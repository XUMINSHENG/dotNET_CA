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
        CourseClass CourseClass;
        protected void Page_Load(object sender, EventArgs e)
        {
            PageMode = WebFormHelper.GetSessionFieldAndRemove(Session, WebFormHelper.C_PageMode, WebFormHelper.C_New_Mode);
            if (!Page.IsPostBack)
            {
                Bind_CourseList();
                ControlDisplayMode();
                if (PageMode == WebFormHelper.C_New_Mode)
                {
                    tb_ClassID.Enabled = true;
                }
                else
                {
                    String ClassId = WebFormHelper.GetSessionFieldAndRemove(Session, WebFormHelper.C_PrimaryKey, "");
                    Bind(ClassId);
                }
            }
        }

        private void Bind(String ClassId)
        {
            CourseClass = CourseClassBLL.Instance.GetCourseClassById(ClassId);
            if (ClassId != null)
            {
                tb_ClassID.Text = CourseClass.ClassId;
                Start_Date.TodaysDate = CourseClass.StartDate;
                End_Date.TodaysDate = CourseClass.EndDate;
                ddt_Course.SelectedValue = CourseClass.Course.CourseCode.ToString();
                ddl_RegisterStatus.SelectedIndex = System.Convert.ToInt32(CourseClass.isOpenForRegister);
                ddt_ClassStatus.SelectedIndex = System.Convert.ToInt32(CourseClass.Status);
            }
        }
        protected void Bind_CourseList()
        {
            List<Course> courseList = CourseBLL.Instance.GetAllCourses();
            ddt_Course.DataSource = courseList;
            ddt_Course.DataValueField = "CourseCode";
            ddt_Course.DataTextField = "CourseTitle";
            ddt_Course.DataBind();
        }
        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            
        }

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            
        }

        private void ControlDisplayMode()
        {
            if (PageMode == WebFormHelper.C_New_Mode)
            {
                tb_ClassID.Enabled = true;
                ddl_RegisterStatus.Enabled = true;
                ddt_ClassStatus.Enabled = true;
                ddt_Course.Enabled = true;
            }
            else if (PageMode == WebFormHelper.C_Edit_Mode)
            {
                tb_ClassID.Enabled = true;
                ddl_RegisterStatus.Enabled = true;
                ddt_ClassStatus.Enabled = true;
                ddt_Course.Enabled = true;
            }
            else if (PageMode == WebFormHelper.C_View_Mode)
            {
                tb_ClassID.Enabled = false;
                ddl_RegisterStatus.Enabled = false;
                ddt_ClassStatus.Enabled = false;
                ddt_Course.Enabled = false;
            }
        }

        protected void Start_Date_SelectionChanged(object sender, EventArgs e)
        {
            Start_Date.TodaysDate = Start_Date.SelectedDate;
            DateTime start = Start_Date.SelectedDate;
            String ClassId = tb_ClassID.Text;
            CourseClass courseClass = CourseClassBLL.Instance.GetCourseClassById(ClassId);
            int NumOfDays = courseClass.Course.NumberOfDays;
            End_Date.SelectedDate = start.AddDays(NumOfDays - 1);
            End_Date.TodaysDate = start.AddDays(NumOfDays - 1);
        }

        protected void End_Date_SelectionChanged(object sender, EventArgs e)
        {
            End_Date.TodaysDate = End_Date.SelectedDate;
        }
    }
}