using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.provisional;


namespace CentroEventos.Aplicacion.CasosDeUso;

public class AltaEventoDeportivoUseCase(IRepositorioEventoDeportivo repoEventoDeportivo,IRepositorioPersona repoPersona, ServicioAutorizacionProvisorio Auth, EventoDeportivoValidador eventoDeportivoValidador)
{
    public void Ejecutar(EventoDeportivo eventoDeportivo, int idUsuario)
    {
        //primero verificar permisos
        if(!Auth.PoseeElPermiso(idUsuario))
        {
            throw new FalloAutorizacionException("Usuario no autorizado");
        }

        //validamos el evento deportivo
        if(!eventoDeportivoValidador.Validar(eventoDeportivo, out string mensajeError))
        {
            throw new ValidacionException(mensajeError);
        }
        
        //validar ResponsableId
        if(!repoPersona.ExistePorId(eventoDeportivo.ResponsableId))
        {
            throw new EntidadNotFoundException("Id del responsable no corresponde a una persona registrada.\n");
        }
        
        repoEventoDeportivo.Agregar(eventoDeportivo);
    }
}
