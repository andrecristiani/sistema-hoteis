using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaDeHotelaria
{
    class DALhospedes
    {
        public Conexao objCon;
       
       


        public DALhospedes(Conexao conexao)
        {
            objCon = conexao;
        }

        public DataTable CarregarLista()
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select *from hospede", objCon.StringConexao);
            da.Fill(tabela);
            return tabela;
        }

     

        public DataTable BuscaCodigo(String valor)
        {

            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select *from hospede where hospCodigo = " + valor, objCon.StringConexao);
            da.Fill(tabela);
            return tabela;
        }

        public DataTable BuscaNome(String valor)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select *from hospede where hospNome like '%" + valor + "%'", objCon.StringConexao);
            da.Fill(tabela);
            return tabela;
        }

        public DataTable BuscaCpf(String valor)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select *from hospede where hospCpf like '%" + valor + "%'", objCon.StringConexao);
            da.Fill(tabela);
            return tabela;
        }


        public  void Inserir(Hospede h)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = objCon.ObjetoConexao;
                cmd.CommandText = "insert into hospede (hospNome, hospCpf, hospTelefone, hospCelular, hospLogradouro, hospNumero, hospBairro, " +
                    "hospCep, hospComplemento, cidadeCodigo) values ( @nome, @cpf, @telefone, @celular, @logradouro, @numero, @bairro, @cep," +
                    " @complemento, @codCidade); select @@IDENTITY;";
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

                objCon.Conectar();
                h.Codigo = Convert.ToInt32(cmd.ExecuteScalar());
                objCon.Desconectar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            

        }
     

        public void Alterar(Hospede h)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = objCon.ObjetoConexao;
                cmd.CommandText = "update hospede set hospNome = @nome, hospCpf = @cpf, hospTelefone = @telefone, hospCelular = @celular, " +
                    "hospLogradouro = @logradouro, hospNumero = @numero, hospBairro = @bairro, hospCep = @cep, hospComplemento = @complemento, " +
                    "cidadeCodigo = @codCidade where hospCodigo = @cod";
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
                objCon.Conectar();
                cmd.ExecuteNonQuery();
                objCon.Desconectar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        public void Excluir(int codigo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = objCon.ObjetoConexao;
                cmd.CommandText = "delete from hospede where hospCodigo = @cod";
                cmd.Parameters.AddWithValue("@cod", codigo);
                objCon.Conectar();
                cmd.ExecuteNonQuery();
                objCon.Desconectar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }

        public Hospede carregaHospede(int codigo)
        {
            Hospede modelo = new Hospede();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = objCon.ObjetoConexao;
            cmd.CommandText = "select *from hospede where hospCodigo = " + codigo.ToString();
            objCon.Conectar();
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.HasRows)
            {
                registro.Read();
               // modelo.Codigo = Convert.ToInt32(registro["hospCodigo"]);
                modelo.Nome = Convert.ToString(registro["hospNome"]);
                modelo.CPF = Convert.ToString(registro["hospCpf"]);
                modelo.Telefone = Convert.ToString(registro["hospTelefone"]);
                modelo.Celular = Convert.ToString(registro["hospCelular"]);
                modelo.Logradouro = Convert.ToString(registro["hospLogradouro"]);
                modelo.Numero = Convert.ToString(registro["hospNumero"]);
                modelo.Bairro = Convert.ToString(registro["hospBairro"]);
                modelo.CEP = Convert.ToString(registro["hospCep"]);
                modelo.Complemento = Convert.ToString(registro["hospComplemento"]);
                modelo.Cidade = Convert.ToInt32(registro["cidadeCodigo"]);

            }
            return modelo;
        }
    }
}

