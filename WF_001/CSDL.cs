using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WF_001
{
    class CSDL
    {
        public delegate int MyCompare(DataRow p1, DataRow p2);
        private static int trackID = 104;
        public List<SV> listSV = new List<SV>();
        private List<LopSH> listLopSH = new List<LopSH>();
        public DataTable dtSV { get; set; }
        public DataTable dtLopSH { get; set; }
        internal static CSDL Instance
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

        private static CSDL _Instance;

        private CSDL()
        {
            // DataTable danh sach lop
            dtLopSH = new DataTable();
            dtLopSH.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("Id", typeof(int)),
                new DataColumn("Ten", typeof(string))
            });

            // Datatable danh sach SV
            dtSV = new DataTable();
            createDataColumnForSVDataTable(dtSV);

            // Khoi tao du lieu (sau nay se load tu DB ra)
            LopSH lop1 = new LopSH(1, "Lop 1");
            LopSH lop2 = new LopSH(2, "Lop 2");
            this.listLopSH.AddRange(new LopSH[]
            {
                lop1, lop2
            });

            this.listSV.AddRange(new SV[]
            {
                new SV("101", "NVA", true, DateTime.Now, lop1),
                new SV("102", "NVB", false, DateTime.Now, lop1),
                new SV("103", "NVC", true, DateTime.Now, lop2),
                new SV("104", "NVD", false, DateTime.Now, lop2),
            });

            foreach (LopSH lopSH in this.listLopSH)
            {
                DataRow dr = dtLopSH.NewRow();
                dr["Id"] = lopSH.Id;
                dr["Ten"] = lopSH.Ten;

                dtLopSH.Rows.Add(dr);
            }


            foreach (SV sv in this.listSV)
            {
                DataRow dr = dtSV.NewRow();
                dr["MSSV"] = sv.MSSV;
                dr["Ten"] = sv.Ten;
                dr["GioiTinh"] = sv.GioiTinh;
                dr["NgaySinh"] = sv.NgaySinh;
                dr["Id_Lop"] = sv.lopSh.Id;

                dtSV.Rows.Add(dr);
            }
        }

        private void createDataColumnForSVDataTable(DataTable dt)
        {
            dt.Columns.AddRange(new DataColumn[]
            {
                    new DataColumn("MSSV", typeof(string)),
                    new DataColumn("Ten", typeof(string)),
                    new DataColumn("GioiTinh", typeof(bool)),
                    new DataColumn("NgaySinh", typeof(DateTime)),
                    new DataColumn("Id_Lop", typeof(int))
            });
        }

        public DataTable FilterSVByLopSH(int idLopSH)
        {
            DataTable dt = new DataTable();
            createDataColumnForSVDataTable(dt);

            foreach (SV sv in this.listSV)
            {
                // neu khong phai la All thi xet id cua lop
                if (idLopSH != 0)
                    if (idLopSH != sv.lopSh.Id) 
                        continue;

                DataRow dr = dt.NewRow();
                dr["MSSV"] = sv.MSSV;
                dr["Ten"] = sv.Ten;
                dr["GioiTinh"] = sv.GioiTinh;
                dr["NgaySinh"] = sv.NgaySinh;
                dr["Id_Lop"] = sv.lopSh.Id;

                dt.Rows.Add(dr);
            }
            this.dtSV = dt;
            return dt;
        }

        public LopSH GetLopSHById(int idLopSH)
        {
            foreach (LopSH lopSh in this.listLopSH)
            {
                if (lopSh.Id == idLopSH)
                {
                    return new LopSH(lopSh);
                }
            }

            return null;
        }

        public SV GetSVByMSSV(string MSSV)
        {
            foreach(SV sv in this.listSV)
            {
                if (sv.MSSV.Equals(MSSV))
                {
                    return new SV(sv);
                }
            }
            return null;
        }

        public bool UpdateSV(SV sv)
        {
            foreach(SV itemSV in this.listSV)
            {
                if (sv.MSSV == itemSV.MSSV)
                {
                    this.listSV.Remove(itemSV);
                    this.listSV.Add(sv);
                    return true;
                }
            }

            return false;
        }

        public bool AddNewSV(SV sv)
        {
            this.listSV.Add(sv);
            return true;
        }


        public string GenerateIdForSV()
        {
            return Convert.ToString(++trackID);
        }

        public bool deleteSVByMSSV(string MSSV)
        {
            foreach (SV sv in this.listSV)
            {
                if (sv.MSSV.Equals(MSSV))
                {
                    this.listSV.Remove(sv);
                    return true;
                }
            }

            return false;
        }

        public DataTable searchByName(string txt)
        {
            DataTable dt = new DataTable();
            createDataColumnForSVDataTable(dt);

            foreach(DataRow dr in this.dtSV.Rows)
            {
                DataRow newDr = dt.NewRow();
                string Ten = (string)dr["Ten"];
                if (Ten.StartsWith(txt))
                {
                    newDr["MSSV"] = dr["MSSV"];
                    newDr["Ten"] = dr["Ten"];
                    newDr["GioiTinh"] = dr["GioiTinh"];
                    newDr["NgaySinh"] = dr["NgaySinh"];
                    newDr["Id_Lop"] = dr["Id_Lop"];

                    dt.Rows.Add(newDr);
                }
            }
            return dt;
        }

        public int CompareMSSV(DataRow p1, DataRow p2)
        {
            string s1 = (string)p1["MSSV"];
            string s2 = (string)p2["MSSV"];
            return String.Compare(s1, s2);
        }

        public int CompareTen(DataRow p1, DataRow p2)
        {
            string s1 = (string)p1["Ten"];
            string s2 = (string)p2["Ten"];
            return String.Compare(s1, s2);
        }

        public DataTable sortBy(MyCompare myCompare)
        {
            // use shadow clone
            DataTable dt = new DataTable();
            createDataColumnForSVDataTable(dt);
            ShadowCloneSVDataTable(dt, this.dtSV);

            for (int i = dt.Rows.Count - 1; i >= 1; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    DataRow p1 = cloneSVDataRow(dt, dt.Rows[j]);
                    DataRow p2 = cloneSVDataRow(dt, dt.Rows[j+1]);
                    string s1 = (string)p1["MSSV"];
                    string s2 = (string)p2["MSSV"];
                    if (myCompare(p1, p2) < 0)
                    {
                        dt.Rows.RemoveAt(j);
                        dt.Rows.InsertAt(p2, j);
                        dt.Rows.RemoveAt(j+1);
                        dt.Rows.InsertAt(p1, j + 1);
                    }
                }
            }

            return dt;
        }

        private void ShadowCloneSVDataTable(DataTable dest, DataTable src)
        {
            foreach (DataRow dr in src.Rows)
            {
                //DataRow newDr = dest.NewRow();

                //newDr["MSSV"] = dr["MSSV"];
                //newDr["Ten"] = dr["Ten"];
                //newDr["GioiTinh"] = dr["GioiTinh"];
                //newDr["NgaySinh"] = dr["NgaySinh"];
                //newDr["Id_Lop"] = dr["Id_Lop"];

                dest.Rows.Add(cloneSVDataRow(dest, dr));
            }
        }

        private DataRow cloneSVDataRow(DataTable dt, DataRow dr)
        {
            DataRow newDr = dt.NewRow();

            newDr["MSSV"] = dr["MSSV"];
            newDr["Ten"] = dr["Ten"];
            newDr["GioiTinh"] = dr["GioiTinh"];
            newDr["NgaySinh"] = dr["NgaySinh"];
            newDr["Id_Lop"] = dr["Id_Lop"];

            return newDr;
        }
    }
}
