using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaDeHotelaria
{
    public partial class frmFuncionario : Form
    {

        Funcionario funcionario = new Funcionario();

        List<Funcionario> listaFuncionarios = new List<Funcionario>();
        Boolean alterar = false;


        public frmFuncionario()
        {
            InitializeComponent();
            atualizarLista();
            habilitarCampos();
            List<Funcionario> listaFuncionario = Funcionario.carregarListaFuncionarios();
            foreach (var atributo in listaFuncionario)
            {
                cbStatusFunc.Items.Add(atributo.Status);
            }
            
           
            setarDados();
            desabilitarCampos();
            

            CarregarGridFuncionario();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txtNomeFunc.Text.Equals(string.Empty))
            {
                MessageBox.Show("O campo NOME deve ser preenchido!");
                txtNomeFunc.Focus();
            }
            else if (maskCPFFunc.Text.Equals(string.Empty))
            {
                MessageBox.Show("O campo CPF deve ser preenchido!");
                maskCPFFunc.Focus();
            }
            else if (txtLogradouroFunc.Text.Equals(string.Empty))
            {
                MessageBox.Show("O campo LOGRADOURO deve ser preenchido!");
                txtLogradouroFunc.Focus();
            }
            else if (txtNumeroFunc.Text.Equals(string.Empty))
            {
                MessageBox.Show("O campo NÚMERO deve ser preenchido!");
                txtNumeroFunc.Focus();
            }
            else if (txtBairroFunc.Text.Equals(string.Empty)) {
                MessageBox.Show("O campo BAIRRO deve ser preenchido!");
                txtBairroFunc.Focus();
            }
            else if (txtComplementoFunc.Text.Equals(string.Empty))
            {
                MessageBox.Show("O campo COMPLEMENTO deve ser preenchido!");
                txtComplementoFunc.Focus();
            }
            else if (cbCidadeFunc.Text.Equals(string.Empty))
            {
                MessageBox.Show("Uma CIDADE deve ser selecionada!");
                cbCidadeFunc.Focus();
            }
            else if (maskCEPFunc.Text.Equals(string.Empty))
            {
                MessageBox.Show("O campo CEP deve ser preenchido!");
                maskCEPFunc.Focus();
            }
            else if (maskTelefoneFunc.Text.Equals(string.Empty))
            {
                MessageBox.Show("O campo TELEFONE deve ser preenchido!");
                maskTelefoneFunc.Focus();
            }
            else if (maskCelularFunc.Text.Equals(string.Empty))
            {
                MessageBox.Show("O campo CELULAR deve ser preenchido!");
                maskCelularFunc.Focus();
            }
            else if (cbStatusFunc.Text.Equals(string.Empty))
            {
                MessageBox.Show("Um STATUS deve ser selecionado!");
                cbStatusFunc.Focus();
            }
            else if (txtSalarioFunc.Text.Equals(string.Empty))
            {
                MessageBox.Show("O campo SALÁRIO deve ser preenchido!");
                txtSalarioFunc.Focus();
            }
            else if (txtLoginFunc.Text.Equals(string.Empty))
            {
                MessageBox.Show("O campo LOGIN deve ser preenchido!");
                    txtLoginFunc.Focus();
            }
            else if (txtSenhaFunc.Text.Equals(string.Empty))
            {
                MessageBox.Show("O campo SENHA deve ser preenchido!");
                txtSenhaFunc.Focus();
            }
            else
            {
                desabilitarCampos();
                pegarDados();
                if (alterar.Equals(false))
                {
                    try
                    {
                        Funcionario.cadastrarFuncionario(funcionario);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro: " + ex);
                    }
                }
                if (alterar.Equals(true))
                {
                    try
                    {
                        alterar = false;
                        Funcionario.alterarFuncionario(funcionario);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro: " + ex);
                    }
                }
                atualizarLista();
            }
        }



        private void pegarDados()
        {
            funcionario.Codigo = int.Parse(txtCodigoFunc.Text);
            funcionario.Nome = txtNomeFunc.Text;
            funcionario.CPF = maskCPFFunc.Text;
            funcionario.Logradouro = txtLogradouroFunc.Text;
            funcionario.Numero = int.Parse(txtNumeroFunc.Text);
            funcionario.Bairro = txtBairroFunc.Text;
            funcionario.Complemento = txtComplementoFunc.Text;
            funcionario.CidadeCodigo = int.Parse(cbCidadeFunc.Text);
           // funcionario.CidadeCodigo = 1;
             funcionario.CEP = maskCEPFunc.Text;
            funcionario.Telefone = maskTelefoneFunc.Text;
            funcionario.Celular = maskCelularFunc.Text;
            funcionario.Status = (cbStatusFunc.Text);
            funcionario.Salario = decimal.Parse(txtSalarioFunc.Text);
            funcionario.Login = txtLoginFunc.Text;
            funcionario.Senha = txtSenhaFunc.Text;
        }

        private void setarDados()
        {
            //txtCodigoFunc.Text = funcionario.Codigo.ToString();
            //txtDescricao.Text = funcionario.Descricao;
            //txtValor.Text = produto.Valor.ToString();
            //cmbTipo.SelectedIndex = produto.Tipo - 1;
            //cmbUnidade.SelectedIndex = produto.Unidade - 1;
        }

        private void atualizarLista()
        {
            try
            {
                Funcionario.carregarListaFuncionarios();
                dgFuncionario.DataSource = new BindingList<Funcionario>(Funcionario.listaFuncionarios);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar lista: " + ex.Message);
            }
        }

        private void desabilitarCampos()
        {
            btnNovoFunc.Enabled = true;
            btnAlterarFunc.Enabled = true;
            btnSalvarFunc.Enabled = false;
            btnCancelarFunc.Enabled = false;
            btnExcluirFunc.Enabled = true;
            txtNomeFunc.Enabled = false;
            maskCPFFunc.Enabled = false;
            txtLogradouroFunc.Enabled = false;
            txtNumeroFunc.Enabled = false;
            txtBairroFunc.Enabled = false;
            txtComplementoFunc.Enabled = false;
            cbCidadeFunc.Enabled = false;
            cbEstadoFunc.Enabled = false;
            maskCEPFunc.Enabled = false;
            maskTelefoneFunc.Enabled = false;
            maskCelularFunc.Enabled = false;
            cbStatusFunc.Enabled = false;
            txtSalarioFunc.Enabled = false;
            txtLoginFunc.Enabled = false;
            txtSenhaFunc.Enabled = false;
        }

        private void habilitarCampos()
        {
            btnNovoFunc.Enabled = false;
            btnAlterarFunc.Enabled = false;
            btnSalvarFunc.Enabled = true;
            btnCancelarFunc.Enabled = true;
            btnExcluirFunc.Enabled = false;
            txtNomeFunc.Enabled = true;
            maskCPFFunc.Enabled = true;
            txtLogradouroFunc.Enabled = true;
            txtNumeroFunc.Enabled = true;
            txtBairroFunc.Enabled = true;
            txtComplementoFunc.Enabled = true;
            cbCidadeFunc.Enabled = true;
            maskCEPFunc.Enabled = true;
            maskTelefoneFunc.Enabled = true;
            maskCelularFunc.Enabled = true;
            cbStatusFunc.Enabled = true;
            txtSalarioFunc.Enabled = true;
            txtLoginFunc.Enabled = true;
            txtSenhaFunc.Enabled = true;
        }

        private void limparCampos()
        {
            txtCodigoFunc.Clear();
            txtNomeFunc.Clear();
            maskCPFFunc.Clear();
            txtLogradouroFunc.Clear();
            txtNumeroFunc.Clear();
            txtBairroFunc.Clear();
            txtComplementoFunc.Clear();
            cbCidadeFunc.Text = "";
            maskCEPFunc.Clear();
            maskTelefoneFunc.Clear();
            maskCelularFunc.Clear();
            cbStatusFunc.Text = "";
            txtSalarioFunc.Clear();
            txtLoginFunc.Clear();
            txtSenhaFunc.Clear();
        }
        

        private void btnNovo_Click(object sender, EventArgs e)
        {
            habilitarCampos();
            limparCampos();
            if (Funcionario.listaFuncionarios.Count.Equals(0))
            {
                txtCodigoFunc.Text = "1";
            }
            else
            {
                funcionario = Funcionario.listaFuncionarios.Last<Funcionario>();
                txtCodigoFunc.Text = (funcionario.Codigo + 1).ToString();
            }
        }

        public void CarregarGridFuncionario()
        {
            try
            {
                using (Entities ef = new Entities())
                {
                    List<funcionario> funcionario_list = ef.funcionario.ToList();
                    dgFuncionario.DataSource = new BindingList<funcionario>(funcionario_list);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente excluir o funcionário: " + txtNomeFunc.Text + "?", "Aviso!",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    Funcionario.excluirFuncionario(int.Parse(txtCodigoFunc.Text));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao excluir: " + ex.Message);
                }

            }
        }

        private void btnCancelarFunc_Click(object sender, EventArgs e)
        {
            desabilitarCampos();
            limparCampos();
            setarDados();
        }

        private void frmFuncionario_Load(object sender, EventArgs e)
        {

        }

        private void btnAlterarFunc_Click(object sender, EventArgs e)
        {

        }

    
    }
}
