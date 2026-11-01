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
    }
}
