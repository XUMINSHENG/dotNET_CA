﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CourseRegistration.BLL;
using CourseRegistration.Models;
using CourseRegistrationSystem.Areas.CourseAdmin.Shared;

namespace CourseRegistrationSystem.Areas.CourseAdmin.RegistrationManagement
{
    public partial class RegistrationDetail : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                String rId = WebFormHelper.GetSessionFieldAndRemove(Session ,WebFormHelper.C_PrimaryKey, "");
                if (!string.IsNullOrEmpty(rId))
                {
                    Registration r = RegistrationBLL.Instance.getRegistrationById(Int32.Parse(rId));
                    LoadDetailData(r);
                    ControlDisplayMode(r);
                }
            }

        }

        protected void BtnEdit_Click(object sender, EventArgs e)
        {
            String rId = this.TxtRegistrationId.Text;
            try
            {
                SaveChanges(false);

            }
            catch (System.Data.Entity.Infrastructure.DbUpdateConcurrencyException ex)
            {
                this.LblMessage.Text = string.Format(WebFormHelper.Err_Update_Concurrency, "registrition", rId);
            }
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Server.Transfer("RegistrationList.aspx");
        }

        private void ControlDisplayMode(Registration r)
        {
            if (DateTime.Compare(r.CourseClass.StartDate,DateTime.Now)<0)
            {
                this.DropDownClass.Enabled = false;
                this.TxtSponsorship.Enabled = false;
                this.TxtDietaryRequirement.Enabled = false;
                this.TxtOrganizationSize.Enabled = false;
                this.TxtBillingAddress.Enabled = false;
                this.TxtBillingPersonName.Enabled = false;
                this.TxtBillingAddressCountry.Enabled = false;
                this.TxtBillingAddressPostalCode.Enabled = false;

                this.EditPanel.Visible = false;
                this.ViewPanel.Visible = true;
            }
            else
            {
                this.EditPanel.Visible = true;
                this.ViewPanel.Visible = false;
            }
        }

        private void LoadDetailData(Registration r)
        {
            
            if (r != null)
            {
                this.TxtRegistrationId.Text = r.RegistrationId.ToString();
                this.txtCategory.Text = r.CourseClass.Course.Category.CategoryName;
                this.TxtCourseCode.Text = r.CourseClass.Course.CourseCode;
                this.HidTimestamp.Value = System.Convert.ToBase64String(r.Timestamp);
                this.TxtCourseTitle.Text = r.CourseClass.Course.CourseTitle;
                Bind_Classes(r);
                this.TxtParticipant.Text = r.Participant.FullName;
                this.TxtStatus.Text = r.Status.ToString(); ;
                this.TxtSponsorship.Text = r.Sponsorship.ToString();
                this.TxtDietaryRequirement.Text = r.DietaryRequirement;
                this.TxtOrganizationSize.Text = r.OrganizationSize.ToString();
                this.TxtBillingAddress.Text = r.BillingAddress;
                this.TxtBillingPersonName.Text = r.BillingPersonName;
                this.TxtBillingAddressCountry.Text = r.BillingAddressCountry;
                this.TxtBillingAddressPostalCode.Text = r.BillingAddressPostalCode;
                this.TxtCreateDate.Text = r.CreateDate.ToString("dd-MMM-yyyy");
            }
        }

        private void Bind_Classes(Registration r)
        {
            List<CourseClass> classesList = new List<CourseClass>(); ;
            if (DateTime.Compare(r.CourseClass.StartDate, DateTime.Now) < 0)
            {
                // registration overdue, view only
                classesList.Add(r.CourseClass);
            }
            else
            {
                List<CourseClass> tmpList = CourseClassBLL.Instance.GetClassesByConds(
                    r.CourseClass.Course.Category.CategoryId.ToString(), 
                    r.CourseClass.Course.CourseCode);
                foreach (CourseClass c in tmpList)
                {
                    // only classes start later then current time can be selected
                    if (DateTime.Compare(c.StartDate, DateTime.Now) > 0)
                    {
                        // hide overdue classes
                        classesList.Add(c);
                    }
                }
            }
                    
            this.DropDownClass.DataSource = classesList;
            this.DropDownClass.DataValueField = "ClassId";
            this.DropDownClass.DataTextField = "StartDate";
            this.DropDownClass.DataBind();

            this.DropDownClass.SelectedValue = r.CourseClass.ClassId.ToString();
        }

        private void SaveChanges(bool isNew)
        {
            String rId = this.TxtRegistrationId.Text;
            if (!string.IsNullOrEmpty(rId))
            {
                Registration r = RegistrationBLL.Instance.getRegistrationById(Int32.Parse(rId));

                CourseClass newC = CourseClassBLL.Instance.GetCourseClassById(this.DropDownClass.SelectedValue);
                r.CourseClass = newC;

                //r.Sponsorship = this.TxtSponsorship.Text;
                r.DietaryRequirement = this.TxtDietaryRequirement.Text;
                //r.OrganizationSize = this.TxtOrganizationSize.Text;
                r.BillingAddress = this.TxtBillingAddress.Text;
                r.BillingPersonName = this.TxtBillingPersonName.Text;
                r.BillingAddressCountry = this.TxtBillingAddressCountry.Text;
                r.BillingAddressPostalCode = this.TxtBillingAddressPostalCode.Text;

                RegistrationBLL.Instance.UpdateRegistration(r);

                LoadDetailData(r);
                ControlDisplayMode(r);
            }

        }


    }
}