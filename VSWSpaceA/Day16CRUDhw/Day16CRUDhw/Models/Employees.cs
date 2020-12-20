using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Day16CRUDhw.Models
{
    public class Employees
    {
        [Key]
        public int EmpNo { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please Enter name")]
        [StringLength(10,ErrorMessage = "String Length Exceeded") ]
        public string EmpName { get; set; }

        [Range(1000,1000000,ErrorMessage ="Range btw 1000 - 10000000")]
        [Required(ErrorMessage = "Please Enter Basic")]
        public decimal Basic { get; set; }

        [Required(ErrorMessage = "Please Select DeptNo")]
        public int DeptNo { get; set; }

        [Required(ErrorMessage = "Please Checks")]
        public bool IsActive { get; set; }
        public IEnumerable<Department>Departments { get; set; }

    }
}