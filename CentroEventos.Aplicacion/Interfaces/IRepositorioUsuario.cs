using System;
using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Aplicacion.Interfaces;

public interface IRepositorioUsuario
{
    void Agregar(Usuario usuario);
    void Eliminar(int id);
    void Modificar(Usuario usuario);
    bool ExistePorId(int id);
    bool ExistePorEmail(string email);
    Usuario? ObtenerUsuario(int id);
    List<Usuario> listarUsuarios();
    
}
