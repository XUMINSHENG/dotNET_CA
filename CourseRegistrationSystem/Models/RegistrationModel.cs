using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CourseRegistration.Models;
using System.ComponentModel.DataAnnotations;

namespace CourseRegistrationSystem.Models
{
    public class RegistrationModel
    {
        [Required]
        public CourseClass courseClass { get; set; }
        
        public Sponsorship sponsorship;
        
    }
}