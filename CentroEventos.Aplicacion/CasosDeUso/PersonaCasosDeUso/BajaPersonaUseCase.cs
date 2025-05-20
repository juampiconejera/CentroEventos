using System;
using System.Net.Security;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;
namespace CentroEventos.Aplicacion.CasosDeUso.PersonaCasosDeUso;

public class BajaPersonaUseCase(IRepositorioPersona repoPersona, IServicioAutorizacionProvisorio Auth)
{
    public void Ejecutar(int id, int idUsuario)
    {
        if (!Auth.PoseeElPermiso(idUsuario))
        {
            throw new FalloAutorizacionException("Usuario no autorizado.");
        }

        repoPersona.Eliminar(id);
    }
}
