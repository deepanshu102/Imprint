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
    public partial class cart : System.Web.UI.Page
    {
        Connections parent;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                parent = new Connections();
                if (!IsPostBack)
                {
                    gridbinder();
                }

            }
            else
            { Response.Redirect("/"); }
           
        }

        void gridbinder()
        {
            try
            {
                parent.Connection_establish();
                parent.cmd = new System.Data.SqlClient.SqlCommand("view_Cart", Connections.con);
                parent.cmd.CommandType = System.Data.CommandType.StoredProcedure;
                (parent.cmd.Parameters.AddWithValue("@uid", SqlDbType.NVarChar)).Value = ((List<string>)Session["user"])[0].ToString();
                parent.da.SelectCommand = parent.cmd;
                parent.da.Fill(parent.ds, "Cart");
                GridView1.DataSource = parent.ds.Tables["Cart"].DefaultView;
                GridView1.DataBind();
            }
            catch (Exception k)
            {
                Response.Write(k);
            }
            finally
            { parent.Connection_refuse(); }
        }
    
        protected void Cart_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            GridView1.PageIndex = e.NewPageIndex;
            gridbinder();

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            try
            {
                parent.Connection_establish();
                parent.cmd = new System.Data.SqlClient.SqlCommand("del_cart", Connections.con);
                parent.cmd.CommandType = CommandType.StoredProcedure;
                parent.cmd.Parameters.AddWithValue("@cart_id", SqlDbType.NVarChar).Value = GridView1.DataKeys[e.RowIndex].Value.ToString().Trim();
                if((int)parent.cmd.ExecuteNonQuery()==1)
                {
                }
                else
                {
                    Response.Write("Some Issues Try later");
                }
            }
            catch(Exception K)
            {
                Response.Write(K);
            }
            finally
            { parent.Connection_refuse(); }
            gridbinder();

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            String bill;
            try
            { parent.Connection_establish();
                parent.cmd = new SqlCommand("select price from product,cart where cartid=@id and product.pid=cart.pid", Connections.con);
                parent.cmd.Parameters.AddWithValue("@id", GridView1.DataKeys[e.RowIndex].Value.ToString().Trim());
                parent.dr = parent.cmd.ExecuteReader();
                parent.dr.Read();
                bill = parent.dr[0].ToString();

                parent.Connection_refuse();
                String quant =( GridView1.Rows[e.RowIndex].FindControl("ed_quant") as TextBox).Text;
                bill = (Int32.Parse(bill) * Int32.Parse(quant)) + "";
                Response.Write("<script>alert('" + bill + quant + "');</script>");
                
                parent.Connection_establish();
                parent.cmd = new SqlCommand("update cart set quantity=@1,bill=@2 where cartid=@cartid;", Connections.con);
                parent.cmd.Parameters.AddWithValue("@cartid", GridView1.DataKeys[e.RowIndex].Value.ToString().Trim());
                parent.cmd.Parameters.AddWithValue("@1", quant);
                parent.cmd.Parameters.AddWithValue("@2", bill);
                if ((int)parent.cmd.ExecuteNonQuery() > 0)
                {
                  
                }

            }
            catch (Exception K)
            { Response.Write(K); }
            finally
            { parent.Connection_refuse(); }
            GridView1.EditIndex = -1;
            gridbinder();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            gridbinder();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {

            if (Session["user"] != null)
            {

                Response.Cookies["quantity"].Value = "Cart";
                Response.Cookies["quantity"].Expires = DateTime.Now.AddDays(7);
                Response.Redirect("checkout.aspx");
            }
            else
            {
                Response.Cookies["quantity"].Value = "cart";
                Response.Cookies["quantity"].Expires = DateTime.Now.AddDays(7);
                Response.Redirect("register.aspx");
            }
        }
    }
}