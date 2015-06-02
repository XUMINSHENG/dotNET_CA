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
    public partial class ClassDetail : System.Web.UI.Page
    {
        String PageMode;
        protected void Page_Load(object sender, EventArgs e)
        {
            PageMode = WebFormHelper.GetSessionFieldAndRemove(Session, WebFormHelper.C_PageMode, WebFormHelper.C_New_Mode);
            if (!Page.IsPostBack)
            {
                Bind("NICF040201");

                String ClassId = WebFormHelper.GetSessionFieldAndRemove(Session, WebFormHelper.C_PrimaryKey, "");
                tb_ClassID.Text = ClassId;
                tb_endDate.Text = PageMode;
                
            }
        }

        private void Bind(String ClassId)
        {
            CourseClass CourseClass = CourseClassBLL.Instance.GetCourseClassById(ClassId);
            if (ClassId != null)
            {
                tb_ClassID.Text = CourseClass.ClassId;
                tb_startDate.Text = CourseClass.StartDate.ToString();
                tb_endDate.Text = CourseClass.EndDate.ToString();
                List<Course> courseList = CourseBLL.Instance.GetAllCourses();
                ddt_Course.DataSource = courseList;
                ddt_Course.DataValueField = "CourseCode";
                ddt_Course.DataTextField = "CourseTitle";
                ddt_Course.DataBind();
                ddt_Course.SelectedValue = CourseClass.Course.CourseCode.ToString();
                ddl_RegisterStatus.SelectedIndex = System.Convert.ToInt32(CourseClass.isOpenForRegister);
                ddt_ClassStatus.SelectedIndex = System.Convert.ToInt32(CourseClass.Status);
            }
        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {

        }

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            
        }
    }
}