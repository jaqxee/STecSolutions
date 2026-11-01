using System;
using System.Collections.Generic;
using System.Text;

using Npgsql;

namespace STecSolutions.Inventario.DAL
{
    internal class ConexionBD
    {
        private const string CadenaConexion = "Server=LocalHost;Port=5432;Database=stec_solutions;User Id=postgres;Password=131313";

        public static NpgsqlConnection ObtenerConexion() 
        {
            NpgsqlConnection conexion = new NpgsqlConnection(CadenaConexion);
            conexion.Open();
            return conexion;
        }
    }
}
