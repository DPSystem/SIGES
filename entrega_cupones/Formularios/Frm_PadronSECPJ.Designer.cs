namespace entrega_cupones.Formularios
{
    partial class Frm_PadronSECPJ
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
      this.label5 = new System.Windows.Forms.Label();
      this.Cbx_Sexo = new System.Windows.Forms.ComboBox();
      this.label4 = new System.Windows.Forms.Label();
      this.Cbx_Ordenar = new System.Windows.Forms.ComboBox();
      this.Txt_TotalSocios = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.Dgv_Padron = new System.Windows.Forms.DataGridView();
      this.picbox_socio = new System.Windows.Forms.PictureBox();
      this.Btn_Imprimir = new System.Windows.Forms.Button();
      this.CodSeccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Seccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.CodCircuito = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Circuito = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.ApellidoyNombres = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Genero = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Tipodocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Matricula = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Fechanacimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Clase = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Domicilio = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.DescTipoPadron = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.EstadoAfiliacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.FechaAfiliacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Analfabeto = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Profesion = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Fechadomicilio = new System.Windows.Forms.DataGridViewTextBoxColumn();
      ((System.ComponentModel.ISupportInitialize)(this.Dgv_Padron)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.picbox_socio)).BeginInit();
      this.SuspendLayout();
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label5.Location = new System.Drawing.Point(232, 39);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(37, 17);
      this.label5.TabIndex = 586;
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
      this.Cbx_Sexo.Location = new System.Drawing.Point(272, 38);
      this.Cbx_Sexo.Name = "Cbx_Sexo";
      this.Cbx_Sexo.Size = new System.Drawing.Size(220, 25);
      this.Cbx_Sexo.TabIndex = 585;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label4.Location = new System.Drawing.Point(183, 14);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(86, 17);
      this.label4.TabIndex = 584;
      this.label4.Text = "Ordenar Por";
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
      this.Cbx_Ordenar.Location = new System.Drawing.Point(272, 11);
      this.Cbx_Ordenar.Name = "Cbx_Ordenar";
      this.Cbx_Ordenar.Size = new System.Drawing.Size(220, 25);
      this.Cbx_Ordenar.TabIndex = 583;
      // 
      // Txt_TotalSocios
      // 
      this.Txt_TotalSocios.BackColor = System.Drawing.Color.White;
      this.Txt_TotalSocios.Location = new System.Drawing.Point(1120, 587);
      this.Txt_TotalSocios.Name = "Txt_TotalSocios";
      this.Txt_TotalSocios.ReadOnly = true;
      this.Txt_TotalSocios.Size = new System.Drawing.Size(88, 20);
      this.Txt_TotalSocios.TabIndex = 581;
      this.Txt_TotalSocios.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(1040, 590);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(74, 15);
      this.label1.TabIndex = 580;
      this.label1.Text = "Total Socios";
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
            this.CodSeccion,
            this.Seccion,
            this.CodCircuito,
            this.Circuito,
            this.Apellido,
            this.Nombre,
            this.ApellidoyNombres,
            this.Genero,
            this.Tipodocumento,
            this.Matricula,
            this.Fechanacimiento,
            this.Clase,
            this.Domicilio,
            this.DescTipoPadron,
            this.EstadoAfiliacion,
            this.FechaAfiliacion,
            this.Analfabeto,
            this.Profesion,
            this.Fechadomicilio});
      this.Dgv_Padron.Location = new System.Drawing.Point(12, 127);
      this.Dgv_Padron.Name = "Dgv_Padron";
      this.Dgv_Padron.RowHeadersVisible = false;
      this.Dgv_Padron.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.Dgv_Padron.Size = new System.Drawing.Size(1334, 454);
      this.Dgv_Padron.TabIndex = 579;
      this.Dgv_Padron.SelectionChanged += new System.EventHandler(this.Dgv_Padron_SelectionChanged);
      // 
      // picbox_socio
      // 
      this.picbox_socio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.picbox_socio.Location = new System.Drawing.Point(12, 8);
      this.picbox_socio.Name = "picbox_socio";
      this.picbox_socio.Size = new System.Drawing.Size(128, 113);
      this.picbox_socio.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.picbox_socio.TabIndex = 582;
      this.picbox_socio.TabStop = false;
      // 
      // Btn_Imprimir
      // 
      this.Btn_Imprimir.Location = new System.Drawing.Point(585, 19);
      this.Btn_Imprimir.Name = "Btn_Imprimir";
      this.Btn_Imprimir.Size = new System.Drawing.Size(121, 44);
      this.Btn_Imprimir.TabIndex = 587;
      this.Btn_Imprimir.Text = "Imprmir";
      this.Btn_Imprimir.UseVisualStyleBackColor = true;
      this.Btn_Imprimir.Click += new System.EventHandler(this.Btn_Imprimir_Click);
      // 
      // CodSeccion
      // 
      this.CodSeccion.DataPropertyName = "CodSeccion";
      dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      this.CodSeccion.DefaultCellStyle = dataGridViewCellStyle2;
      this.CodSeccion.HeaderText = "Cod Seccion";
      this.CodSeccion.Name = "CodSeccion";
      this.CodSeccion.ReadOnly = true;
      this.CodSeccion.Width = 60;
      // 
      // Seccion
      // 
      this.Seccion.DataPropertyName = "Seccion";
      this.Seccion.HeaderText = "Seccion";
      this.Seccion.Name = "Seccion";
      this.Seccion.ReadOnly = true;
      this.Seccion.Width = 80;
      // 
      // CodCircuito
      // 
      this.CodCircuito.DataPropertyName = "CodCircuito";
      this.CodCircuito.HeaderText = "Cod Circuito";
      this.CodCircuito.Name = "CodCircuito";
      this.CodCircuito.ReadOnly = true;
      this.CodCircuito.Width = 60;
      // 
      // Circuito
      // 
      this.Circuito.DataPropertyName = "Circuito";
      dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      this.Circuito.DefaultCellStyle = dataGridViewCellStyle3;
      this.Circuito.HeaderText = "Circuito";
      this.Circuito.Name = "Circuito";
      this.Circuito.ReadOnly = true;
      this.Circuito.Width = 80;
      // 
      // Apellido
      // 
      this.Apellido.DataPropertyName = "Apellido";
      this.Apellido.HeaderText = "Apellido";
      this.Apellido.Name = "Apellido";
      this.Apellido.ReadOnly = true;
      this.Apellido.Visible = false;
      this.Apellido.Width = 300;
      // 
      // Nombre
      // 
      this.Nombre.DataPropertyName = "Nombre";
      dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle4.Format = "00-00000000-0";
      dataGridViewCellStyle4.NullValue = null;
      this.Nombre.DefaultCellStyle = dataGridViewCellStyle4;
      this.Nombre.HeaderText = "Nombre";
      this.Nombre.Name = "Nombre";
      this.Nombre.ReadOnly = true;
      this.Nombre.Visible = false;
      // 
      // ApellidoyNombres
      // 
      this.ApellidoyNombres.DataPropertyName = "ApellidoyNombres";
      dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle5.Format = "MM/yyyy";
      dataGridViewCellStyle5.NullValue = null;
      this.ApellidoyNombres.DefaultCellStyle = dataGridViewCellStyle5;
      this.ApellidoyNombres.HeaderText = "Apellido y Nombres";
      this.ApellidoyNombres.Name = "ApellidoyNombres";
      this.ApellidoyNombres.ReadOnly = true;
      this.ApellidoyNombres.Width = 150;
      // 
      // Genero
      // 
      this.Genero.DataPropertyName = "Genero";
      dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      this.Genero.DefaultCellStyle = dataGridViewCellStyle6;
      this.Genero.HeaderText = "Genero";
      this.Genero.Name = "Genero";
      this.Genero.ReadOnly = true;
      this.Genero.Width = 50;
      // 
      // Tipodocumento
      // 
      this.Tipodocumento.DataPropertyName = "Tipodocumento";
      this.Tipodocumento.HeaderText = "Tipo DNI";
      this.Tipodocumento.Name = "Tipodocumento";
      this.Tipodocumento.ReadOnly = true;
      this.Tipodocumento.Width = 70;
      // 
      // Matricula
      // 
      this.Matricula.DataPropertyName = "Matricula";
      dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      this.Matricula.DefaultCellStyle = dataGridViewCellStyle7;
      this.Matricula.HeaderText = "D.N.I.";
      this.Matricula.Name = "Matricula";
      this.Matricula.ReadOnly = true;
      this.Matricula.Width = 70;
      // 
      // Fechanacimiento
      // 
      this.Fechanacimiento.DataPropertyName = "Fechanacimiento";
      this.Fechanacimiento.HeaderText = "Fecha Nac";
      this.Fechanacimiento.Name = "Fechanacimiento";
      this.Fechanacimiento.ReadOnly = true;
      this.Fechanacimiento.Width = 70;
      // 
      // Clase
      // 
      this.Clase.DataPropertyName = "Clase";
      dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      this.Clase.DefaultCellStyle = dataGridViewCellStyle8;
      this.Clase.HeaderText = "Clase";
      this.Clase.Name = "Clase";
      this.Clase.ReadOnly = true;
      this.Clase.Width = 50;
      // 
      // Domicilio
      // 
      this.Domicilio.DataPropertyName = "Domicilio";
      this.Domicilio.HeaderText = "Domicilio";
      this.Domicilio.Name = "Domicilio";
      this.Domicilio.ReadOnly = true;
      this.Domicilio.Width = 200;
      // 
      // DescTipoPadron
      // 
      this.DescTipoPadron.DataPropertyName = "DescTipoPadron";
      this.DescTipoPadron.HeaderText = "Tipo Padron";
      this.DescTipoPadron.Name = "DescTipoPadron";
      this.DescTipoPadron.ReadOnly = true;
      // 
      // EstadoAfiliacion
      // 
      this.EstadoAfiliacion.DataPropertyName = "EstadoAfiliacion";
      this.EstadoAfiliacion.HeaderText = "Estado Afiliacion";
      this.EstadoAfiliacion.Name = "EstadoAfiliacion";
      this.EstadoAfiliacion.ReadOnly = true;
      this.EstadoAfiliacion.Width = 80;
      // 
      // FechaAfiliacion
      // 
      this.FechaAfiliacion.DataPropertyName = "FechaAfiliacion";
      this.FechaAfiliacion.HeaderText = "Fecha Afiliacion";
      this.FechaAfiliacion.Name = "FechaAfiliacion";
      this.FechaAfiliacion.ReadOnly = true;
      this.FechaAfiliacion.Width = 80;
      // 
      // Analfabeto
      // 
      this.Analfabeto.DataPropertyName = "Analfabeto";
      this.Analfabeto.HeaderText = "Analfabeto";
      this.Analfabeto.Name = "Analfabeto";
      this.Analfabeto.ReadOnly = true;
      this.Analfabeto.Width = 80;
      // 
      // Profesion
      // 
      this.Profesion.DataPropertyName = "Profesion";
      this.Profesion.HeaderText = "Profesion";
      this.Profesion.Name = "Profesion";
      this.Profesion.ReadOnly = true;
      this.Profesion.Width = 80;
      // 
      // Fechadomicilio
      // 
      this.Fechadomicilio.DataPropertyName = "Fechadomicilio";
      this.Fechadomicilio.HeaderText = "Fecha Domicilio";
      this.Fechadomicilio.Name = "Fechadomicilio";
      this.Fechadomicilio.ReadOnly = true;
      this.Fechadomicilio.Width = 80;
      // 
      // Frm_PadronSECPJ
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1347, 640);
      this.Controls.Add(this.Btn_Imprimir);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.Cbx_Sexo);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.Cbx_Ordenar);
      this.Controls.Add(this.picbox_socio);
      this.Controls.Add(this.Txt_TotalSocios);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.Dgv_Padron);
      this.Name = "Frm_PadronSECPJ";
      this.Text = "Padron del SEC en el Padron de PJ";
      this.Load += new System.EventHandler(this.Frm_PadronSECPJ_Load);
      ((System.ComponentModel.ISupportInitialize)(this.Dgv_Padron)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.picbox_socio)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox Cbx_Sexo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox Cbx_Ordenar;
        private System.Windows.Forms.PictureBox picbox_socio;
        private System.Windows.Forms.TextBox Txt_TotalSocios;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView Dgv_Padron;
        private System.Windows.Forms.Button Btn_Imprimir;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodSeccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Seccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodCircuito;
        private System.Windows.Forms.DataGridViewTextBoxColumn Circuito;
        private System.Windows.Forms.DataGridViewTextBoxColumn Apellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApellidoyNombres;
        private System.Windows.Forms.DataGridViewTextBoxColumn Genero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipodocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Matricula;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fechanacimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Clase;
        private System.Windows.Forms.DataGridViewTextBoxColumn Domicilio;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescTipoPadron;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstadoAfiliacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaAfiliacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Analfabeto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Profesion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fechadomicilio;
    }
}