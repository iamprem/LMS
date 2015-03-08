using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library_Management_System.EL;
using Library_Management_System.BL;
using System.Web.Security;



namespace Library_Management_System.PL
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblErrorMessage.Text = "";
            

        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(txtMemberId.Text)==100000)
                {
                    lblErrorMessage.Text = "";
                    EntitiesLayerClass.AdminDetails objLoginPagePL = new EntitiesLayerClass.AdminDetails();
                    objLoginPagePL.adminId = int.Parse(txtMemberId.Text);
                    BusinessLayerClass objLoginPageBL = new BusinessLayerClass();
                    string retrivedPwd = objLoginPageBL.loginAdmin(objLoginPagePL);

                    if (retrivedPwd==txtPassword.Text)
                    {
                        string adminidSS = txtMemberId.Text;
                        Session["AdminIDSS"] = adminidSS;
                        Response.Redirect("AdminPage.aspx");
                    }
                    else
                    {
                        lblErrorMessage.Text = "Check your Admin ID and Password";
                    }
                }
                else
                {
                    lblErrorMessage.Text = "";
                    EntitiesLayerClass.MemberDetails ObjLoginPagePL = new EntitiesLayerClass.MemberDetails();
                    ObjLoginPagePL.memberId = int.Parse(txtMemberId.Text);
                    BusinessLayerClass objLoginPageBL = new BusinessLayerClass();
                    string retrivedPwd = objLoginPageBL.loginMember(ObjLoginPagePL);


                    if (retrivedPwd == "")
                    {
                        lblErrorMessage.Text = "Check your Member ID and Password";
                    }
                    else if (retrivedPwd == txtPassword.Text)
                    {
                        string memberidSS = txtMemberId.Text;
                        Session["MemberIDSS"] = memberidSS;
                        Response.Redirect("Member.aspx");
                    }
                    else
                    {
                        lblErrorMessage.Text = "Check your Member ID and Password";
                    }
                }
                
                

            }
            catch (Exception)
            {
                throw;
            }
            
        }
    }
}