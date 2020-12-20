using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCLogin.Models
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please Enter Full Name")]
        public string FullName { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Please Enter Email")]
        public string Email { get; set; }

       
        [Required(ErrorMessage = "Please Enter City")]
        public int CityId { get; set; }

        [Required(ErrorMessage = "Please Enter Phone")]
        public string Phone { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please Enter name")]
        public string Password { get; set; }

        public IEnumerable<SelectListItem> City { get; set; }

        bool rememberme { get; set; }

    }
}