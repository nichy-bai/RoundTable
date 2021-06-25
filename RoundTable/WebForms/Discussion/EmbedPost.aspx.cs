using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace RoundTable.WebForms.Discussion
{
    public partial class EmbedPost : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\RoundTableDB.mdf;Integrated Security=True");
        string postID;

        protected void Page_Load(object sender, EventArgs e)
        {
            postID = "DP" + Request.QueryString["p"];

            if (!IsPostBack)
            {
                string topic = null, tag = null;

                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT *,(SELECT COUNT(*) AS Expr1 FROM DiscussionLike WHERE (postID = Post.postID) AND (likeStatus = 1)) AS totalLike, (SELECT COUNT(*) AS Expr1 FROM DiscussionComment WHERE (postID = Post.postID)) AS totalComment, (SELECT COUNT(*) AS Expr1 FROM DiscussionView WHERE (postID = Post.postID)) AS totalView FROM Post INNER JOIN [User] ON Post.userID = [User].userID WHERE postID='" + postID + "'", con);
                cmd.CommandType = CommandType.Text;
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    userID_lbl.Text = dr["userID"].ToString();
                    userID_lbl.ToolTip = dr["name"].ToString();

                    postDate_lbl.Text = Convert.ToDateTime(dr["postDate"]).ToString("d MMMM yyyy");
                    postDate_lbl.ToolTip = Convert.ToDateTime(dr["postDate"]).ToString("dddd, dd/MM/yyyy h:mm:ss tt");

                    postTitle_lbl.Text = dr["postTitle"].ToString();
                    topic = dr["topicID"].ToString();
                    tag = dr["tagID"].ToString();
                    postLike_lbl.Text = dr["totalLike"].ToString();
                    postComment_lbl.Text = dr["totalComment"].ToString();
                    postView_lbl.Text = dr["totalView"].ToString();
                }
                con.Close();

                con.Open();
                SqlCommand cmd2 = new SqlCommand("SELECT topicName FROM Topic WHERE topicID='" + topic + "'", con);
                SqlCommand cmd4 = new SqlCommand("SELECT tagName FROM Tag WHERE tagID='" + tag + "'", con);
                SqlCommand cmd7 = new SqlCommand("SELECT COUNT(bookmarkID) FROM Bookmark WHERE postID='" + postID + "' AND (bookmarkStatus = 1)", con);
                SqlCommand cmd10 = new SqlCommand("SELECT editDate FROM Post WHERE postID='" + postID + "'", con);
                SqlCommand cmd11 = new SqlCommand("SELECT reportID FROM Report WHERE postID='" + postID + "'", con);
                SqlCommand cmd12 = new SqlCommand("SELECT profilePicture FROM [User] WHERE userID='" + userID_lbl.Text + "'", con);

                topicName_lbl.Text = cmd2.ExecuteScalar().ToString();

                tagName_lbl.Text = cmd4.ExecuteScalar().ToString();
                postBookmark_lbl.Text = cmd7.ExecuteScalar().ToString();

                object obj4 = cmd10.ExecuteScalar();

                if (obj4 != null && DBNull.Value != obj4)
                {
                    string editDate = Convert.ToDateTime(cmd10.ExecuteScalar()).ToString("d MMMM yyyy");
                    string editDateFull = Convert.ToDateTime(cmd10.ExecuteScalar()).ToString("dddd, dd/MM/yyyy h:mm:ss tt");

                    editDate_lbl.Text = "(Edited on " + editDate + ")";
                    editDate_lbl.ToolTip = "Edited on " + editDateFull;
                }

                object obj5 = cmd11.ExecuteScalar();

                if (obj5 != null && DBNull.Value != obj5)
                {
                    post_report_panel.Visible = true;
                    post_report_panel.ToolTip = "This discussion post was recently reported by other users.\nIt may contain harmful content that violates regulations.";
                }

                object obj6 = cmd12.ExecuteScalar();

                if (obj6 != null && DBNull.Value != obj6)
                {
                    post_user_img.ImageUrl = obj6.ToString();
                }

                con.Close();

                string url = Request.Url.AbsoluteUri.ToString().Replace("EmbedPost", "DiscussionPost");
                embed_btn.HRef = url;
            }
        }
    }
}