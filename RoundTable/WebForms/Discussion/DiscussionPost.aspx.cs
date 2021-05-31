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
        string postID;

        protected void Page_Load(object sender, EventArgs e)
        {
            postID = Request.QueryString["postID"];
            string topic = null, tag = null;

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Post INNER JOIN [User] ON Post.userID = [User].userID WHERE postID='" + postID + "'", con);
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
                postLike_lbl.Text = dr["postLike"].ToString();
                postComment_lbl.Text = dr["postComment"].ToString();
            }
            con.Close();

            con.Open();
            SqlCommand cmd2 = new SqlCommand("SELECT topicName FROM Topic WHERE topicID='" + topic + "'", con);
            SqlCommand cmd3 = new SqlCommand("SELECT tagName FROM Tag WHERE tagID='" + tag + "'", con);

            topicName_lbl.Text = '#' + cmd2.ExecuteScalar().ToString();
            tagName_lbl.Text = '#' + cmd3.ExecuteScalar().ToString();
            con.Close();

            SqlDataSource1.SelectParameters.Add("postID", postID.ToString());
        }
    }
}