using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace rpgASP.Camadas.Modelo
{
    public class Usuario
    {
        public int id { get; set; }

        public string usuario { get; set; }

        public string senha { get; set; }

        public string email { get; set; }

        public float saldo { get; set; }

        public int perm { get; set; }

    }
}