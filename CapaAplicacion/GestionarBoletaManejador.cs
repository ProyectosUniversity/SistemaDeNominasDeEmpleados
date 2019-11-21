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
    public class GestionarBoletaManejador
    {
        BoletaDAO objBoletaDAO = new BoletaDAO();

        //ListarBoletas
        public DataTable listarBoletas(Periodo objPeriodo)
        {
            return objBoletaDAO.ListarBoletas(objPeriodo);
        }

        //InsertarBoletas
        public void insertarBoleta(List<Boleta> listaBoleta)
        {
            objBoletaDAO.insertarBoleta(listaBoleta);
        }
    }
}
