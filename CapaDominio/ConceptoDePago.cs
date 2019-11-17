using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDominio
{
    public class ConceptoDePago
    {
        //Atributos
        string codigoConceptoPago;
        double montoPorHorasExtra;
        double montoPorReintegros;
        double montoDeOtrosIngresos;
        double montoPorHorasAusentes;
        double montoPorAdelantos;
        double montoDeOtrosDescuentos;
        double sumaDeConceptosDeIngresos;
        double sumaDeConceptosDeDescuentos;
        string codigoPeriodo;
        string codigoBoleta;

        //Campos Encapsulados
        public string CodigoConceptoPago { get => codigoConceptoPago; set => codigoConceptoPago = value; }
        public double MontoPorHorasExtra { get => montoPorHorasExtra; set => montoPorHorasExtra = value; }
        public double MontoPorReintegros { get => montoPorReintegros; set => montoPorReintegros = value; }
        public double MontoDeOtrosIngresos { get => montoDeOtrosIngresos; set => montoDeOtrosIngresos = value; }
        public double MontoPorHorasAusentes { get => montoPorHorasAusentes; set => montoPorHorasAusentes = value; }
        public double MontoPorAdelantos { get => montoPorAdelantos; set => montoPorAdelantos = value; }
        public double MontoDeOtrosDescuentos { get => montoDeOtrosDescuentos; set => montoDeOtrosDescuentos = value; }
        public string CodigoPeriodo { get => codigoPeriodo; set => codigoPeriodo = value; }
        public string CodigoBoleta { get => codigoBoleta; set => codigoBoleta = value; }
        public double SumaDeConceptosDeIngresos { get => sumaDeConceptosDeIngresos; set => sumaDeConceptosDeIngresos = value; }
        public double SumaDeConceptosDeDescuentos { get => sumaDeConceptosDeDescuentos; set => sumaDeConceptosDeDescuentos = value; }


        //Regla 09
        public double calcularConceptosDeIngresos()
        {
            return MontoPorHorasExtra + MontoPorReintegros + MontoDeOtrosIngresos;
        }

        //Regla 10
        public double calcularConceptosDeDescuentos()
        {
            return MontoPorHorasAusentes + MontoPorAdelantos + MontoDeOtrosDescuentos;
        }
    }
}
