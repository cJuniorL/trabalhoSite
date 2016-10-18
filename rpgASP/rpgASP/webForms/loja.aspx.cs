using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace rpgASP.webForms
{
    public partial class loja : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Camadas.DAL.Usuario bllUsuario = new Camadas.DAL.Usuario();
                lblCarteira.Text =  bllUsuario.SelectId(Convert.ToInt32(Session["id"])).saldo.ToString("C2");
            }
        }

        protected void gdvLoja_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Camadas.DAL.Jogos dalJogo = new Camadas.DAL.Jogos();
            Camadas.DAL.Genero dalGenero = new Camadas.DAL.Genero();
            Camadas.Modelo.Jogo jogo = dalJogo.SelectId(Convert.ToInt32(gdvLoja.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text));
            List<Camadas.Modelo.Jogo> lstJogo = new List<Camadas.Modelo.Jogo>();
            float valor = 0;
            foreach (GridViewRow row in gdvCarrinho.Rows)
            {
                Camadas.Modelo.Jogo jogoL = dalJogo.SelectId(Convert.ToInt32(row.Cells[0].Text));
                valor += jogoL.valor;
                lstJogo.Add(jogoL);

            }
            if (lstJogo.Count(c => c.nome == jogo.nome) == 0)
            {
                valor += jogo.valor;
                lstJogo.Add(jogo);
            }
            lblTotal.Text = "O Carrinho possui o total de " + valor.ToString("C2") + " em jogos.";
            Cache["total"] = valor;
            var dados = from j in lstJogo
                        select new
                        {
                            ID = j.id,
                            Nome = j.nome,
                            Genero = dalGenero.SelectId(j.generoID).descricao,
                            Valor = j.valor,
                        };
            gdvCarrinho.DataSource = dados.ToList();
            gdvCarrinho.DataBind();
        }

        protected void gdvLoja_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnFinalizar_Click(object sender, EventArgs e)
        {
            Camadas.Modelo.JogoUsuario jogoUsuario = new Camadas.Modelo.JogoUsuario();
            Camadas.DAL.Usuario dalUsuario = new Camadas.DAL.Usuario();
            Camadas.Modelo.Usuario usuario = dalUsuario.SelectId(Convert.ToInt32(Session["id"]));
            Camadas.DAL.Jogos dalJogo = new Camadas.DAL.Jogos();
            Camadas.DAL.JogoUsuario dalJogoUsuario = new Camadas.DAL.JogoUsuario();
            jogoUsuario.usuarioID = usuario.id;
            foreach (GridViewRow row in gdvCarrinho.Rows)
            {
                Camadas.Modelo.Jogo jogoL = dalJogo.SelectId(Convert.ToInt32(row.Cells[0].Text));
                jogoUsuario.jogoID = jogoL.id;
                dalJogoUsuario.Insert(jogoUsuario);
                usuario.saldo -= jogoL.valor;
            }
            dalUsuario.Update(usuario);
            Response.Redirect("inventario.aspx");
        }
    }
}