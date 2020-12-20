using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Models
{
    public class Employees
    {
        [Key]
        public int EmpNo { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter Name")]
        public string EmpName { get; set; }

        [Display(Name = "Basic Salary")]
        public decimal Basic { get; set; }
        public int DeptNo { get; set; }

        [EmailAddress]
        public string EmailId { get; set; }

        public IEnumerable<SelectListItem> Departments { get; set; }
    }
}