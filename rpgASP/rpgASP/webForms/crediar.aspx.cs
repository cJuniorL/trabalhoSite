using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace rpgASP.webForms
{
    public partial class crediar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Camadas.DAL.Usuario dalUsuario = new Camadas.DAL.Usuario();
                Camadas.Modelo.Usuario usuario = dalUsuario.SelectId(Convert.ToInt32(Session["id"]));
                lblSaldo.Text = "O seu saldo atual é de: " + usuario.saldo;
            }
        }

        protected void btnDepositar_Click(object sender, EventArgs e)
        {
            try { 
                Camadas.DAL.Usuario dalUsuario = new Camadas.DAL.Usuario();
                Camadas.Modelo.Usuario usuario = dalUsuario.SelectId(Convert.ToInt32(Session["id"]));
                usuario.saldo += Convert.ToSingle(txtValor.Text);
                dalUsuario.Update(usuario);
                txtValor.BorderColor = System.Drawing.Color.Black;
                txtValor.Text = "";
                lblSaldo.Text = "O seu saldo atual é de: " + usuario.saldo;
            }
            catch
            {
                txtValor.BorderColor = System.Drawing.Color.Red;
                txtValor.Text = "";
                txtValor.Focus();
            }
        }
    }
}