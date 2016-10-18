using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace rpgASP.Camadas.Modelo
{
    public class Jogo
    {
        public int id { get; set; }
        public string nome { get; set; }
        public float valor { get; set; }
        public int generoID { get; set; }
        public virtual string generoDescr
        {
            get
            {
                Camadas.DAL.Genero dalGenero = new DAL.Genero();
                return dalGenero.SelectId(id).descricao;
            }
        }
    }
}