using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CourseRegistrationSystem.Areas.SystemAdmin
{
    public partial class SystemAdmin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (DateTime.Now.Hour < 12)
            {
                SayHello.Text = "Good Morning, Mr X";
            }
            else if (DateTime.Now.Hour < 17)
            {
                SayHello.Text = "Good Afternoon, Mr X";
            }
            else
            {
                SayHello.Text = "Good Afternoon, Mr X";
            }
        }
        protected void LogOff_Click(object sender, EventArgs e)
        {

        }
    }
}