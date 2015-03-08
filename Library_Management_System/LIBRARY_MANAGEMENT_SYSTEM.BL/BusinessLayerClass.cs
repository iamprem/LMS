using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library_Management_System.DAL;
using Library_Management_System.EL;
using System.Data;
using System.Data.SqlClient;

namespace Library_Management_System.BL
{
    public class BusinessLayerClass
    {
        public string loginMember(EntitiesLayerClass.MemberDetails memberLoginDetails)
        {
            try
            {
                DataAccessLayerClass objLoginPageDAL = new DataAccessLayerClass();
                return objLoginPageDAL.chkMemberPassword(memberLoginDetails);
            }
            catch (Exception)
            {                
                throw;
            }
        }



        public DataSet retriveMemberDetails(EntitiesLayerClass.MemberDetails memberLoginDetails1)
        {
            DataAccessLayerClass objMasterpageDAL = new DataAccessLayerClass();
            return objMasterpageDAL.retriveMemberDetails(memberLoginDetails1);
        }

        public DataSet retriveBookHistoryDetails(EntitiesLayerClass.MemberDetails memberLoginDetails2)
        {
            DataAccessLayerClass objMasterpageDAL = new DataAccessLayerClass();
            return objMasterpageDAL.retriveBookHistoryDetails(memberLoginDetails2);
        }


        public DataSet bookSearch(EntitiesLayerClass.BookDetails bookSearchDetails)
        {
            DataAccessLayerClass objSearchpageDAL = new DataAccessLayerClass();
            return objSearchpageDAL.retriveBookSearchResult(bookSearchDetails);
        }

        public void bookIssue(EntitiesLayerClass.MemberDetails adminMemBookTransactionDetails, EntitiesLayerClass.AllBooks adminBkBookTransactionDetails)
        {
            try
            {
                DataAccessLayerClass objBookTransactionDAL = new DataAccessLayerClass();
                objBookTransactionDAL.insertBookIssue(adminMemBookTransactionDetails, adminBkBookTransactionDetails);
            }
            catch (SqlException ex)
            {
                
                throw;
            }
            
        }
        public void bookReturn(EntitiesLayerClass.MemberDetails adminMemBookTransactionDetails1, EntitiesLayerClass.AllBooks adminBkBookTransactionDetails1)
        {
            try
            {
                DataAccessLayerClass objBookTransactionDAL = new DataAccessLayerClass();
                objBookTransactionDAL.updateBookReturn(adminMemBookTransactionDetails1, adminBkBookTransactionDetails1);
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }
        //Member Management Block
        public void addMemberDetails(EntitiesLayerClass.MemberDetails adminMemberManagementDetails)
        {
            DataAccessLayerClass objMemberManagementDAL = new DataAccessLayerClass();   
            objMemberManagementDAL.insertMemberDetails(adminMemberManagementDetails);
        }
        public DataSet MemberDetailsToEdit(EntitiesLayerClass.MemberDetails adminMemberManagementDetails1)
        {
            try
            {
                DataAccessLayerClass objMemberManagementDAL = new DataAccessLayerClass();
                return objMemberManagementDAL.retriveMemberDetailsToEdit(adminMemberManagementDetails1);    
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }
        public void updateMemberDetails(EntitiesLayerClass.MemberDetails adminMemberManagementDetails2)
        {
            DataAccessLayerClass objMemberManagementDAL = new DataAccessLayerClass();
            objMemberManagementDAL.updateMemberDetails(adminMemberManagementDetails2);
        }

        //Supplier Management Block
        public void addSupplierDetails(EntitiesLayerClass.SupplierDetails adminSupplierManagementDetails)
        {
            DataAccessLayerClass objSupplierManagementDAL = new DataAccessLayerClass();
            objSupplierManagementDAL.insertSupplierDetails(adminSupplierManagementDetails);
        }
        public DataSet SupplierDetailsToEdit(EntitiesLayerClass.SupplierDetails adminSupplierManagementDetails1)
        {
            try
            {
                DataAccessLayerClass objSupplierManagementDAL = new DataAccessLayerClass();
                return objSupplierManagementDAL.retriveSupplierDetailsToEdit(adminSupplierManagementDetails1);
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }
        public void updateSupplierDetails(EntitiesLayerClass.SupplierDetails adminSupplierManagementDetails2)
        {
            DataAccessLayerClass objSupplierManagementDAL = new DataAccessLayerClass();
            objSupplierManagementDAL.updateSupplierDetails(adminSupplierManagementDetails2);
        }


        //BookManagement

        public DataTable getCategoryddl()
        {
            DataAccessLayerClass objBookManagementDAL = new DataAccessLayerClass();
            return objBookManagementDAL.getCategoryddl();
        }
        public DataTable getBookCodeddl(string categorySelected)
        {
            DataAccessLayerClass objBookManagementDAL = new DataAccessLayerClass();
            return objBookManagementDAL.getBookCodeddl(categorySelected);
        }
        public DataTable getSupplierNameddl()
        {
            DataAccessLayerClass objBookManagementDAL = new DataAccessLayerClass();
            return objBookManagementDAL.getSupplierNameddl();
        }

        public void addNewBookDetails(EntitiesLayerClass.BookDetails adminBookManagementDetails)
        {
            DataAccessLayerClass objBookManagementDAL = new DataAccessLayerClass();
            objBookManagementDAL.insertNewBookDetails(adminBookManagementDetails);
        }
        public void addBookCopies(EntitiesLayerClass.AllBooks adminBkBookManagementDetails, EntitiesLayerClass.SupplierDetails adminSupBookManagementDetails)
        {
            DataAccessLayerClass objBookManagementDAL = new DataAccessLayerClass();
            objBookManagementDAL.insertBookCopies(adminBkBookManagementDetails, adminSupBookManagementDetails);
        }

        //ResetPassword
        public string getSecurityQuestion(EntitiesLayerClass.MemberDetails memberLoginDetails3)
        {
            try
            {
                DataAccessLayerClass objForgotpageDAL = new DataAccessLayerClass();
                return objForgotpageDAL.retriveSecurityQuestion(memberLoginDetails3);
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }
        public string getAnswer(EntitiesLayerClass.MemberDetails memberLoginDetails4)
        {
            DataAccessLayerClass objRetriveAnswerDAL = new DataAccessLayerClass();
            return objRetriveAnswerDAL.chkSecurityAnswer(memberLoginDetails4);
        }

        public void putNewPassword(EntitiesLayerClass.MemberDetails memberLoginDetails5)
        {
            DataAccessLayerClass objUpadatePasswordDAL = new DataAccessLayerClass();
            objUpadatePasswordDAL.updateNewPassword(memberLoginDetails5);
        }

        //Admin Login



        public string loginAdmin(EntitiesLayerClass.AdminDetails adminLoginDetails)
        {
            DataAccessLayerClass objLoginPageDAL = new DataAccessLayerClass();
            return objLoginPageDAL.chkAdminPassword(adminLoginDetails);
        }
    }
}
