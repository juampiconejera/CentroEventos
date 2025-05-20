using System;
using System.Runtime.Serialization;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Validadores;
using Aplicacion;

namespace CentroEventos.Aplicacion.CasosDeUso.ReservaCasosDeUso;

public class AltaReservaUseCase(IRepositorioEventoDeportivo repoEventoDeportivo, IRepositorioPersona repoPersona, 
IRepositorioReserva repoReserva, IServicioAutorizacionProvisorio Auth, ReservaValidador reservaValidador)
{
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
        if (!repoPersona.ExistePorId(reserva.PersonaId))
        {
            throw new EntidadNotFoundException("Persona no encontrada.");
        }

        //verificamos si existe el evento deportivo por id
        if(!repoEventoDeportivo.ExistePorId(reserva.EventoDeportivoId))
        {
            throw new EntidadNotFoundException("Evento deportivo no encontrado.");
        }

        //validar cupo disponible.
        if( repoReserva.ListarEventos(reserva.EventoDeportivoId).Count() > repoEventoDeportivo.ObtenerPorId(reserva.EventoDeportivoId).CupoMaximo ){
            throw new CupoExcedidoException("Evento deportivo lleno.");
        }

        //Validar que PersonaID no tenga EventoDeportivoId dos veces.
        if (repoReserva.Listar().Any( repo => (repo.PersonaId == reserva.PersonaId) && (repo.EventoDeportivoId == reserva.EventoDeportivoId) ))
        {
            throw new DuplicadoException("Persona duplicada en el evento.");
        }

        //Completar datosReserva.
        reserva.FechaAltaReserva = DateTime.Now;
        reserva.EstadoAsistencia = EstadoAsistencia.Pendiente;
        
        //Agregamos la reserva
        repoReserva.Agregar(reserva);
    }
}
