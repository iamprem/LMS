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
    public partial class BookTransaction : System.Web.UI.Page
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

        protected void btnBookIssue_Click(object sender, EventArgs e)
        {
            lblBookId.Visible = true;
            lblMemberId.Visible = true;
            txtBookId.Visible = true;
            txtMemberId.Visible = true;
            btnBookTransactionSubmit.Text = "Issue Book";
            btnBookTransactionSubmit.Visible = true;
            lblErrorMessage.Visible = false;
        }

        protected void btnBookReturn_Click(object sender, EventArgs e)
        {
            lblBookId.Visible = true;
            lblMemberId.Visible = true;
            txtBookId.Visible = true;
            txtMemberId.Visible = true;
            btnBookTransactionSubmit.Text = "Return Book";
            btnBookTransactionSubmit.Visible = true;
            lblErrorMessage.Visible = false;
        }

        protected void btnBookTransactionSubmit_Click(object sender, EventArgs e)
        {
            if (btnBookTransactionSubmit.Text=="Issue Book")
            {
                if (txtBookId.Text!="" && txtMemberId.Text!="")
                {
                    try
                    {
                        EntitiesLayerClass.MemberDetails objMemBookTransactionPL = new EntitiesLayerClass.MemberDetails();
                        EntitiesLayerClass.AllBooks objBkBookTransactionPL = new EntitiesLayerClass.AllBooks();
                        BusinessLayerClass ObjBookTransactionBL = new BusinessLayerClass();
                        objMemBookTransactionPL.memberId = int.Parse(txtMemberId.Text);
                        objBkBookTransactionPL.bookId = int.Parse(txtBookId.Text);
                        txtBookId.Text = "";
                        txtMemberId.Text = "";
                        ObjBookTransactionBL.bookIssue(objMemBookTransactionPL, objBkBookTransactionPL);
                        lblErrorMessage.Text = "Book Issued Successfully!";
                        lblErrorMessage.Visible = true;
                    }
                    catch (Exception ex)
                    {
                        lblErrorMessage.Visible = true;
                        lblErrorMessage.Text = ex.Message;

                    }
                }
                else
                {
                    lblErrorMessage.Visible = true;
                    lblErrorMessage.Text = "Enter Book ID and Member ID";
                }
                
                
            }
            else if (btnBookTransactionSubmit.Text=="Return Book")
            {
                if (txtBookId.Text != "" && txtMemberId.Text != "")
                {
                    try
                    {
                        EntitiesLayerClass.MemberDetails objMemBookTransactionPL = new EntitiesLayerClass.MemberDetails();
                        EntitiesLayerClass.AllBooks objBkBookTransactionPL = new EntitiesLayerClass.AllBooks();
                        BusinessLayerClass ObjBookTransactionBL = new BusinessLayerClass();
                        objMemBookTransactionPL.memberId = int.Parse(txtMemberId.Text);
                        objBkBookTransactionPL.bookId = int.Parse(txtBookId.Text);
                        txtBookId.Text = "";
                        txtMemberId.Text = "";
                        ObjBookTransactionBL.bookReturn(objMemBookTransactionPL, objBkBookTransactionPL);
                        lblErrorMessage.Text = "Books Returned Successfully!";
                        lblErrorMessage.Visible = true;
                    }
                    catch (Exception ex)
                    {
                        lblErrorMessage.Visible = true;
                        lblErrorMessage.Text = ex.Message;
                    }
                }
                else
                {
                    lblErrorMessage.Visible = true;
                    lblErrorMessage.Text = "Enter Book ID and Member ID";
                }
            }
        }

        


        
    }
}