using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N7
{
    internal class MyClass<T>
    {
        public void PrintType()
        {
            Console.WriteLine($"Type of generic: {typeof(T)}");
        }
    }
}

