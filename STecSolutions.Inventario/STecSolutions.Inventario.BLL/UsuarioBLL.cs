using STecSolutions.Inventario.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using STecSolutions.Inventario.DAL;
using STecSolutions.Inventario.Entities.Excepciones;

namespace STecSolutions.Inventario.BLL
{
    public class UsuarioBLL
    {
        public int InsertarDatos(Usuario usuario)
        {
            if (string.IsNullOrWhiteSpace(usuario.NombreCompleto)) throw new NegocioException("El campo Nombre no puede estar vacío");
            if (!string.IsNullOrWhiteSpace(usuario.Email)) 
            {
                if (new UsuarioDAL().EmailDuplicado(usuario.Email) == 1) throw new NegocioException("El email ya existe, ingrese otro");
            }

            if (string.IsNullOrWhiteSpace(usuario.Departamento)) usuario.Departamento = "Sin Asignar";
            return new UsuarioDAL().InsertarUsuario(usuario);
        }

    public List<Usuario> MostrarDatos()
        {
            return new UsuarioDAL().ObtenerListaUsuario();
        }
    }
}
