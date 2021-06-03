using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RoundTable.WebForms
{
    public partial class RoundTable_master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
        }
    }
}