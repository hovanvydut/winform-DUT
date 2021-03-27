using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_001
{
    public class SV
    {
        public string MSSV { get; private set; }
        public string Ten { get; set; }
        public bool GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public LopSH lopSh { get; set; }

        public SV()
        {
            this.NgaySinh = DateTime.Now;
        }

        public SV(SV sv)
        {
            this.MSSV = sv.MSSV;
            this.Ten = sv.Ten;
            this.GioiTinh = sv.GioiTinh;
            this.NgaySinh = sv.NgaySinh;
            this.lopSh = sv.lopSh;
        }

        public SV(string MSSV, SV sv)
        {
            this.MSSV = MSSV;
            this.Ten = sv.Ten;
            this.GioiTinh = sv.GioiTinh;
            this.NgaySinh = sv.NgaySinh;
            this.lopSh = sv.lopSh;
        }

        public SV(string mssv, string ten, bool gioiTinh, DateTime ngaySinh)
        {
            new SV("200", "", true, ngaySinh, null);
        }

        public SV(string mssv, string ten, bool gioiTinh, DateTime ngaySinh, LopSH lopSH)
        {
            this.MSSV = mssv;
            this.Ten = ten;
            this.GioiTinh = gioiTinh;
            this.NgaySinh = ngaySinh;
            this.lopSh = lopSH;
        }
    }
}
