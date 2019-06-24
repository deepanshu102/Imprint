using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using WebApplication1.Models;
using System.Data.SqlClient;
using System.Data;

namespace WebApplication1
{
    public partial class SiteMaster : MasterPage
    {
        Connections parent;
        
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;

        protected void Page_Init(object sender, EventArgs e)
        {
            // The code below helps to protect against XSRF attacks
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Use the Anti-XSRF token from the cookie
                _antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                // Generate a new Anti-XSRF token and save to the cookie
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = _antiXsrfTokenValue
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }
                Response.Cookies.Set(responseCookie);
            }

            Page.PreLoad += master_Page_PreLoad;
        }

        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Set Anti-XSRF token
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
            }
            else
            {
                // Validate the Anti-XSRF token
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                    || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            parent = new Connections();
            try
            {
                parent.Connection_establish();
                parent.cmd = new SqlCommand("select * from super_category", Connections.con);
                parent.da.SelectCommand = parent.cmd;
                parent.da.Fill(parent.ds, "Super");
                ListView1.DataSource = parent.ds.Tables["Super"].DefaultView;
                ListView1.DataBind();
               /* parent.Connection_refuse();
                parent.dt = new DataTable();
                parent.dt = parent.ds.Tables["Super"];
                for (int i = 0; i < parent.dt.Rows.Count; i++)
                {
                    ListBox libox = new ListBox();
                    ListItemCollection obj = new ListItemCollection();
                                
                    try
                    {
                        parent.Connection_establish();
                        parent.cmd = new SqlCommand("Select * from category where s_catid=@1", Connections.con);
                        parent.cmd.Parameters.AddWithValue("@1", parent.dt.Rows[i][0]);
                        parent.dr = parent.cmd.ExecuteReader();
                        while (parent.dr.Read())
                        {

                            obj.Add(new ListItem(parent.dr["catname"].ToString(), parent.dr["cat_id"].ToString()));

                        }
                    }
                    catch
                    { }
                    finally
                    { parent.Connection_refuse(); }
                    

                }*/
              
            }
            catch (Exception k)
            {
                Response.Write(k);
            }
            finally
            { parent.Connection_refuse(); }
            
        }

        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }

        protected void logout_Click(object sender, EventArgs e)
        {
            parent = new Connections();
            try
            {
                parent.Connection_establish();

                parent.cmd = new SqlCommand("LoginTimeUpdater", Connections.con);
                parent.cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter property_name = parent.cmd.Parameters.Add("@id", SqlDbType.NVarChar);
                property_name.Value = ((List<string>)Session["user"])[0].ToString();
                if ((int)parent.cmd.ExecuteNonQuery() > 0)
                {
                    //Response.Write("<script>alert('Hello');</script>");//For Testing
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
            Session.Abandon();
            Response.Write("<script>history.go(-history.lenght);window.location='register.aspx';</script>");
        }
    }

}