﻿using System;
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
        string postID, likeID, commentID, bookmarkID;
        //To be modified
        string userID = "Shrimp";

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Response.Cache.SetCacheability(HttpCacheability.NoCache);

            postID = Request.QueryString["p"];

            if (!IsPostBack)
            {
                string topic = null, tag = null;
                bool likeStatus = false, bookmarkStatus = false;
                int commentStatus = 0;

                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT *,(SELECT COUNT(*) AS Expr1 FROM DiscussionLike WHERE (postID = Post.postID) AND (likeStatus = 1)) AS totalLike, (SELECT COUNT(*) AS Expr1 FROM DiscussionComment WHERE (postID = Post.postID) AND (commentStatus = 1)) AS totalComment FROM Post INNER JOIN [User] ON Post.userID = [User].userID WHERE postID='" + postID + "'", con);
                cmd.CommandType = CommandType.Text;
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    userID_lbl.Text = dr["userID"].ToString();
                    userID_lbl.ToolTip = dr["name"].ToString();

                    postDate_lbl.Text = Convert.ToDateTime(dr["postDate"]).ToString("d MMMM yyyy");
                    postDate_lbl.ToolTip = dr["postDate"].ToString();

                    postTitle_lbl.Text = dr["postTitle"].ToString();
                    postContent_lbl.Text = dr["postContent"].ToString();
                    topic = dr["topicID"].ToString();
                    tag = dr["tagID"].ToString();
                    postLike_lbl.Text = dr["totalLike"].ToString();
                    postComment_lbl.Text = dr["totalComment"].ToString();
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
                    string hex = "#7c3aed";
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
                    string hex = "#7c3aed";
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
                    string hex = "#7c3aed";
                    react_comment_btn.ForeColor = System.Drawing.ColorTranslator.FromHtml(hex);
                }

                con.Close();

                SqlDataSource1.SelectParameters.Add("postID", postID.ToString());
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
            //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('report')", true);
            Response.Write("<script>alert('report')</script>");
        }

        protected void threedot_dropdown_btn_2_Click(object sender, EventArgs e)
        {
            //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('share')", true);
            Response.Write("<script>alert('share')</script>");
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

                string hex = "#7c3aed";
                react_like_btn.ForeColor = System.Drawing.ColorTranslator.FromHtml(hex);

                Response.Redirect(Request.Url.AbsoluteUri);
            }
            else
            {
                bookmarkStatus = !bookmarkStatus;
                string bookmarkDate = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

                SqlCommand update = new SqlCommand("UPDATE Bookmark SET bookmarkDate='" + bookmarkDate + "', bookmarkStatus='" + bookmarkStatus + "' WHERE postID='" + postID + "'" + "AND userID='" + userID + "'", con);
                con.Open();
                update.ExecuteNonQuery();
                con.Close();

                Response.Redirect(Request.Url.AbsoluteUri);
            }
        }

        protected void comment_btn_Command(object sender, CommandEventArgs e)
        {
            GenerateCommentID();

            string commentContent = comment_txt.Text;
            string commentDate = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            bool commentStatus = true;

            //To be modified
            string userID = "Shrimp";

            if(!String.IsNullOrEmpty(comment_txt.Text))
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

                Response.Redirect(Request.Url.AbsoluteUri);
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

                string hex = "#7c3aed";
                react_like_btn.ForeColor = System.Drawing.ColorTranslator.FromHtml(hex);

                //Response.Write("<script>alert('Liked')</script>");

                Response.Redirect(Request.Url.AbsoluteUri);
            }
            else
            {
                likeStatus = !likeStatus;
                string likeDate = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

                SqlCommand update = new SqlCommand("UPDATE DiscussionLike SET likeDate='" + likeDate + "', likeStatus='" + likeStatus + "' WHERE postID='" + postID + "'" + "AND userID='" + userID + "'", con);
                con.Open();
                update.ExecuteNonQuery();
                con.Close();

                //if (likeStatus)
                //{
                //    Response.Write("<script>alert('Liked')</script>");
                //}
                //else
                //{
                //    Response.Write("<script>alert('Unliked')</script>");
                //}

                Response.Redirect(Request.Url.AbsoluteUri);
            }
        }
    }
}