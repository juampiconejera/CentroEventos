using System;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;

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
    public bool Validar(Reserva reserva, IRepositorioReserva repositorioReserva,IRepositorioPersona repositorioPersona, IRepositorioEventoDeportivo repositorioEventoDeportivo)
    {   
        //validacion IdPersona
        if(!repositorioPersona.Listar().Contains(repositorioPersona.ObtenerPorId(reserva.PersonaId)))
        {
            throw new EntidadNotFoundException("El Id no corresponde a una persona registrada.");
        }
        //validacion IdEventoDeportivo
        if(!repositorioEventoDeportivo.Listar().Contains(repositorioEventoDeportivo.ObtenerPorId(reserva.EventoDeportivoId)))
        {
            throw new EntidadNotFoundException("El Id no corresponde a un evento registrado.");
        }
        return true;
    }
}
