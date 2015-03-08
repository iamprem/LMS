using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library_Management_System.EL;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Library_Management_System.DAL
{
    public class DataAccessLayerClass
    {
        public string chkMemberPassword(EntitiesLayerClass.MemberDetails memberLoginDetails)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LibraryManagementSystemConnectionString"].ConnectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand com = new SqlCommand("getPwdFrmDB", con);
                    com.Parameters.AddWithValue("@memberId", memberLoginDetails.memberId);
                    com.CommandType = CommandType.StoredProcedure;
                    Object pwdObj = com.ExecuteScalar();
                    string retrivedPwd = "";
                    if (pwdObj == null)
                    {
                        retrivedPwd = "";
                    }
                    else
                    {
                        retrivedPwd = pwdObj.ToString();
                    }
                    return retrivedPwd;
                }
                catch (Exception)
                {

                    throw;
                }

            }
        }
        public DataSet retriveMemberDetails(EntitiesLayerClass.MemberDetails memberLoginDetails1)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LibraryManagementSystemConnectionString"].ConnectionString))
            {
                con.Open();
                SqlCommand com = new SqlCommand("spGetMemberDetailsFrmDB", con);
                com.Parameters.AddWithValue("@memberId", memberLoginDetails1.memberId);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adp = new SqlDataAdapter();
                DataSet ds = new DataSet();
                adp.SelectCommand = com;
                adp.Fill(ds);
                com.Dispose();
                adp.Dispose();
                con.Close();
                return ds;
            }
        }
        public DataSet retriveBookSearchResult(EntitiesLayerClass.BookDetails bookSearchDetails)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LibraryManagementSystemConnectionString"].ConnectionString))
            {
                con.Open();
                SqlDataAdapter adp = new SqlDataAdapter();
                DataSet ds = new DataSet();
                if (bookSearchDetails.author == "" && bookSearchDetails.bookTitle == "")
                {
                    ds = null;
                }
                else
                {
                    SqlCommand com = new SqlCommand("spBookSearchTitleAndAuthor", con);
                    com.Parameters.AddWithValue("@bookTitle", bookSearchDetails.bookTitle);
                    com.Parameters.AddWithValue("@bookAuthor", bookSearchDetails.author);
                    com.CommandType = CommandType.StoredProcedure;
                    adp.SelectCommand = com;
                    adp.Fill(ds);
                    com.Dispose();
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        ds = null;
                    }
                }
                adp.Dispose();
                con.Close();

                return ds;
            }
        }
        public DataSet retriveBookHistoryDetails(EntitiesLayerClass.MemberDetails memberLoginDetails2)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LibraryManagementSystemConnectionString"].ConnectionString))
                {
                    con.Open();
                    SqlDataAdapter adp = new SqlDataAdapter();
                    DataSet ds = new DataSet();
                    SqlCommand com = new SqlCommand("spGetBookHistory", con);
                    com.Parameters.AddWithValue("@memberId", memberLoginDetails2.memberId);
                    com.CommandType = CommandType.StoredProcedure;
                    adp.SelectCommand = com;
                    adp.Fill(ds);
                    com.Dispose();
                    adp.Dispose();
                    con.Close();
                    return ds;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void insertBookIssue(EntitiesLayerClass.MemberDetails adminMemBookTransactionDetails, EntitiesLayerClass.AllBooks adminBkBookTransactionDetails)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LibraryManagementSystemConnectionString"].ConnectionString))
                {
                    con.Open();
                    SqlCommand com = new SqlCommand("spBookIssue", con);
                    com.Parameters.AddWithValue("@memberId", adminMemBookTransactionDetails.memberId);
                    com.Parameters.AddWithValue("@bookId", adminBkBookTransactionDetails.bookId);
                    com.Parameters.AddWithValue("@issueDate", DateTime.Now);
                    com.CommandType = CommandType.StoredProcedure;
                    com.ExecuteNonQuery();

                }
            }
            catch (SqlException ex)
            {

                throw;
            }

        }

        public void updateBookReturn(EntitiesLayerClass.MemberDetails adminMemBookTransactionDetails, EntitiesLayerClass.AllBooks adminBkBookTransactionDetails)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LibraryManagementSystemConnectionString"].ConnectionString))
                {
                    con.Open();
                    SqlCommand com = new SqlCommand("spBookReturn", con);
                    com.Parameters.AddWithValue("@memberId", adminMemBookTransactionDetails.memberId);
                    com.Parameters.AddWithValue("@bookId", adminBkBookTransactionDetails.bookId);
                    com.Parameters.AddWithValue("@returnDate", DateTime.Now);
                    com.CommandType = CommandType.StoredProcedure;
                    com.ExecuteNonQuery();

                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void insertMemberDetails(EntitiesLayerClass.MemberDetails adminMemberManagementDetails)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LibraryManagementSystemConnectionString"].ConnectionString))
            {
                con.Open();
                SqlCommand com = new SqlCommand("spAddMemberDetails", con);
                com.Parameters.AddWithValue("@memberName", adminMemberManagementDetails.memberName);
                com.Parameters.AddWithValue("@phoneNumber", adminMemberManagementDetails.phoneNumber);
                com.Parameters.AddWithValue("@password", adminMemberManagementDetails.password);
                com.Parameters.AddWithValue("@memberEmail", adminMemberManagementDetails.memberEmail);
                com.Parameters.AddWithValue("@securityQuestion", adminMemberManagementDetails.securityQuestion);
                com.Parameters.AddWithValue("@answer", adminMemberManagementDetails.answer);
                com.Parameters.AddWithValue("@idProofValue", adminMemberManagementDetails.idProofNumber);
                com.Parameters.AddWithValue("@idProofType", adminMemberManagementDetails.idProofType);
                com.Parameters.AddWithValue("@registerDate", DateTime.Now);
                com.CommandType = CommandType.StoredProcedure;
                com.ExecuteNonQuery();

            }
        }


        public DataSet retriveMemberDetailsToEdit(EntitiesLayerClass.MemberDetails adminMemberManagementDetails1)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LibraryManagementSystemConnectionString"].ConnectionString))
                {
                    con.Open();
                    SqlCommand com = new SqlCommand("spGetMemberDetails", con);
                    com.Parameters.AddWithValue("@memberId", adminMemberManagementDetails1.memberId);
                    com.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adp = new SqlDataAdapter();
                    DataSet ds = new DataSet();
                    adp.SelectCommand = com;
                    adp.Fill(ds);
                    com.Dispose();
                    adp.Dispose();
                    con.Close();
                    return ds;
                }
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }


        //After Clicking Update
        public void updateMemberDetails(EntitiesLayerClass.MemberDetails adminMemberManagementDetails2)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LibraryManagementSystemConnectionString"].ConnectionString))
            {
                con.Open();
                SqlCommand com = new SqlCommand("spEditMemberDetails", con);
                com.Parameters.AddWithValue("@memberId", adminMemberManagementDetails2.memberId);
                com.Parameters.AddWithValue("@memberName", adminMemberManagementDetails2.memberName);
                com.Parameters.AddWithValue("@phoneNumber", adminMemberManagementDetails2.phoneNumber);
                com.Parameters.AddWithValue("@memberEmail", adminMemberManagementDetails2.memberEmail);
                com.Parameters.AddWithValue("@securityQuestion", adminMemberManagementDetails2.securityQuestion);
                com.Parameters.AddWithValue("@answer", adminMemberManagementDetails2.answer);
                com.Parameters.AddWithValue("@idProofValue", adminMemberManagementDetails2.idProofNumber);
                com.Parameters.AddWithValue("@idProofType", adminMemberManagementDetails2.idProofType);
                com.CommandType = CommandType.StoredProcedure;
                com.ExecuteNonQuery();

            }
        }


        //Supplier Details Management
        public void insertSupplierDetails(EntitiesLayerClass.SupplierDetails adminSupplierManagementDetails)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LibraryManagementSystemConnectionString"].ConnectionString))
            {
                con.Open();
                SqlCommand com = new SqlCommand("spAddSupplierDetails", con);
                com.Parameters.AddWithValue("@supplierName", adminSupplierManagementDetails.supplierName);
                com.Parameters.AddWithValue("@phoneNumber", adminSupplierManagementDetails.contact);
                com.Parameters.AddWithValue("@supplierEmail", adminSupplierManagementDetails.email);
                com.CommandType = CommandType.StoredProcedure;
                com.ExecuteNonQuery();

            }
        }
        public DataSet retriveSupplierDetailsToEdit(EntitiesLayerClass.SupplierDetails adminSupplierManagementDetails1)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LibraryManagementSystemConnectionString"].ConnectionString))
                {
                    con.Open();
                    SqlCommand com = new SqlCommand("spGetSupplierDetails", con);
                    com.Parameters.AddWithValue("@supplierId", adminSupplierManagementDetails1.supplierId);
                    com.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adp = new SqlDataAdapter();
                    DataSet ds = new DataSet();
                    adp.SelectCommand = com;
                    adp.Fill(ds);
                    com.Dispose();
                    adp.Dispose();
                    con.Close();
                    return ds;
                }
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }
        public void updateSupplierDetails(EntitiesLayerClass.SupplierDetails adminSupplierManagementDetails2)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LibraryManagementSystemConnectionString"].ConnectionString))
            {
                con.Open();
                SqlCommand com = new SqlCommand("spEditSupplierDetails", con);
                com.Parameters.AddWithValue("@supplierId", adminSupplierManagementDetails2.supplierId);
                com.Parameters.AddWithValue("@supplierName", adminSupplierManagementDetails2.supplierName);
                com.Parameters.AddWithValue("@phoneNumber", adminSupplierManagementDetails2.contact);
                com.Parameters.AddWithValue("@supplierEmail", adminSupplierManagementDetails2.email);
                com.CommandType = CommandType.StoredProcedure;
                com.ExecuteNonQuery();
            }
        }
        public DataTable getCategoryddl()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LibraryManagementSystemConnectionString"].ConnectionString))
            {
                SqlCommand com = new SqlCommand("spCategorySelect", con);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adp = new SqlDataAdapter();
                DataTable dt = new DataTable();
                adp.SelectCommand = com;
                adp.Fill(dt);
                com.Dispose();
                adp.Dispose();
                return dt;
            }
        }
        public DataTable getSupplierNameddl()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LibraryManagementSystemConnectionString"].ConnectionString))
            {
                SqlCommand com = new SqlCommand("spSupplierNameSelect", con);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adp = new SqlDataAdapter();
                DataTable dt = new DataTable();
                adp.SelectCommand = com;
                adp.Fill(dt);
                com.Dispose();
                adp.Dispose();
                return dt;
            }
        }
        public DataTable getBookCodeddl(string categorySelected)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LibraryManagementSystemConnectionString"].ConnectionString))
            {
                SqlCommand com = new SqlCommand("spBookCodeSelect", con);
                com.Parameters.AddWithValue("@categorySelected", categorySelected);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adp = new SqlDataAdapter();
                DataTable dt = new DataTable();
                adp.SelectCommand = com;
                adp.Fill(dt);
                com.Dispose();
                adp.Dispose();
                return dt;
            }
        }

        public void insertNewBookDetails(EntitiesLayerClass.BookDetails adminBookManagementDetails)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LibraryManagementSystemConnectionString"].ConnectionString))
            {
                con.Open();
                SqlCommand com = new SqlCommand("spAddNewBookDetails", con);
                com.Parameters.AddWithValue("@bookCode", adminBookManagementDetails.bookCode);
                com.Parameters.AddWithValue("@bookTitle", adminBookManagementDetails.bookTitle);
                com.Parameters.AddWithValue("@author", adminBookManagementDetails.author);
                com.Parameters.AddWithValue("@category", adminBookManagementDetails.catogory);
                com.Parameters.AddWithValue("@publications", adminBookManagementDetails.publications);
                com.Parameters.AddWithValue("@bookEdition", adminBookManagementDetails.bookEdition);
                com.Parameters.AddWithValue("@price", adminBookManagementDetails.price);
                com.CommandType = CommandType.StoredProcedure;
                com.ExecuteNonQuery();
            }
        }
        public void insertBookCopies(EntitiesLayerClass.AllBooks adminBkBookManagentDetails, EntitiesLayerClass.SupplierDetails adminSupBookManagementDetails)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LibraryManagementSystemConnectionString"].ConnectionString))
            {
                con.Open();
                SqlCommand com = new SqlCommand("spAddBookCopies", con);
                com.Parameters.AddWithValue("@bookCode", adminBkBookManagentDetails.bookCode);
                com.Parameters.AddWithValue("@availability", adminBkBookManagentDetails.bookAvailability);
                com.Parameters.AddWithValue("@supplierName", adminSupBookManagementDetails.supplierName);
                com.CommandType = CommandType.StoredProcedure;
                com.ExecuteNonQuery();
            }
        }

        //ResetPassword
        public string retriveSecurityQuestion(EntitiesLayerClass.MemberDetails memberLoginDetails3)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LibraryManagementSystemConnectionString"].ConnectionString))
                {
                    con.Open();
                    SqlCommand com = new SqlCommand("spSecurityQuestion", con);
                    com.Parameters.AddWithValue("@memberId", memberLoginDetails3.memberId);
                    com.CommandType = CommandType.StoredProcedure;
                    string retrivedQuestion = com.ExecuteScalar().ToString();
                    return retrivedQuestion;

                }
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }
        public string chkSecurityAnswer(EntitiesLayerClass.MemberDetails memberLoginDetails4)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LibraryManagementSystemConnectionString"].ConnectionString))
            {
                con.Open();
                SqlCommand com = new SqlCommand("spMatchAnswer", con);
                com.Parameters.AddWithValue("@memberId", memberLoginDetails4.memberId);
                com.CommandType = CommandType.StoredProcedure;
                string retrivedAnswer = "";
                object objRetrivedAnswer = com.ExecuteScalar();
                if (objRetrivedAnswer == null)
                {
                    retrivedAnswer = "";
                }
                else
                {
                    retrivedAnswer = objRetrivedAnswer.ToString();
                }
                return retrivedAnswer;

            }
        }
        public void updateNewPassword(EntitiesLayerClass.MemberDetails memberLoginDetails5)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LibraryManagementSystemConnectionString"].ConnectionString))
            {
                con.Open();
                SqlCommand com = new SqlCommand("spUpdateNewPassword", con);
                com.Parameters.AddWithValue("@memberId", memberLoginDetails5.memberId);
                com.Parameters.AddWithValue("@password", memberLoginDetails5.password);
                com.CommandType = CommandType.StoredProcedure;
                com.ExecuteNonQuery();
            }
        }

        public string chkAdminPassword(EntitiesLayerClass.AdminDetails adminLoginDetails)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LibraryManagementSystemConnectionString"].ConnectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand com = new SqlCommand("getAdminPwd", con);
                    com.Parameters.AddWithValue("@adminId", adminLoginDetails.adminId);
                    com.CommandType = CommandType.StoredProcedure;
                    Object pwdObj = com.ExecuteScalar();
                    string retrivedPwd = "";
                    if (pwdObj == null)
                    {
                        retrivedPwd = "";
                    }
                    else
                    {
                        retrivedPwd = pwdObj.ToString();
                    }
                    return retrivedPwd;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
