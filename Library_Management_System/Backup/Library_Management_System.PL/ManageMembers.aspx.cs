using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library_Management_System.EL;
using Library_Management_System.BL;
using System.Data;
using System.Data.SqlClient;

namespace Library_Management_System.PL
{
    public partial class ManageMembers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                EntitiesLayerClass.AdminDetails objAdminPagePL = new EntitiesLayerClass.AdminDetails();
                objAdminPagePL.adminId = int.Parse(Session["adminIDSS"].ToString());


            }
            catch (Exception)
            {
                //throw;
                //To Control the direct access to the member page -test
                Response.Redirect("Default.aspx");
                // Response.Write("Log In to Continue");
            }
        }

        

        protected void btnManageMemberSubmit_Click(object sender, EventArgs e)
        {
            if (btnManageMemberSubmit.Text=="Add")
            {
                if (txtMemberName.Text != "" && txtAnswer.Text != "" && txtIdProofValue.Text != "" && txtPhoneNumber.Text != "" && txtMemberEmail.Text!="")
                {
                    try
                    {
                        EntitiesLayerClass.MemberDetails objMemberManagementPL = new EntitiesLayerClass.MemberDetails();
                        BusinessLayerClass objMemberManagementBL = new BusinessLayerClass();
                        objMemberManagementPL.memberName = txtMemberName.Text;
                        objMemberManagementPL.phoneNumber = Int64.Parse(txtPhoneNumber.Text);
                        objMemberManagementPL.memberEmail = txtMemberEmail.Text;
                        objMemberManagementPL.password = txtPassword.Text;
                        objMemberManagementPL.memberEmail = txtMemberEmail.Text;
                        objMemberManagementPL.idProofType = ddlIdProofType.SelectedValue;
                        objMemberManagementPL.idProofNumber = txtIdProofValue.Text;
                        objMemberManagementPL.securityQuestion = ddlSecurityQuestion.SelectedValue;
                        objMemberManagementPL.answer = txtAnswer.Text;
                        objMemberManagementBL.addMemberDetails(objMemberManagementPL);
                        lblErrorMessage.Text = "Member Added Successfully :)";
                        txtMemberId.Text = "";
                        txtMemberName.Text = "";
                        txtPhoneNumber.Text = "";
                        txtPassword.Text = "";
                        txtRepeatPassword.Text = "";
                        txtMemberEmail.Text = "";
                        txtAnswer.Text = "";
                        ddlIdProofType.SelectedIndex = 0;
                        ddlSecurityQuestion.SelectedIndex = 0;
                        txtIdProofValue.Text = "";
                    }
                    catch (Exception)
                    {

                        lblErrorMessage.Text = "Check Phone Number Feild";
                    }
                    
                }
                else
                {
                    lblErrorMessage.Text = "You missed entering data in some of the feilds. Please Check!";
                }
                
            }
            else if (btnManageMemberSubmit.Text=="Edit")
            {
                if (txtMemberId.Text!="")
                {
                    try
                    {
                        EntitiesLayerClass.MemberDetails objMemberManagementPL = new EntitiesLayerClass.MemberDetails();
                        BusinessLayerClass objMemberManagementBL = new BusinessLayerClass();
                        objMemberManagementPL.memberId = int.Parse(txtMemberId.Text);
                        DataSet ds = objMemberManagementBL.MemberDetailsToEdit(objMemberManagementPL);
                        txtMemberName.Text = ds.Tables[0].Rows[0][1].ToString();
                        txtPhoneNumber.Text = ds.Tables[0].Rows[0][2].ToString();
                        txtMemberEmail.Text = ds.Tables[0].Rows[0][4].ToString();
                        ddlSecurityQuestion.SelectedValue = ds.Tables[0].Rows[0][5].ToString();
                        txtAnswer.Text = ds.Tables[0].Rows[0][6].ToString();
                        ddlIdProofType.SelectedValue = ds.Tables[0].Rows[0][7].ToString();
                        txtIdProofValue.Text = ds.Tables[0].Rows[0][8].ToString();


                        lblMemberName.Visible = true;
                        lblPhoneNumber.Visible = true;
                        lblMemberEmail.Visible = true;
                        lblPassword.Visible = false;
                        lblRepeatPassword.Visible = false;
                        lblSecurityQuestion.Visible = true;
                        lblAnswer.Visible = true;
                        lblIdProofType.Visible = true;
                        lblIdProofValue.Visible = true;
                        txtMemberName.Visible = true;
                        txtMemberEmail.Visible = true;
                        txtPhoneNumber.Visible = true;
                        txtPassword.Visible = false;
                        txtRepeatPassword.Visible = false;
                        ddlSecurityQuestion.Visible = true;
                        ddlIdProofType.Visible = true;
                        txtAnswer.Visible = true;
                        txtIdProofValue.Visible = true;
                        txtMemberId.Enabled = false;
                        txtAnswer.Enabled = true;
                        txtIdProofValue.Enabled = true;
                        btnManageMemberSubmit.Text = "Update";
                        lblErrorMessage.Text = "";
                    }
                    catch (Exception)
                    {
                        lblErrorMessage.Text = "Enter a valid Member ID";
                        lblErrorMessage.Visible = true;
                    }
                }
                else
                {
                    lblErrorMessage.Text = "Enter a Member ID";
                }
            }
            else if (btnManageMemberSubmit.Text=="Update")
            {
                if (txtMemberName.Text != "" && txtAnswer.Text != "" && txtIdProofValue.Text != "" && txtPhoneNumber.Text != "")
                {
                    try
                    {
                        EntitiesLayerClass.MemberDetails objMemberManagementPL = new EntitiesLayerClass.MemberDetails();
                        BusinessLayerClass objMemberManagementBL = new BusinessLayerClass();
                        objMemberManagementPL.memberId = int.Parse(txtMemberId.Text);
                        objMemberManagementPL.memberName = txtMemberName.Text;
                        objMemberManagementPL.phoneNumber = Int64.Parse(txtPhoneNumber.Text);
                        objMemberManagementPL.memberEmail = txtMemberEmail.Text;
                        objMemberManagementPL.idProofType = ddlIdProofType.SelectedValue;
                        objMemberManagementPL.idProofNumber = txtIdProofValue.Text;
                        objMemberManagementPL.securityQuestion = ddlSecurityQuestion.SelectedValue;
                        objMemberManagementPL.answer = txtAnswer.Text;
                        objMemberManagementBL.updateMemberDetails(objMemberManagementPL);
                        lblErrorMessage.Text = "Update Successfull";
                        txtMemberId.Text = "";
                        txtMemberName.Text = "";
                        txtPhoneNumber.Text = "";
                        txtMemberEmail.Text = "";
                        txtAnswer.Text = "";
                        txtIdProofValue.Text = "";
                        ddlIdProofType.SelectedIndex = 0;
                        ddlSecurityQuestion.SelectedIndex = 0;
                        btnEditMemberDetails_Click(sender, e);
                    }
                    catch (Exception)
                    {

                        lblErrorMessage.Text = "Check Phone Number Feild";
                    }
                    
                }
                else
                {
                    lblErrorMessage.Text = "You missed entering data in some of the feilds. Please Check!";
                }
            }
        }

        protected void btnAddMemberDetails_Click(object sender, EventArgs e)
        {
            revEmailId.Enabled = true;
            txtMemberName.Text = "";
            txtPhoneNumber.Text = "";
            txtMemberEmail.Text = "";
            txtAnswer.Text = "";
            txtIdProofValue.Text = "";
            ddlIdProofType.SelectedIndex = 0;
            ddlSecurityQuestion.SelectedIndex = 0;
            lblErrorMessage.Text = "";

            lblMemberId.Visible = false;
            txtMemberId.Visible = false;
            lblMemberName.Visible = true;
            lblPhoneNumber.Visible = true;
            lblMemberEmail.Visible = true;
            lblPassword.Visible = true;
            lblRepeatPassword.Visible = true;
            lblSecurityQuestion.Visible = true;
            lblAnswer.Visible = true;
            lblIdProofType.Visible = true;
            lblIdProofValue.Visible = true;
            txtMemberName.Visible = true;
            txtMemberEmail.Visible = true;
            txtPhoneNumber.Visible = true;
            txtPassword.Visible = true;
            txtRepeatPassword.Visible = true;
            ddlSecurityQuestion.Visible = true;
            ddlIdProofType.Visible = true;
            txtAnswer.Visible = true;
            txtIdProofValue.Visible = true;
            btnManageMemberSubmit.Text = "Add";
            btnManageMemberSubmit.Visible = true;
            txtAnswer.Enabled = false;
            txtIdProofValue.Enabled = false;
            
        }

        protected void btnEditMemberDetails_Click(object sender, EventArgs e)
        {
            revEmailId.Enabled = false;
            lblErrorMessage.Text = "";
            txtMemberId.Text = "";
            txtMemberId.Enabled = true;
            lblMemberId.Visible = true;
            txtMemberId.Visible = true;
            lblMemberName.Visible = false;
            lblPhoneNumber.Visible = false;
            lblMemberEmail.Visible = false;
            lblPassword.Visible = false;
            lblRepeatPassword.Visible = false;
            lblSecurityQuestion.Visible = false;
            lblAnswer.Visible = false;
            lblIdProofType.Visible = false;
            lblIdProofValue.Visible = false;
            txtMemberName.Visible = false;
            txtMemberEmail.Visible = false;
            txtPhoneNumber.Visible = false;
            txtPassword.Visible = false;
            txtRepeatPassword.Visible = false;
            ddlSecurityQuestion.Visible = false;
            ddlIdProofType.Visible = false;
            txtAnswer.Visible = false;
            txtIdProofValue.Visible = false;
            btnManageMemberSubmit.Text = "Edit";
            btnManageMemberSubmit.Visible = true;
        }

        
        protected void ddlSecurityQuestion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSecurityQuestion.SelectedIndex!=0)
            {
                txtAnswer.Text = "";
                txtAnswer.Enabled = true;    
            }
            else
            {
                txtAnswer.Text = "";
                txtAnswer.Enabled = false;
            }
        }

        protected void ddlIdProofType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlIdProofType.SelectedIndex!=0)
            {
                txtIdProofValue.Text = "";
                txtIdProofValue.Enabled = true;
            }
            else
            {
                txtIdProofValue.Text = "";
                txtIdProofValue.Enabled = false;
            }
        }

        

        
    }
}