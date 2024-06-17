using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N14
{
    public class Company
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public virtual List<Employee> Employees { get; set; } = new List<Employee>();
    }
}
