using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RoundTable.WebForms.Explore
{
    public partial class TrendingTopic : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\RoundTableDB.mdf;Integrated Security=True");
        string topicID;
        protected void Page_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand status = new SqlCommand("SELECT * FROM Topic WHERE topicID='TP" + Request.QueryString["topic"] + "'", con);
            if (status.ExecuteScalar() == null)
            {
                Response.Redirect("/WebForms/Error.aspx");
            }
            con.Close();



            topicID = "TP" + Request.QueryString["topic"];

            if (!this.IsPostBack)
            {
                this.BindRepeater();
                this.BindHeader();
            }
        }

        private void BindRepeater()
        {
            using (con)
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Post.postID, Post.postTitle, Post.postContent, Post.postDate, Post.postStatus, Post.editDate, Tag.tagID, Tag.tagName, Tag.tagDesc, Topic.topicID, Topic.topicName, Topic.topicDesc, [User].userID, [User].name, [User].profilePicture, (SELECT COUNT(*) AS Expr1 FROM DiscussionLike WHERE (postID = Post.postID) AND (likeStatus = 1)) AS totalLike, (SELECT COUNT(*) AS Expr1 FROM DiscussionComment WHERE (postID = Post.postID)) AS totalComment, (SELECT COUNT(*) AS Expr1 FROM Bookmark WHERE (postID = Post.postID) AND (bookmarkStatus = 1)) AS totalBookmark, (SELECT COUNT(*) AS Expr1 FROM DiscussionView WHERE (postID = Post.postID)) AS totalView FROM Post INNER JOIN Tag ON Post.tagID = Tag.tagID INNER JOIN Topic ON Post.topicID = Topic.topicID INNER JOIN [User] ON Post.userID = [User].userID WHERE (Post.postStatus = 1) AND Topic.topicID='" + topicID + "' ORDER BY Post.postDate DESC", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        Repeater1.DataSource = dt;
                        Repeater1.DataBind();

                        if (Repeater1.Items.Count == 0)
                        {
                            noPost_lbl.Visible = true;
                        }
                        else
                        {
                            noPost_lbl.Visible = false;
                        }

                    }
                }
            }
        }

        private void BindHeader()
        {
            String con = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(con))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT TOP(1) topicName, topicDesc FROM Topic WHERE topicID='" + topicID + "'", cnn))
                {
                    using (SqlDataAdapter DA = new SqlDataAdapter(cmd))
                    {
                        DataTable headerDT = new DataTable();
                        DA.Fill(headerDT);
                        Repeater2.DataSource = headerDT;
                        Repeater2.DataBind();
                    }
                }
            }
        }

        protected void postBody_btn_Command(object sender, CommandEventArgs e)
        {
            string postID = e.CommandArgument.ToString();
            //Response.Redirect("DiscussionPost.aspx?p=" + postID);
            Response.Redirect("../Discussion/DiscussionPost.aspx?p=" + postID.Substring(2, postID.Length - 2));
        }
    }
}