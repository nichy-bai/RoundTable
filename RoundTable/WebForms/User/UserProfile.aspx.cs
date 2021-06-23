﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RoundTable.WebForms.User
{
    public partial class UserProfile : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\RoundTableDB.mdf;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            //Panel p1 = (Panel)Master.FindControl("master_aside_panel");
            //p1.Style.Add("display", "none");
            if (Session["UserID"] != null)
            {
                string getTopicPosted = "Select Count(*) from [Post] where userID = @currUserID";
                SqlCommand cmdTopic = new SqlCommand(getTopicPosted, con);
                cmdTopic.Parameters.AddWithValue("@currUserID", Session["UserID"].ToString());
                con.Open();

                int TopicCount = Convert.ToInt32(cmdTopic.ExecuteScalar());
                lblTopicPosted.Text = TopicCount.ToString();
                con.Close();

                string getProfileData = "Select * from [User] where userID = @currUserID ";
                SqlCommand cmd = new SqlCommand(getProfileData, con);
                SqlDataReader rdr;
                cmd.Parameters.AddWithValue("@currUserID", Session["UserID"].ToString());
                con.Open();
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    DateTime sourceDate = (DateTime)rdr["DOB"];
                    imgProfilePic.ImageUrl = rdr["profilePicture"].ToString();
                    profilePicture.ImageUrl = rdr["profilePicture"].ToString();
                    lblName.Text = rdr["name"].ToString();
                    lblGender.Text = rdr["Gender"].ToString();
                    lblDOB.Text = sourceDate.ToString("dd MMMM yyyy");
                    lblEmail.Text = rdr["emailAddress"].ToString();
                    lblProfileDesc.Text = rdr["profileDesc"].ToString();
                }
            }
            MultiViewProfile.ActiveViewIndex = 0;
        }

        protected void post_btn_Command(object sender, CommandEventArgs e)
        {
            string postID = e.CommandArgument.ToString();
            //Response.Redirect("DiscussionPost.aspx?p=" + postID);
            Response.Redirect("../Discussion/DiscussionPost.aspx?p=" + postID.Substring(2, postID.Length - 2));
        }
        protected void btnEditProfile_Click(object sender, EventArgs e)
        {
            MultiViewProfile.ActiveViewIndex = 1;
            if (Session["UserID"] != null)
            {
                string getProfileData = "Select * from [User] where userID = @currUserID ";
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\RoundTableDB.mdf;Integrated Security=True");
                SqlCommand cmd = new SqlCommand(getProfileData, con);
                SqlDataReader rdr;
                cmd.Parameters.AddWithValue("@currUserID", Session["UserID"].ToString());
                con.Open();
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    DateTime sourceDate = (DateTime)rdr["DOB"];
                    txtName.Text = rdr["name"].ToString();
                    ddlGender.Text = rdr["Gender"].ToString();
                    txtDOB.Text = sourceDate.ToString("yyyy-MM-dd");
                    txtEmail.Text = rdr["emailAddress"].ToString();
                    txtProfileDesc.Text = rdr["profileDesc"].ToString();
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            MultiViewProfile.ActiveViewIndex = 0;
        }

        protected void btnSaveChanges_Click(object sender, EventArgs e)
        {
            String updateProfile = "UPDATE [dbo].[User] SET [User].[name] = @newName,[User].[Gender] = @newGender, [User].[DOB] = @newDOB, [User].[emailAddress] = @newEmail, [User].[profilePicture] = @ProfilePicture, [User].[profileDesc] = @Desc WHERE [User].[userID] = @UserID";
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\RoundTableDB.mdf;Integrated Security=True");
            SqlCommand cmdEditProfile = new SqlCommand(updateProfile, con);

            //string UploadPhoto = "~/ProfileImages/" + FileUpload.FileName.ToString();
            if (FileUpload.HasFile)
            {
                string UploadImg = "~/ProfileImages/" + FileUpload.FileName.ToString();
                FileUpload.SaveAs(Server.MapPath("~/ProfileImages/" + FileUpload.FileName));
                cmdEditProfile.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());
                cmdEditProfile.Parameters.AddWithValue("@newName", txtName.Text);
                cmdEditProfile.Parameters.AddWithValue("@newGender", ddlGender.SelectedValue);
                cmdEditProfile.Parameters.AddWithValue("@newDOB", txtDOB.Text);
                cmdEditProfile.Parameters.AddWithValue("@newEmail", txtEmail.Text);
                cmdEditProfile.Parameters.AddWithValue("@ProfilePicture", UploadImg);
                cmdEditProfile.Parameters.AddWithValue("@Desc", txtProfileDesc.Text);
                con.Open();
                cmdEditProfile.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                string getProfileData = "Select * from [User] where userID = @currUserID ";
                SqlCommand cmd = new SqlCommand(getProfileData, con);
                SqlDataReader rdr;
                cmd.Parameters.AddWithValue("@currUserID", Session["UserID"].ToString());
                con.Open();
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    imgProfilePic.ImageUrl = rdr["profilePicture"].ToString();
                    profilePicture.ImageUrl = rdr["profilePicture"].ToString();
                }
                con.Close();

                cmdEditProfile.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());
                cmdEditProfile.Parameters.AddWithValue("@newName", txtName.Text);
                cmdEditProfile.Parameters.AddWithValue("@newGender", ddlGender.SelectedValue);
                cmdEditProfile.Parameters.AddWithValue("@newDOB", txtDOB.Text);
                cmdEditProfile.Parameters.AddWithValue("@newEmail", txtEmail.Text);
                cmdEditProfile.Parameters.AddWithValue("@ProfilePicture", profilePicture.ImageUrl);
                cmdEditProfile.Parameters.AddWithValue("@Desc", txtProfileDesc.Text);
                con.Open();
                cmdEditProfile.ExecuteNonQuery();
                con.Close();
            }
            

            Response.Redirect("~/WebForms/User/UserProfile.aspx");
        }

    }
}