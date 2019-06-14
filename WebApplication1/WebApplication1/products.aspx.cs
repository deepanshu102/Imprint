using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Models;
namespace WebApplication1
{
    public partial class products : System.Web.UI.Page
    {
        String s;
        Connections parent;
        List<String> keywords = new List<String>();
        string pids;
        protected void Page_Load(object sender, EventArgs e)
        {
             parent = new Connections(); ;

            if (!IsPostBack)
            {
                Category_binder();
              //  product_binder();
            }
        }

        private void product_binder()
        {
            try
            {
                parent.Connection_establish();
                parent.cmd = new SqlCommand("products", Connections.con);
                parent.cmd.CommandType = CommandType.StoredProcedure;
                parent.da.SelectCommand = parent.cmd;
                parent.da.Fill(parent.ds, "Products");
                Products.DataSource = parent.ds.Tables["Products"].DefaultView;
                Products.DataBind();

            }
            catch(Exception k)
            { Response.Write(k.StackTrace); }
            finally
            { parent.Connection_refuse(); }
        }

        void keyadder()
        {
            keywords.Add(Category.SelectedItem.Text);
            keywords.Add(name.Text);
            foreach (String str in KeysIndi.Text.Split(' '))
            {
                keywords.Add(str);

            }
        }

        void Category_binder()
        {
            try
            {
                parent.Connection_establish();
                parent.cmd=new System.Data.SqlClient.SqlCommand("categories",Connections.con);
                parent.cmd.CommandType = System.Data.CommandType.StoredProcedure;
                Category.DataSource = parent.cmd.ExecuteReader();
                Category.DataBind();
            }
            catch
            {
                Response.Write("<script>alert('Internal issues please Try again later');</script>");
            }
            finally
            {
                parent.Connection_refuse();
            }
        }
        protected void Category_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Key_TextChanged(object sender, EventArgs e)
        {


            if (!keywords.Contains(Key.Text))
            {


                KeysIndi.Text += Key.Text + " ";

            }

            Key.Text = "";

        }

        protected void Update_Click(object sender, EventArgs e)
        {
            keyadder();

            if (IsValid)
            {
             
                        try
                        {
                            parent.Connection_establish();
                            pids = "Pro" + Connections.ids;
                            
                            parent.cmd = new SqlCommand("add_product", Connections.con);
                            parent.cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            (parent.cmd.Parameters.AddWithValue("@pid", SqlDbType.NVarChar)).Value = pids;
                            (parent.cmd.Parameters.AddWithValue("@name", SqlDbType.NVarChar)).Value = name.Text;
                            (parent.cmd.Parameters.AddWithValue("@desc", SqlDbType.NVarChar)).Value = details.Text;
                            (parent.cmd.Parameters.AddWithValue("@price", SqlDbType.NVarChar)).Value = price.Text;
                            (parent.cmd.Parameters.AddWithValue("@catid", SqlDbType.NVarChar)).Value = Category.SelectedItem.Value;
                            (parent.cmd.Parameters.AddWithValue("@stock", SqlDbType.NVarChar)).Value = Stock.Text;
                            (parent.cmd.Parameters.AddWithValue("@pimage", SqlDbType.NVarChar)).Value = s;
                       
                            if ((int)parent.cmd.ExecuteNonQuery() > 0)
                            {

                            }

                            Connections.ids++;
                            File_image.SaveAs(Server.MapPath("~/themes/images/product/") + File_image.FileName);

                        }
                        catch (Exception k)
                        { Response.Write(k.StackTrace); }
                        finally
                        {
                            parent.Connection_refuse();
                        }
                        foreach (String k in keywords)
                        {

                            keyInserter(k);
                        }
                        initials();

                        Response.Write("<script>alert('sucessfull inserted');</script>");
                  

                }
            }
        
        void keyInserter(String ki)
        {


            try
            {

                parent.Connection_establish();
                string keyid = "key" + Connections.key_id;
                parent.cmd = new SqlCommand("add_key", Connections.con);
                parent.cmd.CommandType = System.Data.CommandType.StoredProcedure;
                (parent.cmd.Parameters.AddWithValue("@pid", SqlDbType.NVarChar)).Value = pids;
                (parent.cmd.Parameters.AddWithValue("@kid", SqlDbType.NVarChar)).Value = keyid;
                (parent.cmd.Parameters.AddWithValue("@key", SqlDbType.NVarChar)).Value = ki;
             
                if ((int)parent.cmd.ExecuteNonQuery() > 0)
                {


                }

                Connections.key_id++;


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
            void initials()
        {
            keywords = new List<String>();
            KeysIndi.Text = "";
            Key.Text = "";
            name.Text = "";
            Stock.Text = "";
            price.Text = "";
            details.Text = "";

        }

    protected void File_image_DataBinding(object sender, EventArgs e)
    {
        if (File_image.HasFile)
        {
                
            if (checkFileType(File_image.FileName))
            {
                    File_image.SaveAs(Server.MapPath("~/themes/images/product/") + File_image.FileName);
                    s = "/themes/images/product/" + File_image.FileName;
                   
            }


            else
            {
                Response.Write("<script>alert('Select only jpg or png Image');</script>");
            }
        }
    }

        protected void Products_ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {

        }

        

        protected void Products_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            string bill;
            String id = e.CommandArgument.ToString();
            if (e.CommandName == "ADD")
            {
                if (Session["user"] != null)
                {
                    try
                    {
                        parent.Connection_establish();
                        parent.cmd = new SqlCommand("select price from product where pid=@pid", Connections.con);
                        parent.cmd.Parameters.AddWithValue("@pid", e.CommandArgument.ToString());
                        parent.dr = parent.cmd.ExecuteReader();
                        parent.dr.Read();
                        bill = parent.dr[0].ToString();

                        parent.Connection_refuse();
                        
                        parent.Connection_establish();
                        parent.cmd = new SqlCommand("insert into cart (cartid,pid,uid,quantity,bill) values(@cartid,@pid,@id,@quant,@bills);", Connections.con);
                        parent.cmd.Parameters.AddWithValue("@cartid", "Crt" + Connections.cart_id);
                        parent.cmd.Parameters.AddWithValue("@pid" ,e.CommandArgument.ToString());
                        parent.cmd.Parameters.AddWithValue("@id", ((List<string>)Session["user"])[0].ToString());
                        parent.cmd.Parameters.AddWithValue("@quant","1");
                        parent.cmd.Parameters.AddWithValue("@bills", bill);
                        if ((int)parent.cmd.ExecuteNonQuery()>0)
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
                    Response.Redirect("register.aspx");
                }

            }
            else if (e.CommandName == "Delete")
            {
                Response.Cookies["products"].Value = id;
                Response.Cookies["products"].Expires = DateTime.Now.AddDays(7);
                Response.Redirect("product_detail.aspx");
            }

           
        }

        private Boolean checkFileType(String s)
        {


            switch (Path.GetExtension(s).ToLower())
            {
                case ".jpg":
                case ".png":
                case ".jpeg":
                case ".gif": return true;
                default: return false;
            }
        }

        protected void DataPagerProducts_PreRender(object sender, EventArgs e)
        {
            try
            {
                parent.Connection_establish();
                parent.cmd = new SqlCommand("products", Connections.con);
                parent.cmd.CommandType = CommandType.StoredProcedure;
                parent.da.SelectCommand = parent.cmd;
                parent.da.Fill(parent.ds, "Products");
                Products.DataSource = parent.ds.Tables["Products"].DefaultView;
                Products.DataBind();

            }
            catch (Exception k)
            { Response.Write(k.StackTrace); }
            finally
            { parent.Connection_refuse(); }

        }
    }
}