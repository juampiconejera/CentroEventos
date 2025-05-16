using System;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Validadores;

namespace CentroEventos.Aplicacion.CasosDeUso.ReservaCasosDeUso;

public class ModificarEventoDeportivoUseCase(IRepositorioEventoDeportivo repoEventoDeportivo, IServicioAutorizacionProvisorio Auth, EventoDeportivoValidador eventoDeportivoValidador)
{
    public void Ejecutar(EventoDeportivo eventoDeportivo, int IdUsuario)
    {
        if(!Auth.PoseeElPermiso(IdUsuario))
        {
            throw new FalloAutorizacionException("Usuario no autorizado.");
        }

        if(!eventoDeportivoValidador.Validar(eventoDeportivo, out string mensajeError))
        {
            throw new ValidacionException(mensajeError);
        }

        repoEventoDeportivo.Modificar(eventoDeportivo);
    }
}
