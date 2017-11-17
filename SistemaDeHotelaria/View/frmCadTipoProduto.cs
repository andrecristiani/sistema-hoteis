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
    public partial class frmCadTipoProduto : Form
    {
        TipoProduto tipoProduto = new TipoProduto();
        frmCadProduto frm;
        List<TipoProduto> lista;
        public frmCadTipoProduto(frmCadProduto frm)
        {
            InitializeComponent();
            this.frm = frm;
            lista = TipoProduto.carregarListaTipoProduto();
            if (lista.Count.Equals(0))
            {
                txtCodigo.Text = "1";
            }
            else
            {
                txtCodigo.Text = (lista.Last<TipoProduto>().Codigo + 1).ToString();
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text != "" && txtDescricao.Text != "")
            {
                pegarDados();
                TipoProduto.inserirTipoProduto(tipoProduto);
                frm.carregarComboBox();
                this.Close();
            }
            else
            {
                MessageBox.Show("Favor preencher todos os campos!");
            }
        }

        private void pegarDados()
        {
            tipoProduto.Codigo = int.Parse(txtCodigo.Text);
            tipoProduto.Descricao = txtDescricao.Text;
        }
    }
}
