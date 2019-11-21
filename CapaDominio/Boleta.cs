using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDominio
{
    public class Boleta
    {
        //Atributos
        string codigoBoleta;
        string fechaDePago;
        double sueldoBasico;
        double asignacionFamiliar;
        double totalDeIngresos;
        double descuentoPorAFP;
        double totalDeDescuentos;
        double sueldoNeto;
        double totalDeHoras;
        string codigoConceptoPago;
        string codigoPeriodo;
        string codigoContrato;

        //Campos Encapsulados
        public string CodigoBoleta { get => codigoBoleta; set => codigoBoleta = value; }
        public string FechaDePago { get => fechaDePago; set => fechaDePago = value; }
        public double SueldoBasico { get => sueldoBasico; set => sueldoBasico = value; }
        public double AsignacionFamiliar { get => asignacionFamiliar; set => asignacionFamiliar = value; }
        public double TotalDeIngresos { get => totalDeIngresos; set => totalDeIngresos = value; }
        public double DescuentoPorAFP { get => descuentoPorAFP; set => descuentoPorAFP = value; }
        public double TotalDeDescuentos { get => totalDeDescuentos; set => totalDeDescuentos = value; }
        public double SueldoNeto { get => sueldoNeto; set => sueldoNeto = value; }
        public double TotalDeHoras { get => totalDeHoras; set => totalDeHoras = value; }
        public string CodigoConceptoPago { get => codigoConceptoPago; set => codigoConceptoPago = value; }
        public string CodigoPeriodo { get => codigoPeriodo; set => codigoPeriodo = value; }
        public string CodigoContrato { get => codigoContrato; set => codigoContrato = value; }

        //REGLAS DE NEGOCIO

        //Regla 01
        public bool elPeriodoEstaActivo(Contrato objContrato)
        {
            DateTime fechaActual = DateTime.Now;
            if (fechaActual >= objContrato.FechaFin)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Regla 02
        public double calcularSueldoBasico(Contrato objContrato)
        {
            return TotalDeHoras * objContrato.ValorHora;
        }

        //Regla 03
        public double calcularAsignacionFamiliar()
        {
                double sueldoMinimo = 930;
                return sueldoMinimo * 0.1;
        }

        //Regla 04
        public double calcularTotalDeIngresos(ConceptoDePago objConceptoDePago)
        {
            return SueldoBasico + AsignacionFamiliar + objConceptoDePago.SumaDeConceptosDeIngresos;
        }

        //Regla 05
        public double calcularDescuentoPorAFP(AFP objAFP)
        {
            return SueldoBasico * objAFP.PorcentajeDeDescuento1;
        }
        //Regla 06
        public double calcularTotalDeDescuentos(ConceptoDePago objConceptoDePago)
        {
            return DescuentoPorAFP + objConceptoDePago.SumaDeConceptosDeDescuentos;
        }

        //Regla 07
        public double calcularSueldoNeto()
        {
            return TotalDeIngresos + TotalDeDescuentos;
        }

        //Regla 08
        public double calcularTotalDeHoras(Contrato objContrato,Periodo objPeriodo)
        {
            TimeSpan diasDelPeriodo = objPeriodo.FechaFin - objPeriodo.FechaInicio;
            int dias = diasDelPeriodo.Days;
            int totalDeSemanasDelPeriodo = dias / 7;

            return totalDeSemanasDelPeriodo * objContrato.TotalDeHorasContratadasPorSemanas;
        }

    }
}
