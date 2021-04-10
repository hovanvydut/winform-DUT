using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WF_002
{
    class CSDL
    {
        private DataTable listSV;
        private DataTable listLopSH;
        private static CSDL _Instance;

        public static CSDL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new CSDL();
                }

                return _Instance;
            }

            private set
            {

            }
        }

        private CSDL()
        {
            this.listSV = new DataTable();
            this.listLopSH = new DataTable();

            this.listSV.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("MSSV", typeof(int)),
                new DataColumn("Ten", typeof(string)),
                new DataColumn("GioiTinh", typeof(bool)),
                new DataColumn("NgaySinh", typeof(DateTime)),
                new DataColumn("Id_Lop", typeof(int))
            });

            this.listLopSH.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("Id", typeof(int)),
                new DataColumn("Ten", typeof(string))
            });

            // Add new data
            DataRow dr1 = this.listLopSH.NewRow();
            dr1["Id"] = 1;
            dr1["Ten"] = "Lop 1";

            DataRow dr2 = this.listLopSH.NewRow();
            dr2["Id"] = 2;
            dr2["Ten"] = "Lop 2";

            this.listLopSH.Rows.Add(dr1);
            this.listLopSH.Rows.Add(dr2);

            DataRow dr3 = this.listSV.NewRow();
            dr3["MSSV"] = 1;
            dr3["Ten"] = "NVA";
            dr3["GioiTinh"] = true;
            dr3["NgaySinh"] = DateTime.Now;
            dr3["Id_Lop"] = 1;

            DataRow dr4 = this.listSV.NewRow();
            dr4["MSSV"] = 2;
            dr4["Ten"] = "NVB";
            dr4["GioiTinh"] = false;
            dr4["NgaySinh"] = DateTime.Now;
            dr4["Id_Lop"] = 1;

            DataRow dr5 = this.listSV.NewRow();
            dr5["MSSV"] = 3;
            dr5["Ten"] = "NVC";
            dr5["GioiTinh"] = true;
            dr5["NgaySinh"] = DateTime.Now;
            dr5["Id_Lop"] = 2;

            DataRow dr6 = this.listSV.NewRow();
            dr6["MSSV"] = 4;
            dr6["Ten"] = "NVD";
            dr6["GioiTinh"] = false;
            dr6["NgaySinh"] = DateTime.Now;
            dr6["Id_Lop"] = 1; 

            this.listSV.Rows.Add(dr3);
            this.listSV.Rows.Add(dr4);
            this.listSV.Rows.Add(dr5);
            this.listSV.Rows.Add(dr6);
        }

        public DataTable GetAllLopSH()
        {
            return this.listLopSH;
        }

        public DataTable GetAllSV()
        {
            return this.listSV;
        }

        public bool SaveSV(DataRow dr)
        {
            foreach (DataRow item in this.listSV.Rows)
            {
                if (item["MSSV"].Equals(dr["MSSV"]))
                {
                    
                    item["Ten"] = dr["Ten"];
                    item["GioiTinh"] = dr["GioiTinh"];
                    item["NgaySinh"] = dr["NgaySinh"];
                    item["Id_Lop"] = dr["Id_Lop"];

                    return true;
                }
            }

            this.listSV.Rows.Add(dr);
            return true;
        }

    }
}
