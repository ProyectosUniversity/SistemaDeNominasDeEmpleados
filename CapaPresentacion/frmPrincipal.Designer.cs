﻿namespace CapaPresentacion
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
            this.pnlOpciones = new System.Windows.Forms.Panel();
            this.btnGestionarContrato = new System.Windows.Forms.Button();
            this.pnlBanner = new System.Windows.Forms.Panel();
            this.pnlContenido = new System.Windows.Forms.Panel();
            this.btnProcesarPagos = new System.Windows.Forms.Button();
            this.pnlOpciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlOpciones
            // 
            this.pnlOpciones.Controls.Add(this.btnProcesarPagos);
            this.pnlOpciones.Controls.Add(this.btnGestionarContrato);
            this.pnlOpciones.Controls.Add(this.pnlBanner);
            this.pnlOpciones.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlOpciones.Location = new System.Drawing.Point(0, 0);
            this.pnlOpciones.Name = "pnlOpciones";
            this.pnlOpciones.Size = new System.Drawing.Size(200, 450);
            this.pnlOpciones.TabIndex = 0;
            // 
            // btnGestionarContrato
            // 
            this.btnGestionarContrato.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGestionarContrato.FlatAppearance.BorderSize = 0;
            this.btnGestionarContrato.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
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
            this.pnlBanner.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBanner.Location = new System.Drawing.Point(0, 0);
            this.pnlBanner.Name = "pnlBanner";
            this.pnlBanner.Size = new System.Drawing.Size(200, 118);
            this.pnlBanner.TabIndex = 0;
            // 
            // pnlContenido
            // 
            this.pnlContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenido.Location = new System.Drawing.Point(200, 0);
            this.pnlContenido.Name = "pnlContenido";
            this.pnlContenido.Size = new System.Drawing.Size(600, 450);
            this.pnlContenido.TabIndex = 1;
            // 
            // btnProcesarPagos
            // 
            this.btnProcesarPagos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProcesarPagos.FlatAppearance.BorderSize = 0;
            this.btnProcesarPagos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProcesarPagos.Location = new System.Drawing.Point(0, 162);
            this.btnProcesarPagos.Name = "btnProcesarPagos";
            this.btnProcesarPagos.Size = new System.Drawing.Size(200, 44);
            this.btnProcesarPagos.TabIndex = 1;
            this.btnProcesarPagos.Text = "Procesar Pagos";
            this.btnProcesarPagos.UseVisualStyleBackColor = true;
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlContenido);
            this.Controls.Add(this.pnlOpciones);
            this.Name = "frmPrincipal";
            this.Text = "Form1";
            this.pnlOpciones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlOpciones;
        private System.Windows.Forms.Button btnGestionarContrato;
        private System.Windows.Forms.Panel pnlBanner;
        private System.Windows.Forms.Panel pnlContenido;
        private System.Windows.Forms.Button btnProcesarPagos;
    }
}

