<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="product_detail.aspx.cs" Inherits="WebApplication1.product_detail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<section class="header_text sub">
			<img class="pageBanner" src="themes/images/pageBanner.png" alt="New products" >
				<h4><span>Product Detail</span></h4>
			</section>
			<section class="main-content">				
				<div class="row">						
					<div class="span12">
						<div class="row">
							<div class="span5">
								<a href="#" class="thumbnail" data-fancybox-group="group1" title="Description 1">
                                <asp:Image ID="pro_image" runat="server" /></a>												
								<ul class="thumbnails small">								
									<li class="span1">
										<a href="themes/images/ladies/2.jpg" class="thumbnail" data-fancybox-group="group1" title="Description 2">
                                <asp:Image ID="pro_image1" runat="server" /></a>
									</li>								
									
								</ul>
							</div>
							<div class="span6">
									
									<h1><span><asp:Label ID="product" runat="server" Text=""></asp:Label></span></h1><br>
								
                                <h4><strong>Brand:</strong> <span><asp:Label ID="Brand" runat="server" Text=""></asp:Label></span></h4><br>
									
									<h4><strong>Availability:</strong> <span><asp:Label ID="stock" runat="server" Text=""></asp:Label></span></h4><br>								
                                <asp:HiddenField ID="stock1" runat="server" />						
								<h4><strong>Price: <asp:Label ID="price" runat="server" Text=""></asp:Label></strong></h4>
							</div>
							<div class="span6">
								<div class="form-inline">
									<p>&nbsp;</p>
									<label>Qty:</label>
                                    <asp:TextBox ID="quant"  class="span1" TextMode="Number"  Text="1" runat="server"></asp:TextBox>
									<br />
                                   <h1> <asp:Label ID="unstock" runat="server" Text=""></asp:Label></h1>
                                    <asp:Button ID="cart" runat="server" Text="Add to Cart" Cssclass="btn btn-danger" OnClick="cart_Click" />
                                    <asp:Button ID="Checkout" runat="server" Text="Buy Now" CssClass="btn btn-success" OnClick="Checkout_Click" />
                                    
								</div>
							</div>							
						</div>
						<div class="row">
							<div class="span12">
								<ul class="nav nav-tabs" id="myTab">
									<li class="active"><a href="#home">Description</a></li>
								</ul>							 
								<div class="tab-content">
									<div class="tab-pane active" id="home">
                                        <asp:Label ID="desc" runat="server" Text=""></asp:Label></div>

								</div>							
							</div>						
							<div class="span12">	
								<br>
								<h4 class="title">
									<span class="pull-left"><span class="text"><strong>Related</strong> Products</span></span>
									<span class="pull-right">
										<a class="left button" href="#myCarousel-1" data-slide="prev"></a><a class="right button" href="#myCarousel-1" data-slide="next"></a>
									</span>
								</h4>
								<div id="myCarousel-1" class="carousel slide">
									<div class="carousel-inner">
										<div class=" item">
											<ul class="thumbnails listing-products">
												<li class="span4">
													<div class="product-box">
														<span class="sale_tag"></span>												
														<a href="product_detail.aspx"><img alt="" src="themes/images/ladies/6.jpg"></a><br/>
														<a href="product_detail.aspx" class="title">Wuam ultrices rutrum</a><br/>
														<a href="#" class="category">Suspendisse aliquet</a>
														<p class="price">$341</p>
													</div>
												</li>
												<li class="span4">
													<div class="product-box">
														<span class="sale_tag"></span>												
														<a href="product_detail.aspx"><img alt="" src="themes/images/ladies/5.jpg"></a><br/>
														<a href="product_detail.aspx" class="title">Fusce id molestie massa</a><br/>
														<a href="#" class="category">Phasellus consequat</a>
														<p class="price">$341</p>
													</div>
												</li>       
												<li class="span4">
													<div class="product-box">												
														<a href="product_detail.aspx"><img alt="" src="themes/images/ladies/4.jpg"></a><br/>
														<a href="product_detail.aspx" class="title">Praesent tempor sem</a><br/>
														<a href="#" class="category">Erat gravida</a>
														<p class="price">$28</p>
													</div>
												</li>												
											</ul>
										</div>
										<div class="  item">
											<ul class="thumbnails listing-products">
												<li class="span3">
													<div class="product-box">
														<span class="sale_tag"></span>												
														<a href="product_detail.aspx"><img alt="" src="themes/images/ladies/1.jpg"></a><br/>
														<a href="product_detail.aspx" class="title">Fusce id molestie massa</a><br/>
														<a href="#" class="category">Phasellus consequat</a>
														<p class="price">$341</p>
													</div>
												</li>       
												<li class="span3">
													<div class="product-box">												
														<a href="product_detail.aspx"><img alt="" src="themes/images/ladies/2.jpg"></a><br/>
														<a href="product_detail.aspx">Praesent tempor sem</a><br/>
														<a href="#" class="category">Erat gravida</a>
														<p class="price">$28</p>
													</div>
												</li>
												<li class="span3">
													<div class="product-box">
														<span class="sale_tag"></span>												
														<a href="product_detail.aspx"><img alt="" src="themes/images/ladies/3.jpg"></a><br/>
														<a href="product_detail.aspx" class="title">Wuam ultrices rutrum</a><br/>
														<a href="#" class="category">Suspendisse aliquet</a>
														<p class="price">$341</p>
													</div>
												</li>
											</ul>
										</div>
									</div>
								</div>
							</div>
						</div>
					</div>
					
				</div>
			</section>		
			<script>
			$(function () {
				$('#myTab a:first').tab('show');
				$('#myTab a').click(function (e) {
					e.preventDefault();
					$(this).tab('show');
				})
			})
			$(document).ready(function() {
				$('.thumbnail').fancybox({
					openEffect  : 'none',
					closeEffect : 'none'
				});
				
				$('#myCarousel-2').carousel({
                    interval: 2500
                });								
			});
		</script>

</asp:Content>
