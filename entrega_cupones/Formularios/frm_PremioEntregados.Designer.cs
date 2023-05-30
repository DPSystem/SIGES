
namespace entrega_cupones.Formularios
{
  partial class frm_PremioEntregados
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
      this.txt_CUIT = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.btn_BuscarEmpresa = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.dgv_MochilasEntregadas = new System.Windows.Forms.DataGridView();
      this.FechaDeEntrega = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.NroDeCupon = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.ApenomSocio = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.ApenomBenef = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Articulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Entregado = new System.Windows.Forms.DataGridViewTextBoxColumn();
      ((System.ComponentModel.ISupportInitialize)(this.dgv_MochilasEntregadas)).BeginInit();
      this.SuspendLayout();
      // 
      // txt_CUIT
      // 
      this.txt_CUIT.BackColor = System.Drawing.Color.White;
      this.txt_CUIT.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txt_CUIT.Location = new System.Drawing.Point(488, 336);
      this.txt_CUIT.Name = "txt_CUIT";
      this.txt_CUIT.ReadOnly = true;
      this.txt_CUIT.Size = new System.Drawing.Size(140, 23);
      this.txt_CUIT.TabIndex = 591;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label5.ForeColor = System.Drawing.Color.Gainsboro;
      this.label5.Location = new System.Drawing.Point(430, 339);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(55, 17);
      this.label5.TabIndex = 592;
      this.label5.Text = "C.U.I.T.:";
      // 
      // btn_BuscarEmpresa
      // 
      this.btn_BuscarEmpresa.Font = new System.Drawing.Font("Century Gothic", 9.75F);
      this.btn_BuscarEmpresa.Location = new System.Drawing.Point(673, 336);
      this.btn_BuscarEmpresa.Name = "btn_BuscarEmpresa";
      this.btn_BuscarEmpresa.Size = new System.Drawing.Size(115, 32);
      this.btn_BuscarEmpresa.TabIndex = 590;
      this.btn_BuscarEmpresa.Text = "Buscar Empresa";
      this.btn_BuscarEmpresa.UseVisualStyleBackColor = true;
      // 
      // label1
      // 
      this.label1.AutoEllipsis = true;
      this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(151)))), ((int)(((byte)(119)))));
      this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.ForeColor = System.Drawing.Color.Black;
      this.label1.Location = new System.Drawing.Point(12, 9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(869, 23);
      this.label1.TabIndex = 593;
      this.label1.Text = "C.U.I.T.:";
      this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      // 
      // dgv_MochilasEntregadas
      // 
      this.dgv_MochilasEntregadas.AllowUserToAddRows = false;
      this.dgv_MochilasEntregadas.AllowUserToDeleteRows = false;
      this.dgv_MochilasEntregadas.AllowUserToResizeColumns = false;
      this.dgv_MochilasEntregadas.AllowUserToResizeRows = false;
      dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.dgv_MochilasEntregadas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
      dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DimGray;
      dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.dgv_MochilasEntregadas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
      this.dgv_MochilasEntregadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgv_MochilasEntregadas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FechaDeEntrega,
            this.NroDeCupon,
            this.ApenomSocio,
            this.ApenomBenef,
            this.Articulo,
            this.Entregado});
      this.dgv_MochilasEntregadas.Location = new System.Drawing.Point(12, 35);
      this.dgv_MochilasEntregadas.Name = "dgv_MochilasEntregadas";
      this.dgv_MochilasEntregadas.ReadOnly = true;
      this.dgv_MochilasEntregadas.RowHeadersVisible = false;
      this.dgv_MochilasEntregadas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.dgv_MochilasEntregadas.Size = new System.Drawing.Size(869, 210);
      this.dgv_MochilasEntregadas.TabIndex = 594;
      // 
      // FechaDeEntrega
      // 
      this.FechaDeEntrega.DataPropertyName = "FechaDeEntrega";
      dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomLeft;
      dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 9F);
      this.FechaDeEntrega.DefaultCellStyle = dataGridViewCellStyle3;
      this.FechaDeEntrega.HeaderText = "Fecha";
      this.FechaDeEntrega.Name = "FechaDeEntrega";
      this.FechaDeEntrega.ReadOnly = true;
      this.FechaDeEntrega.Width = 120;
      // 
      // NroDeCupon
      // 
      this.NroDeCupon.DataPropertyName = "NroDeCupon";
      dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter;
      dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 9F);
      this.NroDeCupon.DefaultCellStyle = dataGridViewCellStyle4;
      this.NroDeCupon.HeaderText = "Cupon";
      this.NroDeCupon.Name = "NroDeCupon";
      this.NroDeCupon.ReadOnly = true;
      this.NroDeCupon.Width = 60;
      // 
      // ApenomSocio
      // 
      this.ApenomSocio.DataPropertyName = "ApenomSocio";
      this.ApenomSocio.HeaderText = "Socio Titular";
      this.ApenomSocio.Name = "ApenomSocio";
      this.ApenomSocio.ReadOnly = true;
      this.ApenomSocio.Width = 220;
      // 
      // ApenomBenef
      // 
      this.ApenomBenef.DataPropertyName = "ApenomBenef";
      this.ApenomBenef.HeaderText = "Beneficiario";
      this.ApenomBenef.Name = "ApenomBenef";
      this.ApenomBenef.ReadOnly = true;
      this.ApenomBenef.Width = 220;
      // 
      // Articulo
      // 
      this.Articulo.DataPropertyName = "Mochila";
      dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomLeft;
      dataGridViewCellStyle5.Font = new System.Drawing.Font("Century Gothic", 9F);
      this.Articulo.DefaultCellStyle = dataGridViewCellStyle5;
      this.Articulo.HeaderText = "Mochila";
      this.Articulo.Name = "Articulo";
      this.Articulo.ReadOnly = true;
      this.Articulo.Width = 140;
      // 
      // Entregado
      // 
      this.Entregado.DataPropertyName = "Entregado";
      dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      this.Entregado.DefaultCellStyle = dataGridViewCellStyle6;
      this.Entregado.HeaderText = "Retirado";
      this.Entregado.Name = "Entregado";
      this.Entregado.ReadOnly = true;
      this.Entregado.Width = 70;
      // 
      // frm_PremioEntregados
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
      this.ClientSize = new System.Drawing.Size(983, 450);
      this.Controls.Add(this.dgv_MochilasEntregadas);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.txt_CUIT);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.btn_BuscarEmpresa);
      this.Name = "frm_PremioEntregados";
      this.Text = "Premios Entregados";
      ((System.ComponentModel.ISupportInitialize)(this.dgv_MochilasEntregadas)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    public System.Windows.Forms.TextBox txt_CUIT;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Button btn_BuscarEmpresa;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.DataGridView dgv_MochilasEntregadas;
    private System.Windows.Forms.DataGridViewTextBoxColumn FechaDeEntrega;
    private System.Windows.Forms.DataGridViewTextBoxColumn NroDeCupon;
    private System.Windows.Forms.DataGridViewTextBoxColumn ApenomSocio;
    private System.Windows.Forms.DataGridViewTextBoxColumn ApenomBenef;
    private System.Windows.Forms.DataGridViewTextBoxColumn Articulo;
    private System.Windows.Forms.DataGridViewTextBoxColumn Entregado;
  }
}