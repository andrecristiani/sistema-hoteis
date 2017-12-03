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
    public partial class frmCadReserva : Form
    {
        frmPrincipal frm;
        List<Hospede> listaHospede;
        List<Quarto> listaQuarto;
        List<Funcionario> listaFuncionario;
        List<Reservas> listaReservas;
        SituacaoQuarto sit;
        int opcao = 0, id = 0;
        Reservas res = new Reservas();
 
        public frmCadReserva(frmPrincipal frm)
        {
            InitializeComponent();
            this.frm = frm;
            Hospedagens.carregarHospedagens();
            carregarGrid();
            listaHospede = Hospede.carregarListaHospede();
            foreach (var l in listaHospede)
            {
                cbHospede.Items.Add(l.Nome);
            }
            Quarto.carregarListaQuartos();
            listaQuarto = Quarto.listaQuartos;
            foreach (var l in listaQuarto)
            {
                cbQuarto.Items.Add(l.Codigo);
            }
            listaFuncionario = Funcionario.carregarListaFuncionarios();
            listaReservas = Reservas.carregarListaReservas();
            desabilitar();
            txtCodigo.Enabled = false;
            rbTodas.Checked = true;
            mkDataBusca.Enabled = false;
        }

        public frmCadReserva(frmPrincipal frm, SituacaoQuarto sit)
        {
            InitializeComponent();
            this.frm = frm;
            this.sit = sit;
            carregarGrid();
            Hospedagens.carregarHospedagens();
            listaHospede = Hospede.carregarListaHospede();
            foreach (var l in listaHospede)
            {
                cbHospede.Items.Add(l.Nome);
            }
            Quarto.carregarListaQuartos();
            listaQuarto = Quarto.listaQuartos;
            foreach (var l in listaQuarto)
            {
                cbQuarto.Items.Add(l.Codigo);
            }
            listaFuncionario = Funcionario.carregarListaFuncionarios();
            listaReservas = Reservas.carregarListaReservas();
            desabilitar();
            txtCodigo.Enabled = false;
            rbTodas.Checked = true;
            mkDataBusca.Enabled = false;
            cbQuarto.SelectedItem = sit.Quarto;
            habilitar();
            opcao = 1;
            cbQuarto.Enabled = false;
        }
       
        
        private void carregarGrid()
        {
            using (Entities ef = new Entities())
            {
                var dados = (from r in ef.reserva
                             join h in ef.hospede on r.hospCodigo equals h.hospCodigo
                             join f in ef.funcionario on r.funcCodigo equals f.funcCodigo
                             select new { Código = r.reservaCodigo, CheckIn = r.reservaCheckin, CheckOut = r.reservaCheckout, Quarto = r.quartoCodigo, Hóspede = h.hospNome, Funcionário = f.funcNome }).ToList();
                dgvReserva.DataSource = dados;
            }

        }

       

        private void btnNovo_Click(object sender, EventArgs e)
        {
            opcao = 1;
            limparCampos();
            habilitar();
            btn_alterar.Enabled = false;
            btnExcluir.Enabled = false;
        }

       

        private void btn_alterar_Click(object sender, EventArgs e)
        {
            opcao = 2;
            btnNovo.Enabled = false;
            btnExcluir.Enabled = false;
            id = Convert.ToInt32(dgvReserva.CurrentRow.Cells["Código"].Value.ToString());
            habilitar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            opcao = 0;
            limparCampos();
            desabilitar();
            btn_alterar.Enabled = true;
            btnExcluir.Enabled = true;
            btnNovo.Enabled = true;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                id = Convert.ToInt32(dgvReserva.CurrentRow.Cells["Código"].Value.ToString());
                if (MessageBox.Show("Tem certeza que deseja excluir este hóspede?", "Confirmação de Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Reservas.excluirReserva(id);
                    carregarGrid();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        public void habilitar()
        {
            cbHospede.Enabled = true;
            cbQuarto.Enabled = true;
            dtpCheckin.Enabled = true;
            dtpCheckout.Enabled = true;
            btnNovo.Enabled = false;
            btn_alterar.Enabled = false;
            btnExcluir.Enabled = false;
            dgvReserva.Enabled = false;
            gpbBuscaReserva.Enabled = false;
            btnSalvar.Enabled = true;
            btnCancelar.Enabled = true;
        }

        private void dgvReserva_MouseClick(object sender, MouseEventArgs e)
        {
            int idReserva = int.Parse(dgvReserva.CurrentRow.Cells["Código"].Value.ToString());
            string nomeHospede = dgvReserva.CurrentRow.Cells["Hóspede"].Value.ToString();
            int idQuarto = int.Parse(dgvReserva.CurrentRow.Cells["Quarto"].Value.ToString());
            string checkin = dgvReserva.CurrentRow.Cells["CheckIn"].Value.ToString();
            string checkout = dgvReserva.CurrentRow.Cells["CheckOut"].Value.ToString();
            txtCodigo.Text = idReserva.ToString();
            cbHospede.Text = nomeHospede.ToString();
            cbQuarto.Text = idQuarto.ToString();
            dtpCheckin.Text = checkin.ToString();
            dtpCheckout.Text = checkout.ToString();
            desabilitar();
        }

        public void desabilitar()
        {
            cbHospede.Enabled = false;
            cbQuarto.Enabled = false;
            dtpCheckin.Enabled = false;
            dtpCheckout.Enabled = false;
            btnNovo.Enabled = true;
            btn_alterar.Enabled = true;
            btnExcluir.Enabled = true;
            dgvReserva.Enabled = true;
            gpbBuscaReserva.Enabled = true;
            btnSalvar.Enabled = false;
            btnCancelar.Enabled = false;
        }

        private void RbAtual_MouseClick(object sender, MouseEventArgs e)
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

        private void rbAnterior_MouseClick(object sender, MouseEventArgs e)
        {
            mkDataBusca.Enabled = true;
            mkDataBusca.Focus();
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
            dgvReserva.DataSource = typeof(List<Reservas>);

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
                    dgvReserva.DataSource = Reservas.listaReservas.FindAll(res => res.Checkin.Equals(data));
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
                    dgvReserva.DataSource = Reservas.listaReservas.FindAll(res => res.Checkin < data);
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
                    dgvReserva.DataSource = Reservas.listaReservas.FindAll(res => res.Checkin > data);
                }
                else
                {
                    // data invalida ou não preenchida
                    carregarGrid();
                }
            }
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
                   (res.Checkin <= checkin && res.Checkout >= checkin || res.Checkin <= checkout && res.Checkout >= checkout)))
                    {
                        MessageBox.Show("O quarto está reservado!");
                        limparCampos();
                        desabilitar();
                    }else if (Hospedagens.listaHospedagens.Any(hosp => hosp.CodigoQuarto == codQuarto && 
                    (hosp.Checkin <= checkin && hosp.Checkout >= checkin || hosp.Checkin <= checkout && hosp.Checkout >= checkout)))
                    {
                        MessageBox.Show("O quarto está ocupado durante este período!");
                        limparCampos();
                        desabilitar();
                    }
                    else
                    {
                        inserir();
                        try
                        {
                            Reservas.inserirReserva(res);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Erro ao inserir: " + ex.Message);
                        }
                        carregarGrid();
                        limparCampos();
                        desabilitar();
                        btn_alterar.Enabled = true;
                        btnExcluir.Enabled = true;
                    }
                }
            }
            if (opcao == 2)
            {
                if (checkin < DateTime.Now.Date)
                {
                    MessageBox.Show("A data de Check-in não pode ser anterior a data de hoje!");
                }
                else
                {
                    if (Reservas.listaReservas.Any(res => res.CodQuarto == codQuarto &&
                     (res.Checkin <= checkin && res.Checkout >= checkin || res.Checkin <= checkout && res.Checkout >= checkout) && !res.Codigo.Equals(int.Parse(txtCodigo.Text))))
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
                        alterar();
                        Reservas.alterarReserva(res);
                        carregarGrid();
                        limparCampos();
                        desabilitar();
                        btnNovo.Enabled = true;
                        btnExcluir.Enabled = true;
                    }
                }
            }
           
                opcao = 0;
        
        }

        public void limparCampos()
        {
            txtCodigo.Clear();
            cbHospede.Text = "";
            cbQuarto.Text = "";
            dtpCheckin.Text = "";
            dtpCheckout.Text = "";
        }

        public void inserir()
        {
            res.CodHospede = listaHospede[cbHospede.SelectedIndex].Codigo;
            res.CodQuarto = listaQuarto[cbQuarto.SelectedIndex].Codigo;
            res.Checkin = DateTime.Parse(dtpCheckin.Text);
            res.Checkout = DateTime.Parse(dtpCheckout.Text);
            res.CodFuncionario = 1;
        }

        private void frmCadReserva_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (Panel p in frmPrincipal.panels)
            {
                p.Dispose();
            }
            this.frm.criarPanels();
        }

        public void alterar()
        {
            res.Codigo = id;
            res.CodHospede = listaHospede[cbHospede.SelectedIndex].Codigo;
            res.CodQuarto = listaQuarto[cbQuarto.SelectedIndex].Codigo;
            res.Checkin = DateTime.Parse(dtpCheckin.Text);
            res.Checkout = DateTime.Parse(dtpCheckout.Text);
            res.CodFuncionario = 1;
        }

    }
}
