using System;
using System.Diagnostics.Tracing;
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
}
