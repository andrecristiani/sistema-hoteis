using SistemaDeHotelaria.Controller;
using SistemaDeHotelaria.Domain;
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
    public partial class frmCadHospedagem : Form
    {
        List<Hospede> listaHospede;
        List<Quarto> listaQuarto;
        List<Reservas> listaReservas;
        SituacaoQuarto sit;
        frmPrincipal frm;
        int opcao = 0, id = 0, codRes = 0, codQua = 0, periodo;
        float diaria = 0, valorTotal = 0;

        public frmCadHospedagem(frmPrincipal frm)
        {
            InitializeComponent();
            carregarGrid();
            this.frm = frm;
            listaHospede = Hospede.carregarListaHospede();
            foreach (var atributo in listaHospede)
            {
              cbHospede.Items.Add(atributo.Nome);
            }
            Quarto.carregarListaQuartos();
            listaQuarto = Quarto.listaQuartos;
            foreach (var atributo in listaQuarto)
            {
              cbQuarto.Items.Add(atributo.Codigo);
            }
            listaReservas = Reservas.carregarListaReservas();
            Hospedagens.carregarHospedagens();
            desabilitar();
            txtCodigo.Enabled = false;
            rbTodas.Checked = true;
            mkDataBusca.Enabled = false;

        }

        public frmCadHospedagem(frmPrincipal frm, SituacaoQuarto sit)
        {
            InitializeComponent();
            carregarGrid();
            this.sit = sit;
            this.frm = frm;
            listaHospede = Hospede.carregarListaHospede();
            foreach (var atributo in listaHospede)
            {
                cbHospede.Items.Add(atributo.Nome);
            }
            Quarto.carregarListaQuartos();
            listaQuarto = Quarto.listaQuartos;
            foreach (var atributo in listaQuarto)
            {
                cbQuarto.Items.Add(atributo.Codigo);
            }
            listaReservas = Reservas.carregarListaReservas();
            Hospedagens.carregarHospedagens();
            opcao = 1;

            if(sit.Reserva > 0)
            {
                carregarReserva(sit.Reserva);
            }
            habilitar();
            cbQuarto.Enabled = false;
            txtCodigo.Enabled = false;
            cbHospede.Enabled = false;
            cbQuarto.SelectedItem = sit.Quarto;
        }

        private void carregarGrid()
        {
            using (Entities ef = new Entities())
            {
                var dados = (from ho in ef.hospedagem
                             join h in ef.hospede on ho.hospCodigo equals h.hospCodigo
                             join f in ef.funcionario on ho.funcCodigo equals f.funcCodigo
                             select new { Código = ho.hospedagemCodigo, CheckIn = ho.hospCheckin, CheckOut = ho.hospCheckout, Quarto = ho.quartoCodigo, Hóspede = h.hospNome, Reserva = ho.reservaCodigo, Funcionário = f.funcNome, Valor = ho.valorTotal }).ToList();
                dgvHospedagem.DataSource = dados;
            }
            
        }

        string checkin, checkout;
        Hospedagens hos = new Hospedagens();
        Hospede h = new Hospede();

        
        private void btnNovo_Click(object sender, EventArgs e)
        {
            opcao = 1;
            limparCampos();
            habilitar();
            btn_alterar.Enabled = false;
            btnExcluir.Enabled = false;
            dtpCheckin.Enabled = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            opcao = 0;
            limparCampos();
            desabilitar();
            btn_alterar.Enabled = true;
            btnExcluir.Enabled = true;
            btnNovo.Enabled = true;
            dtpCheckin.Enabled = true;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                id = Convert.ToInt32(dgvHospedagem.CurrentRow.Cells["Código"].Value.ToString());
                if (MessageBox.Show("Tem certeza que deseja excluir esta hospedagem?", "Confirmação de Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Hospedagens.excluirHospedagem(id);
                    carregarGrid();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btn_alterar_Click(object sender, EventArgs e)
        {
            opcao = 2;
            btnNovo.Enabled = false;
            btnExcluir.Enabled = false;
            id = Convert.ToInt32(dgvHospedagem.CurrentRow.Cells["Código"].Value.ToString());
            habilitar();
        }

        public void habilitar()
        {
            cbHospede.Enabled = true;
            cbQuarto.Enabled = true;
            dtpCheckin.Enabled = true;
            dtpCheckout.Enabled = true;
            txtValor.Enabled = true;
        }

        private void dgvHospedagem_MouseClick(object sender, MouseEventArgs e)
        {
            int idHospedagem = int.Parse(dgvHospedagem.CurrentRow.Cells["Código"].Value.ToString());
            string nomeHospede = dgvHospedagem.CurrentRow.Cells["Hóspede"].Value.ToString();
            int idQuarto = int.Parse(dgvHospedagem.CurrentRow.Cells["Quarto"].Value.ToString());
            string checkin = dgvHospedagem.CurrentRow.Cells["CheckIn"].Value.ToString();
            string checkout = dgvHospedagem.CurrentRow.Cells["checkOut"].Value.ToString();
            float valor = float.Parse(dgvHospedagem.CurrentRow.Cells["Valor"].Value.ToString());
            txtCodigo.Text = idHospedagem.ToString();
            cbHospede.Text = nomeHospede.ToString();
            cbQuarto.Text = idQuarto.ToString();
            dtpCheckin.Text = checkin.ToString();
            dtpCheckout.Text = checkout.ToString();
            txtValor.Text = valor.ToString("N2");
            desabilitar();
        }

        public void desabilitar()
        {
            cbHospede.Enabled = false;
            cbQuarto.Enabled = false;
            dtpCheckin.Enabled = false;
            dtpCheckout.Enabled = false;
            txtValor.Enabled = false;
        }

        private void RbAtual_MouseClick(object sender, MouseEventArgs e)
        {
            mkDataBusca.Enabled = true;
            mkDataBusca.Focus();
        }

        private void rbAnterior_MouseClick(object sender, MouseEventArgs e)
        {
            mkDataBusca.Enabled = true;
            mkDataBusca.Focus();
        }

        private void rbTodas_MouseClick(object sender, MouseEventArgs e)
        {
            mkDataBusca.Enabled = false;
            carregarGrid();
            mkDataBusca.Clear();
        }

        private void rbPosterior_MouseClick(object sender, MouseEventArgs e)
        {
            mkDataBusca.Enabled = true;
            mkDataBusca.Focus();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            DateTime data;

            //Limpar o dataGridView
            dgvHospedagem.DataSource = typeof(List<Hospedagens>);

            if (rbTodas.Checked)
            {

                mkDataBusca.Text = "";
                carregarGrid();
            }
            else if (RbAtual.Checked)
            {

                if (DateTime.TryParse(mkDataBusca.Text, out data))
                {
                    // data Válida
                    dgvHospedagem.DataSource = Hospedagens.listaHospedagens.FindAll(hos => hos.Checkin.Equals(data));
                }

                else
                {
                    // data invalida ou não preenchida
                    carregarGrid();
                }
            }
            else if (rbAnterior.Checked)
            {

                if (DateTime.TryParse(mkDataBusca.Text, out data))
                {
                    // data Válida
                    dgvHospedagem.DataSource = Hospedagens.listaHospedagens.FindAll(hos => hos.Checkin < data);
                }
                else
                {
                    // data invalida ou não preenchida
                    carregarGrid();
                }
            }
            else if (rbPosterior.Checked)
            {

                if (DateTime.TryParse(mkDataBusca.Text, out data))
                {
                    // data Válida
                    dgvHospedagem.DataSource = Hospedagens.listaHospedagens.FindAll(hos => hos.Checkin > data);
                }
                else
                {
                    // data invalida ou não preenchida
                    carregarGrid();
                }
            }
        }

        private void dtpCheckout_CloseUp(object sender, EventArgs e)
        {
            checkin = dtpCheckin.Text;
            checkout = dtpCheckout.Text;
            periodo = (DateTime.Parse(checkout).Subtract(DateTime.Parse(checkin))).Days;
            if (periodo == 0)
            {
                periodo = 1;
            }
            valorTotal = diaria * periodo;
            txtValor.Text = valorTotal.ToString();
        }

        private void cbReserva_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
        }

        private void frmCadHospedagem_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (Panel p in frmPrincipal.panels)
            {
                p.Dispose();
            }
            this.frm.criarPanels();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {       
            int codQuarto = listaQuarto[cbQuarto.SelectedIndex].Codigo;
            DateTime checkin = DateTime.Parse(dtpCheckin.Text);
            DateTime checkout = DateTime.Parse(dtpCheckout.Text);
            if (opcao == 1)
            {
                if (checkin < DateTime.Now.Date || checkout < DateTime.Now.Date)
                {
                    MessageBox.Show("A data de Check-in não pode ser anterior a data de hoje!");
                }
                else
                {
                    if (Reservas.listaReservas.Any(res => res.CodQuarto == codQuarto &&
                    (res.Checkin <= checkin && res.Checkout >= checkin || res.Checkin <= checkout && res.Checkout >= checkout) && !res.Codigo.Equals(sit.Reserva)))
                    {
                        MessageBox.Show("O quarto está reservado!");
                        limparCampos();
                        desabilitar();
                    }
                    else if (Hospedagens.listaHospedagens.Any(hosp => hosp.CodigoQuarto == codQuarto &&
                   (hosp.Checkin <= checkin && hosp.Checkout >= checkin || hosp.Checkin <= checkout && hosp.Checkout >= checkout)))
                    {
                        MessageBox.Show("O quarto está ocupado durante este período!");
                        limparCampos();
                        desabilitar();
                    }
                    else
                    {
                        inserir();
                        Hospedagens.inserirHospedagem(hos);
                        carregarGrid();
                        limparCampos();
                        desabilitar();
                        btn_alterar.Enabled = true;
                        btnExcluir.Enabled = true;
                        dtpCheckin.Enabled = true;
                    }
                }
            }
            if (opcao==2)
            {
                if (checkin < DateTime.Now.Date)
                {
                    MessageBox.Show("A data de Check-in não pode ser anterior a data de hoje!");
                }
                else
                {
                    if (Reservas.listaReservas.Any(res => res.CodQuarto == codQuarto &&
                    (res.Checkin <= checkin && res.Checkout >= checkin || res.Checkin <= checkout && res.Checkout >= checkout)))
                    {
                        MessageBox.Show("O quarto está reservado!");
                        limparCampos();
                        desabilitar();
                    }
                    else if (Hospedagens.listaHospedagens.Any(hosp => hosp.CodigoQuarto == codQuarto &&
                    (hosp.Checkin <= checkin && hosp.Checkout >= checkin || hosp.Checkin <= checkout && hosp.Checkout >= checkout) && !hosp.Codigo.Equals(int.Parse(txtCodigo.Text))))
                    {
                        MessageBox.Show("O quarto está em uso!");
                        limparCampos();
                        desabilitar();
                    }
                    else
                    {
                        alterar();
                        Hospedagens.alterarHospedagem(hos);
                        carregarGrid();
                        limparCampos();
                        desabilitar();
                        btnNovo.Enabled = true;
                        btnExcluir.Enabled = true;
                        dtpCheckin.Enabled = true;
                    }
                }
            }
            opcao = 0;
        }

        

        public void inserir()
        {
            if (sit != null)
                hos.CodigoHosp = sit.Hospede;
            else
                hos.CodigoHosp = listaHospede[cbHospede.SelectedIndex].Codigo;
            hos.CodigoQuarto = listaQuarto[cbQuarto.SelectedIndex].Codigo;
            hos.Checkin = DateTime.Parse(dtpCheckin.Text);
            hos.Checkout = DateTime.Parse(dtpCheckout.Text);
            hos.CodigoFunc = 1;
            if (sit != null)
            {
                if (sit.Reserva != null)
                {
                    hos.CodigoReserva = sit.Reserva;
                }
            }    
            hos.Valor = double.Parse(txtValor.Text);
        }

        public void alterar()
        {
            hos.Codigo = id;
            hos.CodigoHosp = listaHospede[cbHospede.SelectedIndex].Codigo;
            hos.CodigoQuarto = listaQuarto[cbQuarto.SelectedIndex].Codigo;
            hos.Checkin = DateTime.Parse(dtpCheckin.Text);
            hos.Checkout = DateTime.Parse(dtpCheckout.Text);
            hos.Valor = double.Parse(txtValor.Text);
        }

       

        private void cbQuarto_SelectedIndexChanged(object sender, EventArgs e)
        {
            codQua = int.Parse(cbQuarto.Text);
            diaria = listaQuarto.Find(q => q.Codigo == codQua).Valor;
        }


        public void limparCampos()
        {
            txtCodigo.Text = "";
            cbHospede.Text = "";
            cbQuarto.Text = "";
            dtpCheckin.Text = "";
            dtpCheckout.Text = "";
            txtValor.Text= "";
        }

        private void carregarReserva(int codigo)
        {
            Reservas reserva = listaReservas.Find(res => res.Codigo.Equals(codigo));
            cbHospede.Text = sit.NomeHospede;
            cbQuarto.Text = reserva.CodQuarto.ToString();
            dtpCheckin.Text = reserva.Checkin.ToString();
            dtpCheckout.Text = reserva.Checkout.ToString(); ;
            checkin = reserva.Checkin.ToString();
            checkout = reserva.Checkout.ToString();
            periodo = (DateTime.Parse(checkout).Subtract(DateTime.Parse(checkin))).Days;
            if (periodo == 0)
            {
                periodo = 1;
            }
            valorTotal = diaria * periodo;
            txtValor.Text = valorTotal.ToString("N2");
        }
    }
}
