using System;
using System.Collections.Generic;
using System.Text;
using STecSolutions.Inventario.Entities;
using STecSolutions.Inventario.DAL;
using STecSolutions.Inventario.Entities.Excepciones;

namespace STecSolutions.Inventario.BLL
{
    public class ProcesadorBLL
    {
        public int InsertarDatos(Procesador procesador) 
        {
            if (string.IsNullOrWhiteSpace(procesador.Marca)) throw new NegocioException("El campo Marca no puede estar vacío");
            if (string.IsNullOrWhiteSpace(procesador.ModeloCpu)) throw new NegocioException("El campo Modelo CPU no puede estar vacío");
            return new ProcesadorDAL().InsertarProcesador(procesador);
        }

        public List<Procesador> MostrarDatos() 
        {
            return new ProcesadorDAL().ObtenerListaProcesador();
        }
    }
}
