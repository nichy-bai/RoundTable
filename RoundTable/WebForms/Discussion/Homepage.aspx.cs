using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;

namespace RoundTable.WebForms.Discussion
{
    public partial class Homepage : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\RoundTableDB.mdf;Integrated Security=True");
        string likeID;

        protected void Page_Load(object sender, EventArgs e)
        {

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

        protected void postTitle_btn_Command(object sender, CommandEventArgs e)
        {
            string postID = e.CommandArgument.ToString();
            Response.Redirect("DiscussionPost.aspx?p=" + postID);
            //Response.Redirect("DiscussionPost.aspx?p=" + postID.Substring(2, postID.Length - 2));
        }

        protected void react_like_btn_Command(object sender, CommandEventArgs e)
        {
            GenerateLikeID();

            string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
            string postID = commandArgs[0];
            string currentLike = commandArgs[1];
            string likeDate = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

            //To be modified
            bool likeStatus = true;
            string userID = "Shrimp";

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

        //protected void threedot_btn_Click(object sender, EventArgs e)
        //{
        //    RepeaterItem item = (sender as LinkButton).NamingContainer as RepeaterItem;

        //    Panel p = (Panel)item.FindControl("threedot_panel");

        //    if (p.Visible == false)
        //    {
        //        p.Visible = true;
        //    }
        //    else
        //    {
        //        p.Visible = false;
        //    }
        //}
    }
}