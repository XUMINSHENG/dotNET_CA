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
                    tb_ClassID.Enabled = false;
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
            checkDataFormat();
            saveClass();
        }

        protected void checkDataFormat()
        { 
            
        }

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Areas/CourseAdmin/ClassManagement/ClassList.aspx");
        }

        private void ControlDisplayMode()
        {
            if (PageMode == WebFormHelper.C_New_Mode)
            {
                tb_ClassID.Enabled = true;
                ddl_RegisterStatus.Enabled = true;
                ddt_ClassStatus.Enabled = true;
                ddt_Course.Enabled = true;
                Start_Date.Enabled = true;
                End_Date.Enabled = true;
                btn_Submit.Text = "Create";
                btn_Cancel.Text = "Cancel";
                btn_Submit.Visible = true;
            }
            else if (PageMode == WebFormHelper.C_Edit_Mode)
            {
                tb_ClassID.Enabled = true;
                ddl_RegisterStatus.Enabled = true;
                ddt_ClassStatus.Enabled = true;
                ddt_Course.Enabled = false;
                Start_Date.Enabled = true;
                End_Date.Enabled = true;
                btn_Submit.Text = "Save";
                btn_Cancel.Text = "Cancel";
                btn_Submit.Visible = true;
            }
            else if (PageMode == WebFormHelper.C_View_Mode)
            {
                tb_ClassID.Enabled = false;
                ddl_RegisterStatus.Enabled = false;
                ddt_ClassStatus.Enabled = false;
                ddt_Course.Enabled = false;
                Start_Date.Enabled = false;
                End_Date.Enabled = false;
                btn_Submit.Visible = false;
                btn_Cancel.Text = "Back";
            }
        }

        protected void Start_Date_SelectionChanged(object sender, EventArgs e)
        {
            Start_Date.TodaysDate = Start_Date.SelectedDate;
            DateTime start = Start_Date.SelectedDate;
            if (btn_Submit.Text == "Save")
            {
                String ClassId = tb_ClassID.Text;
                CourseClass courseClass = CourseClassBLL.Instance.GetCourseClassById(ClassId);
                int NumOfDays = courseClass.Course.NumberOfDays;
                End_Date.SelectedDate = start.AddDays(NumOfDays - 1);
                End_Date.TodaysDate = start.AddDays(NumOfDays - 1);
            }
        }

        protected void End_Date_SelectionChanged(object sender, EventArgs e)
        {
            End_Date.TodaysDate = End_Date.SelectedDate;
        }
        protected bool saveClass()
        {
            if (btn_Submit.Text == "Create")
            {
                CourseClass courseClass = new CourseClass();
                courseClass.ClassId = tb_ClassID.Text;
                courseClass.StartDate = Start_Date.SelectedDate;
                courseClass.EndDate = End_Date.SelectedDate;
                courseClass.isOpenForRegister = System.Convert.ToBoolean(ddl_RegisterStatus.SelectedIndex);
                switch (ddt_ClassStatus.SelectedIndex)
                {
                    case 0: { courseClass.Status = ClassStatus.Pending; break; }
                    case 1: { courseClass.Status = ClassStatus.Confirmed; break; }
                    case 2: { courseClass.Status = ClassStatus.Cancel; break; }
                }
                courseClass.Course = CourseBLL.Instance.GetCourseByCode(ddt_Course.SelectedValue);
                CourseClassBLL.Instance.CreateCourseClass(courseClass);
                return true;
            }
            else if (btn_Submit.Text == "Save")
            { 
                
            }
            return false;
        }
    }
}