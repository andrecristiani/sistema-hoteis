using SistemaDeHotelaria.Controller;
using SistemaDeHotelaria.Utilitarios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaDeHotelaria.View
{
    public partial class frmHospedes : Form
    {
        public frmHospedes()
        {
            InitializeComponent();
            List<Cidade> listaCidade = Cidade.carregarListaCidade();
            foreach (var l in listaCidade)
            {
                cbCidade.Items.Add(l.Cidades);
            }
        }
        int opcao = 0, cod = 0, id = 0;
        //String strConexao = "Data Source=DESKTOP-K0O0JOH;Initial Catalog=bdHotel;Integrated Security=True";
        String strConexao = @"Data Source=DESKTOP-9GUVKU6\SQLEXPRESS;Initial Catalog=bdHotel;Integrated Security=True";
        

        public void chamarGradeView(){
            try
            {
                Conexao con = new Conexao(StringBD.stringConexao);
                DALhospedes dal = new DALhospedes(con);
                dgvHospede.DataSource = dal.CarregarLista();
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
        }

    

        public void Inserir()
        {
            try
            {
                Hospede h = new Hospede();
                h.Nome = txtNome.Text;
                h.CPF = maskCPF.Text;
                h.Logradouro = txtLogradouro.Text;
                h.Numero = txtNumero.Text;
                h.Bairro = txtBairro.Text;
                h.Complemento = txtComplemento.Text;
                h.Cidade = cbCidade.SelectedIndex + 1;
                h.CEP = maskCEP.Text;
                h.Telefone = maskTelefone.Text;
                h.Celular = maskCelular.Text;
                Conexao con = new Conexao(StringBD.stringConexao);
                DALhospedes dal = new DALhospedes(con);
                dal.Inserir(h);
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
        }

        public void Alterar()
        {
            try
            {
                id = Convert.ToInt32(dgvHospede.CurrentRow.Cells["hospCodigo"].Value.ToString());
                if (MessageBox.Show("Tem certeza que deseja efetuar está alteração?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes);
                Hospede h = new Hospede();
                h.Codigo = id;
                h.Nome = txtNome.Text;
                h.CPF = maskCPF.Text;
                h.Logradouro = txtLogradouro.Text;
                h.Numero = txtNumero.Text;
                h.Bairro = txtBairro.Text;
                h.Complemento = txtComplemento.Text;
                h.Cidade = cbCidade.SelectedIndex + 1;
                h.CEP = maskCEP.Text;
                h.Telefone = maskTelefone.Text;
                h.Celular = maskCelular.Text;
                Conexao con = new Conexao(StringBD.stringConexao);
                DALhospedes dal = new DALhospedes(con);
                dal.Alterar(h);
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
        }

        private void frmHospedes_Load(object sender, EventArgs e)
        {
            desabilitar();
            txtCodigo.Enabled = false;
            txtBuscaCodigo.Enabled = false;
            txtBuscaNome.Enabled = false;
            maskBuscaCpf.Enabled = false;
            rbTodos.Checked = true;
            chamarGradeView();
            txtCodigo.Text = "";

        }
        

        public void limparCampos()
        {
            txtCodigo.Clear();
            txtNome.Clear();
            maskCPF.Clear();
            txtLogradouro.Clear();
            txtNumero.Clear();
            txtBairro.Clear();
            txtComplemento.Clear();
            cbCidade.Text = " ";
            maskCEP.Clear();
            maskTelefone.Clear();
            maskCelular.Clear();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            opcao = 1;
            limparCampos();
            habilitar();
            btn_alterar.Enabled = false;
            btnExcluir.Enabled = false;
            txtNome.Focus();
        }

        private void btn_alterar_Click(object sender, EventArgs e)
        {
            btnNovo.Enabled = false;
            btnExcluir.Enabled = false;
            opcao = 2;
            id = Convert.ToInt32(dgvHospede.CurrentRow.Cells["hospCodigo"].Value.ToString());
            habilitar();
        }

        private void habilitar()
        {
            txtNome.Enabled = true;
            maskCPF.Enabled = true;
            txtLogradouro.Enabled = true;
            txtNumero.Enabled = true;
            txtBairro.Enabled = true;
            txtComplemento.Enabled = true;
            cbCidade.Enabled = true;
            maskCEP.Enabled = true;
            maskTelefone.Enabled = true;
            maskCelular.Enabled = true;
        }

        private void desabilitar()
        {
            txtNome.Enabled = false;
            maskCPF.Enabled = false;
            txtLogradouro.Enabled = false;
            txtNumero.Enabled = false;
            txtBairro.Enabled = false;
            txtComplemento.Enabled = false;
            cbCidade.Enabled = false;
            maskCEP.Enabled = false;
            maskTelefone.Enabled = false;
            maskCelular.Enabled = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            opcao = 0;
            limparCampos();
            desabilitar();
            btn_alterar.Enabled = true;
            btnExcluir.Enabled = true;
            btnNovo.Enabled = true;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (opcao == 1)
            {
               
                    Inserir();
                    chamarGradeView();
                    limparCampos();
                    desabilitar();
                    btn_alterar.Enabled = true;
                    btnExcluir.Enabled = true;
           
                    
            }
            if (opcao == 2)
            {
                     //camposNulos();
                     Alterar();
                     chamarGradeView();
                     limparCampos();
                     desabilitar();
                     btnNovo.Enabled = true;
                     btnExcluir.Enabled = true;
            }
            opcao = 0;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                id = Convert.ToInt32(dgvHospede.CurrentRow.Cells["hospCodigo"].Value.ToString());
                if (MessageBox.Show("Tem certeza que deseja excluir este hóspede?", "Confirmação de Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Conexao con = new Conexao(strConexao);
                    DALhospedes dal = new DALhospedes(con);
                    dal.Excluir(id);
                    limparCampos();
                    dgvHospede.DataSource = dal.CarregarLista();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
           
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (rbTodos.Checked)
            {
                txtBuscaCodigo.Clear();
                txtBuscaNome.Clear();
                maskBuscaCpf.Clear();
                chamarGradeView();
            }
            else if (rbCodigo.Checked)
            {
                Conexao con = new Conexao(StringBD.stringConexao);
                DALhospedes dal = new DALhospedes(con);
                dgvHospede.DataSource = dal.BuscaCodigo(txtBuscaCodigo.Text);

            }

            else if (rbNome.Checked)
            {
                Conexao con = new Conexao(StringBD.stringConexao);
                DALhospedes dal = new DALhospedes(con);
                dgvHospede.DataSource = dal.BuscaNome(txtBuscaNome.Text);
            }
            else if (rbCPF.Checked)
            {
                Conexao con = new Conexao(StringBD.stringConexao);
                DALhospedes dal = new DALhospedes(con);
                dgvHospede.DataSource = dal.BuscaCpf(maskBuscaCpf.Text);
              
            }
        }

        private void rbTodos_MouseClick(object sender, MouseEventArgs e)
        {
            txtBuscaCodigo.Clear();
            txtBuscaNome.Clear();
            maskBuscaCpf.Clear();
            txtBuscaCodigo.Enabled = false;
            txtBuscaNome.Enabled = false;
            maskBuscaCpf.Enabled = false;
            chamarGradeView();
        }

       

        private void rbNome_MouseClick(object sender, MouseEventArgs e)
        {
            txtBuscaNome.Enabled = true;
            maskBuscaCpf.Enabled = false;
            txtBuscaCodigo.Enabled = false;
            txtBuscaNome.Focus();
        }

        private void rbCPF_MouseClick(object sender, MouseEventArgs e)
        {
            maskBuscaCpf.Enabled = true;
            txtBuscaCodigo.Enabled = false;
            txtBuscaNome.Enabled = false;
            maskBuscaCpf.Focus();
        }

        private void maskCPF_Validating(object sender, CancelEventArgs e)
        {
            //if (CpfCnpjUtils.IsCpf(maskCPF.Text))
            //{

            //}
            //else
            //{
            //    MessageBox.Show("CPF inválido!");
            //    maskCPF.Clear();
            //    txtNome.Focus();

            //}
        }

        private void rbCodigo_MouseClick(object sender, MouseEventArgs e)
        {
            txtBuscaCodigo.Enabled = true;
            txtBuscaNome.Enabled = false;
            maskBuscaCpf.Enabled = false;
            txtBuscaCodigo.Focus();
        }

        private void dgvHospede_MouseClick(object sender, MouseEventArgs e)
        {
            cod = Convert.ToInt32(dgvHospede.CurrentRow.Cells["hospCodigo"].Value.ToString());
            
            if (cod != 0)
            {
                try
                {
                    Conexao con = new Conexao(StringBD.stringConexao);
                    DALhospedes dal = new DALhospedes(con);
                    Hospede h = dal.carregaHospede(cod);
                    txtCodigo.Text = cod.ToString();
                    txtNome.Text = h.Nome;
                    maskCPF.Text = h.CPF;
                    txtLogradouro.Text = h.Logradouro;
                    txtNumero.Text = h.Numero;
                    txtBairro.Text = h.Bairro;
                    txtComplemento.Text = h.Complemento;
                    cbCidade.SelectedIndex = h.Cidade-1;
                    maskCEP.Text = h.CEP;
                    maskTelefone.Text = h.Telefone;
                    maskCelular.Text = h.Celular;
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }

            }
        }




    }
}
