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
    class Produto
    {
        public int Codigo { get; set; }
        public String Descricao { get; set; }
        public float Valor { get; set; }
        public int Tipo { get; set; }
        public int Unidade { get; set; }

        public static List<Produto> listaProdutos = new List<Produto>();

        public static void carregarListaProdutos()
        {
            try{
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[StringBD.nomeString].ToString());
                conn.Open();
                string query = "SELECT * FROM produto";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader dtr = cmd.ExecuteReader();

                listaProdutos.Clear();

                while (dtr.Read())
                {
                    Produto produto = new Produto();
                    produto.Codigo = int.Parse(dtr["prodCodigo"].ToString());
                    produto.Descricao = dtr["prodDescricao"].ToString();
                    produto.Valor = float.Parse(dtr["prodValor"].ToString());
                    produto.Tipo = int.Parse(dtr["tipoCodigo"].ToString());
                    produto.Unidade = int.Parse(dtr["unidadeCodigo"].ToString());
                    listaProdutos.Add(produto);
                }
                conn.Close();
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public static void inserirProduto(Produto produto)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[StringBD.nomeString].ToString());
                conn.Open();

                string query = "INSERT INTO produto (prodCodigo, prodDescricao, prodValor, tipoCodigo, unidadeCodigo) values (@Codigo, @Descricao, @Valor, @Tipo, @Unidade);";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Codigo", produto.Codigo.ToString());
                cmd.Parameters.AddWithValue("@Descricao", produto.Descricao.ToString());
                cmd.Parameters.AddWithValue("@Valor", produto.Valor.ToString());
                cmd.Parameters.AddWithValue("@Tipo", produto.Tipo.ToString());
                cmd.Parameters.AddWithValue("@Unidade", produto.Unidade.ToString());
                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void excluirProduto(int codigoProduto)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[StringBD.nomeString].ToString());
                conn.Open();

                String query = "DELETE FROM produto WHERE prodCodigo = @Codigo";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Codigo", codigoProduto);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }

        public static void alterarProduto(Produto produto)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[StringBD.nomeString].ToString());
                conn.Open();

                String query = "UPDATE produto SET prodDescricao = @DESCRICAO, prodValor = @VALOR, tipoCodigo = @TIPO, unidadeCodigo = @UNIDADE WHERE prodCodigo = @CODIGO";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@DESCRICAO", produto.Descricao.ToString());
                cmd.Parameters.AddWithValue("@VALOR", produto.Valor.ToString());
                cmd.Parameters.AddWithValue("@TIPO", produto.Tipo.ToString());
                cmd.Parameters.AddWithValue("@UNIDADE", produto.Unidade.ToString());
                cmd.Parameters.AddWithValue("@CODIGO", produto.Codigo.ToString());
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
