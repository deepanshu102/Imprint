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
            //Response.Write("<script>alert('" + Request.Cookies["products"].Value + "');</script>");
            try
            {
                parent.Connection_establish();
                parent.cmd = new System.Data.SqlClient.SqlCommand("select * from product,category where  pid=@1 and product.cat_id=category.cat_id",Connections.con);
                parent.cmd.Parameters.AddWithValue("@1", Request.Cookies["products"].Value);
                parent.dr = parent.cmd.ExecuteReader();
                while (parent.dr.Read())
                {
                    desc.Text = parent.dr["pdesc"].ToString();
                    product.Text = parent.dr["pname"].ToString();
                    Brand.Text = parent.dr["catname"].ToString();
                    price.Text = parent.dr["price"].ToString();
                    if ((parent.dr["stock"].ToString()).Equals("0"))
                    { stock.Text = "Out of Stock";
                    }
                    else
                    {
                        stock.Text = "Available";
                        stock1.Value = parent.dr["stock"].ToString();
                    }
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