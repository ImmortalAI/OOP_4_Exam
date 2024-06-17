using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N14
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual Company Company { get; set; }

        public int CompanyId { get; set; }
    }
}