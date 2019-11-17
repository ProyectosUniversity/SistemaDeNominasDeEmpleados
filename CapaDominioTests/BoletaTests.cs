using Microsoft.VisualStudio.TestTools.UnitTesting;
using CapaDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDominio.Tests
{
    [TestClass()]
    public class BoletaTests
    {
        //Pruebas Unitarias del metodo elPeriodoEstaActivo()

        //Complejidad Ciclomatica = 2
        [TestMethod()]
        public void elPeriodoEstaActivoTest1()
        {
            Boleta objBoleta = new Boleta();
            Contrato objContrato = new Contrato();
            DateTime fechaActual = DateTime.Now;
            objContrato.FechaFin = DateTime.Parse("2019-11-15");
            bool resultadoEsperado = true;
            bool estaActivo = objBoleta.elPeriodoEstaActivo(objContrato);
            Assert.AreEqual(estaActivo, resultadoEsperado);
        }

        [TestMethod()]
        public void elPeriodoEstaActivoTest2()
        {
            Boleta objBoleta = new Boleta();
            Contrato objContrato = new Contrato();
            DateTime fechaActual = DateTime.Now;
            objContrato.FechaFin = DateTime.Parse("2019-12-20");
            bool resultadoEsperado = false;
            bool estaActivo = objBoleta.elPeriodoEstaActivo(objContrato);
            Assert.AreEqual(estaActivo, resultadoEsperado);
        }

        //Pruebas Unitarias del metodo calcularSueldoBasico()

        //Complejidad Ciclomatica = 1
        [TestMethod()]
        public void calcularSueldoBasicoTest()
        {
            Boleta objBoleta = new Boleta();
            Contrato objContrato = new Contrato();
            objBoleta.TotalDeHoras = 35;
            objContrato.ValorHora = 8;
            double resultadoEsperado = 280;
            double sueldoBasico = objBoleta.calcularSueldoBasico(objContrato);
            Assert.AreEqual(sueldoBasico, resultadoEsperado);
        }

        //Pruebas Unitarias del metodo calcularAsignacionFamiliar()

        //Complejidad Ciclomatica = 1
        [TestMethod()]
        public void calcularAsignacionFamiliarTest()
        {
            Boleta objBoleta = new Boleta();

            double resultadoEsperado = 93;
            double sueldoBasico = objBoleta.calcularAsignacionFamiliar();
            Assert.AreEqual(sueldoBasico, resultadoEsperado);
        }

        //Pruebas Unitarias del metodo calcularTotalDeIngresos()

        //Complejidad Ciclomatica = 1
        [TestMethod()]
        public void calcularTotalDeIngresosTest()
        {
            Boleta objBoleta = new Boleta();
            ConceptoDePago objConceptoDePago = new ConceptoDePago();
            objBoleta.SueldoBasico = 280;
            objBoleta.AsignacionFamiliar = 93;
            objConceptoDePago.SumaDeConceptosDeIngresos = 28;
            double resultadoEsperado = 401;
            double totalDeIngresos = objBoleta.calcularTotalDeIngresos(objConceptoDePago);
            Assert.AreEqual(totalDeIngresos, resultadoEsperado);
        }

        //Pruebas Unitarias del metodo calcularDescuentoPorAFP()

        //Complejidad Ciclomatica = 1
        [TestMethod()]
        public void calcularDescuentoPorAFPTest()
        {
            Boleta objBoleta = new Boleta();
            AFP objAFP = new AFP();
            objBoleta.SueldoBasico = 280;
            objAFP.PorcentajeDeDescuento1 = 0.1;
            double resultadoEsperado = 28;
            double totalDeDescuentos = objBoleta.calcularDescuentoPorAFP(objAFP);
            Assert.AreEqual(totalDeDescuentos, resultadoEsperado);
        }

        //Pruebas Unitarias del metodo calcularTotalDeDescuentos()

        //Complejidad Ciclomatica = 1
        [TestMethod()]
        public void calcularTotalDeDescuentosTest()
        {

            Boleta objBoleta = new Boleta();
            ConceptoDePago objConceptoDePago = new ConceptoDePago();
            objBoleta.DescuentoPorAFP = 28;
            objConceptoDePago.SumaDeConceptosDeDescuentos = 25;
            double resultadoEsperado = 53;
            double totalDeDescuentos = objBoleta.calcularTotalDeDescuentos(objConceptoDePago);
            Assert.AreEqual(totalDeDescuentos, resultadoEsperado);
        }

        //Pruebas Unitarias del metodo calcularSueldoNeto()

        //Complejidad Ciclomatica = 1
        [TestMethod()]
        public void calcularSueldoNetoTest()
        {
            Boleta objBoleta = new Boleta();
            objBoleta.TotalDeIngresos = 401;
            objBoleta.TotalDeDescuentos = 53;
            double resultadoEsperado = 454;
            double sueldoNeto = objBoleta.calcularSueldoNeto();
            Assert.AreEqual(sueldoNeto, resultadoEsperado);
        }

        //Pruebas Unitarias del metodo calcularTotalDeHoras()

        //Complejidad Ciclomatica = 1
        [TestMethod()]
        public void calcularTotalDeHorasTest()
        {
            Boleta objBoleta = new Boleta();
            Contrato objContrato = new Contrato();
            Periodo objPeriodo = new Periodo();
            objPeriodo.FechaFin = DateTime.Parse("2020-05-05");
            objPeriodo.FechaInicio = DateTime.Parse("2019-08-20");
            objContrato.TotalDeHorasContratadasPorSemanas = 40;
            double resultadoEsperado = 1480;
            double totalDeHoras = objBoleta.calcularTotalDeHoras(objContrato, objPeriodo);
            Assert.AreEqual(totalDeHoras, resultadoEsperado);
        }
    }
}