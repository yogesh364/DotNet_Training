using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EB_Prj
{
    public partial class BilingPortal : System.Web.UI.Page
    {
        private int total
        {
            get { return Session["total"] != null ? (int)Session["total"] : 0; }
            set { Session["total"] = value; }
        }
        private int currentCount
        {
            get { return Session["currentCount"] != null ? (int)Session["currentCount"] : 0; }
            set { Session["currentCount"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                currentCount = 0;
                total = 0;

            }
        }

        protected void txtunits_TextChanged(object sender, EventArgs e)
        {
            int units = Convert.ToInt32(txtunits.Text);
            double bill = DBHandler.calculateBill(units);
            txtamt.Text = bill.ToString("F2");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentCount == 0)
                {
                    total = Convert.ToInt32(txtno.Text);
                    txtno.ReadOnly = true;
                }

                int units = Convert.ToInt32(txtunits.Text);
                double bill = DBHandler.calculateBill(units);

                bool result = DBHandler.saveBill(txtcustno.Text, txtname.Text.ToString(), units, bill);

                if (result == true)
                {
                    success.Visible = true;
                }

                currentCount++;

                txtcustno.Text = "";
                txtname.Text = "";
                txtunits.Text = "";
                txtamt.Text = "";

                if (currentCount == total)
                {
                    btnSave.Visible = false;
                    btnRetrieve.Visible = true;

                    txtcustno.ReadOnly = true;
                    txtname.ReadOnly = true;
                    txtunits.ReadOnly = true;
                    txtamt.ReadOnly = true;
                }
            }
            catch (Exception es)
            {
                DBHandler.LogExceptiontoDB(es);
            }
        }

        protected void btnRetrieve_Click(object sender, EventArgs e)
        {

            try
            {
                Response.Redirect("RetrieveRecent.aspx?count=" + total);

                txtno.ReadOnly = false;
                txtcustno.ReadOnly = false;
                txtname.ReadOnly = false;
                txtunits.ReadOnly = false;
                txtamt.ReadOnly = false;
                txtno.Text = "";
                total = 0;
                currentCount = 0;

                btnSave.Visible = true;
                btnRetrieve.Visible = false;
            }
            catch (Exception es)
            {
                DBHandler.LogExceptiontoDB(es);
            }
           
        }

        protected void txtcustno_TextChanged(object sender, EventArgs e)
        {
            success.Visible = false;
        }
    }
}