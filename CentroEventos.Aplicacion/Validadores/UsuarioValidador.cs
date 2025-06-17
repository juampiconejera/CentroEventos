using System;
using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Aplicacion.Validadores;

public class UsuarioValidador
{
    public bool Validar(Usuario usuario, out string mensajeError)
    {
        mensajeError = "";
        //validacion nombre
        if (string.IsNullOrWhiteSpace(usuario.Nombre))
        { 
            mensajeError += "Nombre de la persona invalido.\n";
        }
        //validacion apellido
        if (string.IsNullOrWhiteSpace(usuario.Apellido))
        { 
            mensajeError += "Apellido de la persona invalido.\n";
        }
        //validacion email
        if (string.IsNullOrWhiteSpace(usuario.Email))
        { 
            mensajeError += "Email de la persona invalido.\n";
        }
        //validacion password
        if (string.IsNullOrWhiteSpace(usuario.Password))
        { 
            mensajeError += "Contraseña de la persona invalida.\n";
        }
        //no hago validador de permisos ya que un usuario puede no estar autorizado a nada
        return mensajeError == "";
    }
}
