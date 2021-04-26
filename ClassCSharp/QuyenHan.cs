using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viva_vegan.ClassCSharp
{
    class QuyenHan
    {
        private string maqh;
        private string tenqh;
        private string mota;
        private string macv;



        #region Getter, Setter and Construction

        public QuyenHan(string maqh, string tenqh, string mota, string macv)
        {
            this.maqh = maqh;
            this.tenqh = tenqh;
            this.mota = mota;
            this.macv = macv;
        }
        public QuyenHan()
        {
            this.maqh = "";
            this.tenqh = "";
            this.mota = "";
            this.macv = "";
        }
        public QuyenHan(DataRow row)
        {
            this.maqh = row["MAQH"].ToString();
            this.tenqh = row["TENQH"].ToString();
            this.mota = row["MOTA"].ToString();
            this.macv = row["MACV"].ToString();
        }
        public string Quyenhan { get => maqh; set => maqh = value; }
        public string Tenqh { get => tenqh; set => tenqh = value; }
        public string Mota { get => mota; set => mota = value; }
        public string Macv { get => macv; set => macv = value; }
        #endregion

        #region Method

        public string taoMaQH ()
        {
            int count = (int)ConnectDataBase.SessionConnect.executeScalar("select count(*) maqh from quyenhan")+1;
            return "QH" + Convert.ToString( count);
        }
        
        public List<QuyenHan> listQuyenHan(string macv ="")
        {
            List<QuyenHan> listQH = new List<QuyenHan>();
            string query = "select * from quyenhan where macv='" + macv + "'";
            DataTable dt = ConnectDataBase.SessionConnect.executeQuery(query);
            if(dt.Rows.Count>0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    listQH.Add(new QuyenHan(row));
                }
            }
            return listQH;
        }
        #endregion

    }
}
