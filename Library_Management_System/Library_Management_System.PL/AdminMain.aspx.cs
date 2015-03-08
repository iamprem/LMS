using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library_Management_System.PL
{
    public partial class AdminMain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btn1.Visible = false;
            btn2.Visible = false;
            btn3.Visible = false;

        }

        

        protected void btnBookTransaction_Click(object sender, EventArgs e)
        {
            btn1.Text = "Book Issue";
            btn2.Text = "Book Return";
            btn1.Visible = true;
            btn2.Visible = true;
            btn3.Visible = false;
        }

        protected void btnManageMembers_Click(object sender, EventArgs e)
        {
            btn1.Text = "Add Member";
            btn2.Text = "Edit Member";
            btn3.Text = "Delete Member";
            btn1.Visible = true;
            btn2.Visible = true;
            btn3.Visible = true;
        }

        protected void btnManageSuppliers_Click(object sender, EventArgs e)
        {
            btn1.Text = "Add Supplier";
            btn2.Text = "Edit Supplier";
            btn3.Text = "Delete Supplier";
            btn1.Visible = true;
            btn2.Visible = true;
            btn3.Visible = true;
        }

        protected void btnManageBooks_Click(object sender, EventArgs e)
        {
            btn1.Text = "Add Book";
            btn2.Text = "Edit Book";
            btn3.Text = "Delete Book";
            btn1.Visible = true;
            btn2.Visible = true;
            btn3.Visible = true;
        }
        

        protected void btnSignOut_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void btn1_Click(object sender, EventArgs e)
        {
            if (btn1.Text == "Book Issue")
            {
                btnBookIssue_Click();
            }
            else if (btn1.Text == "Add Member")
            {

            }
            else if (btn1.Text == "Add Supplier")
            {

            }
            else if (btn1.Text == "Add Book")
            {

            }

        }

        protected void btn2_Click(object sender, EventArgs e)
        {
            if (btn2.Text == "Book Return")
            {
                btnBookReturn_Click();
            }
            else if (btn2.Text == "Edit Member")
            {

            }
            else if (btn2.Text == "Edit Supplier")
            {

            }
            else if (btn2.Text == "Edit Book")
            {

            }
            
        }
        protected void btn3_Click(object sender, EventArgs e)
        {
            if (btn3.Text == "Delete Member")
            {

            }
            else if (btn3.Text == "Delete Supplier")
            {

            }
            else if (btn3.Text == "Delete Book")
            {

            }
        }

        protected void btnBookIssue_Click()
        {
            Response.Redirect("Default.aspx");
        }
        protected void btnBookReturn_Click()
        {

        }
        protected void btnAddMember_Click()
        {

        }
        protected void btnEditMember_Click()
        {

        }
        protected void btnDeleteMember_Click()
        {

        }
        protected void btnAddSupplier_Click()
        {

        }
        protected void btnEditSupplier_Click()
        {

        }
        protected void btnDeleteSupplier_Click()
        {

        }
        protected void btnAddBook_Click()
        {

        }
        protected void btnEditBook_Click()
        {

        }
        protected void btnDeleteBook_Click()
        {

        }

        

        
    }
}