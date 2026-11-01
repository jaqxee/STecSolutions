using System;
using System.Collections.Generic;
using System.Text;

namespace STecSolutions.Inventario.Entities
{
    public class InventarioTecnologico
    {
        public string CodigoInventario { get; set; }
        public int IdTipoEquipo { get; set; }
        public int IdModelo { get; set; }
        public int IdProcesador { get; set; }
        public string MemoriaRam { get; set; }
        public string CapacidadAlmacenamiento { get; set; }
        public int IdSistemaOperativo { get; set; }
        public int IdUsuarioResponsable { get; set; }
        public int IdUbicacion { get; set; }
        public int IdEstadoOperativo { get; set; }
    }
}
