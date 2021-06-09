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
        string postID, reportID;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Response.Cache.SetCacheability(HttpCacheability.NoCache);

            postID = "DP" + Request.QueryString["p"];

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
            GenerateID();

            string reportTitle = TextBox1.Text;
            string reportContent = TextBox2.Text;
            string reportDate = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            string reportType = DropDownList1.SelectedItem.Value;

            //to be modified
            string userID = "Shrimp";

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

            ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
            "alert('Successfully reported!'); window.location='" +
            Request.ApplicationPath + "../WebForms/Discussion/DiscussionPost.aspx?p=" + postID.Substring(2, postID.Length - 2) + "';", true);
        }
    }
}