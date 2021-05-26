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
    public partial class CreateDiscussion : System.Web.UI.Page
    {

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\RoundTableDB.mdf;Integrated Security=True");
        string postID;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Topic", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                DropDownList1.DataSource = dt;
                DropDownList1.DataBind();

                DropDownList1.Items.Insert(0, "[Select a Topic]");
                DropDownList2.Items.Insert(0, "[Select a Tag]");
            }
        }

        protected void GenerateID()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(postID) FROM Post", con);
            int i = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            i++;
            int id = 1000000000 + i;
            postID = "DP" + id.ToString();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList2.Enabled = true;
            DropDownList1.Items.Remove(DropDownList1.Items.FindByText("[Select a Topic]"));
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
            DropDownList1.ClearSelection();
            DropDownList2.ClearSelection();
            DropDownList1.Items.Insert(0, "[Select a Topic]");
            DropDownList2.Items.Insert(0, "[Select a Tag]");

            TextBox1.Text = "";
            TextBox2.Text = "";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            GenerateID();

            SqlCommand cmd = new SqlCommand("SELECT topicID FROM Topic WHERE topicName='" + DropDownList1.SelectedItem.Value + "'", con);
            SqlCommand cmd2 = new SqlCommand("SELECT tagID FROM Tag WHERE tagName='" + DropDownList2.SelectedItem.Value + "'", con);

            con.Open();
            string topicID = cmd.ExecuteScalar().ToString();
            string tagID = cmd2.ExecuteScalar().ToString();
            con.Close();

            string postTitle = TextBox1.Text;
            string postContent = TextBox2.Text;
            string postDate = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            int postLike = 0;
            int postComment = 0;
            int postView = 1;
            string userID = "testing";

            string insertCmd = "INSERT INTO Post(postID, postTitle, postContent, postDate, postLike, postComment, postView, userID, tagID, topicID) VALUES (@postID, @postTitle, @postContent, @postDate, @postLike, @postComment, @postView, @userID, @tagID, @topicID)";
            SqlCommand cmd3 = new SqlCommand(insertCmd, con);
            cmd3.Parameters.AddWithValue("@postID", postID);
            cmd3.Parameters.AddWithValue("@postTitle", postTitle);
            cmd3.Parameters.AddWithValue("@postContent", postContent);
            cmd3.Parameters.AddWithValue("@postDate", postDate);
            cmd3.Parameters.AddWithValue("@postLike", postLike);
            cmd3.Parameters.AddWithValue("@postComment", postComment);
            cmd3.Parameters.AddWithValue("@postView", postView);
            cmd3.Parameters.AddWithValue("@userID", userID);
            cmd3.Parameters.AddWithValue("@tagID", tagID);
            cmd3.Parameters.AddWithValue("@topicID", topicID);
            con.Open();
            cmd3.ExecuteNonQuery();
            con.Close();

            DropDownList1.ClearSelection();
            DropDownList2.ClearSelection();
            DropDownList1.Items.Insert(0, "[Select a Topic]");
            DropDownList2.Items.Insert(0, "[Select a Tag]");

            TextBox1.Text = "";
            TextBox2.Text = "";
        }

    }
}