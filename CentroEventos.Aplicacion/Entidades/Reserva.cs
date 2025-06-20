using System;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Enumerativos;

namespace CentroEventos.Aplicacion.Entidades;

public class Reserva
{
    public int Id { get; set; }
    public int PersonaId { get; set; }
    public int EventoDeportivoId { get; set; }
    public DateTime FechaAltaReserva { get; set; } = DateTime.Now;
    public EstadoAsistencia EstadoAsistencia { get; set; } = EstadoAsistencia.Pendiente;

    // Constructor por defecto 
    public Reserva() { }

    // Constructor básico
    public Reserva(int personaId, int eventoDeportivoId)
    {
        PersonaId = personaId;
        EventoDeportivoId = eventoDeportivoId;
    }

    // Constructor completo
    public Reserva(int personaId, int eventoDeportivoId, DateTime fechaAltaReserva, EstadoAsistencia estadoAsistencia)
    {
        PersonaId = personaId;
        EventoDeportivoId = eventoDeportivoId;
        FechaAltaReserva = fechaAltaReserva;
        EstadoAsistencia = estadoAsistencia;
    }

    public override string ToString()
    {
        return $"Id de la reserva: {Id}, Id de la persona: {PersonaId}, Id del evento: {EventoDeportivoId}, Fecha y hora: {FechaAltaReserva}, Estado: {EstadoAsistencia}";
    }
}