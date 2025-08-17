using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EB_Prj
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Session.Clear();
                Session.Abandon();

                Response.Redirect("LogIn.aspx");
            }
            catch (Exception es)
            {
                DBHandler.LogExceptiontoDB(es);
            }

            
        }
    }
}