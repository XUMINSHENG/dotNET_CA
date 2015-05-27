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
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //e.Row.Cells[2].Text = "1";
            //((LinkButton) e.Row.FindControl("RegNum")).Text = "123";
                //CourseClassBLL.Instance.getRegNum(3).ToString();
        }

        private void Bind_ClassList()
        {
            List<CourseClass> list;
            String CourseId = this.DropDownCourse.SelectedValue;
            if (CourseId == Util.C_String_All_Select)
            {
                // Select ALL
                list = CourseClassBLL.Instance.GetAllCourseClass();
            }

            else
            {
                list = CourseClassBLL.Instance.GetClassesByConds(Util.C_String_All_Select,CourseId);
            }

            if (list.Count() == 0)
            {
                list.Add(new CourseClass());

                this.GridView1.DataSource = list;
                this.GridView1.DataBind();

                int columnCount = this.GridView1.Columns.Count;

                this.GridView1.Rows[0].Cells.Clear();
                this.GridView1.Rows[0].Cells.Add(new TableCell());
                this.GridView1.Rows[0].Cells[0].ColumnSpan = columnCount;
                this.GridView1.Rows[0].Cells[0].Text = "No Record";
                this.GridView1.Rows[0].Cells[0].Style.Add("text-align", "center");
            }
            else
            {

                this.GridView1.DataSource = list;
                this.GridView1.DataBind();

                int pNo = this.GridView1.PageIndex;
                int pSize = this.GridView1.PageSize;
                String RecNo = (pNo * pSize + 1).ToString();
                RecNo += "~";
                if ((pNo + 1) * pSize < list.Count())
                {
                    RecNo += ((pNo + 1) * pSize).ToString();
                }
                else
                {
                    RecNo += list.Count().ToString();
                }
                RecNo += " / ";
                RecNo += list.Count().ToString();
                this.LblRecNo.InnerText = RecNo;
            }
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

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}