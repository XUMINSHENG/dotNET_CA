using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CourseRegistration.Models
{
    public class CourseClass : BaseModel
    {
        [Key][Required]
        public String ClassId { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public bool isOpenForRegister { get; set; }

        public virtual ClassStatus Status { get; set; }

        public virtual Course Course { get; set; }

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

public enum ClassStatus { Pending = 0, Confirmed = 1, Cancel = 2 }
