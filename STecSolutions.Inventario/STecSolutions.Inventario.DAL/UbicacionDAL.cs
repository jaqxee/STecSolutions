using System;
using System.Collections.Generic;
using System.Text;
using Npgsql;
using STecSolutions.Inventario.Entities;

namespace STecSolutions.Inventario.DAL
{
    public class UbicacionDAL
    {
        public int InsertarUbicacion(Ubicacion ubicacion)
        {
            using (NpgsqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                string nonQuery = """
                    INSERT INTO ubicacion(sede, edificio, piso, oficina) VALUES (@sede, @edificio, @piso, @oficina) RETURNING id_ubicacion;
                    """;
                using (NpgsqlCommand comando = new NpgsqlCommand(nonQuery, conexion)) 
                {
                    comando.Parameters.AddWithValue("@sede", ubicacion.Sede);
                    comando.Parameters.AddWithValue("@edificio", ubicacion.Edificio);
                    comando.Parameters.AddWithValue("@piso", ubicacion.Piso);
                    comando.Parameters.AddWithValue("@oficina", ubicacion.Oficina);

                    return Convert.ToInt32(comando.ExecuteScalar());
                }
            }
        }

        public List<Ubicacion> ObtenerListaUbicacion() 
        {
            List<Ubicacion> lista = new List<Ubicacion>();
            using (NpgsqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                string query = """
                    SELECT id_ubicacion, sede, edificio, piso, oficina FROM ubicacion ORDER BY sede ASC;
                    """;
                using (NpgsqlCommand comando = new NpgsqlCommand(query, conexion)) 
                {
                    using (NpgsqlDataReader lector = comando.ExecuteReader())
                    {
                        while (lector.Read()) 
                        {
                            Ubicacion ubicacion = new Ubicacion();
                            ubicacion.IdUbicacion = Convert.ToInt32(lector["id_ubicacion"]);
                            ubicacion.Sede = lector["sede"].ToString();
                            ubicacion.Edificio = lector["edificio"].ToString();
                            ubicacion.Piso = lector["piso"].ToString();
                            ubicacion.Oficina = lector["oficina"].ToString();
                            lista.Add(ubicacion);
                        }
                    }
                }
            }
            return lista;
        }
    }
}
