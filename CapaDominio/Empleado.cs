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
        public string CodigoEmpleado;
        public string DNI;
        public string Nombre;
        public string Direccion;
        public string Telefono;
        public string FechaDeNacimiento;
        public string EstadoCivil;
        public string GradoAcademico;

        //Encapsulacion de Campos
        public string CodigoEmpleado1 { get => CodigoEmpleado; set => CodigoEmpleado = value; }
        public string DNI1 { get => DNI; set => DNI = value; }
        public string Nombre1 { get => Nombre; set => Nombre = value; }
        public string Direccion1 { get => Direccion; set => Direccion = value; }
        public string Telefono1 { get => Telefono; set => Telefono = value; }
        public string FechaDeNacimiento1 { get => FechaDeNacimiento; set => FechaDeNacimiento = value; }
        public string EstadoCivil1 { get => EstadoCivil; set => EstadoCivil = value; }
        public string GradoAcademico1 { get => GradoAcademico; set => GradoAcademico = value; }
    }
}
