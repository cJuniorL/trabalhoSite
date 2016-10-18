using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace rpgASP.webForms
{
    public partial class inventario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Camadas.DAL.Usuario dalUsuario = new Camadas.DAL.Usuario();
                Camadas.DAL.Jogos dalJogos = new Camadas.DAL.Jogos();
                Camadas.Modelo.Usuario usuario = dalUsuario.SelectId(Convert.ToInt32(Session["id"]));
                Camadas.DAL.JogoUsuario dalJogosUsuario = new Camadas.DAL.JogoUsuario();
                Camadas.DAL.Genero dalGenero = new Camadas.DAL.Genero();
                List<Camadas.Modelo.JogoUsuario> lstJogoUsuario = dalJogosUsuario.SelectIdUser(usuario.id);
                var dados = from j in lstJogoUsuario
                            select new
                            {
                                Jogo = dalJogos.SelectId(j.jogoID).nome,
                                Genero = dalGenero.SelectId(dalJogos.SelectId(j.jogoID).generoID).descricao,
                                Valor = dalJogos.SelectId(j.jogoID).valor.ToString("C2")
                            };
                gdvJogos.DataSource = dados.ToList();
                gdvJogos.DataBind();
            }
        }
    }
}