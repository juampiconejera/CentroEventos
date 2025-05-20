using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validadores;


namespace CentroEventos.Aplicacion.CasosDeUso.EventoDeportivoCasosDeUso;

public class AltaEventoDeportivoUseCase(IRepositorioEventoDeportivo repoEventoDeportivo,IRepositorioPersona repoPersona, IServicioAutorizacionProvisorio Auth, EventoDeportivoValidador eventoDeportivoValidador)
{
    public void Ejecutar(EventoDeportivo eventoDeportivo, int idUsuario)
    {
        //Primero verificamos permisos
        if(!Auth.PoseeElPermiso(idUsuario))
        {
            throw new FalloAutorizacionException("Usuario no autorizado");
        }

        //Validamos el evento deportivo
        if(!eventoDeportivoValidador.Validar(eventoDeportivo, out string mensajeError))
        {
            throw new ValidacionException(mensajeError);
        }
        
        //Validar ResponsableId
        if(!repoPersona.ExistePorId(eventoDeportivo.ResponsableId))
        {
            throw new EntidadNotFoundException("Id del responsable no corresponde a una persona registrada.\n");
        }
        
        repoEventoDeportivo.Agregar(eventoDeportivo);
    }
}
