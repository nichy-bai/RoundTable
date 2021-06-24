using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;

namespace RoundTable.WebForms.Discussion
{
    public partial class Homepage : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\RoundTableDB.mdf;Integrated Security=True;Timeout=60");
        string userID, likeID;
        HttpCookie contentCookie = new HttpCookie("contentCookie");
        HttpCookie layoutCookie = new HttpCookie("layoutCookie");
        HttpCookie fontCookie = new HttpCookie("fontCookie");

        protected void Page_Load(object sender, EventArgs e)
        {
            //To be modified
            userID = "Shrimp";


            HttpCookie contentCookie = Request.Cookies["contentCookie"];
            HttpCookie layoutCookie = Request.Cookies["layoutCookie"];
            HttpCookie fontCookie = Request.Cookies["fontCookie"];
            string content, layout, font;

            if(contentCookie != null)
            {
                content = contentCookie["Content"];

                if (content == "Recent")
                {
                    SqlDataSource1.SelectCommand = "SELECT Post.postID, Post.postTitle, Post.postContent, Post.postDate, Post.postStatus, Post.editDate, Tag.tagID, Tag.tagName, Tag.tagDesc, Topic.topicID, Topic.topicName, Topic.topicDesc, [User].userID, [User].name, [User].profilePicture, (SELECT COUNT(*) AS Expr1 FROM DiscussionLike WHERE (postID = Post.postID) AND (likeStatus = 1)) AS totalLike, (SELECT COUNT(*) AS Expr1 FROM DiscussionComment WHERE (postID = Post.postID)) AS totalComment, (SELECT COUNT(*) AS Expr1 FROM Bookmark WHERE (postID = Post.postID) AND (bookmarkStatus = 1)) AS totalBookmark, (SELECT COUNT(*) AS Expr1 FROM DiscussionView WHERE (postID = Post.postID)) AS totalView FROM Post INNER JOIN Tag ON Post.tagID = Tag.tagID INNER JOIN Topic ON Post.topicID = Topic.topicID INNER JOIN [User] ON Post.userID = [User].userID WHERE (Post.postStatus = 1) ORDER BY Post.postDate DESC";
                    SqlDataSource1.Select(DataSourceSelectArguments.Empty);
                    SqlDataSource1.DataBind();
                    Repeater1.DataBind();

                    content_recent_btn.CssClass = content_recent_btn.CssClass.Replace("text-gray-800", "text-indigo-600");
                    content_recent_btn.CssClass = content_recent_btn.CssClass.Replace("bg-white", "bg-gray-200");
                    content_featured_btn.CssClass = content_featured_btn.CssClass.Replace("text-indigo-600", "text-gray-800");
                    content_featured_btn.CssClass = content_featured_btn.CssClass.Replace("bg-gray-200", "bg-white");
                    content_trending_btn.CssClass = content_trending_btn.CssClass.Replace("text-indigo-600", "text-gray-800");
                    content_trending_btn.CssClass = content_trending_btn.CssClass.Replace("bg-gray-200", "bg-white");
                }
                else if(content == "Featured")
                {
                    SqlDataSource1.SelectCommand = "SELECT Post.postID, Post.postTitle, Post.postContent, Post.postDate, Post.postStatus, Post.editDate, Tag.tagID, Tag.tagName, Tag.tagDesc, Topic.topicID, Topic.topicName, Topic.topicDesc, [User].userID, [User].name, [User].profilePicture, (SELECT COUNT(*) AS Expr1 FROM DiscussionLike WHERE (postID = Post.postID) AND (likeStatus = 1)) AS totalLike, (SELECT COUNT(*) AS Expr1 FROM DiscussionComment WHERE (postID = Post.postID)) AS totalComment, (SELECT COUNT(*) AS Expr1 FROM Bookmark WHERE (postID = Post.postID) AND (bookmarkStatus = 1)) AS totalBookmark, (SELECT COUNT(*) AS Expr1 FROM DiscussionView WHERE (postID = Post.postID)) AS totalView FROM Post INNER JOIN Tag ON Post.tagID = Tag.tagID INNER JOIN Topic ON Post.topicID = Topic.topicID INNER JOIN [User] ON Post.userID = [User].userID WHERE (Post.postStatus = 1) ORDER BY totalLike DESC, totalComment DESC";
                    SqlDataSource1.Select(DataSourceSelectArguments.Empty);
                    SqlDataSource1.DataBind();
                    Repeater1.DataBind();

                    content_recent_btn.CssClass = content_recent_btn.CssClass.Replace("text-indigo-600", "text-gray-800");
                    content_recent_btn.CssClass = content_recent_btn.CssClass.Replace("bg-gray-200", "bg-white");
                    content_featured_btn.CssClass = content_featured_btn.CssClass.Replace("text-gray-800", "text-indigo-600");
                    content_featured_btn.CssClass = content_featured_btn.CssClass.Replace("bg-white", "bg-gray-200");
                    content_trending_btn.CssClass = content_trending_btn.CssClass.Replace("text-indigo-600", "text-gray-800");
                    content_trending_btn.CssClass = content_trending_btn.CssClass.Replace("bg-gray-200", "bg-white");
                }
                else if(content == "Trending")
                {
                    SqlDataSource1.SelectCommand = "SELECT Post.postID, Post.postTitle, Post.postContent, Post.postDate, Post.postStatus, Post.editDate, Tag.tagID, Tag.tagName, Tag.tagDesc, Topic.topicID, Topic.topicName, Topic.topicDesc, [User].userID, [User].name, [User].profilePicture, (SELECT COUNT(*) AS Expr1 FROM DiscussionLike WHERE (postID = Post.postID) AND (likeStatus = 1)) AS totalLike, (SELECT COUNT(*) AS Expr1 FROM DiscussionComment WHERE (postID = Post.postID)) AS totalComment, (SELECT COUNT(*) AS Expr1 FROM Bookmark WHERE (postID = Post.postID) AND (bookmarkStatus = 1)) AS totalBookmark, (SELECT COUNT(*) AS Expr1 FROM DiscussionView WHERE (postID = Post.postID)) AS totalView FROM Post INNER JOIN Tag ON Post.tagID = Tag.tagID INNER JOIN Topic ON Post.topicID = Topic.topicID INNER JOIN [User] ON Post.userID = [User].userID WHERE (Post.postStatus = 1) ORDER BY totalView DESC";
                    SqlDataSource1.Select(DataSourceSelectArguments.Empty);
                    SqlDataSource1.DataBind();
                    Repeater1.DataBind();

                    content_recent_btn.CssClass = content_recent_btn.CssClass.Replace("text-indigo-600", "text-gray-800");
                    content_recent_btn.CssClass = content_recent_btn.CssClass.Replace("bg-gray-200", "bg-white");
                    content_featured_btn.CssClass = content_featured_btn.CssClass.Replace("text-indigo-600", "text-gray-800");
                    content_featured_btn.CssClass = content_featured_btn.CssClass.Replace("bg-gray-200", "bg-white");
                    content_trending_btn.CssClass = content_trending_btn.CssClass.Replace("text-gray-800", "text-indigo-600");
                    content_trending_btn.CssClass = content_trending_btn.CssClass.Replace("bg-white", "bg-gray-200");
                }
            }

            if(layoutCookie != null)
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

                    layout_classic_btn.CssClass = layout_classic_btn.CssClass.Replace("text-gray-800", "text-indigo-600");
                    layout_classic_btn.CssClass = layout_classic_btn.CssClass.Replace("bg-white", "bg-gray-200");
                    layout_compact_btn.CssClass = layout_compact_btn.CssClass.Replace("text-indigo-600", "text-gray-800");
                    layout_compact_btn.CssClass = layout_compact_btn.CssClass.Replace("bg-gray-200", "bg-white");
                    layout_cozy_btn.CssClass = layout_cozy_btn.CssClass.Replace("text-indigo-600", "text-gray-800");
                    layout_cozy_btn.CssClass = layout_cozy_btn.CssClass.Replace("bg-gray-200", "bg-white");
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

                    layout_classic_btn.CssClass = layout_classic_btn.CssClass.Replace("text-indigo-600", "text-gray-800");
                    layout_classic_btn.CssClass = layout_classic_btn.CssClass.Replace("bg-gray-200", "bg-white");
                    layout_compact_btn.CssClass = layout_compact_btn.CssClass.Replace("text-gray-800", "text-indigo-600");
                    layout_compact_btn.CssClass = layout_compact_btn.CssClass.Replace("bg-white", "bg-gray-200");
                    layout_cozy_btn.CssClass = layout_cozy_btn.CssClass.Replace("text-indigo-600", "text-gray-800");
                    layout_cozy_btn.CssClass = layout_cozy_btn.CssClass.Replace("bg-gray-200", "bg-white");
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

                    layout_classic_btn.CssClass = layout_classic_btn.CssClass.Replace("text-indigo-600", "text-gray-800");
                    layout_classic_btn.CssClass = layout_classic_btn.CssClass.Replace("bg-gray-200", "bg-white");
                    layout_compact_btn.CssClass = layout_compact_btn.CssClass.Replace("text-indigo-600", "text-gray-800");
                    layout_compact_btn.CssClass = layout_compact_btn.CssClass.Replace("bg-gray-200", "bg-white");
                    layout_cozy_btn.CssClass = layout_cozy_btn.CssClass.Replace("text-gray-800", "text-indigo-600");
                    layout_cozy_btn.CssClass = layout_cozy_btn.CssClass.Replace("bg-white", "bg-gray-200");
                }
            }

            if(fontCookie != null)
            {
                font = fontCookie["Font"];

                if(font == "Small")
                {
                    foreach (RepeaterItem item in Repeater1.Items)
                    {
                        Label title = (Label)item.FindControl("postTitle_lbl");
                        title.CssClass = title.CssClass.Replace("text-xl", "text-md");
                        title.CssClass = title.CssClass.Replace("text-2xl", "text-md");
                    }

                    font_small_btn.CssClass = font_small_btn.CssClass.Replace("text-gray-800", "text-indigo-600");
                    font_small_btn.CssClass = font_small_btn.CssClass.Replace("bg-white", "bg-gray-200");
                    font_medium_btn.CssClass = font_medium_btn.CssClass.Replace("text-indigo-600", "text-gray-800");
                    font_medium_btn.CssClass = font_medium_btn.CssClass.Replace("bg-gray-200", "bg-white");
                    font_large_btn.CssClass = font_large_btn.CssClass.Replace("text-indigo-600", "text-gray-800");
                    font_large_btn.CssClass = font_large_btn.CssClass.Replace("bg-gray-200", "bg-white");
                }
                else if(font == "Medium")
                {
                    foreach (RepeaterItem item in Repeater1.Items)
                    {
                        Label title = (Label)item.FindControl("postTitle_lbl");
                        title.CssClass = title.CssClass.Replace("text-md", "text-xl");
                        title.CssClass = title.CssClass.Replace("text-2xl", "text-xl");
                    }

                    font_small_btn.CssClass = font_small_btn.CssClass.Replace("text-indigo-600", "text-gray-800");
                    font_small_btn.CssClass = font_small_btn.CssClass.Replace("bg-gray-200", "bg-white");
                    font_medium_btn.CssClass = font_medium_btn.CssClass.Replace("text-gray-800", "text-indigo-600");
                    font_medium_btn.CssClass = font_medium_btn.CssClass.Replace("bg-white", "bg-gray-200");
                    font_large_btn.CssClass = font_large_btn.CssClass.Replace("text-indigo-600", "text-gray-800");
                    font_large_btn.CssClass = font_large_btn.CssClass.Replace("bg-gray-200", "bg-white");

                    fontCookie["Font"] = "Medium";
                    fontCookie.Expires = DateTime.Now.AddDays(999);
                    Response.Cookies.Add(fontCookie);
                }
                else if(font == "Large")
                {
                    foreach (RepeaterItem item in Repeater1.Items)
                    {
                        Label title = (Label)item.FindControl("postTitle_lbl");
                        title.CssClass = title.CssClass.Replace("text-md", "text-2xl");
                        title.CssClass = title.CssClass.Replace("text-xl", "text-2xl");
                    }

                    font_small_btn.CssClass = font_small_btn.CssClass.Replace("text-indigo-600", "text-gray-800");
                    font_small_btn.CssClass = font_small_btn.CssClass.Replace("bg-gray-200", "bg-white");
                    font_medium_btn.CssClass = font_medium_btn.CssClass.Replace("text-indigo-600", "text-gray-800");
                    font_medium_btn.CssClass = font_medium_btn.CssClass.Replace("bg-gray-200", "bg-white");
                    font_large_btn.CssClass = font_large_btn.CssClass.Replace("text-gray-800", "text-indigo-600");
                    font_large_btn.CssClass = font_large_btn.CssClass.Replace("bg-white", "bg-gray-200");

                    fontCookie["Font"] = "Large";
                    fontCookie.Expires = DateTime.Now.AddDays(999);
                    Response.Cookies.Add(fontCookie);
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

            foreach (RepeaterItem item in Repeater1.Items)
            {
                Label lbl = item.FindControl("postContent_lbl") as Label;
                lbl.Text = Regex.Replace(lbl.Text , "<[a-zA-Z]\\s+.*>\\s+.*\\s+<\\/a>", string.Empty);
            }
        }

        protected void GenerateLikeID()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(likeID) FROM DiscussionLike", con);
            int i = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            i++;
            int id = 1000000000 + i;
            likeID = "LK" + id.ToString();
        }

        protected void postBody_btn_Command(object sender, CommandEventArgs e)
        {
            string postID = e.CommandArgument.ToString();
            //Response.Redirect("DiscussionPost.aspx?p=" + postID);
            Response.Redirect("../Discussion/DiscussionPost.aspx?p=" + postID.Substring(2, postID.Length - 2));
        }

        protected void react_like_btn_Command(object sender, CommandEventArgs e)
        {
            GenerateLikeID();

            string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
            string postID = commandArgs[0];
            string currentLike = commandArgs[1];
            string likeDate = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            bool likeStatus = true;

            SqlCommand cmd = new SqlCommand("INSERT INTO DiscussionLike(likeID, likeStatus, likeDate, postID, userID) VALUES (@likeID, @likeStatus, @likeDate, @postID, @userID)", con);
            cmd.Parameters.AddWithValue("@likeID", likeID);
            cmd.Parameters.AddWithValue("@likeStatus", likeStatus);
            cmd.Parameters.AddWithValue("@likeDate", likeDate);
            cmd.Parameters.AddWithValue("@postID", postID);
            cmd.Parameters.AddWithValue("@userID", userID);
            con.Open();
            con.Close();

            RepeaterItem item = (sender as LinkButton).NamingContainer as RepeaterItem;
            LinkButton p = (LinkButton)item.FindControl("react_like_btn");

            string hex = "#7c3aed";
            p.ForeColor = System.Drawing.ColorTranslator.FromHtml(hex);
        }

        protected void personalize_btn_Command(object sender, CommandEventArgs e)
        {
            personalize_panel.Visible = true;
        }

        protected void confirm_btn_Command(object sender, CommandEventArgs e)
        {
            personalize_panel.Visible = false;
            Response.Redirect(Request.RawUrl);
        }

        protected void content_btn_Command(object sender, CommandEventArgs e)
        {
            content_panel.Visible = true;
            layout_panel.Visible = false;
            font_panel.Visible = false;
            content_btn.CssClass = content_btn.CssClass.Replace("border-transparent", "border-gray-700");
            layout_btn.CssClass = layout_btn.CssClass.Replace("border-gray-700", "border-transparent");
            font_btn.CssClass = font_btn.CssClass.Replace("border-gray-700", "border-transparent");
            personalize_lbl.Text = "Customize the homepage content by choosing the order of discussion posts to be shown to you.";
        }

        protected void layout_btn_Command(object sender, CommandEventArgs e)
        {
            content_panel.Visible = false;
            layout_panel.Visible = true;
            font_panel.Visible = false;
            content_btn.CssClass = content_btn.CssClass.Replace("border-gray-700", "border-transparent");
            layout_btn.CssClass = layout_btn.CssClass.Replace("border-transparent", "border-gray-700");
            font_btn.CssClass = font_btn.CssClass.Replace("border-gray-700", "border-transparent");
            personalize_lbl.Text = "Personalize the homepage layout by choosing how you want to discuss the display of the posts and the design of the posts.";
        }

        protected void font_btn_Command(object sender, CommandEventArgs e)
        {
            content_panel.Visible = false;
            layout_panel.Visible = false;
            font_panel.Visible = true;
            content_btn.CssClass = content_btn.CssClass.Replace("border-gray-700", "border-transparent");
            layout_btn.CssClass = layout_btn.CssClass.Replace("border-gray-700", "border-transparent");
            font_btn.CssClass = font_btn.CssClass.Replace("border-transparent", "border-gray-700");
            personalize_lbl.Text = "Customize the font size according to your needs for a better reading experience, visually from small to large.";
        }

        protected void content_recent_btn_Command(object sender, CommandEventArgs e)
        {
            SqlDataSource1.SelectCommand = "SELECT Post.postID, Post.postTitle, Post.postContent, Post.postDate, Post.postStatus, Post.editDate, Tag.tagID, Tag.tagName, Tag.tagDesc, Topic.topicID, Topic.topicName, Topic.topicDesc, [User].userID, [User].name, [User].profilePicture, (SELECT COUNT(*) AS Expr1 FROM DiscussionLike WHERE (postID = Post.postID) AND (likeStatus = 1)) AS totalLike, (SELECT COUNT(*) AS Expr1 FROM DiscussionComment WHERE (postID = Post.postID)) AS totalComment, (SELECT COUNT(*) AS Expr1 FROM Bookmark WHERE (postID = Post.postID) AND (bookmarkStatus = 1)) AS totalBookmark, (SELECT COUNT(*) AS Expr1 FROM DiscussionView WHERE (postID = Post.postID)) AS totalView FROM Post INNER JOIN Tag ON Post.tagID = Tag.tagID INNER JOIN Topic ON Post.topicID = Topic.topicID INNER JOIN [User] ON Post.userID = [User].userID WHERE (Post.postStatus = 1) ORDER BY Post.postDate DESC";
            SqlDataSource1.Select(DataSourceSelectArguments.Empty);
            SqlDataSource1.DataBind();
            Repeater1.DataBind();

            content_recent_btn.CssClass = content_recent_btn.CssClass.Replace("text-gray-800", "text-indigo-600");
            content_recent_btn.CssClass = content_recent_btn.CssClass.Replace("bg-white", "bg-gray-200");
            content_featured_btn.CssClass = content_featured_btn.CssClass.Replace("text-indigo-600", "text-gray-800");
            content_featured_btn.CssClass = content_featured_btn.CssClass.Replace("bg-gray-200", "bg-white");
            content_trending_btn.CssClass = content_trending_btn.CssClass.Replace("text-indigo-600", "text-gray-800");
            content_trending_btn.CssClass = content_trending_btn.CssClass.Replace("bg-gray-200", "bg-white");

            contentCookie["Content"] = "Recent";
            contentCookie.Expires = DateTime.Now.AddDays(999);
            Response.Cookies.Add(contentCookie);
        }

        protected void content_featured_btn_Command(object sender, CommandEventArgs e)
        {
            SqlDataSource1.SelectCommand = "SELECT Post.postID, Post.postTitle, Post.postContent, Post.postDate, Post.postStatus, Post.editDate, Tag.tagID, Tag.tagName, Tag.tagDesc, Topic.topicID, Topic.topicName, Topic.topicDesc, [User].userID, [User].name, [User].profilePicture, (SELECT COUNT(*) AS Expr1 FROM DiscussionLike WHERE (postID = Post.postID) AND (likeStatus = 1)) AS totalLike, (SELECT COUNT(*) AS Expr1 FROM DiscussionComment WHERE (postID = Post.postID)) AS totalComment, (SELECT COUNT(*) AS Expr1 FROM Bookmark WHERE (postID = Post.postID) AND (bookmarkStatus = 1)) AS totalBookmark, (SELECT COUNT(*) AS Expr1 FROM DiscussionView WHERE (postID = Post.postID)) AS totalView FROM Post INNER JOIN Tag ON Post.tagID = Tag.tagID INNER JOIN Topic ON Post.topicID = Topic.topicID INNER JOIN [User] ON Post.userID = [User].userID WHERE (Post.postStatus = 1) ORDER BY totalLike DESC, totalComment DESC";
            SqlDataSource1.Select(DataSourceSelectArguments.Empty);
            SqlDataSource1.DataBind();
            Repeater1.DataBind();

            content_recent_btn.CssClass = content_recent_btn.CssClass.Replace("text-indigo-600", "text-gray-800");
            content_recent_btn.CssClass = content_recent_btn.CssClass.Replace("bg-gray-200", "bg-white");
            content_featured_btn.CssClass = content_featured_btn.CssClass.Replace("text-gray-800", "text-indigo-600");
            content_featured_btn.CssClass = content_featured_btn.CssClass.Replace("bg-white", "bg-gray-200");
            content_trending_btn.CssClass = content_trending_btn.CssClass.Replace("text-indigo-600", "text-gray-800");
            content_trending_btn.CssClass = content_trending_btn.CssClass.Replace("bg-gray-200", "bg-white");

            contentCookie["Content"] = "Featured";
            contentCookie.Expires = DateTime.Now.AddDays(999);
            Response.Cookies.Add(contentCookie);
        }

        protected void content_trending_btn_Command(object sender, CommandEventArgs e)
        {
            SqlDataSource1.SelectCommand = "SELECT Post.postID, Post.postTitle, Post.postContent, Post.postDate, Post.postStatus, Post.editDate, Tag.tagID, Tag.tagName, Tag.tagDesc, Topic.topicID, Topic.topicName, Topic.topicDesc, [User].userID, [User].name, [User].profilePicture, (SELECT COUNT(*) AS Expr1 FROM DiscussionLike WHERE (postID = Post.postID) AND (likeStatus = 1)) AS totalLike, (SELECT COUNT(*) AS Expr1 FROM DiscussionComment WHERE (postID = Post.postID)) AS totalComment, (SELECT COUNT(*) AS Expr1 FROM Bookmark WHERE (postID = Post.postID) AND (bookmarkStatus = 1)) AS totalBookmark, (SELECT COUNT(*) AS Expr1 FROM DiscussionView WHERE (postID = Post.postID)) AS totalView FROM Post INNER JOIN Tag ON Post.tagID = Tag.tagID INNER JOIN Topic ON Post.topicID = Topic.topicID INNER JOIN [User] ON Post.userID = [User].userID WHERE (Post.postStatus = 1) ORDER BY totalView DESC";
            SqlDataSource1.Select(DataSourceSelectArguments.Empty);
            SqlDataSource1.DataBind();
            Repeater1.DataBind();

            content_recent_btn.CssClass = content_recent_btn.CssClass.Replace("text-indigo-600", "text-gray-800");
            content_recent_btn.CssClass = content_recent_btn.CssClass.Replace("bg-gray-200", "bg-white");
            content_featured_btn.CssClass = content_featured_btn.CssClass.Replace("text-indigo-600", "text-gray-800");
            content_featured_btn.CssClass = content_featured_btn.CssClass.Replace("bg-gray-200", "bg-white");
            content_trending_btn.CssClass = content_trending_btn.CssClass.Replace("text-gray-800", "text-indigo-600");
            content_trending_btn.CssClass = content_trending_btn.CssClass.Replace("bg-white", "bg-gray-200");

            contentCookie["Content"] = "Trending";
            contentCookie.Expires = DateTime.Now.AddDays(999);
            Response.Cookies.Add(contentCookie);
        }

        protected void layout_classic_btn_Command(object sender, CommandEventArgs e)
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

            layout_classic_btn.CssClass = layout_classic_btn.CssClass.Replace("text-gray-800", "text-indigo-600");
            layout_classic_btn.CssClass = layout_classic_btn.CssClass.Replace("bg-white", "bg-gray-200");
            layout_compact_btn.CssClass = layout_compact_btn.CssClass.Replace("text-indigo-600", "text-gray-800");
            layout_compact_btn.CssClass = layout_compact_btn.CssClass.Replace("bg-gray-200", "bg-white");
            layout_cozy_btn.CssClass = layout_cozy_btn.CssClass.Replace("text-indigo-600", "text-gray-800");
            layout_cozy_btn.CssClass = layout_cozy_btn.CssClass.Replace("bg-gray-200", "bg-white");

            layoutCookie["Layout"] = "Classic";
            layoutCookie.Expires = DateTime.Now.AddDays(999);
            Response.Cookies.Add(layoutCookie);
        }

        protected void layout_compact_btn_Command(object sender, CommandEventArgs e)
        {
            foreach(RepeaterItem item in Repeater1.Items)
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

            layout_classic_btn.CssClass = layout_classic_btn.CssClass.Replace("text-indigo-600", "text-gray-800");
            layout_classic_btn.CssClass = layout_classic_btn.CssClass.Replace("bg-gray-200", "bg-white");
            layout_compact_btn.CssClass = layout_compact_btn.CssClass.Replace("text-gray-800", "text-indigo-600");
            layout_compact_btn.CssClass = layout_compact_btn.CssClass.Replace("bg-white", "bg-gray-200");
            layout_cozy_btn.CssClass = layout_cozy_btn.CssClass.Replace("text-indigo-600", "text-gray-800");
            layout_cozy_btn.CssClass = layout_cozy_btn.CssClass.Replace("bg-gray-200", "bg-white");

            layoutCookie["Layout"] = "Compact";
            layoutCookie.Expires = DateTime.Now.AddDays(999);
            Response.Cookies.Add(layoutCookie);
        }

        protected void layout_cozy_btn_Command(object sender, CommandEventArgs e)
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

            layout_classic_btn.CssClass = layout_classic_btn.CssClass.Replace("text-indigo-600", "text-gray-800");
            layout_classic_btn.CssClass = layout_classic_btn.CssClass.Replace("bg-gray-200", "bg-white");
            layout_compact_btn.CssClass = layout_compact_btn.CssClass.Replace("text-indigo-600", "text-gray-800");
            layout_compact_btn.CssClass = layout_compact_btn.CssClass.Replace("bg-gray-200", "bg-white");
            layout_cozy_btn.CssClass = layout_cozy_btn.CssClass.Replace("text-gray-800", "text-indigo-600");
            layout_cozy_btn.CssClass = layout_cozy_btn.CssClass.Replace("bg-white", "bg-gray-200");

            layoutCookie["Layout"] = "Cozy";
            layoutCookie.Expires = DateTime.Now.AddDays(999);
            Response.Cookies.Add(layoutCookie);
        }

        protected void font_small_btn_Command(object sender, CommandEventArgs e)
        {
            foreach (RepeaterItem item in Repeater1.Items)
            {
                Label title = (Label)item.FindControl("postTitle_lbl");
                title.CssClass = title.CssClass.Replace("text-xl", "text-md");
                title.CssClass = title.CssClass.Replace("text-2xl", "text-md");
            }

            font_small_btn.CssClass = font_small_btn.CssClass.Replace("text-gray-800", "text-indigo-600");
            font_small_btn.CssClass = font_small_btn.CssClass.Replace("bg-white", "bg-gray-200");
            font_medium_btn.CssClass = font_medium_btn.CssClass.Replace("text-indigo-600", "text-gray-800");
            font_medium_btn.CssClass = font_medium_btn.CssClass.Replace("bg-gray-200", "bg-white");
            font_large_btn.CssClass = font_large_btn.CssClass.Replace("text-indigo-600", "text-gray-800");
            font_large_btn.CssClass = font_large_btn.CssClass.Replace("bg-gray-200", "bg-white");

            fontCookie["Font"] = "Small";
            fontCookie.Expires = DateTime.Now.AddDays(999);
            Response.Cookies.Add(fontCookie);
        }

        protected void font_medium_btn_Command(object sender, CommandEventArgs e)
        {
            foreach (RepeaterItem item in Repeater1.Items)
            {
                Label title = (Label)item.FindControl("postTitle_lbl");
                title.CssClass = title.CssClass.Replace("text-md", "text-xl");
                title.CssClass = title.CssClass.Replace("text-2xl", "text-xl");
            }

            font_small_btn.CssClass = font_small_btn.CssClass.Replace("text-indigo-600", "text-gray-800");
            font_small_btn.CssClass = font_small_btn.CssClass.Replace("bg-gray-200", "bg-white");
            font_medium_btn.CssClass = font_medium_btn.CssClass.Replace("text-gray-800", "text-indigo-600");
            font_medium_btn.CssClass = font_medium_btn.CssClass.Replace("bg-white", "bg-gray-200");
            font_large_btn.CssClass = font_large_btn.CssClass.Replace("text-indigo-600", "text-gray-800");
            font_large_btn.CssClass = font_large_btn.CssClass.Replace("bg-gray-200", "bg-white");

            fontCookie["Font"] = "Medium";
            fontCookie.Expires = DateTime.Now.AddDays(999);
            Response.Cookies.Add(fontCookie);
        }

        protected void font_large_btn_Command(object sender, CommandEventArgs e)
        {
            foreach (RepeaterItem item in Repeater1.Items)
            {
                Label title = (Label)item.FindControl("postTitle_lbl");
                title.CssClass = title.CssClass.Replace("text-md", "text-2xl");
                title.CssClass = title.CssClass.Replace("text-xl", "text-2xl");
            }

            font_small_btn.CssClass = font_small_btn.CssClass.Replace("text-indigo-600", "text-gray-800");
            font_small_btn.CssClass = font_small_btn.CssClass.Replace("bg-gray-200", "bg-white");
            font_medium_btn.CssClass = font_medium_btn.CssClass.Replace("text-indigo-600", "text-gray-800");
            font_medium_btn.CssClass = font_medium_btn.CssClass.Replace("bg-gray-200", "bg-white");
            font_large_btn.CssClass = font_large_btn.CssClass.Replace("text-gray-800", "text-indigo-600");
            font_large_btn.CssClass = font_large_btn.CssClass.Replace("bg-white", "bg-gray-200");

            fontCookie["Font"] = "Large";
            fontCookie.Expires = DateTime.Now.AddDays(999);
            Response.Cookies.Add(fontCookie);
        }

    }
}