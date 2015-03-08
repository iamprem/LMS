using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library_Management_System.EL
{
    public class EntitiesLayerClass
    {
        public class MemberDetails
        {
            public int memberId { get; set; }
            public string memberName { get; set; }
            public long phoneNumber { get; set; }
            public string password { get; set; }
            public string memberEmail { get; set; }
            public string securityQuestion { get; set; }
            public string answer { get; set; }
            public string idProofType { get; set; }
            public string idProofNumber { get; set; }
            public DateTime dateRegister { get; set; }
        }
        public class SupplierDetails
        {
            public int supplierId { get; set; }
            public string supplierName { get; set; }
            public long contact { get; set; }
            public string email { get; set; }
        }
        public class BookDetails
        {
            public string bookCode { get; set; }
            public string bookTitle { get; set; }
            public string catogory { get; set; }
            public string author { get; set; }
            public string publications { get; set; }
            public int bookEdition { get; set; }
            public double price { get; set; }
        }
        public class AllBooks
        {
            public int bookId { get; set; }
            public string bookCode { get; set; }
            public char bookAvailability { get; set; }
            public string supplierId { get; set; }
        }
        public class BookIssue
        {
            public int bookIssueNumber { get; set; }
            public int memberID { get; set; }
            public int bookID { get; set; }
            public DateTime dateIssue { get; set; }
            public DateTime dateDue { get; set; }
            public DateTime dateReturn { get; set; }
            public int daysDelayed { get; set; }
            public double fineAmount { get; set; }
        }
        public class AdminDetails
        {
            public int adminId { get; set; }
            public string password { get; set; }
        }
    }
}
