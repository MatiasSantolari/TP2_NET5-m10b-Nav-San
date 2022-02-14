using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;

namespace UI.Web
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Persona p = (Persona)Session["USUARIO"];
            if (p == null)
            {
                this.Panel2.Visible = false;
                this.Label1.Visible = false;
                this.Label2.Visible = false;
                this.nombreLabel.Visible = false;

                Response.Redirect("~/AccesoRestringido.aspx");
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session["USUARIO"] = null;
            Response.Redirect("~/Login.aspx");
        }
    }
}