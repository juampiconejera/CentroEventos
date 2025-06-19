using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
using System.Net.Security;
using CentroEventos.Aplicacion.Enumerativos;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Servicios;

namespace CentroEventos.Aplicacion.CasosDeUso.UsuarioCasosDeUso;

public class AltaUsuarioUseCase(IRepositorioUsuario repoUsuario, ServicioSHA256 servicioSHA256, UsuarioValidador usuarioValidador)
{
    public void Ejecutar(Usuario usuario)
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
        if (repoUsuario.listarUsuarios().Count == 0)
        {
            usuario.Permisos = Enum.GetValues<Permiso>().ToList();
        }
        //Hashing del password
        string newPass = servicioSHA256.getSha256(usuario.Password);
        usuario.Password = newPass;

        repoUsuario.Agregar(usuario);
    }
}
