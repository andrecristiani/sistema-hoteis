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
    class ServicoPrestado
    {
        public int servPrestadoCodigo { get; set; }
        public double valorUnitario { get; set; }
        public int quantidade { get; set; }
        public int servCodigo { get; set; }
        public int hospCodigo { get; set; }

        public static List<ServicoPrestado> listaServicosPrestados = new List<ServicoPrestado>();

        public static void adicionarServPrestado(ServicoPrestado serv)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[StringBD.nomeString].ToString());
                conn.Open();
                string query = "insert into servicosPrestados (servPrestadoCodigo, valorUnitario, quantidade, hospCodigo, servCodigo) values (@Codigo, @Valor, @Quantidade, @Hospedagem, @Servico)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Codigo", serv.servPrestadoCodigo);
                cmd.Parameters.AddWithValue("@Valor", serv.valorUnitario);
                cmd.Parameters.AddWithValue("@Quantidade", serv.quantidade);
                cmd.Parameters.AddWithValue("@Hospedagem", serv.hospCodigo);
                cmd.Parameters.AddWithValue("@Servico", serv.servCodigo);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void excluirServicoPrestado(int codigo)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[StringBD.nomeString].ToString());
                conn.Open();

                String query = "DELETE FROM servicosPrestados WHERE servPrestadoCodigo = @Codigo";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Codigo", codigo);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }

        public static void alterarServicoPrestado(ServicoPrestado serv)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[StringBD.nomeString].ToString());
                conn.Open();

                String query = "UPDATE servicosPrestados SET hospCodigo = @Hospedagem, valorUnitario = @VALOR, servCodigo = @Servico, quantidade = @Quantidade WHERE servPrestadoCodigo = @CODIGO";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Hospedagem", serv.hospCodigo);
                cmd.Parameters.AddWithValue("@VALOR", serv.valorUnitario);
                cmd.Parameters.AddWithValue("@Servico", serv.servCodigo);
                cmd.Parameters.AddWithValue("@Quantidade", serv.quantidade);
                cmd.Parameters.AddWithValue("@CODIGO", serv.servPrestadoCodigo);
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
