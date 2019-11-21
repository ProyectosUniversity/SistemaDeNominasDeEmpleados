using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Referencia a otras Capas
using CapaAplicacion;
using CapaDominio;

namespace CapaPresentacion
{
    public partial class frmProcesarPagos : Form
    {
        public frmProcesarPagos()
        {
            InitializeComponent();
        }

        GestionarBoletaManejador objGestionarBoletaManejador = new GestionarBoletaManejador();
        GestionarPeriodoManejador objGestionarPeriodoManejador = new GestionarPeriodoManejador();

        Boleta objBoleta = new Boleta();
        Periodo objPeriodo = new Periodo();
        private void frmProcesarPagos_Load(object sender, EventArgs e)
        {
            MostrarPeriodo();
        }

        public void MostrarPeriodo()
        {
            //dtBoletas.DataSource= objGestionarPeriodoManejador.listarPeriodo(); 
            objGestionarPeriodoManejador.listarPeriodo();
        }

        


    }
}
