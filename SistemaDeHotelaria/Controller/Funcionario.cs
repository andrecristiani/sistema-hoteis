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
    class Funcionario
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string CEP { get; set; }
        public string Complemento { get; set; }
        public int CidadeCodigo { get; set; }
        public decimal Salario { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Status { get; set; }

        public static List<Funcionario> listaFuncionarios = new List<Funcionario>();

        public static List<Funcionario> carregarListaFuncionarios()
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[StringBD.nomeString].ToString());
                //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionDB"].ToString());    
                conn.Open();
                string query = "SELECT * FROM funcionario";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader dtr = cmd.ExecuteReader();

                listaFuncionarios.Clear();

                while (dtr.Read())
                {
                    Funcionario f = new Funcionario();
                    f.Codigo = int.Parse(dtr["funcCodigo"].ToString());
                    f.Nome = dtr["funcNome"].ToString();
                    f.CPF = dtr["funcCpf"].ToString();
                    f.Telefone = dtr["funcTelefone"].ToString();
                    f.Celular = dtr["funcCelular"].ToString();
                    f.Logradouro = dtr["funcLogradouro"].ToString();
                    f.Numero = int.Parse(dtr["funcNumero"].ToString());
                    f.Bairro = dtr["funcBairro"].ToString();
                    f.CEP = dtr["funcCep"].ToString();
                    f.Complemento = dtr["funcComplemento"].ToString();
                    f.CidadeCodigo = int.Parse(dtr["cidadeCodigo"].ToString());
                    f.Salario = decimal.Parse(dtr["funcSalario"].ToString());
                    f.Login = dtr["funcLogin"].ToString();
                    f.Senha = dtr["funcSenha"].ToString();
                    f.Status = dtr["funcStatus"].ToString();
                    listaFuncionarios.Add(f);

                }
                conn.Close();
                return listaFuncionarios;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void cadastrarFuncionario(Funcionario funcionario)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[StringBD.nomeString].ToString());
                conn.Open();

                String query = "INSERT INTO funcionario (funcCodigo, funcNome, funcCpf, funcTelefone, funcCelular, funcLogradouro, funcNumero, funcBairro, funcCep, funcComplemento, cidadeCodigo, funcSalario, funcLogin," +
                    "funcSenha, funcStatus) VALUES (@Codigo, @Nome, @Cpf, @Telefone, @Celular, @Logradouro, @Numero, @Bairro, @Cep, @Complemento, @Cidade, @Salario, @Login, @Senha, @Status)";
                

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Codigo", funcionario.Codigo.ToString());
                cmd.Parameters.AddWithValue("@Nome", funcionario.Nome.ToString());
                cmd.Parameters.AddWithValue("@Cpf", funcionario.CPF.ToString());
                cmd.Parameters.AddWithValue("@Logradouro", funcionario.Logradouro.ToString());
                cmd.Parameters.AddWithValue("@Numero", funcionario.Numero.ToString());
                cmd.Parameters.AddWithValue("@Bairro", funcionario.Bairro.ToString());
                cmd.Parameters.AddWithValue("@Complemento", funcionario.Complemento.ToString());
                cmd.Parameters.AddWithValue("@Cidade", funcionario.CidadeCodigo.ToString());
                cmd.Parameters.AddWithValue("@Cep", funcionario.CEP.ToString());
                cmd.Parameters.AddWithValue("@Telefone", funcionario.Telefone.ToString());
                cmd.Parameters.AddWithValue("@Celular", funcionario.Celular.ToString());
               
                cmd.Parameters.AddWithValue("@Salario", funcionario.Salario.ToString());
                cmd.Parameters.AddWithValue("@Login", funcionario.Login.ToString());
                cmd.Parameters.AddWithValue("@Senha", funcionario.Senha.ToString());
                cmd.Parameters.AddWithValue("@Status", funcionario.Status.ToString());
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void alterarFuncionario(Funcionario funcionario)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[StringBD.nomeString].ToString());
                conn.Open();

                String query = "UPDATE funcionario SET funcNome = @Nome, funcCpf = @Cpf, funcTelefone = @Telefone," +
                    "funcCelular = @Celular, funcLogradouro = @Logradouro, funcNumero = @Numero, funcBairro = @Bairro," +
                    "funcCep = @Cep, funcComplemento = @Complemento, cidadeCodigo = @CodigoCidade, funcSalario = @Salario, funcLogin = @Login" +
                    "funcSenha = @Senha" +
                    "WHERE funcCodigo = @CODIGO";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Nome", funcionario.Nome.ToString());
                cmd.Parameters.AddWithValue("@Cpf", funcionario.CPF.ToString());
                cmd.Parameters.AddWithValue("@Logradouro", funcionario.Logradouro.ToString());
                cmd.Parameters.AddWithValue("@Numero", funcionario.Numero.ToString());
                cmd.Parameters.AddWithValue("@Bairro", funcionario.Bairro.ToString());
                cmd.Parameters.AddWithValue("@Complemento", funcionario.Complemento.ToString());
                cmd.Parameters.AddWithValue("@Cidade", funcionario.CidadeCodigo.ToString());
                cmd.Parameters.AddWithValue("@Cep", funcionario.CEP.ToString());
                cmd.Parameters.AddWithValue("@Telefone", funcionario.Telefone.ToString());
                cmd.Parameters.AddWithValue("@Celular", funcionario.Celular.ToString());
                cmd.Parameters.AddWithValue("@Status", funcionario.Status.ToString());
                cmd.Parameters.AddWithValue("@Salario", funcionario.Salario.ToString());
                cmd.Parameters.AddWithValue("@Login", funcionario.Login.ToString());
                cmd.Parameters.AddWithValue("@Senha", funcionario.Senha.ToString());
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void excluirFuncionario(int codigo)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[StringBD.nomeString].ToString());
                conn.Open();

                String query = "DELETE from funcionario where funcCodigo = @Codigo";

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
