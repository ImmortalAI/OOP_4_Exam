

using System.Diagnostics;

namespace N14
{
    public class ProgramN10
    {
        public static void Main(string[] args)
        {
            using (MyDbContext db = new MyDbContext())
            {
                Company c1 = new Company {Id=1, Name="Company_1" };
                Company c2 = new Company {Id=2, Name="Company_2" };
                db.companies.AddRange(c1, c2);
                Employee e1 = new Employee { Id = 1, Name = "Employee_1", Company = c1 };
                Employee e2 = new Employee { Id = 2, Name = "Employee_2", Company = c2 };
                Employee e3 = new Employee { Id = 3, Name = "Employee_3", Company = c2 };
                Employee e4 = new Employee { Id = 4, Name = "Employee_4", Company = c1 };
                Employee e5 = new Employee { Id = 5, Name = "Employee_5", Company = c2 };
                db.employees.AddRange(e1, e2, e3, e4, e5);
                db.SaveChanges();

                foreach(var employee in db.employees)
                    Console.WriteLine($"employee name: {employee.Name}, employee company: {employee.Company.Name}");
            }
        }
    }
}