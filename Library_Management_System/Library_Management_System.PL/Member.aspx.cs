using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library_Management_System.EL;
using Library_Management_System.BL;
using System.Data;


namespace Library_Management_System.PL
{
    public partial class Member : System.Web.UI.Page
    {
            EntitiesLayerClass.MemberDetails ObjMemberPagePL = new EntitiesLayerClass.MemberDetails();
            
            BusinessLayerClass objMemberPageBL = new BusinessLayerClass();
            
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ObjMemberPagePL.memberId = int.Parse(Session["MemberIDSS"].ToString());
                DataSet MemberDetails = objMemberPageBL.retriveMemberDetails(ObjMemberPagePL);
                lblWelcomeMemberName.Text ="Hey "+MemberDetails.Tables[0].Rows[0][1].ToString().ToUpper();


            }
            catch (Exception)
            {
                //throw;
                //To Control the direct access to the member page -test
                Response.Redirect("Default.aspx");
               // Response.Write("Log In to Continue");
            }
           
        }

        protected void btnCurrentBooks_Click(object sender, EventArgs e)
        {
            if (Session["MemberIDSS"]!="1")
            {
                gvBookHistory.Visible = false;

                lblMemberID.Visible = false;
                lblMemberIDValue.Visible = false;
                lblMemberName.Visible = false;
                lblMemberNameValue.Visible = false;
                lblPhoneNumber.Visible = false;
                lblPhoneNumberValue.Visible = false;
                lblEmail.Visible = false;
                lblEmailValue.Visible = false;
                lblSecurityQuestion.Visible = false;
                lblSecurityQuestionValue.Visible = false;
                lblAnswer.Visible = false;
                lblAnswerValue.Visible = false;
                lblDateRegister.Visible = false;
                lblDateRegisterValue.Visible = false;
                lblIdProofNumber.Visible = false;
                lblIdProofNumberValue.Visible = false;
                lblIdProofType.Visible = false;
                lblIdProofTypeValue.Visible = false;

                grdCurrentBooks.Visible = true;
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void btnMemberDetails_Click(object sender, EventArgs e)
        {
            if (Session["MemberIDSS"]!="1")
            {
                gvBookHistory.Visible = false;
                grdCurrentBooks.Visible = false;
                
            }
            else
            {
                Response.Redirect("Default.aspx");
            }



            //EntitiesLayerClass.MemberDetails ObjMemberPagePL = new EntitiesLayerClass.MemberDetails();
            //ObjMemberPagePL.memberId = int.Parse(Session["MemberIDSS"].ToString());
            //BusinessLayerClass objMemberPageBL = new BusinessLayerClass();
            DataSet MemberDetails = objMemberPageBL.retriveMemberDetails(ObjMemberPagePL);
            lblMemberIDValue.Text = MemberDetails.Tables[0].Rows[0][0].ToString();
            lblMemberNameValue.Text = MemberDetails.Tables[0].Rows[0][1].ToString();
            lblPhoneNumberValue.Text = MemberDetails.Tables[0].Rows[0][2].ToString();
            lblEmailValue.Text = MemberDetails.Tables[0].Rows[0][3].ToString();
            lblSecurityQuestionValue.Text = MemberDetails.Tables[0].Rows[0][4].ToString();
            lblAnswerValue.Text = MemberDetails.Tables[0].Rows[0][5].ToString();
            lblIdProofTypeValue.Text = MemberDetails.Tables[0].Rows[0][6].ToString();
            lblIdProofNumberValue.Text = MemberDetails.Tables[0].Rows[0][7].ToString();
            DateTime tempdate=(DateTime)MemberDetails.Tables[0].Rows[0][8];
            lblDateRegisterValue.Text = tempdate.ToShortDateString();

            lblMemberID.Visible = true;
            lblMemberIDValue.Visible = true;
            lblMemberName.Visible = true;
            lblMemberNameValue.Visible = true;
            lblPhoneNumber.Visible = true;
            lblPhoneNumberValue.Visible = true;
            lblEmail.Visible = true;
            lblEmailValue.Visible = true;
            lblSecurityQuestion.Visible = true;
            lblSecurityQuestionValue.Visible = true;
            lblAnswer.Visible = true;
            lblAnswerValue.Visible = true;
            lblDateRegister.Visible = true;
            lblDateRegisterValue.Visible = true;
            lblIdProofNumber.Visible = true;
            lblIdProofNumberValue.Visible = true;
            lblIdProofType.Visible = true;
            lblIdProofTypeValue.Visible = true;
        }

        protected void btnSignOut_Click(object sender, EventArgs e)
        {
            Session["MemberIDSS"] = "1";
            Response.Redirect("Default.aspx");
        }

        protected void btnBookHistory_Click(object sender, EventArgs e)
        {
            grdCurrentBooks.Visible = false;

            lblMemberID.Visible = false;
            lblMemberIDValue.Visible = false;
            lblMemberName.Visible = false;
            lblMemberNameValue.Visible = false;
            lblPhoneNumber.Visible = false;
            lblPhoneNumberValue.Visible = false;
            lblEmail.Visible = false;
            lblEmailValue.Visible = false;
            lblSecurityQuestion.Visible = false;
            lblSecurityQuestionValue.Visible = false;
            lblAnswer.Visible = false;
            lblAnswerValue.Visible = false;
            lblDateRegister.Visible = false;
            lblDateRegisterValue.Visible = false;
            lblIdProofNumber.Visible = false;
            lblIdProofNumberValue.Visible = false;
            lblIdProofType.Visible = false;
            lblIdProofTypeValue.Visible = false;
            DataSet ds = new DataSet();
            //ObjMemberPagePL.memberId = int.Parse(Session["MemberIDSS"].ToString());
            ds=objMemberPageBL.retriveBookHistoryDetails(ObjMemberPagePL);
            gvBookHistory.DataSource = ds;
            gvBookHistory.DataBind();
            gvBookHistory.Visible = true;

        }
    }
}