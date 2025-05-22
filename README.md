
# Informe de Funcionalidades – CentroEventos

## Guía de prueba y validación desde Program.cs

**Autores**: Conejera Juan Pablo, Dogil Franco Matías, Brizzi Matías  
**Cátedra**: Seminario de Lenguajes – .NET – 1er Semestre 2025  
**Fecha**: 21 de mayo de 2025  

---

## ✅ Requisitos previos

- Tener instalado SDK de .NET 8.0  
- Sistema operativo con terminal  
- Descargar desde: https://dotnet.microsoft.com/en-us/download/dotnet/8.0

---

## 📁 Estructura del proyecto

```
CentroEventos/
├── CentroEventos.Aplicacion/
│   ├── CasosDeUso/
│   │   ├── EventoDeportivoCasosDeUso/
│   │   ├── PersonaCasosDeUso/
│   │   └── ReservaCasosDeUso/
│   ├── Entidades/
│   ├── Enumerativos/
│   ├── Excepciones/
│   ├── Interfaces/
│   └── Validadores/
├── CentroEventos.Consola/
└── CentroEventos.Repositorios/
```

---

## ▶️ Pasos para ejecutar

1. Descomprimir el archivo .ZIP  
2. Abrir una terminal en la carpeta `CentroEventos/CentroEventos.Consola`  
3. Ejecutar para compilar:
    ```bash
    dotnet build
    ```
4. Ejecutar el programa:
    ```bash
    dotnet run
    ```

---

## 📋 Funcionalidades

### 🔸 MENÚ PRINCIPAL
**Descripción**: Permite navegar entre repositorios de personas, eventos deportivos y reservas.  
**Modo de uso**:  
- Ingresar `1` para personas  
- Ingresar `2` para eventos deportivos  
- Ingresar `3` para reservas  

---

### 🔸 DAR DE ALTA PERSONA
```csharp
altaPersona.Ejecutar(nuevaPersona, listarPersona.Ejecutar()[0].Id);
```

---

### 🔸 MODIFICAR PERSONA
```csharp
modificarPersona.Ejecutar(personaModificar, listarPersona.Ejecutar()[0].Id);
```

---

### 🔸 LISTAR PERSONAS
```csharp
List<Persona> listaPersonas = listarPersona.Ejecutar();
foreach (Persona p in listaPersonas)
{
    Console.WriteLine(p);
}
```

---

### 🔸 ELIMINAR PERSONA
```csharp
bajaPersona.Ejecutar(idPersonaEliminar, listarPersona.Ejecutar()[0].Id);
```

---

### 🔸 AGREGAR EVENTO DEPORTIVO
```csharp
altaEvento.Ejecutar(nuevoEvento, listarPersona.Ejecutar()[0].Id);
```

---

### 🔸 MODIFICAR EVENTO DEPORTIVO
```csharp
modificarEvento.Ejecutar(eventoModificar, listarPersona.Ejecutar()[0].Id);
```

---

### 🔸 LISTAR EVENTOS DEPORTIVOS
```csharp
List<EventoDeportivo> listaEventos = listarEventoDeportivo.Ejecutar();
foreach (EventoDeportivo e in listaEventos)
{
    Console.WriteLine(e.ToString());
}
```

---

### 🔸 ELIMINAR EVENTO DEPORTIVO
```csharp
bajaEvento.Ejecutar(idEventoEliminar, listarPersona.Ejecutar()[0].Id);
```

---

### 🔸 DAR DE ALTA RESERVA
```csharp
altaReserva.Ejecutar(nuevaReserva, listarPersona.Ejecutar()[0].Id);
```

---

### 🔸 MODIFICAR RESERVA
```csharp
modificarReserva.Ejecutar(reservaModificar, listarPersona.Ejecutar()[0].Id);
```

---

### 🔸 LISTAR RESERVAS
```csharp
List<Reserva> listaReservas = listarReserva.Ejecutar();
foreach (Reserva r in listaReservas)
{
    Console.WriteLine(r.ToString());
}
```

---

### 🔸 ELIMINAR RESERVA
```csharp
bajaReserva.Ejecutar(idReservaEliminar, listarPersona.Ejecutar()[0].Id);
```

---

### 🔸 LISTAR EVENTOS CON CUPO DISPONIBLE
```csharp
List<EventoDeportivo> listaEventosDisponibles = listarEventosDisponibles.Ejecutar();
foreach (EventoDeportivo e in listaEventosDisponibles)
{
    Console.WriteLine(e.ToString());
}
```

---

### 🔸 LISTAR PERSONAS PRESENTES A UN EVENTO DETERMINADO
```csharp
List<Persona> listaAsistentes = listarAsistencia.Ejecutar(idEvento);
foreach (Persona p in listaAsistentes)
{
    Console.WriteLine(p.ToString());
}
```

---
