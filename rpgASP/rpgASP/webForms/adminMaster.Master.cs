using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using rpgASP.Camadas;

namespace rpgASP.webForms
{
    public partial class adminMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["id"] != null){
                Camadas.DAL.Usuario dalUsuario = new Camadas.DAL.Usuario();
                if (dalUsuario.SelectId(Convert.ToInt32(Session["id"])).perm == 0)
                {
                    Response.Redirect("login.aspx");
                }
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session["id"] = null;
            Response.Redirect("login.aspx");
        }
    }
}