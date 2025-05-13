using System;

namespace CentroEventos.Aplicacion.Excepciones;

public class DuplicadoException : Exception
{
    public DuplicadoException () {}
    public DuplicadoException(string mensaje) : base (mensaje) {}
}
