using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechWizard.Data.Models.Entities
{
    public class WizardUser : IdentityUser
    {
        [Required(ErrorMessage = "You didn't enter your first name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "You didn't enter your last name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "You didn't enter city")]
        public string City { get; set; }
        [Required(ErrorMessage = "You didn't enter your street address")]
        public string StreetAddress { get; set; }
    }
}
