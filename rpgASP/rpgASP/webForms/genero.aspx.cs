using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace rpgASP.webForms
{
    public partial class genero : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Cache["op"] = "X";
                habilitarCampos(false);
            }

        }

        private void habilitarCampos(bool status)
        {
            txtDescricao.Enabled = status;
            if (status)
                btnGravar.Text = "Gravar";
            else
                btnGravar.Text = "Inserir";
            btnCancelar.Enabled = status;
            btnEditar.Enabled = !status;
            btnSelecionar.Enabled = !status;
            btnRemover.Enabled = !status;
            lsbGeneros.Enabled = !status;
            if (Cache["op"].ToString() != "E")
            {
                txtDescricao.Text = "";
            }
            corNormal();
        }

        protected void txtGravar_Click(object sender, EventArgs e)
        {
            string cache = Cache["op"].ToString();
            if (!txtDescricao.Enabled)
            {
                Cache["op"] = "I";
                habilitarCampos(true);
            }
            else
            {
                if (validarDado())
                {
                    Camadas.DAL.Genero dalGenero = new Camadas.DAL.Genero();
                    Camadas.Modelo.Genero genero = new Camadas.Modelo.Genero();
                    genero.descricao = txtDescricao.Text;
                    if (Cache["op"].ToString() == "I")
                    {
                        dalGenero.Insert(genero);
                    }
                    else
                    {
                        genero.id = Convert.ToInt32(lsbGeneros.SelectedValue);
                        dalGenero.Update(genero);
                    }
                    btnGravar.Text = "Inserir";
                    DataBind();
                    Cache["op"] = "X";
                    habilitarCampos(false);
                }
            }

        }

        public void corNormal()
        {
            txtDescricao.BorderColor = System.Drawing.Color.Black;
        }

        public bool validarDado()
        {
            corNormal();
            if (txtDescricao.Text.Trim() == "")
            {
                txtDescricao.BorderColor = System.Drawing.Color.Red;
                txtDescricao.Focus();
                return false;
            }
            return true;
        }

        protected void btnSelecionar_Click(object sender, EventArgs e)
        {
            Camadas.DAL.Genero dalGenero = new Camadas.DAL.Genero();
            int idGenero = Convert.ToInt32(lsbGeneros.SelectedValue);
            Camadas.Modelo.Genero genero = dalGenero.SelectId(idGenero);
            txtDescricao.Text = genero.descricao;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Cache["op"] = "X";
            habilitarCampos(false);
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            if (txtDescricao.Text != "")
            {
                Cache["op"] = "E";
                habilitarCampos(true);
            }
        }

        protected void btnRemover_Click(object sender, EventArgs e)
        {
            if (lsbGeneros.SelectedValue != null)
            {
                int id = Convert.ToInt32(lsbGeneros.SelectedValue);
                Camadas.DAL.Genero bllGenero = new Camadas.DAL.Genero();
                bllGenero.Delete(bllGenero.SelectId(id));
                DataBind();
            }
        }
    }
}