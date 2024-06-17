using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N6
{
    internal class MyClass
    {

        public int prop1 {  get; set; } 
        public int prop2 {  get; set; } 
        public MyClass(int prop1, int prop2)
        {
            this.prop1 = prop1;
            this.prop2 = prop2;
        }

        public static int operator+(MyClass x)
        {
            return (x.prop1 + x.prop2);
        }
    }
}
