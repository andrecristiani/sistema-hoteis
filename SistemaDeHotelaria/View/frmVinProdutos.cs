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
    public partial class frmVinProdutos : Form
    {
        SituacaoQuarto sit;
        List<produto> listaProdutos;
        Consumo cons = new Consumo();
        consumo consumo = new consumo();
        List<consumo> listaConsumos;
        public frmVinProdutos(SituacaoQuarto sit)
        {
            InitializeComponent();
            this.sit = sit;
            cmbQuarto.Text = sit.Quarto.ToString();
            cmbHospede.Text = sit.NomeHospede;
            carregarProdutos();
            cmbQuarto.Enabled = false;
            cmbHospede.Enabled = false;
            atualizarGrid();
            habilitarCampos();
        }

        public void carregarProdutos()
        {
            using (Entities ef = new Entities())
            {
                listaProdutos = ef.produto.ToList();
            }
            foreach (produto prod in listaProdutos)
            {
                cmbProduto.Items.Add(prod.prodDescricao);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (cmbProduto.Text == string.Empty)
            {
                MessageBox.Show("Nenhum produto selecionado!");
                cmbProduto.Focus();
            }else if (txtQuantidade.Text == string.Empty)
            {
                MessageBox.Show("Nenhuma quantidade informada!");
                txtQuantidade.Focus();
            }else if (txtValorUnitario.Text == string.Empty)
            {
                MessageBox.Show("Nenhum valor informado!");
                txtValorUnitario.Focus();
            }
            else
            {
                pegarDados();
                try
                {
                    Consumo.adicionarConsumo(cons);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao tentar inserir o consumo! Erro: " + ex.Message);
                }
                desabilitarCampos();
                atualizarGrid();
            }
        }

        public void pegarDados()
        {
            if (listaConsumos.Count == 0)
            {
                cons.consumoCodigo = 1;
            }
            else
            {
                cons.consumoCodigo = listaConsumos.Last<consumo>().consumoCodigo + 1;
            }
            cons.hospCodigo = sit.Hospedagem;
            cons.prodCodigo = listaProdutos[cmbProduto.SelectedIndex].prodCodigo;
            cons.quantidade = int.Parse(txtQuantidade.Text);
            cons.valorUnitario = double.Parse(txtValorUnitario.Text);
        }

        private void cmbProduto_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtQuantidade.Text = "1";
            txtValorUnitario.Text = listaProdutos[cmbProduto.SelectedIndex].prodValor.ToString();
            lblTotal.Text = "R$ " + (listaProdutos[cmbProduto.SelectedIndex].prodValor * 1).ToString();
        }

        public void atualizarGrid()
        {
            using (Entities ef = new Entities())
            {
                listaConsumos = ef.consumo.ToList();
                var dados = (from c in ef.consumo join p in ef.produto on c.prodCodigo equals p.prodCodigo where c.hospCodigo.Equals(sit.Hospedagem) select new { Código = c.consumoCodigo ,CodProduto = p.prodCodigo, Descrição = p.prodDescricao, Quantidade = c.quantidade, Valor = "R$ " + c.valorUnitario, Total = "R$ " + c.quantidade * c.valorUnitario}).ToList();
                dgvConsumos.DataSource = dados;
            }
        }

        private void habilitarCampos()
        {
            cmbProduto.Enabled = true;
            txtQuantidade.Enabled = true;
            txtValorUnitario.Enabled = true;
            btnNovo.Enabled = false;
            //btnAlterar.Enabled = false;
            btnSalvar.Enabled = true;
            btnCancelar.Enabled = true;
            btnExcluir.Enabled = false;
            dgvConsumos.Enabled = false;
        }

        private void desabilitarCampos()
        {
            cmbProduto.Enabled = false;
            txtQuantidade.Enabled = false;
            txtValorUnitario.Enabled = false;
            btnNovo.Enabled = true;
            //btnAlterar.Enabled = true;
            btnSalvar.Enabled = false;
            btnCancelar.Enabled = false;
            btnExcluir.Enabled = true;
            dgvConsumos.Enabled = true;
        }

        private void setarDados()
        {
            cmbProduto.Text = consumo.prodCodigo.ToString();
            txtQuantidade.Text = consumo.quantidade.ToString();
            txtValorUnitario.Text = consumo.valorUnitario.ToString();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            limparCampos();
            habilitarCampos();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            setarDados();
            desabilitarCampos();
        }

        private void dgvConsumos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int _id = int.Parse(dgvConsumos.CurrentRow.Cells["Código"].Value.ToString());
            consumo = listaConsumos.Find(c => c.consumoCodigo.Equals(_id));
            setarDados();
            cmbProduto.Text = dgvConsumos.CurrentRow.Cells["Descrição"].Value.ToString();
        }

        public void valorTotal()
        {
            if (txtValorUnitario.Text != string.Empty && txtQuantidade.Text != string.Empty)
            {
                int quantidade = int.Parse(txtQuantidade.Text);
                double valor = double.Parse(txtValorUnitario.Text);
                lblTotal.Text = "R$ " + (quantidade * valor);
            }
        }

        private void txtQuantidade_TextChanged(object sender, EventArgs e)
        {
            valorTotal();
        }

        private void txtValorUnitario_TextChanged(object sender, EventArgs e)
        {
            valorTotal();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente excluir o produto: " + cmbProduto.Text + "?", "Aviso!",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    Consumo.excluirConsumo(consumo.consumoCodigo);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao excluir: " + ex.Message);
                }
                atualizarGrid();
            }
        }

        private void limparCampos()
        {
            cmbProduto.Text = "";
            txtQuantidade.Text = "";
            txtValorUnitario.Text = "";
            lblTotal.Text = "R$ 00.00";
        }
    }
}
