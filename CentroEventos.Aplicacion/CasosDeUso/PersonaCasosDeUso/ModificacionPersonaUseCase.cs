using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Excepciones;

namespace CentroEventos.Aplicacion.CasosDeUso.PersonaCasosDeUso;

public class ModificacionPersonaUseCase(IRepositorioPersona repoPersona, IServicioAutorizacionProvisorio Auth)
{
    public void Ejecutar(Persona persona, int idUsuario)
    {
        if (!Auth.PoseeElPermiso(idUsuario))
        {
            throw new FalloAutorizacionException("Usuario no autorizado.");
        }

        repoPersona.Modificar(persona);     //lo bucamos en el repositorio y si existe lo modificamos
    }
}
