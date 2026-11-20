using System;
using System.Collections.Generic;
using System.Text;

namespace STecSolutions.Inventario.Entities.DTO
{
    public class InventarioConsultaDTO
    {
        public string CodigoInventario { get; set; }
        public string TipoEquipo { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Procesador { get; set; }
        public string MemoriaRam { get; set; }
        public string CapacidadAlmacenamiento { get; set; }
        public string SistemaOperativo { get; set; }
        public string UsuarioResponsable { get; set; }
        public string Ubicacion { get; set; }
        public string EstadoOperativo { get; set; }

    }
}
