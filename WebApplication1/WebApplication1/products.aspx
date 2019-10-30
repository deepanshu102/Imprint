<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="products.aspx.cs" Inherits="WebApplication1.products" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<section class="header_text sub">
		 <% 
                 if (Session["user"] != null && ((List<string>)Session["user"])[1].ToString() == "A")//for admin 
                 { %>
            <div>
           <table>
               <tr>
                   <td class="col-6">
              <table>
                <tr>
                    <td>
                        Select Category :-
                    </td>
                    <td>
                     <asp:DropDownList ID="Category" runat="server" DataTextField="catname" OnSelectedIndexChanged="Category_SelectedIndexChanged" DataValueField="cat_id" AutoPostBack="True"  >                          
                        </asp:DropDownList>
                          
                       
                    </td>
                </tr>
                <tr>

                    <td>
                        Item Name:</td><td><asp:TextBox ID="name" runat="server" required="" placeholder="Enter Item Name">  </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Item Price:</td><td><asp:TextBox ID="price" TextMode="Number" runat="server" required="" placeholder="Price">  </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Item Description:-</td><td><asp:TextBox ID="details" require="" runat="server"></asp:TextBox>
                           </td>
                </tr>
                    <tr>
                    <td>
                        Stock:-</td><td><asp:TextBox ID="Stock" TextMode="Number" required="" runat="server"></asp:TextBox>
                           </td>
                </tr>
                <tr>
                    <td>
                       Item Image</td><td><asp:FileUpload ID="File_image"  AutoPostBack="True" required="" runat="server" placeholder="Enter Item Name">  </asp:FileUpload>
                    </td>
                </tr>
                     <tr>
                         
                    <td colspan="2">
                        <asp:TextBox ID="Key" placeholder="Enter keywords here"  AutoPostBack="true" OnTextChanged="Key_TextChanged"  runat="server" Height="23px" Width="308px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                  
                    <td colspan="3">
                          <asp:Button runat="server"  ID="Update" Text="INSERT" OnClick="Update_Click"  CssClass=" center btn btn-primary" />
                    </td>
                </tr>
            </table></td>
                   <td class="col-6" >
    
                       <header>Keywords Help for searchader</header>
                       <div>
                           <asp:TextBox ID="KeysIndi"  runat="server" Wrap="False"></asp:TextBox>
                       </div>
                   </td></tr>

                  
                   </table>
         </div>
        
    
    
    
    	<% }

    else {
%>
        
   <img class="pageBanner" src="themes/images/pageBanner.png" alt="New products" >
				<h4><span>New products</span></h4>
						<section class="main-content">
				<br />
				<div class="row">						
					<div class="span12">
                       <div class="">
                           <div class="">
                <asp:DataPager ID="DataPagerProducts" runat="server" PagedControlID="Products"
    PageSize="12" OnPreRender="DataPagerProducts_PreRender">
    <Fields>
        <asp:NextPreviousPagerField ShowFirstPageButton="True" ShowNextPageButton="True" ButtonType="Button" ShowPreviousPageButton="False" />
        <asp:NumericPagerField />
        <asp:NextPreviousPagerField ShowLastPageButton="True" ShowPreviousPageButton="true" ButtonType="Button" ShowNextPageButton="False" />
    </Fields>
</asp:DataPager>
                           </div>
                       </div>
                        <br />
                        <asp:ListView class="thumbnails listing-products"    onItemDeleting ="Products_ItemDeleting" OnItemCommand="Products_ItemCommand" ID="Products" DataKeyNames="pid" runat="server">
                            <ItemTemplate>
                                                           
                                <li style="list-style-type:none;" class="span3">
                                <div class="product-box">												
									<img alt="" src="<%#Eval("pimage") %>" ><br/>
									<asp:Label ID="name"  runat="server" CssClass="title" Text='<%#Eval("pname")%>'></asp:Label><br/>
									<asp:Label ID="price" runat="server" CssClass="price" Text='<%#Eval("price") %>' ></asp:Label>
									
								
                                    <div class="bottom">
                                  

                                          <asp:Button ID="Select" runat="server" CommandArgument='<%#Eval("pid")%>' Text="Add Cart" CommandName="ADD" CssClass="btn btn-success"></asp:Button>
										 <asp:Button ID="Delete" runat="server"   CommandArgument='<%#Eval("pid")%>'  Text="View More" CommandName="Delete" CssClass="btn btn-primary"></asp:Button>
										
										
								</div>
                                    </div>
                                </li>
                                
                            </ItemTemplate>
                            				
                            </asp:ListView>
						<hr>
						
					</div>
					
				</div>
			</section>
			<%}%>
    </section>
</asp:Content>
