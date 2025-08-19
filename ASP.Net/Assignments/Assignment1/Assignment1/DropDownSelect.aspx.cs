using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment1
{
    public partial class DropDownSelect : System.Web.UI.Page
    {

        int ac = 40000;
        int tv = 50000;
        int wc = 20000;

        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            if (!IsPostBack)
            {
                products.Items.Add(new ListItem("Select a Product", ""));
                products.Items.Add(new ListItem("AC", "AC.jpg"));
                products.Items.Add(new ListItem("TV", "TV.jpg"));
                products.Items.Add(new ListItem("Washing Machine", "Washing Machine.jpg"));
            }
        }

        protected void products_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (products.SelectedValue != "")
            {
                imgProduct.Visible = true;
                imgProduct.ImageUrl = "~/Images/" + products.SelectedValue;
            }
            else
            {
                imgProduct.ImageUrl = "";
            }

            btnGetPrice.Visible = true;
            lblPrice.Text = "";
        }

        protected void btnGetPrice_Click(object sender, EventArgs e)
        {
            string selected = products.SelectedItem.Text;

            if (selected == "TV")
            {
                lblPrice.Text = "Price: " + tv;
            }
            else if (selected == "AC")
            {
                lblPrice.Text = "Price: " + ac;
            }
            else if (selected == "Washing Machine")
            {
                lblPrice.Text = "Price: " + wc;
            }
            else
            {
                lblPrice.Text = "Please select a product.";
            }
        }
    }
}