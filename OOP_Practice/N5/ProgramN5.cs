namespace N5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Child child = new Child();
            child.MyAbstractMethod();
            child.MyVirtualMethod();
        }
    }
}
