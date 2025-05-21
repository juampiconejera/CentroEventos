using System;
using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Aplicacion.Validadores;
/*
○ PersonaId y EventoDeportivoId deben corresponder a entidades existentes. (Requiere        LISTO 
consulta a IRepositorioPersona y IRepositorioEventoDeportivo)        

○ No permitir que la misma Persona reserve dos veces el mismo EventoDeportivo (Requiere     
consulta a IRepositorioReserva) 

○ Verificar cupo disponible en el EventoDeportivo antes de guardar. (Requiere consulta a 
IRepositorioEventoDeportivo y IRepositorioReserva)
*/
public class ReservaValidador
{
    public bool Validar(Reserva reserva, out string mensajeError)
    {
        mensajeError = "";
        //validacion IdPersona
        if (string.IsNullOrWhiteSpace(reserva.PersonaId + ""))
        {
            mensajeError += "Id de la persona invalido.\n";
        }
        //validacion IdEventoDeportivo
        if (string.IsNullOrWhiteSpace(reserva.EventoDeportivoId + ""))
        {
            mensajeError += "Id del evento deportivo invalido.\n";
        }
        //validacion FechaAltaReserva
        if (string.IsNullOrWhiteSpace(reserva.FechaAltaReserva + ""))
        {
            mensajeError += "FechaAlta de la reserva invalida.\n";
        }
        //validacion Estado
        if (string.IsNullOrWhiteSpace(reserva.EstadoAsistencia + ""))
        {
            mensajeError += "Estado de la reserva invalido.\n";
        }
        return mensajeError == "";
    }
}
