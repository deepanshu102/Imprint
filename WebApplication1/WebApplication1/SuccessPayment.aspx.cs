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

        protected void Page_Load(object sender, EventArgs e)
        {
            parent = new Connections();
            
               update_payment_status();
            
        }

        private void update_payment_status()
        {
            try
            {
                parent.Connection_establish();
                parent.cmd = new System.Data.SqlClient.SqlCommand("update payment set status=@2 where transid=@1", Connections.con);
                parent.cmd.Parameters.AddWithValue("@1",Request.Cookies["products"].Value );
                parent.cmd.Parameters.AddWithValue("@2", "Success");

                if (parent.cmd.ExecuteNonQuery()>0)
                { Label1.Text = "Your order has successfully placed. Thanks for shopping."; }

            }
            catch(Exception E)
            {
                Response.Write(E.Message);
            }
            finally
            {
                parent.Connection_refuse();
            }
        }
    }
}