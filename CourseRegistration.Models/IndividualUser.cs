﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CourseRegistration.Models
{
    public class IndividualUser
    {
        [Key][Required]
        public String IdNumber { get; set; }
        [Required]
        public String Password { get; set; }
        public Participant Participant { get; set; }
    }
}
