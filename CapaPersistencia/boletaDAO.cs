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
    public class BoletaDAO:Conexion
    {
        SqlDataReader leer;
        DataTable tabla = new DataTable();

        //Mostrar Contratos de las Boletas
        public DataTable ListarBoletas(Periodo objPeriodo)
        {
            using (var conexion = GetConnection())
            {
                conexion.Open();
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = conexion;
                    cmd.CommandText = "Contratos.spMostrarContratosBoleta";
                    cmd.Parameters.AddWithValue("@FechaInicioPeriodo", objPeriodo.FechaInicio);
                    cmd.Parameters.AddWithValue("@FechaFinPeriodo", objPeriodo.FechaFin);
                    cmd.CommandType = CommandType.StoredProcedure;
                    leer = cmd.ExecuteReader();
                    tabla.Load(leer);

                    conexion.Close();
                    leer.Close();
                    return tabla;
                }
            }
        }

        //Insertar Boletas
        public void insertarBoleta(IEnumerable<Boleta> detalleBoleta)
        {
            //Crear Lista
            var table = new DataTable();
            table.Columns.Add("CodigoBoelta", typeof(string));
            table.Columns.Add("FechaPago", typeof(DateTime));
            table.Columns.Add("SueldoBasico", typeof(double));
            table.Columns.Add("AsignacionFamiliar", typeof(double));
            table.Columns.Add("TotalDeIngresos", typeof(double));
            table.Columns.Add("DescuentoPorAFP", typeof(double));
            table.Columns.Add("TotalDeDescuentos", typeof(double));
            table.Columns.Add("SueldoNeto", typeof(double));
            table.Columns.Add("TotalDeHoras", typeof(double));
            table.Columns.Add("CodigoContrato", typeof(string));
            table.Columns.Add("CodigoPeriodo", typeof(string));
            table.Columns.Add("CodigoConceptoDePago", typeof(string));
            foreach (var itemDetalle in detalleBoleta)
            {
                table.Rows.Add(new object[]
                    {
                        itemDetalle.CodigoBoleta,
                        itemDetalle.SueldoBasico,
                        itemDetalle.AsignacionFamiliar,
                        itemDetalle.TotalDeIngresos,
                        itemDetalle.DescuentoPorAFP,
                        itemDetalle.TotalDeDescuentos,
                        itemDetalle.SueldoNeto,
                        itemDetalle.TotalDeHoras,
                        itemDetalle.CodigoContrato,
                        itemDetalle.CodigoPeriodo,
                        itemDetalle.CodigoConceptoPago,
                    });
            }

            //Insercion en la base de datos
            using (var connection = GetConnection())
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection, SqlBulkCopyOptions.Default, transaction))
                    {
                        try
                        {
                            bulkCopy.DestinationTableName = "Pagos.Boleta";
                            bulkCopy.WriteToServer(table);
                            transaction.Commit();
                        }
                        catch (Exception)
                        {
                            transaction.Rollback();
                            connection.Close();
                            throw;
                        }
                    }
                }
            }
        }




    }
}
