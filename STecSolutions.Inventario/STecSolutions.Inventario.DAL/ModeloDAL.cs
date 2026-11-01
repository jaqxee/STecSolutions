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
    }
}
