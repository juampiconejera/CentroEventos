using System;
using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Aplicacion.Validadores;
/*
○ Nombre, Apellido, DNI, Email no deben estar vacíos.       LISTO
○ DNI no puede repetirse entre Personas. (Requiere consulta a IRepositorioPersona)  
○ Email no puede repetirse entre Personas. (Requiere consulta a IRepositorioPersona)
*/
public class PersonaValidador
{
    public bool Validar(Persona persona, out string mensajeError){

        mensajeError = "";
        //validacion nombre
        if(string.IsNullOrEmpty(persona.Nombre))
        {
            mensajeError += "Nombre de la persona invalido.\n";
        }
        //validacion apellido
        if(string.IsNullOrEmpty(persona.Apellido))
        {
            mensajeError += "Apellido de la persona invalido.\n";
        }
        //validacion dni
        if(string.IsNullOrEmpty(persona.Dni))
        {
            mensajeError += "DNI de la persona invalido.\n";
        }
        //validacion email
        if(string.IsNullOrEmpty(persona.Email))
        {
            mensajeError += "Email de la persona invalido.\n";
        }
        return mensajeError == "";
    }
}
