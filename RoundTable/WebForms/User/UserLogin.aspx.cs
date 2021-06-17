using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RoundTable.WebForms.User
{
    public partial class UserLogin : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\RoundTableDB.mdf;Integrated Security=True");
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["UserID"] != null)
            {
                Response.Redirect("~/WebForms/Discussion/Homepage.aspx");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            con.Open();
            String getUser = "Select count(*) from [dbo].[User] where userID = @Username AND userPassword = @Password";
            SqlCommand cmdGetUser = new SqlCommand(getUser, con);
            cmdGetUser.Parameters.AddWithValue("@Username", txtUserID.Text);
            cmdGetUser.Parameters.AddWithValue("@Password", Encryptdata(txtPassword.Text));

            String output = cmdGetUser.ExecuteScalar().ToString();

            if (output == "1")
            {
                Session["UserID"] = txtUserID.Text;
                Response.Redirect("~/WebForms/Discussion/Homepage.aspx");
            }
            else
            {
                lblLoginStatus.Text = "Invalid Username or Password";
            }
            con.Close();
        }

        protected void btnForgotPassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/WebForms/User/ForgotPassword.aspx");
        }

        private string Encryptdata(string password)
        {
            string strmsg = string.Empty;
            byte[] encode = new byte[password.Length];
            encode = Encoding.UTF8.GetBytes(password);
            strmsg = Convert.ToBase64String(encode);
            return strmsg;
        }
    }
}