namespace entrega_cupones
{
    partial class frm_edades
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
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
      this.dgv_edades = new System.Windows.Forms.DataGridView();
      this.edad = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.F = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.M = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.btn_imprimir = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.lbl_total_edades = new System.Windows.Forms.Label();
      this.cbx_localidad = new System.Windows.Forms.ComboBox();
      this.label2 = new System.Windows.Forms.Label();
      this.cbx_Desde = new System.Windows.Forms.ComboBox();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.dgv_Edades2 = new System.Windows.Forms.DataGridView();
      this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Mujer2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Varon2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Cantidad2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.cbx_Hasta = new System.Windows.Forms.ComboBox();
      this.btn_CalcularEdades = new System.Windows.Forms.Button();
      this.dgv_EdadesCupones = new System.Windows.Forms.DataGridView();
      this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Lbl_TotalCuponesJuguetes = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.dgv_edades)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.dgv_Edades2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.dgv_EdadesCupones)).BeginInit();
      this.SuspendLayout();
      // 
      // dgv_edades
      // 
      this.dgv_edades.AllowUserToAddRows = false;
      this.dgv_edades.AllowUserToDeleteRows = false;
      this.dgv_edades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgv_edades.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.edad,
            this.F,
            this.M,
            this.cantidad});
      this.dgv_edades.Location = new System.Drawing.Point(7, 98);
      this.dgv_edades.Name = "dgv_edades";
      this.dgv_edades.ReadOnly = true;
      this.dgv_edades.RowHeadersVisible = false;
      dataGridViewCellStyle5.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.dgv_edades.RowsDefaultCellStyle = dataGridViewCellStyle5;
      this.dgv_edades.Size = new System.Drawing.Size(406, 163);
      this.dgv_edades.TabIndex = 0;
      // 
      // edad
      // 
      dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      this.edad.DefaultCellStyle = dataGridViewCellStyle1;
      this.edad.HeaderText = "Edad";
      this.edad.Name = "edad";
      this.edad.ReadOnly = true;
      // 
      // F
      // 
      dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      this.F.DefaultCellStyle = dataGridViewCellStyle2;
      this.F.HeaderText = "Mujer";
      this.F.Name = "F";
      this.F.ReadOnly = true;
      // 
      // M
      // 
      dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      this.M.DefaultCellStyle = dataGridViewCellStyle3;
      this.M.HeaderText = "Varon";
      this.M.Name = "M";
      this.M.ReadOnly = true;
      // 
      // cantidad
      // 
      dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      this.cantidad.DefaultCellStyle = dataGridViewCellStyle4;
      this.cantidad.HeaderText = "Cantidad";
      this.cantidad.Name = "cantidad";
      this.cantidad.ReadOnly = true;
      // 
      // btn_imprimir
      // 
      this.btn_imprimir.Location = new System.Drawing.Point(285, 49);
      this.btn_imprimir.Name = "btn_imprimir";
      this.btn_imprimir.Size = new System.Drawing.Size(128, 34);
      this.btn_imprimir.TabIndex = 1;
      this.btn_imprimir.Text = "Imprimir";
      this.btn_imprimir.UseVisualStyleBackColor = true;
      this.btn_imprimir.Click += new System.EventHandler(this.btn_imprimir_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.BackColor = System.Drawing.Color.Transparent;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
      this.label1.ForeColor = System.Drawing.Color.Gainsboro;
      this.label1.Location = new System.Drawing.Point(294, 264);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(55, 17);
      this.label1.TabIndex = 2;
      this.label1.Text = "Total :";
      // 
      // lbl_total_edades
      // 
      this.lbl_total_edades.AutoSize = true;
      this.lbl_total_edades.BackColor = System.Drawing.Color.Transparent;
      this.lbl_total_edades.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
      this.lbl_total_edades.ForeColor = System.Drawing.Color.Gainsboro;
      this.lbl_total_edades.Location = new System.Drawing.Point(361, 264);
      this.lbl_total_edades.Name = "lbl_total_edades";
      this.lbl_total_edades.Size = new System.Drawing.Size(17, 17);
      this.lbl_total_edades.TabIndex = 3;
      this.lbl_total_edades.Text = "0";
      // 
      // cbx_localidad
      // 
      this.cbx_localidad.FormattingEnabled = true;
      this.cbx_localidad.Location = new System.Drawing.Point(84, 15);
      this.cbx_localidad.Name = "cbx_localidad";
      this.cbx_localidad.Size = new System.Drawing.Size(329, 21);
      this.cbx_localidad.TabIndex = 4;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.BackColor = System.Drawing.Color.Transparent;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.ForeColor = System.Drawing.Color.Gainsboro;
      this.label2.Location = new System.Drawing.Point(7, 20);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(71, 16);
      this.label2.TabIndex = 5;
      this.label2.Text = "Localidad:";
      // 
      // cbx_Desde
      // 
      this.cbx_Desde.FormattingEnabled = true;
      this.cbx_Desde.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59",
            "60",
            "61",
            "62",
            "63",
            "64",
            "65",
            "66",
            "67",
            "68",
            "69",
            "70"});
      this.cbx_Desde.Location = new System.Drawing.Point(578, 21);
      this.cbx_Desde.Name = "cbx_Desde";
      this.cbx_Desde.Size = new System.Drawing.Size(54, 21);
      this.cbx_Desde.TabIndex = 6;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.BackColor = System.Drawing.Color.Transparent;
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label3.ForeColor = System.Drawing.Color.Gainsboro;
      this.label3.Location = new System.Drawing.Point(520, 23);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(52, 16);
      this.label3.TabIndex = 7;
      this.label3.Text = "Desde:";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.BackColor = System.Drawing.Color.Transparent;
      this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label4.ForeColor = System.Drawing.Color.Gainsboro;
      this.label4.Location = new System.Drawing.Point(640, 23);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(47, 16);
      this.label4.TabIndex = 9;
      this.label4.Text = "Hasta:";
      // 
      // dgv_Edades2
      // 
      this.dgv_Edades2.AllowUserToAddRows = false;
      this.dgv_Edades2.AllowUserToDeleteRows = false;
      this.dgv_Edades2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgv_Edades2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.Mujer2,
            this.Varon2,
            this.Cantidad2});
      this.dgv_Edades2.Location = new System.Drawing.Point(489, 98);
      this.dgv_Edades2.Name = "dgv_Edades2";
      this.dgv_Edades2.ReadOnly = true;
      this.dgv_Edades2.RowHeadersVisible = false;
      dataGridViewCellStyle10.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.dgv_Edades2.RowsDefaultCellStyle = dataGridViewCellStyle10;
      this.dgv_Edades2.Size = new System.Drawing.Size(427, 163);
      this.dgv_Edades2.TabIndex = 10;
      // 
      // dataGridViewTextBoxColumn1
      // 
      this.dataGridViewTextBoxColumn1.DataPropertyName = "Edad";
      dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle6;
      this.dataGridViewTextBoxColumn1.HeaderText = "Edad";
      this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
      this.dataGridViewTextBoxColumn1.ReadOnly = true;
      // 
      // Mujer2
      // 
      this.Mujer2.DataPropertyName = "Mujer";
      dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      this.Mujer2.DefaultCellStyle = dataGridViewCellStyle7;
      this.Mujer2.HeaderText = "Mujer";
      this.Mujer2.Name = "Mujer2";
      this.Mujer2.ReadOnly = true;
      // 
      // Varon2
      // 
      this.Varon2.DataPropertyName = "Varon";
      dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      this.Varon2.DefaultCellStyle = dataGridViewCellStyle8;
      this.Varon2.HeaderText = "Varon";
      this.Varon2.Name = "Varon2";
      this.Varon2.ReadOnly = true;
      // 
      // Cantidad2
      // 
      this.Cantidad2.DataPropertyName = "Cantidad";
      dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      this.Cantidad2.DefaultCellStyle = dataGridViewCellStyle9;
      this.Cantidad2.HeaderText = "Cantidad";
      this.Cantidad2.Name = "Cantidad2";
      this.Cantidad2.ReadOnly = true;
      // 
      // cbx_Hasta
      // 
      this.cbx_Hasta.FormattingEnabled = true;
      this.cbx_Hasta.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59",
            "60",
            "61",
            "62",
            "63",
            "64",
            "65",
            "66",
            "67",
            "68",
            "69",
            "70"});
      this.cbx_Hasta.Location = new System.Drawing.Point(693, 21);
      this.cbx_Hasta.Name = "cbx_Hasta";
      this.cbx_Hasta.Size = new System.Drawing.Size(54, 21);
      this.cbx_Hasta.TabIndex = 11;
      // 
      // btn_CalcularEdades
      // 
      this.btn_CalcularEdades.Location = new System.Drawing.Point(798, 15);
      this.btn_CalcularEdades.Name = "btn_CalcularEdades";
      this.btn_CalcularEdades.Size = new System.Drawing.Size(96, 34);
      this.btn_CalcularEdades.TabIndex = 12;
      this.btn_CalcularEdades.Text = "Calcular";
      this.btn_CalcularEdades.UseVisualStyleBackColor = true;
      this.btn_CalcularEdades.Click += new System.EventHandler(this.btn_CalcularEdades_Click);
      // 
      // dgv_EdadesCupones
      // 
      this.dgv_EdadesCupones.AllowUserToAddRows = false;
      this.dgv_EdadesCupones.AllowUserToDeleteRows = false;
      this.dgv_EdadesCupones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgv_EdadesCupones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8});
      this.dgv_EdadesCupones.Location = new System.Drawing.Point(10, 314);
      this.dgv_EdadesCupones.Name = "dgv_EdadesCupones";
      this.dgv_EdadesCupones.ReadOnly = true;
      this.dgv_EdadesCupones.RowHeadersVisible = false;
      dataGridViewCellStyle15.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.dgv_EdadesCupones.RowsDefaultCellStyle = dataGridViewCellStyle15;
      this.dgv_EdadesCupones.Size = new System.Drawing.Size(428, 171);
      this.dgv_EdadesCupones.TabIndex = 13;
      // 
      // dataGridViewTextBoxColumn5
      // 
      this.dataGridViewTextBoxColumn5.DataPropertyName = "Edad";
      dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle11;
      this.dataGridViewTextBoxColumn5.HeaderText = "Edad";
      this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
      this.dataGridViewTextBoxColumn5.ReadOnly = true;
      // 
      // dataGridViewTextBoxColumn6
      // 
      this.dataGridViewTextBoxColumn6.DataPropertyName = "Mujer";
      dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle12;
      this.dataGridViewTextBoxColumn6.HeaderText = "Mujer";
      this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
      this.dataGridViewTextBoxColumn6.ReadOnly = true;
      // 
      // dataGridViewTextBoxColumn7
      // 
      this.dataGridViewTextBoxColumn7.DataPropertyName = "Varon";
      dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      this.dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle13;
      this.dataGridViewTextBoxColumn7.HeaderText = "Varon";
      this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
      this.dataGridViewTextBoxColumn7.ReadOnly = true;
      // 
      // dataGridViewTextBoxColumn8
      // 
      this.dataGridViewTextBoxColumn8.DataPropertyName = "Total";
      dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      this.dataGridViewTextBoxColumn8.DefaultCellStyle = dataGridViewCellStyle14;
      this.dataGridViewTextBoxColumn8.HeaderText = "Total";
      this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
      this.dataGridViewTextBoxColumn8.ReadOnly = true;
      // 
      // Lbl_TotalCuponesJuguetes
      // 
      this.Lbl_TotalCuponesJuguetes.AutoSize = true;
      this.Lbl_TotalCuponesJuguetes.BackColor = System.Drawing.Color.Transparent;
      this.Lbl_TotalCuponesJuguetes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
      this.Lbl_TotalCuponesJuguetes.ForeColor = System.Drawing.Color.Gainsboro;
      this.Lbl_TotalCuponesJuguetes.Location = new System.Drawing.Point(345, 488);
      this.Lbl_TotalCuponesJuguetes.Name = "Lbl_TotalCuponesJuguetes";
      this.Lbl_TotalCuponesJuguetes.Size = new System.Drawing.Size(17, 17);
      this.Lbl_TotalCuponesJuguetes.TabIndex = 15;
      this.Lbl_TotalCuponesJuguetes.Text = "0";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.BackColor = System.Drawing.Color.Transparent;
      this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
      this.label6.ForeColor = System.Drawing.Color.Gainsboro;
      this.label6.Location = new System.Drawing.Point(278, 488);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(55, 17);
      this.label6.TabIndex = 14;
      this.label6.Text = "Total :";
      // 
      // frm_edades
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
      this.ClientSize = new System.Drawing.Size(928, 521);
      this.Controls.Add(this.Lbl_TotalCuponesJuguetes);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.dgv_EdadesCupones);
      this.Controls.Add(this.btn_CalcularEdades);
      this.Controls.Add(this.cbx_Hasta);
      this.Controls.Add(this.dgv_Edades2);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.cbx_Desde);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.cbx_localidad);
      this.Controls.Add(this.lbl_total_edades);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.btn_imprimir);
      this.Controls.Add(this.dgv_edades);
      this.Name = "frm_edades";
      this.Text = "frm_edades";
      this.Load += new System.EventHandler(this.frm_edades_Load);
      ((System.ComponentModel.ISupportInitialize)(this.dgv_edades)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dgv_Edades2)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dgv_EdadesCupones)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_edades;
        private System.Windows.Forms.Button btn_imprimir;
        private System.Windows.Forms.DataGridViewTextBoxColumn edad;
        private System.Windows.Forms.DataGridViewTextBoxColumn F;
        private System.Windows.Forms.DataGridViewTextBoxColumn M;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_total_edades;
        private System.Windows.Forms.ComboBox cbx_localidad;
        private System.Windows.Forms.Label label2;
    private System.Windows.Forms.ComboBox cbx_Desde;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.DataGridView dgv_Edades2;
    private System.Windows.Forms.ComboBox cbx_Hasta;
    private System.Windows.Forms.Button btn_CalcularEdades;
    private System.Windows.Forms.DataGridView dgv_EdadesCupones;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
    private System.Windows.Forms.DataGridViewTextBoxColumn Mujer2;
    private System.Windows.Forms.DataGridViewTextBoxColumn Varon2;
    private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad2;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
    private System.Windows.Forms.Label Lbl_TotalCuponesJuguetes;
    private System.Windows.Forms.Label label6;
  }
}