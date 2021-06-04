using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace RoundTable.WebForms.Bookmark
{
    public partial class Bookmark : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\RoundTableDB.mdf;Integrated Security=True");

        //To be modified
        string bookmarkUserID = "Shrimp";

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
                using (SqlCommand cmd = new SqlCommand("SELECT Bookmark_1.bookmarkID, Bookmark_1.bookmarkDate, Bookmark_1.postID, Bookmark_1.userID AS bookmarkUserID, Post.postTitle, Post.postContent, Tag.tagID, Tag.tagName, Tag.tagDesc, Topic.topicID, Topic.topicName, Topic.topicDesc, [User].name, [User].profilePicture, Post.userID AS postUserID, Post.postDate, (SELECT COUNT(*) AS Expr1 FROM DiscussionLike WHERE (postID = Post.postID) AND (likeStatus = 1)) AS totalLike, (SELECT COUNT(*) AS Expr1 FROM DiscussionComment WHERE (postID = Post.postID)) AS totalComment, (SELECT COUNT(*) AS Expr1 FROM Bookmark WHERE (postID = Post.postID)) AS totalBookmark FROM Bookmark AS Bookmark_1 INNER JOIN Post ON Bookmark_1.postID = Post.postID INNER JOIN [User] ON Bookmark_1.userID = [User].userID INNER JOIN Tag ON Post.tagID = Tag.tagID INNER JOIN Topic ON Post.topicID = Topic.topicID WHERE Bookmark_1.bookmarkStatus=1 AND Bookmark_1.userID='" + bookmarkUserID + "' ORDER BY Bookmark_1.bookmarkDate DESC", con))
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

        protected void bookmarkBody_btn_Command(object sender, CommandEventArgs e)
        {
            string postID = e.CommandArgument.ToString();
            Response.Redirect("../Discussion/DiscussionPost.aspx?p=" + postID);
            //Response.Redirect("DiscussionPost.aspx?p=" + postID.Substring(2, postID.Length - 2));
        }
    }
}