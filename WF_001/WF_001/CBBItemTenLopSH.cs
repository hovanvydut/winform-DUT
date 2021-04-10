using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_001
{
    class CBBItemTenLopSH
    {
        public int value { get; set; }
        public string text { get; set; }

        public CBBItemTenLopSH(int value, string text)
        {
            this.value = value;
            this.text = text;
        }

        public override string ToString()
        {
            return this.text;
        }
    }
}
