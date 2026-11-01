using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;
using STecSolutions.Inventario.Entities;

namespace STecSolutions.Inventario.DAL
{
    public class ModeloDAL
    {
        public int InsertarModelo(Modelo modelo) 
        {
            using (NpgsqlConnection conexion = ConexionBD.ObtenerConexion()) 
            {
                string nonQuery = """
                    INSERT INTO modelo(id_marca, nombre_modelo) VALUES(@id_marca, @nombre_modelo) RETURNING id_modelo;
                    """;

                using (NpgsqlCommand comando = new NpgsqlCommand(nonQuery, conexion))
                {
                    comando.Parameters.AddWithValue("@id_marca", modelo.IdMarca);
                    comando.Parameters.AddWithValue("@nombre_modelo",modelo.NombreModelo);

                    object Id = comando.ExecuteScalar();
                    return Convert.ToInt32(Id);
                }
            }
        }

        public List<Modelo> ObtenerListaModelo()
        {
            List<Modelo> lista = new List<Modelo>();
            using (NpgsqlConnection conexion = ConexionBD.ObtenerConexion()) 
            {
                string query = """
                    SELECT id_modelo, id_marca, nombre_modelo FROM modelo;
                    """;

                using (NpgsqlCommand comando = new NpgsqlCommand(query, conexion)) 
                {
                    using (NpgsqlDataReader lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            Modelo modelo = new Modelo();
                            modelo.IdModelo = Convert.ToInt32(lector["id_modelo"]);
                            modelo.IdMarca = Convert.ToInt32(lector["id_marca"]);
                            modelo.NombreModelo = lector["nombre_modelo"].ToString();
                            lista.Add(modelo);
                        }
                    }
                }
            }
            return lista;
        }
    }
}
