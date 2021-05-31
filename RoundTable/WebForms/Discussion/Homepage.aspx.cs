using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RoundTable.WebForms.Discussion
{
    public partial class Homepage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void postTitle_btn_Command(object sender, CommandEventArgs e)
        {
            string postID = e.CommandArgument.ToString();
            Response.Redirect("DiscussionPost.aspx?postID=" + postID);
        }
    }
}