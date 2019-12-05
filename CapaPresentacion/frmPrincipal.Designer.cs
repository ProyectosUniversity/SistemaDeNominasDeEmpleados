namespace CapaPresentacion
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.pnlOpciones = new System.Windows.Forms.Panel();
            this.btnProcesarPagos = new System.Windows.Forms.Button();
            this.btnGestionarContrato = new System.Windows.Forms.Button();
            this.pnlBanner = new System.Windows.Forms.Panel();
            this.pnlContenido = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlOpciones.SuspendLayout();
            this.pnlBanner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlOpciones
            // 
            this.pnlOpciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(47)))), ((int)(((byte)(66)))));
            this.pnlOpciones.Controls.Add(this.btnProcesarPagos);
            this.pnlOpciones.Controls.Add(this.btnGestionarContrato);
            this.pnlOpciones.Controls.Add(this.pnlBanner);
            this.pnlOpciones.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlOpciones.Location = new System.Drawing.Point(0, 0);
            this.pnlOpciones.Name = "pnlOpciones";
            this.pnlOpciones.Size = new System.Drawing.Size(200, 450);
            this.pnlOpciones.TabIndex = 0;
            // 
            // btnProcesarPagos
            // 
            this.btnProcesarPagos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProcesarPagos.FlatAppearance.BorderSize = 0;
            this.btnProcesarPagos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProcesarPagos.Font = new System.Drawing.Font("Britannic Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcesarPagos.ForeColor = System.Drawing.Color.White;
            this.btnProcesarPagos.Location = new System.Drawing.Point(0, 162);
            this.btnProcesarPagos.Name = "btnProcesarPagos";
            this.btnProcesarPagos.Size = new System.Drawing.Size(200, 44);
            this.btnProcesarPagos.TabIndex = 1;
            this.btnProcesarPagos.Text = "Procesar Pagos";
            this.btnProcesarPagos.UseVisualStyleBackColor = true;
            this.btnProcesarPagos.Click += new System.EventHandler(this.btnProcesarPagos_Click);
            // 
            // btnGestionarContrato
            // 
            this.btnGestionarContrato.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGestionarContrato.FlatAppearance.BorderSize = 0;
            this.btnGestionarContrato.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGestionarContrato.Font = new System.Drawing.Font("Britannic Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGestionarContrato.ForeColor = System.Drawing.Color.White;
            this.btnGestionarContrato.Location = new System.Drawing.Point(0, 118);
            this.btnGestionarContrato.Name = "btnGestionarContrato";
            this.btnGestionarContrato.Size = new System.Drawing.Size(200, 44);
            this.btnGestionarContrato.TabIndex = 0;
            this.btnGestionarContrato.Text = "Gestionar Contrato";
            this.btnGestionarContrato.UseVisualStyleBackColor = true;
            this.btnGestionarContrato.Click += new System.EventHandler(this.btnGestionarContrato_Click);
            // 
            // pnlBanner
            // 
            this.pnlBanner.Controls.Add(this.pictureBox1);
            this.pnlBanner.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBanner.Location = new System.Drawing.Point(0, 0);
            this.pnlBanner.Name = "pnlBanner";
            this.pnlBanner.Size = new System.Drawing.Size(200, 118);
            this.pnlBanner.TabIndex = 0;
            // 
            // pnlContenido
            // 
            this.pnlContenido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(47)))), ((int)(((byte)(66)))));
            this.pnlContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenido.Location = new System.Drawing.Point(200, 0);
            this.pnlContenido.Name = "pnlContenido";
            this.pnlContenido.Size = new System.Drawing.Size(600, 450);
            this.pnlContenido.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(40, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(121, 83);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlContenido);
            this.Controls.Add(this.pnlOpciones);
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Nominas";
            this.pnlOpciones.ResumeLayout(false);
            this.pnlBanner.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlOpciones;
        private System.Windows.Forms.Button btnGestionarContrato;
        private System.Windows.Forms.Panel pnlBanner;
        private System.Windows.Forms.Panel pnlContenido;
        private System.Windows.Forms.Button btnProcesarPagos;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

