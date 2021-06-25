using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace RoundTable.WebForms
{
    public partial class RoundTable_master : System.Web.UI.MasterPage
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\RoundTableDB.mdf;Integrated Security=True");
        string userID;

        protected void Page_Load(object sender, EventArgs e)
        {
            //to be modified
            if (Session["UserID"] != null)
            {
                userID = Session["UserID"].ToString();
            }

            string path = HttpContext.Current.Request.Url.AbsolutePath;

            if (path.Contains("Discussion/"))
            {
                nav_home_btn.Attributes.Add("Class", "text-indigo-600");
            }
            else if (path.Contains("Bookmark/"))
            {
                nav_bookmark_btn.Attributes.Add("Class", "text-indigo-600");
            }
            else if (path.Contains("Explore/"))
            {
                nav_explore_btn.Attributes.Add("Class", "text-indigo-600");
            }
            else if (path.Contains("Tag/"))
            {
                nav_tag_btn.Attributes.Add("Class", "text-indigo-600");
            }
            else if (path.Contains("Search/"))
            {
                nav_search_btn.Attributes.Add("Class", "text-indigo-600");
            }

            SqlCommand cmd = new SqlCommand("SELECT profilePicture FROM [User] WHERE userID='" + userID + "'", con);
            con.Open();

            object obj = cmd.ExecuteScalar();

            if (obj != null && DBNull.Value != obj)
            {
                post_user_img.ImageUrl = obj.ToString();
                post_user_img_2.ImageUrl = obj.ToString();
            }

            con.Close();
        }
    }
}