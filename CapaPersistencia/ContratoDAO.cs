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
    public class ContratoDAO:Conexion
    {
        //Mostrar Contratos del Empleado
        SqlDataReader leer;
        DataTable tabla = new DataTable();

        public DataTable MostrarContratoEmpleado(Contrato objContrato)
        {
            using (var conexion = GetConnection())
            {
                conexion.Open();
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = conexion;
                    cmd.CommandText = "Contratos.spMostrarContrato";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CodigoEmpleado", objContrato.CodigoEmpleado);
                    leer = cmd.ExecuteReader();
                    tabla.Load(leer);

                    conexion.Close();
                    leer.Close();
                    return tabla;
                }
            }
        }

        //Crear Contrato
        public void CrearContrato(Contrato objContrato)
        {
            using (var conexion = GetConnection())
            {
                conexion.Open();
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = conexion;
                    cmd.CommandText = "Contratos.spCrearContrato";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FechaInicio", objContrato.FechaInicio);
                    cmd.Parameters.AddWithValue("@FechaFin", objContrato.FechaFin);
                    cmd.Parameters.AddWithValue("@Cargo", objContrato.Cargo);
                    cmd.Parameters.AddWithValue("@AsignacionFamiliar", objContrato.AsignacionFamiliar);
                    cmd.Parameters.AddWithValue("@TotalDeHorasContratadasPorSemanas", objContrato.TotalDeHorasContratadasPorSemanas);
                    cmd.Parameters.AddWithValue("@ValorHora", objContrato.ValorHora);
                    cmd.Parameters.AddWithValue("@Estado", objContrato.Estado);
                    cmd.Parameters.AddWithValue("@CodigoEmpleado", objContrato.CodigoEmpleado);
                    cmd.Parameters.AddWithValue("@CodigoAFP", objContrato.CodigoAFP);
                    cmd.Parameters.AddWithValue("@CodigoPeriodo", objContrato.CodigoPeriodo);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();

                }
            }
        }

        //Editar Contrato
        public void EditarContrato(Contrato objContrato)
        {
            using (var conexion = GetConnection())
            {
                conexion.Open();
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = conexion;
                    cmd.CommandText = "Contratos.spEditarContrato";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CodigoContrato", objContrato.CodigoContrato);
                    cmd.Parameters.AddWithValue("@FechaInicio", objContrato.FechaInicio);
                    cmd.Parameters.AddWithValue("@FechaFin", objContrato.FechaFin);
                    cmd.Parameters.AddWithValue("@Cargo", objContrato.Cargo);
                    cmd.Parameters.AddWithValue("@AsignacionFamiliar", objContrato.AsignacionFamiliar);
                    cmd.Parameters.AddWithValue("@TotalDeHorasContratadasPorSemanas", objContrato.TotalDeHorasContratadasPorSemanas);
                    cmd.Parameters.AddWithValue("@ValorHora", objContrato.ValorHora);
                    cmd.Parameters.AddWithValue("@Estado", objContrato.Estado);
                    cmd.Parameters.AddWithValue("@CodigoEmpleado", objContrato.CodigoEmpleado);
                    cmd.Parameters.AddWithValue("@CodigoAFP", objContrato.CodigoAFP);
                    cmd.Parameters.AddWithValue("@CodigoPeriodo", objContrato.CodigoPeriodo);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();

                }
            }
        }

        //Anular Contrato
        public void AnularContrato(Contrato objContrato)
        {
            using (var conexion = GetConnection())
            {
                conexion.Open();
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = conexion;
                    cmd.CommandText = "Contratos.spAnularContrato";
                    cmd.Parameters.AddWithValue("@CodigoContrato", objContrato.CodigoContrato);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //Mostrar Contrato Del Periodo
        public DataTable MostrarContratoDelPeriodo(Periodo objPeriodo)
        {
            using (var conexion = GetConnection())
            {
                conexion.Open();
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = conexion;
                    cmd.CommandText = "Contratos.spMostrarContratosBoleta";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@FechaInicioPeriodo", objPeriodo.FechaInicio);
                    cmd.Parameters.AddWithValue("@FechaFinPeriodo", objPeriodo.FechaFin);
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

