using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viva_vegan.ClassCSharp
{
    class KhachHang
    {
        private string makh;
        private string tenkh;
        private string dienthoaikh;
        private string diachikh;
        private string sotaikhoankh;
        private DateTime ngaysinhkh;
        private string emailkh;
        private long diem;
        private decimal tiendatieu;
        private string maloaikh;

        public string Makh { get => makh; set => makh = value; }
        public string Tenkh { get => tenkh; set => tenkh = value; }
        public string Dienthoaikh { get => dienthoaikh; set => dienthoaikh = value; }
        public string Diachikh { get => diachikh; set => diachikh = value; }
        public string Sotaikhoankh { get => sotaikhoankh; set => sotaikhoankh = value; }
        public DateTime Ngaysinhkh { get => ngaysinhkh; set => ngaysinhkh = value; }
        public string Emailkh { get => emailkh; set => emailkh = value; }
        public long Diem { get => diem; set => diem = value; }
        public decimal Tiendatieu { get => tiendatieu; set => tiendatieu = value; }
        public string Maloaikh { get => maloaikh; set => maloaikh = value; }

        public KhachHang(string makh, string tenkh, string dienthoaikh, string diachikh, string sotaikhoankh, DateTime ngaysinhkh, string emailkh, long diem, decimal tiendatieu, string maloaikh)
        {
            this.Makh = makh;
            this.Tenkh = tenkh;
            this.Dienthoaikh = dienthoaikh;
            this.Diachikh = diachikh;
            this.Sotaikhoankh = sotaikhoankh;
            this.Ngaysinhkh = ngaysinhkh;
            this.Emailkh = emailkh;
            this.Diem = diem;
            this.Tiendatieu = tiendatieu;
            this.Maloaikh = maloaikh;
        }

        public KhachHang()
        {
            this.Makh = "";
            this.Tenkh = "";
            this.Dienthoaikh = "";
            this.Diachikh = "";
            this.Sotaikhoankh = "";
            this.Ngaysinhkh = DateTime.Now;
            this.Emailkh = "";
            this.Diem = 0;
            this.Tiendatieu = 0;
            this.Maloaikh = "";
        }
        #region Method
        public async Task<string> taoMaKh ()
        {
            string query = "select makh from khachhang";
            string result = "";
            int max = 0;
            DataTable table = await ConnectDataBase.SessionConnect.executeQueryAsync(query);
            foreach (DataRow row in table.Rows)
            {
                string makh = row["MAKH"].ToString();
                int i = int.Parse(makh.Substring(2, makh.Length - 2));
                if (max <= i)
                {
                    max = i;
                }
            }
            return "KH" + (max + 1).ToString();
        }
        public async Task<DataTable> loadTableKhachHang (string input, String timTheo =null)
        {
            String query = "select * from khachhang";
            if (String.IsNullOrWhiteSpace(input))
            {
                query = "select * from khachhang";
                DataTable table = await ConnectDataBase.SessionConnect.executeQueryAsync(query);
                return table;
            }
            else
            {

                if (timTheo.Contains("Tên"))
                {
                    query = "select * from khachhang where tenkh like N'%" +
                    input.Trim() + "%'";
                }
                else if (timTheo.Contains("Mã"))
                {
                    query = "select * from khachhang where makh like '%" +
                    input.Trim() + "%'";
                }
                DataTable table = await ConnectDataBase.SessionConnect.executeQueryAsync(query);
                return table;
            }
        }
        #endregion

    }
}
