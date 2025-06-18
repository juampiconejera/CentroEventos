using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.CasosDeUso.UsuarioCasosDeUso;

public class ListarUsuarioUseCase(IRepositorioUsuario repoUsuario)
{
    public List<Usuario> Ejecutar()
    {
        return repoUsuario.listarUsuarios();
    }
}
