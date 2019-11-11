using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Payroll_App.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string FatherName { get; set; }

        //date
        public DateTime Birthday { get; set; }

        public string Address { get; set; }

        public string RegistrationAddress { get; set; }

        public int PassportId { get; set; }

        //date
        public DateTime PassportExpireDate { get; set; }

        public string Education { get; set; }

        public MaritalStatus MaritalStatus { get; set; }

        public Gender Gender { get; set; }

        public string Photo { get; set; }

        public List<OldWorkPlace> OldWorkPlaces { get; set; }

        public List<WorkPlace> WorkPlaces { get; set; }

        public List<Attendance> Attendances { get; set; }

        public List<Bonus> Bonuses { get; set; }

        public List<Penalty> Penalties { get; set; }

        public List<Vacation> Vacations { get; set; }
    }
}
