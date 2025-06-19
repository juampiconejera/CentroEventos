using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validadores;

namespace CentroEventos.Aplicacion.CasosDeUso.UsuarioCasosDeUso;

public class RegistroUsuarioUseCase(IRepositorioUsuario repoUsuario, UsuarioValidador usuarioValidador)
{
  public void Ejecutar(string nombre, string apellido, string email, string password)
    {
        // Crear el objeto
        var nuevoUsuario = new Usuario(nombre, apellido, email, password);

        // Validar los campos
        if (!usuarioValidador.Validar(nuevoUsuario, out string mensajeError))
        {
            throw new ValidacionException(mensajeError);
        }

        // Validar duplicado
        if (repoUsuario.ExistePorEmail(email))
        {
            throw new DuplicadoException("Ya existe un usuario con ese email.");
        }

        // Guardar
        repoUsuario.Agregar(nuevoUsuario);
    }
}

