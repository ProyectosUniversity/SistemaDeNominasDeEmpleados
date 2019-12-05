using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDominio
{
    public class Empleado
    {
        //Atributos
        private string codigoEmpleado;
        private string dNI;
        private string nombre;
        private string direccion;
        private string telefono;
        private string fechaDeNacimiento;
        private string estadoCivil;
        private string gradoAcademico;

        //Encapsulacion de Campos
        public string CodigoEmpleado { get => codigoEmpleado; set => codigoEmpleado = value; }
        public string DNI { get => dNI; set => dNI = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string FechaDeNacimiento { get => fechaDeNacimiento; set => fechaDeNacimiento = value; }
        public string EstadoCivil { get => estadoCivil; set => estadoCivil = value; }
        public string GradoAcademico { get => gradoAcademico; set => gradoAcademico = value; }

       
    }
}
