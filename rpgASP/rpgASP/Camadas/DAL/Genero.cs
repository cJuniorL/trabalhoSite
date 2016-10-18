using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace rpgASP.Camadas.DAL
{
    public class Genero
    {
        private string strCon = Conexao.getConexao();

        public List<Modelo.Genero> Select()
        {
            List<Modelo.Genero> lstGenero = new List<Modelo.Genero>();
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Select * from genero";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            conexao.Open();
            try
            {
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (reader.Read())
                {
                    Modelo.Genero genero = new Modelo.Genero();
                    genero.id = Convert.ToInt32(reader["id"]);
                    genero.descricao = reader["descricao"].ToString();
                    lstGenero.Add(genero);
                }
                return lstGenero;
            }
            catch
            {
                Console.WriteLine("Deu erro na seleção de Genero...");
            }
            finally
            {
                conexao.Close();
            }
            return lstGenero;
        }

        public void Insert(Modelo.Genero genero)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "INSERT INTO genero VALUES (@descricao);";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@descricao", genero.descricao);
            conexao.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Deu erro na inserção de Genero...");
            }
            finally
            {
                conexao.Close();
            }
        }

        public Modelo.Genero SelectId(int id)
        {
            Modelo.Genero genero = new Modelo.Genero();
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "SELECT * FROM genero WHERE id='" + id + "';";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            conexao.Open();
            try
            {
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    genero.id = Convert.ToInt32(reader["id"]);
                    genero.descricao = reader["descricao"].ToString();
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
            return genero;
        }

        public void Update(Modelo.Genero genero)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Update genero set descricao=@descricao ";
            sql += "where id=@id";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", genero.id);
            cmd.Parameters.AddWithValue("@descricao", genero.descricao); 
            conexao.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Deu erro na Atualização de genero...");
            }
            finally
            {
                conexao.Close();
            }
        }

        public void Delete(Modelo.Genero genero)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Delete from genero where id=@id";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", genero.id);

            conexao.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Deu erro na Remoção de Clientes...");
            }
            finally
            {
                conexao.Close();
            }
        }
    }

}