using System;
using System.Collections.Generic;
using System.Data;
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

            parent = new Connections();
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
                parent.cmd = new System.Data.SqlClient.SqlCommand("view_Cart", Connections.con);
                parent.cmd.CommandType = System.Data.CommandType.StoredProcedure;
                (parent.cmd.Parameters.AddWithValue("@uid", SqlDbType.NVarChar)).Value = "geet";
                parent.da.SelectCommand = parent.cmd;
                parent.da.Fill(parent.ds, "Cart");
                GridView1.DataSource = parent.ds.Tables["Cart"].DefaultView;
                GridView1.DataBind();
            }
            catch
            { }
            finally
            { parent.Connection_refuse(); }
        }
    
        protected void Cart_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {

        }
        

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            GridView1.PageIndex = e.NewPageIndex;
            gridbinder();

        }
    }
}