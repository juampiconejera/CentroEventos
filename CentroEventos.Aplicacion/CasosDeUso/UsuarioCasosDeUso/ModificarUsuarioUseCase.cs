using System;
using System.Net.Security;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Servicios;
using CentroEventos.Aplicacion.Validadores;

namespace CentroEventos.Aplicacion.CasosDeUso.UsuarioCasosDeUso;

public class ModificarUsuarioUseCase(IRepositorioUsuario repoUsuario, /* IServicioAutorizacion Auth, */ ServicioSHA256 servicioSHA256, UsuarioValidador usuarioValidador)
{
    public void Ejecutar(Usuario usuario, Usuario admin)
    {
        /* if (!Auth.PoseeElPermiso(admin))
        {
            throw new FalloAutorizacionException("Usuario no autorizado.");
        } */
        if (!usuarioValidador.Validar(usuario, out string mensajeError))
        {
            throw new ValidacionException(mensajeError);
        }
        if (!repoUsuario.ExistePorId(usuario.Id))
        {
            throw new EntidadNotFoundException("Id del responsable no corresponde a una persona ");
        }

        //Hashing del password
        string newPass = servicioSHA256.getSha256(usuario.Password);
        usuario.Password = newPass;

        repoUsuario.Modificar(usuario);
    }
}
