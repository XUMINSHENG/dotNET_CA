using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions; 

using System.Text;
using System.Threading.Tasks;


namespace CourseRegistration.BLL
{
    public class Util
    {
        public const string C_Role_SystemAdmin = "SystemAdmin";
        public const string C_Role_CourseAdmin = "CourseAdmin";
        public const string C_Role_CompanyHR = "CompanyHR";
        public const string C_Role_IndividualUser = "IndividualUser";

        public const string C_String_All_Select = "";



        public static String GeneratePassword()
        {
            String pwd = "";
            String alphaStr = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            String numStr = "1234567890";
            char[] alphaNumList = (alphaStr.ToUpper() + alphaStr.ToLower() + numStr).ToCharArray();
            Random rnd = new Random();
            for (int i = 0; i < 9; i++)
            {
                int indexVal = rnd.Next(0, alphaNumList.Length);
                pwd = pwd + alphaNumList[indexVal];
            }
            return pwd;
        }



    }
}
