using System;
using System.Runtime.Serialization;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Enumerativos;

public class BajaReservaUseCase(IRepositorioEventoDeportivo repoEventoDeportivo, 
IRepositorioReserva repoReserva, IServicioAutorizacion Auth)
{
    public void Ejecutar(int reservaId, Usuario usuario)
    {
        //Verificamos permisos
        if (!Auth.PoseeElPermiso(usuario.Permisos, Permiso.ReservaBaja))
        {
            throw new FalloAutorizacionException("Usuario no autorizado.");
        }
        //Obtenemos la reserva
        var reserva = repoReserva.ObtenerPorId(reservaId);
        if (reserva == null)
            {
             throw new EntidadNotFoundException("La reserva no existe.");
            }
        //Y el evento para el que se creo. Para verificar que no sea un evento ya iniciado.
        var evento = repoEventoDeportivo.ObtenerPorId(reserva.EventoDeportivoId);

        if (evento.FechaHoraInicio < DateTime.Now)
           {
            throw new ValidacionException("No se puede cancelar una reserva a un evento ya iniciado.");
           }
        //Verificamos el estado de la reserva.
        if (reserva.EstadoAsistencia != EstadoAsistencia.Pendiente)
        {
            throw new ValidacionException("Solo se pueden cancelar reservas pendientes.");
        }
        //Eliminamos
        repoReserva.Eliminar(reservaId);
    }
}
