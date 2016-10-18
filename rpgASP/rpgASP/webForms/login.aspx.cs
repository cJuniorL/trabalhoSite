using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using rpgASP.Camadas;
using System.Drawing;

namespace rpgASP.webForms
{
    public partial class login : System.Web.UI.Page
    {
        Color corPadrao;

        protected void Page_Load(object sender, EventArgs e)
        {
            corPadrao = Color.Black;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            corNormal();
            if (verificarCampos())
            {
                Camadas.DAL.Usuario bllUsuario = new Camadas.DAL.Usuario();
                Camadas.Modelo.Usuario usuario = bllUsuario.SelectUser(txtUsuario.Text);
                Session["id"] = usuario.id;
                if (usuario.perm == 0)
                    Response.Redirect("index.aspx");
                else
                    Response.Redirect("indexAdmin.aspx");
            }
        }

        private bool verificarCampos()
        {
            Camadas.DAL.Usuario dalUsuario = new Camadas.DAL.Usuario();
            Camadas.Modelo.Usuario usuario = dalUsuario.SelectUser(txtUsuario.Text);
            if (usuario.id == -1)
            {
                txtUsuario.Focus();
                txtUsuario.BorderColor = Color.Red;
                return false;
            }
            else
            {
                if (usuario.senha != txtSenha.Text)
                {
                    txtSenha.Focus();
                    txtSenha.BorderColor = Color.Red;
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        private void corNormal()
        {
            txtSenha.BorderColor = corPadrao;
            txtUsuario.BorderColor = corPadrao;
        }

        protected void btnCadastro_Click(object sender, EventArgs e)
        {
            Response.Redirect("registro.aspx");
        }
    }
}