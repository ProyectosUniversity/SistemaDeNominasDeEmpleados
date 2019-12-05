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

        //Objetos de la Capa de Aplicacion
        GestionarContratoManejador objGestionarContratoManejador = new GestionarContratoManejador();
        ProcesarPagosManejador objProcresarPagosManejador = new ProcesarPagosManejador();
        //Objetos de la Capa de Dominio
        AFP objAFP = new AFP();
        Boleta objBoleta = new Boleta();
        Periodo objPeriodo = new Periodo();
        Contrato objContrato = new Contrato();
        ConceptoDePago objConceptoDePago = new ConceptoDePago();

        //Metodos que se ejecutaran al cargar el formulario
        private void frmProcesarPagos_Load(object sender, EventArgs e)
        {
            MostrarPeriodo();
            objPeriodo.FechaInicio = Convert.ToDateTime(dtFechas.CurrentRow.Cells[0].Value.ToString());
            objPeriodo.FechaFin = Convert.ToDateTime(dtFechas.CurrentRow.Cells[1].Value.ToString());
            MostrarContratoDelPeriodo(objPeriodo);
        }

        //Metodo para mostrar los datos del periodo
        public void MostrarPeriodo()
        {
            dtFechas.DataSource= objProcresarPagosManejador.listarPeriodo();
            dtFechas.Columns[2].Visible = false;
        }

        //Metodo para mostrar contratos que estan dentro del periodo
        public void MostrarContratoDelPeriodo(Periodo objPeriodo)
        {
           dtBoletas.DataSource= objGestionarContratoManejador.MostrarContratoDelPeriodo(objPeriodo);
           dtBoletas.Columns[0].Visible = false;
           dtBoletas.Columns[9].Visible = false;
        }

        //Funcion para procesar Datos del contrato
        public void ProcesarDatosDelContrato(List<Contrato> listaDeDatosDelContrato)
        {
            List<Boleta> objListaBoleta = new List<Boleta>();

            var lista = new DataTable();

            //Nombres de las columnas
            lista.Columns.Add("CodigoEmpleado", typeof(string));
            lista.Columns.Add("Total de Horas", typeof(double));
            lista.Columns.Add("Valor Hora", typeof(double));
            lista.Columns.Add("Sueldo Básico", typeof(double));
            lista.Columns.Add("Total de Ingresos", typeof(double));
            lista.Columns.Add("Total de Descuentos", typeof(double));
            lista.Columns.Add("Sueldo Neto", typeof(double));

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
                if (dato.AsignacionFamiliar == "Si")
                {
                    objBoleta.AsignacionFamiliar = objBoleta.calcularAsignacionFamiliar();
                }
                else
                {
                    objBoleta.AsignacionFamiliar = 0;
                }
                objBoleta.TotalDeIngresos = objBoleta.calcularTotalDeIngresos(objConceptoDePago);
                objAFP.PorcentajeDeDescuento1 = dato.PorcentajeDeDescuento1;
                objBoleta.DescuentoPorAFP = objBoleta.calcularDescuentoPorAFP(objAFP);
                objBoleta.TotalDeDescuentos = objBoleta.calcularTotalDeDescuentos(objConceptoDePago);
                objBoleta.SueldoNeto = objBoleta.calcularSueldoNeto();
                //Añadimos los datos calculados a una lista local
                lista.Rows.Add(new object[]
                {
                  dato.CodigoEmpleado,
                  objBoleta.TotalDeHoras,
                  dato.ValorHora,
                  objBoleta.SueldoBasico,
                  objBoleta.TotalDeIngresos,
                  objBoleta.TotalDeDescuentos,
                  objBoleta.SueldoNeto

                });
                objListaBoleta.Add(Boletas);
            }
            //Pasamos esos datos al dtComprobar para ver que se procesaen correctamente 
            dtBoletas.DataSource = lista;
            //Guardar(objListaBoleta);

        }

        //Boton para procesar el periodo
        private void btnProcesar_Click(object sender, EventArgs e)
        {
            List<Contrato> datosContrato = new List<Contrato>();

            foreach (DataGridViewRow fila in dtBoletas.Rows)
            {
                var objcontrato = new Contrato()
                {
                    CodigoContrato = Convert.ToString(fila.Cells[0].Value),
                    AsignacionFamiliar = Convert.ToString(fila.Cells[4].Value),
                    PorcentajeDeDescuento1= Convert.ToDouble(fila.Cells[6].Value),
                    TotalDeHorasContratadasPorSemanas = Convert.ToDouble(fila.Cells[7].Value),
                    ValorHora = Convert.ToDouble(fila.Cells[8].Value),
                    CodigoEmpleado = Convert.ToString(fila.Cells[9].Value)
                };
                datosContrato.Add(objcontrato);

            }
            ProcesarDatosDelContrato(datosContrato);
        }


    }
}
