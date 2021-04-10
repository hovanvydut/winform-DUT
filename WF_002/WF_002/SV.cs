using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_002
{
    class SV
    {
        public int MSSV { get; private set; }
        public string Ten { get; set; }
        public bool GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public int LopSHId { get; set; }

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
            this.LopSHId = sv.LopSHId;
        }

        public SV(int MSSV, SV sv)
        {
            this.MSSV = MSSV;
            this.Ten = sv.Ten;
            this.GioiTinh = sv.GioiTinh;
            this.NgaySinh = sv.NgaySinh;
        }

        public SV(int mssv, string ten, bool gioiTinh, DateTime ngaySinh)
        {
            this.MSSV = mssv;
            this.Ten = ten;
            this.GioiTinh = gioiTinh;
            this.NgaySinh = ngaySinh;
        }

        public SV(int mssv, string ten, bool gioiTinh, DateTime ngaySinh, int idLopSH)
        {
            this.MSSV = mssv;
            this.Ten = ten;
            this.GioiTinh = gioiTinh;
            this.NgaySinh = ngaySinh;
            this.LopSHId = idLopSH;
        }

    }
}
