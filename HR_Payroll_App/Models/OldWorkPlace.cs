using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Payroll_App.Models
{
    public class OldWorkPlace
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        //date
        [Required]
        public DateTime HireDate { get; set; }

        //date
        [Required]
        public DateTime FireDate { get; set; }

        [Required]
        public string FireReason { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }
    }
}
