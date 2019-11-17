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
    public class ConceptoDePagoTests
    {
        [TestMethod()]
        public void calcularConceptosDeIngresosTest()
        {
            ConceptoDePago objConceptoDePago = new ConceptoDePago();
            objConceptoDePago.MontoPorHorasExtra = 8;
            objConceptoDePago.MontoPorReintegros = 10;
            objConceptoDePago.MontoDeOtrosIngresos = 10;
            double resultadoEsperado = 28;
            double conceptoDeIngreso = objConceptoDePago.calcularConceptosDeIngresos();
            Assert.AreEqual(conceptoDeIngreso, resultadoEsperado);
        }

        [TestMethod()]
        public void calcularConceptosDeDescuentosTest()
        {
            ConceptoDePago objConceptoDePago = new ConceptoDePago();
            objConceptoDePago.MontoPorHorasAusentes = 5;
            objConceptoDePago.MontoPorAdelantos = 10;
            objConceptoDePago.MontoDeOtrosDescuentos = 10;
            double resultadoEsperado = 25;
            double conceptoDeDescuento = objConceptoDePago.calcularConceptosDeDescuentos();
            Assert.AreEqual(conceptoDeDescuento, resultadoEsperado);
        }
    }
}