using System.Diagnostics;

namespace N15
{
    public class Program
    {
        public static List<int> times = new List<int>();
        public static void MyMethod(object obj)
        {
            Stopwatch sw = Stopwatch.StartNew(); 
            int length = Random.Shared.Next(10000000, 15000000);
            int X = (int)obj;
            int[] arr = new int[length];
            for (int i = 0; i < length; ++i)
            {
                arr[i] = Random.Shared.Next(1000);
            }
            Array.Sort(arr);
            int count = arr.Count(x => x == X);
            Console.WriteLine($"Thread num is: {Thread.CurrentThread.ManagedThreadId}, count of {X} = {count}");
            sw.Stop();
            lock (times)
            {
                times.Add((int)sw.Elapsed.TotalMilliseconds);
            }
        }
        public static void Main(string[] args)
        {
            
            object obj = (object)563;
            for (int i = 0; i < 10; ++i)
            {
                ThreadPool.QueueUserWorkItem(MyMethod, obj);
            }
            while(times.Count < 10)
            {
                Thread.Sleep(1000);
            }
            times.Sort();
            Console.WriteLine($"maxtime = {times[times.Count-1]}, mintime = {times[0]}, avg = {times.Sum()/times.Count} ms");


        }
    }
}