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
        bool validacion = true;
        mensajeError = "";
        //validacion IdPersona
        if(validacion && string.IsNullOrWhiteSpace(reserva.PersonaId + ""))
        {
            mensajeError = "Id de la persona invalido.\n";
            validacion = false;
        }
        //validacion IdEventoDeportivo
        if(validacion && string.IsNullOrWhiteSpace(reserva.EventoDeportivoId + ""))
        {
            mensajeError = "Id del evento deportivo invalido.\n";
            validacion = false;
        }
        //validacion FechaAltaReserva
        if(validacion && string.IsNullOrWhiteSpace(reserva.FechaAltaReserva + ""))
        {
            mensajeError = "FechaAlta de la reserva invalida.\n";
            validacion = false;
        }
        //validacion Estado
        if(validacion && string.IsNullOrWhiteSpace(reserva.EstadoAsistencia + ""))
        {
            mensajeError = "Estado de la reserva invalido.\n";
            validacion = false;
        }
        return validacion;
    }
}
