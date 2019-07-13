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
                   <asp:GridView ID="GridView1" runat="server"  AutoGenerateColumns="False" ShowFooter="true" onRowCancelingEdit ="GridView1_RowCancelingEdit"
        DataKeyNames="cartid"  AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" onRowDeleting ="GridView1_RowDeleting" onRowEditing="GridView1_RowEditing" onRowUpdating ="GridView1_RowUpdating" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                       <EmptyDataTemplate>
                          <h1> Cart is Empty</h1>
                       </EmptyDataTemplate>
                       <FooterStyle BackColor="White" ForeColor="Black" />
                       <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
<PagerStyle BackColor="white" ForeColor="#000066" HorizontalAlign="Left"/>
<Columns>
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
    
    <asp:TemplateField HeaderText="">
        <ItemTemplate>
            <asp:Button ID="Button1" runat="server" CssClass="btn btn-danger" CommandName="Delete" Text="Delete" />
            <asp:Button ID="Button2" runat="server" CssClass="btn btn-primary" Text="Edit"  CommandName="Edit"/>
        </ItemTemplate>
        <EditItemTemplate>
            <asp:Button ID="Button3" CommandArgument="" CssClass="btn btn-primary" CommandName="Update" runat="server" Text="update" />
            
            <asp:Button ID="Button4" CommandArgument="" CssClass="btn btn-danger" CommandName="Cancel" runat="server" Text="Cancel" />
        </EditItemTemplate>
    </asp:TemplateField>
</Columns>
                       <RowStyle ForeColor="#000066" />
                       <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                       <SortedAscendingCellStyle BackColor="#F1F1F1" />
                       <SortedAscendingHeaderStyle BackColor="#007DBB" />
                       <SortedDescendingCellStyle BackColor="#CAC9C9" />
                       <SortedDescendingHeaderStyle BackColor="#00547E" />
    </asp:GridView>
                        
                        <div align="right">
                            <asp:Button ID="Button5" OnClick="Button5_Click" CssClass="btn btn-danger" runat="server" Text="Check Out" />
                        </div>
					
						
                        				
					</div>
					
			</section>			

    

</asp:Content>
