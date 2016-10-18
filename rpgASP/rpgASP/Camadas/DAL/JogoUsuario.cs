using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace rpgASP.Camadas.DAL
{
    public class JogoUsuario
    {
        private string strCon = Conexao.getConexao();

        public void Insert(Modelo.JogoUsuario jogoUsuario)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "INSERT INTO JogosUsuarios VALUES (@jogoID, @usuarioID);";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@jogoID", jogoUsuario.jogoID);
            cmd.Parameters.AddWithValue("@usuarioID", jogoUsuario.usuarioID);
            conexao.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Deu erro na inserção de JogoUsuario...");
            }
            finally
            {
                conexao.Close();
            }
        }

        public List<Modelo.JogoUsuario> SelectIdUser(int id)
        {
            List<Modelo.JogoUsuario> lstJogoUsuario = new List<Modelo.JogoUsuario>();
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "SELECT * FROM JogosUsuarios WHERE usuarioID=" + id + ";";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            conexao.Open();
            try
            {
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    Camadas.Modelo.JogoUsuario jogoUsuario = new Modelo.JogoUsuario();
                    jogoUsuario.usuarioID = Convert.ToInt32(reader["usuarioID"]);
                    jogoUsuario.jogoID = Convert.ToInt32(reader["jogoID"]);
                    lstJogoUsuario.Add(jogoUsuario);
                }
            }
            catch
            {
                Console.WriteLine("Deu erro na Seleção de Genero...");
            }
            finally
            {
                conexao.Close();
            }
            return lstJogoUsuario;
        }

    }
}