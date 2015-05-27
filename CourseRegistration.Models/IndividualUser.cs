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

        public String BillingAddress { get; set; }
        public String BillingPersonName { get; set; }
        public String BillingAddressCountry { get; set; }
        public String BillingAddressPostalCode { get; set; }
    }

}
