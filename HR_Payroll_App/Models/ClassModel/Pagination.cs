using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Payroll_App.Models.ClassModel
{
    public class Pagination<T> : List<T>
    {
        public int PageIndex { get; private set; }
        public int TotalPage { get; private set; }

        public Pagination(List<T> item, int count, int PageIndex, int Page)
        {
            this.PageIndex = PageIndex;
            TotalPage = (int)Math.Ceiling(count / (decimal)Page);
            this.AddRange(item);
        }

        public bool HasPreviousPage { get { return PageIndex > 1; } }
        public bool NextPreviousPage { get { return PageIndex < TotalPage; } }

        public static Pagination<T> Create(List<T> source, int pageIndex, int Page)
        {
            int count = source.Count();
            var item =  source.Skip((pageIndex - 1) * Page).Take(Page).ToList();
            return new Pagination<T>(item, count, pageIndex, Page);
        }
    }
}
