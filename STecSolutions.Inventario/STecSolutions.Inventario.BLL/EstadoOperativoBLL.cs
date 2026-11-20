using System;
using System.Collections.Generic;
using System.Text;
using STecSolutions.Inventario.Entities;
using STecSolutions.Inventario.Entities.Excepciones;
using STecSolutions.Inventario.DAL;

namespace STecSolutions.Inventario.BLL
{
    public class EstadoOperativoBLL
    {
        public int InsertarDatos(EstadoOperativo estadoOperativo)
        {
            if(string.IsNullOrWhiteSpace(estadoOperativo.Nombre)) throw new NegocioException("El campo Nombre es Obligatorio");
            if (string.IsNullOrWhiteSpace(estadoOperativo.Descripcion)) estadoOperativo.Descripcion = "Sin Asignar";
            return new EstadoOperativoDAL().InsertarEstadoOperativo(estadoOperativo);
        }

        public List<EstadoOperativo> MostrarDatos() 
        {
            return new EstadoOperativoDAL().ObtenerListaEstadoOperativo();
        } 
    }
}
