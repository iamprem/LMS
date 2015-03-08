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
    public partial class ManageSuppliers : System.Web.UI.Page
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

        protected void btnManageSupplierSubmit_Click(object sender, EventArgs e)
        {
            if (btnManageSupplierSubmit.Text=="Add")
            {
                if (txtSupplierName.Text!="" && txtPhoneNumber.Text!="" && txtSupplierEmail.Text!="")
                {
                    try
                    {
                        EntitiesLayerClass.SupplierDetails objSupplierManagementPL = new EntitiesLayerClass.SupplierDetails();
                        BusinessLayerClass objSupplierManagementBL = new BusinessLayerClass();
                        objSupplierManagementPL.supplierName = txtSupplierName.Text;
                        objSupplierManagementPL.contact = Int64.Parse(txtPhoneNumber.Text);
                        objSupplierManagementPL.email = txtSupplierEmail.Text;
                        objSupplierManagementBL.addSupplierDetails(objSupplierManagementPL);
                        lblErrorMessage.Text = "Supplier Added Successfully :)";
                        txtSupplierName.Text = "";
                        txtPhoneNumber.Text = "";
                        txtSupplierEmail.Text = "";
                    }
                    catch (Exception)
                    {
                        lblErrorMessage.Text = "Check  Phone Number Feild";   
                    }
                    
                }
                else
                {
                    lblErrorMessage.Text = "You missed entering data in some of the feilds. Please Check!";
                }
            }
            else if (btnManageSupplierSubmit.Text=="Edit")
            {
                if (txtSupplierId.Text!="")
                {
                    try
                    {
                        EntitiesLayerClass.SupplierDetails objSupplierManagementPL = new EntitiesLayerClass.SupplierDetails();
                        BusinessLayerClass objSupplierManagementBL = new BusinessLayerClass();
                        objSupplierManagementPL.supplierId = int.Parse(txtSupplierId.Text);
                        DataSet supplierDetails = objSupplierManagementBL.SupplierDetailsToEdit(objSupplierManagementPL);
                        txtSupplierName.Text = supplierDetails.Tables[0].Rows[0][1].ToString();
                        txtPhoneNumber.Text = supplierDetails.Tables[0].Rows[0][2].ToString();
                        txtSupplierEmail.Text = supplierDetails.Tables[0].Rows[0][3].ToString();
                        lblSupplierName.Visible = true;
                        lblSupplierEmail.Visible = true;
                        lblPhoneNumber.Visible = true;
                        txtPhoneNumber.Visible = true;
                        txtSupplierEmail.Visible = true;
                        txtSupplierName.Visible = true;
                        txtSupplierId.Enabled = false;
                        btnManageSupplierSubmit.Text = "Update";
                        lblErrorMessage.Text = "";
                    }
                    catch (Exception)
                    {
                        lblErrorMessage.Text = "Enter a valid Supplier ID";
                    }
                    
                }
                else
                {
                    lblErrorMessage.Text = "Enter a Valid Supplier ID";
                }
            }
            else if (btnManageSupplierSubmit.Text=="Update")
            {
                if (txtSupplierName.Text!="" && txtPhoneNumber.Text!="" && txtSupplierEmail.Text!="")
                {
                    try
                    {
                        EntitiesLayerClass.SupplierDetails objSupplierManagementPL = new EntitiesLayerClass.SupplierDetails();
                        BusinessLayerClass objSupplierManagementBL = new BusinessLayerClass();
                        objSupplierManagementPL.supplierId = int.Parse(txtSupplierId.Text);
                        objSupplierManagementPL.supplierName = txtSupplierName.Text;
                        objSupplierManagementPL.contact = Int64.Parse(txtPhoneNumber.Text);
                        objSupplierManagementPL.email = txtSupplierEmail.Text;

                        objSupplierManagementBL.updateSupplierDetails(objSupplierManagementPL);
                        lblErrorMessage.Text = "Update Successfull :P";

                        txtSupplierName.Text = "";
                        txtPhoneNumber.Text = "";
                        txtSupplierEmail.Text = "";
                        txtSupplierId.Text = "";
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

        protected void btnAddSupplierDetails_Click(object sender, EventArgs e)
        {
            lblErrorMessage.Text = "";
            txtSupplierId.Text = "";
            txtSupplierName.Text = "";
            txtPhoneNumber.Text = "";
            txtSupplierEmail.Text = "";
            lblSupplierId.Visible = false;
            txtSupplierId.Visible = false;
            lblSupplierName.Visible = true;
            lblSupplierEmail.Visible = true;
            lblPhoneNumber.Visible = true;
            txtPhoneNumber.Visible = true;
            txtSupplierEmail.Visible = true;
            txtSupplierName.Visible = true;
            btnManageSupplierSubmit.Text = "Add";
            btnManageSupplierSubmit.Visible = true;

        }

        protected void btnEditSupplierDetails_Click(object sender, EventArgs e)
        {
            lblErrorMessage.Text = "";
            txtSupplierId.Text = "";
            txtSupplierId.Enabled = true;
            lblSupplierId.Visible = true;
            txtSupplierId.Visible = true;
            lblSupplierName.Visible = false;
            lblSupplierEmail.Visible = false;
            lblPhoneNumber.Visible = false;
            txtPhoneNumber.Visible = false;
            txtSupplierEmail.Visible = false;
            txtSupplierName.Visible = false;
            btnManageSupplierSubmit.Visible = true;
            btnManageSupplierSubmit.Text = "Edit";
        }

        
    }
}