namespace N8
{
    public class ProgramN8
    {
        public static void Main(string[] args)
        {
            MyFirstClass<MySecondClass> tmp = new MyFirstClass<MySecondClass>();
            //MyFirstClass<int> error = new MyFirstClass<int>();
        }
    }
}