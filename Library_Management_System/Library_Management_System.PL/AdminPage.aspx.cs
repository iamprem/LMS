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
    public partial class AdminPage : System.Web.UI.Page
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
    }
}