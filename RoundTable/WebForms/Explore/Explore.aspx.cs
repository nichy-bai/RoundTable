using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RoundTable.WebForms.Explore
{
    public partial class Explore : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\RoundTableDB.mdf;Integrated Security=True");
       

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if(Session["UserID"] != null)
                {
                    recommendations_div.Visible = true;
                    this.BindRepeater();
                }
                else
                {
                    recommendations_div.Visible = false;
                }
            }
        }

        protected void post_btn_Command(object sender, CommandEventArgs e)
        {
            if (Session["UserID"] != null)
            {
                string postID = e.CommandArgument.ToString();
                Response.Redirect("../Discussion/DiscussionPost.aspx?p=" + postID.Substring(2, postID.Length - 2));
            }
            else
            {
                Response.Redirect("/WebForms/LoginError.aspx");
            }
        }

        protected void trendingPost_btn_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("../Explore/TrendingDiscussion.aspx");
        }

        protected void topic_btn_Command(object sender, CommandEventArgs e)
        {
            string topicID = e.CommandArgument.ToString();
            Response.Redirect("../Explore/TrendingTopic.aspx?topic=" + topicID.Substring(2, topicID.Length - 2));
        }

        protected void trendingTopic_btn_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("../Explore/TrendingTopic.aspx");
        }

        private void BindRepeater()
        {
            using (con)
            {
                
                var rand = new Random();

                string userID = Session["UserID"].ToString();

                using (SqlCommand cmd = new SqlCommand("SELECT TOP (3) Post.postID, Post.postTitle, Post.postContent, Post.postDate, Post.postStatus, Post.editDate, Tag.tagID, Tag.tagName, Tag.tagDesc, Topic.topicID, Topic.topicName, Topic.topicDesc, [User].userID, [User].name, [User].profilePicture, (SELECT COUNT(*) AS Expr1 FROM DiscussionLike WHERE (postID = Post.postID) AND (likeStatus = 1)) AS totalLike, (SELECT COUNT(*) AS Expr1 FROM DiscussionComment WHERE (postID = Post.postID)) AS totalComment, (SELECT COUNT(*) AS Expr1 FROM Bookmark WHERE (postID = Post.postID) AND (bookmarkStatus = 1)) AS totalBookmark, (SELECT COUNT(*) AS Expr1 FROM DiscussionView WHERE (postID = Post.postID)) AS totalView FROM Post INNER JOIN Tag ON Post.tagID = Tag.tagID INNER JOIN Topic ON Post.topicID = Topic.topicID INNER JOIN [User] ON Post.userID = [User].userID WHERE (Post.postStatus = 1) AND Post.userID <>'" + userID + "'ORDER BY NEWID()", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        Repeater4.DataSource = dt;
                        Repeater4.DataBind();
                    }
                }
            }
        }
    }
}