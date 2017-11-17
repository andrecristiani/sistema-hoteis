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
    public partial class frmCadServico : Form
    {
        Servico servico = new Servico();
        List<TipoServico> listaTiposServico;
        int alterar = 0;
        public frmCadServico()
        {
            InitializeComponent();
            desabilitarCampos();
            atualizarLista();
            carregarCombobox();
            cmbTipoPesquisa.SelectedIndex = 1;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txtDescricao.Text.Equals(""))
            {
                MessageBox.Show("Favor preencher a descrição!");
                txtDescricao.Focus();
            }else if (txtValor.Text.Equals(""))
            {
                MessageBox.Show("Favor preencher o valor!");
                txtValor.Focus();
            }else if (cmbTipo.Text.Equals(""))
            {
                MessageBox.Show("Favor preencher o tipo!");
                cmbTipo.Focus();
            }
            else
            {
                pegarDados();
                if (alterar == 0)
                {
                    try
                    {
                        Servico.inserirServico(servico);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao salvar servico! Erro: " + ex);
                    }
                }
                else
                {
                    try
                    {
                        Servico.alterarServico(servico);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao alterar servico! Erro: " + ex);
                    }
                }
                desabilitarCampos();
                setarDados();
            }
        }


        private void pegarDados()
        {
            servico.Codigo = int.Parse(txtCodigo.Text);
            servico.Descricao = txtDescricao.Text;
            servico.Valor = float.Parse(txtValor.Text);
            servico.Tipo = 1;//(cmbTipo.SelectedIndex + 1);
        }

        private void setarDados()
        {
            txtCodigo.Text = servico.Codigo.ToString();
            txtDescricao.Text = servico.Descricao;
            txtValor.Text = servico.Valor.ToString();
            cmbTipo.SelectedIndex = servico.Tipo - 1;
        }

        private void atualizarLista()
        {
            Servico.carregarListaServicos();
            dgvProduto.DataSource = new BindingList<Servico>(Servico.listaServicos);
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
            txtCodigo.Enabled = false;
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
            btnNovoTipo.Enabled = true;
        }

        private void limparCampos()
        {
            txtCodigo.Clear();
            txtDescricao.Clear();
            txtValor.Clear();
            cmbTipo.Text = "";
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            limparCampos();
            if (Servico.listaServicos.Count.Equals(0))
            {
                txtCodigo.Text = "1";
            }
            else
            {
                servico = Servico.listaServicos.Last<Servico>();
                txtCodigo.Text = (servico.Codigo + 1).ToString();
            }

            habilitarCampos();
            txtDescricao.Focus();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Deseja realmente excluir o serviço: " + txtDescricao.Text + "?", "Aviso!",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Servico.excluirServico(int.Parse(txtCodigo.Text));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Impossível excluir, serviço possui vinculo com alguma atividade!");
            }
        }

        private void dgvProduto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int _id = int.Parse(dgvProduto.CurrentRow.Cells["Codigo"].Value.ToString());
            Console.WriteLine(_id);
            servico = Servico.listaServicos.Find(s => s.Codigo == _id);
            setarDados();
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            if (cmbTipoPesquisa.SelectedIndex.Equals(1))
            {
                dgvProduto.DataSource = new BindingList<Servico>(Servico.listaServicos.FindAll(s => s.Descricao.Contains(txtDescricao.Text)));
            }
            else
            {
                dgvProduto.DataSource = new BindingList<Servico>(Servico.listaServicos.FindAll(s => s.Codigo == int.Parse(txtDescricao.Text)));
            }
        }

        private void btnNovoTipo_Click(object sender, EventArgs e)
        {
            frmCadTipoServico frm = new frmCadTipoServico(this);
            frm.Show();
        }

        public void carregarCombobox()
        {
            listaTiposServico = TipoServico.carregarListaTiposServico();
            foreach (var tp in listaTiposServico)
            {
                cmbTipo.Items.Add(tp.Descricao);
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            alterar = 1;
            habilitarCampos();
            txtDescricao.Focus();
        }
    }
}
