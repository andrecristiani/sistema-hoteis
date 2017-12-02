using SistemaDeHotelaria.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaDeHotelaria.View
{
    public partial class frmCadProduto : Form
    {
        Produto produto = new Produto();
        List<TipoProduto> listaTipos = new List<TipoProduto>();
        List<produto> listaProdutos = new List<produto>();
        List<UnidadeProduto> listaUnidades = new List<UnidadeProduto>();
        Boolean alterar = false;
        string acumulado;
        public frmCadProduto()
        {
            InitializeComponent();
            atualizarLista();
            habilitarCampos();
            cmbTipoPesquisa.SelectedIndex = 1;
            carregarComboBox();
            if(Produto.listaProdutos.Count > 0)
                produto = Produto.listaProdutos.First<Produto>();
            setarDados();
            desabilitarCampos();
            cmbTipoPesquisa.SelectedIndex = 1;
            Produto.carregarListaProdutos();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txtDescricao.Text.Equals(string.Empty))
            {
                MessageBox.Show("Campos descrição vazio! Favor preencher.");
                txtDescricao.Focus();
            }
            else if (txtValor.Text.Equals(string.Empty))
            {
                MessageBox.Show("Campos valor vazio! Favor preencher.");
                txtValor.Focus();
            }else if (cmbTipo.Text.Equals(string.Empty))
            {
                MessageBox.Show("Campos tipo vazio! Favor preencher.");
                cmbTipo.Focus();
            }else if (cmbUnidade.Text.Equals(string.Empty))
            {
                MessageBox.Show("Campos unidade vazio! Favor preencher.");
                cmbUnidade.Focus();
            }
            else
            {
                desabilitarCampos();
                pegarDados();
                if (alterar.Equals(false))
                {
                    try
                    {
                        Produto.inserirProduto(produto);

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
                        Produto.alterarProduto(produto);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro: " + ex);
                    }
                }
                atualizarLista();
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            habilitarCampos();
            alterar = true;
            txtDescricao.Focus();
        }

        private void pegarDados()
        {
            produto.Codigo = int.Parse(txtCodigo.Text);
            produto.Descricao = txtDescricao.Text;
            produto.Valor = Convert.ToDouble(txtValor.Text.Replace("R$", string.Empty));
            produto.Tipo = (cmbTipo.SelectedIndex+1);
            produto.Unidade = (cmbUnidade.SelectedIndex + 1);
        }

        private void setarDados()
        {
            txtCodigo.Text = produto.Codigo.ToString();
            txtDescricao.Text = produto.Descricao;
            txtValor.Text = produto.Valor.ToString();
            cmbTipo.SelectedIndex = produto.Tipo - 1;
            cmbUnidade.SelectedIndex = produto.Unidade - 1;
        }

        private void atualizarLista()
        {
            using (Entities ef = new Entities())
            {
                var dados = (from p in ef.produto
                             join t in ef.tipoProduto on p.tipoCodigo equals t.tipoCodigo
                             join u in ef.unidadeProduto on p.unidadeCodigo equals u.unidadeCodigo
                             select new { Código = p.prodCodigo, Descrição = p.prodDescricao, Valor = p.prodValor, Tipo = t.tipoDescricao, Unidade = u.unidadeDescricao, Resumo = u.unidadeResumo }).ToList();
                dgvProduto.DataSource = dados;
            }
        }

        private void desabilitarCampos()
        {
            btnNovo.Enabled = true;
            btnAlterar.Enabled = true;
            btnSalvar.Enabled = false;
            btnCancelar.Enabled = false;
            btnExcluir.Enabled = true;
            cmbTipoPesquisa.Enabled = true;
            txtPesquisa.Enabled = true;
            txtDescricao.Enabled = false;
            txtValor.Enabled = false;
            cmbTipo.Enabled = false;
            cmbUnidade.Enabled = false;
            txtCodigo.Enabled = false;
            txtResumo.Enabled = false;
            btnNovaUnidade.Enabled = false;
            btnNovoTipo.Enabled = false;
        }

        private void habilitarCampos()
        {
            btnNovo.Enabled = false;
            btnAlterar.Enabled = false;
            btnSalvar.Enabled = true;
            btnCancelar.Enabled = true;
            btnExcluir.Enabled = false;
            cmbTipoPesquisa.Enabled = false;
            txtPesquisa.Enabled = false;
            txtDescricao.Enabled = true;
            txtValor.Enabled = true;
            cmbTipo.Enabled = true;
            cmbUnidade.Enabled = true;
            btnNovaUnidade.Enabled = true;
            btnNovoTipo.Enabled = true;
        }

        private void limparCampos()
        {
            txtCodigo.Clear();
            txtDescricao.Clear();
            txtValor.Clear();
            txtResumo.Clear();
            cmbTipo.Text = "";
            cmbUnidade.Text = "";
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            habilitarCampos();
            limparCampos();
            if (Produto.listaProdutos.Count.Equals(0))
            {
                txtCodigo.Text = "1";
            }
            else
            {
                produto = Produto.listaProdutos.Last<Produto>();
                txtCodigo.Text = (produto.Codigo + 1).ToString();
            }
            txtDescricao.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            desabilitarCampos();
            limparCampos();
            setarDados();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente excluir o produto: " + txtDescricao.Text + "?", "Aviso!",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try { 
                    Produto.excluirProduto(int.Parse(txtCodigo.Text));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao excluir: "+ex.Message);
                }

            }
        }

        private void cmbUnidade_SelectedIndexChanged(object sender, EventArgs e)
        {
            UnidadeProduto unidade = listaUnidades.Find(un => un.Codigo == (cmbUnidade.SelectedIndex+1));
            txtResumo.Text = unidade.Resumo;
        }

        private void dgvProduto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int _id = int.Parse(dgvProduto.CurrentRow.Cells["Codigo"].Value.ToString());
            Console.WriteLine(_id);
            produto = Produto.listaProdutos.Find(prod => prod.Codigo == _id);
            setarDados();
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            if(cmbTipoPesquisa.SelectedIndex.Equals(1))
            {
                dgvProduto.DataSource = new BindingList<Produto>(Produto.listaProdutos.FindAll(p => p.Descricao.Contains(txtPesquisa.Text)));
            }
            else
            {
                dgvProduto.DataSource = new BindingList<Produto>(Produto.listaProdutos.FindAll(p => p.Codigo.Equals(txtPesquisa.Text)));
            }
        }

        public void carregarComboBox()
        {
            cmbUnidade.Items.Clear();
            cmbTipo.Items.Clear();
            listaTipos = TipoProduto.carregarListaTipoProduto();
            listaUnidades = UnidadeProduto.listaUnidades();
            foreach (var tipo in listaTipos)
            {
                cmbTipo.Items.Add(tipo.Descricao);
            }
            foreach (var unidade in listaUnidades)
            {
                cmbUnidade.Items.Add(unidade.Unidade);
            }
        }

        private void frmCadProduto_Load(object sender, EventArgs e)
        {

        }

        private void btnNovoTipo_Click(object sender, EventArgs e)
        {
            frmCadTipoProduto frm = new frmCadTipoProduto(this);
            frm.Show();
            carregarComboBox();
        }

        private void btnNovaUnidade_Click(object sender, EventArgs e)
        {
            frmCadUnidadeProduto frm = new frmCadUnidadeProduto(this);
            frm.Show();
            carregarComboBox();
        }

        private void txtValor_TextChanged(object sender, EventArgs e)
        {
            string valor = txtValor.Text
                         .Replace(".", string.Empty)
                         .Replace(",", string.Empty)
                         .Replace(" ", string.Empty)
                         .Replace("R$", "")
                         .Trim();
            if (valor.Length > 0)
            {
                string ultimo = valor.Substring(0, 1);
                acumulado += ultimo;

                decimal valorDec;

                if (decimal.TryParse(acumulado, out valorDec))
                {
                    txtValor.TextChanged -= txtValor_TextChanged;

                    txtValor.Text = string.Format("{0:C2}", valorDec / 100);
                    txtValor.TextChanged += txtValor_TextChanged;
                }
                else
                {
                    txtValor.Text = string.Empty;
                    acumulado = string.Empty;
                }
            }
            else
                acumulado = string.Empty;
        }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar);
        }

        private void txtValor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
                txtValor.Text = string.Empty;
        }
    }
}
