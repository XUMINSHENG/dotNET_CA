using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CourseRegistrationSystem.Models
{
    public class BillingViewModel
    {
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