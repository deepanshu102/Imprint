using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Models;
namespace WebApplication1
{
    public partial class search : System.Web.UI.Page
    {
        Connections parent;
        static int ids = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                parent = new Connections();
                if (!IsPostBack)
                {
                    PopulateGridview();//FOr items
                    PopulateGridView1();//FOr Category
                    PopulateGridView2();//For Users
                }
            }
            else
            {
                Response.Redirect("/");
            }
        }

        private void PopulateGridView2()
        {
            try
            {
                if (Connections.con != null && Connections.con.State == System.Data.ConnectionState.Closed)
                    parent.Connection_establish();
                parent.cmd = new SqlCommand("A_User", Connections.con);
                parent.cmd.CommandType = System.Data.CommandType.StoredProcedure;
                parent.da.SelectCommand = parent.cmd;
                parent.da.Fill(parent.ds, "Users");
                
                 Grid_Users.DataSource = parent.ds.Tables["Users"].DefaultView;
                Grid_Users.DataBind();

            }
            catch (Exception k)
            {
                Response.Write(k.StackTrace);

            }
            finally
            {
                parent.Connection_refuse();
            }
        }

        private void PopulateGridView1()
        {
            try
            {
                if (Connections.con != null && Connections.con.State == System.Data.ConnectionState.Closed)
                    parent.Connection_establish();
                parent.cmd = new SqlCommand("categories", Connections.con);
                parent.cmd.CommandType = System.Data.CommandType.StoredProcedure;
                parent.da.SelectCommand = parent.cmd;
                parent.da.Fill(parent.ds,"Category");

                Grid_Category.DataSource = parent.ds.Tables["Category"].DefaultView;
                Grid_Category.DataBind();
            }
            catch (Exception k)
            {
                Response.Write(k.StackTrace);

            }
            finally
            {
                parent.Connection_refuse();
            }
        }

        private void PopulateGridview()
        {
            try
            {
                if (Connections.con != null && Connections.con.State == System.Data.ConnectionState.Closed)
                    parent.Connection_establish();
                parent.cmd = new SqlCommand("products", Connections.con);
                    parent.cmd.CommandType = System.Data.CommandType.StoredProcedure;
                parent.da.SelectCommand = parent.cmd;
                parent.da.Fill(parent.ds, "Products");
               
                Grid_items.DataSource = parent.ds.Tables["Products"].DefaultView;
                Grid_items.DataBind();

            }
            catch (Exception k)
            {
                Response.Write(k.StackTrace);

            }
            finally
            {
                parent.Connection_refuse();
            }
        }



        protected void Grid_items_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int key = ids;

                parent.Connection_establish();
                parent.cmd = new SqlCommand("del_product", Connections.con);
                parent.cmd.CommandType = System.Data.CommandType.StoredProcedure;
                (parent.cmd.Parameters.AddWithValue("@id", SqlDbType.NVarChar)).Value = Grid_items.DataKeys[e.RowIndex].Value.ToString().Trim();
                if ((int)parent.cmd.ExecuteNonQuery() > 0)
                {
                    ids++;
                    Response.Write("<script>alert('Sucessfully Deleted');</script>");
                }
                else
                {
                    Response.Write("<script>alert('Some issues');</script>");
                }



            }
            catch (Exception k)
            {
                


            }
            finally
            {
                parent.Connection_refuse();
                PopulateGridview();
            }
        }

      

        protected void Grid_Category_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                parent.Connection_establish();
                parent.cmd = new SqlCommand("Delete from category where cat_id=@id", Connections.con);
                parent.cmd.Parameters.AddWithValue("@id", Grid_Category.DataKeys[e.RowIndex].Value.ToString().Trim());
                if ((int)parent.cmd.ExecuteNonQuery() > 0)
                {
                    PopulateGridView1();
                    Response.Write("<script>alert('Sucessfully Deleted');</script>");
                }
                else
                {
                    Response.Write("<script>alert('Not sucessfully inserted');</script>");
                }

            }
            catch (Exception k)
            {
                Response.Write("<script>alert('first delete the products in this category then delete this category');</script>");

            }
            finally
            {
                parent.Connection_refuse();
            }
        }

        protected void Grid_Category_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Add"))
            {
                if ((Grid_Category.FooterRow.FindControl("Category_text") as TextBox).Text != "")
                    try
                    {
                        int key = ids;

                        parent.Connection_establish();
                        parent.cmd = new SqlCommand("add_category", Connections.con);
                        parent.cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        (parent.cmd.Parameters.AddWithValue("@catid", SqlDbType.NVarChar)).Value = "cat" + ids;
                        (parent.cmd.Parameters.AddWithValue("@catname", SqlDbType.NVarChar)).Value = ((Grid_Category.FooterRow.FindControl("Category_text") as TextBox).Text).Trim();
                        if ((int)parent.cmd.ExecuteNonQuery() > 0)
                        {
                            ids++;
                            Response.Write("<script>alert('Sucessfully Insert');</script>");
                        }
                        else
                        {
                            Response.Write("<script>alert('Not sucessfully inserted');</script>");
                        }
                       


                    }
                    catch (Exception k)
                    {
                        Response.Write(k.StackTrace + "<script>alert('" + ids.ToString() + "');</script>");


                    }
                    finally
                    {
                        parent.Connection_refuse();
                        PopulateGridView1();
                    }
            }
            else if (e.CommandArgument.Equals("Save"))
            {

            }
            else if (e.CommandArgument.Equals("Delete"))
            {
                Response.Redirect("/");
            }
        }

        protected void Category_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                parent.Connection_establish();
                parent.cmd = new SqlCommand("categories", Connections.con);
                parent.cmd.CommandType = System.Data.CommandType.StoredProcedure;
                parent.da.SelectCommand = parent.cmd;
                parent.da.Fill(parent.ds, "Category");
                if (!string.IsNullOrEmpty(Category_Box.Text))
                {
                    parent.ds.Tables["Category"].DefaultView.RowFilter = "catname='" + Category_Box.Text + "'";
                }
               
                    Grid_Category.DataSource = parent.ds.Tables["Category"].DefaultView;
                    Grid_Category.DataBind();

           
            }
            catch (Exception k)
            {
                Response.Write(k.StackTrace);

            }
            finally
            {
                parent.Connection_refuse();
            }

        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                parent.Connection_establish();
                parent.cmd = new SqlCommand("A_User", Connections.con);
                parent.cmd.CommandType = System.Data.CommandType.StoredProcedure;
                parent.da.SelectCommand = parent.cmd;
                parent.da.Fill(parent.ds, "Users");
                parent.dv = parent.ds.Tables["Users"].DefaultView;
                if (!string.IsNullOrEmpty(User_name.Text)) { parent.dv.RowFilter = "uname='" + User_name.Text + "'"; }
                Grid_Users.DataSource = parent.dv;
                Grid_Users.DataBind();
            }
            catch
            { }
            finally
            {
                parent.Connection_refuse();
            }

        
        }

        protected void Grid_Category_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            // Set the index of the new display page.  
            Grid_Category.PageIndex = e.NewPageIndex;


            // Rebind the GridView control to  
            // show data in the new page. 
            PopulateGridView1();//FOr Category           
        }

        protected void Grid_Category_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Grid_Users_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Grid_Category.PageIndex = e.NewPageIndex;


            // Rebind the GridView control to  
            // show data in the new page. 
            PopulateGridView2();//For Users  
        }

        protected void Grid_items_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Grid_items.PageIndex = e.NewPageIndex;


            // Rebind the GridView control to  
            // show data in the new page. 
            PopulateGridview();//FOr items
        }

        protected void ImageButton1_Click1(object sender, ImageClickEventArgs e)
        {
            try
            {
                parent.Connection_establish();
                parent.cmd = new SqlCommand("products", Connections.con);
                parent.cmd.CommandType = System.Data.CommandType.StoredProcedure;
                parent.da.SelectCommand = parent.cmd;
                parent.da.Fill(parent.ds, "Products");
                if (!string.IsNullOrEmpty(Item_Box.Text))
                {
                    parent.ds.Tables["Products"].DefaultView.RowFilter = "pname='" + Item_Box.Text + "'";
                }
                Grid_items.DataSource = parent.ds.Tables["Products"].DefaultView;
                Grid_items.DataBind();
            }
            catch (Exception k)
            {
                Response.Write(Item_Box.Text);

            }
            finally
            {
                parent.Connection_refuse();
            }
        }
    }
}