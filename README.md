# Proyecto API en ASP.NET - Sistema de Punto de Venta

Este proyecto es una API desarrollada en ASP.NET para un sistema de punto de venta. Incluye autenticación de usuarios mediante JWT y diferentes endpoints para gestionar usuarios, clientes, productos, direcciones, pedidos y detalles de pedidos.
Además en esta documentación podra enconrar el diagrama-relacional de la base de datos y sus tablas
***********
# Vista de la API
![image](https://github.com/RacsoJosu/SistemaPosApp/assets/101236726/5382fa99-6da2-473f-b3cd-e2bc9dba8ac2)


************

# Modelo Relacional
![image](https://github.com/RacsoJosu/SistemaPosApp/assets/101236726/0204d130-50f1-4bfd-a330-e9424c5981fb)

***********

# Pasos para Configurar el Proyecto

### Clonar el Repositorio

Primero, clona el repositorio del proyecto desde GitHub.

```bash
git clone https://github.com/RacsoJosu/SistemaPosApp.git
```
## Restaurar Paquetes NuGet

Abre el proyecto en Visual Studio 2022 y restaura los paquetes NuGet necesarios.

En el menú `Build`, selecciona `Restore NuGet Packages` 

También desde Visual Studio puedes intentar compilar y ejectura el programa para instalar las dependencias

si la información anterior no te funciona puedes vistitar la página (https://learn.microsoft.com/es-es/nuget/consume-packages/package-restore) para mas informacíon

## Crear la Base de Datos y conectarse a la base de datos

1. Abre SQL Server Management Studio (SSMS) y conéctate a tu instancia de SQL Server.
2. La instancia a la que te conectes deberas agregarla al archivo appsettings.json

    ```
          ConnectionStrings: {
          SistemaPosDB: Server=localhost\\{Tu_Instancia};Database=SistemaPosDB;Trusted_Connection=True;TrustServerCertificate=True;}  ```
   
3. Ejecuta el siguiente script de la base de datos ubicado en la carpeta SistemposApi/Scripts del proyecto esto creara la base de datos y agregara la data

*************

## Crendenciales
La API incluye varios endpoints controlados mediante autenticación JWT. despues de cargar los datos puedes usar las credenciales siguientees para probar el api:

- Admin: user2@example.com
- User: user@example.com
- Contraseñas: 1234 (las contraseñas están cifradas en la base de datos)

Algunos endpoints solo están accesibles para usuarios con el tipo Admin.

**************


# Features 
### AccountController

- **Iniciar Sesión (Login):**
  - **Descripción:** Endpoint para que los usuarios inicien sesión y generen un JWT para la autenticación de futuras solicitudes.
  - **Ruta:** `POST /api/Account/login`
  - **Autenticación requerida:** No se requiere autenticación.
  - **Parámetros de entrada:** Objeto JSON que contiene el correo electrónico (`Email`) y la contraseña (`Password`) del usuario.
  - **Respuestas:**
    - `200 OK`: Devuelve un token JWT en caso de éxito.
    - `400 Bad Request`: Si la contraseña es incorrecta.
    - `500 Internal Server Error`: Si ocurre un error interno.

- **Obtener Lista de Usuarios:**
  - **Descripción:** Endpoint para mostrar la lista de usuarios en la base de datos. Solo puede ser vista por usuarios Admin.
  - **Ruta:** `GET /api/Account/GetUserList`
  - **Autenticación requerida:** JWT, Roles permitidos: "Administrator".
  - **Respuestas:**
    - `200 OK`: Devuelve la lista de usuarios en la base de datos.
    - `401 Unauthorized`: Si el usuario no está autenticado.
    - `403 Forbidden`: Si el usuario autenticado no tiene permisos de administrador.
    - `500 Internal Server Error`: Si ocurre un error interno.

- **Registrar Usuario (Signup):**
  - **Descripción:** Endpoint para registrar nuevos usuarios en el sistema.
  - **Ruta:** `POST /api/Account/signup`
  - **Autenticación requerida:** No se requiere autenticación.
  - **Parámetros de entrada:** Objeto JSON que contiene la información del nuevo usuario (Nombre, Apellido, Email, Contraseña, Fecha de Nacimiento).
  - **Respuestas:**
    - `200 OK`: Devuelve los datos del usuario recién registrado.
    - `400 Bad Request`: Si el correo electrónico ya está en uso.
    - `500 Internal Server Error`: Si ocurre un error interno.

- **Cambiar Rol de Usuario:**
  - **Descripción:** Endpoint para cambiar el rol de un usuario específico. Solo puede ser usado por usuarios Admin.
  - **Ruta:** `PATCH /api/Account/ChangeRoleUser`
  - **Autenticación requerida:** JWT, Roles permitidos: "Administrator".
  - **Parámetros de entrada:** Objeto JSON que contiene el correo electrónico (`Email`) del usuario y el nuevo rol (`Role`).
  - **Respuestas:**
    - `200 OK`: Devuelve los datos del usuario con el rol actualizado.
    - `400 Bad Request`: Si el usuario no existe.
    - `401 Unauthorized`: Si el usuario no está autenticado.
    - `403 Forbidden`: Si el usuario autenticado no tiene permisos de administrador.
    - `500 Internal Server Error`: Si ocurre un error interno.

- **Eliminar Cuenta de Usuario:**
  - **Descripción:** Endpoint para eliminar cuentas de usuario. Solo los Admin pueden eliminar otros usuarios.
  - **Ruta:** `DELETE /api/Account/DeleteAccount/{email}`
  - **Autenticación requerida:** JWT, Roles permitidos: "Administrator".
  - **Parámetros de entrada:** `email` - Correo electrónico del usuario que se desea eliminar.
  - **Respuestas:**
    - `200 OK`: Devuelve los datos del usuario eliminado.
    - `400 Bad Request`: Si el usuario no existe.
    - `401 Unauthorized`: Si el usuario no está autenticado.
    - `403 Forbidden`: Si el usuario autenticado no tiene permisos de administrador.
    - `500 Internal Server Error`: Si ocurre un error interno.

### AddressController

- **Obtener Todas las Direcciones:**
  - **Descripción:** Endpoint para obtener todas las direcciones.
  - **Ruta:** `GET /api/Address/GetAll`
  - **Autenticación requerida:** JWT, Roles permitidos: "Administrator", "User".
  - **Parámetros de entrada:** Ninguno.
  - **Respuestas:**
    - `200 OK`: Devuelve la lista de todas las direcciones.
    - `401 Unauthorized`: Si el usuario no está autenticado.
    - `403 Forbidden`: Si el usuario autenticado no tiene permisos.
    - `500 Internal Server Error`: Si ocurre un error interno.

- **Obtener una Dirección por su ID:**
  - **Descripción:** Endpoint para obtener una dirección por su ID.
  - **Ruta:** `GET /api/Address/GetOne/{IdAddress}`
  - **Autenticación requerida:** JWT, Roles permitidos: "Administrator", "User".
  - **Parámetros de entrada:** `IdAddress` - ID de la dirección que se desea obtener.
  - **Respuestas:**
    - `200 OK`: Devuelve los datos de la dirección solicitada.
    - `404 Not Found`: Si la dirección no existe.
    - `401 Unauthorized`: Si el usuario no está autenticado.
    - `403 Forbidden`: Si el usuario autenticado no tiene permisos.
    - `500 Internal Server Error`: Si ocurre un error interno.

- **Agregar una Nueva Dirección:**
  - **Descripción:** Endpoint para agregar una nueva dirección.
  - **Ruta:** `POST /api/Address/AddAddress`
  - **Autenticación requerida:** JWT, Roles permitidos: "Administrator", "User".
  - **Parámetros de entrada:** Objeto JSON que contiene los datos de la nueva dirección.
  - **Respuestas:**
    - `200 OK`: Devuelve los datos de la dirección recién agregada.
    - `400 Bad Request`: Si hay un error en los datos de entrada.
    - `401 Unauthorized`: Si el usuario no está autenticado.
    - `403 Forbidden`: Si el usuario autenticado no tiene permisos.
    - `500 Internal Server Error`: Si ocurre un error interno.

- **Actualizar una Dirección:**
  - **Descripción:** Endpoint para actualizar una dirección existente.
  - **Ruta:** `PATCH /api/Address/Update/{IdAddress}`
  - **Autenticación requerida:** JWT, Roles permitidos: "Administrator", "User".
  - **Parámetros de entrada:** `IdAddress` - ID de la dirección que se desea actualizar. Objeto JSON que contiene los nuevos datos de la dirección.
  - **Respuestas:**
    - `200 OK`: Devuelve un mensaje de éxito.
    - `404 Not Found`: Si la dirección no existe.
    - `401 Unauthorized`: Si el usuario no está autenticado.
    - `403 Forbidden`: Si el usuario autenticado no tiene permisos.
    - `500 Internal Server Error`: Si ocurre un error interno.

- **Eliminar una Dirección:**
  - **Descripción:** Endpoint para eliminar una dirección.
  - **Ruta:** `DELETE /api/Address/Delete/{IdAddress}`
  - **Autenticación requerida:** JWT, Roles permitidos: "Administrator", "User".
  - **Parámetros de entrada:** `IdAddress` - ID de la dirección que se desea eliminar.
  - **Respuestas:**
    - `200 OK`: Devuelve un mensaje de éxito.
    - `404 Not Found`: Si la dirección no existe.
    - `401 Unauthorized`: Si el usuario no está autenticado.
    - `403 Forbidden`: Si el usuario autenticado no tiene permisos.
    - `500 Internal Server Error`: Si ocurre un error interno.

### CustomerController
- **Obtener Todos los Clientes:**
  - **Descripción:** Endpoint para obtener todos los clientes.
  - **Ruta:** `GET /api/Customer/GetAll`
  - **Autenticación requerida:** JWT, Roles permitidos: "Administrator", "User".
  - **Parámetros de entrada:** Ninguno.
  - **Respuestas:**
    - `200 OK`: Devuelve la lista de todos los clientes.
    - `401 Unauthorized`: Si el usuario no está autenticado.
    - `403 Forbidden`: Si el usuario autenticado no tiene permisos.
    - `500 Internal Server Error`: Si ocurre un error interno.

- **Obtener un Cliente por su ID:**
  - **Descripción:** Endpoint para obtener un cliente por su ID.
  - **Ruta:** `GET /api/Customer/GetOne/{IdCustomer}`
  - **Autenticación requerida:** JWT, Roles permitidos: "Administrator", "User".
  - **Parámetros de entrada:** `IdCustomer` - ID del cliente que se desea obtener.
  - **Respuestas:**
    - `200 OK`: Devuelve los datos del cliente solicitado.
    - `404 Not Found`: Si el cliente no existe.
    - `401 Unauthorized`: Si el usuario no está autenticado.
    - `403 Forbidden`: Si el usuario autenticado no tiene permisos.
    - `500 Internal Server Error`: Si ocurre un error interno.

- **Agregar un Nuevo Cliente:**
  - **Descripción:** Endpoint para agregar un nuevo cliente.
  - **Ruta:** `POST /api/Customer/AddCustomer`
  - **Autenticación requerida:** JWT, Roles permitidos: "Administrator", "User".
  - **Parámetros de entrada:** Objeto JSON que contiene los datos del nuevo cliente.
  - **Respuestas:**
    - `200 OK`: Devuelve los datos del cliente recién agregado.
    - `400 Bad Request`: Si hay un error en los datos de entrada.
    - `401 Unauthorized`: Si el usuario no está autenticado.
    - `403 Forbidden`: Si el usuario autenticado no tiene permisos.
    - `500 Internal Server Error`: Si ocurre un error interno.

- **Actualizar un Cliente:**
  - **Descripción:** Endpoint para actualizar un cliente existente.
  - **Ruta:** `PATCH /api/Customer/Update/{IdCustomer}`
  - **Autenticación requerida:** JWT, Roles permitidos: "Administrator", "User".
  - **Parámetros de entrada:** `IdCustomer` - ID del cliente que se desea actualizar. Objeto JSON que contiene los nuevos datos del cliente.
  - **Respuestas:**
    - `200 OK`: Devuelve un mensaje de éxito.
    - `404 Not Found`: Si el cliente no existe.
    - `401 Unauthorized`: Si el usuario no está autenticado.
    - `403 Forbidden`: Si el usuario autenticado no tiene permisos.
    - `500 Internal Server Error`: Si ocurre un error interno.

- **Eliminar un Cliente:**
  - **Descripción:** Endpoint para eliminar un cliente.
  - **Ruta:** `DELETE /api/Customer/Delete/{IdCustomer}`
  - **Autenticación requerida:** JWT, Roles permitidos: "Administrator", "User".
  - **Parámetros de entrada:** `IdCustomer` - ID del cliente que se desea eliminar.
  - **Respuestas:**
    - `200 OK`: Devuelve un mensaje de éxito.
    - `404 Not Found`: Si el cliente no existe.
    - `401 Unauthorized`: Si el usuario no está autenticado.
    - `403 Forbidden`: Si el usuario autenticado no tiene permisos.
    - `500 Internal Server Error`: Si ocurre un error interno.

### OrderController

- **Obtener Todos los Pedidos:**
  - **Descripción:** Endpoint para obtener todos los pedidos.
  - **Ruta:** `GET /api/Order/GetAll`
  - **Autenticación requerida:** JWT, Roles permitidos: "Administrator", "User".
  - **Parámetros de entrada:** Ninguno.
  - **Respuestas:**
    - `200 OK`: Devuelve la lista de todos los pedidos.
    - `401 Unauthorized`: Si el usuario no está autenticado.
    - `403 Forbidden`: Si el usuario autenticado no tiene permisos.
    - `500 Internal Server Error`: Si ocurre un error interno.

- **Obtener un Pedido por su ID:**
  - **Descripción:** Endpoint para obtener un pedido por su ID.
  - **Ruta:** `GET /api/Order/GetOne/{IdOrder}`
  - **Autenticación requerida:** JWT, Roles permitidos: "Administrator", "User".
  - **Parámetros de entrada:** `IdOrder` - ID del pedido que se desea obtener.
  - **Respuestas:**
    - `200 OK`: Devuelve los datos del pedido solicitado.
    - `404 Not Found`: Si el pedido no existe.
    - `401 Unauthorized`: Si el usuario no está autenticado.
    - `403 Forbidden`: Si el usuario autenticado no tiene permisos.
    - `500 Internal Server Error`: Si ocurre un error interno.

- **Agregar un Nuevo Pedido:**
  - **Descripción:** Endpoint para agregar un nuevo pedido.
  - **Ruta:** `POST /api/Order/AddOrder`
  - **Autenticación requerida:** JWT, Roles permitidos: "Administrator", "User".
  - **Parámetros de entrada:** Objeto JSON que contiene los datos del nuevo pedido.
  - **Respuestas:**
    - `200 OK`: Devuelve los datos del pedido recién agregado.
    - `400 Bad Request`: Si hay un error en los datos de entrada.
    - `401 Unauthorized`: Si el usuario no está autenticado.
    - `403 Forbidden`: Si el usuario autenticado no tiene permisos.
    - `500 Internal Server Error`: Si ocurre un error interno.

- **Agregar un Artículo a un Pedido:**
  - **Descripción:** Endpoint para agregar un artículo a un pedido existente.
  - **Ruta:** `POST /api/Order/AddItemOrder`
  - **Autenticación requerida:** JWT, Roles permitidos: "Administrator", "User".
  - **Parámetros de entrada:** Objeto JSON que contiene los datos del artículo a agregar.
  - **Respuestas:**
    - `200 OK`: Devuelve los detalles del artículo agregado al pedido.
    - `400 Bad Request`: Si hay un error en los datos de entrada.
    - `401 Unauthorized`: Si el usuario no está autenticado.
    - `403 Forbidden`: Si el usuario autenticado no tiene permisos.
    - `500 Internal Server Error`: Si ocurre un error interno.

- **Actualizar un Pedido:**
  - **Descripción:** Endpoint para actualizar un pedido existente.
  - **Ruta:** `PATCH /api/Order/Update/{IdOrder}`
  - **Autenticación requerida:** JWT, Roles permitidos: "Administrator", "User".
  - **Parámetros de entrada:** `IdOrder` - ID del pedido que se desea actualizar. Objeto JSON que contiene los nuevos datos del pedido.
  - **Respuestas:**
    - `200 OK`: Devuelve un mensaje de éxito.
    - `404 Not Found`: Si el pedido no existe.
    - `401 Unauthorized`: Si el usuario no está autenticado.
    - `403 Forbidden`: Si el usuario autenticado no tiene permisos.
    - `500 Internal Server Error`: Si ocurre un error interno.

- **Eliminar un Pedido:**
  - **Descripción:** Endpoint para eliminar un pedido.
  - **Ruta:** `DELETE /api/Order/Delete/{IdOrder}`
  - **Autenticación requerida:** JWT, Roles permitidos: "Administrator", "User".
  - **Parámetros de entrada:** `IdOrder` - ID del pedido que se desea eliminar.
  - **Respuestas:**
    - `200 OK`: Devuelve un mensaje de éxito.
    - `404 Not Found`: Si el pedido no existe.
    - `401 Unauthorized`: Si el usuario no está autenticado.
    - `403 Forbidden`: Si el usuario autenticado no tiene permisos.
    - `500 Internal Server Error`: Si ocurre un error interno.

### ProductController

- **Obtener Todos los Productos:**
  - **Descripción:** Endpoint para obtener todos los productos.
  - **Ruta:** `GET /api/Product/GetAll`
  - **Autenticación requerida:** JWT, Roles permitidos: "Administrator", "User".
  - **Parámetros de entrada:** Ninguno.
  - **Respuestas:**
    - `200 OK`: Devuelve la lista de todos los productos.
    - `401 Unauthorized`: Si el usuario no está autenticado.
    - `403 Forbidden`: Si el usuario autenticado no tiene permisos.
    - `500 Internal Server Error`: Si ocurre un error interno.

- **Obtener un Producto por su ID:**
  - **Descripción:** Endpoint para obtener un producto por su ID.
  - **Ruta:** `GET /api/Product/{IdProduct}`
  - **Autenticación requerida:** JWT, Roles permitidos: "Administrator", "User".
  - **Parámetros de entrada:** `IdProduct` - ID del producto que se desea obtener.
  - **Respuestas:**
    - `200 OK`: Devuelve los datos del producto solicitado.
    - `404 Not Found`: Si el producto no existe.
    - `401 Unauthorized`: Si el usuario no está autenticado.
    - `403 Forbidden`: Si el usuario autenticado no tiene permisos.
    - `500 Internal Server Error`: Si ocurre un error interno.

- **Agregar un Nuevo Producto:**
  - **Descripción:** Endpoint para agregar un nuevo producto.
  - **Ruta:** `POST /api/Product/AddProduct`
  - **Autenticación requerida:** JWT, Roles permitidos: "Administrator", "User".
  - **Parámetros de entrada:** Objeto JSON que contiene los datos del nuevo producto.
  - **Respuestas:**
    - `200 OK`: Devuelve los datos del producto recién agregado.
    - `400 Bad Request`: Si hay un error en los datos de entrada.
    - `401 Unauthorized`: Si el usuario no está autenticado.
    - `403 Forbidden`: Si el usuario autenticado no tiene permisos.
    - `500 Internal Server Error`: Si ocurre un error interno.

- **Actualizar un Producto:**
  - **Descripción:** Endpoint para actualizar un producto existente.
  - **Ruta:** `PATCH /api/Product/Update/{IdProduct}`
  - **Autenticación requerida:** JWT, Roles permitidos: "Administrator", "User".
  - **Parámetros de entrada:** `IdProduct` - ID del producto que se desea actualizar. Objeto JSON que contiene los nuevos datos del producto.
  - **Respuestas:**
    - `200 OK`: Devuelve un mensaje de éxito.
    - `404 Not Found`: Si el producto no existe.
    - `401 Unauthorized`: Si el usuario no está autenticado.
    - `403 Forbidden`: Si el usuario autenticado no tiene permisos.
    - `500 Internal Server Error`: Si ocurre un error interno.

- **Eliminar un Producto:**
  - **Descripción:** Endpoint para eliminar un producto.
  - **Ruta:** `DELETE /api/Product/Delete/{IdProduct}`
  - **Autenticación requerida:** JWT, Roles permitidos: "Administrator", "User".
  - **Parámetros de entrada:** `IdProduct` - ID del producto que se desea eliminar.
  - **Respuestas:**
    - `200 OK`: Devuelve un mensaje de éxito.
    - `404 Not Found`: Si el producto no existe.
    - `401 Unauthorized`: Si el usuario no está autenticado.
    - `403 Forbidden`: Si el usuario autenticado no tiene permisos.
    - `500 Internal Server Error`: Si ocurre un error interno.



************

# Entidades del Proyecto 
### Usuario
- **Id:** Identificador único (VARCHAR 255)
- **Nombre:** Nombre del usuario (VARCHAR 200)
- **Password:** Contraseña del usuario (VARCHAR 255)
- **Apellido:** Apellido del usuario (VARCHAR 200)
- **Email:** Correo electrónico del usuario (VARCHAR 100)
- **FechaNacimiento:** Fecha de nacimiento del usuario (DATE)
- **TipoUsuario:** Tipo de usuario ('User' o 'Admin') (VARCHAR 10)
- **EstaEliminado:** Indicador de eliminación (BIT)
- **CreatedAt:** Fecha de creación (DATETIME)
- **UpdatedAt:** Fecha de actualización (DATETIME)
- **DeletedAt:** Fecha de eliminación (DATETIME)

### Cliente
- **Id:** Identificador único (INT, IDENTITY)
- **Nombre:** Nombre del cliente (VARCHAR 200)
- **Apellido:** Apellido del cliente (VARCHAR 200)
- **Email:** Correo electrónico del cliente (VARCHAR 100)
- **EstaEliminado:** Indicador de eliminación (BIT)
- **FechaNacimiento:** Fecha de nacimiento del cliente (DATE)
- **CodigoPostal:** Código postal del cliente (VARCHAR 200)
- **NumeroTelefono:** Número de teléfono del cliente (VARCHAR 200)
- **CreatedAt:** Fecha de creación (DATETIME)
- **UpdatedAt:** Fecha de actualización (DATETIME)
- **DeletedAt:** Fecha de eliminación (DATETIME)

### Categoria
- **Id:** Identificador único (INT, IDENTITY)
- **Nombre:** Nombre de la categoría (NVARCHAR 100)
- **Descripcion:** Descripción de la categoría (TEXT)
- **EstaEliminado:** Indicador de eliminación (BIT)
- **CreatedAt:** Fecha de creación (DATETIME)
- **UpdatedAt:** Fecha de actualización (DATETIME)
- **DeletedAt:** Fecha de eliminación (DATETIME)

### Producto
- **Id:** Identificador único (INT, IDENTITY)
- **Nombre:** Nombre del producto (VARCHAR 200)
- **Descripcion:** Descripción del producto (TEXT)
- **PrecioUnitario:** Precio unitario del producto (FLOAT 4)
- **CantidadUnidad:** Cantidad en unidad del producto (FLOAT 4)
- **Medida:** Medida del producto (VARCHAR 10)
- **IdCategoria:** Identificador de la categoría (INT)
- **CreatedAt:** Fecha de creación (DATETIME)
- **UpdatedAt:** Fecha de actualización (DATETIME)
- **DeletedAt:** Fecha de eliminación (DATETIME)
- **IsDeleted:** Indicador de eliminación (BIT)

### Direccion
- **Id:** Identificador único (INT, IDENTITY)
- **Calle:** Calle de la dirección (VARCHAR 100)
- **Municipio:** Municipio de la dirección (VARCHAR 100)
- **Ciudad:** Ciudad de la dirección (VARCHAR 200)
- **Descripcion:** Descripción adicional de la dirección (TEXT)
- **IdCliente:** Identificador del cliente (INT)
- **EstaEliminado:** Indicador de eliminación (BIT)
- **CreatedAt:** Fecha de creación (DATETIME)
- **UpdatedAt:** Fecha de actualización (DATETIME)
- **DeletedAt:** Fecha de eliminación (DATETIME)

### Pedido
- **Id:** Identificador único (INT, IDENTITY)
- **FechaPedido:** Fecha del pedido (DATETIME)
- **Estado:** Estado del pedido (BIT)
- **ISV:** Impuesto sobre ventas (FLOAT 4)
- **MontoTotal:** Monto total del pedido (FLOAT 4)
- **IdUsuario:** Identificador del usuario (VARCHAR 255)
- **IdCliente:** Identificador del cliente (INT)
- **IdDireccion:** Identificador de la dirección (INT)
- **UpdatedAt:** Fecha de actualización (DATETIME)
- **DeletedAt:** Fecha de eliminación (DATETIME)

### Detalle_Pedido
- **Id:** Identificador único (INT, IDENTITY)
- **CantidadProducto:** Cantidad de producto (INT)
- **Descuento:** Descuento aplicado (FLOAT 4)
- **IdPedido:** Identificador del pedido (INT)
- **IdProducto:** Identificador del producto (INT)

