using Npgsql;
using STecSolutions.Inventario.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace STecSolutions.Inventario.DAL
{
    public class TipoEquipoDAL
    {
        public int InsertarTipoEquipo(TipoEquipo Tipo)
        {
            using (NpgsqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                string nonQuery = """
                    INSERT INTO tipo_equipo (nombre, descripcion) VALUES (@nombre, @descripcion) RETURNING id_tipo_equipo;
                    """;
                using (NpgsqlCommand comando = new NpgsqlCommand(nonQuery, conexion))
                {
                    comando.Parameters.AddWithValue("@nombre", Tipo.Nombre);
                    comando.Parameters.AddWithValue("@descripcion", Tipo.Descripcion);
                    object idEquipo = comando.ExecuteScalar();
                    return Convert.ToInt32(idEquipo);
                }
            }
        }

        public List<TipoEquipo> ObtenerListaTipoEquipo() 
        {
            List<TipoEquipo> lista = new List<TipoEquipo>();
            using (NpgsqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                string query = """
                    SELECT id_tipo_equipo, nombre, descripcion FROM tipo_equipo;
                    """;
                using (NpgsqlCommand comando = new NpgsqlCommand(query, conexion)) 
                {
                    using (NpgsqlDataReader lector = comando.ExecuteReader()) 
                    {
                        while (lector.Read()) 
                        {
                            TipoEquipo tipoEquipo = new TipoEquipo();
                            tipoEquipo.IdTipoEquipo = Convert.ToInt32(lector["id_tipo_equipo"]);
                            tipoEquipo.Nombre = lector["nombre"].ToString();
                            tipoEquipo.Descripcion = lector["descripcion"].ToString();
                            lista.Add(tipoEquipo);
                        }
                    }
                }
            }
            return lista;
        }
    }
}
