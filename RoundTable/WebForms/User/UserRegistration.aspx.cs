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
    public partial class UserRegistration : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\RoundTableDB.mdf;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            //CheckPassword(txtPassword.Text);
        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            if (CheckUsername(txtUserID.Text.Trim()))
            {
                lblSignUpStatus.Text = "Username already exists. Please try another one.";
            }
            else
            {
                string defaultPicture = "~/ProfileImages/Default.png";
                string encryptedPassword = Encryptdata(txtPassword.Text);
                String saveUserData = "Insert into [dbo].[User] (userID, name, emailAddress, userPassword, profilePicture, Gender) VALUES (@UserID, @Name, @EmailAddress, @UserPassword, @ProfilePicture, @Gender)";
                SqlCommand cmdSaveUser = new SqlCommand(saveUserData, con);
                cmdSaveUser.Parameters.AddWithValue("@UserID", txtUserID.Text);
                cmdSaveUser.Parameters.AddWithValue("@Name", txtName.Text);
                cmdSaveUser.Parameters.AddWithValue("@EmailAddress", txtEmail.Text);
                cmdSaveUser.Parameters.AddWithValue("@UserPassword", encryptedPassword);
                cmdSaveUser.Parameters.AddWithValue("@ProfilePicture", defaultPicture);
                //cmdSaveUser.Parameters.AddWithValue("@ProfileDesc", null);
                cmdSaveUser.Parameters.AddWithValue("@Gender", "-");
                //cmdSaveUser.Parameters.AddWithValue("@DOB", null);
                con.Open();
                cmdSaveUser.ExecuteNonQuery();
                con.Close();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('You have signed up successfully!');window.location ='UserLogin.aspx';", true);
                //Response.Redirect("~/WebForms/User/UserLogin.aspx");
            }
        }

        private string Encryptdata(string password)
        {
            string strmsg = string.Empty;
            byte[] encode = new byte[password.Length];
            encode = Encoding.UTF8.GetBytes(password);
            strmsg = Convert.ToBase64String(encode);
            return strmsg;
        }

        //public void CheckPassword(string password)
        //{
        //    string noNumber = @"/\d /$";
        //    string noAlphabets = @"/[a - zA - Z] /$";
        //    string noSpecialChar = @"/[^a - zA - Z0 - 9\!\@\#\$\%\^\&\*\(\)\_\+]/";

        //    if (password.Length < 6)
        //    {
        //        lblPasswordValidation.Text = "Password must at least 6 characters.";
        //    }
        //    else if (password.Length > 50)
        //    {
        //        lblPasswordValidation.Text = "Password maximum length is only 50 characters.";
        //    }
        //    else if (Regex.IsMatch(password, noNumber) == false)
        //    {
        //        lblPasswordValidation.Text = "Password must contain at least 1 number.";
        //    }
        //    else if (Regex.IsMatch(password, noAlphabets) == false)
        //    {
        //        lblPasswordValidation.Text = "Password must contain at least 1 alphabet.";
        //    }
        //    else if (Regex.IsMatch(password, noSpecialChar) == false) 
        //    {
        //        lblPasswordValidation.Text = "Password must contain special character(s).";
        //    }
        //    else
        //    {
        //        lblPasswordValidation.Text = "";
        //    }
        //}

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