using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Models;
namespace WebApplication1
{
    
    public partial class SuccessPayment : System.Web.UI.Page
    {
        Connections parent;
        static int i = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            parent = new Connections();
            if (!IsPostBack)
            {
                insert_orders();
            }
        }
        void insert_orders()
        {
            try
            {
                parent.Connection_establish();
                parent.cmd = new System.Data.SqlClient.SqlCommand("add_orders", Connections.con);
          
            }
            catch (Exception E)
            {
                Response.Write(E);
            }
            finally
            {
                parent.Connection_refuse();
            }
        }
    }
}