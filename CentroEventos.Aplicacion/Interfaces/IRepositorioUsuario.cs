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
<<<<<<< HEAD
    void AsignarPermisos(int id, List<Permiso> listaPermisos);
=======
    
>>>>>>> b749e95fe0321adf19cfcdfa4878cf8e55807087
}
