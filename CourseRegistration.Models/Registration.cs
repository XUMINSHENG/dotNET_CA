﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CourseRegistration.Models
{
    public class Registration : BaseModel
    {
        [Key][Required]
        public String RegistrationId { get; set; }
        [Required]
        public virtual CourseClass CourseClass { get; set; }
        [Required]
        public virtual Participant Participant { get; set; }
        public String Sponsorship { get; set; }
        public String DietaryRequirement { get; set; }
        public String OrganizationSize { get; set; }
        public String BillingAddress { get; set; }
        public String BillingPersonName { get; set; }
        public String BillingAddressCountry { get; set; }
        public String BillingAddressPostalCode { get; set; }
        public virtual RegistrationStatus Status { get; set; }
    }
}

public enum RegistrationStatus { Pending=0,Success=1,Cancel=2}