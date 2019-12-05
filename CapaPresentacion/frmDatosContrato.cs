using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Referencia a otras capas
using CapaAplicacion;
using CapaDominio;

namespace CapaPresentacion
{
    public partial class frmDatosContrato : Form
    {
        //Objetos de la CapaAplicacion
        GestionarContratoManejador objGestionarContratoManejador = new GestionarContratoManejador();
        
        //Objetos de la CapaDominio
        Empleado objEmpleado = new Empleado();
        Contrato objContrato = new Contrato();
        AFP objAFP = new AFP();
        Periodo objPeriodo = new Periodo();

        //Variables locales
        public string CodigoContrato;
        public string CodigoEmpleado;
        public string GradoAcademico;
        public bool Editarse = false;

        public frmDatosContrato()
        {
            InitializeComponent();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        

        //Crear y Editar
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Editarse == false)
            {
                try
                {
                    objContrato.FechaInicio = Convert.ToDateTime(dtpFechaInicio.Value);
                    objContrato.FechaFin = Convert.ToDateTime(dtpFechaFin.Value);
                    objContrato.Cargo = txtCargo.Text;
                    if (rdSi.Checked)
                    {
                        objContrato.AsignacionFamiliar = "Si";
                    }
                    else if (rdNo.Checked)
                    {
                        objContrato.AsignacionFamiliar = "No";
                    }
                    objContrato.TotalDeHorasContratadasPorSemanas = Convert.ToDouble(nbTotalHoras.Value);
                    objContrato.ValorHora = Convert.ToDouble(nbValorHora.Value);
                    objContrato.Estado = "Vigente";
                    objContrato.CodigoEmpleado = CodigoEmpleado;
                    objContrato.CodigoAFP = Convert.ToString(cmbAFP.SelectedValue);
                    objContrato.CodigoPeriodo = "1";

                    objEmpleado.GradoAcademico = GradoAcademico;

                    var regla03 = objContrato.determinarFechaFin();
                    var regla04 = objContrato.determinarTotalDeHorasContratadasPorSemana();
                    var regla05 = objContrato.determinarValorHora(objEmpleado);
                    objGestionarContratoManejador.CrearContrato(objContrato);
                    MessageBox.Show("Se guardo el nuevo contrato");
                    this.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo crear el contrato" + ex);
                }
            }
            else if (Editarse == true)
            {
                try
                {
                    objContrato.CodigoContrato = CodigoContrato;
                    objContrato.FechaInicio = dtpFechaInicio.Value;
                    objContrato.FechaFin = dtpFechaFin.Value;
                    objContrato.Cargo = txtCargo.Text;
                    if (rdSi.Checked)
                    {
                        objContrato.AsignacionFamiliar = "Si";
                    }
                    else if (rdNo.Checked)
                    {
                        objContrato.AsignacionFamiliar = "No";
                    }
                    objContrato.TotalDeHorasContratadasPorSemanas = Convert.ToDouble(nbTotalHoras.Value);
                    objContrato.ValorHora = Convert.ToDouble(nbValorHora.Value);
                    objContrato.CodigoAFP = Convert.ToString(cmbAFP.SelectedValue);
                    objContrato.Estado = "Vigente";
                    objContrato.CodigoEmpleado = CodigoEmpleado;
                    objContrato.CodigoPeriodo = "1";

                    objEmpleado.GradoAcademico = GradoAcademico;

                    var regla03 = objContrato.determinarFechaFin();
                    var regla04 = objContrato.determinarTotalDeHorasContratadasPorSemana();
                    var regla05 = objContrato.determinarValorHora(objEmpleado);

                    objGestionarContratoManejador.EditarContrato(objContrato);
                    MessageBox.Show("Se guardó las modificaciones del contrato");
                    this.Close();
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudieron guardar las modificaciones del contrato" + ex);
                }
            }
        }

        //Metodo ListarAFP
        public void ListarAFP()
        {
            cmbAFP.DataSource = objGestionarContratoManejador.ListarAFP();
            cmbAFP.DisplayMember = "NombreAFP";
            cmbAFP.ValueMember = "CodigoAFP";
        }

        //Radio Butttons Control
        private void rdSi_CheckedChanged(object sender, EventArgs e)
        {
            if (rdSi.Checked == true)
            {
                objContrato.AsignacionFamiliar = "Si";
            }
        }

        private void rdNo_CheckedChanged(object sender, EventArgs e)
        {
            if (rdNo.Checked == true)
            {
                objContrato.AsignacionFamiliar = "No";
            }
        }

        //Boton Cancelar
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
