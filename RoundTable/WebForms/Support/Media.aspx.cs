using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RoundTable.WebForms.Support
{
    public partial class Media : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Panel p1 = (Panel)Master.FindControl("master_aside_panel");
            Panel p2 = (Panel)Master.FindControl("bottom_aside_panel");
            Panel p3 = (Panel)Master.FindControl("whole_body_panel");
            p1.Visible = false;
            p2.Visible = true;
            p3.CssClass = p3.CssClass.Replace("md:flex-row", "md:flex-col");
        }
    }
}