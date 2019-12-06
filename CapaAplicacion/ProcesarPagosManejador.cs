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
using CapaDominio;
using CapaPersistencia;

namespace CapaAplicacion
{
    public class ProcesarPagosManejador
    {
        PeriodoDAO objPeriodoDAO = new PeriodoDAO();
        BoletaDAO objBoletaDAO = new BoletaDAO();

        //Listar Periodos
        public DataTable listarPeriodo()
        {
            return objPeriodoDAO.ListarPeriodo();
        }
        //ListarBoletas
        public DataTable listarBoletas(Periodo objPeriodo)
        {
            return objBoletaDAO.MostrarContratosDelPeriodo(objPeriodo);
        }

        //InsertarBoletas
        public void insertarBoleta(List<Boleta> listaBoleta)
        {
            objBoletaDAO.insertarBoleta(listaBoleta);
        }
    }
}
