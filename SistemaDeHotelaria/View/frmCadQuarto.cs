using SistemaDeHotelaria.Domain;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace SistemaDeHotelaria.View
{
    public partial class frmCadQuarto : Form
    {
        Quarto quarto = new Quarto();
        int alterar = 0;
        frmPrincipal frm;
        public frmCadQuarto(frmPrincipal frm)
        {
            InitializeComponent();
            this.frm = frm;
            atualizarGrid();
            desabilitarCampos();
            quarto = Quarto.listaQuartos.First<Quarto>();
            setarDados();
            cmbTipoPesquisa.SelectedIndex = 1;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmCadQuarto_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txtDescricao.Text.Equals(string.Empty))
            {
                MessageBox.Show("Campos descrição vazio! Favor preencher.");
                txtDescricao.Focus();
            }else if (txtNumero.Text.Equals(string.Empty))
            {
                MessageBox.Show("Campos número vazio! Favor preencher.");
                txtNumero.Focus();
            }else if (txtAndar.Text.Equals(string.Empty))
            {
                MessageBox.Show("Campos andar vazio! Favor preencher.");
                txtAndar.Focus();
            }else if (txtNPressoas.Text.Equals(string.Empty))
            {
                MessageBox.Show("Campos nº pessoas vazio! Favor preencher.");
                txtNPressoas.Focus();
            }else if (txtValor.Text.Equals(string.Empty))
            {
                MessageBox.Show("Campos valor vazio! Favor preencher.");
                txtValor.Focus();
            }
            else
            {
                if (alterar == 1)
                {
                    pegarDados();
                    Quarto.alterarQuarto(quarto);
                    desabilitarCampos();
                    alterar = 0;
                }
                else
                {
                    pegarDados();
                    Quarto.inserirQuarto(quarto);
                    desabilitarCampos();
                }
                atualizarGrid();
            }
        }

        private void habilitarCampos()
        {
            txtDescricao.Enabled = true;
            txtNumero.Enabled = true;
            txtAndar.Enabled = true;
            txtNPressoas.Enabled = true;
            txtRamal.Enabled = true;
            txtValor.Enabled = true;
            txtObservacao.Enabled = true;
            btnNovo.Enabled = false;
            btnAlterar.Enabled = false;
            btnSalvar.Enabled = true;
            btnCancelar.Enabled = true;
            btnExcluir.Enabled = false;
            cmbTipoPesquisa.Enabled = false;
            txtPesquisa.Enabled = false;
        }

        private void desabilitarCampos()
        {
            txtDescricao.Enabled = false;
            txtNumero.Enabled = false;
            txtAndar.Enabled = false;
            txtNPressoas.Enabled = false;
            txtRamal.Enabled = false;
            txtValor.Enabled = false;
            txtObservacao.Enabled = false;
            btnNovo.Enabled = true;
            btnAlterar.Enabled = true;
            btnSalvar.Enabled = false;
            btnCancelar.Enabled = false;
            btnExcluir.Enabled = true;
            cmbTipoPesquisa.Enabled = true;
            txtPesquisa.Enabled = true;
        }

        private void pegarDados()
        {
            quarto.Codigo = int.Parse(txtCodigo.Text);
            quarto.Descricao = txtDescricao.Text;
            quarto.Numero = int.Parse(txtNumero.Text);
            quarto.Andar = txtAndar.Text;
            quarto.QtdPessoas = int.Parse(txtNPressoas.Text);
            quarto.Ramal = txtRamal.Text;
            quarto.Observacao = txtObservacao.Text;
            quarto.Valor = float.Parse(txtValor.Text);
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            limparCampos();
            if (Quarto.listaQuartos.Count.Equals(0))
            {
                txtCodigo.Text = "1";
            }
            else
            {
                quarto = Quarto.listaQuartos.Last<Quarto>();
                txtCodigo.Text = (quarto.Codigo + 1).ToString();
            }
            habilitarCampos();
            txtDescricao.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            desabilitarCampos();
            setarDados();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente excluir o quarto: " + txtDescricao.Text + "?", "Aviso!",
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Quarto.excluirQuarto(int.Parse(txtCodigo.Text));
            }
        }

        private void dgvQuartos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int _id = int.Parse(dgvQuartos.CurrentRow.Cells["Codigo"].Value.ToString());
            Console.WriteLine(_id);
            quarto = Quarto.listaQuartos.Find(prod => prod.Codigo == _id);
            setarDados();
        }

        private void setarDados()
        {
            txtCodigo.Text = quarto.Codigo.ToString();
            txtDescricao.Text = quarto.Descricao;
            txtNumero.Text = quarto.Numero.ToString();
            txtAndar.Text = quarto.Andar;
            txtNPressoas.Text = quarto.QtdPessoas.ToString();
            txtRamal.Text = quarto.Ramal;
            txtObservacao.Text = quarto.Observacao;
            txtValor.Text = quarto.Valor.ToString();
        }

        private void atualizarGrid()
        {
            Quarto.carregarListaQuartos();
            dgvQuartos.DataSource = new BindingList<Quarto>(Quarto.listaQuartos);
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            habilitarCampos();
            alterar = 1;
            txtDescricao.Focus();
        }

        private void limparCampos()
        {
            txtCodigo.Text = "";
            txtDescricao.Text = "";
            txtNumero.Text = "";
            txtAndar.Text = "";
            txtNPressoas.Text = "";
            txtRamal.Text = "";
            txtObservacao.Text = "";
            txtValor.Text = "";
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            if (cmbTipoPesquisa.SelectedIndex.Equals(1))
            {
                dgvQuartos.DataSource = new BindingList<Quarto>(Quarto.listaQuartos.FindAll(q => q.Descricao.Contains(txtPesquisa.Text)));
            }
            else
            {
                dgvQuartos.DataSource = new BindingList<Quarto>(Quarto.listaQuartos.FindAll(q => q.Codigo.Equals(txtPesquisa.Text)));
            }
        }

        private void frmCadQuarto_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach(Panel p in frmPrincipal.panels)
            {
                p.Dispose();
            }
            this.frm.criarPanels();
        }
    }
}
