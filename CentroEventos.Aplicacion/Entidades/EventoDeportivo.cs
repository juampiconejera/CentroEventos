using System;
using System.Reflection;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.Entidades;

public class EventoDeportivo
{
    // Propiedades autoimplementadas
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public DateTime FechaHoraInicio { get; set; }
    public double DuracionHoras { get; set; }
    public int CupoMaximo { get; set; }
    public int ResponsableId { get; set; }

    // Constructor por defecto 
    public EventoDeportivo() { }

    // Constructor para inicializar propiedades al crear una instancia
    public EventoDeportivo(string nombre, string descripcion, DateTime fechaHoraInicio, double duracionHoras, int cupoMaximo, int responsableId)
    {
        Nombre = nombre;
        Descripcion = descripcion;
        FechaHoraInicio = fechaHoraInicio;
        DuracionHoras = duracionHoras;
        CupoMaximo = cupoMaximo;
        ResponsableId = responsableId;
    }

    public override string ToString()
    {
        return $"Id: {Id}, Nombre: {Nombre}, Descripcion: {Descripcion}, FechaHoraInicio: {FechaHoraInicio}, DuracionHoras: {DuracionHoras}, CupoMaximo: {CupoMaximo}, ResponsableId: {ResponsableId}";
    }
}
    



