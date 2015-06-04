using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CourseRegistration.Models;

namespace CourseRegistrationSystem.Models
{
    public class ParticipantViewModel
    {
        [Required]
        [Display(Name = "NRIC/PASSPORT")]
        public String IdNumber { get; set; }
        public virtual Company Company { get; set; }
        public String Salutation { get; set; }
        [Display(Name = "Status")]
        public String EmploymentStatus { get; set; }
        public String CompanyName { get; set; }
        public String JobTitle { get; set; }
        public String Department { get; set; }
        [Required]
        [Display(Name = "Name")]
        public String FullName { get; set; }
        [Required]
        public Gender Gender { get; set; }
        public String Nationality { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public String Email { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "PhoneNo.")]
        public String ContactNumber { get; set; }
        public String DietaryRequirement { get; set; }
        public OrganizationSize OrganizationSize { get; set; }
        [Display(Name = "Annual Salary")]
        public SalaryRange SalaryRange { get; set; }
    }
}