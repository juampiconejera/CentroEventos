using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.CasosDeUso.UsuarioCasosDeUso;

public class LoginUseCase(IRepositorioUsuario repoUsuario)
{
    public Usuario Ejecutar(string email, string password)
{
    var usuario = repoUsuario.ObtenerPorEmail(email);

    if (usuario is null || usuario.Password != password)
    {
        throw new FalloAutorizacionException("Email o contraseña incorrectos.");
    }

    return usuario;
}
}
