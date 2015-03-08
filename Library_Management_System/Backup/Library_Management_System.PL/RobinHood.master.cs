using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library_Management_System.PL
{
    public partial class RobinHood : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           

        }

        protected void btnBookTransaction_Click(object sender, EventArgs e)
        {
            Response.Redirect("BookTransaction.aspx");
        }

        protected void btnManageMembers_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageMembers.aspx");
        }

        protected void btnManageSuppliers_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageSuppliers.aspx");
        }

        protected void btnManageBooks_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageBooks.aspx");
        }

        protected void btnSignOut_Click(object sender, EventArgs e)
        {
            Session["adminIDSS"] = null;
            Response.Redirect("Default.aspx");
        }

        

        
    }
}