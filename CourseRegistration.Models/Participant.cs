﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CourseRegistration.Models
{
    public class Participant : BaseModel
    {
        [Key]
        [Required]
        public int ParticipantId { get; set; }
        [Required]
        [Display(Name = "NRIC/PASSPORT")]
        public String IdNumber{ get;set; }
        public virtual Company Company { get; set; }
        public String Salutation{ get;set; }
        public String EmploymentStatus{ get;set; }
        public String CompanyName{ get;set; }
        public String JobTitle{ get;set; }
        public String Department{ get;set; }
        [Required]
        public String FullName{ get;set; }
        [Required]
        public String Gender{ get;set; }
        public String Nationality{ get;set; }
        [DataType(DataType.Date)]
        public DateTime DateOfBirth{ get;set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public String Email{ get;set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
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

        public String generatePassowrd()
        {
            String pwd="";
            String alphaStr = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            String numStr = "1234567890";
            char[] alphaNumList = (alphaStr.ToUpper() + alphaStr.ToLower() + numStr).ToCharArray();
            Random rnd = new Random();
            for(int i=0; i<9;i++)
            {
                int indexVal = rnd.Next(0, alphaNumList.Length);
                pwd = pwd + alphaNumList[indexVal];
            }
            return pwd;            
        }
    }
}
