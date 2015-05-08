using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CourseRegistration.BLL;
using CourseRegistration.Models;


namespace CourseRegistrationSystem.Areas.CourseAdmin.ClassManagement
{
    public partial class CourseList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindCoursesList();
            }
            
        }


        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;
            BindCoursesList();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            BindCoursesList();
        }

        protected void BTNEDIT_Click(object sender, EventArgs e)
        {
            String s = ((Button)sender).CommandArgument.ToString();
        }
        protected void BTNDELETE_Click(object sender, EventArgs e)
        {
            String s = ((Button)sender).CommandArgument.ToString();
        }

        private void BindCoursesList()
        {
            IEnumerable<Course> list = CourseBLL.Instance.GetAllCourses();

            this.GridView1.DataSource = list;
            this.GridView1.DataBind();
        }
    }
}