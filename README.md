# Proyecto API en ASP.NET - Sistema de Punto de Venta

Este proyecto es una API desarrollada en ASP.NET para un sistema de punto de venta. Incluye autenticación de usuarios mediante JWT y diferentes endpoints para gestionar usuarios, clientes, productos, direcciones, pedidos y detalles de pedidos.


## Pasos para Configurar el Proyecto

### Clonar el Repositorio

Primero, clona el repositorio del proyecto desde GitHub.

```bash
git clone https://github.com/tuusuario/sistema-pos.git
```
## Restaurar Paquetes NuGet

Abre el proyecto en Visual Studio 2022 y restaura los paquetes NuGet necesarios.

En el menú `Build`, selecciona `Restore NuGet Packages`.

## Crear la Base de Datos y conectarse a la base de datos

1. Abre SQL Server Management Studio (SSMS) y conéctate a tu instancia de SQL Server.
2. La instancia a la que te conectes deberas agregarla al archivo appsettings.json

    ```
          ConnectionStrings: {
          SistemaPosDB: Server=localhost\\{Tu_Instancia};Database=SistemaPosDB;Trusted_Connection=True;TrustServerCertificate=True;}  ```
   
3. Ejecuta el siguiente script en la carpeta Scripts del proyecto esto creara la base de datos y agregara la data

## Crendenciales
La API incluye varios endpoints controlados mediante autenticación JWT. despues de cargar los datos puedes usar las credenciales siguientees para probar el api:

- Admin: user2@example.com
- User: user@example.com
- Contraseñas: 1234 (las contraseñas están cifradas en la base de datos)

Algunos endpoints solo están accesibles para usuarios con el tipo Admin.

###

## Entidades del Proyecto

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

