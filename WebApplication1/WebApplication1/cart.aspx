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
        DataKeyNames="cartid"   PageSize="10"  AllowPaging="true" OnRowUpdating="GridView1_RowUpdating" OnRowDeleting="GridView1_RowDeleting"
                 OnRowCommand="GridView1_RowCommand"     
OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDeleted="GridView1_RowDeleted" OnRowEditing="GridView1_RowEditing" OnRowUpdated="GridView1_RowUpdated" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
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
                        <asp:TextBox ID="ed_quant" width="60px"  TextMode="Number" runat="server" Text='<%#Bind("quantity") %>'></asp:TextBox>
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
                         <asp:CommandField ButtonType="Link" ControlStyle-CssClass="btn btn-primary" ShowEditButton="true" />
                                          
                            <asp:CommandField ButtonType="Link"  ControlStyle-CssClass="btn btn-danger" ShowDeleteButton="true" />
                   
</Columns>
    </asp:GridView>
                        

					
						<p class="cart-total right">
							<strong>Sub-Total</strong>:	$100.00<br>
							<strong>Eco Tax (-2.00)</strong>: $2.00<br>
							<strong>VAT (17.5%)</strong>: $150<br>
							<strong>Total</strong><asp:Label ID="lbl_totalCost" Text="" runat="server"></asp:Label><br>
						</p>
						<hr/>
						<p class="buttons center">				
							<button class="btn" type="button">Update</button>
							<button class="btn" type="button">Continue</button>
							<button class="btn btn-inverse" type="submit" id="checkout">Checkout</button>
						</p>					
					</div>
					
			</section>			

    

    </strong>			

    

</asp:Content>
