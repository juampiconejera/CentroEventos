using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validadores;

namespace CentroEventos.Aplicacion.CasosDeUso.ReservaCasosDeUso;

public class ModificarReservaUseCase(IRepositorioReserva repoReserva, IRepositorioPersona repoPersona, IRepositorioEventoDeportivo repoEventoDeportivo, IServicioAutorizacion Auth, ReservaValidador reservaValidador)
{
    public void Ejecutar(Reserva reserva, int idUsuario)
    {
        //Verificamos los permisos del usuario
        /* if(!Auth.PoseeElPermiso(idUsuario))
        {
            throw new FalloAutorizacionException("Usuario no autorizado.");
        } */
        
        //Validamos los datos de la reserva
        if(!reservaValidador.Validar(reserva, out string mensajeError))
        {
            throw new ValidacionException(mensajeError);            
        }

        //Verificamos si existe la persona por id
        if(!repoPersona.ExistePorId(reserva.PersonaId))
        {
            throw new EntidadNotFoundException("Persona no encontrada.");
        }

        //Verificamos si existe el evento deportivo por id
        if(!repoEventoDeportivo.ExistePorId(reserva.EventoDeportivoId))
        {
            throw new EntidadNotFoundException("Evento deportivo no encontrado");
        }
        
        //
        if (repoReserva.Listar().Any(repo => (repo.PersonaId == reserva.PersonaId) && (repo.EventoDeportivoId == reserva.EventoDeportivoId)))
        {
            throw new DuplicadoException("Persona duplicada en el evento");
        }
        
        //Buscamos la reserva en el repositorio y si existe la modificamos
        repoReserva.Modificar(reserva);
    }
}
