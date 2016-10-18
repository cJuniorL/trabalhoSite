using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace rpgASP.Camadas.DAL
{
    public class Conexao
    {
        public static string getConexao()
        {
            return @"Data Source=.\SQLEXPRESS;Initial Catalog=sRpg;Integrated Security=True";
        }
    }
}