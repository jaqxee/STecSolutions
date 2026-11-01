using STecSolutions.Inventario.DAL;
using STecSolutions.Inventario.Entities;
using STecSolutions.Inventario.Entities.Excepciones;
using System;
using System.Collections.Generic;
using System.Text;

namespace STecSolutions.Inventario.BLL
{
    public class TipoEquipoBLL
    {
        public int InsertarDatos(TipoEquipo Tipo)
        {
            if (string.IsNullOrWhiteSpace(Tipo.Nombre)) throw new NegocioException("Se debe ingresar un Nombre");
            if (string.IsNullOrWhiteSpace(Tipo.Descripcion)) Tipo.Descripcion = "Sin Asignar";

            TipoEquipoDAL tipoEquipoDAL = new TipoEquipoDAL();
            return tipoEquipoDAL.InsertarTipoEquipo(Tipo);
        }

        public List<TipoEquipo> MostrarDatos() 
        {
            return new TipoEquipoDAL().ObtenerListaTipoEquipo();
        }
    }
}
