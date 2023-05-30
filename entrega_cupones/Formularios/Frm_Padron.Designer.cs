namespace entrega_cupones.Formularios
{
  partial class Frm_Padron
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
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
      this.Dgv_Padron = new System.Windows.Forms.DataGridView();
      this.NroSocio = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.ApeNom = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.CUIL = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.DNI = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Empresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.CUIT = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.DDJJ = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Sorteo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.label1 = new System.Windows.Forms.Label();
      this.Txt_TotalSocios = new System.Windows.Forms.TextBox();
      this.picbox_socio = new System.Windows.Forms.PictureBox();
      this.Btn_Guardar = new System.Windows.Forms.Button();
      this.Txt_Participan = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.Txt_NoParticipan = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.Cbx_Ordenar = new System.Windows.Forms.ComboBox();
      this.label4 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.Cbx_Sexo = new System.Windows.Forms.ComboBox();
      this.panel6 = new System.Windows.Forms.Panel();
      this.label10 = new System.Windows.Forms.Label();
      this.lbl_Parentesco = new System.Windows.Forms.Label();
      this.lbl_SinRegistrosBeneficiarios = new System.Windows.Forms.Label();
      this.panel8 = new System.Windows.Forms.Panel();
      this.bunifuCustomLabel7 = new Bunifu.Framework.UI.BunifuCustomLabel();
      this.dgv_MostrarBeneficiario = new System.Windows.Forms.DataGridView();
      this.apeynom = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.parentesco = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.codigo_fliar = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.FechaDeNacimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Edad = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.picbox_beneficiario = new System.Windows.Forms.PictureBox();
      ((System.ComponentModel.ISupportInitialize)(this.Dgv_Padron)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.picbox_socio)).BeginInit();
      this.panel6.SuspendLayout();
      this.panel8.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgv_MostrarBeneficiario)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.picbox_beneficiario)).BeginInit();
      this.SuspendLayout();
      // 
      // Dgv_Padron
      // 
      this.Dgv_Padron.AllowUserToResizeRows = false;
      dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.Dgv_Padron.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
      this.Dgv_Padron.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.Dgv_Padron.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NroSocio,
            this.ApeNom,
            this.CUIL,
            this.DNI,
            this.Empresa,
            this.CUIT,
            this.DDJJ,
            this.Sorteo});
      this.Dgv_Padron.Location = new System.Drawing.Point(12, 217);
      this.Dgv_Padron.MultiSelect = false;
      this.Dgv_Padron.Name = "Dgv_Padron";
      this.Dgv_Padron.RowHeadersVisible = false;
      this.Dgv_Padron.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.Dgv_Padron.Size = new System.Drawing.Size(1088, 368);
      this.Dgv_Padron.TabIndex = 0;
      this.Dgv_Padron.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_Padron_CellContentClick);
      this.Dgv_Padron.SelectionChanged += new System.EventHandler(this.Dgv_Padron_SelectionChanged);
      this.Dgv_Padron.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Dgv_Padron_KeyDown);
      // 
      // NroSocio
      // 
      this.NroSocio.DataPropertyName = "NroDeSocio";
      dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      this.NroSocio.DefaultCellStyle = dataGridViewCellStyle2;
      this.NroSocio.HeaderText = "N° Socio";
      this.NroSocio.Name = "NroSocio";
      this.NroSocio.ReadOnly = true;
      this.NroSocio.Width = 80;
      // 
      // ApeNom
      // 
      this.ApeNom.DataPropertyName = "ApeNom";
      this.ApeNom.HeaderText = "Nombre";
      this.ApeNom.Name = "ApeNom";
      this.ApeNom.ReadOnly = true;
      this.ApeNom.Width = 300;
      // 
      // CUIL
      // 
      this.CUIL.DataPropertyName = "CUIL";
      this.CUIL.HeaderText = "CUIL";
      this.CUIL.Name = "CUIL";
      this.CUIL.ReadOnly = true;
      this.CUIL.Visible = false;
      // 
      // DNI
      // 
      this.DNI.DataPropertyName = "NroDNI";
      dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      this.DNI.DefaultCellStyle = dataGridViewCellStyle3;
      this.DNI.HeaderText = "D.N.I.";
      this.DNI.Name = "DNI";
      this.DNI.ReadOnly = true;
      this.DNI.Width = 80;
      // 
      // Empresa
      // 
      this.Empresa.DataPropertyName = "RazonSocial";
      this.Empresa.HeaderText = "Empresa";
      this.Empresa.Name = "Empresa";
      this.Empresa.ReadOnly = true;
      this.Empresa.Width = 300;
      // 
      // CUIT
      // 
      this.CUIT.DataPropertyName = "CUIT";
      dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle4.Format = "00-00000000-0";
      dataGridViewCellStyle4.NullValue = null;
      this.CUIT.DefaultCellStyle = dataGridViewCellStyle4;
      this.CUIT.HeaderText = "CUIT";
      this.CUIT.Name = "CUIT";
      this.CUIT.ReadOnly = true;
      // 
      // DDJJ
      // 
      this.DDJJ.DataPropertyName = "LastDDJJ";
      dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle5.Format = "MM/yyyy";
      dataGridViewCellStyle5.NullValue = null;
      this.DDJJ.DefaultCellStyle = dataGridViewCellStyle5;
      this.DDJJ.HeaderText = "Ultima DDJJ";
      this.DDJJ.Name = "DDJJ";
      this.DDJJ.ReadOnly = true;
      // 
      // Sorteo
      // 
      this.Sorteo.DataPropertyName = "GrupoSanguineo";
      this.Sorteo.HeaderText = "Sorteo";
      this.Sorteo.Name = "Sorteo";
      this.Sorteo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
      this.Sorteo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(932, 594);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(74, 15);
      this.label1.TabIndex = 1;
      this.label1.Text = "Total Socios";
      // 
      // Txt_TotalSocios
      // 
      this.Txt_TotalSocios.BackColor = System.Drawing.Color.White;
      this.Txt_TotalSocios.Location = new System.Drawing.Point(1012, 591);
      this.Txt_TotalSocios.Name = "Txt_TotalSocios";
      this.Txt_TotalSocios.ReadOnly = true;
      this.Txt_TotalSocios.Size = new System.Drawing.Size(88, 20);
      this.Txt_TotalSocios.TabIndex = 2;
      this.Txt_TotalSocios.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // picbox_socio
      // 
      this.picbox_socio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.picbox_socio.Location = new System.Drawing.Point(12, 12);
      this.picbox_socio.Name = "picbox_socio";
      this.picbox_socio.Size = new System.Drawing.Size(128, 113);
      this.picbox_socio.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.picbox_socio.TabIndex = 569;
      this.picbox_socio.TabStop = false;
      // 
      // Btn_Guardar
      // 
      this.Btn_Guardar.Location = new System.Drawing.Point(343, 122);
      this.Btn_Guardar.Name = "Btn_Guardar";
      this.Btn_Guardar.Size = new System.Drawing.Size(112, 49);
      this.Btn_Guardar.TabIndex = 570;
      this.Btn_Guardar.Text = "Guardar";
      this.Btn_Guardar.UseVisualStyleBackColor = true;
      this.Btn_Guardar.Click += new System.EventHandler(this.Btn_Guardar_Click);
      // 
      // Txt_Participan
      // 
      this.Txt_Participan.BackColor = System.Drawing.Color.White;
      this.Txt_Participan.Location = new System.Drawing.Point(593, 591);
      this.Txt_Participan.Name = "Txt_Participan";
      this.Txt_Participan.ReadOnly = true;
      this.Txt_Participan.Size = new System.Drawing.Size(88, 20);
      this.Txt_Participan.TabIndex = 572;
      this.Txt_Participan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.Location = new System.Drawing.Point(718, 594);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(62, 15);
      this.label2.TabIndex = 571;
      this.label2.Text = "Participan";
      // 
      // Txt_NoParticipan
      // 
      this.Txt_NoParticipan.BackColor = System.Drawing.Color.White;
      this.Txt_NoParticipan.Location = new System.Drawing.Point(786, 591);
      this.Txt_NoParticipan.Name = "Txt_NoParticipan";
      this.Txt_NoParticipan.ReadOnly = true;
      this.Txt_NoParticipan.Size = new System.Drawing.Size(88, 20);
      this.Txt_NoParticipan.TabIndex = 574;
      this.Txt_NoParticipan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label3.Location = new System.Drawing.Point(504, 594);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(83, 15);
      this.label3.TabIndex = 573;
      this.label3.Text = "NO Participan";
      // 
      // Cbx_Ordenar
      // 
      this.Cbx_Ordenar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.Cbx_Ordenar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Cbx_Ordenar.FormattingEnabled = true;
      this.Cbx_Ordenar.Items.AddRange(new object[] {
            "Nro Socio",
            "Apellido y Nombre",
            "D.N.I.",
            "Empesa",
            "C.U.I.T",
            "ULtima DDJJ"});
      this.Cbx_Ordenar.Location = new System.Drawing.Point(272, 15);
      this.Cbx_Ordenar.Name = "Cbx_Ordenar";
      this.Cbx_Ordenar.Size = new System.Drawing.Size(220, 25);
      this.Cbx_Ordenar.TabIndex = 575;
      this.Cbx_Ordenar.SelectedIndexChanged += new System.EventHandler(this.Cbx_Ordenar_SelectedIndexChanged);
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label4.Location = new System.Drawing.Point(183, 18);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(86, 17);
      this.label4.TabIndex = 576;
      this.label4.Text = "Ordenar Por";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label5.Location = new System.Drawing.Point(232, 43);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(37, 17);
      this.label5.TabIndex = 578;
      this.label5.Text = "Sexo";
      // 
      // Cbx_Sexo
      // 
      this.Cbx_Sexo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.Cbx_Sexo.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Cbx_Sexo.FormattingEnabled = true;
      this.Cbx_Sexo.Items.AddRange(new object[] {
            "Todos",
            "Femenino",
            "Masculino"});
      this.Cbx_Sexo.Location = new System.Drawing.Point(272, 42);
      this.Cbx_Sexo.Name = "Cbx_Sexo";
      this.Cbx_Sexo.Size = new System.Drawing.Size(220, 25);
      this.Cbx_Sexo.TabIndex = 577;
      this.Cbx_Sexo.SelectedIndexChanged += new System.EventHandler(this.Cbx_Sexo_SelectedIndexChanged);
      // 
      // panel6
      // 
      this.panel6.BackColor = System.Drawing.SystemColors.Control;
      this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panel6.Controls.Add(this.label10);
      this.panel6.Controls.Add(this.lbl_Parentesco);
      this.panel6.Controls.Add(this.lbl_SinRegistrosBeneficiarios);
      this.panel6.Controls.Add(this.panel8);
      this.panel6.Controls.Add(this.dgv_MostrarBeneficiario);
      this.panel6.Controls.Add(this.picbox_beneficiario);
      this.panel6.Location = new System.Drawing.Point(520, 12);
      this.panel6.Name = "panel6";
      this.panel6.Size = new System.Drawing.Size(580, 199);
      this.panel6.TabIndex = 579;
      // 
      // label10
      // 
      this.label10.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label10.ForeColor = System.Drawing.Color.Black;
      this.label10.Location = new System.Drawing.Point(4, 139);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(124, 19);
      this.label10.TabIndex = 590;
      this.label10.Text = "Parentesco";
      this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // lbl_Parentesco
      // 
      this.lbl_Parentesco.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lbl_Parentesco.ForeColor = System.Drawing.Color.Black;
      this.lbl_Parentesco.Location = new System.Drawing.Point(3, 162);
      this.lbl_Parentesco.Name = "lbl_Parentesco";
      this.lbl_Parentesco.Size = new System.Drawing.Size(124, 19);
      this.lbl_Parentesco.TabIndex = 589;
      this.lbl_Parentesco.Text = "---";
      this.lbl_Parentesco.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // lbl_SinRegistrosBeneficiarios
      // 
      this.lbl_SinRegistrosBeneficiarios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
      this.lbl_SinRegistrosBeneficiarios.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lbl_SinRegistrosBeneficiarios.ForeColor = System.Drawing.Color.White;
      this.lbl_SinRegistrosBeneficiarios.Location = new System.Drawing.Point(208, 69);
      this.lbl_SinRegistrosBeneficiarios.Name = "lbl_SinRegistrosBeneficiarios";
      this.lbl_SinRegistrosBeneficiarios.Size = new System.Drawing.Size(302, 43);
      this.lbl_SinRegistrosBeneficiarios.TabIndex = 588;
      this.lbl_SinRegistrosBeneficiarios.Text = "Sin Beneficiarios";
      this.lbl_SinRegistrosBeneficiarios.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      this.lbl_SinRegistrosBeneficiarios.Visible = false;
      // 
      // panel8
      // 
      this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(151)))), ((int)(((byte)(119)))));
      this.panel8.Controls.Add(this.bunifuCustomLabel7);
      this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel8.Location = new System.Drawing.Point(0, 0);
      this.panel8.Name = "panel8";
      this.panel8.Size = new System.Drawing.Size(578, 23);
      this.panel8.TabIndex = 571;
      // 
      // bunifuCustomLabel7
      // 
      this.bunifuCustomLabel7.AutoSize = true;
      this.bunifuCustomLabel7.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
      this.bunifuCustomLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
      this.bunifuCustomLabel7.Location = new System.Drawing.Point(216, 1);
      this.bunifuCustomLabel7.Name = "bunifuCustomLabel7";
      this.bunifuCustomLabel7.Size = new System.Drawing.Size(95, 17);
      this.bunifuCustomLabel7.TabIndex = 2;
      this.bunifuCustomLabel7.Text = "Beneficiarios";
      // 
      // dgv_MostrarBeneficiario
      // 
      this.dgv_MostrarBeneficiario.AllowUserToAddRows = false;
      this.dgv_MostrarBeneficiario.AllowUserToDeleteRows = false;
      this.dgv_MostrarBeneficiario.AllowUserToResizeColumns = false;
      this.dgv_MostrarBeneficiario.AllowUserToResizeRows = false;
      dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.dgv_MostrarBeneficiario.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
      this.dgv_MostrarBeneficiario.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle7.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.dgv_MostrarBeneficiario.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
      this.dgv_MostrarBeneficiario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgv_MostrarBeneficiario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.apeynom,
            this.parentesco,
            this.codigo_fliar,
            this.dataGridViewTextBoxColumn1,
            this.FechaDeNacimiento,
            this.Edad});
      this.dgv_MostrarBeneficiario.Location = new System.Drawing.Point(140, 33);
      this.dgv_MostrarBeneficiario.Name = "dgv_MostrarBeneficiario";
      this.dgv_MostrarBeneficiario.ReadOnly = true;
      this.dgv_MostrarBeneficiario.RowHeadersVisible = false;
      this.dgv_MostrarBeneficiario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.dgv_MostrarBeneficiario.Size = new System.Drawing.Size(435, 155);
      this.dgv_MostrarBeneficiario.TabIndex = 78;
      this.dgv_MostrarBeneficiario.SelectionChanged += new System.EventHandler(this.dgv_MostrarBeneficiario_SelectionChanged);
      // 
      // apeynom
      // 
      this.apeynom.DataPropertyName = "Nombre";
      dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.apeynom.DefaultCellStyle = dataGridViewCellStyle8;
      this.apeynom.HeaderText = "Apellido y Nombre";
      this.apeynom.Name = "apeynom";
      this.apeynom.ReadOnly = true;
      this.apeynom.Width = 200;
      // 
      // parentesco
      // 
      this.parentesco.DataPropertyName = "Parentesco";
      this.parentesco.HeaderText = "Parentesco";
      this.parentesco.Name = "parentesco";
      this.parentesco.ReadOnly = true;
      this.parentesco.Visible = false;
      this.parentesco.Width = 120;
      // 
      // codigo_fliar
      // 
      this.codigo_fliar.DataPropertyName = "CodigoDeBenef";
      this.codigo_fliar.HeaderText = "cod fliar";
      this.codigo_fliar.Name = "codigo_fliar";
      this.codigo_fliar.ReadOnly = true;
      this.codigo_fliar.Visible = false;
      // 
      // dataGridViewTextBoxColumn1
      // 
      this.dataGridViewTextBoxColumn1.DataPropertyName = "DNI";
      dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter;
      dataGridViewCellStyle9.Format = "N0";
      dataGridViewCellStyle9.NullValue = null;
      this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle9;
      this.dataGridViewTextBoxColumn1.HeaderText = "DNI";
      this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
      this.dataGridViewTextBoxColumn1.ReadOnly = true;
      this.dataGridViewTextBoxColumn1.Width = 70;
      // 
      // FechaDeNacimiento
      // 
      this.FechaDeNacimiento.DataPropertyName = "FechaDeNacimiento";
      dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter;
      this.FechaDeNacimiento.DefaultCellStyle = dataGridViewCellStyle10;
      this.FechaDeNacimiento.HeaderText = "Fecha Nac";
      this.FechaDeNacimiento.Name = "FechaDeNacimiento";
      this.FechaDeNacimiento.ReadOnly = true;
      this.FechaDeNacimiento.Width = 90;
      // 
      // Edad
      // 
      this.Edad.DataPropertyName = "Edad";
      dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter;
      this.Edad.DefaultCellStyle = dataGridViewCellStyle11;
      this.Edad.HeaderText = "Edad";
      this.Edad.Name = "Edad";
      this.Edad.ReadOnly = true;
      this.Edad.Width = 50;
      // 
      // picbox_beneficiario
      // 
      this.picbox_beneficiario.BackColor = System.Drawing.Color.Transparent;
      this.picbox_beneficiario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.picbox_beneficiario.Location = new System.Drawing.Point(7, 38);
      this.picbox_beneficiario.Name = "picbox_beneficiario";
      this.picbox_beneficiario.Size = new System.Drawing.Size(121, 101);
      this.picbox_beneficiario.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.picbox_beneficiario.TabIndex = 76;
      this.picbox_beneficiario.TabStop = false;
      // 
      // Frm_Padron
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1107, 618);
      this.Controls.Add(this.panel6);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.Cbx_Sexo);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.Cbx_Ordenar);
      this.Controls.Add(this.Txt_NoParticipan);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.Txt_Participan);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.Btn_Guardar);
      this.Controls.Add(this.picbox_socio);
      this.Controls.Add(this.Txt_TotalSocios);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.Dgv_Padron);
      this.Name = "Frm_Padron";
      this.Text = "Frm_Padron";
      this.Load += new System.EventHandler(this.Frm_Padron_Load);
      ((System.ComponentModel.ISupportInitialize)(this.Dgv_Padron)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.picbox_socio)).EndInit();
      this.panel6.ResumeLayout(false);
      this.panel8.ResumeLayout(false);
      this.panel8.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgv_MostrarBeneficiario)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.picbox_beneficiario)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.DataGridView Dgv_Padron;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox Txt_TotalSocios;
    private System.Windows.Forms.PictureBox picbox_socio;
    private System.Windows.Forms.Button Btn_Guardar;
    private System.Windows.Forms.DataGridViewTextBoxColumn NroSocio;
    private System.Windows.Forms.DataGridViewTextBoxColumn ApeNom;
    private System.Windows.Forms.DataGridViewTextBoxColumn CUIL;
    private System.Windows.Forms.DataGridViewTextBoxColumn DNI;
    private System.Windows.Forms.DataGridViewTextBoxColumn Empresa;
    private System.Windows.Forms.DataGridViewTextBoxColumn CUIT;
    private System.Windows.Forms.DataGridViewTextBoxColumn DDJJ;
    private System.Windows.Forms.DataGridViewCheckBoxColumn Sorteo;
    private System.Windows.Forms.TextBox Txt_Participan;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox Txt_NoParticipan;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.ComboBox Cbx_Ordenar;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.ComboBox Cbx_Sexo;
    private System.Windows.Forms.Panel panel6;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.Label lbl_Parentesco;
    private System.Windows.Forms.Label lbl_SinRegistrosBeneficiarios;
    private System.Windows.Forms.Panel panel8;
    private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel7;
    private System.Windows.Forms.DataGridView dgv_MostrarBeneficiario;
    private System.Windows.Forms.DataGridViewTextBoxColumn apeynom;
    private System.Windows.Forms.DataGridViewTextBoxColumn parentesco;
    private System.Windows.Forms.DataGridViewTextBoxColumn codigo_fliar;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
    private System.Windows.Forms.DataGridViewTextBoxColumn FechaDeNacimiento;
    private System.Windows.Forms.DataGridViewTextBoxColumn Edad;
    private System.Windows.Forms.PictureBox picbox_beneficiario;
  }
}