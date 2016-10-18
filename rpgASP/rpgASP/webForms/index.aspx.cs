using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace rpgASP.webForms
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Camadas.DAL.Usuario dalUsuario = new Camadas.DAL.Usuario();
            Camadas.Modelo.Usuario usuario = dalUsuario.SelectId(Convert.ToInt32(Session["id"]));
            lblWelcome.Text = "Bem vindo " + usuario.usuario + "!";
            lblSaldo.Text = "Você possui um saldo de: " + usuario.saldo + ". Caso queira adicionar saldo selecione a opção de Creditar no menu!";
        }
    }
}