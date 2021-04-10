
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_001
{
    public class LopSH
    {
        public int Id { get; private set; }
        public string Ten { get; private set; }

        public LopSH()
        {
            new LopSH(0, "No Name");
        }

        public LopSH(LopSH lop)
        {
            this.Id = lop.Id;
            this.Ten = lop.Ten;
        }

        public LopSH(int Id, string Ten)
        {
            this.Id = Id;
            this.Ten = Ten;
        }
    }
}
