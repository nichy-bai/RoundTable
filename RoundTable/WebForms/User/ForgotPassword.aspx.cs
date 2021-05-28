using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
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
            
        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            string inputVerificationCode = txtVerificationCode.Text;

            if(inputVerificationCode.CompareTo(verificationCode)== 0)
            {
                String con = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                SqlConnection forgetPasswordCon = new SqlConnection(con);
                forgetPasswordCon.Open();

                forgetPasswordCon.Open();
                string selectUser = "Select * from [dbo].[User] where userID = @Username";
                SqlCommand cmdSelectUser = new SqlCommand(selectUser, forgetPasswordCon);
                cmdSelectUser.Parameters.AddWithValue("@Username", txtUserID.Text);

                SqlDataReader dtrUser = cmdSelectUser.ExecuteReader();
                if (dtrUser.HasRows)
                {
                    using (SqlConnection cnn = new SqlConnection(con))
                    {
                        using (SqlCommand cmd = new SqlCommand("UPDATE [dbo].[User] SET userPassword = @Password where userID = @Username", cnn))
                        {
                            cmd.Parameters.AddWithValue("@Username", txtUserID.Text);
                            cmd.Parameters.AddWithValue("@Password", txtNewPassword.Text);
                            cnn.Open();
                            cmd.ExecuteNonQuery();
                            cnn.Close();
                        }
                    }

                }

            }
        }

        
    }
}