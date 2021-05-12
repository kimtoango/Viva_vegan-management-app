﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Drawing;

namespace Viva_vegan.ClassCSharp
{
    static class OptimizedPerformance
    {
        static string key = "Toa@123";
        #region Tăng hiệu suất load data 
        public static void DoubleBuffered(this DataGridView dgv, bool setting)
        {
            Type dgvType = dgv.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",
                  BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(dgv, setting, null);
        }
        #endregion
        #region Format 
        public static string formatCurrency(DataGridView dgv, string whichDgv = null, decimal valueNeedFormat = 0)
        {
            decimal value = valueNeedFormat;
            var format = (NumberFormatInfo)NumberFormatInfo.CurrentInfo.Clone();
            format.CurrencySymbol = "VNĐ ";
            for (int i=0;i<dgv.Columns.Count;i++)
            {
                string headerText = dgv.Columns[i].Name;
                Console.WriteLine(headerText);
                if (headerText.Contains("tien")||headerText.Contains("gia"))
                {
                    dgv.Columns[i].DefaultCellStyle.FormatProvider = format;
                    dgv.Columns[i].DefaultCellStyle.Format = "c0";
                }
            }
            return value.ToString("C0", format);
        }
        public static string formatDate(object datetime)
        {
            DateTime dt = DateTime.Parse(datetime.ToString());
            string s = dt.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            return s;
        }
        public static string formatDateTime(object datetime)
        {
            DateTime dt = DateTime.Parse(datetime.ToString());
            string s = dt.ToString("dd/MM/yyyy HH:mm:ss tt", CultureInfo.InvariantCulture);
            return s;
        }
        #endregion
        #region Data Function
        public static string encryptor(string plainText)
        {
            byte[] byteData = UTF8Encoding.UTF8.GetBytes(plainText);
            string hashedPass = "";
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] byteKey = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                using (TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider()
                { Key = byteKey, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 }
                    )
                {
                    ICryptoTransform transform = tripleDES.CreateEncryptor();
                    byte[] res = transform.TransformFinalBlock(byteData, 0, byteData.Length);
                    hashedPass = Convert.ToBase64String(res);
                }
            }
            return hashedPass;
        }
        public static string decriptor(string hashedPass)
        {
            byte[] byteData = Convert.FromBase64String(hashedPass);
            string normalPass = "";
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] byteKey = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                using (TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider()
                { Key = byteKey, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 }
                    )
                {
                    ICryptoTransform transform = tripleDES.CreateDecryptor();
                    byte[] res = transform.TransformFinalBlock(byteData, 0, byteData.Length);
                    normalPass = UTF8Encoding.UTF8.GetString(res);
                }
            }
            return normalPass;
        }
        // Change color if this row has eliminated status
        public static void changeColorRow(DataGridView dgv)
        {
            int colIndex = 0;
            int count = 1;
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                if (col.HeaderText == "Mã trạng thái")
                {
                    colIndex = col.Index;
                    break;
                }
            }
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (count == dgv.RowCount)
                {

                }
                else
                {
                    if (row.Cells[colIndex].Value.ToString() == "elimi")
                    {
                        row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FB8957");
                    }
                    count++;
                }
            }
        }
        public static async void fromTableToDgv(DataTable table, DataGridView dgv, string whichDgv)
        {
            dgv.Rows.Clear();
            dgv.Refresh();
            if (whichDgv == "monan")
            {
                foreach (DataRow row in table.Rows)
                {
                    string mamon = row["MAMON"].ToString();
                    string tenmon = row["TENMON"].ToString();
                    byte[] hinh = new byte[0];
                    if (row["HINH"] == DBNull.Value)
                    {
                        hinh = null;
                    }
                    else
                    {
                        hinh = (byte[])(row[5]);
                    }
                    string matrangthaimonan = row["matrangthai"].ToString();
                    string ngayxoamon = row["NGAYXOAMON"].ToString();
                    ngayxoamon = (!string.IsNullOrWhiteSpace(ngayxoamon)) ? formatDateTime(ngayxoamon) : "";
                    string dvt = row["DVT"].ToString();
                    string mota = row["MOTA"].ToString();
                    decimal giaban = decimal.Parse(row["GIABAN"].ToString());
                    dgv.Rows.Add(mamon, tenmon, hinh, matrangthaimonan, ngayxoamon, dvt, mota, giaban);
                }
            }
            else if (whichDgv == "thucuong")
            {
                foreach (DataRow row in table.Rows)
                {
                    string mathucuong = row["MATHUCUONG"].ToString();
                    string tenthucuong = row["TENTHUCUONG"].ToString();
                    byte[] hinhthucuong = new byte[0];
                    if (row["HINH"] == DBNull.Value)
                    {
                        hinhthucuong = null;
                    }
                    else
                    {
                        hinhthucuong = (byte[])(row["HINH"]);
                    }
                    string dvtthucuong = row["DVT"].ToString();
                    string motathucuong = row["MOTA"].ToString();
                    string matrangthaithucuong = row["matrangthai"].ToString();
                    string ngayxoathucuong = row["NGAYXOATHUCUONG"].ToString();
                    ngayxoathucuong = (!string.IsNullOrWhiteSpace(ngayxoathucuong)) ? formatDateTime(ngayxoathucuong) : "";
                    decimal giabanthucuong = decimal.Parse(row["GIABAN"].ToString());
                    dgv.Rows.Add(mathucuong, tenthucuong, hinhthucuong, motathucuong, matrangthaithucuong, ngayxoathucuong, dvtthucuong, giabanthucuong);
                }
            }
            else if (whichDgv == "nhanvien")
            {
                foreach (DataRow row in table.Rows)
                {
                    string manv = row["MANV"].ToString();
                    string macv = row["MACV"].ToString();
                    string mabp = row["MABP"].ToString();
                    string tennv = row["TENNV"].ToString();
                    string dienthoainv = row["DIENTHOAINV"].ToString();
                    string emailnv = row["EMAILNV"].ToString();
                    string diachinv = row["DIACHINV"].ToString();
                    string tendangnhapnv = row["TENDANGNHAP"].ToString();
                    string matkhaunv = row["MATKHAU"].ToString();
                    string ngayvaolam = formatDate(row["NGAYVAOLAM"].ToString());
                    string sotaikhoan = row["SOTAIKHOANNV"].ToString();
                    string matrangthainv = row["matrangthai"].ToString();
                    string ngayroikhoi = row["NGAYROIKHOI"].ToString();
                    ngayroikhoi = (!string.IsNullOrWhiteSpace(ngayroikhoi)) ? formatDateTime(ngayroikhoi) : "";
                    dgv.Rows.Add(
                        manv, macv, mabp, tennv, dienthoainv, emailnv, diachinv, sotaikhoan, tendangnhapnv, matkhaunv, matrangthainv, ngayvaolam, ngayroikhoi
                        );
                }
            }
            else if (whichDgv == "khachhang")
            {
                foreach (DataRow row in table.Rows)
                {
                    string makh = row["MAKH"].ToString();
                    string tenkh = row["TENKH"].ToString();
                    string dienthoai = row["DIENTHOAIKH"].ToString();
                    string diachi = row["DIACHIKH"].ToString();
                    string ngaysinh = row["NGAYSINHKH"].ToString();
                    string email = row["EMAILKH"].ToString();
                    int diem = Int32.Parse(row["DIEM"].ToString());
                    decimal tiendatieu = decimal.Parse(row["TIENDATIEU"].ToString());
                    string maloaikh = row["MALOAIKH"].ToString();
                    string query = "select tenloaikh from loaikh where maloaikh='" + maloaikh + "'";
                    var tenloaikh = await ConnectDataBase.SessionConnect.executeScalarAsync(query);
                    string matrangthaikh = row["matrangthai"].ToString();
                    string ngayhuytk = row["NGAYXOATK"].ToString();
                    ngayhuytk = (!string.IsNullOrWhiteSpace(ngayhuytk)) ? formatDateTime(ngayhuytk) : "";
                    int rowIndex = dgv.Rows.Add(
                        makh, tenloaikh.ToString(), tenkh, dienthoai, diachi, ngaysinh, email,matrangthaikh,ngayhuytk, diem, tiendatieu
                        );
                    dgv.Rows[rowIndex].Tag = maloaikh;
                }
            }
            else if (whichDgv == "ban")
            {
                foreach (DataRow row in table.Rows)
                {
                    string maban = row["SOBAN"].ToString();
                    string tenban = row["TENBAN"].ToString();
                    string tinhtrangban = row["TINHTRANGBAN"].ToString();
                    string makhuvuc = row["MAKHUVUC"].ToString();
                    string matrangthai = row["MATRANGTHAI"].ToString();
                    string ngayxoaban = row["ngayxoaban"].ToString();
                    ngayxoaban = (!string.IsNullOrWhiteSpace(ngayxoaban)) ? formatDateTime(ngayxoaban) : "";
                    int rowIndex = dgv.Rows.Add(
                        maban, tenban, tinhtrangban, makhuvuc, matrangthai, ngayxoaban
                        );
                }
            }
            changeColorRow(dgv);
            foreach (DataGridViewColumn c in dgv.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Consolas", 14.25F, GraphicsUnit.Pixel);
            }
        }

        #endregion
        #region Optimize number of code line
        public static void disableButton(params Button[] btns)
        {
            foreach (Button btn in btns)
            {
                btn.Enabled = false;
            }
        }
        public static void enableButton(params Button[] btns)
        {
            foreach (Button btn in btns)
            {
                btn.Enabled = true;
            }
        }
        public static string fromListToString(List<string> temp)
        {
            string res = "{ ";
            foreach (string s in temp)
            {
                res += s + "||";
            }
            res += "}";
            return res;
        }
        public static void ClearAllText(Control con)
        {
            foreach (Control c in con.Controls)
            {
                if (c is TextBox)
                    ((TextBox)c).Clear();
                else if (c is RichTextBox)
                {
                    ((RichTextBox)c).Clear();
                }
                else if (c is ComboBox)
                {
                    ((ComboBox)c).Text = "";
                }
                else if (c is PictureBox)
                {
                    ((PictureBox)c).Image = null;
                }
                else
                    ClearAllText(c);
            }
        }
        public static void SaveHistory(Control con, string action, DataGridView dgv = null)
        {
            String content = "\n";
            string dateTimeNow = "Vào ngày: " + DateTime.Now.ToLongDateString() + " lúc " + DateTime.Now.ToLongTimeString();
            List<string> oldDataList = new List<string>();
            if (!action.Contains("xoa"))
            {
                List<string> dataInputList = new List<string>();
                foreach (Control c in con.Controls)
                {
                    if (c is TextBox)
                    {
                        dataInputList.Add(((TextBox)c).Tag.ToString() + ": " + ((TextBox)c).Text);
                    }
                    else if (c is RichTextBox)
                    {
                        dataInputList.Add(((RichTextBox)c).Tag.ToString() + ": " + ((RichTextBox)c).Text);
                    }
                    else if (c is ComboBox)
                    {
                        dataInputList.Add(((ComboBox)c).Tag.ToString() + ": " + ((ComboBox)c).Text);
                    }
                    else if (c is DateTimePicker)
                    {
                        dataInputList.Add(((DateTimePicker)c).Tag.ToString() + ": " + ((DateTimePicker)c).Value.ToLongDateString());
                    }
                }
                if (action.Contains("them"))
                {
                    content = ClassCSharp.User.Manv + " đã thêm:\n\t";
                    foreach (string item in dataInputList)
                    {
                        content += item + "||";
                    }
                    content += "\n\t" + dateTimeNow;
                }
                else if (action.Contains("sua"))
                {
                    DataGridViewRow row = dgv.Rows[dgv.CurrentCell.RowIndex];
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        string colname = dgv.Columns[cell.ColumnIndex].HeaderText;
                        string value = cell.Value.ToString();
                        oldDataList.Add(colname + ": " + value);
                    }
                    content = ClassCSharp.User.Manv + " đã sửa: \n\t" + fromListToString(oldDataList)
                        + "\n\t => \n\t" + fromListToString(dataInputList);
                    content += "\n\t" + dateTimeNow;
                }
            }

            else if (action.Contains("xoa"))
            {
                string madoituong="";

                DataGridViewRow row = dgv.Rows[dgv.CurrentCell.RowIndex];
                if (con.Tag.ToString() == "nv")
                {
                    madoituong = row.Cells["manv"].Value.ToString();
                }
                else
                {
                    madoituong = row.Cells["makh"].Value.ToString();
                }
                content = User.Manv + " đã xóa:\n\t" + madoituong;
                content += "\n\t" + dateTimeNow;
            }
            //System.IO.File.WriteLine(@"C:\Users\Public\TestFolder\WriteText.txt", text);
            if (con.Tag.ToString() == "nv")
            {
                if (!File.Exists("Staff_history.txt")) // If file does not exists
                {
                    File.Create("Staff_history.txt").Close(); // Create file
                }
                using (StreamWriter sw = new StreamWriter(File.Open(@".\Staff_history.txt", FileMode.Append), Encoding.UTF8))
                {
                    sw.WriteLine(content);
                }
            }
            else if (con.Tag.ToString() == "kh")
            {
                if (!File.Exists("Customer_history.txt")) // If file does not exists
                {
                    File.Create("Customer_history.txt").Close(); // Create file
                }
                using (StreamWriter sw = new StreamWriter(File.Open(@".\Customer_history.txt", FileMode.Append), Encoding.UTF8))
                {
                    sw.WriteLine(content);
                }
            }
        }
        #endregion
    }
}
