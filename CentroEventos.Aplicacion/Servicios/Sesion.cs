using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Aplicacion.Servicios;

public class Sesion
{
    public Usuario? UsuarioActual { get; private set; }
    
    public event Action? OnSesionCambiada;

    public bool EstaLogueado()
    {
        return UsuarioActual != null;
    }

    public void Iniciar(Usuario usuario)
    {
        UsuarioActual = usuario;
        
        OnSesionCambiada?.Invoke();
    }

    public void CerrarSesion()
    {
        UsuarioActual = null;

        OnSesionCambiada?.Invoke();
    }
}