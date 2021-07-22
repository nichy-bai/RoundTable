using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web.Services;
using System.Web.Script.Services;
using System.Data;

namespace RoundTable.WebForms.Search
{
    public partial class Searchpage : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\RoundTableDB.mdf;Integrated Security=True");
        DataAccess DA = new DataAccess();
        string topicID = "";
        string keyword;
        protected void Page_Load(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text;

            Page.Form.DefaultButton = btnSearch.UniqueID;
            if (!this.IsPostBack)
            {
                this.BindRepeater();
            }

        }

        protected void postBody_btn_Command(object sender, CommandEventArgs e)
        {
            string postID = e.CommandArgument.ToString();
            //Response.Redirect("DiscussionPost.aspx?p=" + postID);
            Response.Redirect("../Discussion/DiscussionPost.aspx?p=" + postID.Substring(2, postID.Length - 2));
        }


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Button0.CssClass = "cursor-pointer text-white bg-indigo-600 hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button1.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button2.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button3.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button4.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button5.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button6.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button7.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button8.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button9.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button10.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button11.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";

            //get keyword from textbox
            string keyword = txtSearch.Text;
            //if the search box is not empty
            if (string.IsNullOrEmpty(keyword) != true)
            {
                lblNoResult.Text = "";

                //get the result of the search
                DataTable dt = DA.searchQuery(keyword);
                //if there is at least one row
                if (dt.Rows.Count > 0)
                {
                    Repeater1.Visible = true;
                    Repeater1.DataSource = dt; //repeater get the data from table based on the search text
                    Repeater1.DataBind(); //bind the data to the repeater
                }
                else
                {
                    lblNoResult.Text = "No Results.";
                    Repeater1.Visible = false;
                }
            }
            else
            {
                lblNoResult.Text = "No Results.";
                Repeater1.Visible = false;
            }
        }

        private void BindRepeater()
        {
            using (con)
            {
                string query = "";
                string keyword = txtSearch.Text;
                string ddl = DropDownList1.SelectedValue;

                if (topicID == "")
                {
                    query = "SELECT Post.postID, Post.postTitle, Post.postContent, Post.postDate, Post.postStatus, Post.editDate, Tag.tagID, Tag.tagName, Tag.tagDesc, Topic.topicID, Topic.topicName, Topic.topicDesc, [User].userID, [User].name, [User].profilePicture, (SELECT COUNT(*) AS Expr1 FROM DiscussionLike WHERE (postID = Post.postID) AND (likeStatus = 1)) AS totalLike, (SELECT COUNT(*) AS Expr1 FROM DiscussionComment WHERE (postID = Post.postID)) AS totalComment, (SELECT COUNT(*) AS Expr1 FROM Bookmark WHERE (postID = Post.postID) AND (bookmarkStatus = 1)) AS totalBookmark, (SELECT COUNT(*) AS Expr1 FROM DiscussionView WHERE (postID = Post.postID)) AS totalView FROM Post INNER JOIN Tag ON Post.tagID = Tag.tagID INNER JOIN Topic ON Post.topicID = Topic.topicID INNER JOIN [User] ON Post.userID = [User].userID WHERE (Post.postStatus = 1) AND (topicName LIKE '%' + @keyword + '%' OR [User].userID LIKE '%' + @keyword + '%' OR [Post].postTitle LIKE '%' + @keyword + '%') ORDER BY Post.postDate DESC";
                }
                else
                {
                    //something wrong here
                    query = "SELECT Post.postID, Post.postTitle, Post.postContent, Post.postDate, Post.postStatus, Post.editDate, Tag.tagID, Tag.tagName, Tag.tagDesc, Topic.topicID, Topic.topicName, Topic.topicDesc, [User].userID, [User].name, [User].profilePicture, (SELECT COUNT(*) AS Expr1 FROM DiscussionLike WHERE (postID = Post.postID) AND (likeStatus = 1)) AS totalLike, (SELECT COUNT(*) AS Expr1 FROM DiscussionComment WHERE (postID = Post.postID)) AS totalComment, (SELECT COUNT(*) AS Expr1 FROM Bookmark WHERE (postID = Post.postID) AND (bookmarkStatus = 1)) AS totalBookmark, (SELECT COUNT(*) AS Expr1 FROM DiscussionView WHERE (postID = Post.postID)) AS totalView FROM Post INNER JOIN Tag ON Post.tagID = Tag.tagID INNER JOIN Topic ON Post.topicID = Topic.topicID INNER JOIN [User] ON Post.userID = [User].userID WHERE (Post.postStatus = 1) AND Topic.topicID='" + topicID + "' AND (topicName LIKE '%' + @keyword + '%' OR [User].userID LIKE '%' + @keyword + '%' OR [Post].postTitle LIKE '%' + @keyword + '%') ORDER BY Post.postDate DESC";
                }

                Session["TopicID"] = topicID;

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.SelectCommand.Parameters.AddWithValue("@keyword", keyword);
                        sda.Fill(dt);
                        Repeater1.DataSource = dt;
                        Repeater1.DataBind();

                        if (dt.Rows.Count > 0)
                        {
                            Repeater1.Visible = true;
                            lblNoResult.Text = "";
                        }
                        else
                        {
                            lblNoResult.Text = "No Results.";
                            Repeater1.Visible = false;
                        }
                    }
                }
            }
        }

        protected void Button0_Click(object sender, EventArgs e)
        {
            topicID = "";
            Button0.CssClass = "cursor-pointer text-white bg-indigo-600 hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button1.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button2.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button3.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button4.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button5.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button6.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button7.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button8.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button9.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button10.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button11.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            BindRepeater();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            topicID = "TP1000000001";
            Button0.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button1.CssClass = "cursor-pointer text-white bg-indigo-600 hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button2.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button3.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button4.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button5.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button6.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button7.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button8.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button9.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button10.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button11.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            BindRepeater();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            topicID = "TP1000000002";
            Button0.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button1.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button2.CssClass = "cursor-pointer text-white bg-indigo-600 hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button3.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button4.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button5.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button6.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button7.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button8.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button9.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button10.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button11.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            BindRepeater();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            topicID = "TP1000000003";
            Button0.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button1.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button2.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button3.CssClass = "cursor-pointer text-white bg-indigo-600 hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button4.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button5.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button6.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button7.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button8.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button9.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button10.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button11.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            BindRepeater();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            topicID = "TP1000000004";
            Button0.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button1.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button2.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button3.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button4.CssClass = "cursor-pointer text-white bg-indigo-600 hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button5.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button6.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button7.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button8.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button9.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button10.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button11.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            BindRepeater();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            topicID = "TP1000000005";
            Button0.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button1.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button2.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button3.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button4.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button5.CssClass = "cursor-pointer text-white bg-indigo-600 hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button6.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button7.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button8.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button9.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button10.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button11.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            BindRepeater();
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            topicID = "TP1000000006";
            Button0.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button1.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button2.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button3.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button4.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button5.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button6.CssClass = "cursor-pointer text-white bg-indigo-600 hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button7.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button8.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button9.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button10.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button11.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            BindRepeater();
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            topicID = "TP1000000007";
            Button0.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button1.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button2.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button3.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button4.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button5.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button6.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button7.CssClass = "cursor-pointer text-white bg-indigo-600 hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button8.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button9.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button10.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button11.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            BindRepeater();
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            topicID = "TP1000000008";
            Button0.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button1.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button2.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button3.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button4.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button5.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button6.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button7.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button8.CssClass = "cursor-pointer text-white bg-indigo-600 hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button9.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button10.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button11.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            BindRepeater();
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            topicID = "TP1000000009";
            Button0.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button1.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button2.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button3.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button4.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button5.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button6.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button7.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button8.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button9.CssClass = "cursor-pointer text-white bg-indigo-600 hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button10.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button11.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            BindRepeater();
        }

        protected void Button10_Click(object sender, EventArgs e)
        {
            topicID = "TP1000000010";
            Button0.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button1.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button2.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button3.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button4.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button5.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button6.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button7.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button8.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button9.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button10.CssClass = "cursor-pointer text-white bg-indigo-600 hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button11.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            BindRepeater();
        }

        protected void Button11_Click(object sender, EventArgs e)
        {
            topicID = "TP1000000011";
            Button0.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button1.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button2.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button3.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button4.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button5.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button6.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button7.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button8.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button9.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button10.CssClass = "cursor-pointer text-indigo-600 bg-white hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            Button11.CssClass = "cursor-pointer text-white bg-indigo-600 hover:bg-indigo-600 hover:text-white border-2 border-indigo-600 transition ease-in-out duration-300 shadow-md px-2 py-0.5 inline-block rounded";
            BindRepeater();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sortQuery = "";
            string keyword = txtSearch.Text;
            string topic = Session["TopicID"].ToString();


            if (DropDownList1.SelectedValue == "Latest")
            {
                if(topic == "")
                {
                    sortQuery = "SELECT Post.postID, Post.postTitle, Post.postContent, Post.postDate, Post.postStatus, Post.editDate, Tag.tagID, Tag.tagName, Tag.tagDesc, Topic.topicID, Topic.topicName, Topic.topicDesc, [User].userID, [User].name, [User].profilePicture, (SELECT COUNT(*) AS Expr1 FROM DiscussionLike WHERE (postID = Post.postID) AND (likeStatus = 1)) AS totalLike, (SELECT COUNT(*) AS Expr1 FROM DiscussionComment WHERE (postID = Post.postID)) AS totalComment, (SELECT COUNT(*) AS Expr1 FROM Bookmark WHERE (postID = Post.postID) AND (bookmarkStatus = 1)) AS totalBookmark, (SELECT COUNT(*) AS Expr1 FROM DiscussionView WHERE (postID = Post.postID)) AS totalView FROM Post INNER JOIN Tag ON Post.tagID = Tag.tagID INNER JOIN Topic ON Post.topicID = Topic.topicID INNER JOIN [User] ON Post.userID = [User].userID WHERE (Post.postStatus = 1) AND (topicName LIKE '%' + @keyword + '%' OR [User].userID LIKE '%' + @keyword + '%' OR [Post].postTitle LIKE '%' + @keyword + '%') ORDER BY Post.postDate DESC";
                }
                else
                {
                    sortQuery = "SELECT Post.postID, Post.postTitle, Post.postContent, Post.postDate, Post.postStatus, Post.editDate, Tag.tagID, Tag.tagName, Tag.tagDesc, Topic.topicID, Topic.topicName, Topic.topicDesc, [User].userID, [User].name, [User].profilePicture, (SELECT COUNT(*) AS Expr1 FROM DiscussionLike WHERE (postID = Post.postID) AND (likeStatus = 1)) AS totalLike, (SELECT COUNT(*) AS Expr1 FROM DiscussionComment WHERE (postID = Post.postID)) AS totalComment, (SELECT COUNT(*) AS Expr1 FROM Bookmark WHERE (postID = Post.postID) AND (bookmarkStatus = 1)) AS totalBookmark, (SELECT COUNT(*) AS Expr1 FROM DiscussionView WHERE (postID = Post.postID)) AS totalView FROM Post INNER JOIN Tag ON Post.tagID = Tag.tagID INNER JOIN Topic ON Post.topicID = Topic.topicID INNER JOIN [User] ON Post.userID = [User].userID WHERE (Post.postStatus = 1) AND (topicName LIKE '%' + @keyword + '%' OR [User].userID LIKE '%' + @keyword + '%' OR [Post].postTitle LIKE '%' + @keyword + '%') AND Topic.topicID='" + topic + "' ORDER BY Post.postDate DESC";
                }
            }
            else if (DropDownList1.SelectedValue == "Oldest")
            {
                if (topic == "")
                {
                    sortQuery = "SELECT Post.postID, Post.postTitle, Post.postContent, Post.postDate, Post.postStatus, Post.editDate, Tag.tagID, Tag.tagName, Tag.tagDesc, Topic.topicID, Topic.topicName, Topic.topicDesc, [User].userID, [User].name, [User].profilePicture, (SELECT COUNT(*) AS Expr1 FROM DiscussionLike WHERE (postID = Post.postID) AND (likeStatus = 1)) AS totalLike, (SELECT COUNT(*) AS Expr1 FROM DiscussionComment WHERE (postID = Post.postID)) AS totalComment, (SELECT COUNT(*) AS Expr1 FROM Bookmark WHERE (postID = Post.postID) AND (bookmarkStatus = 1)) AS totalBookmark, (SELECT COUNT(*) AS Expr1 FROM DiscussionView WHERE (postID = Post.postID)) AS totalView FROM Post INNER JOIN Tag ON Post.tagID = Tag.tagID INNER JOIN Topic ON Post.topicID = Topic.topicID INNER JOIN [User] ON Post.userID = [User].userID WHERE (Post.postStatus = 1) AND (topicName LIKE '%' + @keyword + '%' OR [User].userID LIKE '%' + @keyword + '%' OR [Post].postTitle LIKE '%' + @keyword + '%') ORDER BY Post.postDate ASC";
                }
                else
                {
                    sortQuery = "SELECT Post.postID, Post.postTitle, Post.postContent, Post.postDate, Post.postStatus, Post.editDate, Tag.tagID, Tag.tagName, Tag.tagDesc, Topic.topicID, Topic.topicName, Topic.topicDesc, [User].userID, [User].name, [User].profilePicture, (SELECT COUNT(*) AS Expr1 FROM DiscussionLike WHERE (postID = Post.postID) AND (likeStatus = 1)) AS totalLike, (SELECT COUNT(*) AS Expr1 FROM DiscussionComment WHERE (postID = Post.postID)) AS totalComment, (SELECT COUNT(*) AS Expr1 FROM Bookmark WHERE (postID = Post.postID) AND (bookmarkStatus = 1)) AS totalBookmark, (SELECT COUNT(*) AS Expr1 FROM DiscussionView WHERE (postID = Post.postID)) AS totalView FROM Post INNER JOIN Tag ON Post.tagID = Tag.tagID INNER JOIN Topic ON Post.topicID = Topic.topicID INNER JOIN [User] ON Post.userID = [User].userID WHERE (Post.postStatus = 1) AND (topicName LIKE '%' + @keyword + '%' OR [User].userID LIKE '%' + @keyword + '%' OR [Post].postTitle LIKE '%' + @keyword + '%') AND Topic.topicID='" + topic + "' ORDER BY Post.postDate ASC";
                }
                
            }
            else if (DropDownList1.SelectedValue == "Featured")
            {
                if (topic == "")
                {
                    sortQuery = "SELECT Post.postID, Post.postTitle, Post.postContent, Post.postDate, Post.postStatus, Post.editDate, Tag.tagID, Tag.tagName, Tag.tagDesc, Topic.topicID, Topic.topicName, Topic.topicDesc, [User].userID, [User].name, [User].profilePicture, (SELECT COUNT(*) AS Expr1 FROM DiscussionLike WHERE (postID = Post.postID) AND (likeStatus = 1)) AS totalLike, (SELECT COUNT(*) AS Expr1 FROM DiscussionComment WHERE (postID = Post.postID)) AS totalComment, (SELECT COUNT(*) AS Expr1 FROM Bookmark WHERE (postID = Post.postID) AND (bookmarkStatus = 1)) AS totalBookmark, (SELECT COUNT(*) AS Expr1 FROM DiscussionView WHERE (postID = Post.postID)) AS totalView FROM Post INNER JOIN Tag ON Post.tagID = Tag.tagID INNER JOIN Topic ON Post.topicID = Topic.topicID INNER JOIN [User] ON Post.userID = [User].userID WHERE (Post.postStatus = 1) AND (topicName LIKE '%' + @keyword + '%' OR [User].userID LIKE '%' + @keyword + '%' OR [Post].postTitle LIKE '%' + @keyword + '%') ORDER BY totalLike DESC, totalComment DESC";
                }
                else
                {
                    sortQuery = "SELECT Post.postID, Post.postTitle, Post.postContent, Post.postDate, Post.postStatus, Post.editDate, Tag.tagID, Tag.tagName, Tag.tagDesc, Topic.topicID, Topic.topicName, Topic.topicDesc, [User].userID, [User].name, [User].profilePicture, (SELECT COUNT(*) AS Expr1 FROM DiscussionLike WHERE (postID = Post.postID) AND (likeStatus = 1)) AS totalLike, (SELECT COUNT(*) AS Expr1 FROM DiscussionComment WHERE (postID = Post.postID)) AS totalComment, (SELECT COUNT(*) AS Expr1 FROM Bookmark WHERE (postID = Post.postID) AND (bookmarkStatus = 1)) AS totalBookmark, (SELECT COUNT(*) AS Expr1 FROM DiscussionView WHERE (postID = Post.postID)) AS totalView FROM Post INNER JOIN Tag ON Post.tagID = Tag.tagID INNER JOIN Topic ON Post.topicID = Topic.topicID INNER JOIN [User] ON Post.userID = [User].userID WHERE (Post.postStatus = 1) AND (topicName LIKE '%' + @keyword + '%' OR [User].userID LIKE '%' + @keyword + '%' OR [Post].postTitle LIKE '%' + @keyword + '%') AND Topic.topicID='" + topic + "' ORDER BY totalLike DESC, totalComment DESC";
                }
                
            }
            else
            {
                if (topic == "")
                {
                    sortQuery = "SELECT Post.postID, Post.postTitle, Post.postContent, Post.postDate, Post.postStatus, Post.editDate, Tag.tagID, Tag.tagName, Tag.tagDesc, Topic.topicID, Topic.topicName, Topic.topicDesc, [User].userID, [User].name, [User].profilePicture, (SELECT COUNT(*) AS Expr1 FROM DiscussionLike WHERE (postID = Post.postID) AND (likeStatus = 1)) AS totalLike, (SELECT COUNT(*) AS Expr1 FROM DiscussionComment WHERE (postID = Post.postID)) AS totalComment, (SELECT COUNT(*) AS Expr1 FROM Bookmark WHERE (postID = Post.postID) AND (bookmarkStatus = 1)) AS totalBookmark, (SELECT COUNT(*) AS Expr1 FROM DiscussionView WHERE (postID = Post.postID)) AS totalView FROM Post INNER JOIN Tag ON Post.tagID = Tag.tagID INNER JOIN Topic ON Post.topicID = Topic.topicID INNER JOIN [User] ON Post.userID = [User].userID WHERE (Post.postStatus = 1) AND (topicName LIKE '%' + @keyword + '%' OR [User].userID LIKE '%' + @keyword + '%' OR [Post].postTitle LIKE '%' + @keyword + '%') ORDER BY totalView DESC";
                }
                else
                {
                    sortQuery = "SELECT Post.postID, Post.postTitle, Post.postContent, Post.postDate, Post.postStatus, Post.editDate, Tag.tagID, Tag.tagName, Tag.tagDesc, Topic.topicID, Topic.topicName, Topic.topicDesc, [User].userID, [User].name, [User].profilePicture, (SELECT COUNT(*) AS Expr1 FROM DiscussionLike WHERE (postID = Post.postID) AND (likeStatus = 1)) AS totalLike, (SELECT COUNT(*) AS Expr1 FROM DiscussionComment WHERE (postID = Post.postID)) AS totalComment, (SELECT COUNT(*) AS Expr1 FROM Bookmark WHERE (postID = Post.postID) AND (bookmarkStatus = 1)) AS totalBookmark, (SELECT COUNT(*) AS Expr1 FROM DiscussionView WHERE (postID = Post.postID)) AS totalView FROM Post INNER JOIN Tag ON Post.tagID = Tag.tagID INNER JOIN Topic ON Post.topicID = Topic.topicID INNER JOIN [User] ON Post.userID = [User].userID WHERE (Post.postStatus = 1) AND (topicName LIKE '%' + @keyword + '%' OR [User].userID LIKE '%' + @keyword + '%' OR [Post].postTitle LIKE '%' + @keyword + '%') AND Topic.topicID='" + topic + "' ORDER BY totalView DESC";
                }
            }

            using (SqlCommand cmd = new SqlCommand(sortQuery, con))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.SelectCommand.Parameters.AddWithValue("@keyword", keyword);
                    sda.Fill(dt);
                    Repeater1.DataSource = dt;
                    Repeater1.DataBind();

                    if (dt.Rows.Count > 0)
                    {
                        Repeater1.Visible = true;
                        lblNoResult.Text = "";
                    }
                    else
                    {
                        lblNoResult.Text = "No Results.";
                        Repeater1.Visible = false;
                    }
                }
            }
        }

        //[ScriptMethod()]
        //[WebMethod]
        //public static List<string> SearchCustomers(string prefixText, int count)
        //{
        //    using (SqlConnection conn = new SqlConnection())
        //    {
        //        conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        //        using (SqlCommand cmd = new SqlCommand())
        //        {
        //            cmd.CommandText = "select postTitle from Post where postTitle like @SearchText + '%'";
        //            cmd.Parameters.AddWithValue("@SearchText", prefixText);
        //            cmd.Connection = conn;
        //            conn.Open();
        //            List<string> customers = new List<string>();
        //            using (SqlDataReader sdr = cmd.ExecuteReader())
        //            {
        //                while (sdr.Read())
        //                {
        //                    customers.Add(sdr["postTitle"].ToString());
        //                }
        //            }
        //            conn.Close();

        //            return customers;
        //        }
        //    }
        //}
    }


    internal class DataAccess
    {
        public DataTable searchQuery(string keyword)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\RoundTableDB.mdf;Integrated Security=True");
            //SqlDataAdapter DA = new SqlDataAdapter("spSearch", con);
            //DA.SelectCommand.CommandType = CommandType.StoredProcedure;
            //DA.SelectCommand.Parameters.AddWithValue("@keyword", keyword);
            var commandText = "SELECT Post.postID, Post.postTitle, Post.postContent, Post.postDate, Post.postStatus, Post.editDate, Tag.tagID, Tag.tagName, Tag.tagDesc, Topic.topicID, Topic.topicName, Topic.topicDesc, [User].userID, [User].name, [User].profilePicture, (SELECT COUNT(*) AS Expr1 FROM DiscussionLike WHERE (postID = Post.postID) AND (likeStatus = 1)) AS totalLike, (SELECT COUNT(*) AS Expr1 FROM DiscussionComment WHERE (postID = Post.postID)) AS totalComment, (SELECT COUNT(*) AS Expr1 FROM Bookmark WHERE (postID = Post.postID) AND (bookmarkStatus = 1)) AS totalBookmark, (SELECT COUNT(*) AS Expr1 FROM DiscussionView WHERE (postID = Post.postID)) AS totalView FROM Post INNER JOIN Tag ON Post.tagID = Tag.tagID INNER JOIN Topic ON Post.topicID = Topic.topicID INNER JOIN [User] ON Post.userID = [User].userID WHERE (Post.postStatus = 1) AND topicName LIKE '%' + @keyword + '%' OR [User].userID LIKE '%' + @keyword + '%' OR [Post].postTitle LIKE '%' + @keyword + '%' ORDER BY Post.postDate DESC";
            
            DataTable dt = new DataTable();
            using (var DA = new SqlDataAdapter(commandText, con))
            {
                DA.SelectCommand.Parameters.AddWithValue("@keyword", keyword);
                DA.Fill(dt);
            }
            return dt;
        }
    }
}