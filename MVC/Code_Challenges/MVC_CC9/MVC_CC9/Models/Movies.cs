using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC_CC9.Models
{
    public class Movies
    {
        [Required]
        public int mid { get; set; }

        [Required]
        public string movieName { get; set; }

        [Required]
        public string DirectorName { get; set; }

        [Required]
        public DateTime release { get; set; }


    }
}