﻿using System;
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
    public class GestionarAFPManejador
    {
        AfpDAO objAfpDAO = new AfpDAO();

        //Metodo ListarAFP
        public DataTable ListarAFP()
        {
            return objAfpDAO.ListarAFP();
        }
    }
}
