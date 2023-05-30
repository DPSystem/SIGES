
namespace entrega_cupones.Formularios
{
  partial class frm_DDP
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
      this.btn_GenerarCupon = new System.Windows.Forms.Button();
      this.btn_Salir = new System.Windows.Forms.Button();
      this.btn_Reimprimir = new System.Windows.Forms.Button();
      this.label23 = new System.Windows.Forms.Label();
      this.txt_Empresa = new System.Windows.Forms.TextBox();
      this.txt_Dni = new System.Windows.Forms.TextBox();
      this.txt_Nombre = new System.Windows.Forms.TextBox();
      this.txt_NroSocio = new System.Windows.Forms.TextBox();
      this.lbl_Dni = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.lbl_NroSocio = new System.Windows.Forms.Label();
      this.lbl_Nombre = new System.Windows.Forms.Label();
      this.picbox_socio = new System.Windows.Forms.PictureBox();
      this.panel2 = new System.Windows.Forms.Panel();
      this.txt_TotalNOSocios = new System.Windows.Forms.TextBox();
      this.label9 = new System.Windows.Forms.Label();
      this.txt_TotalSocios = new System.Windows.Forms.TextBox();
      this.label8 = new System.Windows.Forms.Label();
      this.txt_TotalCupones = new System.Windows.Forms.TextBox();
      this.label7 = new System.Windows.Forms.Label();
      this.dgv_CuponesEmitidos = new System.Windows.Forms.DataGridView();
      this.NroCupon = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.FechaEntrega = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.label4 = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.picbox_socio)).BeginInit();
      this.panel2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgv_CuponesEmitidos)).BeginInit();
      this.SuspendLayout();
      // 
      // btn_GenerarCupon
      // 
      this.btn_GenerarCupon.Cursor = System.Windows.Forms.Cursors.Hand;
      this.btn_GenerarCupon.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(151)))), ((int)(((byte)(119)))));
      this.btn_GenerarCupon.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DodgerBlue;
      this.btn_GenerarCupon.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(151)))), ((int)(((byte)(119)))));
      this.btn_GenerarCupon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btn_GenerarCupon.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btn_GenerarCupon.ForeColor = System.Drawing.Color.Gainsboro;
      this.btn_GenerarCupon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btn_GenerarCupon.Location = new System.Drawing.Point(388, 179);
      this.btn_GenerarCupon.Name = "btn_GenerarCupon";
      this.btn_GenerarCupon.Size = new System.Drawing.Size(147, 56);
      this.btn_GenerarCupon.TabIndex = 645;
      this.btn_GenerarCupon.Text = "Emitir Cupon";
      this.btn_GenerarCupon.UseVisualStyleBackColor = true;
      this.btn_GenerarCupon.Click += new System.EventHandler(this.btn_GenerarCupon_Click);
      // 
      // btn_Salir
      // 
      this.btn_Salir.Cursor = System.Windows.Forms.Cursors.Hand;
      this.btn_Salir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(151)))), ((int)(((byte)(119)))));
      this.btn_Salir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DodgerBlue;
      this.btn_Salir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(151)))), ((int)(((byte)(119)))));
      this.btn_Salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btn_Salir.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btn_Salir.ForeColor = System.Drawing.Color.Gainsboro;
      this.btn_Salir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btn_Salir.Location = new System.Drawing.Point(547, 179);
      this.btn_Salir.Name = "btn_Salir";
      this.btn_Salir.Size = new System.Drawing.Size(147, 56);
      this.btn_Salir.TabIndex = 644;
      this.btn_Salir.Text = "Salir";
      this.btn_Salir.UseVisualStyleBackColor = true;
      this.btn_Salir.Click += new System.EventHandler(this.btn_Salir_Click);
      // 
      // btn_Reimprimir
      // 
      this.btn_Reimprimir.Cursor = System.Windows.Forms.Cursors.Hand;
      this.btn_Reimprimir.Enabled = false;
      this.btn_Reimprimir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(151)))), ((int)(((byte)(119)))));
      this.btn_Reimprimir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DodgerBlue;
      this.btn_Reimprimir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(151)))), ((int)(((byte)(119)))));
      this.btn_Reimprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btn_Reimprimir.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btn_Reimprimir.ForeColor = System.Drawing.Color.Gainsboro;
      this.btn_Reimprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btn_Reimprimir.Location = new System.Drawing.Point(229, 179);
      this.btn_Reimprimir.Name = "btn_Reimprimir";
      this.btn_Reimprimir.Size = new System.Drawing.Size(147, 56);
      this.btn_Reimprimir.TabIndex = 643;
      this.btn_Reimprimir.Text = "Reimprimir";
      this.btn_Reimprimir.UseVisualStyleBackColor = true;
      this.btn_Reimprimir.Click += new System.EventHandler(this.btn_Reimprimir_Click);
      // 
      // label23
      // 
      this.label23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(151)))), ((int)(((byte)(119)))));
      this.label23.Dock = System.Windows.Forms.DockStyle.Top;
      this.label23.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold);
      this.label23.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
      this.label23.Location = new System.Drawing.Point(0, 0);
      this.label23.Name = "label23";
      this.label23.Size = new System.Drawing.Size(703, 23);
      this.label23.TabIndex = 642;
      this.label23.Text = "DATOS DEL PADRE";
      this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // txt_Empresa
      // 
      this.txt_Empresa.BackColor = System.Drawing.Color.White;
      this.txt_Empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txt_Empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txt_Empresa.Location = new System.Drawing.Point(308, 140);
      this.txt_Empresa.Name = "txt_Empresa";
      this.txt_Empresa.ReadOnly = true;
      this.txt_Empresa.Size = new System.Drawing.Size(386, 22);
      this.txt_Empresa.TabIndex = 641;
      // 
      // txt_Dni
      // 
      this.txt_Dni.BackColor = System.Drawing.Color.White;
      this.txt_Dni.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txt_Dni.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txt_Dni.Location = new System.Drawing.Point(308, 107);
      this.txt_Dni.Name = "txt_Dni";
      this.txt_Dni.ReadOnly = true;
      this.txt_Dni.Size = new System.Drawing.Size(189, 22);
      this.txt_Dni.TabIndex = 640;
      // 
      // txt_Nombre
      // 
      this.txt_Nombre.BackColor = System.Drawing.Color.White;
      this.txt_Nombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txt_Nombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txt_Nombre.Location = new System.Drawing.Point(308, 74);
      this.txt_Nombre.Name = "txt_Nombre";
      this.txt_Nombre.ReadOnly = true;
      this.txt_Nombre.Size = new System.Drawing.Size(386, 22);
      this.txt_Nombre.TabIndex = 639;
      // 
      // txt_NroSocio
      // 
      this.txt_NroSocio.BackColor = System.Drawing.Color.White;
      this.txt_NroSocio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txt_NroSocio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txt_NroSocio.Location = new System.Drawing.Point(308, 41);
      this.txt_NroSocio.Name = "txt_NroSocio";
      this.txt_NroSocio.ReadOnly = true;
      this.txt_NroSocio.Size = new System.Drawing.Size(189, 22);
      this.txt_NroSocio.TabIndex = 638;
      // 
      // lbl_Dni
      // 
      this.lbl_Dni.AutoSize = true;
      this.lbl_Dni.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lbl_Dni.ForeColor = System.Drawing.Color.Gainsboro;
      this.lbl_Dni.Location = new System.Drawing.Point(225, 109);
      this.lbl_Dni.Name = "lbl_Dni";
      this.lbl_Dni.Size = new System.Drawing.Size(52, 19);
      this.lbl_Dni.TabIndex = 637;
      this.lbl_Dni.Text = "D.N.I.:";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.ForeColor = System.Drawing.Color.Gainsboro;
      this.label2.Location = new System.Drawing.Point(225, 76);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(77, 19);
      this.label2.TabIndex = 636;
      this.label2.Text = "Nombre:";
      // 
      // lbl_NroSocio
      // 
      this.lbl_NroSocio.AutoSize = true;
      this.lbl_NroSocio.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lbl_NroSocio.ForeColor = System.Drawing.Color.Gainsboro;
      this.lbl_NroSocio.Location = new System.Drawing.Point(225, 43);
      this.lbl_NroSocio.Name = "lbl_NroSocio";
      this.lbl_NroSocio.Size = new System.Drawing.Size(77, 19);
      this.lbl_NroSocio.TabIndex = 635;
      this.lbl_NroSocio.Text = "Nº Socio:";
      // 
      // lbl_Nombre
      // 
      this.lbl_Nombre.AutoSize = true;
      this.lbl_Nombre.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lbl_Nombre.ForeColor = System.Drawing.Color.Gainsboro;
      this.lbl_Nombre.Location = new System.Drawing.Point(225, 142);
      this.lbl_Nombre.Name = "lbl_Nombre";
      this.lbl_Nombre.Size = new System.Drawing.Size(80, 19);
      this.lbl_Nombre.TabIndex = 634;
      this.lbl_Nombre.Text = "Empresa:";
      // 
      // picbox_socio
      // 
      this.picbox_socio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.picbox_socio.Location = new System.Drawing.Point(12, 35);
      this.picbox_socio.Name = "picbox_socio";
      this.picbox_socio.Size = new System.Drawing.Size(200, 200);
      this.picbox_socio.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.picbox_socio.TabIndex = 633;
      this.picbox_socio.TabStop = false;
      // 
      // panel2
      // 
      this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
      this.panel2.Controls.Add(this.txt_TotalNOSocios);
      this.panel2.Controls.Add(this.label9);
      this.panel2.Controls.Add(this.txt_TotalSocios);
      this.panel2.Controls.Add(this.label8);
      this.panel2.Controls.Add(this.txt_TotalCupones);
      this.panel2.Controls.Add(this.label7);
      this.panel2.Controls.Add(this.dgv_CuponesEmitidos);
      this.panel2.Controls.Add(this.label4);
      this.panel2.Location = new System.Drawing.Point(12, 252);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(682, 277);
      this.panel2.TabIndex = 646;
      // 
      // txt_TotalNOSocios
      // 
      this.txt_TotalNOSocios.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txt_TotalNOSocios.Location = new System.Drawing.Point(575, 31);
      this.txt_TotalNOSocios.Name = "txt_TotalNOSocios";
      this.txt_TotalNOSocios.Size = new System.Drawing.Size(70, 24);
      this.txt_TotalNOSocios.TabIndex = 646;
      this.txt_TotalNOSocios.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Font = new System.Drawing.Font("Century Gothic", 10F);
      this.label9.ForeColor = System.Drawing.Color.Gainsboro;
      this.label9.Location = new System.Drawing.Point(488, 34);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(81, 19);
      this.label9.TabIndex = 645;
      this.label9.Text = "NO Socios:";
      // 
      // txt_TotalSocios
      // 
      this.txt_TotalSocios.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txt_TotalSocios.Location = new System.Drawing.Point(334, 31);
      this.txt_TotalSocios.Name = "txt_TotalSocios";
      this.txt_TotalSocios.Size = new System.Drawing.Size(70, 24);
      this.txt_TotalSocios.TabIndex = 644;
      this.txt_TotalSocios.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Font = new System.Drawing.Font("Century Gothic", 10F);
      this.label8.ForeColor = System.Drawing.Color.Gainsboro;
      this.label8.Location = new System.Drawing.Point(273, 34);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(55, 19);
      this.label8.TabIndex = 643;
      this.label8.Text = "Socios:";
      // 
      // txt_TotalCupones
      // 
      this.txt_TotalCupones.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txt_TotalCupones.Location = new System.Drawing.Point(121, 31);
      this.txt_TotalCupones.Name = "txt_TotalCupones";
      this.txt_TotalCupones.Size = new System.Drawing.Size(66, 24);
      this.txt_TotalCupones.TabIndex = 647;
      this.txt_TotalCupones.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Font = new System.Drawing.Font("Century Gothic", 10F);
      this.label7.ForeColor = System.Drawing.Color.Gainsboro;
      this.label7.Location = new System.Drawing.Point(10, 34);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(111, 19);
      this.label7.TabIndex = 641;
      this.label7.Text = "Total Cupones:";
      // 
      // dgv_CuponesEmitidos
      // 
      this.dgv_CuponesEmitidos.AllowUserToAddRows = false;
      this.dgv_CuponesEmitidos.AllowUserToDeleteRows = false;
      this.dgv_CuponesEmitidos.AllowUserToResizeColumns = false;
      this.dgv_CuponesEmitidos.AllowUserToResizeRows = false;
      dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.dgv_CuponesEmitidos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
      dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.dgv_CuponesEmitidos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
      this.dgv_CuponesEmitidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgv_CuponesEmitidos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NroCupon,
            this.Nombre,
            this.FechaEntrega});
      this.dgv_CuponesEmitidos.Location = new System.Drawing.Point(6, 67);
      this.dgv_CuponesEmitidos.Name = "dgv_CuponesEmitidos";
      this.dgv_CuponesEmitidos.ReadOnly = true;
      this.dgv_CuponesEmitidos.RowHeadersVisible = false;
      this.dgv_CuponesEmitidos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.dgv_CuponesEmitidos.Size = new System.Drawing.Size(673, 207);
      this.dgv_CuponesEmitidos.TabIndex = 575;
      // 
      // NroCupon
      // 
      this.NroCupon.DataPropertyName = "NroCupon";
      dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 9F);
      this.NroCupon.DefaultCellStyle = dataGridViewCellStyle3;
      this.NroCupon.HeaderText = "Cupon";
      this.NroCupon.Name = "NroCupon";
      this.NroCupon.ReadOnly = true;
      this.NroCupon.Width = 85;
      // 
      // Nombre
      // 
      this.Nombre.DataPropertyName = "Socio";
      dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Nombre.DefaultCellStyle = dataGridViewCellStyle4;
      this.Nombre.HeaderText = "Socio";
      this.Nombre.Name = "Nombre";
      this.Nombre.ReadOnly = true;
      this.Nombre.Width = 400;
      // 
      // FechaEntrega
      // 
      this.FechaEntrega.DataPropertyName = "FechaEntrega";
      dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle5.Font = new System.Drawing.Font("Century Gothic", 9F);
      this.FechaEntrega.DefaultCellStyle = dataGridViewCellStyle5;
      this.FechaEntrega.HeaderText = "Fecha";
      this.FechaEntrega.Name = "FechaEntrega";
      this.FechaEntrega.ReadOnly = true;
      this.FechaEntrega.Width = 160;
      // 
      // label4
      // 
      this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(151)))), ((int)(((byte)(119)))));
      this.label4.Dock = System.Windows.Forms.DockStyle.Top;
      this.label4.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label4.ForeColor = System.Drawing.Color.Black;
      this.label4.Location = new System.Drawing.Point(0, 0);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(682, 19);
      this.label4.TabIndex = 574;
      this.label4.Text = "Cupones Emitidos";
      this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // frm_DDP
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
      this.ClientSize = new System.Drawing.Size(703, 532);
      this.Controls.Add(this.panel2);
      this.Controls.Add(this.btn_GenerarCupon);
      this.Controls.Add(this.btn_Salir);
      this.Controls.Add(this.btn_Reimprimir);
      this.Controls.Add(this.label23);
      this.Controls.Add(this.txt_Empresa);
      this.Controls.Add(this.txt_Dni);
      this.Controls.Add(this.txt_Nombre);
      this.Controls.Add(this.txt_NroSocio);
      this.Controls.Add(this.lbl_Dni);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.lbl_NroSocio);
      this.Controls.Add(this.lbl_Nombre);
      this.Controls.Add(this.picbox_socio);
      this.Name = "frm_DDP";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Dia del Padre";
      this.Load += new System.EventHandler(this.frm_DDP_Load);
      ((System.ComponentModel.ISupportInitialize)(this.picbox_socio)).EndInit();
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgv_CuponesEmitidos)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btn_GenerarCupon;
    private System.Windows.Forms.Button btn_Salir;
    private System.Windows.Forms.Button btn_Reimprimir;
    private System.Windows.Forms.Label label23;
    public System.Windows.Forms.TextBox txt_Empresa;
    public System.Windows.Forms.TextBox txt_Dni;
    public System.Windows.Forms.TextBox txt_Nombre;
    public System.Windows.Forms.TextBox txt_NroSocio;
    private System.Windows.Forms.Label lbl_Dni;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label lbl_NroSocio;
    private System.Windows.Forms.Label lbl_Nombre;
    public System.Windows.Forms.PictureBox picbox_socio;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.TextBox txt_TotalNOSocios;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.TextBox txt_TotalSocios;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.TextBox txt_TotalCupones;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.DataGridView dgv_CuponesEmitidos;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.DataGridViewTextBoxColumn NroCupon;
    private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
    private System.Windows.Forms.DataGridViewTextBoxColumn FechaEntrega;
  }
}