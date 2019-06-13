using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using WebApplication1.Models;
namespace WebApplication1
{
    public partial class cart : System.Web.UI.Page
    {
        Connections parent;
        private object lbl_totalCost;

        protected void Page_Load(object sender, EventArgs e)
        {
           

            parent = new Connections();
            if (!IsPostBack)
              {
                 gridbinder();
             }
            lbl_totalCost.Text = TotalProductCost() + "";

        }

        public int TotalProductCost()
        {
            int totalCost = 0;
            int currentCost = 0;
            int currentQuantity = 0;

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                // Get the data values from the forms
                HyperLink hypCost = (HyperLink)GridView1.Rows[i].Cells[0].FindControl("hyp_productcost");
                TextBox txtQuantity = (TextBox)GridView1.Rows[i].Cells[0].FindControl("txt_productQuantity");

                // Sum the product quantity and the product cost               
                // Attempt to parse your value (removing any non-numeric values)
                currentQuantity = Int32.Parse(Regex.Replace(txtQuantity.Text, @"[^\d]", ""));

                // Attempt to parse your value (removing any non-numeric values)
                currentCost = Int32.Parse(Regex.Replace(hypCost.Text, @"[^\d]", ""));

                currentCost *= currentQuantity;

                totalCost += currentCost;


            }
            return totalCost;

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
            GridView1.EditIndex = e.NewEditIndex;
            gridbinder();
        }

       

        protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
        }
        

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            GridView1.PageIndex = e.NewPageIndex;
            gridbinder();

        }
/*
        protected void GridView1_RowUpdating(object sender, EventArgs e)
        {
            GridViewRow rowToUpdate = GridView1.SelectedRow;//ye kisliye
           

            //ye function hai jisme aapko coding karni hai
            try
            {
                parent.Connection_establish();
                // Update the cart quantity if the id matches with the grid view data source
                parent.cmd = new System.Data.SqlClient.SqlCommand("UPDATE table cart SET quantity = @1,bill=@2 WHERE cartid =@3", Connections.con);
                parent.cmd.Parameters.AddWithValue("@1")
                parent.cmd.Parameters.AddWithValue("@2")
                    parent.cmd.Parameters.AddWithValue("@3", GridView1.DataKeys[e.RowIntdex].Value.ToString().Trim())
                parent.cmd.ExecuteNonQuery();
                Response.Redirect("cart.aspx");

            }
             catch { }
            
            finally
           {
                parent.Connection_refuse();
            }
            gridbinder();

            Response.Write("<script>alert('hello');</script>");
        }
*/
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            gridbinder();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)

        {
            Response.Write("<script>alert('" + GridView1.DataKeys[e.RowIndex].Values[0] + "');</script>");
            try
            {
                parent.Connection_establish();
                parent.cmd = new System.Data.SqlClient.SqlCommand("delete from cart where cartid=@1", Connections.con);
                parent.cmd.Parameters.AddWithValue("@1", GridView1.DataKeys[e.RowIndex].Values[0]);
                parent.cmd.ExecuteNonQuery();

            }
            catch
            { }
            finally
            {
                parent.Connection_refuse();
            }
            gridbinder();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            GridViewRow rowToUpdate = GridView1.SelectedRow;//ye kisliye


            //ye function hai jisme aapko coding karni hai
          /*  try
            {
                parent.Connection_establish();
                // Update the cart quantity if the id matches with the grid view data source
                parent.cmd = new System.Data.SqlClient.SqlCommand("UPDATE table cart SET quantity = @1,bill=@2 WHERE cartid =@3", Connections.con);
                parent.cmd.Parameters.AddWithValue("@1",rowToUpdate.FindControl("ed_quant"));
                parent.cmd.Parameters.AddWithValue("@2",);
                parent.cmd.Parameters.AddWithValue("@3", GridView1.DataKeys[e.RowIndex].Value.ToString().Trim());
                parent.cmd.ExecuteNonQuery();
                Response.Redirect("cart.aspx");

            }
            catch { }

            finally
            {
                parent.Connection_refuse();
            }
            gridbinder();
            */
            Response.Write("<script>alert('" + GridView1.DataKeys[e.RowIndex].Value.ToString().Trim() + "');</script>");

        }
    }
}