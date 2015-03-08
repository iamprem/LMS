using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library_Management_System.EL;
using Library_Management_System.BL;

namespace Library_Management_System.PL
{
    public partial class ResetPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void btnResetPwd_Click(object sender, EventArgs e)
        {
            EntitiesLayerClass.MemberDetails objResetPagePL = new EntitiesLayerClass.MemberDetails();
            if (btnResetPwd.Text == "Submit")
            {
                if (int.Parse(txtMemberId.Text) != 100000)
                {
                    try
                    {
                        BusinessLayerClass objResetPageBL = new BusinessLayerClass();
                        objResetPagePL.memberId = int.Parse(txtMemberId.Text);
                        txtSecurityQuestion.Text = objResetPageBL.getSecurityQuestion(objResetPagePL);
                        lblSecurityQuestion.Visible = true;
                        lblAnswer.Visible = true;
                        txtSecurityQuestion.Visible = true;
                        txtAnswer.Visible = true;
                        txtSecurityQuestion.Enabled = false;
                        txtAnswer.Text = "";
                        btnResetPwd.Text = "Next";
                        txtMemberId.Enabled = false;
                        lblSuccess.Text = "";
                    }
                    catch (Exception)
                    {

                        lblSuccess.Text = "No Access!";
                        lblSuccess.Visible = true;
                    }
                    
                }
                else
                {
                    lblSuccess.Text = "No Access!";
                    lblSuccess.Visible = true;
                }
                
            }
            else if (btnResetPwd.Text=="Next")
            {
                BusinessLayerClass objResetPageBL = new BusinessLayerClass();
                objResetPagePL.memberId = int.Parse(txtMemberId.Text);
                string retrivedAnswer = objResetPageBL.getAnswer(objResetPagePL);
                lblSuccess.Text = "";
                if (txtAnswer.Text==retrivedAnswer)
                {
                    txtAnswer.Enabled = false;
                    lblNewPassword.Visible = true;
                    lblConfirmPassword.Visible = true;
                    txtNewPassword.Visible = true;
                    txtConfirmPassword.Visible = true;
                    btnResetPwd.Text = "Reset Password";
                    lblAnswerMisMatch.Visible = true;
                    lblAnswerMisMatch.Text = "";
                }
                else
                {
                    lblAnswerMisMatch.Visible = true;
                    lblAnswerMisMatch.Text = "Answer Mismatch";
                    txtAnswer.Text = "";
                    txtAnswer.Focus();
                }
            }
            else if (btnResetPwd.Text=="Reset Password")
            {
                BusinessLayerClass objResetPageBL = new BusinessLayerClass();
                objResetPagePL.password = txtNewPassword.Text;
                objResetPagePL.memberId = int.Parse(txtMemberId.Text);
                objResetPageBL.putNewPassword(objResetPagePL);
                lblSuccess.Text="New Password Updated Successfully";
                lblSuccess.Visible = true;
                lblMemberId.Visible = false;
                lblSecurityQuestion.Visible = false;
                lblAnswer.Visible = false;
                txtMemberId.Visible = false;
                txtSecurityQuestion.Visible = false;
                txtAnswer.Visible = false;
                lblNewPassword.Visible = false;
                lblConfirmPassword.Visible = false;
                txtNewPassword.Visible = false;
                txtConfirmPassword.Visible = false;
                btnResetPwd.Visible = false;
                Response.AddHeader("REFRESH", "1;URL=Default.aspx");
            }
        }
    }
}