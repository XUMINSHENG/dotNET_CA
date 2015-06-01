using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseRegistration.Models
{
    public enum RegistrationStatus { Pending = 0, Successful = 1, Cancel = 2 }

    public enum ClassStatus { Pending = 0, Confirmed = 1, Cancel = 2 }

    public enum OrganizationSize { Less_Than_20 = 0, From_20_To_200 = 1, From_200_To_500 = 2, More_Than_500 = 3 }

    public enum SalaryRange { Less_Than_60k = 0, From_60_To_90k = 1, From_90k_To_120k = 2, More_Than_120k = 3 }

    public enum Sponsorship { Self = 0, Company = 1 }

    public enum Gender { female = 0, male = 1 }



}
