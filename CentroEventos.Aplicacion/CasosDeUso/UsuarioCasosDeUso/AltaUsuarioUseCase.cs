using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
using System.Net.Security;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Validadores;

namespace CentroEventos.Aplicacion.CasosDeUso.UsuarioCasosDeUso;

public class AltaUsuarioUseCase(IRepositorioUsuario repoUsuario,/*  IRepositorioUsuario Auth, */ UsuarioValidador usuarioValidador)
{
    public void Ejecutar(Usuario usuario, Usuario admin)
    {
        //No verificamos la validacion de permisos ya que AltaUsuario se usa solamente para registrarse.
        if (!usuarioValidador.Validar(usuario, out string mensajeError))
        {
            throw new ValidacionException(mensajeError);
        }
        if (repoUsuario.ExistePorEmail(usuario.Email))
        {
            throw new DuplicadoException("El email ya fue registrado");
        }

        repoUsuario.Agregar(usuario);
    }
}
