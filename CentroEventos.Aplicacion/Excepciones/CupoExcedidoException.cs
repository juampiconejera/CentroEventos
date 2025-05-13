using System;

namespace CentroEventos.Aplicacion.Excepciones;

public class CupoExcedidoException : Exception
{
    public CupoExcedidoException() {}
    public CupoExcedidoException(string mensaje) : base (mensaje) {}
}
