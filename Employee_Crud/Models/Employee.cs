using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Employee_Crud.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Display(Name = "Employee Name")]


        public string EmployeeName { get; set; }

        public Department Department { get; set; }


        [Display(Name = "Employee Number")]
        public int EmployeePhone { get; set; }


        [Display(Name = "Gender")]
        public string EmployeeGender { get; set; }
        
        public DateTime Birthday { get; set; }

            
        [Display(Name = "Department Name")]
        public int DepartmentId { get; set; }

        //public virtual Department DepartmentName { get; set; }
    }
}