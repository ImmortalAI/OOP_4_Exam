using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5
{
    internal class Child : Parent
    {
        public override void MyAbstractMethod()
        {
            Console.WriteLine("Hello from child abstract");
        }
        public override void MyVirtualMethod()
        {
            Console.WriteLine("Hello from child");
        }
    }
}
