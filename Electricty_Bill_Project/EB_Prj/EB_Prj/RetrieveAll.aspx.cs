using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EB_Prj
{
    public partial class RetrieveAll : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("ViewBilling.aspx");
            }
            catch (Exception es)
            {
                DBHandler.LogExceptiontoDB(es);
            }
            
        }
    }
}