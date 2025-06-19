using System;

namespace CentroEventos.Aplicacion.Interfaces;

public interface IServicioSHA256
{
    string getSha256(string entrada);
}
