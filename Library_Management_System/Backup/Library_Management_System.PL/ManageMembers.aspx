<%@ Page Title="" Language="C#" MasterPageFile="~/RobinHood.master" AutoEventWireup="true" CodeBehind="ManageMembers.aspx.cs" Inherits="Library_Management_System.PL.ManageMembers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div>
    <center>
                <asp:Button ID="btnAddMemberDetails" runat="server" Text="Add Member" 
                    CssClass="ButtonStyleAdminPage" onclick="btnAddMemberDetails_Click"  />
                <asp:Button ID="btnEditMemberDetails" runat="server" Text="Edit Member" 
                    CssClass="ButtonStyleAdminPage" onclick="btnEditMemberDetails_Click" />
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
                    <asp:Label ID="lblMemberId" runat="server" Text="Member ID" 
                        CssClass="LabelStyle" Visible="False"></asp:Label>
                </td>
                <td style="width: 28px">
                    &nbsp;
                </td>
                <td style="text-align: left">
                    <asp:TextBox ID="txtMemberId" runat="server" CssClass="TextBoxStyle" 
                        Visible="False"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="revMemberId" runat="server" 
                        ControlToValidate="txtMemberId" ErrorMessage="*" 
                        ValidationExpression="^[0-9]{6}$" 
                        ValidationGroup="vgrpManageMemberSubmitButton"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    <asp:Label ID="lblMemberName" runat="server" Text="Member Name" 
                        CssClass="LabelStyle" Visible="False"></asp:Label>
                </td>
                <td style="width: 28px">
                    &nbsp;
                </td>
                <td style="text-align: left">
                    <asp:TextBox ID="txtMemberName" runat="server" CssClass="TextBoxStyle" 
                        Visible="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    <asp:Label ID="lblPhoneNumber" runat="server" Text="Phone Number" 
                        CssClass="LabelStyle" Visible="False"></asp:Label>
                </td>
                <td style="width: 28px">
                    &nbsp;
                </td>
                <td style="text-align: left">
                    <asp:TextBox ID="txtPhoneNumber" runat="server" CssClass="TextBoxStyle" 
                        Visible="False"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="revPhoneNumber" runat="server" 
                        ControlToValidate="txtPhoneNumber" ErrorMessage="*" 
                        ValidationExpression="^[0-9]{10}$" 
                        ValidationGroup="vgrpManageMemberSubmitButton"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    <asp:Label ID="lblMemberEmail" runat="server" Text="Email" 
                        CssClass="LabelStyle" Visible="False"></asp:Label>
                </td>
                <td style="width: 28px">
                    &nbsp;</td>
                <td style="text-align: left">
                    <asp:TextBox ID="txtMemberEmail" runat="server" CssClass="TextBoxStyle" 
                        Visible="False"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="revEmailId" runat="server" 
                        ControlToValidate="txtMemberEmail" ErrorMessage="*" 
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                        ValidationGroup="vgrpManageMemberSubmitButton"></asp:RegularExpressionValidator>
                </td>
            </tr>
            
            
            <tr>
                <td style="text-align: right">
                    <asp:Label ID="lblSecurityQuestion" runat="server" Text="Security Question" 
                        CssClass="LabelStyle" Visible="False"></asp:Label>
                </td>
                <td style="width: 28px">
                    &nbsp;</td>
                <td style="text-align: left">

                    <asp:DropDownList ID="ddlSecurityQuestion" runat="server" CssClass="styled-select" 
                        Visible="False" AutoPostBack="True" 
                        onselectedindexchanged="ddlSecurityQuestion_SelectedIndexChanged">
                        <asp:ListItem Selected="True">Select a security Question</asp:ListItem>
                        <asp:ListItem Value="what is your favourite movie?">What is your favourite movie?</asp:ListItem>
                        <asp:ListItem Value="who is favourite hero?">Who is favourite hero?</asp:ListItem>
                        <asp:ListItem Value="which school did you study in tenth?">Which school did you study in tenth?</asp:ListItem>
                        <asp:ListItem Value="what is your favourite food?">What is your favourite food?</asp:ListItem>
                        <asp:ListItem Value="what is your nickname?">What is your nickname?</asp:ListItem>
                        <asp:ListItem Value="who is your best friend?">Who is your best friend?</asp:ListItem>
                        <asp:ListItem Value="what is your first electronics gadget?">What is your first electronics gadget?</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    <asp:Label ID="lblAnswer" runat="server" Text="Answer" CssClass="LabelStyle" 
                        Visible="False"></asp:Label>
                </td>
                <td style="width: 28px">
                    &nbsp;</td>
                <td style="text-align: left">
                    <asp:TextBox ID="txtAnswer" runat="server" CssClass="TextBoxStyle" 
                        Visible="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    <asp:Label ID="lblIdProofType" runat="server" Text="ID Proof Type" 
                        CssClass="LabelStyle" Visible="False"></asp:Label>
                </td>
                <td style="width: 28px">
                    &nbsp;</td>
                <td style="text-align: left">
                    <asp:DropDownList ID="ddlIdProofType"  runat="server" 
                        Visible="False" CssClass="styled-select" AutoPostBack="True" 
                        onselectedindexchanged="ddlIdProofType_SelectedIndexChanged">
                        <asp:ListItem Selected="True">Select an ID type</asp:ListItem>
                        <asp:ListItem Value="driving license">Driving License</asp:ListItem>
                        <asp:ListItem Value="pan card">Pan Card</asp:ListItem>
                        <asp:ListItem Value="passport number">Passport Number</asp:ListItem>
                        <asp:ListItem Value="voter id">Voter ID</asp:ListItem>
                        <asp:ListItem Value="adhar no">Adhar No</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    <asp:Label ID="lblIdProofValue" runat="server" Text="ID Proof Value" 
                        CssClass="LabelStyle" Visible="False"></asp:Label>
                </td>
                <td style="width: 28px">
                    &nbsp;</td>
                <td style="text-align: left">
                    <asp:TextBox ID="txtIdProofValue" runat="server" CssClass="TextBoxStyle" 
                        Visible="False"></asp:TextBox>
                </td>
               </tr>             
            <tr>
                <td style="text-align: right">
                    <asp:Label ID="lblPassword" runat="server" Text="Password" 
                        CssClass="LabelStyle" Visible="False"></asp:Label>
                </td>
                <td style="width: 28px">
                    &nbsp;</td>
                <td style="text-align: left">
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="TextBoxStyle" 
                        Visible="False" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    <asp:Label ID="lblRepeatPassword" runat="server" Text="Repeat Password" 
                        CssClass="LabelStyle" Visible="False"></asp:Label>
                </td>
                <td style="width: 28px">
                    &nbsp;</td>
                <td style="text-align: left">
                    <asp:TextBox ID="txtRepeatPassword" runat="server" CssClass="TextBoxStyle" 
                        Visible="False" TextMode="Password"></asp:TextBox>
                    <asp:CompareValidator ID="cvRepeatPassword" runat="server" 
                        ControlToCompare="txtPassword" ControlToValidate="txtRepeatPassword" 
                        ErrorMessage="*" ValidationGroup="vgrpManageMemberSubmitButton"></asp:CompareValidator>
                </td>
            </tr>
            
            <tr>
                <td colspan="3" style="text-align: center">
                    <asp:Button ID="btnManageMemberSubmit" runat="server" Text="Submit" 
                        Visible="False" CssClass="ButtonStyle" Height="30px" 
                         Width="111px" onclick="btnManageMemberSubmit_Click" 
                        ValidationGroup="vgrpManageMemberSubmitButton" />
                </td>
            </tr>
        </table>
    </center>
    </div> 
</asp:Content>
