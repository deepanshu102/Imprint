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
    public partial class orders : System.Web.UI.Page
    {
        Connections parent;
        protected void Page_Load(object sender, EventArgs e)
        {
            parent = new Connections();

            fillgrid();
            if (!IsPostBack)
            {
                gridbinder();
            }

           
        }
            void gridbinder()
        {
                try
                {
                    parent.Connection_establish();
                    parent.cmd = new System.Data.SqlClient.SqlCommand("orders", Connections.con);
                    parent.cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    (parent.cmd.Parameters.AddWithValue("@id", SqlDbType.NVarChar)).Value = ((List<string>)Session["user"])[0].ToString();
                parent.da.SelectCommand = parent.cmd;
                parent.da.Fill(parent.ds, "order");
                GridView1.DataSource = parent.ds.Tables["order"].DefaultView;
                    GridView1.DataBind();
                }
                catch(Exception e)
                {
                Response.Write(e.StackTrace);

            }
                finally
                { parent.Connection_refuse(); }
            }
            protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            GridView1.PageIndex = e.NewPageIndex;
            gridbinder();

        }
        protected void fillgrid()
        {
            if (Session["User"] != null)
            {
                try
                {
                    parent.Connection_establish();

                    parent.cmd = new SqlCommand("orders", Connections.con);
                    parent.cmd.CommandType = CommandType.StoredProcedure;
                    (parent.cmd.Parameters.AddWithValue("@id", SqlDbType.NVarChar)).Value = ((List<string>)Session["user"])[0].ToString();

                    parent.da.SelectCommand = parent.cmd;
                    parent.da.Fill(parent.ds, "orders");
                    GridView1.DataSource = parent.ds.Tables["orders"].DefaultView;
                    GridView1.DataBind();
                }catch(Exception k)
                { Response.Write(k); }
                finally { parent.Connection_refuse(); }
            }
            else
            {
                Response.Redirect("/");
            }
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            int odid = Convert.ToInt32(e.CommandArgument);
            Response.Redirect("~/Order.aspx" + odid + "");
        }
    }
}