using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CourseRegistration.Models
{
    public class Staff
    {
        [Key][Required]
        public String StaffId { get; set; }
        [Required]
        public String Password { get; set; }
        public Role Role { get; set; }
    }
}
