using System;
using System.Collections.Generic;
using System.Text;

namespace STecSolutions.Inventario.Entities.Excepciones
{
    public class NegocioException : Exception
    {
        public NegocioException() : base() { }
        public NegocioException(string message) : base(message) { }
        public NegocioException(string message, Exception innerException) : base(message, innerException) { }
    }
}
