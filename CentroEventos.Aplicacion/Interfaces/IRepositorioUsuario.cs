using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Enumerativos;

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
    void AsignarPermisos(int id, List<Permiso> listaPermisos);
    void RetirarPermisos(int id, List<Permiso> listaPermisos);
    Usuario? ObtenerPorEmail(string email);
}
