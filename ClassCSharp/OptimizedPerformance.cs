using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Viva_vegan.ClassCSharp
{
    static class OptimizedPerformance
    {
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
            if (whichDgv == "ma")
            {
                dgv.Columns["giaban"].DefaultCellStyle.FormatProvider = format;
                dgv.Columns["giaban"].DefaultCellStyle.Format = "c0";
            }
            else if (whichDgv == "tu")
            {
                dgv.Columns["giabanthucuong"].DefaultCellStyle.FormatProvider = format;
                dgv.Columns["giabanthucuong"].DefaultCellStyle.Format = "c0";
            }
            else if (whichDgv == "kh")
            {
                dgv.Columns["tiendatieukh"].DefaultCellStyle.FormatProvider = format;
                dgv.Columns["tiendatieukh"].DefaultCellStyle.Format = "c0";
            }
            return value.ToString("C0", format);
        }
        #endregion
        #region Data Function
        public static async void fromTableToDgv(DataTable table, DataGridView dgv, string whichDgv)
        {
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
                    string dvt = row["DVT"].ToString();
                    string mota = row["MOTA"].ToString();
                    decimal giaban = decimal.Parse(row["GIABAN"].ToString());
                    dgv.Rows.Add(mamon, tenmon, hinh, dvt, mota, giaban);
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
                    decimal giabanthucuong = decimal.Parse(row["GIABAN"].ToString());
                    dgv.Rows.Add(mathucuong, tenthucuong, hinhthucuong, motathucuong, dvtthucuong, giabanthucuong);
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
                    string ngayvaolam = row["NGAYVAOLAM"].ToString();
                    string sotaikhoan = row["SOTAIKHOANNV"].ToString();
                    dgv.Rows.Add(
                        manv, macv, mabp, tennv, dienthoainv, emailnv, diachinv, sotaikhoan, tendangnhapnv, matkhaunv, ngayvaolam
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
                    //string ngaydangky = row["NGAYVAOLAM"].ToString();
                    int rowIndex = dgv.Rows.Add(
                        makh, tenloaikh.ToString(), tenkh, dienthoai, diachi, ngaysinh, email, diem, tiendatieu
                        );
                    dgv.Rows[rowIndex].Tag = maloaikh;
                }
            }
        }
        #endregion
        #region Optimize number of code line
        public static string fromListToString (List<string> temp)
        {
            string res = "{ ";
            foreach(string s in temp)
            {
                res += s + "||";
            }
            res+= "}";
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
            List<string> dataInputList = new List<string>();
            string dateTimeNow ="Vào ngày: "+ DateTime.Now.ToLongDateString()+ " lúc "+DateTime.Now.ToLongTimeString();
            String content = "\n";
            foreach (Control c in con.Controls)
            {
                if(c is TextBox)
                {
                    dataInputList.Add(((TextBox)c).Tag.ToString()+": "+((TextBox)c).Text);
                }
                else if (c is RichTextBox)
                {
                    dataInputList.Add(((RichTextBox)c).Tag.ToString() + ": " + ((RichTextBox)c).Text);
                }
                else if(c is ComboBox)
                {
                    dataInputList.Add(((ComboBox)c).Tag.ToString() + ": " + ((ComboBox)c).Text);
                }
            }
            foreach (string s in dataInputList)
            {
                Console.WriteLine(s);
            }
            if (action.Contains("them"))
            {
                content = ClassCSharp.User.Manv + " đã thêm:\n\t";
                foreach (string item in dataInputList)
                {
                    content += item+"||";
                }
                content += "\n\t" + dateTimeNow;
            }
            else if (action.Contains("sua"))
            {
                DataGridViewRow row = dgv.Rows[dgv.CurrentCell.RowIndex];
                List<string> oldDataList = new List<string>();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    string colname = dgv.Columns[cell.ColumnIndex].HeaderText;
                    string value = cell.Value.ToString();
                    oldDataList.Add(colname+": "+value);
                }
                content = ClassCSharp.User.Manv + " đã sửa: \n\t" + fromListToString(oldDataList)
                    + "\n\t => \n\t" + fromListToString(dataInputList) ;
                content += "\n\t" + dateTimeNow;
            }
            else if (action.Contains("xoa"))
            {
                content = ClassCSharp.User.Manv + " đã xóa:\n\t" + fromListToString(dataInputList);
                content += "\n\t" + dateTimeNow;
            }
            //System.IO.File.WriteLine(@"C:\Users\Public\TestFolder\WriteText.txt", text);
            if(con.Tag.ToString()=="nv")
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
            else if (con.Tag.ToString()=="kh")
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
