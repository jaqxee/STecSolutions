using Npgsql;
using STecSolutions.Inventario.Entities;
using STecSolutions.Inventario.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace STecSolutions.Inventario.DAL
{
    public class InventarioTecnologicoDAL
    {
        public void InsertarInventario(InventarioTecnologico inventario)
        {
            using (NpgsqlConnection conexion = ConexionBD.ObtenerConexion()) 
            {
                string nonQuery = """
                    INSERT INTO inventario_tecnologico(codigo_inventario, id_tipo_equipo, id_modelo, id_procesador, memoria_ram, capacidad_almacenamiento, id_sistema_operativo, id_usuario_responsable, id_ubicacion, id_estado_operativo)
                    VALUES(@codigo, @idTipoEquipo, @idModelo, @idProcesador, @ram, @almacenamiento, @idSO, @idResponsable, @idUbicacion, @idEstadoOperativo);
                    """;
                using (NpgsqlCommand comando = new NpgsqlCommand(nonQuery, conexion)) 
                {
                    comando.Parameters.AddWithValue("@codigo", inventario.CodigoInventario);
                    comando.Parameters.AddWithValue("@idTipoEquipo", inventario.IdTipoEquipo);
                    comando.Parameters.AddWithValue("@idModelo", inventario.IdModelo);
                    comando.Parameters.AddWithValue("@idProcesador", inventario.IdProcesador);
                    comando.Parameters.AddWithValue("@ram", inventario.MemoriaRam);
                    comando.Parameters.AddWithValue("@almacenamiento", inventario.CapacidadAlmacenamiento);
                    comando.Parameters.AddWithValue("@idSO", inventario.IdSistemaOperativo);
                    comando.Parameters.AddWithValue("@idResponsable", inventario.IdUsuarioResponsable);
                    comando.Parameters.AddWithValue("@idUbicacion", inventario.IdUbicacion);
                    comando.Parameters.AddWithValue("@idEstadoOperativo", inventario.IdEstadoOperativo);
                    comando.ExecuteNonQuery();
                }
            }
        }

        public InventarioConsultaDTO ObtenerInventarioTecnologico(string IdConsultado) 
        {
            using (NpgsqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                string query = """
                    SELECT
                        i.codigo_inventario AS codigo_inventario,
                        te.nombre AS tipo_equipo,
                        mar.nombre AS marca,
                        m.nombre_modelo AS modelo,
                        p.modelo_cpu AS procesador,
                        i.memoria_ram AS RAM,
                        i.capacidad_almacenamiento AS capacidad_almacenamiento,
                        so.nombre AS sistema_operativo,
                        us.nombre_completo AS usuario,
                        ub.sede AS ubicacion,
                        e.nombre AS estado_operativo
                    FROM inventario_tecnologico i
                    INNER JOIN tipo_equipo te ON i.id_tipo_equipo = te.id_tipo_equipo
                    INNER JOIN modelo m ON i.id_modelo = m.id_modelo
                    INNER JOIN marca mar ON m.id_marca = mar.id_marca
                    INNER JOIN procesador p ON i.id_procesador = p.id_procesador
                    INNER JOIN sistema_operativo so ON i.id_sistema_operativo = so.id_sistema_operativo
                    INNER JOIN usuario us ON i.id_usuario_responsable = us.id_usuario
                    INNER JOIN ubicacion ub ON i.id_ubicacion = ub.id_ubicacion
                    INNER JOIN estado_operativo e ON i.id_estado_operativo = e.id_estado_operativo
                    WHERE codigo_inventario = @codigo_inventario;
                    """;
                using (NpgsqlCommand comando = new NpgsqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@codigo_inventario", IdConsultado);
                    using (NpgsqlDataReader lector = comando.ExecuteReader())
                    {
                        lector.Read();
                        InventarioConsultaDTO inventarioConsultado = new InventarioConsultaDTO();
                        inventarioConsultado.CodigoInventario = lector["codigo_inventario"].ToString();
                        inventarioConsultado.TipoEquipo = lector["tipo_equipo"].ToString();
                        inventarioConsultado.Marca = lector["marca"].ToString();
                        inventarioConsultado.Modelo = lector["modelo"].ToString();
                        inventarioConsultado.Procesador = lector["procesador"].ToString();
                        inventarioConsultado.MemoriaRam = lector["RAM"].ToString();
                        inventarioConsultado.CapacidadAlmacenamiento = lector["capacidad_almacenamiento"].ToString();
                        inventarioConsultado.SistemaOperativo = lector["sistema_operativo"].ToString();
                        inventarioConsultado.UsuarioResponsable = lector["usuario"].ToString();
                        inventarioConsultado.Ubicacion = lector["ubicacion"].ToString();
                        inventarioConsultado.EstadoOperativo = lector["estado_operativo"].ToString();
                        return inventarioConsultado;
                    } /////// TIENES QUE CONSULTAR Y TRAER EL VALOR DE LOS CAMPOS QUE QUIERES Y DESPUES LLENAR el DTO 
                }
            }
        }
        public int ConsultarCodigo(string codigo) 
        {
            using (NpgsqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                string query = "SELECT 1 FROM inventario_tecnologico WHERE codigo_inventario = @codigo LIMIT 1;";
                using (NpgsqlCommand comando = new NpgsqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@codigo", codigo);
                    object resultado = comando.ExecuteScalar();
                    if (resultado != null) return Convert.ToInt32(resultado); else return 0; 
                }
            }
        }
    }
}
