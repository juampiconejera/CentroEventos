using System;
using CentroEventos.Aplicacion.Entidades;
    
namespace CentroEventos.Aplicacion.Validadores;

public class EventoDeportivoValidador
{
    public bool Validar(EventoDeportivo eventoDeportivo, out string mensajeError)
    {
        mensajeError = "";

        //Validar nombre y descripcion.
        if(string.IsNullOrWhiteSpace(eventoDeportivo.Nombre))
        {
            mensajeError += "Nombre del evento deportivo invalido.\n";
        }
        
        if(string.IsNullOrWhiteSpace(eventoDeportivo.Descripcion))
        {
            mensajeError += "Descripcion del evento deportivo invalida.\n";
        }

        //validad hora del evento.
        if(eventoDeportivo.FechaHoraInicio < DateTime.Now)
        {
            mensajeError += "La fecha y hora de inicio anterior a la fecha y hora actual\n";
        }

        //validar cupoMaximo > 0
        if(eventoDeportivo.CupoMaximo <= 0)
        {
            mensajeError += "El cupo maximo es menor o igual a cero.\n";
        }

        //validar DuracionHoras > 0
        if(eventoDeportivo.DuracionHoras <= 0)
        {
            mensajeError += "La duracion del evento es menor o igual a cero.\n";
        }

        return mensajeError == "";
    }
}