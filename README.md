#  Librería .NET para la API de Dátil

## 📝 Descripción

La librería .NET para la API de Dátil proporciona una manera simple y flexible de acceder a la API de Dátil desde aplicaciones .NET.

## 🔧 Requerimientos

- [.NET Framework 4.5](http://www.microsoft.com/en-us/download/details.aspx?id=30653) o superior
- Paquetes NuGet:
  - 📦 Newtonsoft.Json 7.0.1
  - 📦 RestSharp

## 💻 Instalación

1. Asegúrate de tener instalado .NET Framework 4.5 o superior.
2. Instala los paquetes NuGet necesarios usando el Administrador de Paquetes NuGet:

```
Install-Package Newtonsoft.Json -Version 7.0.1
Install-Package RestSharp
```

## 🚀 Ejemplos de Uso

Para ver ejemplos de cómo utilizar esta librería, consulta el archivo [FacturaEjemplo.cs](https://github.com/datil/link-dotnet/blob/master/EjemploCSharp/FacturaEjemplo.cs) en el repositorio.

## 🛠️ Desarrollo

### Requisitos para desarrollo

- 🍎 [Mono](https://www.mono-project.com/docs/getting-started/install/mac/) (para desarrollo en macOS)

### Compilación del proyecto

Para compilar el proyecto EjemploCSharp, utiliza el siguiente comando en la terminal:

```
msbuild EjemploCSharp.csproj
```

### Ejecución del programa

Después de compilar, puedes ejecutar el programa con:

```
mono bin/Debug/EjemploCSharp.exe
```
