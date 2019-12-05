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
    public class EmpleadoDAO:Conexion
    {
        //Buscar Empleado

        public bool BuscarEmpleado(Empleado objEmpleado)
        {
            using (var conexion = GetConnection())
            {
                conexion.Open();
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = conexion;
                    cmd.CommandText = "Contratos.spBuscarEmpleado";
                    cmd.Parameters.AddWithValue("@DNIEmpleado", objEmpleado.DNI);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            objEmpleado.CodigoEmpleado = reader.GetString(0);
                            objEmpleado.Nombre = reader.GetString(1);
                            objEmpleado.Direccion = reader.GetString(2);
                            objEmpleado.Telefono = reader.GetString(3);
                            objEmpleado.FechaDeNacimiento = reader.GetString(4);
                            objEmpleado.EstadoCivil = reader.GetString(5);
                            objEmpleado.GradoAcademico = reader.GetString(6);

                        }
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
            }
        }
    }
}
