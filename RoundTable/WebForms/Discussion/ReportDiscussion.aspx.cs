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
    public partial class ReportDiscussion : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\RoundTableDB.mdf;Integrated Security=True");
        string userID, postID, reportID;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] != null)
            {
                Page.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                userID = Session["UserID"].ToString();
                postID = "DP" + Request.QueryString["p"];

                con.Open();
                SqlCommand status = new SqlCommand("SELECT postStatus FROM Post WHERE postID='" + postID + "'", con);
                bool postStatus;
                if (status.ExecuteScalar() != null)
                {
                    postStatus = true;
                }
                else
                {
                    postStatus = false;
                }
                con.Close();

                if (postStatus)
                {
                    if (!Page.IsPostBack)
                    {
                        DropDownList1.Items.Insert(0, "[Select a Report Category]");
                        DropDownList1.Items.Insert(1, "Threatening violence");
                        DropDownList1.Items.Insert(2, "Misinformation");
                        DropDownList1.Items.Insert(3, "Sexualization");
                        DropDownList1.Items.Insert(4, "Impersonation");
                        DropDownList1.Items.Insert(5, "Harassment");
                        DropDownList1.Items.Insert(6, "Spam");
                        DropDownList1.Items.Insert(7, "Hate");
                        DropDownList1.Items.Insert(8, "Others");

                        TextBox1.Text = "Report: Discussion Post " + postID.Substring(2, postID.Length - 2);
                    }
                }
                else
                {
                    Response.Redirect("/WebForms/Error.aspx");
                }
            }
            else
            {
                Response.Redirect("/WebForms/LoginError.aspx");
            }

        }

        protected void GenerateID()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(reportID) FROM Report", con);
            int i = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            i++;
            int id = 1000000000 + i;
            reportID = "RP" + id.ToString();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList1.Items.Remove(DropDownList1.Items.FindByText("[Select a Report Category]"));
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Discussion/DiscussionPost.aspx?p=" + postID.Substring(2, postID.Length - 2));
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            var filter = new ProfanityFilter.ProfanityFilter();

            GenerateID();

            string reportTitle = TextBox1.Text;
            string reportContent = TextBox2.Text;
            reportContent = filter.CensorString(reportContent);
            string reportDate = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            string reportType = DropDownList1.SelectedItem.Value;
            string userID = Session["UserID"].ToString();

            string insertCmd = "INSERT INTO Report(reportID, reportTitle, reportContent, reportDate, reportType, userID, postID) VALUES (@reportID, @reportTitle, @reportContent, @reportDate, @reportType, @userID, @postID)";
            SqlCommand cmd = new SqlCommand(insertCmd, con);
            cmd.Parameters.AddWithValue("@reportID", reportID);
            cmd.Parameters.AddWithValue("@reportTitle", reportTitle);
            cmd.Parameters.AddWithValue("@reportContent", reportContent);
            cmd.Parameters.AddWithValue("@reportDate", reportDate);
            cmd.Parameters.AddWithValue("@reportType", reportType);
            cmd.Parameters.AddWithValue("@userID", userID);
            cmd.Parameters.AddWithValue("@postID", postID);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            SqlCommand viewCmd = new SqlCommand("SELECT COUNT(viewID) FROM DiscussionView WHERE postID='" + postID + "'", con);
            SqlCommand reportCmd = new SqlCommand("SELECT COUNT(reportID) FROM Report WHERE postID='" + postID + "'", con);
            con.Open();
            int viewCount = (int)viewCmd.ExecuteScalar();
            int reportCount = (int)reportCmd.ExecuteScalar();
            con.Close();

            if (viewCount > 1000)
            {
                if (reportCount >= viewCount * 0.1)
                {
                    SqlCommand blockCmd = new SqlCommand("UPDATE Post SET postStatus=0 WHERE postID='" + postID + "'", con);

                    con.Open();
                    blockCmd.ExecuteNonQuery();
                    con.Close();

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
                    "alert('Successfully reported! Due to too many reported cases, this post will be restricted until further notice'); window.location='" +
                    Request.ApplicationPath + "../WebForms/Discussion/Homepage.aspx';", true);
                }
            }
            else if (viewCount > 500)
            {
                if (reportCount >= viewCount * 0.2)
                {
                    SqlCommand blockCmd = new SqlCommand("UPDATE Post SET postStatus=0 WHERE postID='" + postID + "'", con);

                    con.Open();
                    blockCmd.ExecuteNonQuery();
                    con.Close();

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
                    "alert('Successfully reported! Due to too many reported cases, this post will be restricted until further notice'); window.location='" +
                    Request.ApplicationPath + "../WebForms/Discussion/Homepage.aspx';", true);
                }
            }
            else if (viewCount > 100)
            {
                if (reportCount >= viewCount * 0.3)
                {
                    SqlCommand blockCmd = new SqlCommand("UPDATE Post SET postStatus=0 WHERE postID='" + postID + "'", con);

                    con.Open();
                    blockCmd.ExecuteNonQuery();
                    con.Close();

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
                    "alert('Successfully reported! Due to too many reported cases, this post will be restricted until further notice'); window.location='" +
                    Request.ApplicationPath + "../WebForms/Discussion/Homepage.aspx';", true);
                }
            }
            else if (viewCount > 50)
            {
                if (reportCount >= viewCount * 0.4)
                {
                    SqlCommand blockCmd = new SqlCommand("UPDATE Post SET postStatus=0 WHERE postID='" + postID + "'", con);

                    con.Open();
                    blockCmd.ExecuteNonQuery();
                    con.Close();

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
                    "alert('Successfully reported! Due to too many reported cases, this post will be restricted until further notice'); window.location='" +
                    Request.ApplicationPath + "../WebForms/Discussion/Homepage.aspx';", true);
                }
            }
            else if (viewCount > 10)
            {
                if(reportCount >= viewCount * 0.5)
                {
                    SqlCommand blockCmd = new SqlCommand("UPDATE Post SET postStatus=0 WHERE postID='" + postID + "'", con);

                    con.Open();
                    blockCmd.ExecuteNonQuery();
                    con.Close();

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
                    "alert('Successfully reported! Due to too many reported cases, this post will be restricted until further notice'); window.location='" +
                    Request.ApplicationPath + "../WebForms/Discussion/Homepage.aspx';", true);
                }
            }

            ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
            "alert('Successfully reported!'); window.location='" +
            Request.ApplicationPath + "../WebForms/Discussion/DiscussionPost.aspx?p=" + postID.Substring(2, postID.Length - 2) + "';", true);
        }
    }
}