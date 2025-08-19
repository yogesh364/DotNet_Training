using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EB_Prj
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if(Session["UserName"] != null)
                {
                    string user = Session["UserName"].ToString();
                    lblWelcome.Text = "Welcome,  " + user + "!";
                }
                else if (Session["UserName"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
            }

            load();

        }

        private void load()
        {
            var details = DBHandler.statistics();

            lblTotalBills.Text = details.bill.ToString();
            lblTotalUnits.Text = details.unit.ToString();
            lblTotalRevenue.Text = details.amt.ToString();
        }
    }
}