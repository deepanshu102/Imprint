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
                                    	<p class="reset"><button tabindex="4" id="register_button" onclick="button();" title="Register">Register Yourself</button></p>
									<p class="reset">Recover your <a tabindex="4" href="#" title="Recover your username or password">username or password</a></p>
								</div>
							</fieldset>
										
					</div>
					<div class=" modal" id="myModal" >					
						<h4 class="title"><span class="text"><strong>Register</strong> Form</span></h4>
						<div class="form-stacked">
							<fieldset>
								<div class="control-group">
									<label class="control-label">Username</label>
									<div class="controls">
										<input type="text" placeholder="Enter your username" class="input-xlarge">
									</div>
								</div>
								<div class="control-group">
									<label class="control-label">Email address:</label>
									<div class="controls">
										<input type="password" placeholder="Enter your email" class="input-xlarge">
									</div>
								</div>
								<div class="control-group">
									<label class="control-label">Password:</label>
									<div class="controls">
										<input type="password" placeholder="Enter your password" class="input-xlarge">
									</div>
								</div>							                            
								<div class="control-group">
									<p>Now that we know who you are. I'm not a mistake! In a comic, you know how you can tell who the arch-villain's going to be?</p>
								</div>
								<hr>
								<div class="actions"><input tabindex="9" class="btn btn-inverse large" type="submit" value="Create your account"></div>
							</fieldset>
						</div>					
					</div>				
				</div>
			</section>			
		
			

        </div>
    <script>
        var modal = document.getElementById("myModal");

// Get the button that opens the modal
        var btn = document.getElementById("register_button");

// Get the <span> element that closes the modal
var span = document.getElementsByClassName("close")[0];

// When the user clicks the button, open the modal 
btn.onclick = function() {
  modal.style.display = "block";
}

// When the user clicks on <span> (x), close the modal
span.onclick = function() {
  modal.style.display = "none";
}

// When the user clicks anywhere outside of the modal, close it
window.onclick = function(event) {
  if (event.target == modal) {
    modal.style.display = "none";
  }
}
</script>
</asp:Content>
