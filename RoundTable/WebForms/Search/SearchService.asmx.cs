using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace RoundTable
{
    /// <summary>
    /// Summary description for SearchService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class SearchService : System.Web.Services.WebService
    {

        [WebMethod]
        public List<string> searchQuery(string keyword)
        {
            string CS = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            List<string> keywords = new List<string>();
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spSearch", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parameter = new SqlParameter("@keyword", keyword);
                cmd.Parameters.Add(parameter);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    //keywords.Add(rdr["postTitle"].ToString());
                    keywords.Add(rdr["topicName"].ToString());
                    //keywords.Add(rdr["postTitle"].ToString());
                    //keywords.Add(rdr["userID"].ToString());
                }
                con.Close();

                con.Open();
                SqlCommand cmdUser = new SqlCommand("spUser", con);
                cmdUser.CommandType = CommandType.StoredProcedure;

                SqlParameter parameterUser = new SqlParameter("@keyword", keyword);
                cmdUser.Parameters.Add(parameterUser);


                SqlDataReader rdrUser = cmdUser.ExecuteReader();
                while (rdrUser.Read())
                {
                    //keywords.Add(rdr["postTitle"].ToString());
                    //keywords.Add(rdr["topicName"].ToString());
                    //keywords.Add(rdr["postTitle"].ToString());
                    keywords.Add(rdrUser["userID"].ToString());
                }
                con.Close();


            }
            return keywords;
        }
    }
}
