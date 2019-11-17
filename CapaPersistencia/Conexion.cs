using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Libreria SQL
using System.Data.SqlClient;

namespace CapaPersistencia
{
    public abstract class Conexion
    {
        private readonly string cadenadeconexion;

        //Crear conexion
        public Conexion()
        {
            cadenadeconexion = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SistemaDeNominas;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }

        //Obtener conexion
        protected SqlConnection GetConnection()
        {
            return new SqlConnection(cadenadeconexion);
        }
    }
}
