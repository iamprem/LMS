<%@ Page Title="" Language="C#" MasterPageFile="~/Batman.Master" AutoEventWireup="true" CodeBehind="AdminMain.aspx.cs" Inherits="Library_Management_System.PL.AdminMain" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
<div>
  <br />
  <br />
  <br />
  <br />
<center><h2><asp:Label ID="lblWelcomeAdmin" runat="server" Text="Hey Admin" ></asp:Label></h2></center>
  <br />
  <br />
 

  <div align="center" style="height: 36px">

        


    <asp:Button ID="btnBookTransaction" runat="server" 
         style="color: #66CCFF; background-color: #000000; font-weight: bold;"
        Text="Book Transaction" Height="35px" Width="250px"  
            CssClass="ButtonStyle" onclick="btnBookTransaction_Click"/>
    <asp:Button ID="btnManageMembers" runat="server" 
        style="color: #66CCFF; background-color: #000000; font-weight: bold;" Text="Manage Members" 
        Height="35px" Width="250px" CssClass="ButtonStyle" onclick="btnManageMembers_Click" 
            />
    <asp:Button ID="btnManageSuppliers" runat="server" 
        style="color: #66CCFF; background-color: #000000; font-weight: bold;" Text="Manage Suppliers" 
        Height="35px" Width="250px" CssClass="ButtonStyle" 
          onclick="btnManageSuppliers_Click"/>
    <asp:Button ID="btnManageBooks" runat="server" 
        style="color: #66CCFF; background-color: #000000; font-weight: bold;" Text="Manage Books" 
        Height="35px" Width="250px" CssClass="ButtonStyle" 
          onclick="btnManageBooks_Click"/>
    <asp:Button ID="btnSignOut" runat="server"
        style="color: #66CCFF; background-color: #000000; font-weight: bold;" Text="Sign Out" 
        Height="35px" Width="250px" CssClass="ButtonStyle" 
          onclick="btnSignOut_Click" />
        </div>
  <br />
  <br />
  <br />
  <br />
  <center>
    <table style="width: 50%; height:250px">
        <tr>
            <td>
                <asp:Button ID="btn1" runat="server" Text="Button1" 
                    CssClass="ButtonStyleAdminPage" onclick="btn1_Click" />
                
            </td>
        </tr>
        <tr>
            <td>
                
                <asp:Button ID="btn2" runat="server" Text="Button2" 
                    CssClass="ButtonStyleAdminPage" onclick="btn2_Click" />
            </td>
        </tr>
        <tr>
            <td>
                
                <asp:Button ID="btn3" runat="server" Text="Button3" 
                    CssClass="ButtonStyleAdminPage" onclick="btn3_Click" />
            </td>
        </tr>
    </table>
    </center>
</div>
</asp:Content>
