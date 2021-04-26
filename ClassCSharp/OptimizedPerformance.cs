using System;
using System.Collections.Generic;
using System.Data;
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
        #region Format function

        #endregion
        #region Data Function
        public static void fromTableToDgv(DataTable table, DataGridView dgv, string whichDgv)
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
                    string tenv = row["TENNV"].ToString();
                    string dienthoainv = row["DIENTHOAINV"].ToString();
                    string emailnv = row["EMAILNV"].ToString();
                    string diachinv = row["DIACHINV"].ToString();
                    string tendangnhapnv = row["TENDANGNHAP"].ToString();
                    string matkhaunv = row["MATKHAUNV"].ToString();

                    dgv.Rows.Add(mathucuong, tenthucuong, hinhthucuong, motathucuong, dvtthucuong, giabanthucuong);
                }
            }
        }
        #endregion
    }
}
