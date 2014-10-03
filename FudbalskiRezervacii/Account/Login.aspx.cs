using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;


namespace test.Account
{
    public partial class Login : System.Web.UI.Page
    {
        private SqlConnection connect;
        protected void Page_Load(object sender, EventArgs e)
        {
            connect=new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename='D:\Fudbalski rezervacii\FudbalskiRezervacii\FudbalskiRezervacii\App_Data\ASPNETDB.MDF';Integrated Security=True;Connect Timeout=30;User Instance=True");
            RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            SqlCommand comm = new SqlCommand("select UserName from aspnet_Users where UserName=@UserName", connect);
            comm.Parameters.AddWithValue("@UserName", LoginUser.UserName);
            SqlDataReader read;
            try {
                connect.Open();
                int pom;
                read=comm.ExecuteReader();
                if (read.HasRows)
                {
                    
                    Session["korisnik"] = LoginUser.UserName;
                    if (LoginUser.RememberMeSet == true)
                    {
                        HttpCookie cookie = new HttpCookie("korisnik");
                        cookie["username"] = LoginUser.UserName;
                        cookie["password"] = LoginUser.Password;
                        cookie["date"] = DateTime.Now.ToString();
                        cookie.Expires = DateTime.Now.AddMinutes(15);
                        Response.Cookies.Add(cookie);
                    }
                   
                    Response.Redirect("~/Default.aspx");
                    
                }
                read.Close();
            }
            catch (Exception ex) { }
            finally { connect.Close(); }
        }

        protected void LoginUser_Authenticate(object sender, AuthenticateEventArgs e)
        {
            if (Session["korisnik"] != null) e.Authenticated = true;
        }

        protected void LoginUser_LoggedIn(object sender, EventArgs e)
        {
            

        }
    }
}
