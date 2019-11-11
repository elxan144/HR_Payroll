using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Payroll_App.Models.ClassModel
{
    public class EmployeeModel
    {
        public List<Employee> Employees { get; set; }
        public Pagination<Employee> Pagination { get; set; }
    }
}
