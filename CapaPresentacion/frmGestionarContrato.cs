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
    public partial class frmGestionarContrato : Form
    {
        public frmGestionarContrato()
        {
            InitializeComponent();
        }

        //Objetos de la CapaAplicacion
        GestionarEmpleadoManejador objGestionarEmpleado = new GestionarEmpleadoManejador();

        //Objetos de la CapaDominio
        Empleado objEmpleado = new Empleado();
        Contrato objContrato = new Contrato();
        //Formulario
        frmDatosContrato frmContrato = new frmDatosContrato();

        //Buscar Empleado
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (objEmpleado.DNI1 != "")
            {
                objEmpleado.DNI1 = txtBuscarEmpleado.Text;
                var validarCajaTexto = objGestionarEmpleado.BuscarEmpleado(objEmpleado);
                if (validarCajaTexto == true)
                {
                    txtBuscarEmpleado.Clear();
                    objContrato.CodigoEmpleado = objEmpleado.CodigoEmpleado1;
                    lbNombre.Text = objEmpleado.Nombre1;
                    lbDireccion.Text = objEmpleado.Direccion1;
                    lbTelefono.Text = objEmpleado.Telefono1;
                    lbFechaNacimiento.Text = objEmpleado.FechaDeNacimiento1;
                    lbEstadoCivil.Text = objEmpleado.EstadoCivil1;
                    lbGradoAcademico.Text = objEmpleado.GradoAcademico1;

                    MostrarContratoEmpleado(objContrato);
                    //Habilitar opciones
                    btnCrearContrato.Enabled = true;
                    btnEditarContrato.Enabled = true;
                    btnAnularContrato.Enabled = true;

                }
                else
                {
                    MessageBox.Show("No existe el empleado");
                }
            }
            else
            {
                MessageBox.Show("Ingresa un numero de DNI");
            }
        }

        //Mostrar Contrato de Empleado
        public void MostrarContratoEmpleado(Contrato objContrato)
        {
            //Mostrar Datos del Contrato
            GestionarContratoManejador objGestionarContrato = new GestionarContratoManejador();
            dtContratos.DataSource = objGestionarContrato.MostrarContratoEmpleado(objContrato);
            dtContratos.Columns[0].Visible = false;
            dtContratos.Columns[8].Visible = false;

        }

        //Reglas de Negocio
        public bool regla01()
        {
            //var elContratoEstaVigente = objContrato.elContratoEstaVigente();
            objContrato.FechaInicio = Convert.ToDateTime(dtContratos.CurrentRow.Cells[1].Value.ToString());
            objContrato.FechaFin = Convert.ToDateTime(dtContratos.CurrentRow.Cells[2].Value.ToString());
            objContrato.Estado = dtContratos.CurrentRow.Cells[9].Value.ToString();
            var elContratoEstaVigente = objContrato.elContratoEstaVigente();
            if (elContratoEstaVigente == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Boton Crear Contrato
        private void btnCrearContrato_Click(object sender, EventArgs e)
        {

            if (dtContratos.SelectedRows.Count > 0)
            {
                var Regla01 = regla01();
                if (Regla01 == false)
                {
                    frmContrato.Editarse = false;
                    frmContrato.ListarAFP();
                    frmContrato.CodigoEmpleado = objEmpleado.CodigoEmpleado1;
                    frmContrato.GradoAcademico = objEmpleado.GradoAcademico1;
                    frmContrato.ShowDialog();
                    MostrarContratoEmpleado(objContrato);
                    
                }
                else
                {

                    MessageBox.Show("El contrato aun esta vigente.");
                }
            }
            else if (dtContratos.SelectedRows.Count < 1)
            {
                frmContrato.Editarse = false;
                frmContrato.ListarAFP();
                frmContrato.CodigoEmpleado = objEmpleado.CodigoEmpleado1;
                frmContrato.GradoAcademico = objEmpleado.GradoAcademico1;
                frmContrato.ShowDialog();
            }
            else
            {
                MessageBox.Show("No es posible crear un nuevo contrato.");
            }
        }

        //Boton Editar Contrato
        private void btnEditarContrato_Click(object sender, EventArgs e)
        {
            if (dtContratos.SelectedRows.Count > 0)
            {
                var Regla01 = regla01();
                if (Regla01 == true)
                { 
                    //Validar Edicion
                    frmContrato.Editarse = true;
                //Enviar Datos
                frmContrato.CodigoContrato = dtContratos.CurrentRow.Cells[0].Value.ToString();
                frmContrato.dtpFechaInicio.Value = Convert.ToDateTime(dtContratos.CurrentRow.Cells[1].Value.ToString());
                frmContrato.dtpFechaFin.Value = Convert.ToDateTime(dtContratos.CurrentRow.Cells[2].Value.ToString());
                frmContrato.txtCargo.Text = dtContratos.CurrentRow.Cells[3].Value.ToString();
                objContrato.AsignacionFamiliar = dtContratos.CurrentRow.Cells[4].Value.ToString();
                if (objContrato.AsignacionFamiliar == "Si")
                {
                    frmContrato.rdSi.Checked = true;
                    frmContrato.rdNo.Checked = false;
                }
                else if (objContrato.AsignacionFamiliar == "No")
                {
                    frmContrato.rdSi.Checked = false;
                    frmContrato.rdNo.Checked = true;
                }
                frmContrato.ListarAFP();
                frmContrato.nbTotalHoras.Value = Convert.ToDecimal(dtContratos.CurrentRow.Cells[6].Value.ToString());
                frmContrato.nbValorHora.Value = Convert.ToDecimal(dtContratos.CurrentRow.Cells[7].Value.ToString());
                frmContrato.CodigoEmpleado = objEmpleado.CodigoEmpleado1;
                frmContrato.GradoAcademico = objEmpleado.GradoAcademico1;
                //Abrir Formulario
                frmContrato.ShowDialog();
                MostrarContratoEmpleado(objContrato);
                }
                else
                {
                    MessageBox.Show("No se puede editar un contrato anulado.");
                }
            }
            else
            {
                MessageBox.Show("Elije un contrato para editar.");
            }
        }

        private void btnAnularContrato_Click(object sender, EventArgs e)
        {
            GestionarContratoManejador objGestionarContratoManejador = new GestionarContratoManejador();
            if (dtContratos.SelectedRows.Count > 0)
            {
                objContrato.CodigoContrato = dtContratos.CurrentRow.Cells[0].Value.ToString();
                objGestionarContratoManejador.AnularContrato(objContrato);
                MessageBox.Show("Se anuló el contrato");
                MostrarContratoEmpleado(objContrato);
            }
            else
            {
                MessageBox.Show("No se pudo anular el contrato.");
            }
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            lbVer.Text = dtContratos.CurrentRow.Cells[9].Value.ToString();
        }
    }
}
