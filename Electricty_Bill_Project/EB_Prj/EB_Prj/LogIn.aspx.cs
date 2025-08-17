using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EB_Prj
{
    public partial class LogIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try 
            {
                string email = txtmail.Text;
                string pas = txtpass.Text;

                string result = DBHandler.validateUser(email, pas);

                if (result != null)
                {
                    Session["UserName"] = result;
                    string script = "alert('Login successful!'); window.location='Home.aspx';";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", script, true);
                }
                else
                {
                    string script = "alert('Invalid email or password.');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "error", script, true);
                }
            }
            catch(Exception es)
            {
                DBHandler.LogExceptiontoDB(es);
            }

        }
    }
}