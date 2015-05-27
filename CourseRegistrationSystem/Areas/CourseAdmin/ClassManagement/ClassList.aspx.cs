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
                Bind_CategoryList();
                Bind_ClassList();
            }
        }
        protected void DropDownCategory_SelectedIndexChanged(object sender, EventArgs e)
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

        protected void DropDownClass_SelectedIndexChanged(object sender, EventArgs e)
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
            String categoryID = this.DropDownCategory.SelectedValue;
            if (categoryID == Util.C_String_All_Select)
            {
                // Select ALL
                list = CourseClassBLL.Instance.GetAllCourseClass();
            }
            list = CourseClassBLL.Instance.GetAllCourseClass();
            this.GridView1.DataSource = list;
            this.GridView1.DataBind();
        }
        private void Bind_CategoryList()
        {
            List<Category> list;
            list = CategoryBLL.Instance.GetAllCategories();

            this.DropDownCategory.DataSource = list;
            this.DropDownCategory.DataValueField = "CategoryId";
            this.DropDownCategory.DataTextField = "CategoryName";
            this.DropDownCategory.DataBind();

            ListItem AllItem = new ListItem("Select All", Util.C_String_All_Select);
            this.DropDownCategory.Items.Insert(0, AllItem);
        }

    }
}