using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RoundTable.WebForms.User
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        static string verificationCode;
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\RoundTableDB.mdf;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnGetCode_Click(object sender, EventArgs e)
        {
            string email;
            con.Open();
            SqlCommand cmdEmail = new SqlCommand("Select emailAddress FROM [dbo].[User] WHERE UserID = @Username;", con);
            cmdEmail.Parameters.AddWithValue("@Username", txtUserID.Text);
            SqlDataReader dtrUser = cmdEmail.ExecuteReader();

            if (dtrUser.HasRows && txtNewPassword.Text == txtConfirmPassword.Text)
            {
                con.Close();
                con.Open();
                SqlCommand cmd = new SqlCommand("Select emailAddress FROM [dbo].[User] WHERE UserID = @Username;", con);


                cmd.Parameters.AddWithValue("@Username", txtUserID.Text);
                email = Convert.ToString(cmdEmail.ExecuteScalar());
                con.Close();




                if (txtUserID.Text != "")
                {
                    //new MailMessage(From, To)
                    MailMessage mailMessage = new MailMessage("roundtable.cs@gmail.com", email);

                    Random rnd = new Random();
                    int code = rnd.Next(1000, 9999);
                    verificationCode = code.ToString();

                    mailMessage.Subject = "Verification Code";
                    mailMessage.Body = "Your validation code to reset password is " + verificationCode; ;
                    mailMessage.BodyEncoding = Encoding.UTF8;
                    mailMessage.IsBodyHtml = true;
                    SmtpClient smtpClient = new SmtpClient();
                    try
                    {
                        smtpClient.Send(mailMessage);
                        lblGetCode.Text = "We have sent you a verification code, please check your email.";
                    }

                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }


            }
            else if (dtrUser.HasRows == false)
            {
                con.Close();
                System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
                string scriptKey = "ErrorMessage";

                javaScript.Append("var userConfirmation = window.confirm('" + "Username does not exist." + "');\n");

                ClientScript.RegisterStartupScript(this.GetType(), scriptKey, javaScript.ToString(), true);
            }


        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            string inputVerificationCode = txtVerificationCode.Text;

            if(inputVerificationCode.CompareTo(verificationCode)== 0)
            {
                string selectUser = "Select * from [dbo].[User] where userID = @Username";
                SqlCommand cmdSelectUser = new SqlCommand(selectUser, con);
                cmdSelectUser.Parameters.AddWithValue("@Username", txtUserID.Text);

                string updatePassword = "Update [dbo].[User] Set userPassword = @UserPassword Where userID = @Username";
                SqlCommand cmdUpdatePassword = new SqlCommand(updatePassword, con);
                cmdUpdatePassword.Parameters.AddWithValue("@Username", txtUserID.Text);
                cmdUpdatePassword.Parameters.AddWithValue("@UserPassword", txtNewPassword.Text);
                con.Open();
                cmdSelectUser.ExecuteNonQuery();
                cmdUpdatePassword.ExecuteNonQuery();
                con.Close();

                verificationCode = "";
                //System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
                //string scriptKey = "SuccessMessage";
                //javaScript.Append("var userConfirmation = window.confirm('" + "Password successfully updated!" + "');\n");
                //javaScript.Append("window.location='login.aspx';");

                //ClientScript.RegisterStartupScript(this.GetType(), scriptKey, javaScript.ToString(), true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Password successfully updated!');window.location ='UserLogin.aspx';", true);

            }
            else
            {
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Invalid verification code.');window.location ='UserLogin.aspx';", true);
                Response.Write("<script> alert('Invalid verification code.') </script>");

                //System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
                //string scriptKey = "ErrorMessage";

                //javaScript.Append("var userConfirmation = window.confirm('" + "Invalid verification code." + "');\n");

                //ClientScript.RegisterStartupScript(this.GetType(), scriptKey, javaScript.ToString(), true);
            }
        }

        
    }
}