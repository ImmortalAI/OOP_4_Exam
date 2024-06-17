using System.Globalization;
using System.Runtime.InteropServices;

namespace N9
{
    public class ProgramN9
    {
        delegate void MyDelegate1(int intProp, string stringProp, bool boolProp);
        delegate int MyDelegate2(int[] intArrProp, double doubleProp);

        static void MyMethod1(int intProp, string stringProp, bool boolProp)
        {
            Console.WriteLine($"My int is: {intProp}, My string is: {stringProp}, My bool is: {boolProp}");
        }

        static int MyMethod2(int[] intArrProp, double doubleProp)
        {
            Console.WriteLine($"My int array is: {String.Join(", ", intArrProp)}, My double is: {doubleProp}");
            return 1;
        }

        public static void Main(string[] args)
        {
            MyDelegate1 md1 = MyMethod1;
            md1 += MyMethod1;
            MyDelegate2 md2 = MyMethod2;
            md2 += MyMethod2;
            md1(10, "abob", true);
            Console.WriteLine(md2(new int [] {15, 20, 30 }, 10.1));
        }
    }
}