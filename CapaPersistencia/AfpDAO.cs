using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Librerias para la conexion a base de datos
using System.Data;
using System.Data.SqlClient;
//Referencia a CapaDominio
using CapaDominio;

namespace CapaPersistencia
{
    public class AfpDAO:Conexion
    {
        //Metodo ListarAFP
        SqlDataReader leer;
        DataTable tabla = new DataTable();
        public DataTable ListarAFP()
        {
            using (var conexion = GetConnection())
            {
                conexion.Open();
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = conexion;
                    cmd.CommandText = "Pagos.spListarAFP";
                    cmd.CommandType = CommandType.StoredProcedure;
                    leer = cmd.ExecuteReader();
                    tabla.Load(leer);

                    conexion.Close();
                    leer.Close();
                    return tabla;
                }
            }
        }


    }
}
