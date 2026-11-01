using System;
using System.Collections.Generic;
using System.Text;

namespace STecSolutions.Inventario.Entities
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string NombreCompleto { get; set; }
        public string Email { get; set; }
        public string Departamento { get; set; }
    }
}
