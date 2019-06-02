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
        Connections parent;
        static int ids = 0, key_id = 0;
        List<String> keywords = new List<String>();
        string pids;
        protected void Page_Load(object sender, EventArgs e)
        {
             parent = new Connections(); ;

            if (!IsPostBack)
            {
                Category_binder();
            }
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
                if (File_image.HasFile)
                {

                    if (checkFileType(File_image.FileName))
                    {

                        try
                        {
                            parent.Connection_establish();
                            pids = "Pro" + ids;
                            String s = "/themes/images/product/" + File_image.FileName;
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

                            ids++;
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
                    else
                    {
                        Response.Write("<script>alert('Select only jpg or png Image');</script>");
                    }


                }
            }
        }
        void keyInserter(String ki)
        {


            try
            {

                parent.Connection_establish();
                string keyid = "key" + key_id;
                parent.cmd = new SqlCommand("add_key", Connections.con);
                parent.cmd.CommandType = System.Data.CommandType.StoredProcedure;
                (parent.cmd.Parameters.AddWithValue("@pid", SqlDbType.NVarChar)).Value = pids;
                (parent.cmd.Parameters.AddWithValue("@kid", SqlDbType.NVarChar)).Value = keyid;
                (parent.cmd.Parameters.AddWithValue("@key", SqlDbType.NVarChar)).Value = ki;
               
                if ((int)parent.cmd.ExecuteNonQuery() > 0)
                {


                }

                key_id++;


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
    }
}