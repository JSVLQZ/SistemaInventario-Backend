# SistemaInventario Backend

API REST desarrollada con **C# y .NET 9** para la gestión y control de inventarios tecnológicos.

El proyecto surge a partir de la experiencia trabajando con sistemas empresariales de gestión de equipos e inventarios. Su objetivo es profundizar en el desarrollo backend, diseño de bases de datos y aplicación de reglas de negocio mediante una solución desarrollada desde cero.

## Tecnologías

* **C#**
* **.NET 9**
* **ASP.NET Core 9**
* **Entity Framework Core 9**
* **Pomelo.EntityFrameworkCore.MySql 9**
* **MariaDB**
* **SQL**
* **DBeaver**
* **Visual Studio**
* **Git / GitHub**

## Estructura de la solución

La solución está organizada en diferentes proyectos para separar responsabilidades y facilitar su evolución:

```text
SistemaInventario
│
├── SistemaInventario.API
│   ├── Controllers
│   ├── DTOs
│   └── Program.cs
│
├── SistemaInventario.Data
│   ├── Entities
│   └── InventarioDbContext
│
└── Sistema.Inventario.Services
    └── Proyecto preparado para incorporar servicios
```

### SistemaInventario.API

Contiene la API REST, incluyendo los controladores, DTOs y la configuración principal de la aplicación.

### SistemaInventario.Data

Contiene las entidades del dominio y el `InventarioDbContext`, utilizado por Entity Framework Core para la interacción con la base de datos.

### Sistema.Inventario.Services

Proyecto preparado para incorporar servicios y lógica de negocio conforme avance el desarrollo.

## Funcionalidades

Actualmente el sistema contempla la gestión de diferentes recursos relacionados con un entorno de inventario tecnológico:

* Equipos
* Usuarios
* Asignaciones de equipos
* Histórico de asignaciones
* Componentes
* Periféricos
* Proveedores
* Renting
* Sedes
* Licencias de software
* Tickets
* Categorías de tickets
* Comentarios

## Reglas de negocio

El sistema incorpora validaciones y reglas de negocio para controlar diferentes operaciones.

### Gestión de asignaciones

Entre las reglas implementadas se encuentran:

* Validación de existencia de equipos.
* Validación de existencia de usuarios.
* Prevención de asignaciones duplicadas.
* Registro histórico de las asignaciones.
* Cierre del histórico anterior cuando cambia el usuario asignado.
* Creación de un nuevo registro histórico para la nueva asignación.

Estas reglas permiten mantener la **trazabilidad de las asignaciones de equipos** y conservar su historial.

## API REST

La API utiliza diferentes métodos HTTP para gestionar los recursos:

| Método   | Uso                     |
| -------- | ----------------------- |
| `GET`    | Consultar información   |
| `POST`   | Crear recursos          |
| `PATCH`  | Actualizar parcialmente |
| `DELETE` | Eliminar recursos       |

La API también utiliza diferentes códigos de respuesta HTTP para representar el resultado de las operaciones, incluyendo solicitudes exitosas, recursos inexistentes y solicitudes inválidas.

## DTOs

La API utiliza **Data Transfer Objects (DTOs)** para controlar la información intercambiada entre los clientes y los endpoints.

Se utilizan DTOs específicos para diferentes operaciones, incluyendo procesos de creación y actualización.

## Base de datos

El proyecto utiliza **MariaDB** como motor de base de datos.

La comunicación entre la aplicación y la base de datos se realiza mediante:

```text
ASP.NET Core
      ↓
Entity Framework Core
      ↓
Pomelo.EntityFrameworkCore.MySql
      ↓
MariaDB
```

El modelo de datos contempla entidades relacionadas con equipos, usuarios, asignaciones, histórico y demás recursos del sistema.

La administración y consulta de la base de datos se realiza mediante **DBeaver**.

## Estado del proyecto

🚧 **En desarrollo**

El proyecto continúa evolucionando con la incorporación progresiva de nuevas funcionalidades y mejoras técnicas.

## Próximas mejoras

Entre las mejoras previstas se encuentran:

* Manejo global de excepciones.
* Autenticación y autorización mediante JWT.
* Fortalecimiento de validaciones y manejo de errores.
* Mejoras de seguridad.
* Documentación de endpoints.
* Incorporación de nuevas reglas de negocio.
* Evolución de la capa de servicios.

## Requisitos

Para ejecutar el proyecto se requiere:

* **.NET 9 SDK**
* **MariaDB**
* **Visual Studio**
* **Git**

## Configuración

### 1. Clonar el repositorio

```bash
git clone https://github.com/JSVLQZ/SistemaInventario-Backend.git
```

### 2. Configurar MariaDB

Crear una base de datos local para el proyecto.

La aplicación utiliza una cadena de conexión configurada mediante `ConnectionStrings:DbInventario`.

El archivo de configuración de desarrollo se encuentra en:

```text
SistemaInventario.API/appsettings.Development.json
```

Ejemplo:

```json
{
  "ConnectionStrings": {
    "DbInventario": "Server=localhost;Port=3307;Database=inventario;User=root;Password=TU_PASSWORD;"
  }
}
```

> **Nota:** La configuración anterior es únicamente un ejemplo. Utilice las credenciales correspondientes a su entorno local.

### 3. Restaurar las dependencias

Desde Visual Studio, restaurar las dependencias de la solución.

También puede utilizar:

```bash
dotnet restore
```

### 4. Ejecutar la aplicación

Abrir la solución en **Visual Studio** y ejecutar el proyecto `SistemaInventario.API`.

## Control de versiones

El proyecto utiliza **Git** para el control de versiones y **GitHub** como repositorio remoto.

## Autor

**Juan Sebastián Velásquez Páez**

[GitHub](https://github.com/JSVLQZ)
