using System;
using System.Collections.Generic;
using System.Data;

namespace WF_002
{
    class CSDL_OOP
    {

        private CSDL CSDL;
        private static CSDL_OOP _Instance;
        public delegate bool MyCompare(SV sv1, SV sv2);

        public static CSDL_OOP Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new CSDL_OOP();
                }

                return _Instance;
            }

            private set
            {

            }
        }

        private CSDL_OOP()
        {
            this.CSDL = CSDL.Instance;
        }

        public List<LopSH> GetAllLopSH()
        {
            List<LopSH> listLopSH = new List<LopSH>();
            foreach(DataRow drLopSH in CSDL.Instance.GetAllLopSH().Rows)
            {
                LopSH lopSH = ParseLopSH(drLopSH);
                listLopSH.Add(lopSH);
            }

            return listLopSH;
        }

        public List<SV> GetAllSV()
        {
            List<SV> listSV = new List<SV>();

            foreach(DataRow drSV in CSDL.Instance.GetAllSV().Rows)
            {
                listSV.Add(ParseSV(drSV));
            }

            return listSV;
        }

        public SV FindSVByMSSV(int MSSV)
        {
            foreach (SV sv in GetAllSV())
            {
                if (sv.MSSV == MSSV)
                {
                    return new SV(sv);
                }
            }
            return null;
        }

        // lopSHId = 0 then get all SV
        public List<SV> FindSVsByLopSHId(int lopSHId)
        {
            List<SV> listSV = new List<SV>();

            foreach (DataRow drSV in CSDL.Instance.GetAllSV().Rows)
            {
                SV sv = ParseSV(drSV);
                if (sv.LopSHId == lopSHId || lopSHId == 0)
                {
                    listSV.Add(sv);
                }
            }

            return listSV;
        }

        public bool DeleteSVByMSSV(int MSSV)
        {
            try
            {
                foreach(DataRow dr in CSDL.Instance.GetAllSV().Rows)
                {
                    if (dr["MSSV"].Equals(MSSV))
                    {
                        CSDL.Instance.GetAllSV().Rows.Remove(dr);
                        return true;
                    }
                }

                return false;
            } catch(Exception e)
            {
                return false;
            }
        }

        public LopSH FindLopSHById(int id)
        {
            foreach (DataRow drLopSH in CSDL.Instance.GetAllLopSH().Rows)
            {
                LopSH lopSH = ParseLopSH(drLopSH);
                if (lopSH.Id == id)
                {
                    return lopSH;
                }
            }

            return null;
        }

        private static SV ParseSV(DataRow drSV)
        {
            int mssv = Convert.ToInt32(drSV["MSSV"].ToString());
            string ten = drSV["Ten"].ToString();
            bool gioiTinh = Convert.ToBoolean(drSV["GioiTinh"].ToString());
            DateTime ngaySinh = Convert.ToDateTime(drSV["NgaySinh"].ToString());
            int idLop = Convert.ToInt32(drSV["Id_Lop"].ToString());

            return new SV(mssv, ten, gioiTinh, ngaySinh, idLop);
        }

        private static LopSH ParseLopSH(DataRow drLopSH)
        {
            string idLopSH = drLopSH["Id"].ToString();
            int id = Convert.ToInt32(idLopSH);
            string Ten = drLopSH["Ten"].ToString();

            return new LopSH(id, Ten);
        }
    
        public static List<SV> SortBy(MyCompare myCompare, List<SV> listSV)
        {
            List<SV> sortedList = CloneListSV(listSV);
            int n = sortedList.Count;

            for (int i = 0; i < n - 1; i++)
            {
                int minOrMaxIdx = i;
                for (int j = i + 1; j < n; j++)
                {
                    SV sv2 = sortedList[j];
                    if (myCompare(sortedList[minOrMaxIdx], sv2))
                    {
                        minOrMaxIdx = j;
                    }
                }

                if (minOrMaxIdx != i)
                {
                    SV tmp = sortedList[i];
                    sortedList[i] = sortedList[minOrMaxIdx];
                    sortedList[minOrMaxIdx] = tmp;
                }
            }

            return sortedList;
        }

        public static bool CompareTenDESC(SV sv1, SV sv2)
        {
            return sv1.Ten.CompareTo(sv2.Ten) < 0;
        }

        public static bool CompareMSSVDESC(SV sv1, SV sv2)
        {
            return sv1.MSSV < sv2.MSSV;
        }

        private static List<SV> CloneListSV(List<SV> listSV)
        {
            List<SV> result = new List<SV>();

            for (int i = 0; i < listSV.Count; i++)
            {
                result.Add(new SV(listSV[i]));
            }

            return result;
        }

        public static int GenAutoId()
        {
            List<SV> listSV = CSDL_OOP.Instance.GetAllSV();
            int maxId = 0;
            foreach (SV sv in listSV)
            {
                if (sv.MSSV > maxId)
                {
                    maxId = sv.MSSV;
                }
            }

            return maxId + 1;
        }

        public bool SaveSV(SV sv)
        {
            DataRow dr = CSDL.Instance.GetAllSV().NewRow();
            dr["MSSV"] = sv.MSSV;
            dr["Ten"] = sv.Ten;
            dr["GioiTinh"] = sv.GioiTinh;
            dr["NgaySinh"] = sv.NgaySinh;
            dr["Id_Lop"] = sv.LopSHId;

            return CSDL.Instance.SaveSV(dr);
        }
    }
}
