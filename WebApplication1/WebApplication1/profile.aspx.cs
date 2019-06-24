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
    public partial class profile : System.Web.UI.Page
    {
        Connections parent;
        protected void Page_Load(object sender, EventArgs e)
        {

            parent = new Connections();
            if (Session["user"] != null)
            {
                Profile();
            }
            else
            {
                Response.Redirect("/");
            }
        }
        void Profile()
        {
            try
            {
                parent.Connection_establish();
                parent.cmd = new System.Data.SqlClient.SqlCommand("Profile", Connections.con);
                parent.cmd.CommandType = System.Data.CommandType.StoredProcedure;
               parent.cmd.Parameters.AddWithValue("@uid", SqlDbType.NVarChar).Value = ((List<string>)Session["user"])[0].ToString();
                parent.dr = parent.cmd.ExecuteReader();
                if (parent.dr.Read())
                {
                    username.Text = parent.dr["uid"].ToString();
                    name.Text = parent.dr["uname"].ToString();
                    phone.Text = parent.dr["phone"].ToString();
                    address.Text = parent.dr["address"].ToString();
                    email.Text = parent.dr["email"].ToString();

                }
                else
                {

                }

            }
            catch (Exception k)
            {
                Response.Write(k);
            }
            finally
            {
                parent.Connection_refuse();
            }
        }
        protected void update_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                try
                {
                    parent.Connection_establish();
                    parent.cmd = new System.Data.SqlClient.SqlCommand("profile_updation", Connections.con);
                    parent.cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    (parent.cmd.Parameters.AddWithValue("@userid", SqlDbType.NVarChar)).Value = username.Text.Trim();
                    (parent.cmd.Parameters.AddWithValue("@uid", SqlDbType.NVarChar)).Value = ((List<string>)Session["user"])[0].ToString();
                    (parent.cmd.Parameters.AddWithValue("@address", SqlDbType.NVarChar)).Value = address.Text.Trim();
                    (parent.cmd.Parameters.AddWithValue("@phone", SqlDbType.NVarChar)).Value = phone.Text.Trim();
                    (parent.cmd.Parameters.AddWithValue("@email", SqlDbType.NVarChar)).Value = email.Text.Trim();
                    if ((int)parent.cmd.ExecuteNonQuery() >=2)
                    {
                       // ((List<string>)Session["user"]).Insert(0, username.Text.Trim());
                        Response.Write("<script>alert('Sucessfully updated');</script>");
                        Response.Write(((List<string>)Session["user"])[0].ToString());
                    }
                    else
                    {

                        Response.Write("<script>alert('Some Issues');</script>");
                    }
                }
                catch (Exception k)
                {
                    Response.Write(k.StackTrace);
                }
                finally
                {
                    parent.Connection_refuse();
                    Profile();
                }
            }

        }
    }
}