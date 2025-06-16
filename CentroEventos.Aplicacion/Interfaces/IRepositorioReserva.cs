namespace CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
public interface IRepositorioReserva
    {
        void Agregar(Reserva reserva);
        void Eliminar(int id);
        void Modificar(Reserva reserva);
        Reserva ObtenerPorId(int id);
        bool ExistePorId(int id);
        List<Reserva> Listar();
        List<Reserva> ListarReservasPorEvento(int id);

    }