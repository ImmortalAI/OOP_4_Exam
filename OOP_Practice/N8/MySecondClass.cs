using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N8
{
    internal class MySecondClass
    {
        public int intProp { get; set; }
        public string stringProp { get; set;}

        public MySecondClass(int p1, string p2) 
        {
            intProp = p1;
            stringProp = p2;
        }
    }
}
