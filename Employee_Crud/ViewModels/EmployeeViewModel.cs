using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Employee_Crud.Models;

namespace Employee_Crud.ViewModels
{
    public class EmployeeViewModel
    {
        public IEnumerable<Department> Department { get; set; }
        public Employee Employee { get; set; }
    }
}