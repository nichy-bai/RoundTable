﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RoundTable.WebForms.Support
{
    public partial class SupportDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Panel p1 = (Panel)Master.FindControl("master_aside_panel");
            p1.Style.Add("display", "none");
        }
    }
}