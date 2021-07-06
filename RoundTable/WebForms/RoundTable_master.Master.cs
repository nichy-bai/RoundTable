using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace RoundTable.WebForms
{
    public partial class RoundTable_master : System.Web.UI.MasterPage
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\RoundTableDB.mdf;Integrated Security=True");
        string userID;

        protected void Page_Load(object sender, EventArgs e)
        {
            //to be modified
            if (Session["UserID"] != null)
            {
                userID = Session["UserID"].ToString();
            }

            string path = HttpContext.Current.Request.Url.AbsolutePath;

            if (path.Contains("Discussion/"))
            {
                nav_home_btn.Attributes.Add("Class", "text-indigo-600");
            }
            else if (path.Contains("Bookmark/"))
            {
                nav_bookmark_btn.Attributes.Add("Class", "text-indigo-600");
            }
            else if (path.Contains("Explore/"))
            {
                nav_explore_btn.Attributes.Add("Class", "text-indigo-600");
            }
            else if (path.Contains("Search/"))
            {
                nav_search_btn.Attributes.Add("Class", "text-indigo-600");
            }
            else if (path.Contains("Support/"))
            {
                nav_support_btn.Attributes.Add("Class", "text-indigo-600");
            }
            else if (path.Contains("User/"))
            {
                nav_profile_btn.CssClass = nav_profile_btn.CssClass.Replace("border-transparent", "border-indigo-500");
            }

            SqlCommand cmd = new SqlCommand("SELECT profilePicture FROM [User] WHERE userID='" + userID + "'", con);
            con.Open();

            object obj = cmd.ExecuteScalar();

            if (obj != null && DBNull.Value != obj)
            {
                post_user_img.ImageUrl = obj.ToString();
                post_user_img_2.ImageUrl = obj.ToString();
            }

            con.Close();
        }

        protected void post_btn_Command(object sender, CommandEventArgs e)
        {
            string postID = e.CommandArgument.ToString();
            //Response.Redirect("DiscussionPost.aspx?p=" + postID);
            Response.Redirect("../Discussion/DiscussionPost.aspx?p=" + postID.Substring(2, postID.Length - 2));
        }

        protected void topic_btn_Command(object sender, CommandEventArgs e)
        {
            string topicID = e.CommandArgument.ToString();
            Response.Redirect("../Explore/TrendingTopic.aspx?topic=" + topicID.Substring(2, topicID.Length - 2));
        }
    }
}