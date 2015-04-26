using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CourseRegistration.Models
{
    public class IndividualUser : BaseModel
    {
        [Key][Required]
        public String IdNumber { get; set; }
        [Required]
        public String Password { get; set; }
        public virtual Participant Participant { get; set; }
    }
}
