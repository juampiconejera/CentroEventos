using System;
using System.Diagnostics.Tracing;
using CentroEventos.Aplicacion.CasosDeUso.EventoDeportivoCasosDeUso;
using CentroEventos.Aplicacion.CasosDeUso.ReservaCasosDeUso;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Repositorios;

public class RepositorioEventoDeportivo : IRepositorioEventoDeportivo
{
    readonly string _nombreArchivo = "eventos.txt";
    private int GenerarId()
    {
        return 1;
    }
    public void Agregar(EventoDeportivo eventoDeportivo)
    {
        eventoDeportivo.Id = GenerarId();
        using var sw = new StreamWriter(_nombreArchivo, true);
        sw.WriteLine(eventoDeportivo.Id);
        sw.WriteLine(eventoDeportivo.Nombre);
        sw.WriteLine(eventoDeportivo.Descripcion);
        sw.WriteLine(eventoDeportivo.FechaHoraInicio);
        sw.WriteLine(eventoDeportivo.DuracionHoras);
        sw.WriteLine(eventoDeportivo.CupoMaximo);
        sw.WriteLine(eventoDeportivo.ResponsableId);
    }

    public List<EventoDeportivo> Listar()
    {
        var listaTotal = new List<EventoDeportivo>();
        using var sr = new StreamReader(_nombreArchivo);
        while (!sr.EndOfStream)
        {
            var evento = new EventoDeportivo();
            evento.Id = int.Parse(sr.ReadLine() ?? ""); evento.Nombre = sr.ReadLine(); evento.Descripcion = sr.ReadLine(); evento.FechaHoraInicio = DateTime.Parse(sr.ReadLine()); evento.DuracionHoras = double.Parse(sr.ReadLine()); evento.CupoMaximo = int.Parse(sr.ReadLine()); evento.ResponsableId = int.Parse(sr.ReadLine());
            listaTotal.Add(evento);
        }

        return listaTotal;
    }
}