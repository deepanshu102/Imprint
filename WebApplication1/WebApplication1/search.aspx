<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="search.aspx.cs" Inherits="WebApplication1.search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section class="header_text" onload="display()">
        <div class="row ">
            <div  class=" col-sm-4">
               <a onclick="display()" class="btn btn-primary active" href="#items"> Items</a>
                    <a onclick="display1()" class="btn btn-primary" href="#Users">Users </a>
            
           <a onclick="display2()" class="btn btn-primary" href="#category">Category</a>
            </div>
        </div>

   
    <hr />
    <div class="row">
        <div id="Users" style="display:none;margin-left:20%;">
            <center> 
              Name:-<asp:TextBox ID="User_name" runat="server"></asp:Textbox><asp:ImageButton ID="ImageButton2" onclick="ImageButton2_Click" runat="server"  ImageUrl="/themes/search.png" Height="40px" ImageAlign="AbsBottom" Width="40px"></asp:ImageButton>
               <hr/>
                <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
               <hr />
            <asp:GridView AutoPostBack="true" ID="Grid_Users" AllowPaging="true" PageSize="5" OnPageIndexChanging="Grid_Users_PageIndexChanging" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="uid"
              AutoColumnGenrated="false" ShowHeaderWhenEmpty="True"    AutoGenerateColumns="False">
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />
                 <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" /> 
                <Columns>
                    <asp:TemplateField HeaderText="Name">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("uname") %>'></asp:Label>
                        </ItemTemplate>                    
                    </asp:TemplateField>
                                
                    <asp:TemplateField HeaderText="Phone">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("phone") %>'></asp:Label>
                        </ItemTemplate>                    
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Address">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("address") %>'></asp:Label>
                        </ItemTemplate>                    
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Mail">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("email") %>'></asp:Label>
                        </ItemTemplate>                    
                    </asp:TemplateField>
                </Columns>
                 </asp:GridView>
               </center>
        </div>
        <div id="category"  style="display:none;margin-left:20%;">
         <center> 
             Primary Category:<asp:DropDownList ID="Primary_category" OnSelectedIndexChanged="Primary_category_SelectedIndexChanged"  DataTextField="name" DataValueField="s_cat_id" runat="server">
 
                              </asp:DropDownList>
             Category Name:-<asp:TextBox ID="Category_Box" runat="server"></asp:Textbox><asp:ImageButton ID="Category" onclick="Category_Click" runat="server"  ImageUrl="/themes/search.png" Height="40px" ImageAlign="AbsBottom" Width="40px"></asp:ImageButton>
               <hr/>
                <asp:Label ID="Status1" runat="server" Text=""></asp:Label>
               <hr />
            <asp:GridView  AutoPostBack="true" PageSize="4" ID="Grid_Category" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="cat_id"
              AutoColumnGenrated="false" ShowfooterWhenEmpty="true" ShowHeaderWhenEmpty="True" AllowPaging="true" OnPageIndexChanging="Grid_Category_PageIndexChanging"  ShowFooter="true"  OnRowDeleting="Grid_Category_RowDeleting"  OnRowCommand="Grid_Category_RowCommand"     AutoGenerateColumns="False" OnSelectedIndexChanged="Grid_Category_SelectedIndexChanged">
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />
                 <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" /> 
                <Columns>
                    <asp:TemplateField HeaderText="Name">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("catname") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate> 
                            <asp:TextBox ID="cat_name"  Text='<%#Eval("catname") %>' runat="server"></asp:TextBox>
                        </EditItemTemplate>
                     <FooterTemplate>
                         <asp:TextBox ID="Category_text" CommandName="Category_Text" runat="server"></asp:TextBox>
                     </FooterTemplate>
                    </asp:TemplateField>
                     
                    <asp:TemplateField>
                        <ItemTemplate>
                          <asp:Button ID="Delete" runat="server" Text="Delete" CommandName="Delete" CssClass="btn btn-danger"></asp:Button>
                        </ItemTemplate>
                        <FooterTemplate>
                              <asp:Button ID="Add" CssClass="btn btn-primary" CommandName="Add" runat="server" Text="ADD"></asp:Button>
                        </FooterTemplate>
                    </asp:TemplateField>              
                </Columns>
                 </asp:GridView>
               </center>
           
        </div>
        <div id="items" style="display:block;margin-left:20%;">
           <center> Items Name:-<asp:TextBox ID="Item_Box" runat="server"></asp:Textbox><asp:ImageButton ID="ImageButton1" runat="server" onclick="ImageButton1_Click1" ImageUrl="/themes/search.png" Height="40px" ImageAlign="AbsBottom" Width="40px"></asp:ImageButton>
               <hr/>
<asp:Label ID="Status" runat="server" Text=""></asp:Label>
               <hr />
            <asp:GridView  AutoPostBack="true" ID="Grid_items"  AllowPaging="true" PageSize="2" OnPageIndexChanging="Grid_items_PageIndexChanging" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="pid"
              AutoColumnGenrated="false" ShowHeaderWhenEmpty="True"    OnRowDeleting="Grid_items_RowDeleting" AutoGenerateColumns="False">
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />
                 <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" /> 
                <Columns>
                    
                    <asp:TemplateField HeaderText="Name">
                        <ItemTemplate>
                         
                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("pname") %>'></asp:Label>
                        </ItemTemplate>
                      
                    </asp:TemplateField>
                 <asp:TemplateField HeaderText="Categry">
                        <ItemTemplate>
                            <asp:Label ID="cat_id" runat="server" Text='<%#Eval("catname") %>'></asp:Label>
                        </ItemTemplate>
                       
                       
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Price">
                        <ItemTemplate>
                            <asp:Label ID="price" runat="server" Text='<%#Eval("price") %>'></asp:Label>
                        </ItemTemplate>
                  
                      
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Stock">
                        <ItemTemplate>
                            <asp:Label ID="price" runat="server" Text='<%#Eval("stock") %>'></asp:Label>
                        </ItemTemplate>
                  
                      
                    </asp:TemplateField>
                   <asp:TemplateField HeaderText="Details">
                        <ItemTemplate>
                            <asp:Label ID="details" runat="server" Text='<%#Eval("pdesc") %>'></asp:Label>
                        </ItemTemplate>
                     
                       
                    </asp:TemplateField>
                 
                    <asp:ButtonField ButtonType="Button" runat="server" CommandName="Delete" Text="Delete">
                    <ControlStyle CssClass="btn btn-danger" />
                    </asp:ButtonField>
                 
                </Columns>
            </asp:GridView>
               </center>
        </div>
    </div>
         </section>
    <script>
        function display()
        {
            document.getElementById("items").style.display = "block";
            document.getElementById("category").style.display = "none";
            document.getElementById("Users").style.display = "none";

        }
        function display1() {
            document.getElementById("items").style.display = "none";
            document.getElementById("Users").style.display = "block";
            document.getElementById("category").style.display = "none";
        }
        function display2() {
            document.getElementById("category").style.display = "block";
            document.getElementById("Users").style.display = "none";
            document.getElementById("items").style.display = "none";

        }
    </script>
   
</asp:Content>
