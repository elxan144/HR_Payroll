using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Payroll_App.Models
{
    public class Salary
    {
        public int Id { get; set; }

        public decimal Amount { get; set; }

        public int PositionId { get; set; }

        public Position Position { get; set; }

        public int CompanyId { get; set; }

        public Company Company { get; set; }
    }
}
