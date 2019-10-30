<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="orders.aspx.cs" Inherits="WebApplication1.orders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section class="header_text sub">
        <img class="pageBanner" src="themes/images/pageBanner.png" alt="New products">
        <h4><span>Orders</span></h4>
    </section>
    <section class="main-content">
        <div class="row">
            <div class="span9">


                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="oid" AllowPaging="True"  ShowFooter="true"
                    OnPageIndexChanging="GridView1_PageIndexChanging" align="center" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                    <Columns>
                        <asp:TemplateField HeaderText="Product ">
                            <ItemTemplate>
                                <asp:Image ID="arrow1" runat="server" ImageUrl='<%#Bind("pimage") %>' Width="100" Height="100" />
                                
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Product  Detail">
                            <ItemTemplate>
                              
                                 <asp:Label ID="Label2" runat="server" Text='<%#Eval("pname") %>'></asp:Label><br />
                                <small>
                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("pdesc") %>'></asp:Label>
                                </small>
                            </ItemTemplate>

                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Quantity">
                            <ItemTemplate>
                                <asp:Label ID="quant" runat="server" Text='<%#Eval("quantity") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Price" SortExpression="pprice">
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%#Bind("price") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText=" Amount" SortExpression="pprice">
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%#Bind("Total") %>'></asp:Label>
                            </ItemTemplate>
                            
                        </asp:TemplateField>
                        
                     
                    </Columns>
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#808080" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#383838" />
                </asp:GridView>
                <div class="center">
                    <asp:Label ID="Total" runat="server" Text="asdljasdfjls"></asp:Label>
                </div>
                    </div>
            </div>
                
    </section>
</asp:Content>

