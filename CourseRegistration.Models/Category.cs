using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CourseRegistration.Models
{
    class Category
    {
        [Key][Required]
        public String CategoryId { get; set; }

        [Required]
        public String CategoryName { get; set; }

        public String CategoryDescription { get; set; }
    }
}
