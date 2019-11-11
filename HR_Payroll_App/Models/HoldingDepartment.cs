using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Payroll_App.Models
{
    public class HoldingDepartment
    {
        public int HoldingId { get; set; }

        public Holding Holding { get; set; }

        public int DepatmentId { get; set; }

        public Department Department { get; set; }
    }
}
