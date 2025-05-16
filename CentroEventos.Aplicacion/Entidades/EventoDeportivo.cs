using System;
using System.Reflection;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.Entidades;
//Se van a usar validaciones , asi que no usamos propiedades auto implementadas.
public class EventoDeportivo : IRepositorioEventoDeportivo
{
    private int _id;    //único, debe ser autoincremental gestionado por el repositorio
    private string? _nombre;    //ej: "Clase de Spinning Avanzado", "Partido final de Vóley"
    private string? _descripcion;   
    private DateTime _fechaHoraInicio;  //DateTime - Fecha y hora exactas de inicio del evento)
    private double _duracionHoras;  //Duración del evento en horas, ej: 1.5 para una hora y media
    private int _cupoMaximo;        //Cantidad máxima de participantes permitidos)
    private int _cantidadReservas;
    private int _responsableId;     //Id de la Persona a cargo del evento)

    public int Id
    {
        get => _id;
        set => _id = value;
    }

    public string? Nombre
    {
        get => _nombre;
        set => _nombre = value;
    }

    public string? Descripcion
    {
        get => _descripcion;
        set => _descripcion = value;
    }

    public DateTime FechaHoraInicio
    {
        get => _fechaHoraInicio;
        set => _fechaHoraInicio = value;
    }

    public double DuracionHoras
    {
        get => _duracionHoras;
        set => _duracionHoras = value;
    }

    public int CupoMaximo
    {
        get => _cupoMaximo;
        set => _cupoMaximo = value;
    }

    public int CantidadReservas
    {
        get => _cantidadReservas;
    }
    
    public int ResponsableId
    {
        get => _responsableId;
        set => _responsableId = value;
    }

    public void Agregar(EventoDeportivo eventoDeportivo)
    {
        throw new NotImplementedException();
    }

    public void Eliminar(int id)
    {
        throw new NotImplementedException();
    }

    public List<EventoDeportivo> Listar()
    {
        throw new NotImplementedException();
    }

    public void Modificar(EventoDeportivo eventoDeportivo)
    {
        throw new NotImplementedException();
    }

    public EventoDeportivo ObtenerPorId(int id)
    {
        throw new NotImplementedException();
    }
    public bool ExistePorId(int id)
    {
        throw new NotImplementedException();
    }

    public override string ToString()
    {
        return ($"Id: {Id}, Nombre: {Nombre}, Descripcion: {Descripcion}, FechaHoraInicio: {FechaHoraInicio}, DuracionHoras: {DuracionHoras}, CupoMaximo: {CupoMaximo}, ResponsableId: {ResponsableId}");
    }
    
}

    



