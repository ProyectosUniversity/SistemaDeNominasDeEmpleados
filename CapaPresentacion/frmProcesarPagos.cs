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
        GestionarContratoManejador objGestionarContratoManejador = new GestionarContratoManejador();

        Boleta objBoleta = new Boleta();
        Periodo objPeriodo = new Periodo();
        Contrato objContrato = new Contrato();
        private void frmProcesarPagos_Load(object sender, EventArgs e)
        {
            MostrarPeriodo();
            objPeriodo.FechaInicio = Convert.ToDateTime(dtFechas.CurrentRow.Cells[0].Value.ToString());
            objPeriodo.FechaFin = Convert.ToDateTime(dtFechas.CurrentRow.Cells[1].Value.ToString());
            MostrarContratoDelPeriodo(objPeriodo);
        }

        public void MostrarPeriodo()
        {
            dtFechas.DataSource= objGestionarPeriodoManejador.listarPeriodo(); 
        }

        public void MostrarContratoDelPeriodo(Periodo objPeriodo)
        {
           dtBoletas.DataSource= objGestionarContratoManejador.MostrarContratoDelPeriodo(objPeriodo);
        }

        //Funcion para procesar Datos
        public void ProcesarDatosDelContrato(List<Contrato> listaDeDatosDelContrato)
        {
            List<Boleta> objListaBoleta = new List<Boleta>();

            var lista = new DataTable();

            //Nombres de las columnas
            lista.Columns.Add("CodigoEmpleado", typeof(string));
            lista.Columns.Add("Total de Horas", typeof(double));
            lista.Columns.Add("Valor Hora", typeof(double));
            lista.Columns.Add("Sueldo Básico", typeof(double));

            foreach (var dato in listaDeDatosDelContrato)
            {
                //Creamos la isntancia para Boleta
                var Boletas = new Boleta();
                //Reglas de negocio o calculos
                objPeriodo.FechaInicio = Convert.ToDateTime(dtFechas.CurrentRow.Cells[0].Value.ToString());
                objPeriodo.FechaFin = Convert.ToDateTime(dtFechas.CurrentRow.Cells[1].Value.ToString());
                objContrato.TotalDeHorasContratadasPorSemanas = dato.TotalDeHorasContratadasPorSemanas;
                objBoleta.TotalDeHoras = objBoleta.calcularTotalDeHoras(objContrato,objPeriodo);
                objContrato.ValorHora = dato.ValorHora;
                objBoleta.SueldoBasico = objBoleta.calcularSueldoBasico(objContrato);

                //Añadimos los datos calculados a una lista local
                lista.Rows.Add(new object[]
                {
                  dato.CodigoEmpleado,
                  objBoleta.TotalDeHoras,
                  dato.ValorHora,
                  objBoleta.SueldoBasico


                });
                objListaBoleta.Add(Boletas);
            }
            //Pasamos esos datos al dtComprobar para ver que se procesaen correctamente 
            dtBoletas.DataSource = lista;
            //Guardar(objListaBoleta);

        }

        //Boton Procesar Periodo
        private void btnProcesar_Click(object sender, EventArgs e)
        {
            List<Contrato> datosContrato = new List<Contrato>();

            foreach (DataGridViewRow fila in dtBoletas.Rows)
            {
                var objcontrato = new Contrato()
                {
                    CodigoContrato = Convert.ToString(fila.Cells[0].Value),
                    AsignacionFamiliar = Convert.ToString(fila.Cells[4].Value),
                    TotalDeHorasContratadasPorSemanas = Convert.ToDouble(fila.Cells[6].Value),
                    ValorHora = Convert.ToDouble(fila.Cells[7].Value),
                    CodigoEmpleado = Convert.ToString(fila.Cells[8].Value)
                };
                datosContrato.Add(objcontrato);

            }
            ProcesarDatosDelContrato(datosContrato);
        }
    }
}
