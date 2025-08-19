using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EB_Prj
{
    public partial class ViewBilling : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string startDate = Convert.ToDateTime(txtst.Text).ToString("yyyy-MM-dd");
                string endDate = Convert.ToDateTime(txtend.Text).ToString("yyyy-MM-dd");

                Response.Redirect("RetrieveAll.aspx?stdate=" + startDate + "&enddate=" + endDate);
            }
            catch (Exception es)
            {
                DBHandler.LogExceptiontoDB(es);
            }
            
        }
    }
}