using System;
using System.Collections.Generic;
using System.Text;

namespace STecSolutions.Inventario.Entities.DTO
{
    public class InventarioResumen
    {
        public string CodInventario { get; set; }
        public string EstadoOperativo { get; set; }
        public string Responsable { get; set; }
        public string Ubicacion { get; set; }
    }
}