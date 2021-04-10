using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListViewDemo
{
    class SV
    {
        public string MSSV { get; set; }
        public string Ten { get; set; }
        public double DTB { get; set; }
        public bool GioiTinh { get; set; }

        public override string ToString()
        {
            return MSSV + ", " + Ten + ", " + DTB.ToString() + ", " + GioiTinh.ToString() + "\n";
        }
    }
}
