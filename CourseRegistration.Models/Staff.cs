using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CourseRegistration.Models
{
    public class Staff : User
    {
        [Key][Required]
        public String idNumber { get; set; }
    }
}
