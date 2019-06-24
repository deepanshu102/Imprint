<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="cart.aspx.cs" Inherits="WebApplication1.cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

	<section class="header_text sub">
			<img class="pageBanner" src="themes/images/pageBanner.png" alt="New products" >
				<h4><span>Shopping Cart</span></h4>
			</section>
			<section class="main-content">				
				<div class="row">
					<div class="span9">					
						<h4 class="title"><span class="text"><strong>Your</strong> Cart</span></h4>
                   <asp:GridView ID="GridView1" runat="server"  AutoGenerateColumns="False" 
        DataKeyNames="cartid"   PageSize="10"  AllowPaging="true" OnPageIndexChanging="GridView1_PageIndexChanging" onRowDeleting ="GridView1_RowDeleting" onRowEditing="GridView1_RowEditing" onRowUpdating ="GridView1_RowUpdating">
<PagerStyle BackColor="white" ForeColor="#17202A" HorizontalAlign="Center"/>
<Columns>
   <asp:TemplateField HeaderText="Product ID" Insertvisible="false" SortExpression="pid">
       <ItemTemplate>
           <asp:Label ID="Label1" runat="server"  Text='<%#Bind("pid") %>'></asp:Label>
       </ItemTemplate>
   </asp:TemplateField>
    <asp:TemplateField HeaderText="Product Name"  SortExpression="pname">
        <ItemTemplate>
            <asp:Label ID="Label2" runat="server" Text='<%#Eval("pname") %>'  ></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Quantity">
         <ItemTemplate>
            <asp:Label ID="quant" runat="server" Text='<%#Eval("quantity") %>'></asp:Label>
        </ItemTemplate>
        <EditItemTemplate>

            <asp:TextBox ID="ed_quant" TextMode="Number" runat="server" Text='<%#Bind("quantity") %>'></asp:TextBox>
        </EditItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Price" SortExpression="pprice">
        <ItemTemplate>
            <asp:Label ID="Label3" runat="server" Text='<%#Bind("price") %>'></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Image" >
        <ItemTemplate>
            <asp:Image ID="arrow1" runat="server" ImageUrl='<%#Bind("pimage") %>' Width="100" Height="100" />
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Item Total price">
        <ItemTemplate>
            <asp:Label ID="Label4" runat="server" Text='<%#Bind("bill") %>'></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
    
    <asp:TemplateField HeaderText="Item Total price">
        <ItemTemplate>
            <asp:Button ID="Button1" runat="server" CommandName="Delete" Text="Delete" />
            <asp:Button ID="Button2" runat="server" Text="Edit"  CommandName="Edit"/>
        </ItemTemplate>
        <EditItemTemplate>
            <asp:Button ID="Button3" CommandArgument="" CommandName="Update" runat="server" Text="update" />
        </EditItemTemplate>
    </asp:TemplateField>
</Columns>
    </asp:GridView>
                        

					
						<h4>What would you like to do next?</h4>
						<p>Choose if you have a discount code or reward points you want to use or would like to estimate your delivery cost.</p>
						<label class="radio">
							<input type="radio" name="optionsRadios" id="optionsRadios1" value="option1" checked="">
							Use Coupon Code
						</label>
						&nbsp;<label class="radio"><input type="radio" name="optionsRadios" id="optionsRadios2" value="option2">
							Estimate Shipping &amp; Taxes
						</label>
						&nbsp;<hr>
						<p class="cart-total right">
							<strong>Sub-Total</strong>:	$100.00<br>
							<strong>Eco Tax (-2.00)</strong>: $2.00<br>
							<strong>VAT (17.5%)</strong>: $17.50<br>
							<strong>Total</strong>: $119.50<br>
						</p>
						<hr/>
						<p class="buttons center">				
							<button class="btn" type="button">Update</button>
							<button class="btn" type="button">Continue</button>
							<button class="btn btn-inverse" type="submit" id="checkout">Checkout</button>
						</p>					
					</div>
					
			</section>			

    

</asp:Content>
