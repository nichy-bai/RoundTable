using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RoundTable.WebForms.User
{
    public partial class UserProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!Page.IsPostBack)
            //{
            //    DateRangeValidator.MinimumValue = DateTime.Now.AddYears(-100).ToShortDateString();
            //    DateRangeValidator.MaximumValue = DateTime.Now.Date.ToShortDateString();
            //}
        }

        protected void btnEditProfile_Click(object sender, EventArgs e)
        {

        }
    }
}