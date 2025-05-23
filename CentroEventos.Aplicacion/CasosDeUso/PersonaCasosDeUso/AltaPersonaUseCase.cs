using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validadores;

namespace CentroEventos.Aplicacion.CasosDeUso.PersonaCasosDeUso;
public class AltaPersonaUseCase(IRepositorioPersona repoPersona, IServicioAutorizacionProvisorio Auth, PersonaValidador personaValidador)
{
    public void Ejecutar(Persona persona, int idUsuario)
    {
        if(!Auth.PoseeElPermiso(idUsuario))
        {
            throw new FalloAutorizacionException("Usuario no autorizado.");
        }
        if(!personaValidador.Validar(persona, out string mensajeError))
        {
            throw new ValidacionException(mensajeError);
        }

        //validacion dni ya registrado
        if(repoPersona.ExistePorDni(persona.Dni))
        {
            throw new DuplicadoException("DNI ya registrado. \n");
        } 
            

        //validacion email ya registrado
        if(repoPersona.ExistePorEmail(persona.Email))
        {
            throw new DuplicadoException("Email ya registrado.\n");
        }
        
        repoPersona.Agregar(persona);
    }
}
