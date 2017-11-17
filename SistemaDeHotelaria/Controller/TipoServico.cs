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
    class TipoServico
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }

        public static List<TipoServico> listaTipoServicos = new List<TipoServico>();

        public static List<TipoServico> carregarListaTiposServico()
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[StringBD.nomeString].ToString());
                conn.Open();
                string query = "SELECT * FROM tipoServico";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader dtr = cmd.ExecuteReader();
                List<TipoServico> listaTipoServico = new List<TipoServico>();

                while (dtr.Read())
                {
                    TipoServico tp = new TipoServico();
                    tp.Codigo = int.Parse(dtr["tipoCodigo"].ToString());
                    tp.Descricao = dtr["tipoDescricao"].ToString();
                    listaTipoServico.Add(tp);
                }

                conn.Close();
                return listaTipoServico;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void inserirTipoServico(TipoServico tpServico)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[StringBD.nomeString].ToString());
                conn.Open();
                string query = "insert into tipoServico (tipoCodigo, tipoDescricao) values (@Codigo, @Descricao);";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Codigo", tpServico.Codigo.ToString());
                cmd.Parameters.AddWithValue("@Descricao", tpServico.Descricao.ToString());
                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void alterarTipoServico(TipoServico tpServico)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[StringBD.nomeString].ToString());
                conn.Open();
                string query = "update tipoServico  set tipoDescricao = @Descricao where tipoCodigo = @Codigo;";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Codigo", tpServico.Codigo.ToString());
                cmd.Parameters.AddWithValue("@Descricao", tpServico.Descricao.ToString());
                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void excluirTipoServico(int codigo)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[StringBD.nomeString].ToString());
                conn.Open();
                string query = "delete from tipoServico  where tipoCodigo = @Codigo;";

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
