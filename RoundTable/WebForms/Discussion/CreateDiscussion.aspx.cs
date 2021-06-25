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
        string userID, postID;

        protected void Page_Load(object sender, EventArgs e)
        {
            //To be modified
            

            if(Session["UserID"] != null)
            {
                if (!Page.IsPostBack)
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
            else
            {
                Response.Redirect("/WebForms/LoginError.aspx");
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('You must log in as a customer to access this feature.');window.location ='../User/UserLogin.aspx';", true);
            }
            
        }

        protected void GeneratePostID()
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
            var filter = new ProfanityFilter.ProfanityFilter();

            GeneratePostID();

            SqlCommand cmd = new SqlCommand("SELECT topicID FROM Topic WHERE topicName='" + DropDownList1.SelectedItem.Value + "'", con);
            SqlCommand cmd2 = new SqlCommand("SELECT tagID FROM Tag WHERE tagName='" + DropDownList2.SelectedItem.Value + "'", con);

            con.Open();
            string topicID = cmd.ExecuteScalar().ToString();
            string tagID = cmd2.ExecuteScalar().ToString();
            con.Close();

            string postTitle = TextBox1.Text;

            var profanityList = filter.DetectAllProfanities(postTitle);

            if(profanityList.Count == 0)
            {
                string postContent = TextBox2.Text;
                postContent = TrimEnd(postContent, "\r\n<p>&nbsp;</p>");
                postContent = postContent.Replace(">", "> ");
                postContent = postContent.Replace("</", " </");
                postContent = filter.CensorString(postContent);
                string postDate = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                bool postStatus = true;

                string insertCmd = "INSERT INTO Post(postID, postTitle, postContent, postDate, userID, tagID, topicID, postStatus) VALUES (@postID, @postTitle, @postContent, @postDate, @userID, @tagID, @topicID, @postStatus)";
                SqlCommand cmd3 = new SqlCommand(insertCmd, con);
                cmd3.Parameters.AddWithValue("@postID", postID);
                cmd3.Parameters.AddWithValue("@postTitle", postTitle);
                cmd3.Parameters.AddWithValue("@postContent", postContent);
                cmd3.Parameters.AddWithValue("@postDate", postDate);
                cmd3.Parameters.AddWithValue("@userID", userID);
                cmd3.Parameters.AddWithValue("@tagID", tagID);
                cmd3.Parameters.AddWithValue("@topicID", topicID);
                cmd3.Parameters.AddWithValue("@postStatus", postStatus);
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
                "alert('Successfully posted!'); window.location='" +
                Request.ApplicationPath + "../WebForms/Discussion/DiscussionPost.aspx?p=" + postID.Substring(2, postID.Length - 2) + "';", true);
            }
            else
            {
                string profanity = null;

                for(int i = profanityList.Count() - 1; i >= 0; i--)
                {
                    if (i > 0)
                    {
                        profanity = profanity + profanityList[i].ToString() + ", ";
                    }
                    else
                    {
                        profanity += profanityList[i].ToString();
                    }
                }

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Discussion title cannot contain the following words: [" + profanity + "]')", true);
            }
        }

        public static string TrimEnd(string input, string suffixToRemove)
        {
            while (input != null && suffixToRemove != null && input.EndsWith(suffixToRemove))
            {
                input = input.Substring(0, input.Length - suffixToRemove.Length);
            }
            return input;
        }
    }
}