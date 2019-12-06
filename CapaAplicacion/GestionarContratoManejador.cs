using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Librerias para la conexion a base de datos
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
//Referencia a Capas
using CapaDominio;
using CapaPersistencia;

namespace CapaAplicacion
{
    public class GestionarContratoManejador
    {
        ContratoDAO objContratoDAO = new ContratoDAO();
        AfpDAO objAfpDAO = new AfpDAO();
        
        EmpleadoDAO objEmpleadoDAO = new EmpleadoDAO();

        //Metodo BuscarEmpleado

        public bool BuscarEmpleado(Empleado objEmpleado)
        {
            return objEmpleadoDAO.BuscarEmpleado(objEmpleado);
        }


        //Metodo ListarAFP
        public DataTable ListarAFP()
        {
            return objAfpDAO.ListarAFP();
        }

        //Mostrar Contrato Empleado
        public DataTable MostrarContratoEmpleado(Contrato objContrato)
        {
            return objContratoDAO.MostrarContratoEmpleado(objContrato);
        }

        //Crear Contrato
        public void CrearContrato(Contrato objContrato)
        {
            objContratoDAO.CrearContrato(objContrato);
        }
        //Editar Contrato
        public void EditarContrato(Contrato objContrato)
        {
            objContratoDAO.EditarContrato(objContrato);
        }
        //Anular Contrato
        public void AnularContrato(Contrato objContrato)
        {
            objContratoDAO.AnularContrato(objContrato);
        }

        //Mostrar Contrato del Periodo
        public DataTable MostrarContratoDelPeriodo(Periodo objPeriodo)
        {
            return objContratoDAO.MostrarContratoDelPeriodo(objPeriodo);
        }
    }
}
