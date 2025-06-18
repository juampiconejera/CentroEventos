using System;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Validadores;

namespace CentroEventos.Aplicacion.CasosDeUso.ReservaCasosDeUso;

public class ModificarEventoDeportivoUseCase(IRepositorioEventoDeportivo repoEventoDeportivo, IRepositorioPersona repoPersona, IServicioAutorizacion Auth, EventoDeportivoValidador eventoDeportivoValidador)
{
    public void Ejecutar(EventoDeportivo eventoDeportivo, int IdUsuario)
    {
        /* if(!Auth.PoseeElPermiso(IdUsuario))
        {
            throw new FalloAutorizacionException("Usuario no autorizado.");
        } */

        if(!eventoDeportivoValidador.Validar(eventoDeportivo, out string mensajeError))
        {
            throw new ValidacionException(mensajeError);
        }

        if(!repoEventoDeportivo.ExistePorId(eventoDeportivo.Id))
        {
            throw new EntidadNotFoundException("Id del evento no corresponde a un evento registrado.\n");
        }

        if(!repoPersona.ExistePorId(eventoDeportivo.ResponsableId))
        {
            throw new EntidadNotFoundException("Id del responsable no corresponde a una persona registrada.\n");
        }
        repoEventoDeportivo.Modificar(eventoDeportivo);
    }
}
