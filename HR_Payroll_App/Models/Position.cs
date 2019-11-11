using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Payroll_App.Models
{
    public class Position
    {
        public Position()
        {
            WorkPlaces = new HashSet<WorkPlace>();
        }

        public int Id { get; set; }

        public string Namme { get; set; }

        public int DepartmentId { get; set; }

        public Department Department { get; set; }

        public List<Salary> Salaries { get; set; }

        public ICollection<WorkPlace> WorkPlaces { get; set; }
    }
}
