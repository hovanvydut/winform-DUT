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
            dtSV.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("MSSV", typeof(string)),
                new DataColumn("Ten", typeof(string)),
                new DataColumn("GioiTinh", typeof(bool)),
                new DataColumn("NgaySinh", typeof(DateTime)),
                new DataColumn("Id_Lop", typeof(int))
            });

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

        public DataTable FilterSVByLopSH(int idLopSH)
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[]
            {
                    new DataColumn("MSSV", typeof(string)),
                    new DataColumn("Ten", typeof(string)),
                    new DataColumn("GioiTinh", typeof(bool)),
                    new DataColumn("NgaySinh", typeof(DateTime)),
                    new DataColumn("Id_Lop", typeof(int))
            });

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
            dt.Columns.AddRange(new DataColumn[]
            {
                    new DataColumn("MSSV", typeof(string)),
                    new DataColumn("Ten", typeof(string)),
                    new DataColumn("GioiTinh", typeof(bool)),
                    new DataColumn("NgaySinh", typeof(DateTime)),
                    new DataColumn("Id_Lop", typeof(int))
            });

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
            this.dtSV = dt;
            return dt;
        }
    }
}
