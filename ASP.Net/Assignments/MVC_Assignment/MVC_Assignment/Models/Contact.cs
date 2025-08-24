using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC_Assignment.Models
{
    public class Contact
    {
        public long Id { get; set; }

        [Required]
        [StringLength(20, ErrorMessage ="The FirstName Must be Less than 20 Characters...")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "The LastName Must be Less than 20 Characters...")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage ="Enter The Valid Format for Email")]
        public string Email { get; set; }
    }
}