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
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private Form activeForm = null;
        private void openChildForm(Form childform)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childform;
            childform.TopLevel = false;
            childform.FormBorderStyle = FormBorderStyle.None;
            childform.Dock = DockStyle.Fill;
            pnlContenido.Controls.Add(childform);
            pnlContenido.Tag = childform;
            childform.BringToFront();
            childform.Show();


        }

        private void btnGestionarContrato_Click(object sender, EventArgs e)
        {
            openChildForm(new frmGestionarContrato());
        }
    }
}
