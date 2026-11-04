using System;
using System.Collections.Generic;
using System.Text;
using STecSolutions.Inventario.DAL;
using STecSolutions.Inventario.Entities;
using STecSolutions.Inventario.Entities.Excepciones;

namespace STecSolutions.Inventario.BLL
{
    public class MarcaBLL
    {
        public int InsertarDatos(Marca marca)
        {
            if (string.IsNullOrWhiteSpace(marca.Nombre)) throw new NegocioException("Ingrese un valor en el campo Nombre");
            return new MarcaDAL().InsertarMarca(marca);
        }
    

    public List<Marca> MostrarDatos()
        {
            return new MarcaDAL().ObtenerListaMarca();
        }
    }
}
