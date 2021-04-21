using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreeLayerDemo.DTO;
using ThreeLayerDemo.DAL;

namespace ThreeLayerDemo.BLL
{
    class BLL_QLSV
    {
        public delegate bool MyCompare(object o1, object o2);
        private static BLL_QLSV _Instance;
        public static BLL_QLSV Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BLL_QLSV();
                }
                return _Instance;
            }
            private set
            {

            }
        }    

        private BLL_QLSV()
        {

        }

        public List<SV> GetAllSV()
        {
            return DAL_QLSV.Instance.GetAllSV();
        }

        public void AddSV(SV sv)
        {
            DAL_QLSV.Instance.AddSV(sv);
        }
    
        public List<LopSH> GetAllLopSH()
        {
            return DAL_QLSV.Instance.GetAllLopSH();
        }
    
        public void DeleteSVByMSSV(string MSSV)
        {
            DAL_QLSV.Instance.DeleteSVByMSSV(MSSV);
        }

        private static List<SV> GetListSVDGV(List<string> LMSSV)
        {
            List<SV> data = new List<SV>();
            foreach(string MSSV in LMSSV)
            {
                data.Add(DAL_QLSV.Instance.GetSVByMSSV(MSSV));
            }
            return data;
        }
        public static List<SV> ListSVSort(List<string> listMSSV, MyCompare myCompare)
        {
            List<SV> data = GetListSVDGV(listMSSV);

            for (int i = 0; i < data.Count - 1; i++)
            {
                int minOrMaxIdx = i;
                for (int j = i + 1; j < data.Count; j++)
                {
                    if (myCompare(data[minOrMaxIdx], data[j]))
                    {
                        minOrMaxIdx = j;
                    }
                }

                if (minOrMaxIdx != i)
                {
                    SV tmp = data[i];
                    data[i] = data[minOrMaxIdx];
                    data[minOrMaxIdx] = tmp;
                }
            }

            return data;
        }
        public static bool sortNameSVDESC(object o1, object o2)
        {
            return ((SV)o1).NameSV.CompareTo(((SV)o2).NameSV) < 0;
        }
        public static bool sortMSSVDESC(object o1, object o2)
        {
            return ((SV)o1).MSSV.CompareTo(((SV)o2).MSSV) < 0;
        }
        public void Update(SV sv)
        {
            DAL_QLSV.Instance.Update(sv);
        }
        public SV GetSVByMSSV(string MSSV)
        {
            return DAL_QLSV.Instance.GetSVByMSSV(MSSV);
        }
        public List<SV> GetAllSVByIdLop(int ID_Lop)
        {
            return DAL_QLSV.Instance.GetAllSVByIdLop(ID_Lop);
        }
        public static List<SV> searchByText(string txt, List<SV> listSV)
        {
            List<SV> result = new List<SV>();

            foreach (SV sv in listSV)
            {
                if (sv.NameSV.ToLower().Contains(txt.ToLower()))
                {
                    result.Add(sv);
                }
            }

            return result;
        }

        public bool isUniqueId(string mssv)
        {
            return DAL_QLSV.Instance.checkUniqueId(mssv);
        }
    }
}
