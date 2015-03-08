<%@ Page Title="" Language="C#" MasterPageFile="~/RobinHood.master" AutoEventWireup="true" CodeBehind="ManageBooks.aspx.cs" Inherits="Library_Management_System.PL.ManageBooks" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
<div>
    <center>
                <asp:Button ID="btnAddBookDetails" runat="server" Text="Add New Book" 
                    CssClass="ButtonStyleAdminPage" onclick="btnAddBookDetails_Click"  />
                <asp:Button ID="btnAddBookCopies" runat="server" Text="Add Book Copies" 
                    CssClass="ButtonStyleAdminPage" onclick="btnAddBookCopies_Click" />
                <table style="width: 50%;">
            <tr>
                <td style="text-align: center" colspan="4">
                    <asp:Label ID="lblErrorMessage" runat="server" Font-Bold="True" 
                        Font-Names="Century Gothic" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    <asp:Label ID="lblCategory" runat="server" Text="Category" 
                        CssClass="LabelStyle" Visible="False"></asp:Label>
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    <asp:DropDownList ID="ddlCategory" runat="server" CssClass="styled-select" 
                        Visible="False" Width="167px" AutoPostBack="True" 
                        onselectedindexchanged="ddlCategory_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:TextBox ID="txtCategory" runat="server" CssClass="TextBoxStyle" 
                        Visible="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    <asp:Label ID="lblBookCode" runat="server" Text="Book Code" 
                        CssClass="LabelStyle" Visible="False"></asp:Label>
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    <asp:DropDownList ID="ddlBookCode" runat="server" CssClass="styled-select" 
                        Visible="False" Width="167px" AutoPostBack="True" 
                        onselectedindexchanged="ddlBookCode_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:TextBox ID="txtBookCode" runat="server" CssClass="TextBoxStyle" 
                        Visible="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    <asp:Label ID="lblBookTitle" runat="server" Text="Book Title" 
                        CssClass="LabelStyle" Visible="False"></asp:Label>
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    <asp:TextBox ID="txtBookTitle" runat="server" CssClass="TextBoxStyle" 
                        Visible="False"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: right">
                    <asp:Label ID="lblAuthor" runat="server" Text="Author" 
                        CssClass="LabelStyle" Visible="False"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:TextBox ID="txtAuthor" runat="server" CssClass="TextBoxStyle" 
                        Visible="False"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: right">
                    <asp:Label ID="lblSupplierName" runat="server" Text="Supplier Name" 
                        CssClass="LabelStyle" Visible="False"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:DropDownList ID="ddlSupplierName" runat="server" CssClass="styled-select" 
                        Visible="False" Width="167px" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: right">
                    <asp:Label ID="lblPublications" runat="server" Text="Publications" 
                        CssClass="LabelStyle" Visible="False"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:TextBox ID="txtPublications" runat="server" CssClass="TextBoxStyle" 
                        Visible="False"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: right">
                    <asp:Label ID="lblBookEdition" runat="server" Text="Book Edition" 
                        CssClass="LabelStyle" Visible="False"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:TextBox ID="txtBookEdition" runat="server" CssClass="TextBoxStyle" 
                        Visible="False"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            
            <tr>
                <td style="text-align: right">
                    <asp:Label ID="lblPrice" runat="server" Text="Price" 
                        CssClass="LabelStyle" Visible="False"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:TextBox ID="txtPrice" runat="server" CssClass="TextBoxStyle" 
                        Visible="False"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: right">
                    <asp:Label ID="lblQuantity" runat="server" Text="Quantity" CssClass="LabelStyle" 
                        Visible="False"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:TextBox ID="txtQuantity" runat="server" CssClass="TextBoxStyle" 
                        Visible="False"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            
            <tr>
                <td colspan="4" style="text-align: center">
                    <asp:Button ID="btnManageBookSubmit" runat="server" Text="Submit" 
                        Visible="False" CssClass="ButtonStyle" Height="30px" 
                         Width="111px" onclick="btnManageBookSubmit_Click"  />
                </td>
            </tr>
        </table>


    </center>
    </div>
</asp:Content>
