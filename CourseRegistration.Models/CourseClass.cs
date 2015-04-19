using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CourseRegistration.Models
{
    public class CourseClass
    {
        [Key][Required]
        public String ClassId { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public String Status { get; set; }

        public Course Course { get; set; }

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
