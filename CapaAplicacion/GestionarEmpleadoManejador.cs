using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Librerias para la conexion a base de datos
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
//Referencia a CapaDominio
using CapaPersistencia;
using CapaDominio;

namespace CapaAplicacion
{
    public class GestionarEmpleadoManejador
    {
        EmpleadoDAO objEmpleadoDAO = new EmpleadoDAO();

        //Metodo BuscarEmpleado

        public bool BuscarEmpleado(Empleado objEmpleado)
        {
            return objEmpleadoDAO.BuscarEmpleado(objEmpleado);
        }

    }
}
