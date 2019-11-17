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
    public class ContratoTests
    {
        //Pruebas Unitarias del metodo elContratoEstaVigente()

        //Complejidad Ciclomatica = 3
        [TestMethod()]
        public void elContratoEstaVigenteTest_1()
        {
            Contrato objContrato = new Contrato();
            objContrato.FechaInicio = DateTime.Parse("2019-08-20");
            objContrato.FechaFin = DateTime.Parse("2019-09-01");
            objContrato.Estado = "Vigente";
            bool resultadoEsperado = true;
            bool estaVigente = objContrato.elContratoEstaVigente();
            Assert.AreEqual(estaVigente, resultadoEsperado);
        }

        [TestMethod()]
        public void elContratoEstaVigenteTest_2()
        {
            Contrato objContrato = new Contrato();
            objContrato.FechaInicio = DateTime.Parse("2020-09-01");
            objContrato.FechaFin = DateTime.Parse("2019-08-20");
            objContrato.Estado = "Vigente";
            bool resultadoEsperado = false;
            bool estaVigente = objContrato.elContratoEstaVigente();
            Assert.AreEqual(estaVigente, resultadoEsperado);
        }

        [TestMethod()]
        public void elContratoEstaVigenteTest_3()
        {
            Contrato objContrato = new Contrato();
            objContrato.FechaFin = DateTime.Parse("2019-09-01");
            objContrato.FechaInicio = DateTime.Parse("2020-01-20");
            objContrato.Estado = "Anulado";
            bool resultadoEsperado = false;
            bool estaVigente = objContrato.elContratoEstaVigente();
            Assert.AreEqual(estaVigente, resultadoEsperado);
        }

        //Pruebas Unitarias del metodo determinarFechaInicio()

        //Complejidad Ciclomatica = 3
        [TestMethod()]
        public void determinarFechaInicioTest_1()
        {
            Contrato objContrato = new Contrato();
            objContrato.FechaFin = DateTime.Parse("2019-01-20");
            DateTime fechaFinAnterior = objContrato.FechaFin;
            objContrato.FechaInicio = DateTime.Parse("2019-09-01");
            bool resultadoEsperado = true;
            bool fechaFin = objContrato.determinarFechaInicio();
            Assert.AreEqual(fechaFin, resultadoEsperado);
        }

        [TestMethod()]
        public void determinarFechaInicioTest_2()
        {
            Contrato objContrato = new Contrato();

            objContrato.FechaInicio = DateTime.Parse("2019-09-01");
            bool resultadoEsperado = true;
            bool fechaFin = objContrato.determinarFechaInicio();
            Assert.AreEqual(fechaFin, resultadoEsperado);
        }

        [TestMethod()]
        public void determinarFechaInicioTest_3()
        {
            Contrato objContrato = new Contrato();
            objContrato.FechaFin = DateTime.Parse("2020-01-20");
            DateTime fechaFinAnterior = objContrato.FechaFin;
            objContrato.FechaInicio = DateTime.Parse("2019-09-01");
            bool resultadoEsperado = false;
            bool fechaFin = objContrato.determinarFechaInicio();
            Assert.AreEqual(fechaFin, resultadoEsperado);
        }
        //Pruebas Unitarias del metodo determinarFechaFin()

        //Complejidad Ciclomatica = 3
        [TestMethod()]
        public void determinarFechaFinTest_1()
        {
            Contrato objContrato = new Contrato();
            objContrato.FechaFin = DateTime.Parse("2020-01-20");
            objContrato.FechaInicio = DateTime.Parse("2019-09-01");
            bool resultadoEsperado = true;
            bool fechaFin = objContrato.determinarFechaFin();
            Assert.AreEqual(fechaFin, resultadoEsperado);
        }

        [TestMethod()]
        public void determinarFechaFinTest_2()
        {
            Contrato objContrato = new Contrato();
            objContrato.FechaFin = DateTime.Parse("2019-08-20");
            objContrato.FechaInicio = DateTime.Parse("2019-09-01");
            bool resultadoEsperado = false;
            bool fechaFin = objContrato.determinarFechaFin();
            Assert.AreEqual(fechaFin, resultadoEsperado);
        }

        [TestMethod()]
        public void determinarFechaFinTest_3()
        {
            Contrato objContrato = new Contrato();
            objContrato.FechaFin = DateTime.Parse("2021-01-20");
            objContrato.FechaInicio = DateTime.Parse("2019-09-01");
            bool resultadoEsperado = false;
            bool fechaFin = objContrato.determinarFechaFin();
            Assert.AreEqual(fechaFin, resultadoEsperado);
        }

        //Pruebas Unitarias del metodo determinarTotalDeHorasContratadasPorSemana()

        //Complejidad Ciclomatica = 3
        [TestMethod()]
        public void determinarTotalDeHorasContratadasPorSemanaTest_1()
        {
            Contrato objContrato = new Contrato();
            objContrato.TotalDeHorasContratadasPorSemanas = 9;
            bool resultadoEsperado = true;
            bool resultadoObtenido = objContrato.determinarTotalDeHorasContratadasPorSemana();
            Assert.AreEqual(resultadoObtenido, resultadoEsperado);
        }

        [TestMethod()]
        public void determinarTotalDeHorasContratadasPorSemanaTest_2()
        {
            Contrato objContrato = new Contrato();
            objContrato.TotalDeHorasContratadasPorSemanas = 7;
            bool resultadoEsperado = false;
            bool resultadoObtenido = objContrato.determinarTotalDeHorasContratadasPorSemana();
            Assert.AreEqual(resultadoObtenido, resultadoEsperado);
        }

        [TestMethod()]
        public void determinarTotalDeHorasContratadasPorSemanaTest_3()
        {
            Contrato objContrato = new Contrato();
            objContrato.TotalDeHorasContratadasPorSemanas = 41;
            bool resultadoEsperado = false;
            bool resultadoObtenido = objContrato.determinarTotalDeHorasContratadasPorSemana();
            Assert.AreEqual(resultadoObtenido, resultadoEsperado);
        }

        //Pruebas Unitarias del metodo determinarValorHora()

        //Complejidad Ciclomatica = 12

        [TestMethod()]
        public void determinarValorHoraTest()
        {
            Contrato objContrato = new Contrato();
            Empleado objEmpleado = new Empleado();
            objEmpleado.GradoAcademico1 = "primaria";
            objContrato.ValorHora = 6;
            bool resultadoEsperado = true;
            bool resultadoObtenido = objContrato.determinarValorHora(objEmpleado);
            Assert.AreEqual(resultadoObtenido, resultadoEsperado);
        }

        [TestMethod()]
        public void determinarValorHoraTest_2()
        {
            Contrato objContrato = new Contrato();
            Empleado objEmpleado = new Empleado();
            objEmpleado.GradoAcademico1 = "secundaria";
            objContrato.ValorHora = 9;
            bool resultadoEsperado = true;
            bool resultadoObtenido = objContrato.determinarValorHora(objEmpleado);
            Assert.AreEqual(resultadoObtenido, resultadoEsperado);
        }

        [TestMethod()]
        public void determinarValorHoraTest_3()
        {
            Contrato objContrato = new Contrato();
            Empleado objEmpleado = new Empleado();
            objEmpleado.GradoAcademico1 = "bachiller";
            objContrato.ValorHora = 12;
            bool resultadoEsperado = true;
            bool resultadoObtenido = objContrato.determinarValorHora(objEmpleado);
            Assert.AreEqual(resultadoObtenido, resultadoEsperado);
        }


        [TestMethod()]
        public void determinarValorHoraTest_4()
        {
            Contrato objContrato = new Contrato();
            Empleado objEmpleado = new Empleado();
            objEmpleado.GradoAcademico1 = "profesional";
            objContrato.ValorHora = 21;
            bool resultadoEsperado = true;
            bool resultadoObtenido = objContrato.determinarValorHora(objEmpleado);
            Assert.AreEqual(resultadoObtenido, resultadoEsperado);
        }

        [TestMethod()]
        public void determinarValorHoraTest_5()
        {
            Contrato objContrato = new Contrato();
            Empleado objEmpleado = new Empleado();
            objEmpleado.GradoAcademico1 = "magister";
            objContrato.ValorHora = 31;
            bool resultadoEsperado = true;
            bool resultadoObtenido = objContrato.determinarValorHora(objEmpleado);
            Assert.AreEqual(resultadoObtenido, resultadoEsperado);
        }

        [TestMethod()]
        public void determinarValorHoraTest_6()
        {
            Contrato objContrato = new Contrato();
            Empleado objEmpleado = new Empleado();
            objEmpleado.GradoAcademico1 = "doctor";
            objContrato.ValorHora = 41;
            bool resultadoEsperado = true;
            bool resultadoObtenido = objContrato.determinarValorHora(objEmpleado);
            Assert.AreEqual(resultadoObtenido, resultadoEsperado);
        }

        //nuevos
        [TestMethod()]
        public void determinarValorHoraTest_7()
        {
            Contrato objContrato = new Contrato();
            Empleado objEmpleado = new Empleado();
            objEmpleado.GradoAcademico1 = "primaria";
            objContrato.ValorHora = 4;
            bool resultadoEsperado = false;
            bool resultadoObtenido = objContrato.determinarValorHora(objEmpleado);
            Assert.AreEqual(resultadoObtenido, resultadoEsperado);
        }

        [TestMethod()]
        public void determinarValorHoraTest_8()
        {
            Contrato objContrato = new Contrato();
            Empleado objEmpleado = new Empleado();
            objEmpleado.GradoAcademico1 = "secundaria";
            objContrato.ValorHora = 11;
            bool resultadoEsperado = false;
            bool resultadoObtenido = objContrato.determinarValorHora(objEmpleado);
            Assert.AreEqual(resultadoObtenido, resultadoEsperado);
        }

        [TestMethod()]
        public void determinarValorHoraTest_9()
        {
            Contrato objContrato = new Contrato();
            Empleado objEmpleado = new Empleado();
            objEmpleado.GradoAcademico1 = "bachiller";
            objContrato.ValorHora = 10;
            bool resultadoEsperado = false;
            bool resultadoObtenido = objContrato.determinarValorHora(objEmpleado);
            Assert.AreEqual(resultadoObtenido, resultadoEsperado);
        }


        [TestMethod()]
        public void determinarValorHoraTest_10()
        {
            Contrato objContrato = new Contrato();
            Empleado objEmpleado = new Empleado();
            objEmpleado.GradoAcademico1 = "profesional";
            objContrato.ValorHora = 20;
            bool resultadoEsperado = false;
            bool resultadoObtenido = objContrato.determinarValorHora(objEmpleado);
            Assert.AreEqual(resultadoObtenido, resultadoEsperado);
        }

        [TestMethod()]
        public void determinarValorHoraTest_11()
        {
            Contrato objContrato = new Contrato();
            Empleado objEmpleado = new Empleado();
            objEmpleado.GradoAcademico1 = "magister";
            objContrato.ValorHora = 30;
            bool resultadoEsperado = false;
            bool resultadoObtenido = objContrato.determinarValorHora(objEmpleado);
            Assert.AreEqual(resultadoObtenido, resultadoEsperado);
        }

        [TestMethod()]
        public void determinarValorHoraTest_12()
        {
            Contrato objContrato = new Contrato();
            Empleado objEmpleado = new Empleado();
            objEmpleado.GradoAcademico1 = "doctor";
            objContrato.ValorHora = 40;
            bool resultadoEsperado = false;
            bool resultadoObtenido = objContrato.determinarValorHora(objEmpleado);
            Assert.AreEqual(resultadoObtenido, resultadoEsperado);
        }
    }
}