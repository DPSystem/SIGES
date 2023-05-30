
namespace entrega_cupones.Formularios.Informes
{
  partial class PorInspector
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
      this.dgv1 = new System.Windows.Forms.DataGridView();
      this.Btn_Calcular = new System.Windows.Forms.Button();
      this.Txt_Importe = new System.Windows.Forms.TextBox();
      ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
      this.SuspendLayout();
      // 
      // dgv1
      // 
      this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgv1.Location = new System.Drawing.Point(12, 97);
      this.dgv1.Name = "dgv1";
      this.dgv1.Size = new System.Drawing.Size(1136, 387);
      this.dgv1.TabIndex = 0;
      // 
      // Btn_Calcular
      // 
      this.Btn_Calcular.Location = new System.Drawing.Point(24, 2);
      this.Btn_Calcular.Name = "Btn_Calcular";
      this.Btn_Calcular.Size = new System.Drawing.Size(87, 41);
      this.Btn_Calcular.TabIndex = 1;
      this.Btn_Calcular.Text = "Calcular";
      this.Btn_Calcular.UseVisualStyleBackColor = true;
      this.Btn_Calcular.Click += new System.EventHandler(this.Btn_Calcular_Click);
      // 
      // Txt_Importe
      // 
      this.Txt_Importe.Location = new System.Drawing.Point(238, 12);
      this.Txt_Importe.Name = "Txt_Importe";
      this.Txt_Importe.Size = new System.Drawing.Size(96, 20);
      this.Txt_Importe.TabIndex = 2;
      // 
      // PorInspector
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1160, 496);
      this.Controls.Add(this.Txt_Importe);
      this.Controls.Add(this.Btn_Calcular);
      this.Controls.Add(this.dgv1);
      this.Name = "PorInspector";
      this.Text = "PorInspector";
      this.Load += new System.EventHandler(this.PorInspector_Load);
      ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.Button Btn_Calcular;
        private System.Windows.Forms.TextBox Txt_Importe;
    }
}