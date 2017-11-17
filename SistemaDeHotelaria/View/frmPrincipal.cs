using SistemaDeHotelaria.Controller;
using SistemaDeHotelaria.Domain;
using SistemaDeHotelaria.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaDeHotelaria
{
    public partial class frmPrincipal : Form
    {
        public static List<Panel> panels = new List<Panel>();
        List<SituacaoQuarto> listaSituacao = new List<SituacaoQuarto>();
        public frmPrincipal()
        {
            InitializeComponent();
            criarPanels();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmHospedes frm = new frmHospedes();
            frm.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            frmCadProduto frm = new frmCadProduto();
            frm.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            frmCadServico frm = new frmCadServico();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmCadQuarto frm = new frmCadQuarto(this);
            frm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            
        }

        public void criarPainelOcupado(int larg, int alt, SituacaoQuarto st)
        {
            Panel panel1 = new Panel();

            Button btnEstadia = new Button();
            btnEstadia.Location = new System.Drawing.Point(29, 139);
            btnEstadia.Name = "button14";
            btnEstadia.Size = new System.Drawing.Size(105, 23);
            btnEstadia.TabIndex = 5;
            btnEstadia.Text = "Finalizar Estadia";
            btnEstadia.UseVisualStyleBackColor = true;

            Button btnConsumo = new Button();
            btnConsumo.Location = new System.Drawing.Point(7, 110);
            btnConsumo.Name = "button16";
            btnConsumo.Size = new System.Drawing.Size(70, 23);
            btnConsumo.TabIndex = 3;
            btnConsumo.Text = "Consumos";
            btnConsumo.UseVisualStyleBackColor = true;

            Button btnServico = new Button();
            btnServico.Location = new System.Drawing.Point(85, 110);
            btnServico.Name = "button15";
            btnServico.Size = new System.Drawing.Size(70, 23);
            btnServico.TabIndex = 4;
            btnServico.Text = "Serviços";
            btnServico.UseVisualStyleBackColor = true;

            Label lblPeriodo = new Label();
            lblPeriodo.AutoSize = true;
            lblPeriodo.Location = new System.Drawing.Point(20, 94);
            lblPeriodo.Name = "label1";
            lblPeriodo.Size = new System.Drawing.Size(135, 13);
            lblPeriodo.TabIndex = 3;
            lblPeriodo.Text = st.CheckIn.Day + "/" + st.CheckIn.Month + "/" + st.CheckIn.Year + " a " + st.CheckOut.Day + "/" + st.CheckOut.Month + "/" + st.CheckOut.Year;


            Label lblEstadia = new Label();
            lblEstadia.AutoSize = true;
            lblEstadia.Location = new System.Drawing.Point(65, 81);
            lblEstadia.Name = "label2";
            lblEstadia.Size = new System.Drawing.Size(45, 13);
            lblEstadia.TabIndex = 2;
            lblEstadia.Text = "Estadia:";

            Label lblHospede = new Label();
            lblHospede.AutoSize = true;
            lblHospede.Location = new System.Drawing.Point(38, 55);
            lblHospede.Name = "label3";
            lblHospede.Size = new System.Drawing.Size(96, 13);
            lblHospede.TabIndex = 1;
            lblHospede.Text = st.NomeHospede;

            Label lblQuarto = new Label();
            lblQuarto.AutoSize = true;
            lblQuarto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblQuarto.Location = new System.Drawing.Point(71, 14);
            lblQuarto.Name = "label4";
            lblQuarto.Size = new System.Drawing.Size(32, 24);
            lblQuarto.TabIndex = 0;
            lblQuarto.Text = st.Quarto.ToString();

            panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel1.Controls.Add(btnEstadia);
            panel1.Controls.Add(btnServico);
            panel1.Controls.Add(btnConsumo);
            panel1.Controls.Add(lblPeriodo);
            panel1.Controls.Add(lblEstadia);
            panel1.Controls.Add(lblHospede);
            panel1.Controls.Add(lblQuarto);
            panel1.Location = new System.Drawing.Point(larg, alt);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(168, 167);
            panel1.TabIndex = 1;
            this.Controls.Add(panel1);
            panels.Add(panel1);
        }

        public void criarPanelReservado(int larg, int alt, SituacaoQuarto st)
        {
            Panel panelReservado = new Panel();

            Label lblHospedeReserva = new Label();
            lblHospedeReserva.AutoSize = true;
            lblHospedeReserva.Location = new System.Drawing.Point(42, 76);
            lblHospedeReserva.Name = "lblHospedeReserva";
            lblHospedeReserva.Size = new System.Drawing.Size(96, 13);
            lblHospedeReserva.TabIndex = 6;
            lblHospedeReserva.Text = st.NomeHospede;

            Label lblPeriodoReserva = new Label();
            lblPeriodoReserva.AutoSize = true;
            lblPeriodoReserva.Location = new System.Drawing.Point(18, 112);
            lblPeriodoReserva.Name = "lblPeriodoReserva";
            lblPeriodoReserva.Size = new System.Drawing.Size(135, 13);
            lblPeriodoReserva.TabIndex = 3;
            lblPeriodoReserva.Text = st.CheckIn.Day + "/" + st.CheckIn.Month + "/" + st.CheckIn.Year + " a " + st.CheckOut.Day + "/" + st.CheckOut.Month + "/" + st.CheckOut.Year;

            Label lblEstadiaReserva = new Label();
            lblEstadiaReserva.AutoSize = true;
            lblEstadiaReserva.Location = new System.Drawing.Point(63, 99);
            lblEstadiaReserva.Name = "lblEstadiaReserva";
            lblEstadiaReserva.Size = new System.Drawing.Size(45, 13);
            lblEstadiaReserva.TabIndex = 2;
            lblEstadiaReserva.Text = "Estadia:";

            Label lblReservado = new Label();
            lblReservado.AutoSize = true;
            lblReservado.Location = new System.Drawing.Point(48, 60);
            lblReservado.Name = "lblReservado";
            lblReservado.Size = new System.Drawing.Size(86, 13);
            lblReservado.TabIndex = 1;
            lblReservado.Text = "Reservado para:";

            Label label4 = new Label();
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label4.Location = new System.Drawing.Point(71, 14);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(32, 24);
            label4.TabIndex = 0;
            label4.Text = st.Quarto.ToString();

            Button button14 = new Button();
            button14.Location = new System.Drawing.Point(33, 128);
            button14.Name = "button14";
            button14.Size = new System.Drawing.Size(105, 23);
            button14.TabIndex = 5;
            button14.Text = "Cancelar Reserva";
            button14.UseVisualStyleBackColor = true;

            panelReservado.BackColor = System.Drawing.Color.IndianRed;
            panelReservado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panelReservado.Controls.Add(lblHospedeReserva);
            panelReservado.Controls.Add(button14);
            panelReservado.Controls.Add(lblPeriodoReserva);
            panelReservado.Controls.Add(lblEstadiaReserva);
            panelReservado.Controls.Add(lblReservado);
            panelReservado.Controls.Add(label4);
            panelReservado.Location = new System.Drawing.Point(larg, alt);
            panelReservado.Name = "panelReservado";
            panelReservado.Size = new System.Drawing.Size(168, 167);
            panelReservado.TabIndex = 6;
            this.Controls.Add(panelReservado);
            panels.Add(panelReservado);
        }

        public void criarPanelDisponivel(int larg, int alt, SituacaoQuarto st)
        {
            Button btnHospedar = new Button();
            btnHospedar.Location = new System.Drawing.Point(35, 130);
            btnHospedar.Name = "btnHospedar";
            btnHospedar.Size = new System.Drawing.Size(105, 23);
            btnHospedar.TabIndex = 6;
            btnHospedar.Text = "Hospedar";
            btnHospedar.UseVisualStyleBackColor = true;

            Button btnReservar = new Button();
            btnReservar.Location = new System.Drawing.Point(35, 101);
            btnReservar.Name = "btnReservar";
            btnReservar.Size = new System.Drawing.Size(105, 23);
            btnReservar.TabIndex = 5;
            btnReservar.Text = "Reservar";
            btnReservar.UseVisualStyleBackColor = true;

            Label lblQuartoDisponivel = new Label();
            lblQuartoDisponivel.AutoSize = true;
            lblQuartoDisponivel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblQuartoDisponivel.Location = new System.Drawing.Point(71, 14);
            lblQuartoDisponivel.Name = "lblQuartoDisponivel";
            lblQuartoDisponivel.Size = new System.Drawing.Size(32, 24);
            lblQuartoDisponivel.TabIndex = 0;
            lblQuartoDisponivel.Text = st.Quarto.ToString();

            Label quartoDisponivel = new Label();
            quartoDisponivel.AutoSize = true;
            quartoDisponivel.Location = new System.Drawing.Point(58, 75);
            quartoDisponivel.Name = "quartoDisponivel";
            quartoDisponivel.Size = new System.Drawing.Size(58, 13);
            quartoDisponivel.TabIndex = 2;
            quartoDisponivel.Text = "Disponível";

            Panel panelDisponivel = new Panel();
            panelDisponivel.BackColor = System.Drawing.Color.PaleGreen;
            panelDisponivel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panelDisponivel.Controls.Add(btnHospedar);
            panelDisponivel.Controls.Add(btnReservar);
            panelDisponivel.Controls.Add(lblQuartoDisponivel);
            panelDisponivel.Controls.Add(quartoDisponivel);
            panelDisponivel.Location = new System.Drawing.Point(larg, alt);
            panelDisponivel.Name = "panelDisponivel";
            panelDisponivel.Size = new System.Drawing.Size(168, 167);
            panelDisponivel.TabIndex = 6;
            this.Controls.Add(panelDisponivel);
            panels.Add(panelDisponivel);
        }

        

        public void criarPanels()
        {
            listaSituacao.Clear();
            carregarStatusQuartos();
            int larg = 22, alt = 100, i=0;

            foreach (SituacaoQuarto st in listaSituacao)
            {
                if (st.Hospedagem == 0 && st.Reserva == 0)
                {
                    criarPanelDisponivel(larg, alt, st);
                }
                else if (st.Hospedagem != 0)
                {
                    criarPainelOcupado(larg, alt, st);
                }
                else
                {
                    criarPanelReservado(larg, alt, st);
                }
                larg = larg + 182;
                if (i == 6 || i == 13)
                {
                    alt = alt + 180;
                    larg = 22;
                }
                i++;
            }
        }
        public void carregarStatusQuartos()
        {
            try
            {
                using (Entities ef = new Entities())
                {
                    List<quarto> listaQuarto = ef.quartos.ToList();
                    List<hospedagem> listaHospedagem = ef.hospedagems.ToList();
                    List<reserva> listaReserva = ef.reservas.ToList();
                    List<hospede> listaHospede = ef.hospedes.ToList();

                    foreach (quarto q in listaQuarto)
                    {
                        try
                        {
                            SituacaoQuarto sit = new SituacaoQuarto();
                            sit.Quarto = q.quartoCodigo;

                            hospedagem ho = listaHospedagem.Find(h => h.quartoCodigo.Equals(sit.Quarto) && DateTime.Compare(h.hospCheckin, DateTime.Now.Date) == 0);
                            if (ho != null)
                            {
                                sit.Hospedagem = ho.hospedagemCodigo;
                                hospede hosp = listaHospede.Find(h => h.hospCodigo.Equals(ho.hospCodigo));
                                sit.Hospede = hosp.hospCodigo;
                                sit.NomeHospede = hosp.hospNome;
                                sit.CheckIn = ho.hospCheckin;
                                sit.CheckOut = ho.hospCheckout;
                            }
                            else
                                sit.Hospedagem = 0;
                            reserva re = listaReserva.Find(r => r.quartoCodigo.Equals(sit.Quarto) && DateTime.Compare(r.reservaCheckin, DateTime.Now.Date) == 0);
                            if (re != null)
                            {
                                sit.Reserva = re.reservaCodigo;
                                hospede hosp = listaHospede.Find(h => h.hospCodigo.Equals(re.hospCodigo));
                                sit.Hospede = hosp.hospCodigo;
                                sit.NomeHospede = hosp.hospNome;
                                sit.CheckIn = re.reservaCheckin;
                                sit.CheckOut = re.reservaCheckout;
                            }
                            else
                                sit.Reserva = 0;

                            listaSituacao.Add(sit);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Erro: " + ex.Message);
                        }
                    }
                }
            }
            catch (Exception e)
            {

            }


        }
    }
}
