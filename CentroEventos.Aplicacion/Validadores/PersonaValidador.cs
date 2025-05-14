using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.Validadores;

/*
○ Nombre, Apellido, DNI, Email no deben estar vacíos.       LISTO
○ DNI no puede repetirse entre Personas. (Requiere consulta a IRepositorioPersona)  
○ Email no puede repetirse entre Personas. (Requiere consulta a IRepositorioPersona)
*/
public class PersonaValidador
{
    public bool Validar(Persona persona, IRepositorioPersona repositorioPersona, out string mensajeError){
        bool validacion = true;
        mensajeError = "";
        //validacion nombre
        if(validacion & string.IsNullOrEmpty(persona.Nombre))
        {
            mensajeError = "Nombre de la persona invalido.\n";
            validacion = false;
        }
        //validacion apellido
        if(validacion & string.IsNullOrEmpty(persona.Apellido))
        {
            mensajeError = "Apellido de la persona invalido.\n";
            validacion = false;
        }
        //validacion dni
        if(validacion & string.IsNullOrEmpty(persona.Dni))
        {
            mensajeError = "DNI de la persona invalido.\n";
            validacion = false;
        }
        //validacion email
        if(validacion & string.IsNullOrEmpty(persona.Email))
        {
            mensajeError = "Email de la persona invalido.\n";
            validacion = false;
        }
        //validacion dni ya registrado
        if(validacion & !repositorioPersona.Listar().Contains(repositorioPersona.ObtenerPorDni(persona.Dni)))
        {
            mensajeError = "DNI ya registrado.\n";
            validacion = false;
        }
        //validacion email ya registrado
        if(validacion & !repositorioPersona.Listar().Contains(repositorioPersona.ObtenerPorEmail(persona.Email)))
        {
            mensajeError = "Email ya registrado.\n";
            validacion = false;
        }
        return validacion;
    }
}
