namespace SistemaDeHotelaria.View
{
    partial class frmCadHospedagem
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbHospede = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.gpbBuscaHospedagem = new System.Windows.Forms.GroupBox();
            this.rbTodas = new System.Windows.Forms.RadioButton();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.rbPosterior = new System.Windows.Forms.RadioButton();
            this.rbAnterior = new System.Windows.Forms.RadioButton();
            this.RbAtual = new System.Windows.Forms.RadioButton();
            this.mkDataBusca = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btn_alterar = new System.Windows.Forms.Button();
            this.cbQuarto = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpCheckout = new System.Windows.Forms.DateTimePicker();
            this.dtpCheckin = new System.Windows.Forms.DateTimePicker();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvHospedagem = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.gpbBuscaHospedagem.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHospedagem)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbHospede);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtValor);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.gpbBuscaHospedagem);
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.btnSalvar);
            this.panel1.Controls.Add(this.btnNovo);
            this.panel1.Controls.Add(this.btnExcluir);
            this.panel1.Controls.Add(this.btn_alterar);
            this.panel1.Controls.Add(this.cbQuarto);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.dtpCheckout);
            this.panel1.Controls.Add(this.dtpCheckin);
            this.panel1.Controls.Add(this.txtCodigo);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(838, 171);
            this.panel1.TabIndex = 0;
            // 
            // cbHospede
            // 
            this.cbHospede.FormattingEnabled = true;
            this.cbHospede.Location = new System.Drawing.Point(64, 25);
            this.cbHospede.Name = "cbHospede";
            this.cbHospede.Size = new System.Drawing.Size(362, 21);
            this.cbHospede.TabIndex = 154;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(61, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 153;
            this.label5.Text = "Hóspede:";
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(342, 68);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(64, 20);
            this.txtValor.TabIndex = 152;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(339, 52);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 13);
            this.label8.TabIndex = 151;
            this.label8.Text = "R$:";
            // 
            // gpbBuscaHospedagem
            // 
            this.gpbBuscaHospedagem.Controls.Add(this.rbTodas);
            this.gpbBuscaHospedagem.Controls.Add(this.btnFiltrar);
            this.gpbBuscaHospedagem.Controls.Add(this.rbPosterior);
            this.gpbBuscaHospedagem.Controls.Add(this.rbAnterior);
            this.gpbBuscaHospedagem.Controls.Add(this.RbAtual);
            this.gpbBuscaHospedagem.Controls.Add(this.mkDataBusca);
            this.gpbBuscaHospedagem.Controls.Add(this.label7);
            this.gpbBuscaHospedagem.Location = new System.Drawing.Point(578, 12);
            this.gpbBuscaHospedagem.Name = "gpbBuscaHospedagem";
            this.gpbBuscaHospedagem.Size = new System.Drawing.Size(238, 149);
            this.gpbBuscaHospedagem.TabIndex = 148;
            this.gpbBuscaHospedagem.TabStop = false;
            this.gpbBuscaHospedagem.Text = "Buscar Hospedagens";
            // 
            // rbTodas
            // 
            this.rbTodas.AutoSize = true;
            this.rbTodas.Location = new System.Drawing.Point(9, 106);
            this.rbTodas.Name = "rbTodas";
            this.rbTodas.Size = new System.Drawing.Size(55, 17);
            this.rbTodas.TabIndex = 23;
            this.rbTodas.TabStop = true;
            this.rbTodas.Text = "Todas";
            this.rbTodas.UseVisualStyleBackColor = true;
            this.rbTodas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.rbTodas_MouseClick);
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnFiltrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFiltrar.Location = new System.Drawing.Point(145, 93);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(78, 32);
            this.btnFiltrar.TabIndex = 18;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = false;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // rbPosterior
            // 
            this.rbPosterior.AutoSize = true;
            this.rbPosterior.Location = new System.Drawing.Point(64, 106);
            this.rbPosterior.Name = "rbPosterior";
            this.rbPosterior.Size = new System.Drawing.Size(66, 17);
            this.rbPosterior.TabIndex = 22;
            this.rbPosterior.TabStop = true;
            this.rbPosterior.Text = "Posterior";
            this.rbPosterior.UseVisualStyleBackColor = true;
            this.rbPosterior.MouseClick += new System.Windows.Forms.MouseEventHandler(this.rbPosterior_MouseClick);
            // 
            // rbAnterior
            // 
            this.rbAnterior.AutoSize = true;
            this.rbAnterior.Location = new System.Drawing.Point(64, 71);
            this.rbAnterior.Name = "rbAnterior";
            this.rbAnterior.Size = new System.Drawing.Size(61, 17);
            this.rbAnterior.TabIndex = 21;
            this.rbAnterior.TabStop = true;
            this.rbAnterior.Text = "Anterior";
            this.rbAnterior.UseVisualStyleBackColor = true;
            this.rbAnterior.MouseClick += new System.Windows.Forms.MouseEventHandler(this.rbAnterior_MouseClick);
            // 
            // RbAtual
            // 
            this.RbAtual.AutoSize = true;
            this.RbAtual.Location = new System.Drawing.Point(9, 69);
            this.RbAtual.Name = "RbAtual";
            this.RbAtual.Size = new System.Drawing.Size(49, 17);
            this.RbAtual.TabIndex = 20;
            this.RbAtual.TabStop = true;
            this.RbAtual.Text = "Atual";
            this.RbAtual.UseVisualStyleBackColor = true;
            this.RbAtual.MouseClick += new System.Windows.Forms.MouseEventHandler(this.RbAtual_MouseClick);
            // 
            // mkDataBusca
            // 
            this.mkDataBusca.Location = new System.Drawing.Point(9, 32);
            this.mkDataBusca.Mask = "00/00/0000";
            this.mkDataBusca.Name = "mkDataBusca";
            this.mkDataBusca.Size = new System.Drawing.Size(100, 20);
            this.mkDataBusca.TabIndex = 18;
            this.mkDataBusca.ValidatingType = typeof(System.DateTime);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Data da Hospedagem";
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.Location = new System.Drawing.Point(264, 110);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(78, 32);
            this.btnCancelar.TabIndex = 147;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSalvar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalvar.Location = new System.Drawing.Point(180, 110);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(78, 32);
            this.btnSalvar.TabIndex = 146;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnNovo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNovo.Location = new System.Drawing.Point(12, 110);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(78, 32);
            this.btnNovo.TabIndex = 145;
            this.btnNovo.Text = "Novo";
            this.btnNovo.UseVisualStyleBackColor = false;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnExcluir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExcluir.Location = new System.Drawing.Point(348, 110);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(78, 32);
            this.btnExcluir.TabIndex = 144;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = false;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btn_alterar
            // 
            this.btn_alterar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_alterar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_alterar.Location = new System.Drawing.Point(96, 110);
            this.btn_alterar.Name = "btn_alterar";
            this.btn_alterar.Size = new System.Drawing.Size(78, 32);
            this.btn_alterar.TabIndex = 143;
            this.btn_alterar.Text = "Alterar";
            this.btn_alterar.UseVisualStyleBackColor = false;
            this.btn_alterar.Click += new System.EventHandler(this.btn_alterar_Click);
            // 
            // cbQuarto
            // 
            this.cbQuarto.FormattingEnabled = true;
            this.cbQuarto.Location = new System.Drawing.Point(12, 67);
            this.cbQuarto.Name = "cbQuarto";
            this.cbQuarto.Size = new System.Drawing.Size(64, 21);
            this.cbQuarto.TabIndex = 138;
            this.cbQuarto.SelectedIndexChanged += new System.EventHandler(this.cbQuarto_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 137;
            this.label4.Text = "Quarto:";
            // 
            // dtpCheckout
            // 
            this.dtpCheckout.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCheckout.Location = new System.Drawing.Point(217, 68);
            this.dtpCheckout.Name = "dtpCheckout";
            this.dtpCheckout.Size = new System.Drawing.Size(97, 20);
            this.dtpCheckout.TabIndex = 136;
            this.dtpCheckout.CloseUp += new System.EventHandler(this.dtpCheckout_CloseUp);
            // 
            // dtpCheckin
            // 
            this.dtpCheckin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCheckin.Location = new System.Drawing.Point(98, 68);
            this.dtpCheckin.Name = "dtpCheckin";
            this.dtpCheckin.Size = new System.Drawing.Size(96, 20);
            this.dtpCheckin.TabIndex = 135;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(12, 25);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(43, 20);
            this.txtCodigo.TabIndex = 134;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(214, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 133;
            this.label3.Text = "Checkout:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(95, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 132;
            this.label2.Text = "Checkin:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 131;
            this.label1.Text = "Código:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvHospedagem);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 181);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(838, 271);
            this.panel2.TabIndex = 1;
            // 
            // dgvHospedagem
            // 
            this.dgvHospedagem.AllowUserToAddRows = false;
            this.dgvHospedagem.AllowUserToDeleteRows = false;
            this.dgvHospedagem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHospedagem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHospedagem.Location = new System.Drawing.Point(0, 0);
            this.dgvHospedagem.Name = "dgvHospedagem";
            this.dgvHospedagem.ReadOnly = true;
            this.dgvHospedagem.Size = new System.Drawing.Size(838, 271);
            this.dgvHospedagem.TabIndex = 2;
            this.dgvHospedagem.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvHospedagem_MouseClick);
            // 
            // frmCadHospedagem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 452);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmCadHospedagem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Hospedagens";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCadHospedagem_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gpbBuscaHospedagem.ResumeLayout(false);
            this.gpbBuscaHospedagem.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHospedagem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox gpbBuscaHospedagem;
        private System.Windows.Forms.RadioButton rbTodas;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.RadioButton rbPosterior;
        private System.Windows.Forms.RadioButton rbAnterior;
        private System.Windows.Forms.RadioButton RbAtual;
        public System.Windows.Forms.MaskedTextBox mkDataBusca;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btn_alterar;
        private System.Windows.Forms.ComboBox cbQuarto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpCheckout;
        private System.Windows.Forms.DateTimePicker dtpCheckin;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbHospede;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvHospedagem;
    }
}