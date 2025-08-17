using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EB_Prj
{
    public partial class RetrieveRecent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["count"] != null)
            {
                int count = Convert.ToInt32(Request.QueryString["count"]);
                SqlDataSource1.SelectParameters["count"].DefaultValue = count.ToString();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("BilingPortal.aspx");
            }
            catch (Exception es)
            {
                DBHandler.LogExceptiontoDB(es);
            }
        }
    }
}