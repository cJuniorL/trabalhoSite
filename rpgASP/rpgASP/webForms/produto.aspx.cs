using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace rpgASP.webForms
{
    public partial class produto : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Cache["op"] = "X";
                habilitarCampos(false);
                Cache["idJogo"] = "-1";
            }
        }

        private void habilitarCampos(bool status)
        {
            btnInserir.Enabled = !status;
            btnEditar.Enabled = !status;
            btnCancelar.Enabled = status;
            btnGravar.Enabled = status;
            btnRemover.Enabled = !status;
            txtNome.Enabled = status;
            txtValor.Enabled = status;
            ddlGenero.Enabled = status;
            if (Cache["op"].ToString() != "E")
            {
                txtNome.Text = "";
                txtValor.Text = "";
                ddlGenero.SelectedValue = null;
            }
        }

        protected void btnInserir_Click(object sender, EventArgs e)
        {
            Cache["op"] = "I";
            habilitarCampos(true);
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Cache["idJogo"]) > -1)
            {
                Cache["op"] = "E";
                habilitarCampos(true);
            }
        }

        protected void btnGravar_Click(object sender, EventArgs e)
        {
            Camadas.DAL.Jogos dalJogo = new Camadas.DAL.Jogos();
            Camadas.Modelo.Jogo jogo = new Camadas.Modelo.Jogo();
            jogo.nome = txtNome.Text;
            jogo.generoID = Convert.ToInt32(ddlGenero.SelectedValue);
            jogo.valor = Convert.ToSingle(txtValor.Text);
            if (Cache["op"].ToString() == "I")
            {
                dalJogo.Insert(jogo);
            }
            else
            {
                jogo.id = Convert.ToInt32(Cache["idJogo"]);
                dalJogo.Update(jogo);
            }
            Cache["idJogo"] = -1;
            Cache["op"] = "X";  
            gdvJogos.DataBind();
            habilitarCampos(false);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Cache["op"] = "X";
            habilitarCampos(false);
            Cache["idJogo"] = -1;
        }

        protected void btnRemover_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Cache["idJogo"]) > -1)
            {
                Camadas.DAL.Jogos dalJogos = new Camadas.DAL.Jogos();
                dalJogos.Delete(dalJogos.SelectId(Convert.ToInt32(Cache["idJogo"])));
                Cache["idJogo"] = -1;
                Cache["op"] = "X";
                habilitarCampos(false);
                gdvJogos.DataBind();
            }
        }

        protected void gdvJogos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Cache["idJogo"] = Convert.ToInt32(gdvJogos.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text);
            Camadas.DAL.Jogos dalJogo = new Camadas.DAL.Jogos();
            Camadas.Modelo.Jogo jogo = dalJogo.SelectId(Convert.ToInt32(Cache["idJogo"]));
            txtNome.Text = jogo.nome;
            txtValor.Text = jogo.valor.ToString();
            ddlGenero.SelectedValue = jogo.generoID.ToString();
        }
    }
}