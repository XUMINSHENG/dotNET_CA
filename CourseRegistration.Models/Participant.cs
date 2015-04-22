using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CourseRegistration.Models
{
    public class Participant
    {
        [Key]
        [Required]
        public String ParticipantId{ get;set; }
        [Required]
        public String IdNumber{ get;set; }
        public Company Company{ get; set; }
        public String Salutation{ get;set; }
        public String EmploymentStatus{ get;set; }
        public String CompanyName{ get;set; }
        public String JobTitle{ get;set; }
        public String Department{ get;set; }
        [Required]
        public String FullName{ get;set; }
        public String Gender{ get;set; }
        public String Nationality{ get;set; }
        public DateTime DateOfBirth{ get;set; }
        public String Email{ get;set; }
        public String ContactNumber{ get;set; }
        public String DietaryRequirement{ get;set; }
        public String OrganizationSize{ get;set; }
        public String SalaryRange { get; set; }

        private List<Registration> registrations;
        public virtual List<Registration> Registrations
        {
            get { 
                return registrations; 
            }
            set
            {
                registrations = value;
            }
        }
    }
}
