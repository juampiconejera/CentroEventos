using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Enumerativos;

namespace CentroEventos.Aplicacion.CasosDeUso.EventoDeportivoCasosDeUso;

public class AltaEventoDeportivoUseCase(IRepositorioEventoDeportivo repoEventoDeportivo, IRepositorioUsuario repoUsuario, IRepositorioPersona repoPersona, IServicioAutorizacion Auth, EventoDeportivoValidador eventoDeportivoValidador)
{
    public void Ejecutar(EventoDeportivo eventoDeportivo, int idUsuario)
    {
        var usuario = repoUsuario.ObtenerUsuario(idUsuario);
         if(!Auth.PoseeElPermiso(usuario.Permisos, Permiso.EventoAlta ))
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
