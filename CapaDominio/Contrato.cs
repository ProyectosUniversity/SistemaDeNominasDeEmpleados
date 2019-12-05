using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CapaDominio
{
    public class Contrato
    {
        //Atributos
        private string codigoContrato;
        private DateTime fechaInicio;
        private DateTime fechaFin;
        private string cargo;
        private string asignacionFamiliar;
        private double totalDeHorasContratadasPorSemanas;
        private double valorHora;
        private string estado;
        private double PorcentajeDeDescuento;
        private string codigoPeriodo;
        private string codigoEmpleado;
        private string codigoAFP;


        //Campos Encapsulados
        public string CodigoContrato { get => codigoContrato; set => codigoContrato = value; }
        public DateTime FechaInicio { get => fechaInicio; set => fechaInicio = value; }
        public DateTime FechaFin { get => fechaFin; set => fechaFin = value; }
        public string Cargo { get => cargo; set => cargo = value; }
        public string AsignacionFamiliar { get => asignacionFamiliar; set => asignacionFamiliar = value; }
        public double TotalDeHorasContratadasPorSemanas { get => totalDeHorasContratadasPorSemanas; set => totalDeHorasContratadasPorSemanas = value; }
        public double ValorHora { get => valorHora; set => valorHora = value; }
        public string Estado { get => estado; set => estado = value; }
        public string CodigoPeriodo { get => codigoPeriodo; set => codigoPeriodo = value; }
        public string CodigoEmpleado { get => codigoEmpleado; set => codigoEmpleado = value; }
        public string CodigoAFP { get => codigoAFP; set => codigoAFP = value; }
        public double PorcentajeDeDescuento1 { get => PorcentajeDeDescuento; set => PorcentajeDeDescuento = value; }




        //Reglas de Negocio

        //Relga 01
        public bool elContratoEstaVigente()
        {
            if (FechaInicio < FechaFin && Estado != "Anulado")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Regla 02

        public bool determinarFechaInicio()
        {
            DateTime fechaFinAnterior = FechaFin;
            if (FechaInicio > fechaFinAnterior)
            {
                return true;
            }
            else if (fechaFinAnterior == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //Regla 03
        public bool determinarFechaFin()
        {
            TimeSpan nuevaFecha = FechaFin - FechaInicio;
            int dias = nuevaFecha.Days;

            if (dias >= 89 && dias <= 365)
            {
                return true;
            }
            else
                return false;
        }

        //Regla 04
        public bool determinarTotalDeHorasContratadasPorSemana()
        {
            if (TotalDeHorasContratadasPorSemanas >= 8 && TotalDeHorasContratadasPorSemanas <= 40)
            {
                return true;
            }
            else
                return false;
        }

        //Regla 05

        public bool determinarValorHora(Empleado objEmpleado)
        {
            if (objEmpleado.GradoAcademico == "primaria" || objEmpleado.GradoAcademico == "secundaria")
            {
                return ValorHora >= 5 &&
                    ValorHora <= 10;

            }
            else if (objEmpleado.GradoAcademico == "bachiller")
            {
                return ValorHora >= 11 && ValorHora <= 20;
            }
            else if (objEmpleado.GradoAcademico == "profesional")
            {
                return ValorHora >= 21 && ValorHora <= 30;
            }
            else if (objEmpleado.GradoAcademico == "magister")
            {
                return ValorHora >= 31 && ValorHora <= 40;
            }
            else if (objEmpleado.GradoAcademico == "doctor")
            {
                return ValorHora >= 41 && ValorHora <= 60;
            }
            else
            {
                return false;
            }
        }


    }
}

