using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace rpgASP.Camadas.DAL
{
    public class Jogos
    {
        private string strCon = Conexao.getConexao();

        public void Insert(Modelo.Jogo jogo)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "INSERT INTO Jogos VALUES (@nome, @valor, @idGenero);";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@nome", jogo.nome);
            cmd.Parameters.AddWithValue("@valor", jogo.valor);
            cmd.Parameters.AddWithValue("@idGenero", jogo.generoID);
            conexao.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Deu erro na inserção de Jogo...");
            }
            finally
            {
                conexao.Close();
            }
        }

        public void Update(Modelo.Jogo jogo)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Update Jogos set nome=@nome, valor=@valor, idGenero=@idGenero ";
            sql += "where id=@id";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", jogo.id);
            cmd.Parameters.AddWithValue("@nome", jogo.nome);
            cmd.Parameters.AddWithValue("@valor", jogo.valor);
            cmd.Parameters.AddWithValue("@idGenero", jogo.generoID);

            conexao.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Deu erro na Atualização de Jogo...");
            }
            finally
            {
                conexao.Close();
            }
        }

        public void Delete(Modelo.Jogo jogo)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Delete from Jogos where id=@id";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", jogo.id);

            conexao.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Deu erro na Remoção de Jogo...");
            }
            finally
            {
                conexao.Close();
            }
        }

        public Modelo.Jogo SelectId(int id)
        {
            Modelo.Jogo jogo = new Modelo.Jogo();
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "SELECT * FROM Jogos WHERE id='" + id + "';";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            conexao.Open();
            try
            {
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    jogo.id = Convert.ToInt32(reader["id"]);
                    jogo.nome = reader["nome"].ToString();
                    jogo.valor = Convert.ToSingle(reader["valor"]);
                    jogo.generoID = Convert.ToInt32(reader["idGenero"]);
                }
            }
            catch
            {
                Console.WriteLine("Deu erro na Seleção de Jogo...");
            }
            finally
            {
                conexao.Close();
            }
            return jogo;
        }

     }

}