

using System.Diagnostics;

namespace N13
{
    public class ProgramN10
    {
        public static void Main(string[] args)
        {
            using (MyDbContext db = new MyDbContext())
            {
                for (int i = 1; i <= 1000000; ++i)
                {
                    db.MyModels.Add(new MyModel { Id = i, Name = $"Name: {i}" });
                }
                db.SaveChanges();
                Console.WriteLine("All entries saved");
                int key = Random.Shared.Next(1000000) + 1;
                Stopwatch sw = Stopwatch.StartNew();
                for (int i = 0; i < 1000; ++i)
                {
                    db.MyModels.Find(key);
                }
                sw.Stop();
                Console.WriteLine($"Avg time to Id find: {sw.Elapsed.TotalMilliseconds / 1000} ms");
                sw.Restart();
                for (int i = 0; i < 1000; ++i)
                {
                    db.MyModels.FirstOrDefault(x => x.Name == $"Name: {key}");
                }

                sw.Stop();
                Console.WriteLine($"Avg time to Name find: {sw.Elapsed.TotalMilliseconds / 1000} ms");
            }
        }
    }
}