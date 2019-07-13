using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using WebApplication1.Models;
using System.Text;
using System.Security.Cryptography;

namespace WebApplication1
{
    public partial class checkout : System.Web.UI.Page
    {
        Connections parent;
        protected void Page_Load(object sender, EventArgs e)
        {
            //kr
            parent = new Connections();

            if(!IsPostBack)
            { Binding();
                gateway_values();
            }
            
        }
        void gateway_values()
        {
            Random random = new Random();
            txnid.Value = (Convert.ToString(random.Next(10000, 20000)));
            txnid.Value = "Imprint" + txnid.Value.ToString();


           // Response.Write(txnid.Value.ToString());
        }
        void Binding()
        {
            try
            { parent.Connection_establish();
                if (!Request.Cookies["quantity"].Value.Equals("Cart"))
                {
                    parent.cmd = new SqlCommand("Select * from product,users where users.uid=@1 and pid=@2", Connections.con);
                    parent.cmd.Parameters.AddWithValue("@1", ((List<string>)Session["user"])[0].ToString());
                    parent.cmd.Parameters.AddWithValue("@2", Request.Cookies["products"].Value);
                    parent.dr = parent.cmd.ExecuteReader();
                    while (parent.dr.Read())
                    {
                        pid.Value = parent.dr["pid"].ToString();
                        product_image.ImageUrl = parent.dr["pimage"].ToString();
                        product_name.Text = parent.dr["pname"].ToString();
                        product_price.Text = parent.dr["price"].ToString();
                        product_des.Text = parent.dr["pdesc"].ToString();
                        quantity.Text = Request.Cookies["quantity"].Value;
                        user_name.Text = parent.dr["uname"].ToString();
                        phone.Text = parent.dr["phone"].ToString();
                        email.Text = parent.dr["email"].ToString();
                        address.Text = parent.dr["address"].ToString();
                        product_bill.Text = (Int32.Parse(parent.dr["price"].ToString()) * Int32.Parse(Request.Cookies["quantity"].Value)) + "";
                    }
                }
                else
                {
                    parent.cmd = new SqlCommand("Select * from product,cart where cart.pid=product.pid and uid=@1", Connections.con);
                    parent.cmd.Parameters.AddWithValue("@1", ((List<string>)Session["user"])[0].ToString());
                    parent.dr = parent.cmd.ExecuteReader();
                    ListView1.DataSource = parent.dr;
                    ListView1.DataBind();
                    parent.Connection_refuse();
                    users_binder();
                    parent.Connection_establish();
                    parent.cmd = new SqlCommand("select sum(CONVERT(int,bill)) as sum from cart where uid=@1", Connections.con);
                    parent.cmd.Parameters.AddWithValue("@1", ((List<string>)Session["user"])[0].ToString());
                    parent.dr = parent.cmd.ExecuteReader();
                    while (parent.dr.Read())
                    {
                        Total.Text = parent.dr["sum"].ToString();
                    }


                }

            }
            catch (Exception k)
            { Response.Write(k.Message); }
            finally
            { parent.Connection_refuse(); }
        }
        protected void users_binder()
        {
            try
            {
                parent.Connection_establish();
                parent.cmd = new SqlCommand("select * from users where uid=@1", Connections.con);
                parent.cmd.Parameters.AddWithValue("@1", ((List<string>)Session["user"])[0].ToString());
                parent.dr = parent.cmd.ExecuteReader();
                while (parent.dr.Read())
                {
                    name1.Text = parent.dr["uname"].ToString();
                    phone1.Text = parent.dr["phone"].ToString();
                    email1.Text = parent.dr["email"].ToString();
                   address1.Text = parent.dr["address"].ToString();
                }
            }
            catch(Exception K)
            { Response.Write(K.Message); }
            finally
            {
                parent.Connection_refuse();
            }
        }

        protected void place_Click(object sender, EventArgs e)
        {
            insert_orders();
            if (!(Request.Cookies["quantity"].Value  == "Cart"))
            {
                Double amount = Convert.ToDouble(product_bill.Text);

                String text = key.Value.ToString() + "|" + txnid.Value.ToString() + "|" + amount + "|" + product_name.Text + "|" + user_name.Text + "|" + email.Text + "|" + "1" + "|" + "1" + "|" + "1" + "|" + "1" + "|" + "1" + "||||||" + salt.Value.ToString();
                //  Response.Write(text);
                byte[] message = Encoding.UTF8.GetBytes(text);

                UnicodeEncoding UE = new UnicodeEncoding();
                byte[] hashValue;
                SHA512Managed hashString = new SHA512Managed();
                string hex = "";
                hashValue = hashString.ComputeHash(message);
                foreach (byte x in hashValue)
                {
                    hex += String.Format("{0:x2}", x);
                }
                hash.Value = hex;
                Response.Cookies["id"].Value = txnid.Value;
                Response.Cookies["id"].Expires = DateTime.Now.AddMinutes(20);
                System.Collections.Hashtable data = new System.Collections.Hashtable(); // adding values in gash table for data post
                data.Add("hash", hex.ToString());
                data.Add("txnid", txnid.Value);
                data.Add("key", key.Value);
                // string AmountForm = ;// eliminating trailing zeros

                data.Add("amount", amount);
                data.Add("firstname", user_name.Text.Trim());
                data.Add("email", email.Text.Trim());
                data.Add("phone", phone.Text.Trim());
                data.Add("productinfo", product_name.Text);
                data.Add("udf1", "1");
                data.Add("udf2", "1");
                data.Add("udf3", "1");
                data.Add("udf4", "1");
                data.Add("udf5", "1");

                data.Add("surl", "http://localhost:51571/SuccessPayment.aspx/txn=" + txnid.Value);
                data.Add("furl", "http://localhost:51571/FailurePayment.aspx/txn=" + txnid.Value);

                data.Add("service_provider", "");
                string strForm = PreparePOSTForm("https://test.payu.in/_payment", data);
                Page.Controls.Add(new LiteralControl(strForm));
            }
            else
            {
                
                Double amount = Convert.ToDouble(Total.Text);

                String text = key.Value.ToString() + "|" + txnid.Value.ToString() + "|" + amount + "|" + product_name.Text + "|" + name1.Text + "|" + email1.Text + "|" + "1" + "|" + "1" + "|" + "1" + "|" + "1" + "|" + "1" + "||||||" + salt.Value.ToString();
                //  Response.Write(text);
                byte[] message = Encoding.UTF8.GetBytes(text);

                UnicodeEncoding UE = new UnicodeEncoding();
                byte[] hashValue;
                SHA512Managed hashString = new SHA512Managed();
                string hex = "";
                hashValue = hashString.ComputeHash(message);
                foreach (byte x in hashValue)
                {
                    hex += String.Format("{0:x2}", x);
                }
                hash.Value = hex;
                Response.Cookies["id"].Value = txnid.Value;
                Response.Cookies["id"].Expires = DateTime.Now.AddMinutes(20);
                System.Collections.Hashtable data = new System.Collections.Hashtable(); // adding values in gash table for data post
                data.Add("hash", hex.ToString());
                data.Add("txnid", txnid.Value);
                data.Add("key", key.Value);
                // string AmountForm = ;// eliminating trailing zeros

                data.Add("amount", amount);
                data.Add("firstname",name1.Text.Trim());
                data.Add("email", email1.Text.Trim());
                data.Add("phone", phone1.Text.Trim());
                data.Add("productinfo", product_name.Text);
                data.Add("udf1", "1");
                data.Add("udf2", "1");
                data.Add("udf3", "1");
                data.Add("udf4", "1");
                data.Add("udf5", "1");

                data.Add("surl", "http://localhost:51571/SuccessPayment.aspx/txn=" + txnid.Value);
                data.Add("furl", "http://localhost:51571/FailurePayment.aspx/txn=" + txnid.Value);

                data.Add("service_provider", "");
                string strForm = PreparePOSTForm("https://test.payu.in/_payment", data);
                Page.Controls.Add(new LiteralControl(strForm));
            }


        }

        private string PreparePOSTForm(string url, System.Collections.Hashtable data)      // post form
        {
            //Set a name for the form
            string formID = "PostForm";
            //Build the form using the specified data to be posted.
            StringBuilder strForm = new StringBuilder();
            strForm.Append("<form id=\"" + formID + "\" name=\"" +
                           formID + "\" action=\"" + url +
                           "\" method=\"POST\">");

            foreach (System.Collections.DictionaryEntry key in data)
            {

                strForm.Append("<input type=\"hidden\" name=\"" + key.Key +
                               "\" value=\"" + key.Value + "\">");
            }


            strForm.Append("</form>");
            //Build the JavaScript which will do the Posting operation.
            StringBuilder strScript = new StringBuilder();
            strScript.Append("<script language='javascript'>");
            strScript.Append("var v" + formID + " = document." +
                             formID + ";");
            strScript.Append("v" + formID + ".submit();");
            strScript.Append("</script>");
            //Return the form and the script concatenated.
            //(The order is important, Form then JavaScript)
            return strForm.ToString() + strScript.ToString();
        }

        void insert_orders()
        {

            try
            {
                if (Request.Cookies["quantity"].Value != "Cart")
                {
                    parent.Connection_establish();
                    parent.cmd = new SqlCommand("add_orders", Connections.con);
                    parent.cmd.CommandType = CommandType.StoredProcedure;
                    (parent.cmd.Parameters.AddWithValue("@id", SqlDbType.NVarChar)).Value = "Order" + Connections.order_id;
                    (parent.cmd.Parameters.AddWithValue("@pid", SqlDbType.NVarChar)).Value = pid.Value;
                    (parent.cmd.Parameters.AddWithValue("@qty", SqlDbType.NVarChar)).Value = quantity.Text;

                    (parent.cmd.Parameters.AddWithValue("@txnid", SqlDbType.NVarChar)).Value = txnid.Value;
                    (parent.cmd.Parameters.AddWithValue("@Uid", SqlDbType.NVarChar)).Value = ((List<string>)Session["user"])[0].ToString();
                    (parent.cmd.Parameters.AddWithValue("@amount", SqlDbType.NVarChar)).Value = product_bill.Text;


                    if ((int)parent.cmd.ExecuteNonQuery() >= 2)
                    {
                        Response.Cookies["products"].Value = txnid.Value;
                        Connections.order_id++;
                        Response.Write("<script>alert('Sucessfully order placed');</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('UnSucessfull order');</script>");

                    }
                }
                else
                {
                    parent.Connection_establish();
                    parent.cmd = new SqlCommand("Select * from cart where uid=@1", Connections.con);
                    parent.cmd.Parameters.AddWithValue("@1", ((List<string>)Session["user"])[0].ToString());
                    parent.da.SelectCommand = parent.cmd;
                    parent.da.Fill(parent.ds, "Carts");
                    parent.Connection_refuse();
                    for (int i = 0; i < parent.ds.Tables["Carts"].Rows.Count; i++)
                    {
                        DataRow dr = parent.ds.Tables["Carts"].Rows[i];
                        parent.Connection_establish();
                        parent.cmd = new SqlCommand("add_orders", Connections.con);
                        parent.cmd.CommandType = CommandType.StoredProcedure;
                        (parent.cmd.Parameters.AddWithValue("@id", SqlDbType.NVarChar)).Value = "Order" + Connections.order_id++;
                        (parent.cmd.Parameters.AddWithValue("@pid", SqlDbType.NVarChar)).Value = dr["pid"].ToString();
                        (parent.cmd.Parameters.AddWithValue("@qty", SqlDbType.NVarChar)).Value = dr["quantity"].ToString();

                        (parent.cmd.Parameters.AddWithValue("@txnid", SqlDbType.NVarChar)).Value = txnid.Value;
                        (parent.cmd.Parameters.AddWithValue("@Uid", SqlDbType.NVarChar)).Value = ((List<string>)Session["user"])[0].ToString();
                        (parent.cmd.Parameters.AddWithValue("@amount", SqlDbType.NVarChar)).Value = dr["bill"].ToString();


                        if ((int)parent.cmd.ExecuteNonQuery() >= 2)
                        {
                            Response.Cookies["products"].Value = txnid.Value;
                            Response.Write("<script>alert('Sucessfully order placed');</script>");
                        }
                        else
                        {
                            Response.Write("<script>alert('UnSucessfull order');</script>");

                        }
                        parent.Connection_refuse();

                    }

                }
            }
            catch (Exception K)
            {
                Response.Write(K.Message);

            }
            finally
            {
                parent.Connection_refuse();
            }
            

        }
    }
}