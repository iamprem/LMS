<%@ Page Title="" Language="C#" MasterPageFile="~/Batman.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="Library_Management_System.PL.Search" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <center style="height: 700px">
    <br />
   
    <h2>Book Search</h2>
        <asp:Label ID="lblBookSearchStatus" runat="server" CssClass="LabelStyle1"></asp:Label>
    <br />
    <br />
    <asp:GridView ID="gvBookSearchResult" runat="server" BackColor="#CCCCCC" 
            BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" 
            CellSpacing="2" EnableModelValidation="True" ForeColor="Black">
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
            <RowStyle BackColor="White" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        </asp:GridView>

    <table style="width:40%;height: 185px;">
        <tr>
            <td style="text-align: right;">
    <asp:Label ID="lblBookTitle" runat="server" CssClass="LabelStyle" Text="Book Title"></asp:Label>
            </td>
            <td style="text-align: center;">
    <asp:TextBox ID="txtBookTitle" runat="server" CssClass="TextBoxStyle"
                Height= "30px" Width="250px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: right" >
    <asp:Label ID="lblAuthor" runat="server" CssClass="LabelStyle" Text="Author"></asp:Label>  
            </td>
            <td>
    <asp:TextBox ID="txtAuthor" runat="server" CssClass="TextBoxStyle"
                Height="30px" Width="250px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="height: 30px; text-align: center;">
    <asp:Button ID="btnSearch" runat="server" CssClass="ButtonStyle" Height="40px" 
                    Width="100px" Text="Search" onclick="btnSearch_Click" />
        </td>
        </tr>
    </table>
        
    <br />
    <br />
    <br />
</center>

</asp:Content>

