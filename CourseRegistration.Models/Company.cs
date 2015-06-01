using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CourseRegistration.Models
{
    public class Company : BaseModel
    {
        [Key]
        [Required]
        public int CompanyId { get; set; }
        [Required]
        public String CompanyName{ get;set; }
        public String CompanyUEN{ get;set; }
        public OrganizationSize OrganizationSize { get; set; }
        public String CompanyAddress{ get;set; }
        public String Country{ get;set; }
        public String PostalCode { get; set; }

        private List<Participant> employees;
        public virtual List<Participant> Employees
        {
            get {
                return employees;
            }
            set
            {
                employees = value;
            }
        }

        public String BillingAddress { get; set; }
        public String BillingPersonName { get; set; }
        public String BillingAddressCountry { get; set; }
        public String BillingAddressPostalCode { get; set; }

    }
}
