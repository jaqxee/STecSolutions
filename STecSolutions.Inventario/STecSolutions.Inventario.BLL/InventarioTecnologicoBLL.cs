using System;
using System.Collections.Generic;
using System.Text;
using STecSolutions.Inventario.Entities;
using STecSolutions.Inventario.DAL;
using STecSolutions.Inventario.Entities.Excepciones;
using STecSolutions.Inventario.Entities.DTO;

namespace STecSolutions.Inventario.BLL
{
    public class InventarioTecnologicoBLL
    {
        public void InsertarActivoTecnologico(InventarioTecnologico inventario) 
        {
            if (string.IsNullOrWhiteSpace(inventario.CodigoInventario)) throw new NegocioException("El campo Codigo Inventario es obligatorio");
            if (new InventarioTecnologicoDAL().ConsultarCodigo(inventario.CodigoInventario) == 1) throw new NegocioException("El código ya existe, ingrese otro");
            if (inventario.IdTipoEquipo == 0) throw new NegocioException("Debe seleccionar un valor válido para el campo Tipo de Equipo");
            if (inventario.IdModelo == 0) throw new NegocioException("Debe seleccionar un valor válido para el campo Modelo");
            if (inventario.IdProcesador == 0) throw new NegocioException("Debe seleccionar un valor válido para el campo Procesador");
            if (string.IsNullOrWhiteSpace(inventario.MemoriaRam)) throw new NegocioException("El campo RAM es obligatorio");
            if (string.IsNullOrWhiteSpace(inventario.CapacidadAlmacenamiento)) throw new NegocioException("El campo Almacenamiento es obligatorio");
            if (inventario.IdSistemaOperativo == 0) throw new NegocioException("Debe seleccionar un valor válido para el campo Sistema Operativo");
            if (inventario.IdUsuarioResponsable == 0) throw new NegocioException("Debe seleccionar un valor válido para el campo Responsable");
            if (inventario.IdUbicacion == 0) throw new NegocioException("Debe seleccionar un valor válido para el campo Ubicación");
            if (inventario.IdEstadoOperativo == 0) throw new NegocioException("Debe seleccionar un valor válido para el campo Estado Operativo");
            new InventarioTecnologicoDAL().InsertarInventario(inventario);
        }

        public InventarioConsultaDTO MostrarDatos(string IdConsultado) 
        {
            InventarioConsultaDTO inventarioConsultado = new InventarioTecnologicoDAL().ObtenerInventarioTecnologico(IdConsultado);
            if (inventarioConsultado == null) { throw new NegocioException("El equipo consultado ya no existe en la Base de Datos"); }
            return inventarioConsultado;
        }

        public void IdAEliminar(string Id)
        {
            if (new InventarioTecnologicoDAL().ConsultarCodigo(Id) == 0) throw new NegocioException("No es posible hacer la operación porque ese registro ya fué eliminado");
                new InventarioTecnologicoDAL().EliminarRegistro(Id);
        }
    }
}
