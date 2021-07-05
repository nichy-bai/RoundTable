using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RoundTable.WebForms.Explore
{
    public partial class Explore : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\RoundTableDB.mdf;Integrated Security=True");
        //string topicID;

        protected void Page_Load(object sender, EventArgs e)
        {
            //topicID = "TP" + Request.QueryString["p"];
            //if (!this.IsPostBack)
            //{
            //    this.BindRepeater();
            //}
        }

        protected void post_btn_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("../Explore/TrendingDiscussion.aspx");
        }

        protected void trendingPost_btn_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("../Explore/TrendingDiscussion.aspx");
        }

        protected void topic_btn_Command(object sender, CommandEventArgs e)
        {
            string topicID = e.CommandArgument.ToString();
            Response.Redirect("../Explore/TrendingTopic.aspx?topic=" + topicID.Substring(2, topicID.Length - 2));
        }

        //protected void trendingTopic_btn_Command(object sender, CommandEventArgs e)
        //{
        //    Response.Redirect("../Explore/TrendingTopic.aspx");
        //}

        //private void BindRepeater()
        //{
        //    using (con)
        //    {
        //        //RMB ADD SELECT statement here
        //        using (SqlCommand cmd = new SqlCommand("SELECT TOP 3 Topic.topicName, COUNT(*) AS totalTopic FROM Post GROUP BY topicName ORDER BY totalTopic DESC", con))
        //        {
        //            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
        //            {
        //                DataTable dt = new DataTable();
        //                sda.Fill(dt);
        //                Repeater1.DataSource = dt;
        //                Repeater1.DataBind();
        //            }
        //        }
        //    }
        //}
    }
}