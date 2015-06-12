using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.ServiceModel;

namespace ConsoleHost
{
    class UserNameValidation : UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            Console.Write("\nValidating username {0}, & pw {1}..", userName, password);
            //if (!userName.Equals("user") || !password.Equals("secret"))
            //{// throw new SecurityTokenException("Unknown user.");
            //    //throw new FaultException("Unknown user");
            //     Console.WriteLine("Done: Credentials accepted. \n");
        
            //}
            //else
            //{
            //    Console.WriteLine("Done: Credentials accepted. \n");
            //}

            if (userName == null || password == null)
            {
                throw new ArgumentNullException();
            }

            if (CourseRegistration.BLL.UserBLL.Instance.ValidateUser(userName, password) == true)
            {
                throw new FaultException("Incorrect Username or Password");
            }


           
        }

    }
}
