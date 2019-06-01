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

                parent.dr = parent.cmd.ExecuteReader();
                 Grid_Users.DataSource = parent.dr;
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

                parent.dr = parent.cmd.ExecuteReader();
                 Grid_Category.DataSource = parent.dr;
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

                parent.dr = parent.cmd.ExecuteReader();
                Grid_items.DataSource = parent.dr;
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

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {

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
                parent.cmd = new SqlCommand("select * from category where catname=@items", Connections.con);
                parent.cmd.Parameters.AddWithValue("@items", Category_Box.Text);
                parent.dr = parent.cmd.ExecuteReader();
                if (parent.dr.HasRows)
                {
                    Grid_Category.DataSource = parent.dr;
                    Grid_Category.DataBind();

                }
                else
                {
                    Response.Write("<script>alert('No Data Found');</script>");
                    parent.Connection_refuse();
                    PopulateGridView1();
                }
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
                parent.cmd = new SqlCommand("select * from users where uname=@username", Connections.con);
                parent.cmd.Parameters.AddWithValue("@username", User_name.Text);
                parent.dr = parent.cmd.ExecuteReader();
                if (parent.dr.HasRows)
                {
                    Grid_Users.DataSource = parent.dr;
                    Grid_Users.DataBind();

                }
                else
                {
                    Response.Write("<script>alert('No Data Found');</script>");
                    PopulateGridView2();
                }
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
    }
}