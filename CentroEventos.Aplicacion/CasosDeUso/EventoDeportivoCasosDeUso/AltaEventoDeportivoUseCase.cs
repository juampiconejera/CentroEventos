using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validadores;


namespace CentroEventos.Aplicacion.CasosDeUso;

public class AltaEventoDeportivoUseCase(IRepositorioEventoDeportivo repositorioEventoDeportivo,IRepositorioPersona repositorioPersona, EventoDeportivoValidador eventoDeportivoValidador)
{
    public void Ejecutar(EventoDeportivo eventoDeportivo)
    {
        if(eventoDeportivoValidador.Validar(eventoDeportivo, out string mensajeError))
        {
            throw new ValidacionException(mensajeError);
        }
        //validar ResponsableId
        if(!repositorioPersona.Listar().Contains(repositorioPersona.ObtenerPorId(eventoDeportivo.ResponsableId)))
        {
            throw new EntidadNotFoundException("Id del responsable no corresponde a una persona registrada.\n");
        }
    }
}
