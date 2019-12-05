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
    public class PeriodoTests
    {
        //Pruebas Unitarias del metodo elPeriodoEstaActivo()

        //Complejidad Ciclomatica = 2
        [TestMethod()]
        public void elPeriodoEstaActivoTest1()
        {
            Periodo objPeriodo = new Periodo();
            Contrato objContrato = new Contrato();
            DateTime fechaActual = DateTime.Now;
            objContrato.FechaFin = DateTime.Parse("2019-11-15");
            bool resultadoEsperado = true;
            bool estaActivo = objPeriodo.elPeriodoEstaActivo(objContrato);
            Assert.AreEqual(estaActivo, resultadoEsperado);
        }

        [TestMethod()]
        public void elPeriodoEstaActivoTest2()
        {
            Periodo objPeriodo = new Periodo();
            Contrato objContrato = new Contrato();
            DateTime fechaActual = DateTime.Now;
            objContrato.FechaFin = DateTime.Parse("2019-12-20");
            bool resultadoEsperado = false;
            bool estaActivo = objPeriodo.elPeriodoEstaActivo(objContrato);
            Assert.AreEqual(estaActivo, resultadoEsperado);
        }
    }
}