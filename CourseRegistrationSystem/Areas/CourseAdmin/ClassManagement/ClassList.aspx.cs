using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CourseRegistration.BLL;
using CourseRegistration.Models;
using CourseRegistrationSystem.Areas.CourseAdmin.Shared;

namespace CourseRegistrationSystem.Areas.CourseAdmin.ClassManagement
{
    public partial class ClassList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Bind_CourseList();
                Bind_ClassList();
            }
        }
        protected void DropDownCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bind_ClassList();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;
            Bind_ClassList();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Bind_ClassList();
        }

        protected void BTNCREATE_Click(object sender, EventArgs e)
        {
            
        }

        protected void BTNVIEW_Click(object sender, EventArgs e)
        {

        }

        protected void BTNEDIT_Click(object sender, EventArgs e)
        {
            
        }
        protected void BTNViewDetail_Click(object sender, EventArgs e)
        {

        }


        private void Bind_ClassList()
        {
            List<CourseClass> list;
            list = CourseClassBLL.Instance.GetAllCourseClass();
            this.GridView1.DataSource = list;
            this.GridView1.DataBind();
        }
        private void Bind_CourseList()
        {
            List<Course> list;
            list = CourseBLL.Instance.GetAllCourses();

            this.DropDownCourse.DataSource = list;
            this.DropDownCourse.DataValueField = "CourseCode";
            this.DropDownCourse.DataTextField = "CourseTitle";
            this.DropDownCourse.DataBind();

            ListItem AllItem = new ListItem("Select All", Util.C_String_All_Select);
            this.DropDownCourse.Items.Insert(0, AllItem);
        }

    }
}