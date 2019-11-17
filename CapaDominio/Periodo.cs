using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDominio
{
    public class Periodo
    {
        //Atributos
        private string codigoPeriodo;
        private DateTime fechaInicio;
        private DateTime fechaFin;
        private Boolean estado;

        //Campos Encapsulados
        public string CodigoPeriodo { get => codigoPeriodo; set => codigoPeriodo = value; }
        public DateTime FechaInicio { get => fechaInicio; set => fechaInicio = value; }
        public DateTime FechaFin { get => fechaFin; set => fechaFin = value; }
        public bool Estado { get => estado; set => estado = value; }
    }
}
