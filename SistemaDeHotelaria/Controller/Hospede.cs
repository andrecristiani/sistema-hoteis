using SistemaDeHotelaria.Utilitarios;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeHotelaria
{
    class Hospede
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string CEP { get; set; }
        public string Complemento { get; set; }
        public int Cidade { get; set; }
        

        public static List<Hospede> carregarListaHospede()
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings[StringBD.nomeString].ToString());
                con.Open();
                string query = "select  *from hospede";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dtr = cmd.ExecuteReader();
                List<Hospede> listaHospede = new List<Hospede>();

                while (dtr.Read())
                {
                    Hospede h = new Hospede();
                    h.Codigo = int.Parse(dtr["hospCodigo"].ToString());
                    h.Nome = dtr["hospNome"].ToString();
                    h.CPF = dtr["hospCpf"].ToString();
                    h.Telefone = dtr["hospTelefone"].ToString();
                    h.Celular = dtr["hospCelular"].ToString();
                    h.Logradouro = dtr["hospLogradouro"].ToString();
                    h.Numero = dtr["hospNumero"].ToString();
                    h.Bairro = dtr["hospBairro"].ToString();
                    h.CEP = dtr["hospCep"].ToString();
                    h.Complemento = dtr["hospComplemento"].ToString();
                    h.Cidade = int.Parse(dtr["cidadeCodigo"].ToString());
                    listaHospede.Add(h);
                }
                con.Close();
                return listaHospede;

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public static void inserirHospede(Hospede h)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[StringBD.nomeString].ToString());    
                conn.Open();

                string query = "insert into hospede (hospNome, hospCpf, hospTelefone, hospCelular, hospLogradouro, hospNumero, hospBairro, " +
                    "hospCep, hospComplemento, cidadeCodigo) values ( @nome, @cpf, @telefone, @celular, @logradouro, @numero, @bairro, @cep," +
                    " @complemento, @codCidade); select @@IDENTITY;";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nome", h.Nome);
                cmd.Parameters.AddWithValue("@cpf", h.CPF);
                cmd.Parameters.AddWithValue("@telefone", h.Telefone);
                cmd.Parameters.AddWithValue("@celular", h.Celular);
                cmd.Parameters.AddWithValue("@logradouro", h.Logradouro);
                cmd.Parameters.AddWithValue("@numero", h.Numero.ToString());
                cmd.Parameters.AddWithValue("@bairro", h.Bairro);
                cmd.Parameters.AddWithValue("@cep", h.CEP);
                cmd.Parameters.AddWithValue("@complemento", h.Complemento);
                cmd.Parameters.AddWithValue("@codCidade", h.Cidade);
                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void alterarHospede(Hospede h)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[StringBD.nomeString].ToString()); 
                conn.Open();

                String query = "update hospede set hospNome = @nome, hospCpf = @cpf, hospTelefone = @telefone, hospCelular = @celular, " +
                    "hospLogradouro = @logradouro, hospNumero = @numero, hospBairro = @bairro, hospCep = @cep, hospComplemento = @complemento, " +
                    "cidadeCodigo = @codCidade where hospCodigo = @cod";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nome", h.Nome);
                cmd.Parameters.AddWithValue("@cpf", h.CPF);
                cmd.Parameters.AddWithValue("@telefone", h.Telefone);
                cmd.Parameters.AddWithValue("@celular", h.Celular);
                cmd.Parameters.AddWithValue("@logradouro", h.Logradouro);
                cmd.Parameters.AddWithValue("@numero", h.Numero.ToString());
                cmd.Parameters.AddWithValue("@bairro", h.Bairro);
                cmd.Parameters.AddWithValue("@cep", h.CEP);
                cmd.Parameters.AddWithValue("@complemento", h.Complemento);
                cmd.Parameters.AddWithValue("@codCidade", h.Cidade);
                cmd.Parameters.AddWithValue("@cod", h.Codigo.ToString());
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void excluirHospede(int codigo)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[StringBD.nomeString].ToString());
                conn.Open();

                String query = "delete from hospede where hospCodigo = @cod";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@cod", codigo);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }
    }
}
