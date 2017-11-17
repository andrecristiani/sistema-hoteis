using SistemaDeHotelaria.Utilitarios;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeHotelaria.Controller
{
    class Servico
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public float Valor { get; set; }
        public int Tipo { get; set; }

        public static List<Servico> listaServicos = new List<Servico>();

        public static void carregarListaServicos()
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[StringBD.nomeString].ToString());
                conn.Open();
                string query = "SELECT * FROM Servico";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader dtr = cmd.ExecuteReader();

                listaServicos.Clear();

                while (dtr.Read())
                {
                    Servico servico = new Servico();
                    servico.Codigo = int.Parse(dtr["servCodigo"].ToString());
                    servico.Descricao = dtr["servDescricao"].ToString();
                    servico.Valor = float.Parse(dtr["servValor"].ToString());
                    servico.Tipo = int.Parse(dtr["tipoCodigo"].ToString());
                    listaServicos.Add(servico);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void inserirServico(Servico servico)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[StringBD.nomeString].ToString());
                conn.Open();

                string query = "insert into servico (servCodigo, servDescricao, servValor, tipoCodigo) values (@Codigo, @Descricao, @Valor, @TipoCodigo);";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Codigo", servico.Codigo.ToString());
                cmd.Parameters.AddWithValue("@Descricao", servico.Descricao);
                cmd.Parameters.AddWithValue("@Valor", servico.Valor.ToString());
                cmd.Parameters.AddWithValue("@TipoCodigo", servico.Tipo.ToString());
                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public static void alterarServico(Servico servico)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[StringBD.nomeString].ToString());
                conn.Open();

                string query = "update produto set servDescricao = @Descricao, servValor = @Valor, tipoCodigo = @TipoCodigo where servCodigo = @Codigo;";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Descricao", servico.Descricao.ToString());
                cmd.Parameters.AddWithValue("@Valor", servico.Valor.ToString());
                cmd.Parameters.AddWithValue("@TipoCodigo", servico.Tipo.ToString());
                cmd.Parameters.AddWithValue("@Codigo", servico.Codigo.ToString());
                cmd.ExecuteNonQuery();

                conn.Close();
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public static void excluirServico(int codigo)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[StringBD.nomeString].ToString());
                conn.Open();

                string query = "delete from servico where servCodigo = @Codigo;";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Codigo", codigo);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch(SqlException ex)
            {
                throw ex;
            }
        }
    }
}
