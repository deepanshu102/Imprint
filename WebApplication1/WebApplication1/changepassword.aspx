<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="changepassword.aspx.cs" Inherits="WebApplication1.changepassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <%if (Session["user"] != null)
            { %>	

             <section class="header_text">
				<table>
                    <tr>
                        <td>
                            Password:
                        </td>
                        <td>
                            <asp:TextBox ID="oldpass" textmode="Password" runat="server" placeholder="Enter your old password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="oldpass" Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ValidationGroup="changepass_validator">Old password Should not Blank</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                      <tr>
                        <td>
                             New Password:
                        </td>
                        <td>
                            <asp:TextBox ID="newpass" textmode="Password" runat="server" placeholder="Enter your new password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="newpass" Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ValidationGroup="changepass_validator">New Password Should not Blank</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                      <tr>
                        <td>
                            Re-Password:
                        </td>
                        <td>
                            <asp:TextBox ID="repass" textmode="Password" runat="server" placeholder="Enter your Re-password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="repass" Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ValidationGroup="changepass_validator">Re-password Should not Blank</asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="CompareValidator" SetFocusOnError="True" Display="Dynamic" ControlToCompare="newpass" ControlToValidate="repass" ForeColor="Red" ValidationGroup="changepass_validator">Password Mismatch</asp:CompareValidator>
                        </td>
                    </tr>
                 <tr>
                     <td colspan="2">
                         <asp:Button ValidationGroup="changepass_validator" runat="server" ID="Update" Text="Update" CssClass="btn-danger" OnClick="Update_Click" ></asp:Button>

                     </td>
                 </tr>
				</table>
			</section>
    <%}%>
</asp:Content>
