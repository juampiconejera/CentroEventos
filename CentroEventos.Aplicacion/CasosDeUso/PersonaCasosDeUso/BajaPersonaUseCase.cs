using System;
using System.Net.Security;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;
namespace CentroEventos.Aplicacion.CasosDeUso.PersonaCasosDeUso;

public class BajaPersonaUseCase(IRepositorioPersona repoPersona, IServicioAutorizacion Auth)
{
    public void Ejecutar(int id, int idUsuario)
    {
        /* if (!Auth.PoseeElPermiso(idUsuario))
        {
            throw new FalloAutorizacionException("Usuario no autorizado.");
        } */
        if (!repoPersona.ExistePorId(id))
        {
            throw new EntidadNotFoundException("El usuario no existe en la base de datos.");
        }

        repoPersona.Eliminar(id);
    }
}
