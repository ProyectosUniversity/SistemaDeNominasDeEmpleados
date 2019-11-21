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

namespace CapaAplicacion
{
    public class GestionarPeriodoManejador
    {
        PeriodoDAO objPeriodoDAO = new PeriodoDAO();

        public DataTable listarPeriodo()
        {
            return objPeriodoDAO.ListarPeriodo();
        }
    }
}
