# Prueba técnica - Backend Developer (Geeks Hubs) 

## Introducción
Este repositorio es el resultado de una prueba técnica donde se pedía hacer una API REST en ASP.NET.

La mayor parte del esfuerzo se la ha llevado la arquitectura y las tecnologías empleadas con el fin de conseguir una base solida para el proyecto.

Cabe destacar que se han creado las operaciones CRUD convenientes en base a la finalidad del repositorio, respetando las convenciones de URL's para todos los endpoints.

## Tecnologías
Tecnologías usadas en el proyecto:
- .NET 6
- ASP.NET
- Entity Framework
- MediatR
- AutoMapper

## Arquitectura del Proyecto
- DDD
- CQRS

## Instalación
- En el fichero <b>appsettings.Development.json</b>, habrá que configurar la propiedad <ins>DefaultConnection</ins> con la conexión a la base de datos deseada.

- En la capa Domain hay incluido un fichero llamado <b>ScaffoldDbContext.txt</b> donde podemos encontrar los pasos a seguir para generar las entidades de ser necesario. El proyecto está orientado como DATABASE-FIRST.

- En la carpeta <b>Resources</b> se ha incluido el fichero <ins>creacion-tablas</ins> donde se pueden encontrar las sentencias SQL necesarias para crear las tablas que requiere el proyecto. Estas sentencias están pensadas para una base de datos SQL Server.

