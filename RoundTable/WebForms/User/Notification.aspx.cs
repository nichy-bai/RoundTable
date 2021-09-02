using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RoundTable.WebForms.User
{
    public partial class Notification : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\RoundTableDB.mdf;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["UserID"] != null)
            {
                
            }
            else
            {
                Response.Redirect("/WebForms/LoginError.aspx");
            }

            Repeater1.DataBind();
            if (Repeater1.Items.Count == 0)
            {
                noPost_lbl.Visible = true;
                notifications_div.Visible = false;
            }
            else
            {
                noPost_lbl.Visible = false;
                notifications_div.Visible = true;
            }
        }
        protected void postBody_btn_Command(object sender, CommandEventArgs e)
        {
            string postID = e.CommandArgument.ToString();
            Response.Redirect("../Discussion/DiscussionPost.aspx?p=" + postID.Substring(2, postID.Length - 2));
        }

        protected void delete_notification_btn_Command(object sender, CommandEventArgs e)
        {
            string notificationID = e.CommandArgument.ToString();

            con.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM Notification WHERE ID='" + notificationID + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect(Request.RawUrl);
        }

    }
}