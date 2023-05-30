namespace entrega_cupones.Formularios
{
    partial class Frm_BuscarSocio
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
      this.Txt_Buscar = new System.Windows.Forms.TextBox();
      this.label24 = new System.Windows.Forms.Label();
      this.PicBox_FotoSocio = new System.Windows.Forms.PictureBox();
      this.Btn_Salir = new System.Windows.Forms.Button();
      this.Dgv_Socios = new System.Windows.Forms.DataGridView();
      this.NroDNI = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.ApeNom = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.NroDeSocio = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.EsSocio = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.RazSoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.CUIL = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.btn_Confirmar = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.Txt_CantidadSocios = new System.Windows.Forms.TextBox();
      this.bunifuCustomLabel32 = new Bunifu.Framework.UI.BunifuCustomLabel();
      this.Cbx_Filtrar = new System.Windows.Forms.ComboBox();
      this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
      this.Cbx_Empresa = new System.Windows.Forms.ComboBox();
      this.Txt_Empresa = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.PicBox_FotoSocio)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.Dgv_Socios)).BeginInit();
      this.SuspendLayout();
      // 
      // Txt_Buscar
      // 
      this.Txt_Buscar.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
      this.Txt_Buscar.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
      this.Txt_Buscar.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Txt_Buscar.Location = new System.Drawing.Point(118, 28);
      this.Txt_Buscar.MaxLength = 50;
      this.Txt_Buscar.Name = "Txt_Buscar";
      this.Txt_Buscar.ShortcutsEnabled = false;
      this.Txt_Buscar.Size = new System.Drawing.Size(477, 22);
      this.Txt_Buscar.TabIndex = 395;
      this.Txt_Buscar.TextChanged += new System.EventHandler(this.txt_buscar_TextChanged);
      // 
      // label24
      // 
      this.label24.AutoSize = true;
      this.label24.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label24.ForeColor = System.Drawing.Color.Black;
      this.label24.Location = new System.Drawing.Point(118, 6);
      this.label24.Name = "label24";
      this.label24.Size = new System.Drawing.Size(318, 19);
      this.label24.TabIndex = 645;
      this.label24.Text = "Buscar por N° Socio / DNI / Apellido / Nombre";
      // 
      // PicBox_FotoSocio
      // 
      this.PicBox_FotoSocio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.PicBox_FotoSocio.Location = new System.Drawing.Point(12, 9);
      this.PicBox_FotoSocio.Name = "PicBox_FotoSocio";
      this.PicBox_FotoSocio.Size = new System.Drawing.Size(100, 100);
      this.PicBox_FotoSocio.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.PicBox_FotoSocio.TabIndex = 396;
      this.PicBox_FotoSocio.TabStop = false;
      // 
      // Btn_Salir
      // 
      this.Btn_Salir.BackColor = System.Drawing.Color.Transparent;
      this.Btn_Salir.Cursor = System.Windows.Forms.Cursors.Hand;
      this.Btn_Salir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(151)))), ((int)(((byte)(119)))));
      this.Btn_Salir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DodgerBlue;
      this.Btn_Salir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(151)))), ((int)(((byte)(119)))));
      this.Btn_Salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.Btn_Salir.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Btn_Salir.ForeColor = System.Drawing.Color.Black;
      this.Btn_Salir.Image = global::entrega_cupones.Properties.Resources.door13;
      this.Btn_Salir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.Btn_Salir.Location = new System.Drawing.Point(628, 61);
      this.Btn_Salir.Name = "Btn_Salir";
      this.Btn_Salir.Size = new System.Drawing.Size(109, 35);
      this.Btn_Salir.TabIndex = 655;
      this.Btn_Salir.Text = "Salir";
      this.Btn_Salir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.Btn_Salir.UseVisualStyleBackColor = false;
      this.Btn_Salir.Click += new System.EventHandler(this.Btn_Salir_Click);
      // 
      // Dgv_Socios
      // 
      this.Dgv_Socios.AllowUserToAddRows = false;
      this.Dgv_Socios.AllowUserToDeleteRows = false;
      this.Dgv_Socios.AllowUserToResizeColumns = false;
      this.Dgv_Socios.AllowUserToResizeRows = false;
      dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.Dgv_Socios.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
      this.Dgv_Socios.BackgroundColor = System.Drawing.Color.White;
      dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9.5F);
      dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.Dgv_Socios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
      this.Dgv_Socios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.Dgv_Socios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NroDNI,
            this.ApeNom,
            this.NroDeSocio,
            this.EsSocio,
            this.RazSoc,
            this.CUIL});
      this.Dgv_Socios.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
      this.Dgv_Socios.GridColor = System.Drawing.Color.White;
      this.Dgv_Socios.Location = new System.Drawing.Point(12, 115);
      this.Dgv_Socios.Name = "Dgv_Socios";
      this.Dgv_Socios.RowHeadersVisible = false;
      this.Dgv_Socios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.Dgv_Socios.Size = new System.Drawing.Size(726, 378);
      this.Dgv_Socios.TabIndex = 656;
      this.Dgv_Socios.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_Socios_CellContentClick);
      this.Dgv_Socios.SelectionChanged += new System.EventHandler(this.Dgv_Socios_SelectionChanged);
      // 
      // NroDNI
      // 
      this.NroDNI.DataPropertyName = "NroDNI";
      dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 9.5F);
      dataGridViewCellStyle3.NullValue = null;
      this.NroDNI.DefaultCellStyle = dataGridViewCellStyle3;
      this.NroDNI.HeaderText = "D.N.I.";
      this.NroDNI.Name = "NroDNI";
      this.NroDNI.ReadOnly = true;
      this.NroDNI.Width = 80;
      // 
      // ApeNom
      // 
      this.ApeNom.DataPropertyName = "ApeNom";
      dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 9.5F);
      this.ApeNom.DefaultCellStyle = dataGridViewCellStyle4;
      this.ApeNom.HeaderText = "Apellido y Nombre";
      this.ApeNom.Name = "ApeNom";
      this.ApeNom.ReadOnly = true;
      this.ApeNom.Width = 270;
      // 
      // NroDeSocio
      // 
      this.NroDeSocio.DataPropertyName = "NroDeSocio";
      dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle5.Font = new System.Drawing.Font("Century Gothic", 9.5F);
      dataGridViewCellStyle5.Format = "N0";
      this.NroDeSocio.DefaultCellStyle = dataGridViewCellStyle5;
      this.NroDeSocio.HeaderText = "N° Socio";
      this.NroDeSocio.Name = "NroDeSocio";
      this.NroDeSocio.ReadOnly = true;
      this.NroDeSocio.Width = 90;
      // 
      // EsSocio
      // 
      this.EsSocio.DataPropertyName = "EsSocioString";
      dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      this.EsSocio.DefaultCellStyle = dataGridViewCellStyle6;
      this.EsSocio.HeaderText = "Socio";
      this.EsSocio.Name = "EsSocio";
      this.EsSocio.ReadOnly = true;
      this.EsSocio.Width = 50;
      // 
      // RazSoc
      // 
      this.RazSoc.DataPropertyName = "RazonSocial";
      this.RazSoc.HeaderText = "Razon Social";
      this.RazSoc.Name = "RazSoc";
      this.RazSoc.ReadOnly = true;
      this.RazSoc.Visible = false;
      this.RazSoc.Width = 200;
      // 
      // CUIL
      // 
      this.CUIL.DataPropertyName = "CUIL";
      this.CUIL.HeaderText = "CUIL";
      this.CUIL.Name = "CUIL";
      this.CUIL.ReadOnly = true;
      this.CUIL.Visible = false;
      // 
      // btn_Confirmar
      // 
      this.btn_Confirmar.BackColor = System.Drawing.Color.Transparent;
      this.btn_Confirmar.Cursor = System.Windows.Forms.Cursors.Hand;
      this.btn_Confirmar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(151)))), ((int)(((byte)(119)))));
      this.btn_Confirmar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DodgerBlue;
      this.btn_Confirmar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(151)))), ((int)(((byte)(119)))));
      this.btn_Confirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btn_Confirmar.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btn_Confirmar.ForeColor = System.Drawing.Color.Black;
      this.btn_Confirmar.Image = global::entrega_cupones.Properties.Resources.check30___32;
      this.btn_Confirmar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btn_Confirmar.Location = new System.Drawing.Point(628, 20);
      this.btn_Confirmar.Name = "btn_Confirmar";
      this.btn_Confirmar.Size = new System.Drawing.Size(109, 35);
      this.btn_Confirmar.TabIndex = 657;
      this.btn_Confirmar.Text = "Confirmar";
      this.btn_Confirmar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.btn_Confirmar.UseVisualStyleBackColor = false;
      this.btn_Confirmar.Click += new System.EventHandler(this.btn_Confirmar_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.ForeColor = System.Drawing.Color.Black;
      this.label1.Location = new System.Drawing.Point(573, 499);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(51, 19);
      this.label1.TabIndex = 658;
      this.label1.Text = "Socios";
      // 
      // Txt_CantidadSocios
      // 
      this.Txt_CantidadSocios.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
      this.Txt_CantidadSocios.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
      this.Txt_CantidadSocios.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Txt_CantidadSocios.Location = new System.Drawing.Point(628, 499);
      this.Txt_CantidadSocios.MaxLength = 50;
      this.Txt_CantidadSocios.Name = "Txt_CantidadSocios";
      this.Txt_CantidadSocios.ShortcutsEnabled = false;
      this.Txt_CantidadSocios.Size = new System.Drawing.Size(110, 22);
      this.Txt_CantidadSocios.TabIndex = 659;
      this.Txt_CantidadSocios.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // bunifuCustomLabel32
      // 
      this.bunifuCustomLabel32.AutoSize = true;
      this.bunifuCustomLabel32.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.bunifuCustomLabel32.ForeColor = System.Drawing.Color.Black;
      this.bunifuCustomLabel32.Location = new System.Drawing.Point(120, 58);
      this.bunifuCustomLabel32.Name = "bunifuCustomLabel32";
      this.bunifuCustomLabel32.Size = new System.Drawing.Size(68, 17);
      this.bunifuCustomLabel32.TabIndex = 660;
      this.bunifuCustomLabel32.Text = "Filtrar por";
      // 
      // Cbx_Filtrar
      // 
      this.Cbx_Filtrar.BackColor = System.Drawing.SystemColors.Window;
      this.Cbx_Filtrar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.Cbx_Filtrar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Cbx_Filtrar.ForeColor = System.Drawing.Color.Black;
      this.Cbx_Filtrar.FormattingEnabled = true;
      this.Cbx_Filtrar.Items.AddRange(new object[] {
            "Todos",
            "Socios",
            "NO Socios"});
      this.Cbx_Filtrar.Location = new System.Drawing.Point(192, 54);
      this.Cbx_Filtrar.Name = "Cbx_Filtrar";
      this.Cbx_Filtrar.Size = new System.Drawing.Size(113, 25);
      this.Cbx_Filtrar.TabIndex = 661;
      this.Cbx_Filtrar.SelectedIndexChanged += new System.EventHandler(this.Cbx_Filtrar_SelectedIndexChanged);
      // 
      // bunifuCustomLabel1
      // 
      this.bunifuCustomLabel1.AutoSize = true;
      this.bunifuCustomLabel1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.bunifuCustomLabel1.ForeColor = System.Drawing.Color.Black;
      this.bunifuCustomLabel1.Location = new System.Drawing.Point(120, 88);
      this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
      this.bunifuCustomLabel1.Size = new System.Drawing.Size(63, 17);
      this.bunifuCustomLabel1.TabIndex = 662;
      this.bunifuCustomLabel1.Text = "Empresa";
      // 
      // Cbx_Empresa
      // 
      this.Cbx_Empresa.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
      this.Cbx_Empresa.BackColor = System.Drawing.SystemColors.Window;
      this.Cbx_Empresa.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Cbx_Empresa.ForeColor = System.Drawing.Color.Black;
      this.Cbx_Empresa.FormattingEnabled = true;
      this.Cbx_Empresa.Location = new System.Drawing.Point(192, 84);
      this.Cbx_Empresa.MaxDropDownItems = 5;
      this.Cbx_Empresa.Name = "Cbx_Empresa";
      this.Cbx_Empresa.Size = new System.Drawing.Size(403, 25);
      this.Cbx_Empresa.TabIndex = 663;
      this.Cbx_Empresa.SelectedIndexChanged += new System.EventHandler(this.Cbx_Empresa_SelectedIndexChanged);
      // 
      // Txt_Empresa
      // 
      this.Txt_Empresa.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
      this.Txt_Empresa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
      this.Txt_Empresa.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Txt_Empresa.Location = new System.Drawing.Point(82, 499);
      this.Txt_Empresa.MaxLength = 50;
      this.Txt_Empresa.Name = "Txt_Empresa";
      this.Txt_Empresa.ShortcutsEnabled = false;
      this.Txt_Empresa.Size = new System.Drawing.Size(386, 22);
      this.Txt_Empresa.TabIndex = 665;
      this.Txt_Empresa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.ForeColor = System.Drawing.Color.Black;
      this.label2.Location = new System.Drawing.Point(16, 499);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(68, 19);
      this.label2.TabIndex = 664;
      this.label2.Text = "Empresa";
      // 
      // Frm_BuscarSocio
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(744, 529);
      this.Controls.Add(this.Txt_Empresa);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.bunifuCustomLabel1);
      this.Controls.Add(this.Cbx_Empresa);
      this.Controls.Add(this.bunifuCustomLabel32);
      this.Controls.Add(this.Cbx_Filtrar);
      this.Controls.Add(this.Txt_CantidadSocios);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.btn_Confirmar);
      this.Controls.Add(this.Dgv_Socios);
      this.Controls.Add(this.Btn_Salir);
      this.Controls.Add(this.label24);
      this.Controls.Add(this.PicBox_FotoSocio);
      this.Controls.Add(this.Txt_Buscar);
      this.Name = "Frm_BuscarSocio";
      this.Text = "Buscar Socio";
      this.Load += new System.EventHandler(this.Frm_BuscarSocio_Load);
      ((System.ComponentModel.ISupportInitialize)(this.PicBox_FotoSocio)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.Dgv_Socios)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox PicBox_FotoSocio;
        public System.Windows.Forms.TextBox Txt_Buscar;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Button Btn_Salir;
        private System.Windows.Forms.DataGridView Dgv_Socios;
        private System.Windows.Forms.Button btn_Confirmar;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox Txt_CantidadSocios;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel32;
        private System.Windows.Forms.ComboBox Cbx_Filtrar;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private System.Windows.Forms.ComboBox Cbx_Empresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn NroDNI;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApeNom;
        private System.Windows.Forms.DataGridViewTextBoxColumn NroDeSocio;
        private System.Windows.Forms.DataGridViewTextBoxColumn EsSocio;
        private System.Windows.Forms.DataGridViewTextBoxColumn RazSoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn CUIL;
        public System.Windows.Forms.TextBox Txt_Empresa;
        private System.Windows.Forms.Label label2;
    }
}