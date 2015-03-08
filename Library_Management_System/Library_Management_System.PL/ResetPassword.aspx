<%@ Page Title="" Language="C#" MasterPageFile="~/Batman.Master" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="Library_Management_System.PL.ResetPassword" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div align="center">
    <br />
    <br/>
    <br/>
    
        <table class="style1"; >
            <tr>
                <td colspan="3" style="height: 30px">
                    <asp:Label ID="lblSuccess" runat="server" 
                        Text="New Password Updated Successfully" Visible="False" 
                        CssClass="LabelStyle" ForeColor="#009900"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: right;height:50px">
    <asp:Label ID="lblMemberId" CssClass="LabelStyle" runat="server" Text="Member ID"></asp:Label>

                </td>
                <td style="width: 10px">
                    &nbsp;</td>
                <td style="height:50px; width: 136px;">

    <asp:TextBox ID="txtMemberId" runat="server" Height="30px" Width="150px" 
                    CssClass="TextBoxStyle"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td style="text-align: right;height:50px">
                    <asp:Label ID="lblSecurityQuestion" runat="server" Text="Security question" 
                        style="font-weight: 700" CssClass="LabelStyle" Visible="False"></asp:Label>
                </td>
                <td style="width: 10px">
                    &nbsp;</td>
                <td style="height:50px; width: 136px;">
                    <asp:TextBox ID="txtSecurityQuestion" runat="server" CssClass="TextBoxStyle" 
                        Enabled="False" Visible="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: right;height:50px">
                    <asp:Label ID="lblAnswer" runat="server" Text="Answer" style="font-weight: 700" 
                        CssClass="LabelStyle" Visible="False"></asp:Label>
                </td>
                <td style="width: 10px">
                    &nbsp;</td>
                <td style="text-align: left;height:50px; width: 136px;">
                    <asp:TextBox ID="txtAnswer" runat="server" style="text-align: left" 
                        CssClass="TextBoxStyle" Visible="False"></asp:TextBox>
                    <asp:Label ID="lblAnswerMisMatch" runat="server" Text="Answer Mismatch" 
                        Visible="False" Font-Bold="True" ForeColor="#FF3300"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="height: 30px; text-align: right">
                    <asp:Label ID="lblNewPassword" runat="server" style="font-weight: 700" 
                        Text="New Password" Visible="False" CssClass="LabelStyle"></asp:Label>
                </td>
                <td style="height: 30px; width: 10px">
                </td>
                <td style="height: 30px; text-align: left">
                    <asp:TextBox ID="txtNewPassword" runat="server" Visible="False" 
                        CssClass="TextBoxStyle" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="height: 30px; text-align: right">
                    <asp:Label ID="lblConfirmPassword" runat="server" style="font-weight: 700" 
                        Text="Confirm Password" Visible="False" CssClass="LabelStyle"></asp:Label>
                </td>
                <td style="height: 30px; width: 10px">
                    &nbsp;</td>
                <td style="height: 30px; text-align: left">
                    <asp:TextBox ID="txtConfirmPassword" runat="server" Visible="False" 
                        CssClass="TextBoxStyle" TextMode="Password"></asp:TextBox>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" 
                        ControlToCompare="txtNewPassword" ControlToValidate="txtConfirmPassword" 
                        ErrorMessage="*"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="height: 30px">
                    <asp:Button ID="btnResetPwd" runat="server" onclick="btnResetPwd_Click" 
                        Text="Submit" CssClass="ButtonStyle" />
                </td>
            </tr>
        </table>
    
    </div>
</asp:Content>
