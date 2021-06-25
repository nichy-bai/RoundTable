using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text.RegularExpressions;

namespace RoundTable.WebForms.Bookmark
{
    public partial class Bookmark : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\RoundTableDB.mdf;Integrated Security=True");

        string bookmarkUserID, recommendPostID;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] != null)
            {
                bookmarkUserID = Session["UserID"].ToString();

                if (!this.IsPostBack)
                {
                    this.BindRepeater();
                }

                HttpCookie layoutCookie = Request.Cookies["layoutCookie"];
                HttpCookie fontCookie = Request.Cookies["fontCookie"];
                string layout, font;

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

                if (fontCookie != null)
                {
                    font = fontCookie["Font"];

                    if (font == "Small")
                    {
                        foreach (RepeaterItem item in Repeater1.Items)
                        {
                            Label title = (Label)item.FindControl("postTitle_lbl");
                            title.CssClass = title.CssClass.Replace("text-xl", "text-md");
                            title.CssClass = title.CssClass.Replace("text-2xl", "text-md");
                        }

                        Label title2 = (Label)recommend_panel.FindControl("recommend_postTitle_lbl");
                        title2.CssClass = title2.CssClass.Replace("text-xl", "text-md");
                        title2.CssClass = title2.CssClass.Replace("text-2xl", "text-md");
                    }
                    else if (font == "Medium")
                    {
                        foreach (RepeaterItem item in Repeater1.Items)
                        {
                            Label title = (Label)item.FindControl("postTitle_lbl");
                            title.CssClass = title.CssClass.Replace("text-md", "text-xl");
                            title.CssClass = title.CssClass.Replace("text-2xl", "text-xl");
                        }

                        Label title2 = (Label)recommend_panel.FindControl("recommend_postTitle_lbl");
                        title2.CssClass = title2.CssClass.Replace("text-md", "text-xl");
                        title2.CssClass = title2.CssClass.Replace("text-2xl", "text-xl");
                    }
                    else if (font == "Large")
                    {
                        foreach (RepeaterItem item in Repeater1.Items)
                        {
                            Label title = (Label)item.FindControl("postTitle_lbl");
                            title.CssClass = title.CssClass.Replace("text-md", "text-2xl");
                            title.CssClass = title.CssClass.Replace("text-xl", "text-2xl");
                        }

                        Label title2 = (Label)recommend_panel.FindControl("recommend_postTitle_lbl");
                        title2.CssClass = title2.CssClass.Replace("text-md", "text-2xl");
                        title2.CssClass = title2.CssClass.Replace("text-xl", "text-2xl");
                    }
                }
            }
            else
            {
                Response.Redirect("/WebForms/LoginError.aspx");
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('You must log in as a customer to access this feature.');window.location ='../User/UserLogin.aspx';", true);
            }

        }

        private void BindRepeater()
        {
            using (con)
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Bookmark_1.bookmarkID, Bookmark_1.bookmarkDate, Bookmark_1.postID, Bookmark_1.userID AS bookmarkUserID, Post_1.postTitle, Post_1.postContent, Post_1.editDate, Tag.tagID, Tag.tagName, Tag.tagDesc, Topic.topicID, Topic.topicName, Topic.topicDesc, User_1.name, User_1.profilePicture, Post_1.userID AS postUserID, Post_1.postDate, (SELECT COUNT(*) AS Expr1 FROM DiscussionLike WHERE (postID = Post_1.postID) AND (likeStatus = 1)) AS totalLike, (SELECT COUNT(*) AS Expr1 FROM DiscussionComment WHERE (postID = Post_1.postID)) AS totalComment, (SELECT COUNT(*) AS Expr1 FROM Bookmark WHERE (postID = Post_1.postID)) AS totalBookmark, (SELECT COUNT(*) AS Expr1 FROM DiscussionView WHERE (postID = Post_1.postID)) AS totalView, (SELECT profilePicture FROM [User] WHERE (userID = Post_1.userID)) AS postProfilePicture FROM Bookmark AS Bookmark_1 INNER JOIN Post AS Post_1 ON Bookmark_1.postID = Post_1.postID INNER JOIN [User] AS User_1 ON Bookmark_1.userID = User_1.userID INNER JOIN Tag ON Post_1.tagID = Tag.tagID INNER JOIN Topic ON Post_1.topicID = Topic.topicID WHERE (Bookmark_1.bookmarkStatus = 1) AND Bookmark_1.userID='" + bookmarkUserID + "' ORDER BY Bookmark_1.bookmarkDate DESC", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        Repeater1.DataSource = dt;
                        Repeater1.DataBind();
                    }
                }


                //Bind recommend post
                string topic = null, tag = null;

                con.Open();
                SqlCommand count = new SqlCommand("SELECT COUNT(postID) FROM Post", con);
                int totalPost = (int)count.ExecuteScalar();

                Random rnd = new Random();
                int randomPost = rnd.Next(1, totalPost+1);

                randomPost += 1000000000;

                recommendPostID = "DP" + randomPost.ToString();

                SqlCommand cmd1 = new SqlCommand("SELECT Post.postID, Post.postTitle, Post.postContent, Post.postDate, Post.postStatus, Post.editDate, Tag.tagID, Tag.tagName, Tag.tagDesc, Topic.topicID, Topic.topicName, Topic.topicDesc, [User].userID, [User].name, [User].profilePicture, (SELECT COUNT(*) AS Expr1 FROM DiscussionLike WHERE (postID = Post.postID) AND (likeStatus = 1)) AS totalLike, (SELECT COUNT(*) AS Expr1 FROM DiscussionComment WHERE (postID = Post.postID)) AS totalComment, (SELECT COUNT(*) AS Expr1 FROM Bookmark WHERE (postID = Post.postID) AND (bookmarkStatus = 1)) AS totalBookmark, (SELECT COUNT(*) AS Expr1 FROM DiscussionView WHERE (postID = Post.postID)) AS totalView FROM Post INNER JOIN Tag ON Post.tagID = Tag.tagID INNER JOIN Topic ON Post.topicID = Topic.topicID INNER JOIN [User] ON Post.userID = [User].userID WHERE (Post.postStatus = 1) AND postID='" + recommendPostID + "'", con);
                cmd1.CommandType = CommandType.Text;
                SqlDataReader dr = cmd1.ExecuteReader();

                while (dr.Read())
                {
                    recommend_username_lbl.Text = dr["userID"].ToString();
                    recommend_username_lbl.ToolTip = dr["name"].ToString();

                    recommend_date_lbl.Text = Convert.ToDateTime(dr["postDate"]).ToString("d MMMM yyyy");
                    recommend_date_lbl.ToolTip = Convert.ToDateTime(dr["postDate"]).ToString("dddd, dd/MM/yyyy h:mm:ss tt");

                    recommend_postID_lbl.Text = dr["postID"].ToString();
                    recommend_postTitle_lbl.Text = dr["postTitle"].ToString();
                    topic = dr["topicID"].ToString();
                    tag = dr["tagID"].ToString();
                    recommend_like_lbl.Text = dr["totalLike"].ToString();
                    recommend_comment_lbl.Text = dr["totalComment"].ToString();
                    recommend_bookmark_lbl.Text = dr["totalView"].ToString();
                }
                con.Close();

                con.Open();
                SqlCommand cmd2 = new SqlCommand("SELECT topicName FROM Topic WHERE topicID='" + topic + "'", con);
                SqlCommand cmd3 = new SqlCommand("SELECT topicDesc FROM Topic WHERE topicID='" + topic + "'", con);
                SqlCommand cmd4 = new SqlCommand("SELECT tagName FROM Tag WHERE tagID='" + tag + "'", con);
                SqlCommand cmd5 = new SqlCommand("SELECT tagDesc FROM Tag WHERE tagID='" + tag + "'", con);
                SqlCommand cmd6 = new SqlCommand("SELECT editDate FROM Post WHERE postID='" + recommendPostID + "'", con);
                SqlCommand cmd7 = new SqlCommand("SELECT profilePicture FROM [User] WHERE userID='" + recommend_username_lbl.Text + "'", con);

                recommend_topic_name.Text = cmd2.ExecuteScalar().ToString();
                recommend_topic_name.ToolTip = cmd3.ExecuteScalar().ToString();
                recommend_tag_name.Text = cmd4.ExecuteScalar().ToString();
                recommend_tag_name.ToolTip = cmd5.ExecuteScalar().ToString();

                object obj = cmd6.ExecuteScalar();

                if (obj != null && DBNull.Value != obj)
                {
                    string editDate = Convert.ToDateTime(cmd6.ExecuteScalar()).ToString("d MMMM yyyy");
                    string editDateFull = Convert.ToDateTime(cmd6.ExecuteScalar()).ToString("dddd, dd/MM/yyyy h:mm:ss tt");

                    recommend_edit_date_lbl.Text = "(Edited on " + editDate + ")";
                    recommend_edit_date_lbl.ToolTip = "Edited on " + editDateFull;
                }

                object obj6 = cmd7.ExecuteScalar();

                if (obj6 != null && DBNull.Value != obj6)
                {
                    recommend_user_img.ImageUrl = obj6.ToString();
                }

                con.Close();
            }
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (Repeater1.Items.Count < 1)
            {
                if (e.Item.ItemType == ListItemType.Footer)
                {
                    Label lblFooter = (Label)e.Item.FindControl("noBookmark_lbl");
                    Label lblFooter2 = (Label)e.Item.FindControl("noBookmark_lbl_2");
                    LinkButton lblFooter3 = (LinkButton)e.Item.FindControl("homepage_btn");
                    Panel lblFooter4 = (Panel)e.Item.FindControl("noBookmark_panel");
                    lblFooter.Visible = true;
                    lblFooter2.Visible = true;
                    lblFooter3.Visible = true;
                    lblFooter4.Visible = true;
                    recommend_lbl.Visible = true;
                    recommend_panel.Visible = true;
                }
            }

            foreach (RepeaterItem item in Repeater1.Items)
            {
                Label lbl = item.FindControl("postContent_lbl") as Label;
                lbl.Text = Regex.Replace(lbl.Text, "<[a-zA-Z]\\s+.*>\\s+.*\\s+<\\/a>", string.Empty);
            }
        }

        protected void bookmarkBody_btn_Command(object sender, CommandEventArgs e)
        {
            string postID = e.CommandArgument.ToString();
            Response.Redirect("../Discussion/DiscussionPost.aspx?p=" + postID.Substring(2, postID.Length - 2));
        }

        protected void recommendBody_btn_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("../Discussion/DiscussionPost.aspx?p=" + recommend_postID_lbl.Text.Substring(2, recommend_postID_lbl.Text.Length - 2));
        }

        protected void remove_bookmark_btn_Command(object sender, CommandEventArgs e)
        {
            if (Repeater1.Items.Count > 0)
            {
                bool bookmarkStatus = false;

                SqlCommand update = new SqlCommand("UPDATE Bookmark SET bookmarkStatus='" + bookmarkStatus + "' WHERE userID='" + bookmarkUserID + "'", con);
                con.Open();
                update.ExecuteNonQuery();
                con.Close();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
                "alert('Clear all bookmarks successfully!'); window.location='" +
                Request.ApplicationPath + "../WebForms/Bookmark/Bookmark.aspx';", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You have not bookmarked any posts')", true);
            }
        }

        protected void homepage_btn_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("../Discussion/Homepage.aspx");
        }
    }
}