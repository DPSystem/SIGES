
namespace entrega_cupones.Formularios
{
  partial class frm_ActaBuscar
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
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
      this.btn_VerVD = new System.Windows.Forms.Button();
      this.dgv_Actas = new System.Windows.Forms.DataGridView();
      this.label23 = new System.Windows.Forms.Label();
      this.btn_AnularActa = new System.Windows.Forms.Button();
      this.btn_Salir = new System.Windows.Forms.Button();
      this.NroActa = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Cuit = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.RazonSocial = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Desde = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Hasta = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Importe = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Inspector = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.EstadoMostrar = new System.Windows.Forms.DataGridViewTextBoxColumn();
      ((System.ComponentModel.ISupportInitialize)(this.dgv_Actas)).BeginInit();
      this.SuspendLayout();
      // 
      // btn_VerVD
      // 
      this.btn_VerVD.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btn_VerVD.Location = new System.Drawing.Point(895, 29);
      this.btn_VerVD.Name = "btn_VerVD";
      this.btn_VerVD.Size = new System.Drawing.Size(82, 38);
      this.btn_VerVD.TabIndex = 609;
      this.btn_VerVD.Text = "Ver Acta";
      this.btn_VerVD.UseVisualStyleBackColor = true;
      this.btn_VerVD.Click += new System.EventHandler(this.btn_VerVD_Click);
      // 
      // dgv_Actas
      // 
      this.dgv_Actas.AllowUserToAddRows = false;
      this.dgv_Actas.AllowUserToDeleteRows = false;
      this.dgv_Actas.AllowUserToResizeRows = false;
      dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      dataGridViewCellStyle13.ForeColor = System.Drawing.Color.Black;
      this.dgv_Actas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
      this.dgv_Actas.BorderStyle = System.Windows.Forms.BorderStyle.None;
      dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle14.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.dgv_Actas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
      this.dgv_Actas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgv_Actas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NroActa,
            this.Fecha,
            this.Cuit,
            this.RazonSocial,
            this.Desde,
            this.Hasta,
            this.Importe,
            this.Inspector,
            this.Estado,
            this.EstadoMostrar});
      this.dgv_Actas.Location = new System.Drawing.Point(4, 73);
      this.dgv_Actas.Name = "dgv_Actas";
      this.dgv_Actas.RowHeadersVisible = false;
      this.dgv_Actas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.dgv_Actas.Size = new System.Drawing.Size(1062, 513);
      this.dgv_Actas.TabIndex = 608;
      // 
      // label23
      // 
      this.label23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(151)))), ((int)(((byte)(119)))));
      this.label23.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold);
      this.label23.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
      this.label23.Location = new System.Drawing.Point(4, 3);
      this.label23.Name = "label23";
      this.label23.Size = new System.Drawing.Size(1062, 23);
      this.label23.TabIndex = 610;
      this.label23.Text = "Listado de Actas Emitidas ";
      this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // btn_AnularActa
      // 
      this.btn_AnularActa.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btn_AnularActa.Location = new System.Drawing.Point(807, 29);
      this.btn_AnularActa.Name = "btn_AnularActa";
      this.btn_AnularActa.Size = new System.Drawing.Size(82, 38);
      this.btn_AnularActa.TabIndex = 611;
      this.btn_AnularActa.Text = "Anular";
      this.btn_AnularActa.UseVisualStyleBackColor = true;
      this.btn_AnularActa.Click += new System.EventHandler(this.btn_AnularActa_Click);
      // 
      // btn_Salir
      // 
      this.btn_Salir.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btn_Salir.Location = new System.Drawing.Point(983, 29);
      this.btn_Salir.Name = "btn_Salir";
      this.btn_Salir.Size = new System.Drawing.Size(82, 38);
      this.btn_Salir.TabIndex = 612;
      this.btn_Salir.Text = "Salir";
      this.btn_Salir.UseVisualStyleBackColor = true;
      this.btn_Salir.Click += new System.EventHandler(this.btn_Salir_Click);
      // 
      // NroActa
      // 
      this.NroActa.DataPropertyName = "NroActa";
      dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle15.NullValue = null;
      this.NroActa.DefaultCellStyle = dataGridViewCellStyle15;
      this.NroActa.HeaderText = "Numero";
      this.NroActa.Name = "NroActa";
      this.NroActa.ReadOnly = true;
      this.NroActa.Width = 70;
      // 
      // Fecha
      // 
      this.Fecha.DataPropertyName = "Fecha";
      dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      this.Fecha.DefaultCellStyle = dataGridViewCellStyle16;
      this.Fecha.HeaderText = "Fecha";
      this.Fecha.Name = "Fecha";
      this.Fecha.ReadOnly = true;
      this.Fecha.Width = 80;
      // 
      // Cuit
      // 
      this.Cuit.DataPropertyName = "Cuit";
      dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
      dataGridViewCellStyle17.Format = "N2";
      dataGridViewCellStyle17.NullValue = null;
      this.Cuit.DefaultCellStyle = dataGridViewCellStyle17;
      this.Cuit.HeaderText = "CUIT";
      this.Cuit.Name = "Cuit";
      this.Cuit.ReadOnly = true;
      // 
      // RazonSocial
      // 
      this.RazonSocial.DataPropertyName = "RazonSocial";
      dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      this.RazonSocial.DefaultCellStyle = dataGridViewCellStyle18;
      this.RazonSocial.HeaderText = "Empresa";
      this.RazonSocial.Name = "RazonSocial";
      this.RazonSocial.ReadOnly = true;
      this.RazonSocial.Width = 300;
      // 
      // Desde
      // 
      this.Desde.DataPropertyName = "Desde";
      dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      this.Desde.DefaultCellStyle = dataGridViewCellStyle19;
      this.Desde.HeaderText = "Desde";
      this.Desde.Name = "Desde";
      this.Desde.ReadOnly = true;
      this.Desde.Width = 70;
      // 
      // Hasta
      // 
      this.Hasta.DataPropertyName = "Hasta";
      dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      this.Hasta.DefaultCellStyle = dataGridViewCellStyle20;
      this.Hasta.HeaderText = "Hasta";
      this.Hasta.Name = "Hasta";
      this.Hasta.ReadOnly = true;
      this.Hasta.Width = 70;
      // 
      // Importe
      // 
      this.Importe.DataPropertyName = "Importe";
      dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
      dataGridViewCellStyle21.Format = "N2";
      dataGridViewCellStyle21.NullValue = null;
      this.Importe.DefaultCellStyle = dataGridViewCellStyle21;
      this.Importe.HeaderText = "Importe";
      this.Importe.Name = "Importe";
      this.Importe.ReadOnly = true;
      this.Importe.Width = 80;
      // 
      // Inspector
      // 
      this.Inspector.DataPropertyName = "InspectorNombre";
      dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter;
      this.Inspector.DefaultCellStyle = dataGridViewCellStyle22;
      this.Inspector.HeaderText = "Inspector";
      this.Inspector.Name = "Inspector";
      this.Inspector.ReadOnly = true;
      this.Inspector.Width = 190;
      // 
      // Estado
      // 
      this.Estado.DataPropertyName = "Estado";
      dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
      dataGridViewCellStyle23.Format = "N2";
      dataGridViewCellStyle23.NullValue = null;
      this.Estado.DefaultCellStyle = dataGridViewCellStyle23;
      this.Estado.HeaderText = "Estado";
      this.Estado.Name = "Estado";
      this.Estado.ReadOnly = true;
      this.Estado.Visible = false;
      this.Estado.Width = 80;
      // 
      // EstadoMostrar
      // 
      dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      this.EstadoMostrar.DefaultCellStyle = dataGridViewCellStyle24;
      this.EstadoMostrar.HeaderText = "Estado";
      this.EstadoMostrar.Name = "EstadoMostrar";
      this.EstadoMostrar.Width = 80;
      // 
      // frm_ActaBuscar
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
      this.ClientSize = new System.Drawing.Size(1068, 598);
      this.Controls.Add(this.btn_Salir);
      this.Controls.Add(this.btn_AnularActa);
      this.Controls.Add(this.label23);
      this.Controls.Add(this.btn_VerVD);
      this.Controls.Add(this.dgv_Actas);
      this.Name = "frm_ActaBuscar";
      this.Text = "Actas Emitidas";
      this.Load += new System.EventHandler(this.frm_ActaBuscar_Load);
      ((System.ComponentModel.ISupportInitialize)(this.dgv_Actas)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button btn_VerVD;
    public System.Windows.Forms.DataGridView dgv_Actas;
    private System.Windows.Forms.Label label23;
    private System.Windows.Forms.Button btn_AnularActa;
    private System.Windows.Forms.Button btn_Salir;
    private System.Windows.Forms.DataGridViewTextBoxColumn NroActa;
    private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
    private System.Windows.Forms.DataGridViewTextBoxColumn Cuit;
    private System.Windows.Forms.DataGridViewTextBoxColumn RazonSocial;
    private System.Windows.Forms.DataGridViewTextBoxColumn Desde;
    private System.Windows.Forms.DataGridViewTextBoxColumn Hasta;
    private System.Windows.Forms.DataGridViewTextBoxColumn Importe;
    private System.Windows.Forms.DataGridViewTextBoxColumn Inspector;
    private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
    private System.Windows.Forms.DataGridViewTextBoxColumn EstadoMostrar;
  }
}