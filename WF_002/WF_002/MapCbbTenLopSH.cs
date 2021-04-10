using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_002
{
    class MapCbbTenLopSH
    {
        public string tenLopSH { get; set; }
        public int idLopSH { get; set; }

        public MapCbbTenLopSH(string tenLopSH, int idLopSH)
        {
            this.tenLopSH = tenLopSH;
            this.idLopSH = idLopSH;
        }

        public override string ToString()
        {
            return this.tenLopSH;
        }
    }
}
