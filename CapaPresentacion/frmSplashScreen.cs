using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmSplashScreen : Form
    {
        public frmSplashScreen()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void tAbrir_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1) this.Opacity += 0.05;
            cProgressBar.Value += 1;
            cProgressBar.Text = cProgressBar.Value.ToString();
            if (cProgressBar.Value == 100)
            {
                tAbrir.Stop();
                tCerrar.Start();
                
            }

        }

        private void tCerrar_Tick(object sender, EventArgs e)
        {
            this.Opacity -= 0.1;
            if (this.Opacity == 0)
            {
                tCerrar.Stop();
                frmPrincipal frm = new frmPrincipal();
                //this.Close();
                frm.Show();
                
            }
        }

        private void frmSplashScreen_Load(object sender, EventArgs e)
        {
            this.Opacity = 0.0;
            //Inicializamos estas propiedades de la barra de progreso, mediante codigo.(Opcional)
            cProgressBar.Value = 0;
            cProgressBar.Minimum = 0;
            cProgressBar.Maximum = 100;
            //Iniciamos el temporizador 1.
            tAbrir.Start();
        }

      
    }
}
