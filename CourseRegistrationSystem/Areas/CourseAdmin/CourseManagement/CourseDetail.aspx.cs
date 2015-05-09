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

                Load_Instructors();
                Load_Categories();


                Course course = CourseBLL.Instance.GetCourseByCode(courseCode);
                if (course != null)
                {
                    this.TxtCourseCode.Text = course.CourseCode;
                    this.TxtCourseTitle.Text = course.CourseTitle;
                    this.DropDownCategory.SelectedValue = course.Category.CategoryName;
                }
            }
        }

        

        private void Load_Categories()
        {
            List<Category> categoryList = CategoryBLL.Instance.GetAllCategories();
            foreach (Category c in categoryList)
            {
                this.DropDownCategory.Items.Add(c.CategoryName);
            }
        }
        private void Load_Instructors()
        {
            List<Instructor> instructorList = InstructorBLL.Instance.GetAllInstructors();
            this.ChkBoxListInstructors.Items.Clear();
            foreach (Instructor i in instructorList)
            {
                this.ChkBoxListInstructors.Items.Add(i.InstructorName);
            }
        }
    }

    
}