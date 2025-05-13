using System;

namespace CentroEventos.Aplicacion.Excepciones;

public class ValidacionException : Exception
{
    public ValidacionException() {}
    public ValidacionException(string mensaje) : base (mensaje) {}
}
