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
                Bind_CoursesList();
            }
            
        }


        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;
            Bind_CoursesList();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Bind_CoursesList();
        }

        protected void BTNEDIT_Click(object sender, EventArgs e)
        {
            String courseCode = ((Button)sender).CommandArgument.ToString();
            Response.Redirect("CourseDetail.aspx?CourseCode=" + courseCode + "&MODE=EDIT");


        }
        protected void BTNDELETE_Click(object sender, EventArgs e)
        {

            String courseCode = ((Button)sender).CommandArgument.ToString();
            Course course = CourseBLL.Instance.GetCourseByCode(courseCode);
            CourseBLL.Instance.DeleteCourse(course);
            Bind_CoursesList();
        }

        

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        private void Bind_CoursesList()
        {
            IEnumerable<Course> list = CourseBLL.Instance.GetAllCourses();

            this.GridView1.DataSource = list;
            this.GridView1.DataBind();
        }

        
    }
}