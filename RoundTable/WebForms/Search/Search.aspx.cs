using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RoundTable.WebForms.Search
{
    public partial class Search : System.Web.UI.Page
    {
        DataAccess DA = new DataAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            Repeater1.Visible = true;
            lblNoResult.Text = "";
        }

        protected void postBody_btn_Command(object sender, CommandEventArgs e)
        {
            string postID = e.CommandArgument.ToString();
            //Response.Redirect("DiscussionPost.aspx?p=" + postID);
            Response.Redirect("../Discussion/DiscussionPost.aspx?p=" + postID.Substring(2, postID.Length - 2));
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //Get keyword from textbox
            string searchKey = txtSearch.Text;
            //If the search box is not empty
            if (string.IsNullOrEmpty(searchKey) != true)
            {
                lblNoResult.Text = "";

                //Get the result of the search
                DataTable dt = DA.searchQuery(searchKey);
                //If there is at least one row
                if (dt.Rows.Count > 0)
                {
                    Repeater1.Visible = true;
                    Repeater1.DataSource = dt; //Retrieve the data from table based on the search text
                    Repeater1.DataBind(); //Bind the data to the repeater
                }
                else
                {
                    lblNoResult.Text = "No Results.";
                    Repeater1.Visible = false;
                }
            }
            else
            {
                Repeater1.Visible = true;
            }
        }
    }

    internal class DataAccess
    {
        public DataTable searchQuery(string searchKey)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\RoundTableDB.mdf;Integrated Security=True");
            SqlDataAdapter DA = new SqlDataAdapter("searchQuery", con);
            DA.SelectCommand.CommandType = CommandType.StoredProcedure;
            DA.SelectCommand.Parameters.AddWithValue("@SearchKey", searchKey);
            DataTable dt = new DataTable();
            DA.Fill(dt);
            return dt;
        }
    }
}