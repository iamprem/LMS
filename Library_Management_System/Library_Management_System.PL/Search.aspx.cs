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
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            lblBookTitle.Visible = false;
            lblAuthor.Visible = false;
            txtAuthor.Visible = false;
            txtBookTitle.Visible = false;
            btnSearch.Visible = false;
            EntitiesLayerClass.BookDetails bookSearchDetails=new EntitiesLayerClass.BookDetails();
            bookSearchDetails.bookTitle=txtBookTitle.Text;
            bookSearchDetails.author=txtAuthor.Text;
            BusinessLayerClass objSearchPageBL=new BusinessLayerClass();
            DataSet ds = new DataSet();
            ds=objSearchPageBL.bookSearch(bookSearchDetails);
            if (ds==null)
            {
                lblBookSearchStatus.Text = "No Books Found";
                gvBookSearchResult.Visible = false;
            }
            else
            {
                lblBookSearchStatus.Text = "Matches Found";
                gvBookSearchResult.DataSource = ds;
                gvBookSearchResult.DataBind();
                gvBookSearchResult.Visible = true;
            }
            
        }
    }
}