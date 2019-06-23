<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="orders.aspx.cs" Inherits="WebApplication1.orders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section class="header_text sub">
        <img class="pageBanner" src="themes/images/pageBanner.png" alt="New products">
        <h4><span>Orders</span></h4>
    </section>
    <section class="main-content">
        <div class="row">
            <div class="span9">


                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="oid" PageSize="10" AllowPaging="true"
                    OnPageIndexChanging="GridView1_PageIndexChanging" align="center">
                    <PagerStyle BackColor="white" ForeColor="#17202A" HorizontalAlign="Center" />
                    <Columns>
                        <asp:TemplateField HeaderText="Product ID" InsertVisible="false" SortExpression="pid">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%#Bind("pid") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Product Name" SortExpression="pname">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("pname") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Quantity">
                            <ItemTemplate>
                                <asp:Label ID="quant" runat="server" Text='<%#Eval("pdesc") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Price" SortExpression="pprice">
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%#Bind("price") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Image">
                            <ItemTemplate>
                                <asp:Image ID="arrow1" runat="server" ImageUrl='<%#Bind("pimage") %>' Width="100" Height="100" />
                            </ItemTemplate>
                        </asp:TemplateField>
                     
                    </Columns>
                </asp:GridView>
    </section>
</asp:Content>

