using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5
{
    internal abstract class Parent
    {
        public abstract void MyAbstractMethod();
        public virtual void MyVirtualMethod()
        {
            Console.WriteLine("Hello from parent");
        }
    }
}
