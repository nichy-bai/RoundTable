using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace RoundTable.WebForms.Support
{
    public partial class Feedback : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DropDownList1.Items.Insert(0, "[Select a Feedback Category]");
                DropDownList1.Items.Insert(1, "Feature requests");
                DropDownList1.Items.Insert(2, "Bug reports");
                DropDownList1.Items.Insert(3, "Ask questions");
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList1.Items.Remove(DropDownList1.Items.FindByText("[Select a Feedback Category]"));
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DropDownList1.ClearSelection();
            DropDownList1.Items.Insert(0, "[Select a Feedback Category]");

            TextBox1.Text = "";
            TextBox2.Text = "";
        }
    }
}