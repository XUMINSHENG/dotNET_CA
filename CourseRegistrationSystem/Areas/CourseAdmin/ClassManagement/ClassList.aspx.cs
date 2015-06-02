﻿using System;
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
            Session.Add(WebFormHelper.C_PageMode, WebFormHelper.C_New_Mode);
            Response.Redirect("~/Areas/CourseAdmin/ClassManagement/ClassDetail.aspx");
        }

        protected void BTNEDIT_Click(object sender, EventArgs e)
        {
            String ClassId = ((Button)sender).CommandArgument.ToString();
            Session.Add(WebFormHelper.C_PrimaryKey, ClassId);
            Session.Add(WebFormHelper.C_PageMode, WebFormHelper.C_Edit_Mode);
            Response.Redirect("~/Areas/CourseAdmin/ClassManagement/ClassDetail.aspx");
        }
        protected void BTNViewDetail_Click(object sender, EventArgs e)
        {
            String ClassId = ((LinkButton)sender).CommandArgument.ToString();
            Session.Add(WebFormHelper.C_PrimaryKey, ClassId);
            Session.Add(WebFormHelper.C_PageMode, WebFormHelper.C_View_Mode);
            Response.Redirect("~/Areas/CourseAdmin/ClassManagement/ClassDetail.aspx");
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
      
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Object obj = DataBinder.Eval(e.Row.DataItem, "ClassId");
                if (obj != null)
                {
                    String classId = obj.ToString();
                    ((LinkButton)e.Row.FindControl("RegNum")).Text = CourseClassBLL.Instance.getRegNum(classId).ToString();
                }
            }
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

        protected void RegNum_Click(object sender, EventArgs e)
        {

        }
        protected void BTNDELETE_Click(object sender, EventArgs e)
        {
            String ClassId = ((Button)sender).CommandArgument.ToString();
            CourseClass CourseClass = CourseClassBLL.Instance.GetCourseClassById(ClassId);
            CourseClassBLL.Instance.DeleteCourseClass(CourseClass);
            Bind_ClassList();
        }
    }
}