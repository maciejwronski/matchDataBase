using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    class Format
    {
        private string ab { get; set; }
        private string bc { get; set; }

        public Format(string a, string b)
        {
            ab = a;
            bc = b;
        }
        public override string ToString()
        {
            return string.Format("{0}, {1}", ab, bc);
        }
    }
}
