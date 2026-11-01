using System;
using System.Collections.Generic;
using System.Text;

namespace STecSolutions.Inventario.Entities
{
    public class Ubicacion
    {
        public int IdUbicacion { get; set; }
        public string Sede { get; set; }
        public string Edificio { get; set; }
        public string Piso { get; set; }
        public string Oficina { get; set; }
    }
}
