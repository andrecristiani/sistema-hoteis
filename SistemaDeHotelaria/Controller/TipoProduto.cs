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
    class TipoProduto
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }


        public static List<TipoProduto> carregarListaTipoProduto()
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[StringBD.nomeString].ToString());
                conn.Open();
                string query = "SELECT * FROM tipoProduto";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader dtr = cmd.ExecuteReader();
                List<TipoProduto> listaTipoProduto = new List<TipoProduto>();

                while (dtr.Read())
                {
                    TipoProduto tp = new TipoProduto();
                    tp.Codigo = int.Parse(dtr["tipoCodigo"].ToString());
                    tp.Descricao = dtr["tipoDescricao"].ToString();
                    listaTipoProduto.Add(tp);
                }
                conn.Close();
                return listaTipoProduto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void inserirTipoProduto(TipoProduto tipoProduto)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[StringBD.nomeString].ToString());
                conn.Open();
                string query = "insert into tipoProduto (tipoCodigo, tipoDescricao) values (@Codigo, @Descricao);";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Codigo", tipoProduto.Codigo.ToString());
                cmd.Parameters.AddWithValue("@Descricao", tipoProduto.Descricao);
                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static void alterarTipoProduto(TipoProduto tipoProduto)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[StringBD.nomeString].ToString());
                conn.Open();
                string query = "update tipoProduto set tipoDescricao = @Descricao where tipoCodigo = @Codigo;";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Codigo", tipoProduto.Codigo.ToString());
                cmd.Parameters.AddWithValue("@Descricao", tipoProduto.Descricao);
                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void excluirTipoProduto(TipoProduto tipoProduto)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[StringBD.nomeString].ToString());
                conn.Open();
                string query = "delete from tipoProduto where tipoCodigo = @Codigo;";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Codigo", tipoProduto.Codigo.ToString());
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
