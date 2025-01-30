# ERC.UserManagement

## Descripci�n

**ERC.UserManagement** es un microservicio desarrollado en .NET Core 8 que implementa funcionalidades para gestionar usuarios. Entre las principales caracter�sticas se incluyen:

- Registro de cuentas de usuario.
- Inicio de sesi�n para obtener un token de acceso.
- Consulta de informaci�n de usuario.
- Consulta de cuentas de usuario.
- Consulta del historial de inicios de sesi�n.

## Instalaci�n

Para ejecutar este proyecto en tu m�quina local, sigue los siguientes pasos:

### Requisitos previos:

- **.NET Core 8** instalado en tu sistema.
- **Docker** instalado para la creaci�n de contenedores.

### Pasos:

1. **Restaurar los paquetes NuGet:**

   Ejecuta el siguiente comando en la ra�z del proyecto para restaurar los paquetes necesarios:

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

   **Nota:** El proyecto por defecto se ejecutar� en el puerto **8082**. Si este puerto est� ocupado en tu m�quina, modifica el valor del puerto en el archivo `docker-compose.yml` antes de iniciar el contenedor.

## Uso

Una vez que el contenedor est� en funcionamiento, puedes acceder a la API a trav�s de la interfaz de OpenApi (Swagger) en la siguiente URL:

[http://localhost:8082/swagger/index.html](http://localhost:8082/swagger/index.html)

Si modificaste el puerto en el archivo `docker-compose.yml`, aseg�rate de usar el nuevo puerto en la URL de Swagger.
