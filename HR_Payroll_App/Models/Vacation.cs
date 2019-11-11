using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Payroll_App.Models
{
    public class Vacation
    {
        public int Id { get; set; }

        //date
        public DateTime Start { get; set; }

        //date
        public DateTime End { get; set; }

        public int Employeeİd { get; set; }

        public Employee Employee { get; set; }
    }
}
