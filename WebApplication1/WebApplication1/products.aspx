<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="products.aspx.cs" Inherits="WebApplication1.products" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<section class="header_text sub">
		 <% if (Session["user"] != null)
    {
        if (((List<string>)Session["user"])[1].ToString() == "A")//for admin 
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
                       Item Image</td><td><asp:FileUpload ID="File_image"  AutoPostBack="true" required="" runat="server" placeholder="Enter Item Name" OnDataBinding="File_image_DataBinding">  </asp:FileUpload>
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
        
    
    
    
    	<%}
                        else { %>
    <img class="pageBanner" src="themes/images/pageBanner.png" alt="New products" >
				<h4><span>New products</span></h4>
			</section>
			<section class="main-content">
				
				<div class="row">						
					<div class="span9">								
						<ul class="thumbnails listing-products">
							<li class="span3">
								<div class="product-box">
									<span class="sale_tag"></span>												
									<a href="product_detail.aspx"><img alt="" src="themes/images/ladies/9.jpg"></a><br/>
									<a href="product_detail.aspx" class="title">Fusce id molestie massa</a><br/>
									<a href="#" class="category">Phasellus consequat</a>
									<p class="price">$341</p>
								</div>
							</li>       
							<li class="span3">
								<div class="product-box">												
									<a href="product_detail.aspx"><img alt="" src="themes/images/ladies/8.jpg"></a><br/>
									<a href="product_detail.aspx" class="title">Praesent tempor sem</a><br/>
									<a href="#" class="category">Erat gravida</a>
									<p class="price">$28</p>
								</div>
							</li>
							<li class="span3">
								<div class="product-box">
									<span class="sale_tag"></span>												
									<a href="product_detail.aspx"><img alt="" src="themes/images/ladies/7.jpg"></a><br/>
									<a href="product_detail.aspx" class="title">Wuam ultrices rutrum</a><br/>
									<a href="#" class="category">Suspendisse aliquet</a>
									<p class="price">$341</p>
								</div>
							</li>
							<li class="span3">
								<div class="product-box">												
									<span class="sale_tag"></span>
									<a href="product_detail.aspx"><img alt="" src="themes/images/ladies/6.jpg"></a><br/>
									<a href="product_detail.aspx" class="title">Praesent tempor sem sodales</a><br/>
									<a href="#" class="category">Nam imperdiet</a>
									<p class="price">$49</p>
								</div>
							</li>
							<li class="span3">
								<div class="product-box">                                        												
									<a href="product_detail.aspx"><img alt="" src="themes/images/ladies/1.jpg"></a><br/>
									<a href="product_detail.aspx" class="title">Fusce id molestie massa</a><br/>
									<a href="#" class="category">Congue diam congue</a>
									<p class="price">$35</p>
								</div>
							</li>       
							<li class="span3">
								<div class="product-box">												
									<a href="product_detail.aspx"><img alt="" src="themes/images/ladies/2.jpg"></a><br/>
									<a href="product_detail.aspx" class="title">Tempor sem sodales</a><br/>
									<a href="#" class="category">Gravida placerat</a>
									<p class="price">$61</p>
								</div>
							</li>
							<li class="span3">
								<div class="product-box">												
									<a href="product_detail.aspx"><img alt="" src="themes/images/ladies/3.jpg"></a><br/>
									<a href="product_detail.aspx" class="title">Quam ultrices rutrum</a><br/>
									<a href="#" class="category">Orci et nisl iaculis</a>
									<p class="price">$233</p>
								</div>
							</li>
							<li class="span3">
								<div class="product-box">												
									<a href="product_detail.aspx"><img alt="" src="themes/images/ladies/4.jpg"></a><br/>
									<a href="product_detail.aspx" class="title">Tempor sem sodales</a><br/>
									<a href="#" class="category">Urna nec lectus mollis</a>
									<p class="price">$134</p>
								</div>
							</li>
							<li class="span3">
								<div class="product-box">												
									<a href="product_detail.aspx"><img alt="" src="themes/images/ladies/5.jpg"></a><br/>
									<a href="product_detail.aspx" class="title">Luctus quam ultrices</a><br/>
									<a href="#" class="category">Suspendisse aliquet</a>
									<p class="price">$261</p>
								</div>
							</li>
						</ul>								
						<hr>
						<div class="pagination pagination-small pagination-centered">
							<ul>
								<li><a href="#">Prev</a></li>
								<li class="active"><a href="#">1</a></li>
								<li><a href="#">2</a></li>
								<li><a href="#">3</a></li>
								<li><a href="#">4</a></li>
								<li><a href="#">Next</a></li>
							</ul>
						</div>
					</div>
					<div class="span3 col">
						<div class="block">	
							<ul class="nav nav-list">
								<li class="nav-header">SUB CATEGORIES</li>
								<li><a href="products.aspx">Nullam semper elementum</a></li>
								<li class="active"><a href="products.aspx">Phasellus ultricies</a></li>
								<li><a href="products.aspx">Donec laoreet dui</a></li>
								<li><a href="products.aspx">Nullam semper elementum</a></li>
								<li><a href="products.aspx">Phasellus ultricies</a></li>
								<li><a href="products.aspx">Donec laoreet dui</a></li>
							</ul>
							<br/>
							<ul class="nav nav-list below">
								<li class="nav-header">MANUFACTURES</li>
								<li><a href="products.aspx">Adidas</a></li>
								<li><a href="products.aspx">Nike</a></li>
								<li><a href="products.aspx">Dunlop</a></li>
								<li><a href="products.aspx">Yamaha</a></li>
							</ul>
						</div>
						<div class="block">
							<h4 class="title">
								<span class="pull-left"><span class="text">Randomize</span></span>
								<span class="pull-right">
									<a class="left button" href="#myCarousel" data-slide="prev"></a><a class="right button" href="#myCarousel" data-slide="next"></a>
								</span>
							</h4>
							<div id="myCarousel" class="carousel slide">
								<div class="carousel-inner">
									<div class="active item">
										<ul class="thumbnails listing-products">
											<li class="span3">
												<div class="product-box">
													<span class="sale_tag"></span>												
													<img alt="" src="themes/images/ladies/1.jpg"><br/>
													<a href="product_detail.aspx" class="title">Fusce id molestie massa</a><br/>
													<a href="#" class="category">Suspendisse aliquet</a>
													<p class="price">$261</p>
												</div>
											</li>
										</ul>
									</div>
									<div class="item">
										<ul class="thumbnails listing-products">
											<li class="span3">
												<div class="product-box">												
													<img alt="" src="themes/images/ladies/2.jpg"><br/>
													<a href="product_detail.aspx" class="title">Tempor sem sodales</a><br/>
													<a href="#" class="category">Urna nec lectus mollis</a>
													<p class="price">$134</p>
												</div>
											</li>
										</ul>
									</div>
								</div>
							</div>
						</div>
						<div class="block">								
							<h4 class="title"><strong>Best</strong> Seller</h4>								
							<ul class="small-product">
								<li>
									<a href="#" title="Praesent tempor sem sodales">
										<img src="themes/images/ladies/3.jpg" alt="Praesent tempor sem sodales">
									</a>
									<a href="#">Praesent tempor sem</a>
								</li>
								<li>
									<a href="#" title="Luctus quam ultrices rutrum">
										<img src="themes/images/ladies/4.jpg" alt="Luctus quam ultrices rutrum">
									</a>
									<a href="#">Luctus quam ultrices rutrum</a>
								</li>
								<li>
									<a href="#" title="Fusce id molestie massa">
										<img src="themes/images/ladies/5.jpg" alt="Fusce id molestie massa">
									</a>
									<a href="#">Fusce id molestie massa</a>
								</li>   
							</ul>
						</div>
					</div>
				</div>
			</section>
    <%}
                    } %>
               <%else
    { %> <img class="pageBanner" src="themes/images/pageBanner.png" alt="New products" >
				<h4><span>New products</span></h4>
			</section>
			<section class="main-content">
				
				<div class="row">						
					<div class="span9">								
						<ul class="thumbnails listing-products">
							<li class="span3">
								<div class="product-box">
									<span class="sale_tag"></span>												
									<a href="product_detail.aspx"><img alt="" src="themes/images/ladies/9.jpg"></a><br/>
									<a href="product_detail.aspx" class="title">Fusce id molestie massa</a><br/>
									<a href="#" class="category">Phasellus consequat</a>
									<p class="price">$341</p>
								</div>
							</li>       
							<li class="span3">
								<div class="product-box">												
									<a href="product_detail.aspx"><img alt="" src="themes/images/ladies/8.jpg"></a><br/>
									<a href="product_detail.aspx" class="title">Praesent tempor sem</a><br/>
									<a href="#" class="category">Erat gravida</a>
									<p class="price">$28</p>
								</div>
							</li>
							<li class="span3">
								<div class="product-box">
									<span class="sale_tag"></span>												
									<a href="product_detail.aspx"><img alt="" src="themes/images/ladies/7.jpg"></a><br/>
									<a href="product_detail.aspx" class="title">Wuam ultrices rutrum</a><br/>
									<a href="#" class="category">Suspendisse aliquet</a>
									<p class="price">$341</p>
								</div>
							</li>
							<li class="span3">
								<div class="product-box">												
									<span class="sale_tag"></span>
									<a href="product_detail.aspx"><img alt="" src="themes/images/ladies/6.jpg"></a><br/>
									<a href="product_detail.aspx" class="title">Praesent tempor sem sodales</a><br/>
									<a href="#" class="category">Nam imperdiet</a>
									<p class="price">$49</p>
								</div>
							</li>
							<li class="span3">
								<div class="product-box">                                        												
									<a href="product_detail.aspx"><img alt="" src="themes/images/ladies/1.jpg"></a><br/>
									<a href="product_detail.aspx" class="title">Fusce id molestie massa</a><br/>
									<a href="#" class="category">Congue diam congue</a>
									<p class="price">$35</p>
								</div>
							</li>       
							<li class="span3">
								<div class="product-box">												
									<a href="product_detail.aspx"><img alt="" src="themes/images/ladies/2.jpg"></a><br/>
									<a href="product_detail.aspx" class="title">Tempor sem sodales</a><br/>
									<a href="#" class="category">Gravida placerat</a>
									<p class="price">$61</p>
								</div>
							</li>
							<li class="span3">
								<div class="product-box">												
									<a href="product_detail.aspx"><img alt="" src="themes/images/ladies/3.jpg"></a><br/>
									<a href="product_detail.aspx" class="title">Quam ultrices rutrum</a><br/>
									<a href="#" class="category">Orci et nisl iaculis</a>
									<p class="price">$233</p>
								</div>
							</li>
							<li class="span3">
								<div class="product-box">												
									<a href="product_detail.aspx"><img alt="" src="themes/images/ladies/4.jpg"></a><br/>
									<a href="product_detail.aspx" class="title">Tempor sem sodales</a><br/>
									<a href="#" class="category">Urna nec lectus mollis</a>
									<p class="price">$134</p>
								</div>
							</li>
							<li class="span3">
								<div class="product-box">												
									<a href="product_detail.aspx"><img alt="" src="themes/images/ladies/5.jpg"></a><br/>
									<a href="product_detail.aspx" class="title">Luctus quam ultrices</a><br/>
									<a href="#" class="category">Suspendisse aliquet</a>
									<p class="price">$261</p>
								</div>
							</li>
						</ul>								
						<hr>
						<div class="pagination pagination-small pagination-centered">
							<ul>
								<li><a href="#">Prev</a></li>
								<li class="active"><a href="#">1</a></li>
								<li><a href="#">2</a></li>
								<li><a href="#">3</a></li>
								<li><a href="#">4</a></li>
								<li><a href="#">Next</a></li>
							</ul>
						</div>
					</div>
					<div class="span3 col">
						<div class="block">	
							<ul class="nav nav-list">
								<li class="nav-header">SUB CATEGORIES</li>
								<li><a href="products.aspx">Nullam semper elementum</a></li>
								<li class="active"><a href="products.aspx">Phasellus ultricies</a></li>
								<li><a href="products.aspx">Donec laoreet dui</a></li>
								<li><a href="products.aspx">Nullam semper elementum</a></li>
								<li><a href="products.aspx">Phasellus ultricies</a></li>
								<li><a href="products.aspx">Donec laoreet dui</a></li>
							</ul>
							<br/>
							<ul class="nav nav-list below">
								<li class="nav-header">MANUFACTURES</li>
								<li><a href="products.aspx">Adidas</a></li>
								<li><a href="products.aspx">Nike</a></li>
								<li><a href="products.aspx">Dunlop</a></li>
								<li><a href="products.aspx">Yamaha</a></li>
							</ul>
						</div>
						<div class="block">
							<h4 class="title">
								<span class="pull-left"><span class="text">Randomize</span></span>
								<span class="pull-right">
									<a class="left button" href="#myCarousel" data-slide="prev"></a><a class="right button" href="#myCarousel" data-slide="next"></a>
								</span>
							</h4>
							<div id="myCarousel" class="carousel slide">
								<div class="carousel-inner">
									<div class="active item">
										<ul class="thumbnails listing-products">
											<li class="span3">
												<div class="product-box">
													<span class="sale_tag"></span>												
													<img alt="" src="themes/images/ladies/1.jpg"><br/>
													<a href="product_detail.aspx" class="title">Fusce id molestie massa</a><br/>
													<a href="#" class="category">Suspendisse aliquet</a>
													<p class="price">$261</p>
												</div>
											</li>
										</ul>
									</div>
									<div class="item">
										<ul class="thumbnails listing-products">
											<li class="span3">
												<div class="product-box">												
													<img alt="" src="themes/images/ladies/2.jpg"><br/>
													<a href="product_detail.aspx" class="title">Tempor sem sodales</a><br/>
													<a href="#" class="category">Urna nec lectus mollis</a>
													<p class="price">$134</p>
												</div>
											</li>
										</ul>
									</div>
								</div>
							</div>
						</div>
						<div class="block">								
							<h4 class="title"><strong>Best</strong> Seller</h4>								
							<ul class="small-product">
								<li>
									<a href="#" title="Praesent tempor sem sodales">
										<img src="themes/images/ladies/3.jpg" alt="Praesent tempor sem sodales">
									</a>
									<a href="#">Praesent tempor sem</a>
								</li>
								<li>
									<a href="#" title="Luctus quam ultrices rutrum">
										<img src="themes/images/ladies/4.jpg" alt="Luctus quam ultrices rutrum">
									</a>
									<a href="#">Luctus quam ultrices rutrum</a>
								</li>
								<li>
									<a href="#" title="Fusce id molestie massa">
										<img src="themes/images/ladies/5.jpg" alt="Fusce id molestie massa">
									</a>
									<a href="#">Fusce id molestie massa</a>
								</li>   
							</ul>
						</div>
					</div>
				</div>
			</section><%} %>
			
</asp:Content>
