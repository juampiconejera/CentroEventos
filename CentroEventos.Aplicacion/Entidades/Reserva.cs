using System;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Enumerativos;
using Aplicacion;

namespace CentroEventos.Aplicacion.Entidades;
//Se van a usar validaciones , asi que no usamos propiedades auto implementadas.
public class Reserva : IRepositorioReserva
{
    private int _id;//único, debe ser autoincremental gestionado por el repositorio
    private int _personaId;//Id de la Persona que hace la reserva
    private int _eventoDeportivoId;//Id de la EventoDeportivo reservado
    private DateTime _fechaAltaReserva;//Fecha y hora en que se realizó la inscripción)
    /* private EstadoAsistencia _estado;//Pendiente, Presente, Ausente) */
    private EstadoAsistencia _estadoAsistencia;

    public int Id
    {
        get => _id;
        set => _id = value;
    }

    public int PersonaId
    {
        get => _personaId;
        set => _personaId = value;
    }

    public int EventoDeportivoId
    {
        get => _eventoDeportivoId;
        set => _eventoDeportivoId = value;
    }

    public DateTime FechaAltaReserva
    {
        get => _fechaAltaReserva;
        set => _fechaAltaReserva = value;
    }

    public EstadoAsistencia EstadoAsistencia
    {
        get => _estadoAsistencia;
        set => _estadoAsistencia = value;
    }

    public void Agregar(Reserva reserva)
    {
        throw new NotImplementedException();
    }

    public void Eliminar(int id)
    {
        throw new NotImplementedException();
    }

    public List<Reserva> Listar()
    {
        throw new NotImplementedException();
    }

    public void Modificar(Reserva reserva)
    {
        throw new NotImplementedException();
    }

    public Reserva ObtenerPorId(int id)
    {
        throw new NotImplementedException();
    }
    public List<EventoDeportivo> ListarEventos(int id)
    {
        throw new NotImplementedException();
    }

    public override string ToString(){
        return ($"Id de la reserva: {Id}, Id de la persona que realizó la reserva: {PersonaId}, Id del evento deportivo reservado: {EventoDeportivoId}, Fecha y hora: {FechaAltaReserva}, Estado: {EstadoAsistencia}");
    }
}