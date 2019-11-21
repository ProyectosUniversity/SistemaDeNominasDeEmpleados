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

namespace CapaPersistencia
{
    public class PeriodoDAO:Conexion
    {
        SqlDataReader leer;
        DataTable tabla = new DataTable();
        public DataTable ListarPeriodo()
        {
            using (var conexion = GetConnection())
            {
                conexion.Open();
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = conexion;
                    cmd.CommandText = "Contratos.MostrarPeriodo";
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
