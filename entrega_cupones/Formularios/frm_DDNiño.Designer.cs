
namespace entrega_cupones.Formularios
{
  partial class frm_DDNiño
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
      this.panel6 = new System.Windows.Forms.Panel();
      this.Lbl_Encabezado = new System.Windows.Forms.Label();
      this.label10 = new System.Windows.Forms.Label();
      this.lbl_Parentesco = new System.Windows.Forms.Label();
      this.Dgv_Beneficiarios = new System.Windows.Forms.DataGridView();
      this.apeynom = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.parentesco = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.codigo_fliar = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.DNI = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.FechaDeNacimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Edad = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.FechaCupon = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Cupon = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Picbox_Beneficiario = new System.Windows.Forms.PictureBox();
      this.btn_GenerarCupon = new System.Windows.Forms.Button();
      this.btn_Salir = new System.Windows.Forms.Button();
      this.btn_Reimprimir = new System.Windows.Forms.Button();
      this.Btn_Exepcion = new System.Windows.Forms.Button();
      this.panel6.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.Dgv_Beneficiarios)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.Picbox_Beneficiario)).BeginInit();
      this.SuspendLayout();
      // 
      // panel6
      // 
      this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
      this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panel6.Controls.Add(this.Lbl_Encabezado);
      this.panel6.Controls.Add(this.label10);
      this.panel6.Controls.Add(this.lbl_Parentesco);
      this.panel6.Controls.Add(this.Dgv_Beneficiarios);
      this.panel6.Controls.Add(this.Picbox_Beneficiario);
      this.panel6.Location = new System.Drawing.Point(6, 1);
      this.panel6.Name = "panel6";
      this.panel6.Size = new System.Drawing.Size(777, 200);
      this.panel6.TabIndex = 572;
      // 
      // Lbl_Encabezado
      // 
      this.Lbl_Encabezado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(151)))), ((int)(((byte)(119)))));
      this.Lbl_Encabezado.Dock = System.Windows.Forms.DockStyle.Top;
      this.Lbl_Encabezado.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Lbl_Encabezado.ForeColor = System.Drawing.Color.Black;
      this.Lbl_Encabezado.Location = new System.Drawing.Point(0, 0);
      this.Lbl_Encabezado.Name = "Lbl_Encabezado";
      this.Lbl_Encabezado.Size = new System.Drawing.Size(775, 30);
      this.Lbl_Encabezado.TabIndex = 591;
      this.Lbl_Encabezado.Text = "Grupo Familiar";
      this.Lbl_Encabezado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // label10
      // 
      this.label10.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label10.ForeColor = System.Drawing.Color.Gainsboro;
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
      this.lbl_Parentesco.ForeColor = System.Drawing.Color.Gainsboro;
      this.lbl_Parentesco.Location = new System.Drawing.Point(3, 162);
      this.lbl_Parentesco.Name = "lbl_Parentesco";
      this.lbl_Parentesco.Size = new System.Drawing.Size(124, 19);
      this.lbl_Parentesco.TabIndex = 589;
      this.lbl_Parentesco.Text = "---";
      this.lbl_Parentesco.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // Dgv_Beneficiarios
      // 
      this.Dgv_Beneficiarios.AllowUserToAddRows = false;
      this.Dgv_Beneficiarios.AllowUserToDeleteRows = false;
      this.Dgv_Beneficiarios.AllowUserToResizeColumns = false;
      this.Dgv_Beneficiarios.AllowUserToResizeRows = false;
      dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.Dgv_Beneficiarios.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
      this.Dgv_Beneficiarios.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.Dgv_Beneficiarios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
      this.Dgv_Beneficiarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.Dgv_Beneficiarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.apeynom,
            this.parentesco,
            this.codigo_fliar,
            this.DNI,
            this.FechaDeNacimiento,
            this.Edad,
            this.FechaCupon,
            this.Cupon});
      this.Dgv_Beneficiarios.Location = new System.Drawing.Point(140, 33);
      this.Dgv_Beneficiarios.Name = "Dgv_Beneficiarios";
      this.Dgv_Beneficiarios.ReadOnly = true;
      this.Dgv_Beneficiarios.RowHeadersVisible = false;
      this.Dgv_Beneficiarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.Dgv_Beneficiarios.Size = new System.Drawing.Size(626, 155);
      this.Dgv_Beneficiarios.TabIndex = 78;
      this.Dgv_Beneficiarios.SelectionChanged += new System.EventHandler(this.dgv_Beneficiarios_SelectionChanged);
      // 
      // apeynom
      // 
      this.apeynom.DataPropertyName = "ApeNom";
      dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.apeynom.DefaultCellStyle = dataGridViewCellStyle3;
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
      this.codigo_fliar.DataPropertyName = "CodigoFliar";
      this.codigo_fliar.HeaderText = "cod fliar";
      this.codigo_fliar.Name = "codigo_fliar";
      this.codigo_fliar.ReadOnly = true;
      this.codigo_fliar.Visible = false;
      // 
      // DNI
      // 
      this.DNI.DataPropertyName = "DNI";
      dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter;
      dataGridViewCellStyle4.Format = "N0";
      dataGridViewCellStyle4.NullValue = null;
      this.DNI.DefaultCellStyle = dataGridViewCellStyle4;
      this.DNI.HeaderText = "DNI";
      this.DNI.Name = "DNI";
      this.DNI.ReadOnly = true;
      this.DNI.Width = 70;
      // 
      // FechaDeNacimiento
      // 
      this.FechaDeNacimiento.DataPropertyName = "FechaNac";
      dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter;
      this.FechaDeNacimiento.DefaultCellStyle = dataGridViewCellStyle5;
      this.FechaDeNacimiento.HeaderText = "Fecha Nac";
      this.FechaDeNacimiento.Name = "FechaDeNacimiento";
      this.FechaDeNacimiento.ReadOnly = true;
      this.FechaDeNacimiento.Width = 90;
      // 
      // Edad
      // 
      this.Edad.DataPropertyName = "Edad";
      dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter;
      this.Edad.DefaultCellStyle = dataGridViewCellStyle6;
      this.Edad.HeaderText = "Edad";
      this.Edad.Name = "Edad";
      this.Edad.ReadOnly = true;
      this.Edad.Width = 50;
      // 
      // FechaCupon
      // 
      this.FechaCupon.DataPropertyName = "FechaGeneracionDeCupon";
      dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      this.FechaCupon.DefaultCellStyle = dataGridViewCellStyle7;
      this.FechaCupon.HeaderText = "Fecha Cupon";
      this.FechaCupon.Name = "FechaCupon";
      this.FechaCupon.ReadOnly = true;
      this.FechaCupon.Width = 110;
      // 
      // Cupon
      // 
      this.Cupon.DataPropertyName = "NroCupon";
      dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      this.Cupon.DefaultCellStyle = dataGridViewCellStyle8;
      this.Cupon.HeaderText = "Cupon";
      this.Cupon.Name = "Cupon";
      this.Cupon.ReadOnly = true;
      this.Cupon.Width = 80;
      // 
      // Picbox_Beneficiario
      // 
      this.Picbox_Beneficiario.BackColor = System.Drawing.Color.Transparent;
      this.Picbox_Beneficiario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.Picbox_Beneficiario.Location = new System.Drawing.Point(7, 38);
      this.Picbox_Beneficiario.Name = "Picbox_Beneficiario";
      this.Picbox_Beneficiario.Size = new System.Drawing.Size(121, 101);
      this.Picbox_Beneficiario.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.Picbox_Beneficiario.TabIndex = 76;
      this.Picbox_Beneficiario.TabStop = false;
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
      this.btn_GenerarCupon.Location = new System.Drawing.Point(469, 221);
      this.btn_GenerarCupon.Name = "btn_GenerarCupon";
      this.btn_GenerarCupon.Size = new System.Drawing.Size(147, 56);
      this.btn_GenerarCupon.TabIndex = 648;
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
      this.btn_Salir.Location = new System.Drawing.Point(628, 221);
      this.btn_Salir.Name = "btn_Salir";
      this.btn_Salir.Size = new System.Drawing.Size(147, 56);
      this.btn_Salir.TabIndex = 647;
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
      this.btn_Reimprimir.Location = new System.Drawing.Point(310, 221);
      this.btn_Reimprimir.Name = "btn_Reimprimir";
      this.btn_Reimprimir.Size = new System.Drawing.Size(147, 56);
      this.btn_Reimprimir.TabIndex = 646;
      this.btn_Reimprimir.Text = "Reimprimir";
      this.btn_Reimprimir.UseVisualStyleBackColor = true;
      this.btn_Reimprimir.Click += new System.EventHandler(this.btn_Reimprimir_Click);
      // 
      // Btn_Exepcion
      // 
      this.Btn_Exepcion.Cursor = System.Windows.Forms.Cursors.Hand;
      this.Btn_Exepcion.Enabled = false;
      this.Btn_Exepcion.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(151)))), ((int)(((byte)(119)))));
      this.Btn_Exepcion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DodgerBlue;
      this.Btn_Exepcion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(151)))), ((int)(((byte)(119)))));
      this.Btn_Exepcion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.Btn_Exepcion.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Btn_Exepcion.ForeColor = System.Drawing.Color.Gainsboro;
      this.Btn_Exepcion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.Btn_Exepcion.Location = new System.Drawing.Point(147, 221);
      this.Btn_Exepcion.Name = "Btn_Exepcion";
      this.Btn_Exepcion.Size = new System.Drawing.Size(147, 56);
      this.Btn_Exepcion.TabIndex = 649;
      this.Btn_Exepcion.Text = "Exepcion";
      this.Btn_Exepcion.UseVisualStyleBackColor = true;
      this.Btn_Exepcion.Click += new System.EventHandler(this.Btn_Exepcion_Click);
      // 
      // frm_DDNiño
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
      this.ClientSize = new System.Drawing.Size(787, 289);
      this.Controls.Add(this.Btn_Exepcion);
      this.Controls.Add(this.btn_GenerarCupon);
      this.Controls.Add(this.btn_Salir);
      this.Controls.Add(this.btn_Reimprimir);
      this.Controls.Add(this.panel6);
      this.Name = "frm_DDNiño";
      this.Text = "Dia del Niño ";
      this.Load += new System.EventHandler(this.frm_DDNiño_Load);
      this.panel6.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.Dgv_Beneficiarios)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.Picbox_Beneficiario)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel panel6;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.Label lbl_Parentesco;
    private System.Windows.Forms.DataGridView Dgv_Beneficiarios;
    private System.Windows.Forms.PictureBox Picbox_Beneficiario;
    private System.Windows.Forms.DataGridViewTextBoxColumn apeynom;
    private System.Windows.Forms.DataGridViewTextBoxColumn parentesco;
    private System.Windows.Forms.DataGridViewTextBoxColumn codigo_fliar;
    private System.Windows.Forms.DataGridViewTextBoxColumn DNI;
    private System.Windows.Forms.DataGridViewTextBoxColumn FechaDeNacimiento;
    private System.Windows.Forms.DataGridViewTextBoxColumn Edad;
    private System.Windows.Forms.DataGridViewTextBoxColumn FechaCupon;
    private System.Windows.Forms.DataGridViewTextBoxColumn Cupon;
    private System.Windows.Forms.Button btn_GenerarCupon;
    private System.Windows.Forms.Button btn_Salir;
    private System.Windows.Forms.Button btn_Reimprimir;
    private System.Windows.Forms.Button Btn_Exepcion;
    public System.Windows.Forms.Label Lbl_Encabezado;
  }
}