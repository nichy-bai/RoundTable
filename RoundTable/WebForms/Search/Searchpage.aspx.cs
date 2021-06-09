using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web.Services;
using System.Web.Script.Services;
using System.Data;

namespace RoundTable.WebForms.Search
{
    public partial class Searchpage : System.Web.UI.Page
    {
        DataAccess DA = new DataAccess();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //get keyword from textbox
            string keyword = txtSearch.Text;
            //if the search box is not empty
            if (string.IsNullOrEmpty(keyword) != true)
            {
                lblNoResult.Text = "";

                //get the result of the search
                DataTable dt = DA.searchQuery(keyword);
                //if there is at least one row
                if (dt.Rows.Count > 0)
                {
                    Repeater1.Visible = true;
                    Repeater1.DataSource = dt; //repeater get the data from table based on the search text
                    Repeater1.DataBind(); //bind the data to the repeater
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

        [ScriptMethod()]
        [WebMethod]
        public static List<string> SearchCustomers(string prefixText, int count)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select postTitle from Post where postTitle like @SearchText + '%'";
                    cmd.Parameters.AddWithValue("@SearchText", prefixText);
                    cmd.Connection = conn;
                    conn.Open();
                    List<string> customers = new List<string>();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            customers.Add(sdr["postTitle"].ToString());
                        }
                    }
                    conn.Close();

                    return customers;
                }
            }
        }
    }

    internal class DataAccess
    {
        public DataTable searchQuery(string keyword)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\RoundTableDB.mdf;Integrated Security=True");
            SqlDataAdapter DA = new SqlDataAdapter("spSearch", con);
            DA.SelectCommand.CommandType = CommandType.StoredProcedure;
            DA.SelectCommand.Parameters.AddWithValue("@keyword", keyword);
            DataTable dt = new DataTable();
            DA.Fill(dt);
            return dt;
        }
    }
}