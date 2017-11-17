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
    class UnidadeProduto
    {
        public int Codigo { get; set; }
        public string Unidade { get; set; }
        public string Resumo { get; set; }

        public static List<UnidadeProduto> listaUnidades()
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[StringBD.nomeString].ToString());
                conn.Open();
                string query = "SELECT * FROM unidadeProduto";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader dtr = cmd.ExecuteReader();
                List<UnidadeProduto> listaUnidades = new List<UnidadeProduto>();

                while (dtr.Read())
                {
                    UnidadeProduto up = new UnidadeProduto();
                    up.Codigo = int.Parse(dtr["unidadeCodigo"].ToString());
                    up.Unidade = dtr["unidadeDescricao"].ToString();
                    up.Resumo = dtr["unidadeResumo"].ToString();
                    listaUnidades.Add(up);
                }
                conn.Close();
                return listaUnidades;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void inserirUnidadeProduto(UnidadeProduto unidadeProduto)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[StringBD.nomeString].ToString());
                conn.Open();
                string query = "insert into unidadeProduto (unidadeCodigo, unidadeDescricao, unidadeResumo) values (@Codigo, @Descricao, @Resumo);";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Codigo", unidadeProduto.Codigo.ToString());
                cmd.Parameters.AddWithValue("@Descricao", unidadeProduto.Unidade);
                cmd.Parameters.AddWithValue("@Resumo", unidadeProduto.Resumo);
                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static void alterarUnidadeProduto(UnidadeProduto unidadeProduto)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[StringBD.nomeString].ToString());
                conn.Open();
                string query = "update unidadeProduto set unidadeDescricao = @Descricao, unidadeResumo = @Resumo where unidadeCodigo = @Codigo;";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Codigo", unidadeProduto.Codigo.ToString());
                cmd.Parameters.AddWithValue("@Descricao", unidadeProduto.Unidade);
                cmd.Parameters.AddWithValue("@Resumo", unidadeProduto.Resumo);
                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void excluirUnidadeProduto(int codigo)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[StringBD.nomeString].ToString());
                conn.Open();
                string query = "delete from unidadeProduto where unidadeCodigo = @Codigo;";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Codigo", codigo);
                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
