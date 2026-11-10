using Npgsql;
using STecSolutions.Inventario.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace STecSolutions.Inventario.DAL
{
    public class UsuarioDAL
    {
        public int InsertarUsuario(Usuario usuario)
        {
            using (NpgsqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                string nonQuery = """
                    INSERT INTO usuario(nombre_completo, email, departamento) VALUES(@nombre, @email, @departamento) RETURNING id_usuario;
                    """;
                using (NpgsqlCommand comando = new NpgsqlCommand(nonQuery, conexion))
                {
                    comando.Parameters.AddWithValue("@nombre", usuario.NombreCompleto);
                    comando.Parameters.AddWithValue("@email", string.IsNullOrEmpty(usuario.Email) ? DBNull.Value : usuario.Email);
                    comando.Parameters.AddWithValue("@departamento", usuario.Departamento);

                    return Convert.ToInt32(comando.ExecuteScalar());
                }
            }
        }
        public List<Usuario> ObtenerListaUsuario() 
        {
            List<Usuario> lista = new List<Usuario>();
            using (NpgsqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                string query = """
                    SELECT id_usuario, nombre_completo, email, departamento FROM usuario;
                    """;
                using (NpgsqlCommand comando = new NpgsqlCommand(query, conexion)) 
                {
                    using (NpgsqlDataReader lector = comando.ExecuteReader()) 
                    {
                        while (lector.Read()) 
                        {
                            Usuario usuario = new Usuario();
                            usuario.IdUsuario = Convert.ToInt32(lector["id_usuario"]);
                            usuario.NombreCompleto = lector["nombre_completo"].ToString();
                            usuario.Email = lector["email"].ToString();
                            usuario.Departamento = lector["departamento"].ToString();
                            lista.Add(usuario);
                        }
                    }
                }
            }
            return lista;
        }

        public int EmailDuplicado(String email) 
        {
            using (NpgsqlConnection conexion = ConexionBD.ObtenerConexion()) 
            {
                string query = """
                    SELECT 1 FROM usuario WHERE email = @email LIMIT 1; 
                    """;
                using (NpgsqlCommand comando = new NpgsqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@email", email);
                    object resultado = comando.ExecuteScalar();
                    if (resultado != null) return Convert.ToInt32(resultado); else return 0;
                }
            }
        }
    }
}
