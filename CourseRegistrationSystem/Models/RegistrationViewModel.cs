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
        public CourseClass CourseClass { get; set; }
        [Required]
        public IEnumerable<Participant> Participants { get; set; }
        [Display(Name = "Address")]
        public String BillingAddress { get; set; }
        [Display(Name = "PersonName")]
        public String BillingPersonName { get; set; }
        [Display(Name = "Country")]
        public String BillingAddressCountry { get; set; }
        [Display(Name = "PostalCode")]
        public String BillingAddressPostalCode { get; set; }
    }
}