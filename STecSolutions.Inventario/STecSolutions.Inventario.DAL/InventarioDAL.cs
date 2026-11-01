using System;
using System.Collections.Generic;
using System.Text;
using Npgsql;
using STecSolutions.Inventario.Entities.DTO;
using STecSolutions.Inventario.Entities;

namespace STecSolutions.Inventario.DAL
{
    public class InventarioDAL
    {
        public List<InventarioResumen> ObtenerResumen() 
        {
            List<InventarioResumen> listaInventarioResumen = new List<InventarioResumen>();
            using (NpgsqlConnection conexion = ConexionBD.ObtenerConexion() )
            {
                string query = """
                    SELECT it.codigo_inventario,
                           eo.nombre,
                           us.nombre_completo,
                           ub.sede
                    FROM inventario_tecnologico it
                           INNER JOIN estado_operativo eo ON it.id_estado_operativo = eo.id_estado_operativo
                           INNER JOIN usuario us ON it.id_usuario_responsable = us.id_usuario
                           INNER JOIN ubicacion ub ON it.id_ubicacion = ub.id_ubicacion;
                    """;

                using (NpgsqlCommand comando = new NpgsqlCommand(query, conexion))
                {
                    using (NpgsqlDataReader lector = comando.ExecuteReader()) 
                    {
                        while (lector.Read()) 
                        {
                            InventarioResumen inventarioResumen = new InventarioResumen();
                            inventarioResumen.CodInventario = lector.IsDBNull(lector.GetOrdinal("codigo_inventario")) ? "Sin Asignar" : lector["codigo_inventario"].ToString();
                            inventarioResumen.EstadoOperativo = lector.IsDBNull(lector.GetOrdinal("nombre")) ? "Sin Asignar" : lector["nombre"].ToString();
                            inventarioResumen.Responsable = lector.IsDBNull(lector.GetOrdinal("nombre_completo")) ? "Sin Asignar" : lector["nombre_completo"].ToString();
                            inventarioResumen.Ubicacion = lector.IsDBNull(lector.GetOrdinal("sede")) ? "Sin Asignar" : lector["sede"].ToString();
                            listaInventarioResumen.Add(inventarioResumen);
                        }
                    }
                }
            }
            return listaInventarioResumen;
        }
    }
}