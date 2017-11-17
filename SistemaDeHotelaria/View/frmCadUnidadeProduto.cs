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
    public partial class frmCadUnidadeProduto : Form
    {
        UnidadeProduto unidade = new UnidadeProduto();
        frmCadProduto frm;
        List<UnidadeProduto> lista;
        public frmCadUnidadeProduto(frmCadProduto frm)
        {
            InitializeComponent();
            this.frm = frm;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text != "" && txtDescricao.Text != "" && txtResumo.Text != "")
            {
                pegarDados();
                UnidadeProduto.inserirUnidadeProduto(unidade);
                frm.carregarComboBox();
                this.Close();
                lista = UnidadeProduto.listaUnidades();
                if (lista.Count.Equals(0))
                {
                    txtCodigo.Text = "1";
                }
                else
                {
                    txtCodigo.Text = (lista.Last<UnidadeProduto>().Codigo + 1).ToString();
                }
            }
            else
            {
                MessageBox.Show("Favor preencher todos os campos!");
            }
        }

        private void pegarDados()
        {
            unidade.Codigo = int.Parse(txtCodigo.Text);
            unidade.Unidade = txtDescricao.Text;
            unidade.Resumo = txtResumo.Text;
        }
    }
}
