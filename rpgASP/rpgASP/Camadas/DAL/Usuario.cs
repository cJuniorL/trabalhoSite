using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace rpgASP.Camadas.DAL
{
    public class Usuario
    {
        private string strCon = Conexao.getConexao();

        public Modelo.Usuario SelectUser(string userName)
        {
            Modelo.Usuario usuario = new Modelo.Usuario();
            usuario.id = -1;
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "SELECT * FROM Usuario WHERE usuario='" + userName + "';";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            conexao.Open();
            try
            {
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    usuario.id = Convert.ToInt32(reader["id"]);
                    usuario.usuario = reader["usuario"].ToString();
                    usuario.senha = reader["senha"].ToString();
                    usuario.email = reader["email"].ToString();
                    usuario.saldo = Convert.ToSingle(reader["saldo"]);
                    usuario.perm = Convert.ToInt32(reader["permicao"]);
                }
            }
            catch
            {
                Console.WriteLine("Deu erro na Seleção de Clientes...");
            }
            finally
            {
                conexao.Close();
            }
            return usuario;
        }

        public Modelo.Usuario SelectId(int id)
        {
            Modelo.Usuario usuario = new Modelo.Usuario();
            usuario.id = -1;
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "SELECT * FROM Usuario WHERE id='" + id + "';";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            conexao.Open();
            try
            {
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    usuario.id = Convert.ToInt32(reader["id"]);
                    usuario.usuario = reader["usuario"].ToString();
                    usuario.senha = reader["senha"].ToString();
                    usuario.email = reader["email"].ToString();
                    usuario.saldo = Convert.ToSingle(reader["saldo"]);
                    usuario.perm = Convert.ToInt32(reader["permicao"]);
                }
            }
            catch
            {
                Console.WriteLine("Deu erro na Seleção de Clientes...");
            }
            finally
            {
                conexao.Close();
            }
            return usuario;
        }

        public Modelo.Usuario SelectEmail(string email)
        {
            Modelo.Usuario usuario = new Modelo.Usuario();
            usuario.id = -1;
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "SELECT * FROM Usuario WHERE email='" + email + "';";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            conexao.Open();
            try
            {
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    usuario.id = Convert.ToInt32(reader["id"]);
                    usuario.usuario = reader["usuario"].ToString();
                    usuario.senha = reader["senha"].ToString();
                    usuario.email = reader["email"].ToString();
                    usuario.saldo = Convert.ToSingle(reader["saldo"]);
                    usuario.perm = Convert.ToInt32(reader["permicao"]);
                }
            }
            catch
            {
                Console.WriteLine("Deu erro na Seleção de Clientes...");
            }
            finally
            {
                conexao.Close();
            }
            return usuario;
        }

        public void Insert(Modelo.Usuario usuario)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "INSERT INTO Usuario VALUES (@usuario, @senha, @email, @saldo, @permicao);";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@usuario", usuario.usuario);
            cmd.Parameters.AddWithValue("@senha", usuario.senha);
            cmd.Parameters.AddWithValue("@email", usuario.email);
            cmd.Parameters.AddWithValue("@saldo", usuario.saldo);
            cmd.Parameters.AddWithValue("@permicao", usuario.perm);
            conexao.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Deu erro na inserção de Cliente...");
            }
            finally
            {
                conexao.Close();
            }
        }

        public void Update(Modelo.Usuario usuario)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Update Usuario set saldo=@saldo ";
            sql += "where id=@id";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", usuario.id);
            cmd.Parameters.AddWithValue("@saldo", usuario.saldo);
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
    }
}