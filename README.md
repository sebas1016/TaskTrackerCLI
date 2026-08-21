# Task Tracker CLI

Aplicación de consola desarrollada en **C#** para gestionar tareas desde la línea de comandos.

## Funciones

- Agregar tareas
- Actualizar tareas
- Eliminar tareas
- Marcar tareas como `in-progress`
- Marcar tareas como `done`
- Listar todas las tareas
- Listar tareas completadas
- Listar tareas pendientes
- Listar tareas en progreso
- Guardar las tareas en un archivo JSON

## Tecnologías

- C#
- .NET
- JSON
- File System

## Uso

Clona el repositorio y ejecuta el proyecto:

```bash
dotnet run
```

Ejemplos:

```bash
dotnet run add "Aprender C#"
dotnet run list
dotnet run update 1 "Aprender C# y .NET"
dotnet run delete 1
dotnet run mark-in-progress 1
dotnet run mark-done 1
```

Las tareas se almacenan automáticamente en un archivo `tasks.json`.

## Estados

Las tareas pueden tener los siguientes estados:

- `todo`
- `in-progress`
- `done`

## Objetivo

Este proyecto fue desarrollado como práctica para aprender conceptos de **C#**, programación orientada a objetos, manejo de archivos, serialización JSON y construcción de aplicaciones CLI.
Url Project: https://roadmap.sh/projects/task-tracker
