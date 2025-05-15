using System;
using System.Runtime.Serialization;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.provisional;
using CentroEventos.Aplicacion.Validadores;

namespace CentroEventos.Aplicacion.CasosDeUso.ReservaCasosDeUso;

public class AltaReservaUseCase(IRepositorioEventoDeportivo repoEventoDeportivo, IRepositorioPersona repoPersona, 
IRepositorioReserva repoReserva, ServicioAutorizacionProvisorio Auth, ReservaValidador reservaValidador)
{
    private bool cupoDisponible(EventoDeportivo eventoDeportivo)
    {
        return eventoDeportivo.CantidadReservas > eventoDeportivo.CupoMaximo;
    }

    private bool reservaDuplicada(Reserva reserva)
    {
        return ;
    }
    public void Ejecutar(Reserva reserva, int idUsuario){
        //verificamos si posee permisos
        if(!Auth.PoseeElPermiso(idUsuario)){
            throw new FalloAutorizacionException("Usuario no autorizado.");
        }

        //validamos la reserva
        if(!reservaValidador.Validar(reserva, out string message))
        {
            throw new ValidacionException(message);
        }

        //verificamos si existe la persona por id
        if(!repoPersona.ExistePorId(reserva.PersonaId))
        {
            throw new EntidadNotFoundException("Persona no encontrada.");
        }

        //verificamos si existe el evento deportivo por id
        if(!repoEventoDeportivo.ExistePorId(reserva.EventoDeportivoId))
        {
            throw new EntidadNotFoundException("Evento deportivo no encontrado");
        }

        //validar cupo disponible.
        if(cupoDisponible(repoEventoDeportivo.ObtenerPorId(reserva.EventoDeportivoId))){
            throw new CupoExcedidoException("Evento deportivo lleno");
        }
        /*FALTA:
          4. Validar que la Persona no tenga ya una reserva para ese EventoDeportivo. Lanzar DuplicadoException si ya existe. 
          5. Si todo OK, completar datosReserva (FechaAltaReserva, EstadoAsistencia).*/
        repoReserva.Agregar(reserva);
    }
}
