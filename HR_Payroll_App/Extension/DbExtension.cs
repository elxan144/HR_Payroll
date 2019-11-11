using HR_Payroll_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Payroll_App.Extension
{
    public static class DbExtensions
    {
        public static IEnumerable<SelectListItem> GetWorkPlaceSelect<T>(this Payroll_DbContext context, int? Id)
        {
            IEnumerable<SelectListItem> WorkPlaces = null;
            var model = context.Model;

               var entityTypes = model.GetEntityTypes();

            var entityType = entityTypes.First(t => t.ClrType == typeof(T)).Name;

           if(entityType == "HR_Payroll_App.Models.Company")
            {
                 WorkPlaces = context.Companies.Where(x => x.HoldingId == Id.Value)
                                       .Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
            }
          if(entityType == "HR_Payroll_App.Models.Department")
            {
                 WorkPlaces = context.Departments.Where(x => x.Id == Id.Value)
                                       .Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
            }
            if (entityType == "HR_Payroll_App.Models.Position")
            {
                WorkPlaces = context.Positions.Where(x => x.DepartmentId == Id.Value)
                                      .Select(x => new SelectListItem { Text = x.Namme, Value = x.Id.ToString() });
            }

            return WorkPlaces;
        }       
    }
}
