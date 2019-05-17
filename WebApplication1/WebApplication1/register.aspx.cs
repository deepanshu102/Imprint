using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Models;
namespace WebApplication1
{
    public partial class register : System.Web.UI.Page
    {
        Connections parent;
        protected void Page_Load(object sender, EventArgs e)
        {
            parent = new Connections();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           
             if(IsValid)
            {
                
                    try
                {
                    parent.Connection_establish();
                    parent.cmd = new SqlCommand("Authenticate", Connections.con);
                    parent.cmd.CommandType= CommandType.StoredProcedure;
                    SqlParameter parameter1 = parent.cmd.Parameters.AddWithValue("@userid", SqlDbType.NVarChar);
                    parameter1.Value = username.Text;
                    SqlParameter parameter2 = parent.cmd.Parameters.AddWithValue("@pass", SqlDbType.NVarChar);
                    parameter2.Value = password.Text;

                    parent.dr = parent.cmd.ExecuteReader();
                    if (parent.dr.Read())
                    {
                        List<string> obj = new List<string>();

                        obj.Add(parent.dr[0].ToString());
                        obj.Add(parent.dr[2].ToString());
                       // Response.Write("<script>alert('"+parent.dr[0].ToString()+"');</script>");
                        Session["user"] = obj;
                        Response.Redirect("/");
                    }
                    else
                    {
                        Response.Write("<script>alert('Invalid Username and Password');</script>");
                    }


                }
                catch (Exception K)
                {
                    Response.Write(K.StackTrace);
                }
                finally
                {
                    parent.Connection_refuse();
                }
            }
        }
    }
}