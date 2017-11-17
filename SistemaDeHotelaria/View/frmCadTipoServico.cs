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
    public partial class frmCadTipoServico : Form
    {
        TipoServico tipo = new TipoServico();
        frmCadServico frm;
        List<TipoServico> lista;
        public frmCadTipoServico(frmCadServico frm)
        {
            InitializeComponent();
            this.frm = frm;
            lista = TipoServico.carregarListaTiposServico();
            if (lista.Count.Equals(0))
            {
                txtCodigo.Text = "1";
            }
            else
            {
                txtCodigo.Text = (lista.Last<TipoServico>().Codigo + 1).ToString();
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text != "" && txtDescricao.Text != "")
            {
                pegarDados();
                TipoServico.inserirTipoServico(tipo);
                frm.carregarCombobox();
                this.Close();
            }
            else
            {
                MessageBox.Show("Favor preencher todos os campos!");
            }
        }

        private void pegarDados()
        {
            tipo.Codigo = int.Parse(txtCodigo.Text);
            tipo.Descricao = txtDescricao.Text;
        }
    }
}
