using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Servicios;

namespace CentroEventos.Aplicacion.CasosDeUso.UsuarioCasosDeUso;

public class LoginUseCase(IRepositorioUsuario repoUsuario, ServicioSHA256 servicioSHA256)
{
    public Usuario Ejecutar(string email, string password)
{
    var usuario = repoUsuario.ObtenerPorEmail(email);
    string sha256Password = servicioSHA256.getSha256(password);

    if (usuario is null || usuario.Password != sha256Password)
    {
        throw new FalloAutorizacionException("Email o contraseña incorrectos.");
    }
    
    return usuario;
}
}
