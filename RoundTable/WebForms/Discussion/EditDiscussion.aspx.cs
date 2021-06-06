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
    public partial class EditDiscussion : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\RoundTableDB.mdf;Integrated Security=True");
        string postID;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Response.Cache.SetCacheability(HttpCacheability.NoCache);

            postID = "DP" + Request.QueryString["p"];

            if (!Page.IsPostBack)
            {
                string topicID = "", topicName = "", tagID = "", tagName = "";

                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Post WHERE postID='" + postID + "'", con);
                cmd.CommandType = CommandType.Text;
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    topicID = dr["topicID"].ToString();
                    tagID = dr["tagID"].ToString();

                    TextBox1.Text = dr["postTitle"].ToString();
                    TextBox2.Text = dr["postContent"].ToString();
                }
                con.Close();

                SqlCommand cmd2 = new SqlCommand("SELECT * FROM Topic", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd2);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                DropDownList1.DataSource = dt;
                DropDownList1.DataBind();

                SqlCommand cmd3 = new SqlCommand("SELECT * FROM Tag WHERE topicID='" + topicID + "'", con);
                SqlDataAdapter sda2 = new SqlDataAdapter(cmd3);
                DataTable dt2 = new DataTable();
                sda2.Fill(dt2);
                DropDownList2.DataSource = dt2;
                DropDownList2.DataBind();

                con.Open();
                SqlCommand cmd4 = new SqlCommand("SELECT topicName FROM Topic WHERE topicID='" + topicID + "'", con);
                SqlCommand cmd5 = new SqlCommand("SELECT tagName FROM Tag WHERE tagID='" + tagID + "'", con);

                topicName = cmd4.ExecuteScalar().ToString();
                tagName = cmd5.ExecuteScalar().ToString();

                DropDownList1.Items.FindByValue(topicName).Selected = true;
                DropDownList2.Items.FindByValue(tagName).Selected = true;
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT topicID FROM Topic WHERE topicName='" + DropDownList1.SelectedItem.Value + "'", con);
            con.Open();
            string topicID = cmd.ExecuteScalar().ToString();
            con.Close();

            SqlCommand cmd2 = new SqlCommand("SELECT * FROM Tag WHERE topicID='" + topicID + "'", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd2);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DropDownList2.DataSource = dt;
            DropDownList2.DataBind();
            DropDownList2.Items.Insert(0, "[Select a Tag]");
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList2.Items.Remove(DropDownList2.Items.FindByText("[Select a Tag]"));
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Discussion/DiscussionPost.aspx?p=" + postID.Substring(2, postID.Length - 2));
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT topicID FROM Topic WHERE topicName='" + DropDownList1.SelectedItem.Value + "'", con);
            SqlCommand cmd2 = new SqlCommand("SELECT tagID FROM Tag WHERE tagName='" + DropDownList2.SelectedItem.Value + "'", con);

            con.Open();
            string topicID = cmd.ExecuteScalar().ToString();
            string tagID = cmd2.ExecuteScalar().ToString();
            con.Close();

            string postTitle = TextBox1.Text;
            string postContent = TextBox2.Text;

            SqlCommand cmd3 = new SqlCommand("UPDATE Post SET postTitle='" + postTitle + "', postContent='" + postContent + "', topicID='" + topicID + "', tagID='" + tagID + "' WHERE postID='" + postID + "'", con);
            con.Open();
            cmd3.ExecuteNonQuery();
            con.Close();

            DropDownList1.ClearSelection();
            DropDownList2.ClearSelection();
            DropDownList1.Items.Insert(0, "[Select a Topic]");
            DropDownList2.Items.Insert(0, "[Select a Tag]");
            TextBox1.Text = "";
            TextBox2.Text = "";

            ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
            "alert('Successfully updated!'); window.location='" +
            Request.ApplicationPath + "../WebForms/Discussion/DiscussionPost.aspx?p=" + postID.Substring(2, postID.Length - 2) + "';", true);
        }
    }
}