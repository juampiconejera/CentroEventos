using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validadores;

namespace CentroEventos.Aplicacion.CasosDeUso;
public class AltaPersonaUseCase(IRepositorioPersona repositorioPersona, PersonaValidador personaValidador)
{
    public void Ejecutar(Persona persona)
    {
        if(personaValidador.Validar(persona, out string mensajeError))
        {
            throw new ValidacionException(mensajeError);
        }

        //validacion dni ya registrado
        if(!repositorioPersona.Listar().Contains(repositorioPersona.ObtenerPorDni(persona.Dni)))
        {
            throw new DuplicadoException("DNI ya registrado.\n");
        }

        //validacion email ya registrado
        if(!repositorioPersona.Listar().Contains(repositorioPersona.ObtenerPorEmail(persona.Email)))
        {
            throw new DuplicadoException("Email ya registrado.\n");
        }
        
        repositorioPersona.Agregar(persona);
    }
}
