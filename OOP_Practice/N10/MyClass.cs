using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N10
{
    internal class MyClass : IMyInterface
    {
        public void MyMethod1() 
        {
            Console.WriteLine("Hello from MyClass Method 1");
        }
        public void MyMethod2()
        {
            Console.WriteLine("Hello from MyClass Method 2");
        }
        public void MyMethod3()
        {
            Console.WriteLine("Hello from MyClass Method 3");
        }
    }
}
