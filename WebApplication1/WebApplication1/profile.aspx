<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="WebApplication1.profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <%if (Session["user"] != null)
    {

        if ((((List<string>)Session["user"])[1].ToString()) == "A")
        { %>
  <section class="header_text">
				<table>
                    <tr>
                        <td>
                            NAME:
                        </td>
                        <td>
                            <asp:TextBox ID="name"  runat="server" placeholder="Enter your name"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="name" Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ValidationGroup="admin_profile_validation">Name Should not Blank</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Email:
                        </td>
                        <td>
                            <asp:TextBox ID="email" placeholder="Enter your email" TextMode="Email" runat="server" Text="Deepanshu"></asp:TextBox>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="email" ForeColor="Red" Display="Dynamic" SetFocusOnError="True" ValidationGroup="admin_profile_validation">Email Should not Blank</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                        <tr>
                        <td>
                            Address:
                        </td>
                        <td>
                            <asp:TextBox ID="address" placeholder="Enter your address" runat="server" Text="Deepanshu"></asp:TextBox>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="address" ForeColor="Red" SetFocusOnError="True" ValidationGroup="admin_profile_validation">Address should not blank</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                       <tr>
                        <td>
                            Phone:
                        </td>
                        <td>
                            <asp:TextBox ID="phone"  MaxLength="10"  TextMode="Number" runat="server" placeholder="Enter your phone"></asp:TextBox>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="phone" ForeColor="Red" SetFocusOnError="True" ValidationGroup="admin_profile_validation">Phone number should  not blank</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator Display = "Dynamic"  ControlToValidate = "phone" ID="RegularExpressionValidator3" ValidationExpression = "^[\s\S]{10,10}$" runat="server" ValidationGroup="admin_profile_validation"  ForeColor="Red" SetFocusOnError="True" ErrorMessage="10 digit  number required."></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                      <tr>
                        <td>
                            username:
                        </td>
                        <td>
                            <asp:TextBox ID="username" placeholder="Enter your username"  runat="server" Text="username"></asp:TextBox>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="username" ForeColor="Red" SetFocusOnError="True" ValidationGroup="admin_profile_validation">Username should not blank</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="update" CssClass="btn btn-danger" Text="Update" runat="server" OnClick="update_Click" ValidationGroup="admin_profile_validation"></asp:Button>
                        </td>
                    </tr>
				</table>
			</section>

    <%}
    else
    { %><section class="header_text">
				We stand for top quality templates. Our genuine developers always optimized bootstrap commercial templates. 
				<br/>Don't miss to use our cheap abd best bootstrap templates.
			</section>

        <%}
    }%>
</asp:Content>
