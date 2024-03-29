﻿using System;
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
using System.Configuration;

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
                parent.cmd = new SqlCommand("Select * from product,users where users.uid=@1 and pid=@2", Connections.con);
                parent.cmd.Parameters.AddWithValue("@1", ((List<string>)Session["user"])[0].ToString());
                parent.cmd.Parameters.AddWithValue("@2", Request.Cookies["products"].Value);
                parent.dr=parent.cmd.ExecuteReader();
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
                    product_bill.Text=(Int32.Parse(parent.dr["price"].ToString())*Int32.Parse(Request.Cookies["quantity"].Value))+"";
                }

            }
            catch (Exception k)
            { Response.Write(k); }
            finally
            { parent.Connection_refuse(); }
        }

        protected void place_Click(object sender, EventArgs e)
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

            data.Add("surl", "http://localhost:51571/SuccessPayment.aspx/" + txnid.Value);
            data.Add("furl", "http://localhost:51571/FailurePayment.aspx" + txnid.Value);

            data.Add("service_provider", "");
            string strForm = PreparePOSTForm("https://test.payu.in/_payment", data);
            Page.Controls.Add(new LiteralControl(strForm));



            if (IsValid)
            {
                try
                {
                    parent.Connection_establish();
                    parent.cmd = new SqlCommand("add_orders", Connections.con);
                    parent.cmd.CommandType = CommandType.StoredProcedure;
                    (parent.cmd.Parameters.AddWithValue("@oid", SqlDbType.NVarChar)).Value ="Order"+ Connections.order_id;
                    (parent.cmd.Parameters.AddWithValue("@pid", SqlDbType.NVarChar)).Value = pid.Value;
                    (parent.cmd.Parameters.AddWithValue("@quantity", SqlDbType.NVarChar)).Value = quantity.Text;
                    (parent.cmd.Parameters.AddWithValue("@paymode", SqlDbType.NVarChar)).Value = "Online";
                    (parent.cmd.Parameters.AddWithValue("@txnid", SqlDbType.NVarChar)).Value = txnid.Value;
                    (parent.cmd.Parameters.AddWithValue("@Uid", SqlDbType.NVarChar)).Value = ((List<string>)Session["user"])[0].ToString();


                    if ((int)parent.cmd.ExecuteNonQuery() >= 2)
                    {
                        Response.Write("<script>alert('Sucessfully order placed');</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('UnSucessfull order');</script>");

                    }

                }
                catch
                {
                }
                finally
                {
                    parent.Connection_refuse();
                }
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


    }
}