using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDominio
{
    public class AFP
    {
        //Atributos
        string CodigoAFP;
        string NombreAFP;
        double PorcentajeDeDescuento;

        //Encapsulamiento de Campos
        public string CodigoAFP1 { get => CodigoAFP; set => CodigoAFP = value; }
        public string NombreAFP1 { get => NombreAFP; set => NombreAFP = value; }
        public double PorcentajeDeDescuento1 { get => PorcentajeDeDescuento; set => PorcentajeDeDescuento = value; }
    }
}
