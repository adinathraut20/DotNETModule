using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Department
    {
        [Key]
        public int DeptNo { get; set; }

        [Required(ErrorMessage = "Enter Department Name")]
        public string DeptName { get; set; }
    }
}