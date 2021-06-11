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

            HttpCookie layoutCookie = Request.Cookies["layoutCookie"];
            string layout;

            if (layoutCookie != null)
            {
                layout = layoutCookie["Layout"];

                if (layout == "Classic")
                {
                    foreach (RepeaterItem item in Repeater1.Items)
                    {
                        Panel p1 = (Panel)item.FindControl("post_panel");
                        Panel p2 = (Panel)item.FindControl("user_detail_panel");
                        Panel p3 = (Panel)item.FindControl("compact_user_panel");
                        Panel p4 = (Panel)item.FindControl("tag_panel");
                        Panel p5 = (Panel)item.FindControl("cozy_content_panel");
                        p1.CssClass = "mt-0 m-5 bg-white rounded-lg flex flex-col shadow-md h-auto dark:bg-dark-200 dark:text-gray-200 transition ease-in-out duration-1000";
                        p2.Visible = true;
                        p3.Visible = false;
                        p4.Visible = true;
                        p5.Visible = false;
                    }
                }
                else if (layout == "Compact")
                {
                    foreach (RepeaterItem item in Repeater1.Items)
                    {
                        Panel p1 = (Panel)item.FindControl("post_panel");
                        Panel p2 = (Panel)item.FindControl("user_detail_panel");
                        Panel p3 = (Panel)item.FindControl("compact_user_panel");
                        Panel p4 = (Panel)item.FindControl("tag_panel");
                        Panel p5 = (Panel)item.FindControl("cozy_content_panel");
                        p1.CssClass = "mx-5 bg-white border-b-4 rounded-lg flex flex-col shadow-md h-auto dark:bg-dark-200 dark:text-gray-200 transition ease-in-out duration-1000";
                        p2.Visible = false;
                        p3.Visible = true;
                        p4.Visible = false;
                        p5.Visible = false;
                    }
                }
                else if (layout == "Cozy")
                {
                    foreach (RepeaterItem item in Repeater1.Items)
                    {
                        Panel p1 = (Panel)item.FindControl("post_panel");
                        Panel p2 = (Panel)item.FindControl("user_detail_panel");
                        Panel p3 = (Panel)item.FindControl("compact_user_panel");
                        Panel p4 = (Panel)item.FindControl("tag_panel");
                        Panel p5 = (Panel)item.FindControl("cozy_content_panel");
                        p1.CssClass = "mt-0 m-5 mb-8 bg-white rounded-lg flex flex-col shadow-md h-auto dark:bg-dark-200 dark:text-gray-200 transition ease-in-out duration-1000";
                        p2.Visible = true;
                        p3.Visible = false;
                        p4.Visible = true;
                        p5.Visible = true;
                    }
                }
            }
        }

        private void BindRepeater()
        {
            using (con)
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Bookmark_1.bookmarkID, Bookmark_1.bookmarkDate, Bookmark_1.postID, Bookmark_1.userID AS bookmarkUserID, Post.postTitle, Post.postContent, Post.editDate, Tag.tagID, Tag.tagName, Tag.tagDesc, Topic.topicID, Topic.topicName, Topic.topicDesc, [User].name, [User].profilePicture, Post.userID AS postUserID, Post.postDate, (SELECT COUNT(*) AS Expr1 FROM DiscussionLike WHERE (postID = Post.postID) AND (likeStatus = 1)) AS totalLike, (SELECT COUNT(*) AS Expr1 FROM DiscussionComment WHERE (postID = Post.postID)) AS totalComment, (SELECT COUNT(*) AS Expr1 FROM Bookmark WHERE (postID = Post.postID)) AS totalBookmark, (SELECT COUNT(*) AS Expr1 FROM DiscussionView WHERE (postID = Post.postID)) AS totalView FROM Bookmark AS Bookmark_1 INNER JOIN Post ON Bookmark_1.postID = Post.postID INNER JOIN [User] ON Bookmark_1.userID = [User].userID INNER JOIN Tag ON Post.tagID = Tag.tagID INNER JOIN Topic ON Post.topicID = Topic.topicID WHERE Bookmark_1.bookmarkStatus=1 AND Bookmark_1.userID='" + bookmarkUserID + "' ORDER BY Bookmark_1.bookmarkDate DESC", con))
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
                    Label lblFooter = (Label)e.Item.FindControl("noBookmark_lbl");
                    lblFooter.Visible = true;
                }
            }
        }

        protected void bookmarkBody_btn_Command(object sender, CommandEventArgs e)
        {
            string postID = e.CommandArgument.ToString();
            //Response.Redirect("../Discussion/DiscussionPost.aspx?p=" + postID);
            Response.Redirect("../Discussion/DiscussionPost.aspx?p=" + postID.Substring(2, postID.Length - 2));
        }
    }
}