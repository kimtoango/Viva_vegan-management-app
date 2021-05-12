using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viva_vegan.ClassCSharp
{
    public class Ban
    {
        private String soban;
        private String tenban;
        private String trangthai;
        private String makhuvuc;
        private String matrangthai; //Trạng thái còn sử dụng hay không
        private String ngayxoaban;
        #region Getter and Setter 
        public Ban(string soban, string tenban, string trangthai, string makhuvuc, string matrangthai, String ngayxoaban)
        {
            this.Soban = soban;
            this.Tenban = tenban;
            this.Trangthai = trangthai;
            this.Makhuvuc = makhuvuc;
            this.Matrangthai = matrangthai;
            this.Ngayxoaban = ngayxoaban;
        }
        public Ban()
        {

        }
        public Ban( DataRow row)
        {
            this.Soban = row["soban"].ToString();
            this.Tenban = row["tenban"].ToString();
            this.Trangthai = row["tinhtrangban"].ToString();
            this.Makhuvuc = row["makhuvuc"].ToString();
            this.Matrangthai = row["matrangthai"].ToString();
        }

        public string Soban { get => soban; set => soban = value; }
        public string Tenban { get => tenban; set => tenban = value; }
        public string Trangthai { get => trangthai; set => trangthai = value; }
        public string Makhuvuc { get => makhuvuc; set => makhuvuc = value; }
        public string Matrangthai { get => matrangthai; set => matrangthai = value; }
        public String Ngayxoaban { get => ngayxoaban; set => ngayxoaban = value; }

        #endregion
        #region Methods
        public List<Ban> loadList(String makhuvuc)
        {
            String query = "select * from ban";
            if (!String.IsNullOrWhiteSpace(makhuvuc))
            {
                query = "select * from ban where makhuvuc='" +
                    makhuvuc + "'";
            }
            List<Ban> list = new List<Ban>();
            DataTable table = ConnectDataBase.SessionConnect.executeQuery(query);
            foreach (DataRow row in table.Rows)
            {
                list.Add(new Ban(
                    row["soban"].ToString(),
                    row["tenban"].ToString(),
                    row["tinhtrangban"].ToString(),
                    row["makhuvuc"].ToString(),
                    row["matrangthai"].ToString(),
                    row["ngayxoaban"].ToString()
                    ));

            }
            return list;
        }
        public async Task<DataTable> loadTableBan()
        {
            String query = "select * from ban";
            var table =await ConnectDataBase.SessionConnect.executeQueryAsync(query);
            return table;
        }
        public int setBusy (String maban)
        {
            string query = "update ban set tinhtrangban = 'busy' where soban='" + maban+
                "'";
            int result = ConnectDataBase.SessionConnect.executeNonQuery(query);
            return result;
        }
        public int setEmpty(String maban)
        {
            string query = "update ban set tinhtrangban = 'empty' where soban='" + maban +
                "'";
            int result = ConnectDataBase.SessionConnect.executeNonQuery(query);
            return result;
        }
        public int setAllBanEmpty ()
        {
            string query = "update ban set tinhtrangban = 'empty' ";
            int result = ConnectDataBase.SessionConnect.executeNonQuery(query);
            return result;
        }
        #endregion
    }
}
