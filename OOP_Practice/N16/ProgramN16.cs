using System.Diagnostics;

namespace N16
{
    public class Program
    {
        public static List<int> times = new List<int>();
        public static void MyMethod(object obj)
        {
            
            int length = Random.Shared.Next(10000000, 15000000);
            int X = (int)obj;
            int[] arr = new int[length];
            for (int i = 0; i < length; ++i)
            {
                arr[i] = Random.Shared.Next(1000);
            }
            Array.Sort(arr);
            Stopwatch sw = Stopwatch.StartNew();
            lock (times)
            {
                sw.Stop();
                int count = arr.Count(x => x == X);
                times.Add((int)sw.Elapsed.TotalMilliseconds);
                Console.WriteLine($"Thread num is: {Thread.CurrentThread.ManagedThreadId}, count of {X} = {count}");
            }
        }
        public static void Main(string[] args)
        {

            object obj = (object)563;
            for (int i = 0; i < 10; ++i)
            {
                ThreadPool.QueueUserWorkItem(MyMethod, obj);
            }
            while (times.Count < 10)
            {
                Thread.Sleep(1000);
            }
            times.RemoveAll(p => p==0);
            times.Sort();
            Console.WriteLine($"maxtime = {times[times.Count - 1]}, mintime = {times[0]}, avg = {times.Sum() / times.Count} ms");


        }
    }
}