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
        public String billingAddress { get; set; }

        public String billingPersonName { get; set; }

        public String billlingAddressCountry { get; set; }

        public String billingAddressPostalCode { get; set; } 
    }
}