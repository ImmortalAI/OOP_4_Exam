namespace N11
{
    public class ProgramN10
    {

        static Action<int> myAction = delegate { };
        static event Action<int> action
        {
            add
            {
                myAction += value;
                Console.WriteLine($"{value.Method.Name} follow");
            }
            remove
            {
                myAction -= value;
                Console.WriteLine($"{value.Method.Name} unfollow");
            }

        }

        static void MyMethod(int prop)
        {
            Console.WriteLine($"My prop is: {prop}");
        }
        public static void Main(string[] args)
        {
            action += MyMethod;
            action -= MyMethod;
            action += MyMethod;
            myAction.Invoke(10);
        }
    }
}