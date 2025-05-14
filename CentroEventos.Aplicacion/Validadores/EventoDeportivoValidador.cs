using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
    
namespace CentroEventos.Aplicacion.Validadores;
//toy pensando en meter como vamos a conectar esto con el repositorio IRepositorioPersona

/*
○ Nombre y Descripcion no deben estar vacíos.   LISTO
○ FechaHoraInicio debe ser posterior o igual a la fecha actual.     LISTO
○ CupoMaximo debe ser mayor que cero.      LISTO
○ DuracionHoras debe ser mayor que cero.    
○ ResponsableId debe corresponder a una Persona existente. (Requiere consulta a IRepositorioPersona)*/
public class EventoDeportivoValidador
{
    public bool Validar(EventoDeportivo eventoDeportivo, IRepositorioPersona repositorioPersona, out string mensajeError)
    {
        bool validacion = true;
        mensajeError = "";
        //Validar nombre y descripcion.
        if(validacion & string.IsNullOrWhiteSpace(eventoDeportivo.Nombre))
        {
            mensajeError = "Nombre del evento deportivo invalido.\n";
            validacion = false;
        }
        if(validacion & string.IsNullOrWhiteSpace(eventoDeportivo.Descripcion))
        {
            mensajeError = "Descripcion del evento deportivo invalida.\n";
            validacion = false;
        }
        //validad hora del evento.
        if(validacion & eventoDeportivo.FechaHoraInicio < DateTime.Now)
        {
            mensajeError = "La fecha y hora de inicio es anterior a la fecha actual.\n";
            validacion = false;
        }
        //validar cupoMaximo > 0
        if(validacion & eventoDeportivo.CupoMaximo <= 0)
        {
            mensajeError = "El cupo maximo es menor o igual a cero.\n";
            validacion = false;
        }
        //validar DuracionHoras > 0
        if(validacion & eventoDeportivo.DuracionHoras <= 0)
        {
            mensajeError = "La duracion en horas es menor o igual a cero.\n";
            validacion = false;
        }
        //validar ResponsableId
        if(validacion & !repositorioPersona.Listar().Contains(repositorioPersona.ObtenerPorId(eventoDeportivo.ResponsableId)))
        {
            mensajeError = "El Id del responsable no corresponde a una persona registrada.\n";
            validacion = false;
        }
        return validacion;    //retorna true si no hay error
    }
}