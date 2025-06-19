using System;
using System.Net.Security;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Enumerativos;

namespace CentroEventos.Aplicacion.CasosDeUso.UsuarioCasosDeUso;

public class ModificarUsuarioUseCase(IRepositorioUsuario repoUsuario, IServicioAutorizacion Auth, UsuarioValidador usuarioValidador)
{
    public void Ejecutar(Usuario usuario, Usuario admin)
    {
        if (!Auth.PoseeElPermiso(admin.Permisos, Permiso.UsuarioModificacion))
        {
            throw new FalloAutorizacionException("Usuario no autorizado.");
        }
        if (!usuarioValidador.Validar(usuario, out string mensajeError))
        {
            throw new ValidacionException(mensajeError);
        }
        if (!repoUsuario.ExistePorId(usuario.Id))
        {
            throw new EntidadNotFoundException("Id del responsable no corresponde a una persona ");
        }

        repoUsuario.Modificar(usuario);
    }
}
