﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace RoundTable.WebForms.Support
{
    public partial class Feedback : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\RoundTableDB.mdf;Integrated Security=True");
        string userID, feedbackID;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["UserID"] != null)
            {
                if (!Page.IsPostBack)
                {
                    DropDownList1.Items.Insert(0, "[Select a Feedback Category]");
                    DropDownList1.Items.Insert(1, "Feature requests");
                    DropDownList1.Items.Insert(2, "Bug reports");
                    DropDownList1.Items.Insert(3, "Ask questions");
                    DropDownList1.Items.Insert(4, "Others");
                }
            }
            else
            {
                Response.Redirect("/WebForms/LoginError.aspx");
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('You must log in as a customer to access this feature.');window.location ='../User/UserLogin.aspx';", true);
            }



        }
        protected void GenerateID()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(feedbackID) FROM Feedback", con);
            int i = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            i++;
            int id = 1000000000 + i;
            feedbackID = "FB" + id.ToString();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList1.Items.Remove(DropDownList1.Items.FindByText("[Select a Feedback Category]"));
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DropDownList1.ClearSelection();
            DropDownList1.Items.Insert(0, "[Select a Feedback Category]");

            TextBox1.Text = "";
            TextBox2.Text = "";
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            var filter = new ProfanityFilter.ProfanityFilter();

            GenerateID();

            string feedbackTitle = TextBox1.Text;

            var profanityList = filter.DetectAllProfanities(feedbackTitle);

            if (profanityList.Count == 0)
            {
                string feedbackContent = TextBox2.Text;
                feedbackContent = filter.CensorString(feedbackContent);
                string feedbackDate = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                string feedbackType = DropDownList1.SelectedItem.Value;
                string userID = Session["UserID"].ToString();

                string insertCmd = "INSERT INTO Feedback(feedbackID, feedbackTitle, feedbackContent, feedbackDate, feedbackType, userID) VALUES (@feedbackID, @feedbackTitle, @feedbackContent, @feedbackDate, @feedbackType, @userID)";
                SqlCommand cmd = new SqlCommand(insertCmd, con);
                cmd.Parameters.AddWithValue("@feedbackID", feedbackID);
                cmd.Parameters.AddWithValue("@feedbackTitle", feedbackTitle);
                cmd.Parameters.AddWithValue("@feedbackContent", feedbackContent);
                cmd.Parameters.AddWithValue("@feedbackDate", feedbackDate);
                cmd.Parameters.AddWithValue("@feedbackType", feedbackType);
                cmd.Parameters.AddWithValue("@userID", userID);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
                "alert('Successfully feedback!'); window.location='" +
                Request.ApplicationPath + "../WebForms/Discussion/Homepage.aspx';", true);
            }
            else
            {
                string profanity = null;

                for (int i = profanityList.Count() - 1; i >= 0; i--)
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

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Feedback title cannot contain the following words: [" + profanity + "]')", true);
            }
        }
    }
}