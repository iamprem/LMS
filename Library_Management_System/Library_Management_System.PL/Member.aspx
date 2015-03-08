<%@ Page Title="" Language="C#" MasterPageFile="~/Batman.Master" AutoEventWireup="true" CodeBehind="Member.aspx.cs" Inherits="Library_Management_System.PL.Member" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div>
      <br />
  <br />
  <br />
  <br />
<center><h2><asp:Label ID="lblWelcomeMemberName" runat="server" ></asp:Label></h2></center>

 <br />
 <br />
    <div align="center" style="height: 36px">

        


    <asp:Button ID="btnMemberDetails" runat="server" 
         style="color: #66CCFF; background-color: #000000; font-weight: bold;"
        Text="Member Details" Height="35px" Width="250px" onclick="btnMemberDetails_Click" 
            CssClass="ButtonStyle"/>
    <asp:Button ID="btnBookHistory" runat="server" 
        style="color: #66CCFF; background-color: #000000; font-weight: bold;" Text="Book History" 
        Height="35px" Width="250px" CssClass="ButtonStyle" 
            onclick="btnBookHistory_Click" />
    <asp:Button ID="btnCurrentBooks" runat="server" 
        style="color: #66CCFF; background-color: #000000; font-weight: bold;" Text="Current Books" 
        Height="35px" Width="250px" onclick="btnCurrentBooks_Click" CssClass="ButtonStyle"/>
    <asp:Button ID="btnSignOut" runat="server"
        style="color: #66CCFF; background-color: #000000; font-weight: bold;" Text="Sign Out" 
        Height="35px" Width="250px" onclick="btnSignOut_Click" CssClass="ButtonStyle" />
        </div>
        </div>
  <br />
  <br />
  <br />
  <br />
  <br />
  <br />

   <div>
   <center style="height: 484px">
    
    <asp:GridView ID="grdCurrentBooks" runat="server" AllowPaging="True" 
    AutoGenerateColumns="False" 
    DataSourceID="sdsCurrentBooks" EnableModelValidation="True" CellPadding="4" 
           ForeColor="#333333" GridLines="None">
    <AlternatingRowStyle BackColor="White" />
    <Columns>
        <asp:BoundField DataField="Book ID" HeaderText="Book ID" 
            SortExpression="Book ID" />
        <asp:BoundField DataField="Title" HeaderText="Title" 
            SortExpression="Title" />
        <asp:BoundField DataField="Issue Date" HeaderText="Issue Date" 
            SortExpression="Issue Date" />
        <asp:BoundField DataField="Due Date" HeaderText="Due Date" ReadOnly="True" 
            SortExpression="Due Date" />
        <asp:BoundField DataField="Days Delayed" HeaderText="Days Delayed" 
            SortExpression="Days Delayed" ReadOnly="True" />
        <asp:BoundField DataField="Fine Amount" HeaderText="Fine Amount" 
            ReadOnly="True" SortExpression="Fine Amount" />
    </Columns>
    <EditRowStyle BackColor="#2461BF" />
    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
    <RowStyle BackColor="#EFF3FB" />
    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
</asp:GridView>
<asp:SqlDataSource ID="sdsCurrentBooks" runat="server" 
    ConnectionString="<%$ ConnectionStrings:LIBRARY_MANAGEMENT_SYSTEMConnectionString2 %>" 
    
        
           
           
           SelectCommand="SELECT  LMS_BOOK_ISSUE.BOOK_ID as 'Book ID', LMS_BOOK_DETAILS.BOOK_TITLE as 'Title', LMS_BOOK_ISSUE.DATE_ISSUE as 'Issue Date', LMS_BOOK_ISSUE.DATE_DUE as 'Due Date', LMS_BOOK_ISSUE.DAYS_DELAYED as 'Days Delayed', LMS_BOOK_ISSUE.FINE_AMOUNT as 'Fine Amount' 
FROM LMS_BOOK_ISSUE 
INNER JOIN LMS_MEMBER_DETAILS ON LMS_MEMBER_DETAILS.MEMBER_ID=LMS_BOOK_ISSUE.MEMBER_ID
INNER JOIN LMS_ALL_BOOKS ON LMS_ALL_BOOKS.BOOK_ID = LMS_BOOK_ISSUE.BOOK_ID 
INNER JOIN LMS_BOOK_DETAILS ON LMS_BOOK_DETAILS.BOOK_CODE = LMS_ALL_BOOKS.BOOK_CODE
WHERE LMS_MEMBER_DETAILS.MEMBER_ID=@MemberID AND LMS_BOOK_ISSUE.DATE_RETURN IS NULL" 
           ProviderName="<%$ ConnectionStrings:LIBRARY_MANAGEMENT_SYSTEMConnectionString2.ProviderName %>">
   
   <SelectParameters>
      <asp:SessionParameter Name="MemberID" DefaultValue="memberidSS"  SessionField="MemberIDSS" Type="Int32" />
   </SelectParameters>

</asp:SqlDataSource>

       <asp:GridView ID="gvBookHistory" runat="server" CellPadding="4" 
           EnableModelValidation="True" ForeColor="#333333" GridLines="None">
           <AlternatingRowStyle BackColor="White" />
           <EditRowStyle BackColor="#2461BF" />
           <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
           <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
           <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
           <RowStyle BackColor="#EFF3FB" />
           <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
       </asp:GridView>

     <table style="width:60%;">
           <tr>
               <td style="text-align: right">
                   <asp:Label ID="lblMemberID" runat="server" Text="Member ID" Visible="False" 
                       CssClass="LabelStyle"></asp:Label>
               </td>
               <td style="text-align: left; width: 62px">
                   &nbsp;</td>
               <td style="text-align: left">
                   <asp:Label ID="lblMemberIDValue" runat="server" Visible="False" 
                       CssClass="LabelStyle1"></asp:Label>
               </td>
           </tr>
           <tr>
               <td style="text-align: right">
                   <asp:Label ID="lblMemberName" runat="server" Text="Member Name" Visible="False" 
                       CssClass="LabelStyle"></asp:Label>
               </td>
               <td style="text-align: left; width: 62px">
                   &nbsp;</td>
               <td style="text-align: left">
                   <asp:Label ID="lblMemberNameValue" runat="server" Visible="False" 
                       CssClass="LabelStyle1"></asp:Label>
               </td>
           </tr>
           <tr>
               <td style="text-align: right">
                   <asp:Label ID="lblPhoneNumber" runat="server" Text="Phone Number" 
                       Visible="False" CssClass="LabelStyle"></asp:Label>
               </td>
               <td style="text-align: left; width: 62px">
                   &nbsp;</td>
               <td style="text-align: left">
                   <asp:Label ID="lblPhoneNumberValue" runat="server" Visible="False" 
                       CssClass="LabelStyle1"></asp:Label>
               </td>
           </tr>
           <tr>
               <td style="text-align: right">
                   <asp:Label ID="lblEmail" runat="server" Text="Email" Visible="False" 
                       CssClass="LabelStyle"></asp:Label>
               </td>
               <td style="text-align: left; width: 62px">
                   &nbsp;</td>
               <td style="text-align: left">
                   <asp:Label ID="lblEmailValue" runat="server" Visible="False" 
                       CssClass="LabelStyle1"></asp:Label>
               </td>
           </tr>
           <tr>
               <td style="text-align: right">
                   <asp:Label ID="lblSecurityQuestion" runat="server" Text="Security Question" 
                       Visible="False" CssClass="LabelStyle"></asp:Label>
               </td>
               <td style="text-align: left; width: 62px">
                   &nbsp;</td>
               <td style="text-align: left">
                   <asp:Label ID="lblSecurityQuestionValue" runat="server" Visible="False" 
                       CssClass="LabelStyle1"></asp:Label>
               </td>
           </tr>
           <tr>
               <td style="text-align: right" >
                   <asp:Label ID="lblAnswer" runat="server" Text="Answer" Visible="False" 
                       CssClass="LabelStyle"></asp:Label>
               </td>
               <td style="text-align: left; width: 62px">
                   &nbsp;</td>
               <td style="text-align: left">
                   <asp:Label ID="lblAnswerValue" runat="server" Visible="False" 
                       CssClass="LabelStyle1"></asp:Label>
               </td>
           </tr>
           <tr>
               <td style="text-align: right">
                   <asp:Label ID="lblIdProofType" runat="server" Text="ID Proof Type" 
                       Visible="False" CssClass="LabelStyle"></asp:Label>
               </td>
               <td style="text-align: left; width: 62px">
                   &nbsp;</td>
               <td style="text-align: left">
                   <asp:Label ID="lblIdProofTypeValue" runat="server" Visible="False" 
                       CssClass="LabelStyle1"></asp:Label>
               </td>
           </tr>
           <tr>
               <td style="text-align: right">
                   <asp:Label ID="lblIdProofNumber" runat="server" Text="ID Proof Number" 
                       Visible="False" CssClass="LabelStyle"></asp:Label>
               </td>
               <td style="text-align: left; width: 62px">
                   &nbsp;</td>
               <td style="text-align: left">
                   <asp:Label ID="lblIdProofNumberValue" runat="server" Visible="False" 
                       CssClass="LabelStyle1"></asp:Label>
               </td>
           </tr>
           <tr>
               <td style="text-align: right">
                   <asp:Label ID="lblDateRegister" runat="server" Text="Date Register" 
                       Visible="False" CssClass="LabelStyle"></asp:Label>
               </td>
               <td style="text-align: left; width: 62px">
                   &nbsp;</td>
               <td style="text-align: left">
                   <asp:Label ID="lblDateRegisterValue" runat="server" Visible="False" 
                       CssClass="LabelStyle1"></asp:Label>
               </td>
           </tr>
       </table>





      



        </center>
        </div>

</asp:Content>