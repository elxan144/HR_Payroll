using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Payroll_App.Models
{
    public class Bonus
    {
        public int Id { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public string Reason { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }
    }
}