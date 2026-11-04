using System;
using System.Collections.Generic;
using System.Text;
using Npgsql;
using STecSolutions.Inventario.Entities;

namespace STecSolutions.Inventario.DAL
{
    public class ProcesadorDAL
    {
        public int InsertarProcesador(Procesador procesador) 
        {
            using (NpgsqlConnection conexion = ConexionBD.ObtenerConexion()) 
            {
                string nonQuery = """
                    INSERT INTO procesador(marca, modelo_cpu) VALUES (@marca, @modelo_cpu) RETURNING id_procesador;
                    """;
                using (NpgsqlCommand comando = new NpgsqlCommand(nonQuery, conexion)) 
                {
                    comando.Parameters.AddWithValue("@marca", procesador.Marca);
                    comando.Parameters.AddWithValue("@modelo_cpu", procesador.ModeloCpu);
                    return Convert.ToInt32(comando.ExecuteScalar());
                }
            }
        }

        public List<Procesador> ObtenerListaProcesador()
        {
            List<Procesador> lista = new List<Procesador>();
            using (NpgsqlConnection conexion  = ConexionBD.ObtenerConexion())
            {
                string query = """
                    SELECT id_procesador, marca, modelo_cpu FROM procesador;
                    """;
                using (NpgsqlCommand comando = new NpgsqlCommand(query, conexion)) 
                {
                    using (NpgsqlDataReader lector = comando.ExecuteReader()) 
                    {
                        while (lector.Read()) 
                        {
                            Procesador procesador = new Procesador();
                            procesador.IdProcesador = Convert.ToInt32(lector["id_procesador"]);
                            procesador.Marca = lector["marca"].ToString();
                            procesador.ModeloCpu = lector["modelo_cpu"].ToString();
                            lista.Add(procesador);
                        }
                    }
                }
            }
            return lista;
        }
    }
}
