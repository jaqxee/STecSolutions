using System;
using System.Collections.Generic;
using System.Text;
using Npgsql;
using STecSolutions.Inventario.Entities;

namespace STecSolutions.Inventario.DAL
{
    public class SistemaOperativoDAL
    {
        public int InsertarSistemaOperativo(SistemaOperativo sistemaOperativo) 
        {
            using (NpgsqlConnection conexion = ConexionBD.ObtenerConexion()) 
            {
                string nonQuery = """
                    INSERT INTO sistema_operativo(nombre, version) VALUES(@nombre, @version) RETURNING id_sistema_operativo;
                    """;
                using (NpgsqlCommand comando = new NpgsqlCommand(nonQuery, conexion)) 
                {
                    comando.Parameters.AddWithValue("@nombre", sistemaOperativo.Nombre);
                    comando.Parameters.AddWithValue("@version", sistemaOperativo.Version);

                     return Convert.ToInt32(comando.ExecuteScalar());
                }
            }
        }

        public List<SistemaOperativo> ObtenerListaSistemaOperativo() 
        {
            List<SistemaOperativo> lista = new List<SistemaOperativo>();
            using (NpgsqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                string query = """
                    SELECT id_sistema_operativo, nombre, version FROM sistema_operativo;
                    """;
                using (NpgsqlCommand comando = new NpgsqlCommand(query, conexion)) 
                {
                    using (NpgsqlDataReader lector = comando.ExecuteReader())
                    {
                        while (lector.Read()) 
                        {
                            SistemaOperativo sistemaOperativo = new SistemaOperativo();
                            sistemaOperativo.IdSistemaOperativo = Convert.ToInt32(lector["id_sistema_operativo"]);
                            sistemaOperativo.Nombre = lector["nombre"].ToString();
                            sistemaOperativo.Version = lector["version"].ToString();
                            lista.Add(sistemaOperativo);
                        }
                    }
                }
            }
            return lista;
        }
    }
}
