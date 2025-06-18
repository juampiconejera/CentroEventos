using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Validadores;

namespace CentroEventos.Aplicacion.CasosDeUso.PersonaCasosDeUso;

public class ModificacionPersonaUseCase(IRepositorioPersona repoPersona, IServicioAutorizacion Auth, PersonaValidador personaValidador)
{
    public void Ejecutar(Persona persona, int idUsuario)
    {
       //Verificamos los permisos del usuario
        /* if (!Auth.PoseeElPermiso(idUsuario))
        {
            throw new FalloAutorizacionException("Usuario no autorizado.");
        } */
        //Validamos los datos de la persona
        if(!personaValidador.Validar(persona, out string mensajeError))
        {
            throw new ValidacionException(mensajeError);
        }

        if(!repoPersona.ExistePorId(persona.Id))
        {
            throw new EntidadNotFoundException("Id del responsable no corresponde a una persona registrada.\n");
        }

        //Buscamos la persona en el repositorio y si existe la modificamos
        repoPersona.Modificar(persona);
    }
}
