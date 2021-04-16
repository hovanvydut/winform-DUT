using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreeLayerDemo.DTO;
using System.Data;

namespace ThreeLayerDemo.DAL
{
    class DAL_QLSV
    {
        private static DAL_QLSV _Instance;
        public static DAL_QLSV Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new DAL_QLSV();
                }
                return _Instance;
            }
            private set
            {

            }
        }

        private DAL_QLSV()
        {

        }
        
        public List<SV> GetAllSV()
        {
            List<SV> list = new List<SV>();
            string query = "SELECT * FROM SV";

            foreach (DataRow dr in DBHelper.Instance.GetRecords(query).Rows)
            {
                list.Add(ExtractSV(dr));
            }

            return list;
        }

        public void AddSV(SV sv)
        {
            string query = String.Format("INSERT INTO SV(NameSV, Gender, NS, ID_Lop) VALUES ('{0}', {1}, '{2}', {3})",
                sv.NameSV, sv.Gender ? 1 : 0, sv.NS.Date.ToString(), sv.ID_Lop);

            DBHelper.Instance.ExecuteDB(query);
        }

        public List<LopSH> GetAllLopSH()
        {
            List<LopSH> list = new List<LopSH>();
            string query = "SELECT * FROM LopSH";
            
            foreach (DataRow dr in DBHelper.Instance.GetRecords(query).Rows)
            {
                list.Add(ExtractLopSH(dr));
            }

            return list;
        }

        private static SV ExtractSV(DataRow dr)
        {
            return new SV()
            {
                MSSV = Convert.ToInt32(dr["MSSV"]),
                NameSV = dr["NameSV"].ToString(),
                Gender = Convert.ToBoolean(dr["Gender"]),
                NS = Convert.ToDateTime(dr["NS"]),
                ID_Lop = Convert.ToInt32(dr["ID_Lop"])
            };
        }

        private static LopSH ExtractLopSH(DataRow dr)
        {
            return new LopSH()
            {
                ID_Lop = Convert.ToInt32(dr["ID_Lop"]),
                NameLop = dr["NameLop"].ToString()
            };
        }
    
        public void DeleteSVByMSSV(int MSSV)
        {
            string query = String.Format("DELETE FROM SV WHERE MSSV = {0}", MSSV);
            DBHelper.Instance.ExecuteDB(query);
        }
        
        public SV GetSVByMSSV(int MSSV)
        {
            string query = String.Format("SELECT * FROM SV WHERE MSSV = {0}", MSSV);
            return ExtractSV(DBHelper.Instance.GetRecords(query).Rows[0]);
        }

        public void Update(SV sv)
        {
            string query =
                String.Format("UPDATE SV SET NameSV = '{0}', Gender = {1}, NS = '{2}', ID_Lop = {3} WHERE MSSV = {4}",
                sv.NameSV, sv.Gender ? 1 : 0, sv.NS.Date.ToString(), sv.ID_Lop, sv.MSSV);
            DBHelper.Instance.ExecuteDB(query);
        }

        public List<SV> GetAllSVByIdLop(int ID_Lop)
        {
            List<SV> list = new List<SV>();
            string query = String.Format("SELECT * FROM SV WHERE ID_Lop = {0}", ID_Lop);

            foreach (DataRow dr in DBHelper.Instance.GetRecords(query).Rows)
            {
                list.Add(ExtractSV(dr));
            }

            return list;
        }
    }
}
