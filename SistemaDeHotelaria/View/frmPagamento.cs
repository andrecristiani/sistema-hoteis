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
    public partial class frmPagamento : Form
    {
        List<Object> listaObjetos;
        SituacaoQuarto sit;
        double valorTotal = 0;
        double valorDesconto = 0;
        double valorAcrescimo = 0;
        public frmPagamento(SituacaoQuarto sit)
        {
            InitializeComponent();
            this.sit = sit;
            carregarGrid();
            lblHospede.Text = sit.NomeHospede;
            lblQuarto.Text = sit.Quarto.ToString();
            lblPeriodo.Text = sit.CheckIn.Day + "/" + sit.CheckIn.Month + "/" + sit.CheckIn.Year + " a " + sit.CheckOut.Day + "/" + sit.CheckOut.Month + "/" + sit.CheckOut.Year;
        }


        private void carregarGrid()
        {
            using (Entities ef = new Entities())
            {
                listaObjetos = new List<Object>();
                var dados =  (from s in ef.servico join sp in ef.servicosPrestados on s.servCodigo equals sp.servCodigo where sp.hospCodigo.Equals(sit.Hospedagem) select new { Descrição = s.servescricao, Quantidade = sp.quantidade, Valor = "R$ " + sp.valorUnitario, Total = sp.quantidade * sp.valorUnitario }).ToList();
                var dados2 = (from p in ef.produto join c in ef.consumo on p.prodCodigo equals c.prodCodigo where c.hospCodigo.Equals(sit.Hospedagem) select new { Descrição = p.prodDescricao, Quantidade = c.quantidade, Valor = "R$ " + c.valorUnitario, Total = c.quantidade * c.valorUnitario }).ToList();

                foreach (var item in dados){ valorTotal += item.Total; listaObjetos.Add(item); }

                foreach (var item in dados2){ valorTotal += item.Total; listaObjetos.Add(item); }

                dgvSolicitacoes.DataSource = listaObjetos;

                label3.Text = "R$ " + valorTotal;
            }
        }

        private void frmPagamento_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (txtDesconto.Text.Length > 0)
            {
                valorDesconto = (valorTotal * double.Parse(txtDesconto.Text) / 100);
                lblDesconto.Text = "R$ " + valorDesconto.ToString();
            }
            else
                lblDesconto.Text = "R$ 00,00";
        }

        private void txtAcrescimo_TextChanged(object sender, EventArgs e)
        {
            if (txtAcrescimo.Text.Length > 0)
            {
                valorAcrescimo = (valorTotal * double.Parse(txtAcrescimo.Text) / 100);
                lblAcrescimo.Text = "R$ " + valorAcrescimo.ToString();
            }
            else
                lblAcrescimo.Text = "R$ 00,00";
        }
             
    }
}
