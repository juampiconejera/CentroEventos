using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;

public class BajaEventoDeportivoUseCase(IRepositorioEventoDeportivo repoEventoDeportivo, IServicioAutorizacionProvisorio Auth)
{
    public void Ejecutar(int idEventoDeportivo, int idUsuario)
    {
        if (!Auth.PoseeElPermiso(idUsuario))
        {
            throw new FalloAutorizacionException("Usuario no autorizado.");
        }
        
        if (!repoEventoDeportivo.ExistePorId(idEventoDeportivo))
        {
            throw new EntidadNotFoundException("El evento deportivo no existe en la base de datos.");
        }

        repoEventoDeportivo.Eliminar(idEventoDeportivo);
    }
}
