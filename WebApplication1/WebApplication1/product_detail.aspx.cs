using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
                    pro_image.ImageUrl = parent.dr["pimage"].ToString();
                    pro_image1.ImageUrl = parent.dr["pimage"].ToString();
                    desc.Text = parent.dr["pdesc"].ToString();
                    product.Text = parent.dr["pname"].ToString();
                    Brand.Text = parent.dr["catname"].ToString();
                    price.Text = parent.dr["price"].ToString();
                    if ((parent.dr["stock"].ToString()).Equals("0"))
                    { stock.Text = "Out of Stock";
                        stock.ForeColor =System.Drawing.Color.Red;
                        cart.Visible = false;
                        Checkout.Visible = false;
                        unstock.Text = "Try after Some Time Sorry for inconviente";
                    }
                    else
                    {
                        stock.ForeColor = System.Drawing.Color.LawnGreen;
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

        
        protected void cart_Click(object sender, EventArgs e)
        {
            string bill;
            if (Session["user"] != null)
            {
                if ((Int32.Parse(quant.Text)) <= (Int32.Parse(stock1.Value)))
                {
                    try
                    {
                       
                        bill = (Int32.Parse(quant.Text) * Int32.Parse(price.Text)) + "";

                     

                        parent.Connection_establish();
                        parent.cmd = new SqlCommand("insert into cart (cartid,pid,uid,quantity,bill) values(@cartid,@pid,@id,@quant,@bills);", Connections.con);
                        parent.cmd.Parameters.AddWithValue("@cartid", "Crt" + Connections.cart_id);
                       
                        parent.cmd.Parameters.AddWithValue("@pid", Request.Cookies["products"].Value);
                        parent.cmd.Parameters.AddWithValue("@id", ((List<string>)Session["user"])[0].ToString());
                        parent.cmd.Parameters.AddWithValue("@quant",quant.Text);
                        parent.cmd.Parameters.AddWithValue("@bills", bill);
                        if ((int)parent.cmd.ExecuteNonQuery() > 0)
                        {
                            Connections.cart_id++;
                            Response.Write("<script>alert('Sucessfully added');</script>");
                        }

                    }
                    catch (Exception k)
                    {
                        Response.Write(k.StackTrace);
                    }
                    finally
                    {
                        parent.Connection_refuse();
                    }
                }
                else
                {
                    Response.Write("<script>alert('Kindly choose less qunatity');</script>");
                }
            }
            else
            {
                Response.Redirect("register.aspx");
            }


        }

        protected void Checkout_Click(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {

                Response.Cookies["quantity"].Value = quant.Text;
                Response.Cookies["quantity"].Expires = DateTime.Now.AddDays(7);
                Response.Redirect("checkout.aspx");
            }
            else
            {
                Response.Cookies["quantity"].Value = quant.Text;
                Response.Cookies["quantity"].Expires= DateTime.Now.AddDays(7); 
                Response.Redirect("register.aspx");
            }
        }
    }
}