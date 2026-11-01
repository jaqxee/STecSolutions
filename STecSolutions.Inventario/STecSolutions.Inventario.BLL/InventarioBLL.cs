using System;
using System.Collections.Generic;
using System.Text;
using STecSolutions.Inventario.DAL;
using STecSolutions.Inventario.Entities;
using STecSolutions.Inventario.Entities.DTO;
using STecSolutions.Inventario.Entities.Excepciones;

namespace STecSolutions.Inventario.BLL
{
    public class InventarioBLL
    {
        public List<InventarioResumen> ObtenerResumenInicial() 
        {
            try
            {
                InventarioDAL dal = new InventarioDAL();
                return dal.ObtenerResumen();
            }
            catch 
            {
                throw;
            }
        }
    }
}
