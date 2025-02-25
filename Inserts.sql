-- Estados básicos
INSERT INTO EstadoGrupos (Nombre) 
VALUES ('Activo'), ('Inactivo');

INSERT INTO EstadoUsuarios (Nombre)
VALUES ('Activo'), ('Inactivo');

-- Módulos principales (solo Compras y Ventas) 
INSERT INTO Modulos (Nombre) 
VALUES ('Compras'), ('Ventas');

-- Formularios para Compras y sus dependencias
INSERT INTO Formularios (Nombre, ModuloId)
VALUES 
('formCrearCompra', (SELECT TOP 1 ModuloId FROM Modulos WHERE Nombre = 'Compras')),
('formDetalleNotaCompra', (SELECT TOP 1 ModuloId FROM Modulos WHERE Nombre = 'Compras')),
('formNotasCompra', (SELECT TOP 1 ModuloId FROM Modulos WHERE Nombre = 'Compras')),
('formProductoAM', (SELECT TOP 1 ModuloId FROM Modulos WHERE Nombre = 'Compras')),
('formProductoDGV', (SELECT TOP 1 ModuloId FROM Modulos WHERE Nombre = 'Compras')),
('formProveedoresAM', (SELECT TOP 1 ModuloId FROM Modulos WHERE Nombre = 'Compras')),
('formProveedoresDGV', (SELECT TOP 1 ModuloId FROM Modulos WHERE Nombre = 'Compras')),
('formGestionarUsuarios', (SELECT TOP 1 ModuloId FROM Modulos WHERE Nombre = 'Compras')),
('formGestionarGrupos', (SELECT TOP 1 ModuloId FROM Modulos WHERE Nombre = 'Compras')),
('formGrupo', (SELECT TOP 1 ModuloId FROM Modulos WHERE Nombre = 'Compras')),
('formUsuario', (SELECT TOP 1 ModuloId FROM Modulos WHERE Nombre = 'Compras')),
('formInicioSesion', (SELECT TOP 1 ModuloId FROM Modulos WHERE Nombre = 'Compras')),
('formCambiarClave', (SELECT TOP 1 ModuloId FROM Modulos WHERE Nombre = 'Compras')),
('formRecuperarClave', (SELECT TOP 1 ModuloId FROM Modulos WHERE Nombre = 'Compras'));

-- Formularios para Ventas
INSERT INTO Formularios (Nombre, ModuloId)
VALUES
('formCrearVenta', (SELECT TOP 1 ModuloId FROM Modulos WHERE Nombre = 'Ventas')),
('formDetalleVenta', (SELECT TOP 1 ModuloId FROM Modulos WHERE Nombre = 'Ventas')),
('formNotasVenta', (SELECT TOP 1 ModuloId FROM Modulos WHERE Nombre = 'Ventas')),
('formProductoAM', (SELECT TOP 1 ModuloId FROM Modulos WHERE Nombre = 'Ventas')),
('formProductoDGV', (SELECT TOP 1 ModuloId FROM Modulos WHERE Nombre = 'Ventas')),
('formClienteAM', (SELECT TOP 1 ModuloId FROM Modulos WHERE Nombre = 'Ventas')),
('formClienteDGV', (SELECT TOP 1 ModuloId FROM Modulos WHERE Nombre = 'Ventas'));

-- Grupo Administrador
INSERT INTO Componentes (Nombre, Discriminator, Codigo, Descripcion, EstadoGrupoId)
VALUES ('Administradores', 'Grupo', 'GROUP_ADMIN', 'Acceso total', 
(SELECT TOP 1 EstadoGrupoId FROM EstadoGrupos WHERE Nombre = 'Activo'));

-- Usuario Admin
INSERT INTO Usuarios (NombreUsuario, Clave, Email, NombreyApellido, EstadoUsuarioId, Discriminator)
VALUES ('Admin', 'Admin123', 'admin@admin.com', 'Administrador',
(SELECT TOP 1 EstadoUsuarioId FROM EstadoUsuarios WHERE Nombre = 'Activo'),
'Administrador');

-- Acciones para los formularios (permisos)
INSERT INTO Componentes (Nombre, Discriminator, FormularioId, AccionId, Asignada)
VALUES
-- Acciones del módulo Compras
('Crear Compra', 'Accion', (SELECT TOP 1 FormularioId FROM Formularios WHERE Nombre = 'formCrearCompra'), 1, 0),
('Gestionar Detalle Compra', 'Accion', (SELECT TOP 1 FormularioId FROM Formularios WHERE Nombre = 'formDetalleNotaCompra'), 2, 0),
('Ver Listado Compras', 'Accion', (SELECT TOP 1 FormularioId FROM Formularios WHERE Nombre = 'formNotasCompra'), 3, 0),

-- Acciones de Productos (Compras)
('Agregar Producto', 'Accion', (SELECT TOP 1 FormularioId FROM Formularios WHERE Nombre = 'formProductoAM'), 4, 0),
('Modificar Producto', 'Accion', (SELECT TOP 1 FormularioId FROM Formularios WHERE Nombre = 'formProductoAM'), 5, 0),
('Eliminar Producto', 'Accion', (SELECT TOP 1 FormularioId FROM Formularios WHERE Nombre = 'formProductoAM'), 6, 0),
('Ver Listado Productos', 'Accion', (SELECT TOP 1 FormularioId FROM Formularios WHERE Nombre = 'formProductoDGV'), 7, 0),
('Gestionar Productos', 'Accion', (SELECT TOP 1 FormularioId FROM Formularios WHERE Nombre = 'formProductoDGV'), 8, 0),

-- Acciones de Proveedores
('Agregar Proveedor', 'Accion', (SELECT TOP 1 FormularioId FROM Formularios WHERE Nombre = 'formProveedoresAM'), 9, 0),
('Modificar Proveedor', 'Accion', (SELECT TOP 1 FormularioId FROM Formularios WHERE Nombre = 'formProveedoresAM'), 10, 0),
('Eliminar Proveedor', 'Accion', (SELECT TOP 1 FormularioId FROM Formularios WHERE Nombre = 'formProveedoresAM'), 11, 0),
('Ver Listado Proveedores', 'Accion', (SELECT TOP 1 FormularioId FROM Formularios WHERE Nombre = 'formProveedoresDGV'), 12, 0),

-- Acciones del módulo Ventas
('Crear Venta', 'Accion', (SELECT TOP 1 FormularioId FROM Formularios WHERE Nombre = 'formCrearVenta'), 13, 0),
('Gestionar Detalle Venta', 'Accion', (SELECT TOP 1 FormularioId FROM Formularios WHERE Nombre = 'formDetalleVenta'), 14, 0),
('Ver Listado Ventas', 'Accion', (SELECT TOP 1 FormularioId FROM Formularios WHERE Nombre = 'formNotasVenta'), 15, 0),

-- Acciones de Clientes
('Agregar Cliente', 'Accion', (SELECT TOP 1 FormularioId FROM Formularios WHERE Nombre = 'formClienteAM'), 16, 0),
('Modificar Cliente', 'Accion', (SELECT TOP 1 FormularioId FROM Formularios WHERE Nombre = 'formClienteAM'), 17, 0),
('Eliminar Cliente', 'Accion', (SELECT TOP 1 FormularioId FROM Formularios WHERE Nombre = 'formClienteAM'), 18, 0),
('Ver Listado Clientes', 'Accion', (SELECT TOP 1 FormularioId FROM Formularios WHERE Nombre = 'formClienteDGV'), 19, 0),

-- Acciones de Administración
('Gestionar Grupos', 'Accion', (SELECT TOP 1 FormularioId FROM Formularios WHERE Nombre = 'formGestionarGrupos'), 20, 0),
('Agregar Grupo', 'Accion', (SELECT TOP 1 FormularioId FROM Formularios WHERE Nombre = 'formGrupo'), 21, 0),
('Modificar Grupo', 'Accion', (SELECT TOP 1 FormularioId FROM Formularios WHERE Nombre = 'formGrupo'), 22, 0),
('Eliminar Grupo', 'Accion', (SELECT TOP 1 FormularioId FROM Formularios WHERE Nombre = 'formGrupo'), 23, 0),
('Gestionar Usuarios', 'Accion', (SELECT TOP 1 FormularioId FROM Formularios WHERE Nombre = 'formGestionarUsuarios'), 24, 0),
('Agregar Usuario', 'Accion', (SELECT TOP 1 FormularioId FROM Formularios WHERE Nombre = 'formUsuario'), 25, 0),
('Modificar Usuario', 'Accion', (SELECT TOP 1 FormularioId FROM Formularios WHERE Nombre = 'formUsuario'), 26, 0),
('Eliminar Usuario', 'Accion', (SELECT TOP 1 FormularioId FROM Formularios WHERE Nombre = 'formUsuario'), 27, 0),
('Resetear Clave', 'Accion', (SELECT TOP 1 FormularioId FROM Formularios WHERE Nombre = 'formGestionarUsuarios'), 28, 0),

-- Acciones básicas de Usuario
('Iniciar Sesión', 'Accion', (SELECT TOP 1 FormularioId FROM Formularios WHERE Nombre = 'formInicioSesion'), 29, 0),
('Cambiar Clave', 'Accion', (SELECT TOP 1 FormularioId FROM Formularios WHERE Nombre = 'formCambiarClave'), 30, 0),
('Recuperar Clave', 'Accion', (SELECT TOP 1 FormularioId FROM Formularios WHERE Nombre = 'formRecuperarClave'), 31, 0);

-- Asociar todas las acciones al grupo Administrador
INSERT INTO ComponenteUsuario (PerfilComponenteId, UsuariosUsuarioId)
SELECT c.ComponenteId, u.UsuarioId
FROM Componentes c
CROSS JOIN Usuarios u
WHERE c.Discriminator = 'Accion'
AND u.NombreUsuario = 'Admin';