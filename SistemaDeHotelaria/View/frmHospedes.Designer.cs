namespace SistemaDeHotelaria.View
{
    partial class frmHospedes
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
            this.maskCPF = new System.Windows.Forms.MaskedTextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.cbCidade = new System.Windows.Forms.ComboBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btn_alterar = new System.Windows.Forms.Button();
            this.gbBuscaHospedes = new System.Windows.Forms.GroupBox();
            this.rbTodos = new System.Windows.Forms.RadioButton();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.rbCodigo = new System.Windows.Forms.RadioButton();
            this.rbCPF = new System.Windows.Forms.RadioButton();
            this.maskBuscaCpf = new System.Windows.Forms.MaskedTextBox();
            this.rbNome = new System.Windows.Forms.RadioButton();
            this.label13 = new System.Windows.Forms.Label();
            this.txtBuscaCodigo = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtBuscaNome = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.maskCelular = new System.Windows.Forms.MaskedTextBox();
            this.maskTelefone = new System.Windows.Forms.MaskedTextBox();
            this.txtComplemento = new System.Windows.Forms.TextBox();
            this.txtBairro = new System.Windows.Forms.TextBox();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.txtLogradouro = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.maskCEP = new System.Windows.Forms.MaskedTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvHospede = new System.Windows.Forms.DataGridView();
            this.hospCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cpf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Celular = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Logradouro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bairro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Complemento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cidadeCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.gbBuscaHospedes.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHospede)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.maskCPF);
            this.panel1.Controls.Add(this.txtCodigo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.cbCidade);
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.btnSalvar);
            this.panel1.Controls.Add(this.btnNovo);
            this.panel1.Controls.Add(this.btnExcluir);
            this.panel1.Controls.Add(this.btn_alterar);
            this.panel1.Controls.Add(this.gbBuscaHospedes);
            this.panel1.Controls.Add(this.maskCelular);
            this.panel1.Controls.Add(this.maskTelefone);
            this.panel1.Controls.Add(this.txtComplemento);
            this.panel1.Controls.Add(this.txtBairro);
            this.panel1.Controls.Add(this.txtNumero);
            this.panel1.Controls.Add(this.txtLogradouro);
            this.panel1.Controls.Add(this.txtNome);
            this.panel1.Controls.Add(this.maskCEP);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(846, 247);
            this.panel1.TabIndex = 0;
            // 
            // maskCPF
            // 
            this.maskCPF.Location = new System.Drawing.Point(484, 34);
            this.maskCPF.Mask = "000,000,000-00";
            this.maskCPF.Name = "maskCPF";
            this.maskCPF.Size = new System.Drawing.Size(95, 20);
            this.maskCPF.TabIndex = 3;
            this.maskCPF.Validating += new System.ComponentModel.CancelEventHandler(this.maskCPF_Validating);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(15, 34);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(43, 20);
            this.txtCodigo.TabIndex = 110;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 109;
            this.label1.Text = "ID:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(152, 132);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(43, 13);
            this.label14.TabIndex = 108;
            this.label14.Text = "Cidade:";
            // 
            // cbCidade
            // 
            this.cbCidade.FormattingEnabled = true;
            this.cbCidade.Location = new System.Drawing.Point(155, 149);
            this.cbCidade.Name = "cbCidade";
            this.cbCidade.Size = new System.Drawing.Size(121, 21);
            this.cbCidade.TabIndex = 8;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.Location = new System.Drawing.Point(267, 203);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(78, 32);
            this.btnCancelar.TabIndex = 106;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSalvar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalvar.Location = new System.Drawing.Point(183, 203);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(78, 32);
            this.btnSalvar.TabIndex = 105;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnNovo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNovo.Location = new System.Drawing.Point(15, 203);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(78, 32);
            this.btnNovo.TabIndex = 104;
            this.btnNovo.Text = "Novo";
            this.btnNovo.UseVisualStyleBackColor = false;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnExcluir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExcluir.Location = new System.Drawing.Point(351, 203);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(78, 32);
            this.btnExcluir.TabIndex = 103;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = false;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btn_alterar
            // 
            this.btn_alterar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_alterar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_alterar.Location = new System.Drawing.Point(99, 203);
            this.btn_alterar.Name = "btn_alterar";
            this.btn_alterar.Size = new System.Drawing.Size(78, 32);
            this.btn_alterar.TabIndex = 102;
            this.btn_alterar.Text = "Alterar";
            this.btn_alterar.UseVisualStyleBackColor = false;
            this.btn_alterar.Click += new System.EventHandler(this.btn_alterar_Click);
            // 
            // gbBuscaHospedes
            // 
            this.gbBuscaHospedes.Controls.Add(this.rbTodos);
            this.gbBuscaHospedes.Controls.Add(this.btnBuscar);
            this.gbBuscaHospedes.Controls.Add(this.rbCodigo);
            this.gbBuscaHospedes.Controls.Add(this.rbCPF);
            this.gbBuscaHospedes.Controls.Add(this.maskBuscaCpf);
            this.gbBuscaHospedes.Controls.Add(this.rbNome);
            this.gbBuscaHospedes.Controls.Add(this.label13);
            this.gbBuscaHospedes.Controls.Add(this.txtBuscaCodigo);
            this.gbBuscaHospedes.Controls.Add(this.label12);
            this.gbBuscaHospedes.Controls.Add(this.txtBuscaNome);
            this.gbBuscaHospedes.Controls.Add(this.label11);
            this.gbBuscaHospedes.Location = new System.Drawing.Point(621, 18);
            this.gbBuscaHospedes.Name = "gbBuscaHospedes";
            this.gbBuscaHospedes.Size = new System.Drawing.Size(215, 223);
            this.gbBuscaHospedes.TabIndex = 101;
            this.gbBuscaHospedes.TabStop = false;
            this.gbBuscaHospedes.Text = "Buscar Hóspedes";
            // 
            // rbTodos
            // 
            this.rbTodos.AutoSize = true;
            this.rbTodos.Location = new System.Drawing.Point(9, 185);
            this.rbTodos.Name = "rbTodos";
            this.rbTodos.Size = new System.Drawing.Size(55, 17);
            this.rbTodos.TabIndex = 27;
            this.rbTodos.TabStop = true;
            this.rbTodos.Text = "Todos";
            this.rbTodos.UseVisualStyleBackColor = true;
            this.rbTodos.MouseClick += new System.Windows.Forms.MouseEventHandler(this.rbTodos_MouseClick);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.Location = new System.Drawing.Point(131, 161);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(78, 32);
            this.btnBuscar.TabIndex = 26;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // rbCodigo
            // 
            this.rbCodigo.AutoSize = true;
            this.rbCodigo.Location = new System.Drawing.Point(9, 150);
            this.rbCodigo.Name = "rbCodigo";
            this.rbCodigo.Size = new System.Drawing.Size(58, 17);
            this.rbCodigo.TabIndex = 21;
            this.rbCodigo.TabStop = true;
            this.rbCodigo.Text = "Código";
            this.rbCodigo.UseVisualStyleBackColor = true;
            this.rbCodigo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.rbCodigo_MouseClick);
            // 
            // rbCPF
            // 
            this.rbCPF.AutoSize = true;
            this.rbCPF.Location = new System.Drawing.Point(71, 185);
            this.rbCPF.Name = "rbCPF";
            this.rbCPF.Size = new System.Drawing.Size(45, 17);
            this.rbCPF.TabIndex = 23;
            this.rbCPF.TabStop = true;
            this.rbCPF.Text = "CPF";
            this.rbCPF.UseVisualStyleBackColor = true;
            this.rbCPF.MouseClick += new System.Windows.Forms.MouseEventHandler(this.rbCPF_MouseClick);
            // 
            // maskBuscaCpf
            // 
            this.maskBuscaCpf.Location = new System.Drawing.Point(9, 114);
            this.maskBuscaCpf.Mask = "000.000.000-00";
            this.maskBuscaCpf.Name = "maskBuscaCpf";
            this.maskBuscaCpf.Size = new System.Drawing.Size(129, 20);
            this.maskBuscaCpf.TabIndex = 21;
            // 
            // rbNome
            // 
            this.rbNome.AutoSize = true;
            this.rbNome.Location = new System.Drawing.Point(71, 150);
            this.rbNome.Name = "rbNome";
            this.rbNome.Size = new System.Drawing.Size(53, 17);
            this.rbNome.TabIndex = 22;
            this.rbNome.TabStop = true;
            this.rbNome.Text = "Nome";
            this.rbNome.UseVisualStyleBackColor = true;
            this.rbNome.MouseClick += new System.Windows.Forms.MouseEventHandler(this.rbNome_MouseClick);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 98);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(30, 13);
            this.label13.TabIndex = 21;
            this.label13.Text = "CPF:";
            // 
            // txtBuscaCodigo
            // 
            this.txtBuscaCodigo.Location = new System.Drawing.Point(9, 35);
            this.txtBuscaCodigo.Name = "txtBuscaCodigo";
            this.txtBuscaCodigo.Size = new System.Drawing.Size(48, 20);
            this.txtBuscaCodigo.TabIndex = 21;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 19);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(43, 13);
            this.label12.TabIndex = 21;
            this.label12.Text = "Código:";
            // 
            // txtBuscaNome
            // 
            this.txtBuscaNome.Location = new System.Drawing.Point(9, 75);
            this.txtBuscaNome.Name = "txtBuscaNome";
            this.txtBuscaNome.Size = new System.Drawing.Size(173, 20);
            this.txtBuscaNome.TabIndex = 21;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 59);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "Nome:";
            // 
            // maskCelular
            // 
            this.maskCelular.Location = new System.Drawing.Point(517, 150);
            this.maskCelular.Mask = "(00) 0000-0000";
            this.maskCelular.Name = "maskCelular";
            this.maskCelular.Size = new System.Drawing.Size(95, 20);
            this.maskCelular.TabIndex = 11;
            // 
            // maskTelefone
            // 
            this.maskTelefone.Location = new System.Drawing.Point(407, 150);
            this.maskTelefone.Mask = "(00) 0000-0000";
            this.maskTelefone.Name = "maskTelefone";
            this.maskTelefone.Size = new System.Drawing.Size(95, 20);
            this.maskTelefone.TabIndex = 10;
            // 
            // txtComplemento
            // 
            this.txtComplemento.Location = new System.Drawing.Point(15, 150);
            this.txtComplemento.Name = "txtComplemento";
            this.txtComplemento.Size = new System.Drawing.Size(120, 20);
            this.txtComplemento.TabIndex = 7;
            // 
            // txtBairro
            // 
            this.txtBairro.Location = new System.Drawing.Point(484, 93);
            this.txtBairro.Name = "txtBairro";
            this.txtBairro.Size = new System.Drawing.Size(78, 20);
            this.txtBairro.TabIndex = 6;
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(424, 93);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(43, 20);
            this.txtNumero.TabIndex = 5;
            // 
            // txtLogradouro
            // 
            this.txtLogradouro.Location = new System.Drawing.Point(15, 93);
            this.txtLogradouro.Name = "txtLogradouro";
            this.txtLogradouro.Size = new System.Drawing.Size(384, 20);
            this.txtLogradouro.TabIndex = 4;
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(73, 34);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(384, 20);
            this.txtNome.TabIndex = 2;
            // 
            // maskCEP
            // 
            this.maskCEP.Location = new System.Drawing.Point(293, 150);
            this.maskCEP.Mask = "00000-9999";
            this.maskCEP.Name = "maskCEP";
            this.maskCEP.Size = new System.Drawing.Size(95, 20);
            this.maskCEP.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(514, 134);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 13);
            this.label10.TabIndex = 90;
            this.label10.Text = "Celular:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(404, 134);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 13);
            this.label9.TabIndex = 89;
            this.label9.Text = "Telefone:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(484, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 13);
            this.label8.TabIndex = 88;
            this.label8.Text = "CPF:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 134);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 13);
            this.label7.TabIndex = 87;
            this.label7.Text = "Complemento:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(290, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 86;
            this.label6.Text = "CEP:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(481, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 85;
            this.label5.Text = "Bairro:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(420, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 84;
            this.label4.Text = "Número:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 83;
            this.label3.Text = "Logradouro:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(70, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 82;
            this.label2.Text = "Nome:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvHospede);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 253);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(846, 255);
            this.panel2.TabIndex = 1;
            // 
            // dgvHospede
            // 
            this.dgvHospede.AllowUserToAddRows = false;
            this.dgvHospede.AllowUserToDeleteRows = false;
            this.dgvHospede.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHospede.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.hospCodigo,
            this.Nome,
            this.Cpf,
            this.Telefone,
            this.Celular,
            this.Logradouro,
            this.Numero,
            this.Bairro,
            this.Cep,
            this.Complemento,
            this.cidadeCodigo});
            this.dgvHospede.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHospede.Location = new System.Drawing.Point(0, 0);
            this.dgvHospede.Name = "dgvHospede";
            this.dgvHospede.ReadOnly = true;
            this.dgvHospede.Size = new System.Drawing.Size(846, 255);
            this.dgvHospede.TabIndex = 55;
            this.dgvHospede.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvHospede_MouseClick);
            // 
            // hospCodigo
            // 
            this.hospCodigo.DataPropertyName = "hospCodigo";
            this.hospCodigo.HeaderText = "ID";
            this.hospCodigo.Name = "hospCodigo";
            this.hospCodigo.ReadOnly = true;
            this.hospCodigo.Width = 30;
            // 
            // Nome
            // 
            this.Nome.DataPropertyName = "hospNome";
            this.Nome.HeaderText = "Nome";
            this.Nome.Name = "Nome";
            this.Nome.ReadOnly = true;
            this.Nome.Width = 110;
            // 
            // Cpf
            // 
            this.Cpf.DataPropertyName = "hospCpf";
            this.Cpf.HeaderText = "CPF";
            this.Cpf.Name = "Cpf";
            this.Cpf.ReadOnly = true;
            this.Cpf.Width = 80;
            // 
            // Telefone
            // 
            this.Telefone.DataPropertyName = "hospTelefone";
            this.Telefone.HeaderText = "Telefone";
            this.Telefone.Name = "Telefone";
            this.Telefone.ReadOnly = true;
            this.Telefone.Width = 70;
            // 
            // Celular
            // 
            this.Celular.DataPropertyName = "hospCelular";
            this.Celular.HeaderText = "Celular";
            this.Celular.Name = "Celular";
            this.Celular.ReadOnly = true;
            this.Celular.Width = 70;
            // 
            // Logradouro
            // 
            this.Logradouro.DataPropertyName = "hospLogradouro";
            this.Logradouro.HeaderText = "Logradouro";
            this.Logradouro.Name = "Logradouro";
            this.Logradouro.ReadOnly = true;
            // 
            // Numero
            // 
            this.Numero.DataPropertyName = "hospNumero";
            this.Numero.HeaderText = "Número";
            this.Numero.Name = "Numero";
            this.Numero.ReadOnly = true;
            this.Numero.Width = 70;
            // 
            // Bairro
            // 
            this.Bairro.DataPropertyName = "hospBairro";
            this.Bairro.HeaderText = "Bairro";
            this.Bairro.Name = "Bairro";
            this.Bairro.ReadOnly = true;
            this.Bairro.Width = 65;
            // 
            // Cep
            // 
            this.Cep.DataPropertyName = "hospCep";
            this.Cep.HeaderText = "CEP";
            this.Cep.Name = "Cep";
            this.Cep.ReadOnly = true;
            this.Cep.Width = 70;
            // 
            // Complemento
            // 
            this.Complemento.DataPropertyName = "hospComplemento";
            this.Complemento.HeaderText = "Complemento";
            this.Complemento.Name = "Complemento";
            this.Complemento.ReadOnly = true;
            this.Complemento.Width = 75;
            // 
            // cidadeCodigo
            // 
            this.cidadeCodigo.DataPropertyName = "cidadeCodigo";
            this.cidadeCodigo.HeaderText = "Cidade";
            this.cidadeCodigo.Name = "cidadeCodigo";
            this.cidadeCodigo.ReadOnly = true;
            this.cidadeCodigo.Width = 70;
            // 
            // frmHospedes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 508);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "frmHospedes";
            this.Text = "Cadastro de Hóspedes";
            this.Load += new System.EventHandler(this.frmHospedes_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gbBuscaHospedes.ResumeLayout(false);
            this.gbBuscaHospedes.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHospede)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btn_alterar;
        private System.Windows.Forms.GroupBox gbBuscaHospedes;
        private System.Windows.Forms.RadioButton rbTodos;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.RadioButton rbCodigo;
        private System.Windows.Forms.RadioButton rbCPF;
        private System.Windows.Forms.MaskedTextBox maskBuscaCpf;
        private System.Windows.Forms.RadioButton rbNome;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtBuscaCodigo;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtBuscaNome;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.MaskedTextBox maskCelular;
        private System.Windows.Forms.MaskedTextBox maskTelefone;
        private System.Windows.Forms.TextBox txtComplemento;
        private System.Windows.Forms.TextBox txtBairro;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.TextBox txtLogradouro;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.MaskedTextBox maskCEP;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cbCidade;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox maskCPF;
        private System.Windows.Forms.DataGridView dgvHospede;
        private System.Windows.Forms.DataGridViewTextBoxColumn hospCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cpf;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefone;
        private System.Windows.Forms.DataGridViewTextBoxColumn Celular;
        private System.Windows.Forms.DataGridViewTextBoxColumn Logradouro;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bairro;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cep;
        private System.Windows.Forms.DataGridViewTextBoxColumn Complemento;
        private System.Windows.Forms.DataGridViewTextBoxColumn cidadeCodigo;
    }
}