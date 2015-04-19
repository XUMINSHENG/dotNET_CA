using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CourseRegistration.Models
{
    class Instructor
    {
        [Key][Required]
        public String InstructorId { get; set; }

        [Required]
        public String InstructorName { get; set; }

    }
}
