using System;

namespace CentroEventos.Aplicacion.Excepciones;

public class FalloAutorizacionException : Exception
{
    public FalloAutorizacionException() {}  //
    public FalloAutorizacionException(string mensaje) : base (mensaje) {}
}
