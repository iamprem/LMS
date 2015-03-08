<%@ Page Title="" Language="C#" MasterPageFile="~/Batman.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Library_Management_System.PL.Default"  %>
<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder2">
    <center style="height: 700px">
    <br />
    <br />
    <br />
    <br />
    <h2>
        Admin/Member Login</h2>
    <br />
    <br />
   
    <table style="width:35%; height: 250px;" >
        <tr>
            <td style="text-align: right">
    <asp:Label ID="lblMemberId" CssClass="LabelStyle" runat="server" Text="Member ID"></asp:Label>

            </td>
            <td style="text-align: right">

    <asp:TextBox ID="txtMemberId" runat="server" Height="30px" Width="150px" 
                    CssClass="TextBoxStyle"></asp:TextBox>

            </td>
            <td style="text-align: center">

                <asp:RequiredFieldValidator ID="rfvMemberId" runat="server" 
                    ControlToValidate="txtMemberId" ErrorMessage="*"></asp:RequiredFieldValidator>

            </td>
        </tr>
        <tr>
            <td style="text-align: right">
    <asp:Label ID="lblPassword" CssClass="LabelStyle" runat="server" Text="Password"></asp:Label>

            </td>
            <td style="text-align: right">

    <asp:TextBox ID="txtPassword" runat="server" Height="30px" Width="150px" 
                    CssClass="TextBoxStyle" TextMode="Password"></asp:TextBox>
            
            </td>
            <td>

                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:RegularExpressionValidator ID="revMemberId" style="font-family:Century Gothic; font-weight:bold; color:Red;"
                     runat="server" 
                    ControlToValidate="txtMemberId" ErrorMessage="Wrong Member ID!!!" 
                    ValidationExpression="^[0-9]{6}$"></asp:RegularExpressionValidator>
                <br />
                <asp:Label ID="lblErrorMessage" style="font-family:Century Gothic; font-weight:bold; color:Red;" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnSignIn" runat="server" Text="Sign In"  
                    CssClass="ButtonStyle" Height="40px" Width="100px" 
                    onclick="btnSignIn_Click"/>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                <a style="font-family: Century Gothic; 
                font-size: 16px; 
                font-weight: bold; 
                color: #333333;" href="ResetPassword.aspx">Forgot your Password?</a></td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <br />

    <br />
    <br />
    <br />
    <br />
    

</center>

</asp:Content>


