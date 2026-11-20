using STecSolutions.Inventario.Entities;
using STecSolutions.Inventario.Entities.Excepciones;
using STecSolutions.Inventario.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace STecSolutions.Inventario.BLL
{
    public class UbicacionBLL
    {
        public int InsertarDatos(Ubicacion ubicacion) 
        {
            if (string.IsNullOrWhiteSpace(ubicacion.Sede)) throw new NegocioException("El campo sede es obligatorio");
            if (string.IsNullOrWhiteSpace(ubicacion.Edificio)) ubicacion.Edificio = "Sin Asignar";
            if (string.IsNullOrWhiteSpace(ubicacion.Piso)) ubicacion.Piso = "Sin Asignar";
            if (string.IsNullOrWhiteSpace(ubicacion.Oficina)) ubicacion.Oficina = "Sin Asignar";
            return new UbicacionDAL().InsertarUbicacion(ubicacion);
        }

        public List<Ubicacion> MostrarDatos() 
        {
            return new UbicacionDAL().ObtenerListaUbicacion();
        }
    }
}
