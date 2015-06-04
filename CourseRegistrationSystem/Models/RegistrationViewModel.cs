using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CourseRegistration.Models;
using System.ComponentModel.DataAnnotations;

namespace CourseRegistrationSystem.Models
{
    public class RegistrationViewModel
    {
        [Required]
        public CourseClass courseClass { get; set; }
        
        public Sponsorship sponsorship { get; set; }

        public String billingAddress { get; set; }


        
    }
}