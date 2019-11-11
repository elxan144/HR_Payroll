using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Payroll_App.Models
{
    public class Branch
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsHead { get; set; }

        public int CompanyId { get; set; }

        public Company Company { get; set; }
    }
}
