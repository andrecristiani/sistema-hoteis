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
    class Consumo
    {
        public int consumoCodigo { get; set; }
        public double valorUnitario { get; set; }
        public int quantidade { get; set; }
        public int hospCodigo { get; set; }
        public int prodCodigo { get; set; }

        public static void adicionarConsumo(Consumo cons)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[StringBD.nomeString].ToString());
                conn.Open();
                string query = "insert into consumo (consumoCodigo, valorUnitario, quantidade, hospCodigo, prodCodigo) values (@Codigo ,@Valor, @Quantidade, @Hospedagem, @Produto)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Codigo", cons.consumoCodigo);
                cmd.Parameters.AddWithValue("@Valor", cons.valorUnitario);
                cmd.Parameters.AddWithValue("@Quantidade", cons.quantidade);
                cmd.Parameters.AddWithValue("@Hospedagem", cons.hospCodigo);
                cmd.Parameters.AddWithValue("@Produto", cons.prodCodigo);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
               throw ex;
            }
        }

        public static void excluirConsumo(int codigoConsumo)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[StringBD.nomeString].ToString());
                conn.Open();

                String query = "DELETE FROM consumo WHERE consumoCodigo = @Codigo";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Codigo", codigoConsumo);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }

        public static void alterarConsumo(Consumo cons)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[StringBD.nomeString].ToString());
                conn.Open();

                String query = "UPDATE consumo SET hospCodigo = @Hospedagem, valorUnitario = @VALOR, prodCodigo = @Produto, quantidade = @Quantidade WHERE consumoCodigo = @CODIGO";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Hospedagem", cons.hospCodigo.ToString());
                cmd.Parameters.AddWithValue("@VALOR", cons.valorUnitario.ToString());
                cmd.Parameters.AddWithValue("@Produto", cons.prodCodigo.ToString());
                cmd.Parameters.AddWithValue("@Quantidade", cons.quantidade.ToString());
                cmd.Parameters.AddWithValue("@CODIGO", cons.consumoCodigo.ToString());
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
