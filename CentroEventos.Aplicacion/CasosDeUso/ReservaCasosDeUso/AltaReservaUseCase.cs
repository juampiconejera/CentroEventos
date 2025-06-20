using System;
using System.Runtime.Serialization;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Enumerativos;

namespace CentroEventos.Aplicacion.CasosDeUso.ReservaCasosDeUso;
public class AltaReservaUseCase(IRepositorioEventoDeportivo repoEventoDeportivo, IRepositorioPersona repoPersona, 
IRepositorioReserva repoReserva, IServicioAutorizacion Auth, ReservaValidador reservaValidador)
{
    private bool CuposDisponibles(IRepositorioReserva repoReserva, IServicioAutorizacion Auth, IRepositorioEventoDeportivo repoEventoDeportivo, Reserva reserva)
    {
        var totalEventos = repoReserva.ListarReservasPorEvento(reserva.EventoDeportivoId);
        var evento = repoEventoDeportivo.ObtenerPorId(reserva.EventoDeportivoId);
        return totalEventos.Count() < evento.CupoMaximo;
    }

    public void Ejecutar(Reserva reserva, Usuario usuario){
        //verificamos si posee permisos
        if(!Auth.PoseeElPermiso(usuario.Permisos, Permiso.ReservaAlta)){
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
        if (!CuposDisponibles(repoReserva, Auth, repoEventoDeportivo, reserva))
        {
            throw new CupoExcedidoException("Evento deportivo lleno.");
        }

        //Validar que PersonaID no tenga EventoDeportivoId dos veces.
        if (repoReserva.Listar().Any( repo => (repo.PersonaId == reserva.PersonaId) && (repo.EventoDeportivoId == reserva.EventoDeportivoId)))
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
