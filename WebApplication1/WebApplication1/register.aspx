<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="WebApplication1.register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
<div id="wrapper" class="container">
				
			<section class="header_text sub">
			<img class="pageBanner" src="themes/images/pageBanner.png" alt="New products" >
				<h4><span>Login or Regsiter</span></h4>
			</section>			
			<section class="main-content">				
				<div class="row">
					<div class="span5">					
						<h4 class="title"><span class="text"><strong>Login</strong> Form</span></h4>
                       
							
							<fieldset>
								<div class="control-group">
									<label class="control-label">Username</label>
									<div class="controls">
                                        <asp:TextBox ID="username" class="input-xlarge"  placeholder="Enter your username" runat="server"></asp:TextBox>
                                        <br /><asp:RequiredFieldValidator ID="username_validator" runat="server" ErrorMessage="Username Required Validator" BorderColor="Red" ControlToValidate="username" Display="Dynamic" SetFocusOnError="True" ValidationGroup="login_validation">Username should not blank</asp:RequiredFieldValidator>
									</div>
								</div>
								<div class="control-group">
									Password
									<div class="controls">
                                         <asp:TextBox ID="password" class="input-xlarge" TextMode="Password" placeholder="Enter your password" runat="server"></asp:TextBox>
                                         <br /><asp:RequiredFieldValidator ID="Password_validation" runat="server" ErrorMessage="password required validator" BorderColor="Red" ControlToValidate="password" Display="Dynamic" SetFocusOnError="True" ValidationGroup="login_validation">password should not blank</asp:RequiredFieldValidator>
									</div>
                                   
								</div>
								<div class="control-group">
                                    <asp:Button tabindex="3" class="btn btn-inverse large" ID="Button1" runat="server" Text="Sign into your account" OnClick="Button1_Click" ValidateRequestMode="Enabled" ValidationGroup="login_validation" />
									
									<hr>
                                    	
									<p class="reset">Recover your <a tabindex="4" href="#" title="Recover your username or password">username or password</a></p>
								</div>
							</fieldset>
										
					</div>
							   <div class="span7" >					
						<h4 class="title"><span class="text"><strong>Register</strong> Form</span></h4>
						<div class="form-stacked">
							<fieldset>
								
                                    
                                   <table>
                                       <tr><td>
                                             <div class="control-group">
									<label class="control-label">Name</label>
									<div class="controls">
                                        <asp:TextBox ID="name"  MaxLength="20" placeholder="Enter your name" class="input-xlarge" runat="server"></asp:TextBox><br />
                                        <asp:RequiredFieldValidator ID="req_name" runat="server" ErrorMessage="Name should not be Empty" ControlToValidate="name" Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ValidationGroup="registration" Visible="true">Name should not be Empty</asp:RequiredFieldValidator>
						
									</div>
                                	</div></td>
                                           <td>
                                               <div class="control-group">
									<label class="control-label">Email address:</label>
									<div class="controls">
                                        <asp:TextBox ID="email" TextMode="Email" placeholder="Enter your email" CssClass="input-xlarge" runat="server"></asp:TextBox><br />
										  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Email should not be Empty" ControlToValidate="email" Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ValidationGroup="registration" Visible="true">Email should not be Empty</asp:RequiredFieldValidator>
						
									</div>
								</div>
                                           </td>
                                       </tr>
                                       <tr>
                                           <td>
                                                  <div class="control-group">
									<label class="control-label">USERNAME:</label>
									<div class="controls">
                                        <asp:TextBox ID="r_username"  OnTextChanged="r_username_TextChanged" MaxLength="10" placeholder="Enter your username" class="input-xlarge" runat="server" AutoPostBack="True"></asp:TextBox><br />
								  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Username should not be Empty" ControlToValidate="r_username" Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ValidationGroup="registration" Visible="true">Username should not be Empty</asp:RequiredFieldValidator>
						            <asp:Label ID="label1" runat="server"></asp:Label>
									</div>
								</div>	
                                           </td>
                                           <td><div class="control-group">
									<label class="control-label">Password:</label>
									<div class="controls">
                                        <asp:TextBox ID="r_password" runat="server" TextMode="Password" placeholder="Enter your password" CssClass="input-xlarge"></asp:TextBox><br />
								  <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Password should not be Empty" ControlToValidate="r_password" Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ValidationGroup="registration" Visible="true">Password should not be Empty</asp:RequiredFieldValidator>
						
									</div>
								</div>	</td>
                                       </tr>
                                       <tr>
                                           <td><center>  <div>
									<label>Address:</label>
									<div>
                                        <asp:TextBox ID="address" placeholder="Enter your address" CssClass="input-xlarge" runat="server"></asp:TextBox><br />
										  <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="address should not be Empty" ControlToValidate="address" Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ValidationGroup="registration" Visible="true">Address should not be Empty</asp:RequiredFieldValidator>
						
									</div>
								</div></center>	</td>
                                             <td><center>  <div>
									<label>Phone:</label>
									<div>
                                        <asp:TextBox ID="phone"  placeholder="Enter your Phone" TextMode="Number" CssClass="input-xlarge" runat="server"></asp:TextBox><br />
										  <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Phone should not be Empty" ControlToValidate="phone" Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ValidationGroup="registration" Visible="true">Phone should not be Empty</asp:RequiredFieldValidator>
						
									</div>
								</div></center>	</td>
                                       </tr>
                                       <tr>
                                           <td colspan="2">
                                               <asp:Button ID="register1" OnClick="register1_Click" CssClass="btn-primary" Width="100%" Height="100%" runat="server" Text="Register" ValidationGroup="registration"  />
                                         
                                           </td>
                                       </tr>
                                   </table>                        				                            
								
							</fieldset>
						</div>					
					</div>		
				</div>
			</section>			
		
			

        </div>
 
 
</asp:Content>
