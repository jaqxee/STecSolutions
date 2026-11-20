using Npgsql;
using STecSolutions.Inventario.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace STecSolutions.Inventario.DAL
{
    public class EstadoOperativoDAL
    {
        public int InsertarEstadoOperativo(EstadoOperativo estadoOperativo) 
        {
            using (NpgsqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                string nonQuery = """
                    INSERT INTO estado_operativo(nombre, descripcion) VALUES (@nombre, @descripcion) RETURNING id_estado_operativo;
                    """;
                using (NpgsqlCommand comando = new NpgsqlCommand(nonQuery, conexion))
                {
                    comando.Parameters.AddWithValue("@nombre", estadoOperativo.Nombre);
                    comando.Parameters.AddWithValue("@descripcion", estadoOperativo.Descripcion);

                    return Convert.ToInt32(comando.ExecuteScalar());
                }

            }
        }

        public List<EstadoOperativo> ObtenerListaEstadoOperativo() 
        {
            List<EstadoOperativo> lista = new List<EstadoOperativo>();
            using (NpgsqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                string query = """
                    SELECT id_estado_operativo, nombre, descripcion FROM estado_operativo ORDER BY nombre ASC;
                    """;
                using (NpgsqlCommand comando = new NpgsqlCommand(query, conexion))
                {
                    using (NpgsqlDataReader lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            EstadoOperativo estadoOperativo = new EstadoOperativo();
                            estadoOperativo.IdEstadoOperativo = Convert.ToInt32(lector["id_estado_operativo"]);
                            estadoOperativo.Nombre = lector["nombre"].ToString();
                            estadoOperativo.Descripcion = lector["descripcion"].ToString();
                            lista.Add(estadoOperativo);
                        }
                    }
                }
            }
            return lista;
        }
    }
}
