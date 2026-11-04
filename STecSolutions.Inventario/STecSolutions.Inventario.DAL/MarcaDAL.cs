using Npgsql;
using STecSolutions.Inventario.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace STecSolutions.Inventario.DAL
{
    public class MarcaDAL
    {
        public int InsertarMarca(Marca marca) 
        {
            using (NpgsqlConnection conexion = ConexionBD.ObtenerConexion()) 
            {
                string nonQuery = """
                    INSERT INTO marca(nombre) VALUES (@nombre) RETURNING id_marca;
                    """;
                using (NpgsqlCommand comando = new NpgsqlCommand(nonQuery, conexion)) 
                {
                    comando.Parameters.AddWithValue("@nombre", marca.Nombre);
                    int Id = Convert.ToInt32(comando.ExecuteScalar());
                    return Id;
                }
            }
        }

        public List<Marca> ObtenerListaMarca() 
        {
            List<Marca> lista = new List<Marca>();
            using (NpgsqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                string query = """
                    SELECT id_marca, nombre FROM marca;
                    """;
                using(NpgsqlCommand comando = new NpgsqlCommand(query, conexion))
                {
                    using (NpgsqlDataReader lector = comando.ExecuteReader()) 
                    {
                        while (lector.Read())
                        {
                            Marca marca = new Marca();
                            marca.IdMarca = Convert.ToInt32(lector["id_marca"]);
                            marca.Nombre = lector["nombre"].ToString();
                            lista.Add(marca);
                        }
                    }
                }
            }
            return lista;
        }
    }
}
