# ERC.UserManagement

## Descripción

**ERC.UserManagement** es un microservicio desarrollado en .NET Core 8 que implementa funcionalidades para gestionar usuarios. Entre las principales características se incluyen:

- Registro de cuentas de usuario.
- Inicio de sesión para obtener un token de acceso.
- Consulta de información de usuario.
- Consulta de cuentas de usuario.
- Consulta del historial de inicios de sesión.

## Instalación

Para ejecutar este proyecto en tu máquina local, sigue los siguientes pasos:

### Requisitos previos:

- **.NET Core 8** instalado en tu sistema.
- **Docker** instalado para la creación de contenedores.

### Pasos:

1. **Restaurar los paquetes NuGet:**

   Ejecuta el siguiente comando en la raíz del proyecto para restaurar los paquetes necesarios:

   ```bash
   dotnet restore
   ```

2. **Aplicar migraciones:**

   Navega al proyecto `ERC.UserManagement.Infrastructure` y ejecuta las migraciones con el siguiente comando:

   ```bash
   dotnet ef database update
   ```

3. **Crear la imagen de Docker:**

   El proyecto contiene un archivo `Dockerfile` para crear la imagen del contenedor. Ejecuta el siguiente comando para construir la imagen:

   ```bash
   docker build -t user-manager-api .
   ```

4. **Iniciar el contenedor:**

   Con el archivo `docker-compose.yml`, puedes inicializar el contenedor ejecutando el siguiente comando:

   ```bash
   docker-compose up -d
   ```

   **Nota:** El proyecto por defecto se ejecutará en el puerto **8082**. Si este puerto está ocupado en tu máquina, modifica el valor del puerto en el archivo `docker-compose.yml` antes de iniciar el contenedor.

## Uso

Una vez que el contenedor esté en funcionamiento, puedes acceder a la API a través de la interfaz de OpenApi (Swagger) en la siguiente URL:

[http://localhost:8082/swagger/index.html](http://localhost:8082/swagger/index.html)

Si modificaste el puerto en el archivo `docker-compose.yml`, asegúrate de usar el nuevo puerto en la URL de Swagger.
