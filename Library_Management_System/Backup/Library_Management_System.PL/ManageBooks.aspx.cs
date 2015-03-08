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
    public partial class ManageBooks : System.Web.UI.Page
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

        protected void btnAddBookDetails_Click(object sender, EventArgs e)
        {
            BusinessLayerClass objBookManagementBL=new BusinessLayerClass();
            DataTable categoryList=new DataTable();
            categoryList=objBookManagementBL.getCategoryddl();
            ddlCategory.DataSource = categoryList;
            ddlCategory.DataTextField="category";
            ddlCategory.DataValueField = "category";
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, "Select a Category");
            ddlCategory.Items.Insert(1, "Add New Category");

            //DataTable bookCodeList = new DataTable();
            //bookCodeList = objBookManagementBL.getBookCodeddl();
            //ddlBookCode.DataSource = bookCodeList;
            //ddlBookCode.DataTextField = "bookcode";
            //ddlBookCode.DataValueField = "bookcode";
            //ddlBookCode.DataBind();
            //ddlBookCode.Items.Insert(0, "Select a BookCode");
            //ddlBookCode.Items.Insert(1, "Add New BookCode");

            DataTable supplierNameList = new DataTable();
            supplierNameList = objBookManagementBL.getSupplierNameddl();
            ddlSupplierName.DataSource = supplierNameList;
            ddlSupplierName.DataTextField = "suppliername";
            ddlSupplierName.DataValueField = "suppliername";
            ddlSupplierName.DataBind();
            ddlSupplierName.Items.Insert(0, "Select a Supplier");

            txtBookCode.Text = "";
            txtBookCode.Enabled = true;
            txtCategory.Text = "";
            txtCategory.Visible = false;
            txtQuantity.Text = "0";
            lblAuthor.Visible = true;
            lblBookCode.Visible = true;
            lblBookEdition.Visible = true;
            lblBookTitle.Visible = true;
            lblCategory.Visible = true;
            lblPrice.Visible = true;
            lblPublications.Visible = true;
            lblQuantity.Visible = true;
            lblSupplierName.Visible = true;
            txtAuthor.Visible = true;
            ddlBookCode.Visible = false;
            txtBookCode.Visible = true; 
            txtBookEdition.Visible = true;
            txtBookTitle.Visible = true;
            ddlCategory.Visible = true;
            txtCategory.Visible = true;
            txtPrice.Visible = true;
            txtPublications.Visible = true;
            txtQuantity.Visible = true;
            ddlSupplierName.Visible = true;
            btnManageBookSubmit.Text = "Add New Book";
            btnManageBookSubmit.Visible = true;
            lblErrorMessage.Text = "";
        }

        protected void btnAddBookCopies_Click(object sender, EventArgs e)
        {
            BusinessLayerClass objBookManagementBL = new BusinessLayerClass();
            DataTable categoryList = new DataTable();
            categoryList = objBookManagementBL.getCategoryddl();
            ddlCategory.DataSource = categoryList;
            ddlCategory.DataTextField = "category";
            ddlCategory.DataValueField = "category";
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, "Select a Category");
           

            //DataTable bookCodeList = new DataTable();
            //bookCodeList = objBookManagementBL.getBookCodeddl(txtBookCode.Text);
            //ddlBookCode.DataSource = bookCodeList;
            //ddlBookCode.DataTextField = "bookcode";
            //ddlBookCode.DataValueField = "bookcode";
            //ddlBookCode.DataBind();
            //ddlBookCode.Items.Insert(0, "Select a BookCode");
            

            DataTable supplierNameList = new DataTable();
            supplierNameList = objBookManagementBL.getSupplierNameddl();
            ddlSupplierName.DataSource = supplierNameList;
            ddlSupplierName.DataTextField = "suppliername";
            ddlSupplierName.DataValueField = "suppliername";
            ddlSupplierName.DataBind();
            ddlSupplierName.Items.Insert(0, "Select a Supplier");
            txtQuantity.Text = "0";
            txtBookCode.Text = "";
            txtBookCode.Visible = false;
            txtCategory.Text = "";
            txtCategory.Visible = false;
            txtBookCode.Enabled = true;

            lblAuthor.Visible = false;
            lblBookCode.Visible = true;
            lblBookEdition.Visible = false;
            lblBookTitle.Visible = false;
            lblCategory.Visible = true;
            lblPrice.Visible = false;
            lblPublications.Visible = false;
            lblQuantity.Visible = true;
            lblSupplierName.Visible = true;
            txtAuthor.Visible = false;
            ddlBookCode.Visible = true;
            txtBookEdition.Visible = false;
            txtBookTitle.Visible = false;
            ddlCategory.Visible = true;
            txtPrice.Visible = false;
            txtPublications.Visible = false;
            txtQuantity.Visible = true;
            ddlSupplierName.Visible = true;
            btnManageBookSubmit.Text = "Add Copies";
            btnManageBookSubmit.Visible = true;
            lblErrorMessage.Text = "";
            ddlBookCode.Items.Clear();
            
        }

        protected void btnManageBookSubmit_Click(object sender, EventArgs e)
        {
            if (btnManageBookSubmit.Text=="Add New Book")
            {
                if (ddlCategory.SelectedIndex!=0 && txtBookCode.Text!="" && txtBookEdition.Text!="" && txtBookTitle.Text!="" && txtPrice.Text!="" && txtPublications.Text!="" && txtQuantity.Text!=""&& ddlSupplierName.SelectedIndex!=0)
                {
                    int copiesCount = 0;
                    EntitiesLayerClass.BookDetails objBookManagementPL = new EntitiesLayerClass.BookDetails();
                    EntitiesLayerClass.AllBooks objBkBookManagementPL = new EntitiesLayerClass.AllBooks();
                    EntitiesLayerClass.SupplierDetails objSupBookManagementPL = new EntitiesLayerClass.SupplierDetails();
                    BusinessLayerClass objBookManagementBL = new BusinessLayerClass();
                    
                    objBkBookManagementPL.bookCode = txtBookCode.Text;
                    objBkBookManagementPL.bookAvailability = 'Y';
                    objSupBookManagementPL.supplierName = ddlSupplierName.SelectedValue;
                    

                    objBookManagementPL.bookCode = txtBookCode.Text;
                    objBookManagementPL.bookTitle = txtBookTitle.Text;
                    objBookManagementPL.author = txtAuthor.Text;
                    objBookManagementPL.catogory = txtCategory.Text;
                    objBookManagementPL.publications = txtPublications.Text;
                    objBookManagementPL.bookEdition = int.Parse(txtBookEdition.Text);
                    objBookManagementPL.price = double.Parse(txtPrice.Text);
                    if (int.Parse(txtQuantity.Text)>0)
                    {
                        objBookManagementBL.addNewBookDetails(objBookManagementPL);
                        for (int i = 0; i < int.Parse(txtQuantity.Text); i++)
                        {
                            copiesCount++;
                            objBookManagementBL.addBookCopies(objBkBookManagementPL, objSupBookManagementPL);

                        }
                        lblErrorMessage.Text = copiesCount + " Copies of the New Book Added Successfully!";
                    }
                    else
                    {
                        lblErrorMessage.Text = "Quantity Cannot Be Zero";
                    }
                }
                else
                {
                    lblErrorMessage.Text = "You missed entering data in some of the feilds. Please Check!";
                }
            }
            else if (btnManageBookSubmit.Text=="Add Copies")
            {
                if (txtBookCode.Text != "" && ddlSupplierName.SelectedIndex != 0 && txtQuantity.Text != "")
                {
                    int copiesCount = 0;
                    EntitiesLayerClass.AllBooks objBkBookManagementPL = new EntitiesLayerClass.AllBooks();
                    EntitiesLayerClass.SupplierDetails objSupBookManagementPL = new EntitiesLayerClass.SupplierDetails();
                    BusinessLayerClass objBookManagementBL = new BusinessLayerClass();
                    objBkBookManagementPL.bookCode = txtBookCode.Text;
                    objBkBookManagementPL.bookAvailability = 'Y';
                    objSupBookManagementPL.supplierName = ddlSupplierName.SelectedValue;
                    if (int.Parse(txtQuantity.Text)>0)
                    {
                        for (int i = 0; i < int.Parse(txtQuantity.Text); i++)
                        {
                            copiesCount++;
                            objBookManagementBL.addBookCopies(objBkBookManagementPL, objSupBookManagementPL);
                        }
                        lblErrorMessage.Text = copiesCount + " Copies are Added Successfully!";
                    }
                    else
                    {
                        lblErrorMessage.Text = "Quantity Cannot Be Zero";
                    }
                    
                    

                }
                else
                {
                    lblErrorMessage.Text = "You missed entering data in some of the feilds. Please Check!";
                }
            }
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCategory.SelectedValue == "Add New Category")
            {
                txtCategory.Visible = true;
                txtCategory.Enabled = true;
                txtCategory.Text = "";
            }
            else if (ddlCategory.SelectedIndex==0)
            {
                txtCategory.Visible = false;
                txtCategory.Text = "";
            }
            else
            {
                txtCategory.Text = ddlCategory.SelectedValue;
                
                //
                DataTable bookCodeList = new DataTable();
                BusinessLayerClass objBookManagementBL = new BusinessLayerClass();
                bookCodeList = objBookManagementBL.getBookCodeddl(txtCategory.Text);
                ddlBookCode.DataSource = bookCodeList;
                ddlBookCode.DataTextField = "bookcode";
                ddlBookCode.DataValueField = "bookcode";
                ddlBookCode.DataBind();
                ddlBookCode.Items.Insert(0, "Select a BookCode");
                txtCategory.Enabled = false;
                txtCategory.Visible = true;
            }
        }

        protected void ddlBookCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlBookCode.SelectedValue == "Add New BookCode")
            {
                txtBookCode.Visible = true;
                txtBookCode.Enabled = true;
                txtBookCode.Text = "";
            }
            else if (ddlBookCode.SelectedIndex == 0)
            {
                txtBookCode.Visible = false;
                txtBookCode.Text = "";
            }
            else
            {
                txtBookCode.Text = ddlBookCode.SelectedValue;
                txtBookCode.Visible = true;
                txtBookCode.Enabled = false;
            }
        }

        
    }
}