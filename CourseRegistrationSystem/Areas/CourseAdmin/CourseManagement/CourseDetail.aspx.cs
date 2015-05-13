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
    public partial class CourseDetail : System.Web.UI.Page
    {
        String PageMode;
        protected void Page_Load(object sender, EventArgs e)
        {

            PageMode = Request.QueryString["MODE"];
            if (PageMode==null) PageMode = "NEW";

            if (!Page.IsPostBack)
            {
                Bind_Categories();
                Bind_Instructors();

                String courseCode = Request.QueryString["CourseCode"];
                if (PageMode == "NEW")
                {
                }else if(PageMode == "EDIT" || PageMode == "VIEW"){
                    Course course = CourseBLL.Instance.GetCourseByCode(courseCode);
                    if (course != null)
                    {
                        LoadDetailData(course);
                    }
                }
            }
            ControlDisplayMode();
        }

        private void Bind_Categories()
        {
            List<Category> categoryList = CategoryBLL.Instance.GetAllCategories();
            this.DropDownCategory.DataSource = categoryList;
            this.DropDownCategory.DataValueField = "CategoryId";
            this.DropDownCategory.DataTextField = "CategoryName";
            this.DropDownCategory.DataBind();
        }
        private void Bind_Instructors()
        {
            List<Instructor> instructorList = InstructorBLL.Instance.GetAllInstructors();
            this.ChkBoxListInstructors.DataSource = instructorList;
            this.ChkBoxListInstructors.DataValueField = "InstructorId";
            this.ChkBoxListInstructors.DataTextField = "InstructorName";
            this.ChkBoxListInstructors.DataBind();
        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            SaveCourse(true);
            Response.Redirect("CourseDetail.aspx?CourseCode=" + this.TxtCourseCode.Text + "&MODE=VIEW");
        }

        protected void BtnEdit_Click(object sender, EventArgs e)
        {
            SaveCourse(false);
            Response.Redirect("CourseDetail.aspx?CourseCode=" + this.TxtCourseCode.Text + "&MODE=VIEW");
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("CourseList.aspx");
        }

        private void LoadDetailData(Course course)
        {
            this.TxtCourseCode.Text = course.CourseCode;
            this.TxtCourseTitle.Text = course.CourseTitle;
            this.DropDownCategory.SelectedValue = course.Category.CategoryId.ToString();
            this.TxtDescription.Text = course.CourseDescription;
            this.TxtFee.Text = course.Fee.ToString();
            this.TxtNumberOfDays.Text = course.NumberOfDays.ToString();

            foreach (Instructor i in course.Instructors)
            {
                this.ChkBoxListInstructors.Items.FindByValue(i.InstructorId.ToString()).Selected = true;
            }

            this.ChkBoxEnabled.Checked = course.enabled;
            this.TxtCreateDate.Text = course.CreateDate.ToShortDateString();
        }

        private void SaveCourse(bool isNew)
        {
            Course course;
            if (isNew)
            {
                course = new Course();
                course.CourseCode = this.TxtCourseCode.Text;
            }
            else
            {
                course = CourseBLL.Instance.GetCourseByCode(this.TxtCourseCode.Text);
            }
            
            course.CourseTitle = this.TxtCourseTitle.Text;

            Category category = CategoryBLL.Instance.GetCategoryById(int.Parse(this.DropDownCategory.SelectedValue));
            course.Category = category;

            course.CourseDescription = this.TxtDescription.Text;
            course.Fee = double.Parse(this.TxtFee.Text);
            course.NumberOfDays = int.Parse(this.TxtNumberOfDays.Text);

            foreach (ListItem i in this.ChkBoxListInstructors.Items)
            {
                if (i.Selected)
                {
                    Instructor instructor = InstructorBLL.Instance.GetInstructorById(int.Parse(i.Value));
                    course.Instructors.Add(instructor);
                }
            }

            course.enabled = this.ChkBoxEnabled.Checked;


            if (isNew)
            {
                CourseBLL.Instance.CreateCourse(course);
            }
            else
            {
                CourseBLL.Instance.EditCourse(course);
            }
            
        }

        private void ControlDisplayMode()
        {
            if (PageMode == "NEW")
            {
                this.EditPanel.Visible = false;
                this.ViewPanel.Visible = false;
            }
            else if (PageMode == "EDIT")
            {
                this.TxtCourseCode.Enabled = false;

                this.NewPanel.Visible = false;
                this.ViewPanel.Visible = false;
            }
            else if(PageMode == "VIEW")
            {
                this.TxtCourseCode.Enabled = false;
                this.TxtCourseTitle.Enabled = false;
                this.DropDownCategory.Enabled = false;
                this.TxtDescription.Enabled = false;
                this.TxtFee.Enabled = false;
                this.TxtNumberOfDays.Enabled = false;
                this.ChkBoxListInstructors.Enabled = false;
                this.ChkBoxEnabled.Enabled = false;
                this.TxtCreateDate.Enabled = false;

                this.NewPanel.Visible = false;
                this.EditPanel.Visible = false;
            }
        }
    }

    
}