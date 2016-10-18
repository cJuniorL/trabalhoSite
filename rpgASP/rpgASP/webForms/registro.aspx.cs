using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace rpgASP.webForms
{
    public partial class registro : System.Web.UI.Page
    {
        System.Drawing.Color corPadrao;
        protected void Page_Load(object sender, EventArgs e)
        {
            corPadrao = System.Drawing.Color.Black;
            corNormal();
        }

        protected void btnGravar_Click(object sender, EventArgs e)
        {
            if (verificarCampos())
            {
                Camadas.Modelo.Usuario usuario = new Camadas.Modelo.Usuario();
                usuario.usuario = txtNome.Text;
                usuario.senha = txtSenha.Text;
                usuario.email = txtEmail.Text;
                usuario.perm = 0;
                usuario.saldo = 0;
                Camadas.DAL.Usuario dalUsuario = new Camadas.DAL.Usuario();
                dalUsuario.Insert(usuario);
                Response.Redirect("login.aspx");
            }
        }

        private bool verificarCampos()
        {
            String erro = "";
            Camadas.DAL.Usuario dalUsuario = new Camadas.DAL.Usuario();
            if (dalUsuario.SelectUser(txtNome.Text).id != -1)
            {
                erro += "Nome de usuario já existente";
                txtNome.BorderColor = System.Drawing.Color.Red;
            }
            if (dalUsuario.SelectEmail(txtEmail.Text).id != -1)
            {
                if (erro != "")
                {
                    erro += ", email já cadastro";
                }
                else
                {
                    erro += "Este email já está cadastrado";
                }
                txtEmail.BorderColor = System.Drawing.Color.Red;
            }
            if (txtSenha.Text != txtConfSenha.Text)
            {
                if (erro != "")
                {
                    erro += ", as senhas precisam ser iguais";
                }
                else
                {
                    erro += "Ãs senhas precisam ser iguais";
                }
                txtSenha.BorderColor = System.Drawing.Color.Red;
                txtConfSenha.BorderColor = System.Drawing.Color.Red;
            }
            lblErro.Text = erro;
            return (erro == "");
        }

        private void corNormal()
        {
            txtNome.BorderColor = corPadrao;
            txtSenha.BorderColor = corPadrao;
            txtConfSenha.BorderColor = corPadrao;
            txtEmail.BorderColor = corPadrao;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }
    }
}