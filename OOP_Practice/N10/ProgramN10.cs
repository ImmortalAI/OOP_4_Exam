namespace N10
{
    public class ProgramN10
    {
        public static void Main(string[] args)
        {
            IMyInterface tmp = new MyClass();
            tmp.MyMethod1();
            tmp.MyMethod2();
            tmp.MyMethod3();
        }
    }
}