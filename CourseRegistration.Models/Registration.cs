using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CourseRegistration.Models
{
    public class Registration
    {
        [Key][Required]
        public String RegistrationId { get; set; }
        [Required]
        public CourseClass CourseClass { get; set; }
        [Required]
        public Participant Participant { get; set; }
        public String sponsorship { get; set; }
        public String dietaryRequirement { get; set; }
        public String organizationSize { get; set; }
        public String billingAddress { get; set; }
        public String billingPersonName { get; set; }
        public String billingAddressCountry { get; set; }
        public String billingAddressPostalCode { get; set; }
        public String status { get; set; }
    }
}
