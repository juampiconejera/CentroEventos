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
        if(!personaValidador.Validar(persona, repositorioPersona, out string mensajeError))
        {
            throw new ValidacionException(mensajeError);
        }
        repositorioPersona.Agregar(persona);
    }
}
