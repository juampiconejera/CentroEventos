using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Enumerativos;
public class BajaEventoDeportivoUseCase(IRepositorioEventoDeportivo repoEventoDeportivo, IRepositorioUsuario repoUsuario,  IServicioAutorizacion Auth)
{
    public void Ejecutar(int idEventoDeportivo, int idUsuario)
    {
         var usuario = repoUsuario.ObtenerUsuario(idUsuario);
         if(!Auth.PoseeElPermiso(usuario.Permisos, Permiso.EventoBaja ))
        {
            throw new FalloAutorizacionException("Usuario no autorizado");
        } 
        
        if (!repoEventoDeportivo.ExistePorId(idEventoDeportivo))
        {
            throw new EntidadNotFoundException("El evento deportivo no existe en la base de datos.");
        }

        repoEventoDeportivo.Eliminar(idEventoDeportivo);
    }
}
