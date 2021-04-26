using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viva_vegan.ClassCSharp
{
    class KHACHHANG
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

        public KHACHHANG(string makh, string tenkh, string dienthoaikh, string diachikh, string sotaikhoankh, DateTime ngaysinhkh, string emailkh, long diem, decimal tiendatieu, string maloaikh)
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

        public KHACHHANG()
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

        #endregion

    }
}
