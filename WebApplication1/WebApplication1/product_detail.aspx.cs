using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Models;
namespace WebApplication1
{
    public partial class product_detail : System.Web.UI.Page
    {
        Connections parent;
        protected void Page_Load(object sender, EventArgs e)
        {
            parent = new Connections();
            if (!IsPostBack)
            {
                datafetcher();
            }
        }
        void datafetcher()
        {
            try
            {
                parent.Connection_establish();
                parent.cmd = new System.Data.SqlClient.SqlCommand("select * from product where pid=@1",Connections.con);
                parent.cmd.Parameters.AddWithValue("@1", Request.Cookies["products"].ToString());
                parent.dr = parent.cmd.ExecuteReader();
                while (parent.dr.Read())
                {

                }
               
            }
            catch
            { }
            finally
            {
                parent.Connection_refuse();
            }
        }
    }
}