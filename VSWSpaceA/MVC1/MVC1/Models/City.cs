using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC1.Models
{
    public class City
    {
        [Key]
        int Id { get; set; }


        string CityName { get; set; }
    }
}