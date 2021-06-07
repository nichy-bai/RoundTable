using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace RoundTable.WebForms.Discussion
{
    public partial class MyDiscussion : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\RoundTableDB.mdf;Integrated Security=True");

        //To be modified
        string userID = "Shrimp";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindRepeater();
            }
        }

        private void BindRepeater()
        {
            using (con)
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Post.postID, Post.postTitle, Post.postContent, Post.postDate, Post.postStatus, Post.editDate, Tag.tagID, Tag.tagName, Tag.tagDesc, Topic.topicID, Topic.topicName, Topic.topicDesc, [User].userID, [User].name, [User].profilePicture, (SELECT COUNT(*) AS Expr1 FROM DiscussionLike WHERE (postID = Post.postID) AND (likeStatus = 1)) AS totalLike, (SELECT COUNT(*) AS Expr1 FROM DiscussionComment WHERE (postID = Post.postID) AND (commentStatus = 1)) AS totalComment, (SELECT COUNT(*) AS Expr1 FROM Bookmark WHERE (postID = Post.postID) AND (bookmarkStatus = 1)) AS totalBookmark, (SELECT COUNT(*) AS Expr1 FROM DiscussionView WHERE (postID = Post.postID)) AS totalView FROM Post INNER JOIN Tag ON Post.tagID = Tag.tagID INNER JOIN Topic ON Post.topicID = Topic.topicID INNER JOIN [User] ON Post.userID = [User].userID WHERE (Post.postStatus = 1) AND ([User].userID = '" + userID + "') ORDER BY Post.postDate DESC", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        Repeater1.DataSource = dt;
                        Repeater1.DataBind();
                    }
                }
            }
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (Repeater1.Items.Count < 1)
            {
                if (e.Item.ItemType == ListItemType.Footer)
                {
                    Label lblFooter = (Label)e.Item.FindControl("noPost_lbl");
                    lblFooter.Visible = true;
                }
            }
        }

        protected void postBody_btn_Command(object sender, CommandEventArgs e)
        {
            string postID = e.CommandArgument.ToString();
            Response.Redirect("../Discussion/DiscussionPost.aspx?p=" + postID.Substring(2, postID.Length - 2));
        }
    }
}