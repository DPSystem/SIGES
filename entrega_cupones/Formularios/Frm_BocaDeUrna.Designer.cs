
namespace entrega_cupones.Formularios
{
  partial class Frm_BocaDeUrna
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
      this.dgv_MostrarSocios = new System.Windows.Forms.DataGridView();
      this.numero_soc = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dni_socio = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.ayn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.socio_empresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.CUIT_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.CUIL = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.ACargo = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Voto = new System.Windows.Forms.DataGridViewTextBoxColumn();
      ((System.ComponentModel.ISupportInitialize)(this.dgv_MostrarSocios)).BeginInit();
      this.SuspendLayout();
      // 
      // dgv_MostrarSocios
      // 
      this.dgv_MostrarSocios.AllowUserToAddRows = false;
      this.dgv_MostrarSocios.AllowUserToDeleteRows = false;
      this.dgv_MostrarSocios.AllowUserToResizeColumns = false;
      this.dgv_MostrarSocios.AllowUserToResizeRows = false;
      dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.dgv_MostrarSocios.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
      this.dgv_MostrarSocios.BackgroundColor = System.Drawing.Color.WhiteSmoke;
      this.dgv_MostrarSocios.BorderStyle = System.Windows.Forms.BorderStyle.None;
      dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.dgv_MostrarSocios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
      this.dgv_MostrarSocios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgv_MostrarSocios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numero_soc,
            this.dni_socio,
            this.ayn,
            this.socio_empresa,
            this.CUIT_,
            this.CUIL,
            this.ACargo,
            this.Voto});
      this.dgv_MostrarSocios.GridColor = System.Drawing.SystemColors.WindowFrame;
      this.dgv_MostrarSocios.Location = new System.Drawing.Point(12, 64);
      this.dgv_MostrarSocios.Name = "dgv_MostrarSocios";
      this.dgv_MostrarSocios.ReadOnly = true;
      this.dgv_MostrarSocios.RowHeadersVisible = false;
      this.dgv_MostrarSocios.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.dgv_MostrarSocios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.dgv_MostrarSocios.Size = new System.Drawing.Size(886, 281);
      this.dgv_MostrarSocios.TabIndex = 22;
      // 
      // numero_soc
      // 
      this.numero_soc.DataPropertyName = "NroDeSocio";
      dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
      this.numero_soc.DefaultCellStyle = dataGridViewCellStyle3;
      this.numero_soc.HeaderText = "Nº Socio";
      this.numero_soc.Name = "numero_soc";
      this.numero_soc.ReadOnly = true;
      this.numero_soc.Width = 90;
      // 
      // dni_socio
      // 
      this.dni_socio.DataPropertyName = "NroDNI";
      dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
      dataGridViewCellStyle4.Format = "N2";
      dataGridViewCellStyle4.NullValue = null;
      this.dni_socio.DefaultCellStyle = dataGridViewCellStyle4;
      this.dni_socio.HeaderText = "D.N.I.";
      this.dni_socio.Name = "dni_socio";
      this.dni_socio.ReadOnly = true;
      this.dni_socio.Width = 75;
      // 
      // ayn
      // 
      this.ayn.DataPropertyName = "ApeNom";
      dataGridViewCellStyle5.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
      this.ayn.DefaultCellStyle = dataGridViewCellStyle5;
      this.ayn.HeaderText = "Apellido y Nombre";
      this.ayn.Name = "ayn";
      this.ayn.ReadOnly = true;
      this.ayn.Width = 240;
      // 
      // socio_empresa
      // 
      this.socio_empresa.DataPropertyName = "RazonSocial";
      dataGridViewCellStyle6.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
      this.socio_empresa.DefaultCellStyle = dataGridViewCellStyle6;
      this.socio_empresa.HeaderText = "Empresa";
      this.socio_empresa.Name = "socio_empresa";
      this.socio_empresa.ReadOnly = true;
      this.socio_empresa.Width = 295;
      // 
      // CUIT_
      // 
      this.CUIT_.DataPropertyName = "CUIT";
      this.CUIT_.HeaderText = "CUIT";
      this.CUIT_.Name = "CUIT_";
      this.CUIT_.ReadOnly = true;
      this.CUIT_.Visible = false;
      this.CUIT_.Width = 70;
      // 
      // CUIL
      // 
      this.CUIL.DataPropertyName = "CUIL";
      this.CUIL.HeaderText = "CUIL";
      this.CUIL.Name = "CUIL";
      this.CUIL.ReadOnly = true;
      this.CUIL.Visible = false;
      // 
      // ACargo
      // 
      this.ACargo.HeaderText = "A Cargo";
      this.ACargo.Name = "ACargo";
      this.ACargo.ReadOnly = true;
      // 
      // Voto
      // 
      this.Voto.HeaderText = "Voto ?";
      this.Voto.Name = "Voto";
      this.Voto.ReadOnly = true;
      this.Voto.Width = 60;
      // 
      // Frm_BocaDeUrna
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
      this.ClientSize = new System.Drawing.Size(969, 450);
      this.Controls.Add(this.dgv_MostrarSocios);
      this.Name = "Frm_BocaDeUrna";
      this.Text = "Boca De Urna";
      this.Load += new System.EventHandler(this.Frm_BocaDeUrna_Load);
      ((System.ComponentModel.ISupportInitialize)(this.dgv_MostrarSocios)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.DataGridView dgv_MostrarSocios;
    private System.Windows.Forms.DataGridViewTextBoxColumn numero_soc;
    private System.Windows.Forms.DataGridViewTextBoxColumn dni_socio;
    private System.Windows.Forms.DataGridViewTextBoxColumn ayn;
    private System.Windows.Forms.DataGridViewTextBoxColumn socio_empresa;
    private System.Windows.Forms.DataGridViewTextBoxColumn CUIT_;
    private System.Windows.Forms.DataGridViewTextBoxColumn CUIL;
    private System.Windows.Forms.DataGridViewTextBoxColumn ACargo;
    private System.Windows.Forms.DataGridViewTextBoxColumn Voto;
  }
}