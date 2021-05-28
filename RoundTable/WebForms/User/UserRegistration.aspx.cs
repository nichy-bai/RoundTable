using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RoundTable.WebForms.User
{
    public partial class UserRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            String saveUserData = "Insert into [dbo].[User] (userID, name, emailAddress, userPassword, Gender, DOB) VALUES (@UserID, @Name, @EmailAddress, @UserPassword, @Gender, @DOB)";
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\RoundTableDB.mdf;Integrated Security=True");
            SqlCommand cmdSaveUser = new SqlCommand(saveUserData, con);
            cmdSaveUser.Parameters.AddWithValue("@UserID", txtUserID.Text);
            cmdSaveUser.Parameters.AddWithValue("@Name", txtName.Text);
            cmdSaveUser.Parameters.AddWithValue("@EmailAddress", txtEmail.Text);
            cmdSaveUser.Parameters.AddWithValue("@UserPassword", txtPassword.Text);
            cmdSaveUser.Parameters.AddWithValue("@Gender", rblGender.SelectedValue);
            cmdSaveUser.Parameters.AddWithValue("@DOB", txtDOB.Text);
            con.Open();
            cmdSaveUser.ExecuteNonQuery();
            con.Close();
            Response.Redirect("~/WebForms/Discussion/Homepage.aspx");
        }
    }
}