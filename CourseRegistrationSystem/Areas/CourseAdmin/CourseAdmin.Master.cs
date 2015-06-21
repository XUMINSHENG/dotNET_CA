﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace CourseRegistrationSystem.Areas.CourseAdmin
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String username = HttpContext.Current.User.Identity.Name; 

            if (DateTime.Now.Hour < 12)
            {
                SayHello.Text = "Good Morning " + username;
            }
            else if (DateTime.Now.Hour < 17)
            {
                SayHello.Text = "Good Afternoon " + username;
            }
            else
            {
                SayHello.Text = "Good Afternoon " + username;
            }
        }

        protected void LogOff_Click(object sender, EventArgs e)
        {

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("/Home/Index");
        }
    }
}