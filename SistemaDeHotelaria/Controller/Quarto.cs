using SistemaDeHotelaria.Utilitarios;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeHotelaria.Domain
{
    public class Quarto
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public int Numero { get; set; }
        public string  Andar { get; set; }
        public int QtdPessoas { get; set; }
        public string Ramal { get; set; }
        public string Observacao { get; set; }
        public float Valor { get; set; }

        public static List<Quarto> listaQuartos = new List<Quarto>();

        public static void carregarListaQuartos()
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[StringBD.nomeString].ToString());
                conn.Open();
                string query = "SELECT * FROM quarto";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader dtr = cmd.ExecuteReader();

                listaQuartos.Clear();

                while (dtr.Read())
                {
                    Quarto quarto = new Quarto();
                    quarto.Codigo = int.Parse(dtr["quartoCodigo"].ToString());
                    quarto.Descricao = dtr["quartoDescricao"].ToString();
                    quarto.Numero = int.Parse(dtr["quartoNumero"].ToString());
                    quarto.Andar = dtr["quartoAndar"].ToString();
                    quarto.QtdPessoas = int.Parse(dtr["quartoQtdPessoas"].ToString());
                    quarto.Ramal = dtr["quartoRamal"].ToString();
                    quarto.Observacao = dtr["quartoObservacao"].ToString();
                    quarto.Valor = float.Parse(dtr["quartoValor"].ToString());
                    listaQuartos.Add(quarto);
                  
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void inserirQuarto(Quarto quarto)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[StringBD.nomeString].ToString());
                conn.Open();

                string query = "INSERT INTO quarto (quartoCodigo, quartoDescricao, quartoNumero, quartoAndar, quartoQtdPessoas, quartoRamal, quartoObservacao, quartoValor) values (@Codigo, @Descricao, @Numero, @Andar, @QtdPessoas, @Ramal, @Observacao, @Valor);";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Codigo", quarto.Codigo.ToString());
                cmd.Parameters.AddWithValue("@Descricao", quarto.Descricao.ToString());
                cmd.Parameters.AddWithValue("@Numero", quarto.Numero.ToString());
                cmd.Parameters.AddWithValue("@Andar", quarto.Andar.ToString());
                cmd.Parameters.AddWithValue("@QtdPessoas", quarto.QtdPessoas.ToString());
                cmd.Parameters.AddWithValue("@Ramal", quarto.Ramal.ToString());
                cmd.Parameters.AddWithValue("@Observacao", quarto.Observacao.ToString());
                cmd.Parameters.AddWithValue("@Valor", quarto.Valor.ToString());
                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void excluirQuarto(int codigoQuarto)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[StringBD.nomeString].ToString());
                conn.Open();

                String query = "DELETE FROM quarto WHERE quartodCodigo = @Codigo";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Codigo", codigoQuarto);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }

        public static void alterarQuarto(Quarto quarto)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[StringBD.nomeString].ToString());
                conn.Open();

                String query = "UPDATE quarto SET quartoDescricao = @Descricao, quartoNumero = @Numero, quartoAndar = @Andar, quartoQtdPessoas = @QtdPessoas, quartoRamal = @Ramal, quartoObservacao = @Observacao, quartoValor = @Valor where quartoCodigo = @Codigo";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Codigo", quarto.Codigo.ToString());
                cmd.Parameters.AddWithValue("@Descricao", quarto.Descricao.ToString());
                cmd.Parameters.AddWithValue("@Numero", quarto.Numero.ToString());
                cmd.Parameters.AddWithValue("@Andar", quarto.Andar.ToString());
                cmd.Parameters.AddWithValue("@QtdPessoas", quarto.QtdPessoas.ToString());
                cmd.Parameters.AddWithValue("@Ramal", quarto.Ramal.ToString());
                cmd.Parameters.AddWithValue("@Observacao", quarto.Observacao.ToString());
                cmd.Parameters.AddWithValue("@Valor", quarto.Valor.ToString());
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
