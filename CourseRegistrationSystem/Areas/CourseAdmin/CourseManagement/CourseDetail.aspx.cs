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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                String courseCode = Request.QueryString["CourseCode"];
                String PageMode = Request.QueryString["MODE"];
                Bind_Categories();
                Bind_Instructors();
                


                Course course = CourseBLL.Instance.GetCourseByCode(courseCode);
                if (course != null)
                {
                    Load_DetailData(course);
                }
            }
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

        protected void BtnEdit_Click(object sender, EventArgs e)
        {
            Course course = CourseBLL.Instance.GetCourseByCode(this.TxtCourseCode.Text);
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
            
            CourseBLL.Instance.EditCourse(course);
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {

        }

        private void Load_DetailData(Course course)
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
    }

    
}