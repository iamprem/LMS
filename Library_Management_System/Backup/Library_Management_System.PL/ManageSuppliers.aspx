<%@ Page Title="" Language="C#" MasterPageFile="~/RobinHood.master" AutoEventWireup="true" CodeBehind="ManageSuppliers.aspx.cs" Inherits="Library_Management_System.PL.ManageSuppliers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
<div>
    <center>
                <asp:Button ID="btnAddSupplierDetails" runat="server" Text="Add Supplier" 
                    CssClass="ButtonStyleAdminPage" onclick="btnAddSupplierDetails_Click"  />
                <asp:Button ID="btnEditSupplierDetails" runat="server" Text="Edit Supplier" 
                    CssClass="ButtonStyleAdminPage" onclick="btnEditSupplierDetails_Click" />
                <br />
                <br />
                <br />
                <table style="width: 40%;">
                <tr>
                <td style="text-align: center" colspan="3">
                    <asp:Label ID="lblErrorMessage" runat="server" Font-Bold="True" 
                        Font-Names="Century Gothic" ForeColor="Red"></asp:Label>
                </td>
            </tr>
                <tr>
                <td style="text-align: right">
                    <asp:Label ID="lblSupplierId" runat="server" Text="Supplier ID" 
                        CssClass="LabelStyle" Visible="False"></asp:Label>
                </td>
                <td style="width: 50px">
                    &nbsp;
                </td>
                <td style="text-align: left">
                    <asp:TextBox ID="txtSupplierId" runat="server" CssClass="TextBoxStyle" 
                        Visible="False"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="revSupplierId" runat="server" 
                        ControlToValidate="txtSupplierId" ErrorMessage="*" 
                        ValidationExpression="^[0-9]{3}$" 
                        ValidationGroup="vgrpManageSupplierSubmintButton"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    <asp:Label ID="lblSupplierName" runat="server" Text="Supplier Name" 
                        CssClass="LabelStyle" Visible="False"></asp:Label>
                </td>
                <td style="width: 50px">
                    &nbsp;
                </td>
                <td style="text-align: left">
                    <asp:TextBox ID="txtSupplierName" runat="server" CssClass="TextBoxStyle" 
                        Visible="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    <asp:Label ID="lblSupplierEmail" runat="server" Text="Email" 
                        CssClass="LabelStyle" Visible="False"></asp:Label>
                </td>
                <td style="width: 50px">
                    &nbsp;
                </td>
                <td style="text-align: left">
                    <asp:TextBox ID="txtSupplierEmail" runat="server" CssClass="TextBoxStyle" 
                        Visible="False"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="revEmailId" runat="server" 
                        ControlToValidate="txtSupplierEmail" ErrorMessage="*" 
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                        ValidationGroup="vgrpManageSupplierSubmintButton"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    <asp:Label ID="lblPhoneNumber" runat="server" Text="Phone Number" 
                        CssClass="LabelStyle" Visible="False"></asp:Label>
                </td>
                <td style="width: 50px">
                    &nbsp;
                </td>
                <td style="text-align: left">
                    <asp:TextBox ID="txtPhoneNumber" runat="server" CssClass="TextBoxStyle" 
                        Visible="False"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="revPhoneNumber" runat="server" 
                        ControlToValidate="txtPhoneNumber" ErrorMessage="*" 
                        ValidationExpression="^[0-9]{10}$" 
                        ValidationGroup="vgrpManageSupplierSubmintButton"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td style="text-align: center" colspan="3">
                    <asp:Button ID="btnManageSupplierSubmit" runat="server" Text="Submit" 
                        Visible="False" CssClass="ButtonStyle" Height="30px" 
                         Width="111px" onclick="btnManageSupplierSubmit_Click" 
                        ValidationGroup="vgrpManageSupplierSubmintButton" />
                </td>
            </tr>
            </table>
    </center>
    </div> 
</asp:Content>
