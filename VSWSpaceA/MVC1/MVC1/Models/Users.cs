using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC1.Models
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }

        [DataType(DataType.Text)]
        [MinLength(2),MaxLength(50) ]
        [Required(ErrorMessage = "Please Enter FullName")]
        public string FullName { get; set; }

        [EmailAddress]
        [MinLength(7, ErrorMessage = "Cannot be less than 7 Char"), MaxLength(50)]
        [Required(ErrorMessage = "Please Enter Email")]
        public string Email { get; set; }

        [DataType(DataType.Text)]
        [MinLength(8, ErrorMessage = "Cannot be less than 8 Char"), MaxLength(15,ErrorMessage ="Cannot Exceed 15 Char")]
        [Required(ErrorMessage = "Please Enter Phone")]
        public string Phone { get; set; }

        [Required(ErrorMessage ="Select City")]
        public int CityId { get; set; }

        [DataType(DataType.Password)]
        [MinLength(8), MaxLength(15)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Confirmation Password is required.")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Password and Confirmation Password must match.")]
        public string ConfirmPassword { get; set; }

        public IEnumerable<SelectListItem> City { get; set; }

        public bool RememberMe { get; set; }
    }
}