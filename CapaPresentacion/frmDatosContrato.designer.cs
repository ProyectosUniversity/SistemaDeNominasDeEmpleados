namespace CapaPresentacion
{
    partial class frmDatosContrato
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
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbAFP = new System.Windows.Forms.ComboBox();
            this.rdNo = new System.Windows.Forms.RadioButton();
            this.rdSi = new System.Windows.Forms.RadioButton();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.txtCargo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.nbTotalHoras = new System.Windows.Forms.NumericUpDown();
            this.nbValorHora = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nbTotalHoras)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbValorHora)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(23, 316);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(125, 23);
            this.btnGuardar.TabIndex = 69;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(221, 254);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 13);
            this.label8.TabIndex = 68;
            this.label8.Text = "Valor Hora";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(45, 267);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 67;
            this.label7.Text = "Contratadas";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(42, 254);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 66;
            this.label6.Text = "Total de Horas";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(20, 228);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 13);
            this.label5.TabIndex = 65;
            this.label5.Text = "Asiganacion Familiar";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(45, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 64;
            this.label4.Text = "AFP";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(42, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 63;
            this.label3.Text = "Cargo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(42, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 62;
            this.label2.Text = "Fecha Fin";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(42, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 61;
            this.label1.Text = "Fecha Inicio";
            // 
            // cmbAFP
            // 
            this.cmbAFP.FormattingEnabled = true;
            this.cmbAFP.Location = new System.Drawing.Point(129, 189);
            this.cmbAFP.Name = "cmbAFP";
            this.cmbAFP.Size = new System.Drawing.Size(63, 21);
            this.cmbAFP.TabIndex = 58;
            // 
            // rdNo
            // 
            this.rdNo.AutoSize = true;
            this.rdNo.ForeColor = System.Drawing.Color.White;
            this.rdNo.Location = new System.Drawing.Point(190, 226);
            this.rdNo.Name = "rdNo";
            this.rdNo.Size = new System.Drawing.Size(39, 17);
            this.rdNo.TabIndex = 57;
            this.rdNo.TabStop = true;
            this.rdNo.Text = "No";
            this.rdNo.UseVisualStyleBackColor = true;
            // 
            // rdSi
            // 
            this.rdSi.AutoSize = true;
            this.rdSi.ForeColor = System.Drawing.Color.White;
            this.rdSi.Location = new System.Drawing.Point(129, 226);
            this.rdSi.Name = "rdSi";
            this.rdSi.Size = new System.Drawing.Size(34, 17);
            this.rdSi.TabIndex = 56;
            this.rdSi.TabStop = true;
            this.rdSi.Text = "Si";
            this.rdSi.UseVisualStyleBackColor = true;
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Location = new System.Drawing.Point(129, 104);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(149, 20);
            this.dtpFechaFin.TabIndex = 55;
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Location = new System.Drawing.Point(129, 61);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(149, 20);
            this.dtpFechaInicio.TabIndex = 54;
            // 
            // txtCargo
            // 
            this.txtCargo.Location = new System.Drawing.Point(129, 146);
            this.txtCargo.Name = "txtCargo";
            this.txtCargo.Size = new System.Drawing.Size(100, 20);
            this.txtCargo.TabIndex = 53;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(127, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 25);
            this.label9.TabIndex = 70;
            this.label9.Text = "Contrato";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(248, 315);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 71;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // nbTotalHoras
            // 
            this.nbTotalHoras.Location = new System.Drawing.Point(125, 260);
            this.nbTotalHoras.Name = "nbTotalHoras";
            this.nbTotalHoras.Size = new System.Drawing.Size(47, 20);
            this.nbTotalHoras.TabIndex = 72;
            // 
            // nbValorHora
            // 
            this.nbValorHora.Location = new System.Drawing.Point(284, 260);
            this.nbValorHora.Name = "nbValorHora";
            this.nbValorHora.Size = new System.Drawing.Size(47, 20);
            this.nbValorHora.TabIndex = 73;
            // 
            // frmDatosContrato
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(47)))), ((int)(((byte)(66)))));
            this.ClientSize = new System.Drawing.Size(402, 351);
            this.Controls.Add(this.nbValorHora);
            this.Controls.Add(this.nbTotalHoras);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbAFP);
            this.Controls.Add(this.rdNo);
            this.Controls.Add(this.rdSi);
            this.Controls.Add(this.dtpFechaFin);
            this.Controls.Add(this.dtpFechaInicio);
            this.Controls.Add(this.txtCargo);
            this.Name = "frmDatosContrato";
            this.Text = "frmContrato";
            ((System.ComponentModel.ISupportInitialize)(this.nbTotalHoras)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbValorHora)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox cmbAFP;
        public System.Windows.Forms.RadioButton rdNo;
        public System.Windows.Forms.RadioButton rdSi;
        public System.Windows.Forms.DateTimePicker dtpFechaFin;
        public System.Windows.Forms.DateTimePicker dtpFechaInicio;
        public System.Windows.Forms.TextBox txtCargo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnCancelar;
        public System.Windows.Forms.NumericUpDown nbTotalHoras;
        public System.Windows.Forms.NumericUpDown nbValorHora;
    }
}