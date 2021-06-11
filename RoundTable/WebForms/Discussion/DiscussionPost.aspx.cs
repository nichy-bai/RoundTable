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
    public partial class DiscussionPost : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\RoundTableDB.mdf;Integrated Security=True");
        string postID, likeID, commentID, bookmarkID, viewID;
        string hex = "#4F46E5";

        //To be modified
        string userID = "Shrimp";

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Response.Cache.SetCacheability(HttpCacheability.NoCache);

            postID = "DP" + Request.QueryString["p"];

            if (!IsPostBack)
            {
                string topic = null, tag = null;
                bool likeStatus = false, bookmarkStatus = false;
                int commentStatus = 0;

                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT *,(SELECT COUNT(*) AS Expr1 FROM DiscussionLike WHERE (postID = Post.postID) AND (likeStatus = 1)) AS totalLike, (SELECT COUNT(*) AS Expr1 FROM DiscussionComment WHERE (postID = Post.postID) AND (commentStatus = 1)) AS totalComment, (SELECT COUNT(*) AS Expr1 FROM DiscussionView WHERE (postID = Post.postID)) AS totalView FROM Post INNER JOIN [User] ON Post.userID = [User].userID WHERE postID='" + postID + "'", con);
                cmd.CommandType = CommandType.Text;
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    userID_lbl.Text = dr["userID"].ToString();
                    userID_lbl.ToolTip = dr["name"].ToString();

                    postDate_lbl.Text = Convert.ToDateTime(dr["postDate"]).ToString("d MMMM yyyy");
                    postDate_lbl.ToolTip = Convert.ToDateTime(dr["postDate"]).ToString("dddd, dd/MM/yyyy h:mm:ss tt");

                    postTitle_lbl.Text = dr["postTitle"].ToString();
                    postContent_lbl.Text = dr["postContent"].ToString();
                    topic = dr["topicID"].ToString();
                    tag = dr["tagID"].ToString();
                    postLike_lbl.Text = dr["totalLike"].ToString();
                    postComment_lbl.Text = dr["totalComment"].ToString();
                    postView_lbl.Text = dr["totalView"].ToString();
                }
                con.Close();

                con.Open();
                SqlCommand cmd2 = new SqlCommand("SELECT topicName FROM Topic WHERE topicID='" + topic + "'", con);
                SqlCommand cmd3 = new SqlCommand("SELECT topicDesc FROM Topic WHERE topicID='" + topic + "'", con);
                SqlCommand cmd4 = new SqlCommand("SELECT tagName FROM Tag WHERE tagID='" + tag + "'", con);
                SqlCommand cmd5 = new SqlCommand("SELECT tagDesc FROM Tag WHERE tagID='" + tag + "'", con);
                SqlCommand cmd6 = new SqlCommand("SELECT likeStatus FROM DiscussionLike WHERE postID='" + postID + "'" + "AND userID='" + userID + "'", con);
                SqlCommand cmd7 = new SqlCommand("SELECT COUNT(bookmarkID) FROM Bookmark WHERE postID='" + postID + "' AND (bookmarkStatus = 1)", con);
                SqlCommand cmd8 = new SqlCommand("SELECT bookmarkStatus FROM Bookmark WHERE postID='" + postID + "'" + "AND userID='" + userID + "'", con);
                SqlCommand cmd9 = new SqlCommand("SELECT COUNT(commentID) FROM DiscussionComment WHERE postID='" + postID + "' AND (commentStatus = 1) AND userID='" + userID + "'", con);
                SqlCommand cmd10 = new SqlCommand("SELECT editDate FROM Post WHERE postID='" + postID + "'", con);
                SqlCommand cmd11 = new SqlCommand("SELECT reportID FROM Report WHERE postID='" + postID + "'", con);

                topicName_lbl.Text = cmd2.ExecuteScalar().ToString();
                topic_btn.ToolTip = cmd3.ExecuteScalar().ToString();

                tagName_lbl.Text = cmd4.ExecuteScalar().ToString();
                tag_btn.ToolTip = cmd5.ExecuteScalar().ToString();

                object obj = cmd6.ExecuteScalar();

                if (obj != null && DBNull.Value != obj)
                {
                    likeStatus = (bool)cmd6.ExecuteScalar();
                }

                if (likeStatus)
                {
                    react_like_btn.ForeColor = System.Drawing.ColorTranslator.FromHtml(hex);
                    react_like_btn.ToolTip = "Unlike";
                }

                postBookmark_lbl.Text = cmd7.ExecuteScalar().ToString();

                object obj2 = cmd8.ExecuteScalar();

                if (obj2 != null && DBNull.Value != obj2)
                {
                    bookmarkStatus = (bool)cmd8.ExecuteScalar();
                }

                if (bookmarkStatus)
                {
                    react_bookmark_btn.ForeColor = System.Drawing.ColorTranslator.FromHtml(hex);
                    react_bookmark_btn.ToolTip = "Unbookmark";
                }

                object obj3 = cmd9.ExecuteScalar();

                if (obj3 != null && DBNull.Value != obj3)
                {
                    commentStatus = Int32.Parse(cmd9.ExecuteScalar().ToString());
                }

                if (commentStatus > 0)
                {
                    react_comment_btn.ForeColor = System.Drawing.ColorTranslator.FromHtml(hex);
                }

                object obj4 = cmd10.ExecuteScalar();

                if (obj4 != null && DBNull.Value != obj4)
                {
                    string editDate = Convert.ToDateTime(cmd10.ExecuteScalar()).ToString("d MMMM yyyy");
                    string editDateFull = Convert.ToDateTime(cmd10.ExecuteScalar()).ToString("dddd, dd/MM/yyyy h:mm:ss tt");

                    editDate_lbl.Text = "(Edited on " + editDate +")";
                    editDate_lbl.ToolTip = "Edited on " + editDateFull;
                }

                object obj5 = cmd11.ExecuteScalar();

                if (obj5 != null && DBNull.Value != obj5)
                {
                    post_report_panel.Visible = true;
                    post_report_panel.ToolTip = "This discussion post was recently reported by other users.\nIt may contain harmful content that violates regulations.";
                }

                con.Close();

                SqlDataSource1.SelectParameters.Add("postID", postID.ToString());

                if (userID != userID_lbl.Text)
                {
                    threedot_dropdown_btn_2.Visible = false;
                    threedot_dropdown_btn_3.Visible = false;
                }

                IncreaseViewCount();
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

        protected void GenerateCommentID()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(commentID) FROM DiscussionComment", con);
            int i = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            i++;
            int id = 1000000000 + i;
            commentID = "DC" + id.ToString();
        }

        protected void GenerateBookmarkID()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(bookmarkID) FROM Bookmark", con);
            int i = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            i++;
            int id = 1000000000 + i;
            bookmarkID = "BM" + id.ToString();
        }

        protected void GenerateViewID()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(viewID) FROM DiscussionView", con);
            int i = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            i++;
            int id = 1000000000 + i;
            viewID = "VW" + id.ToString();
        }

        private void IncreaseViewCount()
        {
            string viewDate = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            int viewCount, totalViewCount;

            GenerateViewID();

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT viewID FROM DiscussionView WHERE userID='" + userID + "' AND postID='" + postID + "'", con);
            SqlCommand cmd2 = new SqlCommand("SELECT viewCount FROM DiscussionView WHERE userID='" + userID + "' AND postID='" + postID + "'", con);
            SqlCommand cmd3 = new SqlCommand("SELECT COUNT(viewID) FROM DiscussionView WHERE postID='" + postID + "'", con);

            object obj = cmd.ExecuteScalar();

            if (obj != null && DBNull.Value != obj)
            {
                viewID = cmd.ExecuteScalar().ToString();
                viewCount = (int)cmd2.ExecuteScalar();
                viewCount += 1;
                SqlCommand update = new SqlCommand("UPDATE DiscussionView SET viewCount='" + viewCount + "' WHERE userID='" + userID + "' AND postID='" + postID + "'", con);

                update.ExecuteNonQuery();
            }
            else
            {
                viewCount = 1;

                SqlCommand insert = new SqlCommand("INSERT INTO DiscussionView(viewID, viewCount, viewDate, postID, userID) VALUES (@viewID, @viewCount, @viewDate, @postID, @userID)", con);
                insert.Parameters.AddWithValue("@viewID", viewID);
                insert.Parameters.AddWithValue("@viewCount", viewCount);
                insert.Parameters.AddWithValue("@viewDate", viewDate);
                insert.Parameters.AddWithValue("@postID", postID);
                insert.Parameters.AddWithValue("@userID", userID);

                insert.ExecuteNonQuery();
            }

            totalViewCount = (int)cmd3.ExecuteScalar();

            con.Close();

            if(totalViewCount < 2 && viewCount < 2)
            {
                react_view_btn.ToolTip = "No one has viewed this post yet.\nYou are the first.";
            }
            else if (totalViewCount < 2)
            {
                react_view_btn.ToolTip = "You are the first to view this post.\nYou have viewed this post " + viewCount +" times.";
            }
            else
            {
                if (viewCount < 2)
                {
                    react_view_btn.ToolTip = totalViewCount - 1 + " people have viewed this post.";
                }
                else
                {
                    react_view_btn.ToolTip = totalViewCount + " people have viewed this post.\nYou have viewed this post " + viewCount + " times.";
                }
            }
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (Repeater1.Items.Count < 1)
            {
                if (e.Item.ItemType == ListItemType.Footer)
                {
                    Label lblFooter = (Label)e.Item.FindControl("noComment_lbl");
                    lblFooter.Visible = true;
                    comment_txt.Attributes.Add("placeholder", "Be the first to comment");
                }
            }
        }

        protected void threedot_dropdown_btn_1_Click(object sender, EventArgs e)
        {
            //Share Post

            share_panel.Visible = true;
            post_url_txt.Text = Request.Url.AbsoluteUri;
        }

        protected void threedot_dropdown_btn_2_Click(object sender, EventArgs e)
        {
            //Edit Post

            Response.Redirect("../Discussion/EditDiscussion.aspx?p=" + postID.Substring(2, postID.Length - 2));
        }

        protected void threedot_dropdown_btn_3_Click(object sender, EventArgs e)
        {
            //Delete Post

            bool postStatus = false;

            SqlCommand update = new SqlCommand("UPDATE Post SET postStatus='" + postStatus + "' WHERE postID='" + postID + "'" + "AND userID='" + userID + "'", con);
            con.Open();
            update.ExecuteNonQuery();
            con.Close();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
            "alert('Successfully deleted!'); window.location='" +
            Request.ApplicationPath + "../WebForms/Discussion/Homepage.aspx';", true);
        }

        protected void threedot_dropdown_btn_4_Click(object sender, EventArgs e)
        {
            //Report Post

            Response.Redirect("../Discussion/ReportDiscussion.aspx?p=" + postID.Substring(2, postID.Length - 2));
        }

        protected void share_url_btn_Command(object sender, CommandEventArgs e)
        {
            share_url_btn.CssClass = share_url_btn.CssClass.Replace("border-transparent", "border-gray-700");
            share_embeded_btn.CssClass = share_embeded_btn.CssClass.Replace("border-gray-700", "border-transparent");
            share_url_lbl.Text = "Copy this unique URL and share it with your friends to start an asynchronous discussion!";
            copy_btn.Text = "Copy URL";

            post_url_txt.Text = Request.Url.AbsoluteUri;
            post_url_txt.CssClass = post_url_txt.CssClass.Replace("font-mono", "");
        }

        protected void share_embeded_btn_Command(object sender, CommandEventArgs e)
        {
            share_url_btn.CssClass = share_url_btn.CssClass.Replace("border-gray-700", "border-transparent");
            share_embeded_btn.CssClass = share_embeded_btn.CssClass.Replace("border-transparent", "border-gray-700");
            share_url_lbl.Text = "Copy this unique embed code and share it on your website to promote the discussion!";
            copy_btn.Text = "Copy Embed Code";

            string url = Request.Url.AbsoluteUri;

            post_url_txt.Text = "<iframe src='" + url + "' height='500' width='600' style='border: none;' title='" + postTitle_lbl.Text + "'></iframe>";
            post_url_txt.CssClass += " font-mono";
        }

        protected void copy_btn_Click(object sender, EventArgs e)
        {
            if (copy_btn.Text == "Copy URL" || copy_btn.Text == "Copy Embed Code")
            {
                copy_btn.Text = "Copied!";
            }
            else if (copy_btn.Text == "Copied!")
            {
                copy_btn.Text = "Double Copy!";
            }
            else if (copy_btn.Text == "Double Copy!")
            {
                copy_btn.Text = "Triple Copy!";
            }
            else if (copy_btn.Text == "Triple Copy!")
            {
                copy_btn.Text = "Stop It!";
            }
            else if (copy_btn.Text == "Stop It!")
            {
                copy_btn.Text = "Please Stop It!";
            }
            else if (copy_btn.Text == "Please Stop It!")
            {
                copy_btn.Text = "Click →";
                copy_btn.Enabled = false;
                copy_btn.CssClass = copy_btn.CssClass.Replace("hover:bg-gray-100", "");
                close_btn.CssClass += " animate-pulse";
            }
        }

        protected void close_btn_Command(object sender, CommandEventArgs e)
        {
            share_panel.Visible = false;
            Response.Redirect(Request.RawUrl);
        }

        protected void view_global_btn_Command(object sender, CommandEventArgs e)
        {
            view_global_btn.CssClass = view_global_btn.CssClass.Replace("border-transparent", "border-gray-700");
            view_personal_btn.CssClass = view_personal_btn.CssClass.Replace("border-gray-700", "border-transparent");
            view_lbl_1.Text = "Number of people viewed this post";
            view_lbl_2.Text = "Total number of views of this post";
            view_lbl_3.Text = "Average number of views per person";

            count_lbl_1.Visible = true;
            count_lbl_2.Visible = true;
            count_lbl_3.Visible = true;
            count_lbl_11.Visible = false;
            count_lbl_22.Visible = false;
            count_lbl_33.Visible = false;

            count_up_panel.Visible = false;
            count_down_panel.Visible = false;
            count_equal_panel.Visible = false;
        }

        protected void view_personal_btn_Command(object sender, CommandEventArgs e)
        {
            view_global_btn.CssClass = view_global_btn.CssClass.Replace("border-gray-700", "border-transparent");
            view_personal_btn.CssClass = view_personal_btn.CssClass.Replace("border-transparent", "border-gray-700");
            view_lbl_1.Text = "Number of times you viewed this post";
            view_lbl_2.Text = "The first time you viewed this post";
            view_lbl_3.Text = "How long has it been since you first saw this";

            count_lbl_1.Visible = false;
            count_lbl_2.Visible = false;
            count_lbl_3.Visible = false;
            count_lbl_11.Visible = true;
            count_lbl_22.Visible = true;
            count_lbl_33.Visible = true;

            int personal = Int32.Parse(count_lbl_11.Text);
            int avg = Int32.Parse(count_lbl_3.Text);

            if(personal > avg)
            {
                count_up_panel.Visible = true;
            }
            else if(personal < avg)
            {
                count_down_panel.Visible = true;
            }
            else
            {
                count_equal_panel.Visible = true;
            }
        }

        protected void close_view_btn_Command(object sender, CommandEventArgs e)
        {
            view_panel.Visible = false;
            Response.Redirect(Request.RawUrl);
        }

        protected void comment_btn_Command(object sender, CommandEventArgs e)
        {
            GenerateCommentID();

            string commentContent = comment_txt.Text.Replace("\n", "<br>");
            string commentDate = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            bool commentStatus = true;

            //To be modified
            string userID = "Shrimp";

            if (!String.IsNullOrEmpty(comment_txt.Text))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO DiscussionComment(commentID, commentContent, commentDate, postID, userID, commentStatus) VALUES (@commentID, @commentContent, @commentDate, @postID, @userID, @commentStatus)", con);
                cmd.Parameters.AddWithValue("@commentID", commentID);
                cmd.Parameters.AddWithValue("@commentContent", commentContent);
                cmd.Parameters.AddWithValue("@commentDate", commentDate);
                cmd.Parameters.AddWithValue("@postID", postID);
                cmd.Parameters.AddWithValue("@userID", userID);
                cmd.Parameters.AddWithValue("@commentStatus", commentStatus);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                comment_txt.Text = "";

                Response.Redirect(Request.RawUrl);
            }
            else
            {
                Response.Write("<script>alert('Comment cannot be empty')</script>");
            }
        }

        protected void react_like_btn_Command(object sender, CommandEventArgs e)
        {
            bool likeInsert, likeStatus;

            SqlCommand select = new SqlCommand("SELECT likeStatus FROM DiscussionLike WHERE postID='" + postID + "'" + "AND userID='" + userID + "'", con);
            con.Open();
            object obj = select.ExecuteScalar();

            if (obj != null && DBNull.Value != obj)
            {
                likeStatus = (bool)select.ExecuteScalar();
                likeInsert = false;
            }
            else
            {
                likeStatus = true;
                likeInsert = true;
            }
            con.Close();

            if (likeInsert)
            {
                GenerateLikeID();

                int currentLike = Int32.Parse(postLike_lbl.Text);
                string likeDate = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

                SqlCommand insert = new SqlCommand("INSERT INTO DiscussionLike(likeID, likeStatus, likeDate, postID, userID) VALUES (@likeID, @likeStatus, @likeDate, @postID, @userID)", con);
                insert.Parameters.AddWithValue("@likeID", likeID);
                insert.Parameters.AddWithValue("@likeStatus", likeStatus);
                insert.Parameters.AddWithValue("@likeDate", likeDate);
                insert.Parameters.AddWithValue("@postID", postID);
                insert.Parameters.AddWithValue("@userID", userID);
                con.Open();
                insert.ExecuteNonQuery();
                con.Close();

                react_like_btn.ForeColor = System.Drawing.ColorTranslator.FromHtml(hex);

                //Response.Write("<script>alert('Liked')</script>");

                Response.Redirect(Request.RawUrl);
            }
            else
            {
                likeStatus = !likeStatus;
                string likeDate = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

                SqlCommand update = new SqlCommand("UPDATE DiscussionLike SET likeDate='" + likeDate + "', likeStatus='" + likeStatus + "' WHERE postID='" + postID + "'" + "AND userID='" + userID + "'", con);
                con.Open();
                update.ExecuteNonQuery();
                con.Close();

                Response.Redirect(Request.RawUrl);
            }
        }

        protected void react_comment_btn_Command(object sender, CommandEventArgs e)
        {
            comment_txt.Focus();
        }

        protected void react_bookmark_btn_Command(object sender, CommandEventArgs e)
        {
            bool bookmarkInsert, bookmarkStatus;

            SqlCommand select = new SqlCommand("SELECT bookmarkStatus FROM Bookmark WHERE postID='" + postID + "'" + "AND userID='" + userID + "'", con);
            con.Open();
            object obj = select.ExecuteScalar();

            if (obj != null && DBNull.Value != obj)
            {
                bookmarkStatus = (bool)select.ExecuteScalar();
                bookmarkInsert = false;
            }
            else
            {
                bookmarkStatus = true;
                bookmarkInsert = true;
            }
            con.Close();

            if (bookmarkInsert)
            {
                GenerateBookmarkID();

                string bookmarkDate = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

                SqlCommand insert = new SqlCommand("INSERT INTO Bookmark(bookmarkID, bookmarkDate, postID, userID, bookmarkStatus) VALUES (@bookmarkID, @bookmarkDate, @postID, @userID, @bookmarkStatus)", con);
                insert.Parameters.AddWithValue("@bookmarkID", bookmarkID);
                insert.Parameters.AddWithValue("@bookmarkDate", bookmarkDate);
                insert.Parameters.AddWithValue("@postID", postID);
                insert.Parameters.AddWithValue("@userID", userID);
                insert.Parameters.AddWithValue("@bookmarkStatus", bookmarkStatus);
                con.Open();
                insert.ExecuteNonQuery();
                con.Close();

                react_like_btn.ForeColor = System.Drawing.ColorTranslator.FromHtml(hex);

                Response.Redirect(Request.RawUrl);
            }
            else
            {
                bookmarkStatus = !bookmarkStatus;
                string bookmarkDate = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

                SqlCommand update = new SqlCommand("UPDATE Bookmark SET bookmarkDate='" + bookmarkDate + "', bookmarkStatus='" + bookmarkStatus + "' WHERE postID='" + postID + "'" + "AND userID='" + userID + "'", con);
                con.Open();
                update.ExecuteNonQuery();
                con.Close();

                Response.Redirect(Request.RawUrl);
            }
        }

        protected void react_view_btn_Command(object sender, CommandEventArgs e)
        {
            view_panel.Visible = true;

            int numPeopleView, totalNumView, personalView;
            double AvgNumView;
            DateTime personalViewDate, todayDate = System.DateTime.Now;

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(viewID) FROM DiscussionView WHERE postID='" + postID + "'", con);
            SqlCommand cmd2 = new SqlCommand("SELECT SUM(viewCount) FROM DiscussionView WHERE postID='" + postID + "'", con);
            SqlCommand cmd3 = new SqlCommand("SELECT viewCount FROM DiscussionView WHERE postID='" + postID + "' AND userID='" + userID + "'", con);
            SqlCommand cmd4 = new SqlCommand("SELECT viewDate FROM DiscussionView WHERE postID='" + postID + "' AND userID='" + userID + "'", con);

            numPeopleView = (int)cmd.ExecuteScalar();
            totalNumView = (int)cmd2.ExecuteScalar();
            AvgNumView = (totalNumView / numPeopleView);

            personalView = (int)cmd3.ExecuteScalar();
            personalViewDate = Convert.ToDateTime(cmd4.ExecuteScalar());

            con.Close();

            count_lbl_1.Text = numPeopleView.ToString();
            count_lbl_2.Text = totalNumView.ToString();
            count_lbl_3.Text = AvgNumView.ToString();

            count_lbl_11.Text = personalView.ToString();
            count_lbl_22.Text = personalViewDate.ToString("dd/MM/yy");
            count_lbl_33.Text = (todayDate - personalViewDate).Days.ToString() + "&nbsp;Day(s)";

            count_up_panel.Visible = false;
            count_down_panel.Visible = false;
            count_equal_panel.Visible = false;
        }

    }
}