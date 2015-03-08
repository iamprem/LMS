<%@ Page Title="" Language="C#" MasterPageFile="~/RobinHood.master" AutoEventWireup="true" CodeBehind="BookTransaction.aspx.cs" Inherits="Library_Management_System.PL.BookTransaction" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div>
    <center>
                    <asp:Button ID="btnBookIssue" runat="server" Text="Book Issue" 
                    CssClass="ButtonStyleAdminPage" onclick="btnBookIssue_Click" />
                
                <asp:Button ID="btnBookReturn" runat="server" Text="Book Return" 
                    CssClass="ButtonStyleAdminPage" onclick="btnBookReturn_Click" />
    <br />
    <br />
    <br />

    <table style="width: 50%; height:250px">
            <tr>
                <td colspan="3">
                    <asp:Label ID="lblErrorMessage" runat="server" Font-Bold="True" 
                        Font-Names="Century Gothic" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    <asp:Label ID="lblMemberId" runat="server" Text="Member ID" 
                        CssClass="LabelStyle" Visible="False"></asp:Label>
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    <asp:TextBox ID="txtMemberId" runat="server" Visible="False" 
                        CssClass="TextBoxStyle"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    <asp:Label ID="lblBookId" runat="server" Text="Book ID" CssClass="LabelStyle" 
                        Visible="False"></asp:Label>
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    <asp:TextBox ID="txtBookId" runat="server" Visible="False" 
                        CssClass="TextBoxStyle"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Button ID="btnBookTransactionSubmit" runat="server" Text="Submit" 
                        Visible="False" CssClass="ButtonStyle" Height="30px" 
                        onclick="btnBookTransactionSubmit_Click" Width="111px" />
                </td>
            </tr>
            
            </table>

                    <br />

    </center>

        

    </div>        
</asp:Content>
