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
    public partial class frmVinServico : Form
    {
        SituacaoQuarto sit;
        ServicoPrestado servicoP = new ServicoPrestado();
        servicosPrestados serv = new servicosPrestados();
        List<servico> listaServicos;
        List<servicosPrestados> listaServicosPrestados;
        public frmVinServico(SituacaoQuarto sit)
        {
            InitializeComponent();
            this.sit = sit;
            cmbQuarto.Text = sit.Quarto.ToString();
            cmbHospede.Text = sit.NomeHospede;
            carregarProdutos();
            foreach (servico serv in listaServicos)
            {
                cmbServico.Items.Add(serv.servescricao);
            }
            cmbQuarto.Enabled = false;
            cmbHospede.Enabled = false;
            atualizarGrid();
            habilitarCampos();
            cmbServico.Focus();
        }

        public void carregarProdutos()
        {
            using (Entities ef = new Entities())
            {
                listaServicos = ef.servico.ToList();
            }
        }

        private void cmbProduto_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtQuantidade.Text = "1";
            txtValorUnitario.Text = listaServicos[cmbServico.SelectedIndex].servValor.ToString();
            lblTotal.Text = "R$ " + (listaServicos[cmbServico.SelectedIndex].servValor * 1).ToString();
        }

        public void pegarDados()
        {
            if (listaServicosPrestados.Count == 0) {
                servicoP.servPrestadoCodigo = 1;
            }
            else
            {
                servicoP.servPrestadoCodigo = listaServicosPrestados.Last<servicosPrestados>().servPrestadoCodigo + 1;
            }
            servicoP.hospCodigo = sit.Hospedagem;
            servicoP.servCodigo = listaServicos[cmbServico.SelectedIndex].servCodigo;
            servicoP.quantidade = int.Parse(txtQuantidade.Text);
            servicoP.valorUnitario = double.Parse(txtValorUnitario.Text);
        }

        public void atualizarGrid()
        {
            using (Entities ef = new Entities())
            {
                listaServicosPrestados = ef.servicosPrestados.ToList();
                var dados = (from sp in ef.servicosPrestados  join s in ef.servico on sp.servCodigo equals s.servCodigo where sp.hospCodigo.Equals(sit.Hospedagem) select new {Código = sp.servPrestadoCodigo ,Serviço = sp.servCodigo, Descrição = s.servescricao, Quantidade = sp.quantidade, Valor = "R$ " + sp.valorUnitario, Total = "R$ " + sp.valorUnitario * sp.quantidade }).ToList();
                dgvConsumos.DataSource = dados;
            }
        }

       private void habilitarCampos()
        {
            cmbServico.Enabled = true;
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
            cmbServico.Enabled = false;
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
            cmbServico.Text = serv.servCodigo.ToString();
            txtQuantidade.Text = serv.quantidade.ToString();
            txtValorUnitario.Text = serv.valorUnitario.ToString();
        }

        private void limparCampos()
        {
            cmbServico.Text = "";
            txtQuantidade.Text = "";
            txtValorUnitario.Text = "";
            lblTotal.Text = "R$ 00.00";
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (cmbServico.Text == string.Empty)
            {
                MessageBox.Show("Nenhum produto selecionado!");
                cmbServico.Focus();
            }
            else if (txtQuantidade.Text == string.Empty)
            {
                MessageBox.Show("Nenhuma quantidade informada!");
                txtQuantidade.Focus();
            }
            else if (txtValorUnitario.Text == string.Empty)
            {
                MessageBox.Show("Nenhum valor informado!");
                txtValorUnitario.Focus();
            }
            else
            {
                pegarDados();
                try
                {
                    ServicoPrestado.adicionarServPrestado(servicoP);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao tentar inserir o servico! Erro: " + ex.Message);
                }
                desabilitarCampos();
                atualizarGrid();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente excluir o serviço: " + cmbServico.Text + "?", "Aviso!",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    ServicoPrestado.excluirServicoPrestado(serv.servPrestadoCodigo);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao excluir: " + ex.Message);
                }
                atualizarGrid();
            }
        }

        private void dgvConsumos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int _id = int.Parse(dgvConsumos.CurrentRow.Cells["Código"].Value.ToString());
            serv = listaServicosPrestados.Find(s => s.servPrestadoCodigo.Equals(_id));
            setarDados();
            cmbServico.Text = dgvConsumos.CurrentRow.Cells["Descrição"].Value.ToString();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            limparCampos();
            habilitarCampos();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            desabilitarCampos();
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
    }
}
