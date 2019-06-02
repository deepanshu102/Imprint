using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Models;
using System.Data;
namespace WebApplication1
{
    public partial class changepassword : System.Web.UI.Page
    {
        Connections parent;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
                parent = new Connections();
            else
                Response.Redirect("/");
        }
        protected void Update_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                try
                {

                    parent.Connection_establish();
                    parent.cmd = new System.Data.SqlClient.SqlCommand("changepassword", Connections.con);
                    parent.cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    (parent.cmd.Parameters.AddWithValue("@uid", SqlDbType.NVarChar)).Value = ((List<string>)Session["user"])[0].ToString();
                    (parent.cmd.Parameters.AddWithValue("@password", SqlDbType.NVarChar)).Value = oldpass.Text;
                    (parent.cmd.Parameters.AddWithValue("@pass", SqlDbType.NVarChar)).Value = repass.Text;
                    if (parent.cmd.ExecuteNonQuery() > 0)
                    {
                        Response.Write("<script>alert('Sucessfully update');</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('Invalid details');</script>");
                    }

                }
                catch
                { }
                finally
                { }
            }
        }
    }
}