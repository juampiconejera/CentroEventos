using System;
using CentroEventos.Aplicacion.Interfaces;
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
    public bool Validar(Reserva reserva, IRepositorioReserva repositorioReserva,IRepositorioPersona repositorioPersona, IRepositorioEventoDeportivo repositorioEventoDeportivo, out string mensajeError)
    {   bool validacion = true;
        mensajeError = "";
        //validacion IdPersona
        if(validacion & !repositorioPersona.Listar().Contains(repositorioPersona.ObtenerPorId(reserva.PersonaId)))
        {
            mensajeError = "El Id no corresponde a una persona registrada.\n";
            validacion = false;
        }
        //validacion IdEventoDeportivo
        if(validacion & !repositorioEventoDeportivo.Listar().Contains(repositorioEventoDeportivo.ObtenerPorId(reserva.EventoDeportivoId)))
        {
            mensajeError = "El Id no corresponde a un evento registrado.\n";
            validacion = false;
        }
        return validacion;
    }
}
