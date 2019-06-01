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
    public partial class orders : System.Web.UI.Page
    {
        Connections parent;
 

        protected void Page_Load(object sender, EventArgs e)
        {
            parent = new Connections();
            if (!IsPostBack)
            {
                OrderBinder();
            }
        }
        void OrderBinder()
        {
            try
            {
                parent.Connection_establish();
                parent.cmd = new System.Data.SqlClient.SqlCommand("select * from [dbo].[order],product,users where [order].pid=product.pid and  [order].uid=users.uid;", Connections.con);
             
                Grid_Order.DataSource = parent.cmd.ExecuteReader();
                Grid_Order.DataBind();
            }
            catch
            { }
            finally
            { parent.Connection_refuse(); }
        }
    }
}