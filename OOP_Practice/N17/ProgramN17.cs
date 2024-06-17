using System.Diagnostics;

namespace N17
{
    
    public class Program
    {
        public static void Main(string[] args)
        {
            ThreadPool.QueueUserWorkItem((o) =>
            {
                while (true)
                {
                    Console.ReadLine();
                    Console.WriteLine("Enter button was pressed");
                }
            }, new object());
           while(true)
            {

            }
        }
    }
}