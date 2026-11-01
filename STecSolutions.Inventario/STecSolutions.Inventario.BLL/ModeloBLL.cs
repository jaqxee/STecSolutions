using System;
using System.Collections.Generic;
using System.Text;
using STecSolutions.Inventario.DAL;
using STecSolutions.Inventario.Entities;
using STecSolutions.Inventario.Entities.Excepciones;

namespace STecSolutions.Inventario.BLL
{
    public class ModeloBLL
    {
        public int InsertarDatos(Modelo modelo) 
        {
            if (modelo.IdMarca <= 0) throw new NegocioException("El campo Marca tiene un valor inválido");

            if (string.IsNullOrWhiteSpace(modelo.NombreModelo)) throw new NegocioException("Debe ingresar el nombre del modelo");

            ModeloDAL modeloDal = new ModeloDAL();
             return modeloDal.InsertarModelo(modelo);
        }
    }
}
