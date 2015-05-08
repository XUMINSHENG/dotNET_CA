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

                List<Category> categoryList = CategoryBLL.Instance.GetAllCategories();
                foreach(Category c in categoryList)
                {
                    this.DropDownCategory.Items.Add(c.CategoryName);
                    
                }
             


                Course course = CourseBLL.Instance.GetCourseByCode(courseCode);
                if (course != null)
                {
                    this.TxtCourseCode.Text = course.CourseCode;
                    this.TxtCourseTitle.Text = course.CourseTitle;
                    this.DropDownCategory.SelectedValue = course.Category.CategoryName;
                }
            }
        }

    }
}