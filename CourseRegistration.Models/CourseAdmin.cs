﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CourseRegistration.Models
{
    public class CourseAdmin
    {
        public bool enabled { get; set; }
        public Staff Staff { get; set; }
    }
}
