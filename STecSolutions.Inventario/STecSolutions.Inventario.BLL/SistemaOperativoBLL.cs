using System;
using System.Collections.Generic;
using System.Text;
using STecSolutions.Inventario.Entities;
using STecSolutions.Inventario.DAL;
using STecSolutions.Inventario.Entities.Excepciones;

namespace STecSolutions.Inventario.BLL
{
    public class SistemaOperativoBLL
    {
        public int InsertarDatos(SistemaOperativo sistemaOperativo) 
        {
            if (string.IsNullOrWhiteSpace(sistemaOperativo.Nombre)) throw new NegocioException("El campo Nombre no puede estar vacío");
            if (string.IsNullOrEmpty(sistemaOperativo.Version)) sistemaOperativo.Version = "Sin Asignar";
            return new SistemaOperativoDAL().InsertarSistemaOperativo(sistemaOperativo);
        }

        public List<SistemaOperativo> MostrarDatos() 
        {
            return new SistemaOperativoDAL().ObtenerListaSistemaOperativo();
        }
    }
}
