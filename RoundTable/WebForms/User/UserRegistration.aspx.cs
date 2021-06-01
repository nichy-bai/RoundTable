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
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\RoundTableDB.mdf;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            if (CheckUsername(txtUserID.Text.Trim()))
            {
                lblSignUpStatus.Text = "Username already exists. Please try another one.";
            }
            else
            {
                String saveUserData = "Insert into [dbo].[User] (userID, name, emailAddress, userPassword) VALUES (@UserID, @Name, @EmailAddress, @UserPassword)";
                SqlCommand cmdSaveUser = new SqlCommand(saveUserData, con);
                cmdSaveUser.Parameters.AddWithValue("@UserID", txtUserID.Text);
                cmdSaveUser.Parameters.AddWithValue("@Name", txtName.Text);
                cmdSaveUser.Parameters.AddWithValue("@EmailAddress", txtEmail.Text);
                cmdSaveUser.Parameters.AddWithValue("@UserPassword", txtPassword.Text);
                //cmdSaveUser.Parameters.AddWithValue("@Gender", rblGender.SelectedValue);
                //cmdSaveUser.Parameters.AddWithValue("@DOB", txtDOB.Text);
                con.Open();
                cmdSaveUser.ExecuteNonQuery();
                con.Close();
                Response.Redirect("~/WebForms/Discussion/Homepage.aspx");
            }
        }

        public bool CheckUsername(string username)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\RoundTableDB.mdf;Integrated Security=True";
                con.Open();
                using (SqlCommand cmd = new SqlCommand("Select * From [dbo].[User] Where UserID = @Username", con))
                {
                    cmd.Parameters.AddWithValue("@Username", txtUserID.Text);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        return true;
                    }  
                    else
                    {
                        return false;
                    }
                }
            }
        }

    }   
}