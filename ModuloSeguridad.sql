create database ModuloSeguridad

use ModuloSeguridad

CREATE TABLE Modulos (
    Id_Modulo INT PRIMARY KEY IDENTITY(1,1),
    Nombre_Modulo VARCHAR(50) NOT NULL
);

CREATE TABLE EstadoUsuario (
    Id_EstadoUsuario INT PRIMARY KEY,
    Descripcion VARCHAR(50) NOT NULL
);

CREATE TABLE EstadoGrupo (
    Id_EstadoGrupo INT PRIMARY KEY,
    Descripcion VARCHAR(50) NOT NULL
);


CREATE TABLE Formularios (
    Id_Formulario INT PRIMARY KEY IDENTITY(1,1),
    Nombre_Formulario VARCHAR(50) NOT NULL,
    Descripcion VARCHAR(100),
    Id_Modulo INT,
    FOREIGN KEY (Id_Modulo) REFERENCES Modulos(Id_Modulo)
);

-- 2. La tabla de Acciones (Permisos específicos, ej: "Guardar Rutina")
CREATE TABLE Acciones (
    Id_Accion INT PRIMARY KEY IDENTITY(1,1),
    Nombre_Accion VARCHAR(50) NOT NULL,
    Descripcion VARCHAR(100),
    Id_Formulario INT, -- Relación con el formulario donde ocurre la acción
    FOREIGN KEY (Id_Formulario) REFERENCES Formularios(Id_Formulario)
);

CREATE TABLE Grupos (
    Id_Grupo INT PRIMARY KEY IDENTITY(1,1),
    Nombre_Grupo VARCHAR(50) NOT NULL,
    Descripcion VARCHAR(100),
    Id_EstadoGrupo INT NOT NULL, 
    FOREIGN KEY (Id_EstadoGrupo) REFERENCES EstadoGrupo(Id_EstadoGrupo)
);

CREATE TABLE Usuarios (
    Id_Usuario INT PRIMARY KEY IDENTITY(1,1),
    Nombre_Usuario VARCHAR(50) NOT NULL UNIQUE,
    Clave_Usuario VARCHAR(255) NOT NULL, 
    Nombre VARCHAR(50),
    Apellido VARCHAR(50),
    Mail VARCHAR(100),
    Id_EstadoUsuario INT NOT NULL, 
    FOREIGN KEY (Id_EstadoUsuario) REFERENCES EstadoUsuario(Id_EstadoUsuario)
);

-- =============================================
-- TABLAS INTERMEDIAS (RELACIONES MUCHOS A MUCHOS)
-- =============================================

-- A. Relación Grupos <-> Acciones (Qué permisos tiene cada Rol)
CREATE TABLE Grupos_Acciones (
    Id_Grupo INT,
    Id_Accion INT,
    PRIMARY KEY (Id_Grupo, Id_Accion),
    FOREIGN KEY (Id_Grupo) REFERENCES Grupos(Id_Grupo),
    FOREIGN KEY (Id_Accion) REFERENCES Acciones(Id_Accion)
);

-- B. Relación Usuarios <-> Grupos (Qué roles tiene el usuario)
CREATE TABLE Usuarios_Grupos (
    Id_Usuario INT,
    Id_Grupo INT,
    PRIMARY KEY (Id_Usuario, Id_Grupo),
    FOREIGN KEY (Id_Usuario) REFERENCES Usuarios(Id_Usuario),
    FOREIGN KEY (Id_Grupo) REFERENCES Grupos(Id_Grupo)
);

-- C. Relación Usuarios <-> Acciones (Permisos "extra" directos al usuario, según diagrama)
CREATE TABLE Usuarios_Acciones (
    Id_Usuario INT,
    Id_Accion INT,
    PRIMARY KEY (Id_Usuario, Id_Accion),
    FOREIGN KEY (Id_Usuario) REFERENCES Usuarios(Id_Usuario),
    FOREIGN KEY (Id_Accion) REFERENCES Acciones(Id_Accion)
);




-- =============================================
-- SCRIPT DE DATOS INICIALES (SEED DATA)
-- =============================================

-- 1. CARGAR ESTADOS (Tablas sin Identity, asignamos ID manual)
-- Estados de Usuario
INSERT INTO EstadoUsuario (Id_EstadoUsuario, Descripcion) VALUES (1, 'Activo');
INSERT INTO EstadoUsuario (Id_EstadoUsuario, Descripcion) VALUES (2, 'Suspendido'); -- Exclusivo de usuarios
INSERT INTO EstadoUsuario (Id_EstadoUsuario, Descripcion) VALUES (0, 'Baja');

-- Estados de Grupo
INSERT INTO EstadoGrupo (Id_EstadoGrupo, Descripcion) VALUES (1, 'Activo');
INSERT INTO EstadoGrupo (Id_EstadoGrupo, Descripcion) VALUES (0, 'Baja');


-- 2. CARGAR MÓDULOS (Áreas del sistema)
INSERT INTO Modulos (Nombre_Modulo) VALUES ('Administración');   -- Para Encargados
INSERT INTO Modulos (Nombre_Modulo) VALUES ('Entrenamiento');    -- Para Profesores
INSERT INTO Modulos (Nombre_Modulo) VALUES ('Seguridad');        -- Para Admin del sistema



-- 3. CARGAR FORMULARIOS (Pantallas del sistema)
-- Asumimos IDs generados: 1=Admin, 2=Entrenamiento, 3=Seguridad
-- Formularios de Administración
INSERT INTO Formularios (Nombre_Formulario, Descripcion, Id_Modulo) 
VALUES ('FormGestionarClientes', 'ABM de Clientes', 1); -- Id 1
INSERT INTO Formularios (Nombre_Formulario, Descripcion, Id_Modulo) 
VALUES ('FormGestionarPlanes', 'ABM de Planes', 1); -- Id 2

-- Formularios de Entrenamiento
INSERT INTO Formularios (Nombre_Formulario, Descripcion, Id_Modulo) 
VALUES ('FormGestionarRutinas', 'Asignación de Rutinas', 2); -- Id 3
INSERT INTO Formularios (Nombre_Formulario, Descripcion, Id_Modulo) 
VALUES ('FormRegistrarProgreso', 'Carga de métricas', 2); -- Id 4

-- Formularios para el Módulo de Seguridad (Id_Modulo = 3)
INSERT INTO Formularios (Nombre_Formulario, Descripcion, Id_Modulo) 
VALUES ('FormGestionarUsuarios', 'ABM de Usuarios', 3); -- Id 5

INSERT INTO Formularios (Nombre_Formulario, Descripcion, Id_Modulo) 
VALUES ('FormGestionarPermisos', 'Gestión de Roles y Permisos', 3); -- Id 6


-- =============================================
-- 3. CARGA DE ACCIONES (Permisos detallados por Caso de Uso)
-- =============================================

-- ---------------------------------------------
-- FORMULARIO: GESTIONAR CLIENTES (Id_Formulario = 1)
-- ---------------------------------------------
INSERT INTO Acciones (Nombre_Accion, Descripcion, Id_Formulario) 
VALUES ('ConsultarCliente', 'Buscar y ver listado de clientes', 1); 

INSERT INTO Acciones (Nombre_Accion, Descripcion, Id_Formulario) 
VALUES ('AgregarCliente', 'Dar de alta un nuevo cliente', 1);

INSERT INTO Acciones (Nombre_Accion, Descripcion, Id_Formulario) 
VALUES ('ModificarCliente', 'Editar datos personales', 1);

INSERT INTO Acciones (Nombre_Accion, Descripcion, Id_Formulario) 
VALUES ('EliminarCliente', 'Dar de baja un cliente', 1);

INSERT INTO Acciones (Nombre_Accion, Descripcion, Id_Formulario) 
VALUES ('GestionarSuscripcion', 'Gestionar suscripción de un cliente', 1); 


-- ---------------------------------------------
-- FORMULARIO: GESTIONAR PLANES (Id_Formulario = 2)
-- ---------------------------------------------
INSERT INTO Acciones (Nombre_Accion, Descripcion, Id_Formulario) 
VALUES ('ConsultarPlan', 'Ver listado de planes', 2);

INSERT INTO Acciones (Nombre_Accion, Descripcion, Id_Formulario) 
VALUES ('AgregarPlan', 'Crear un nuevo tipo de plan', 2);

INSERT INTO Acciones (Nombre_Accion, Descripcion, Id_Formulario) 
VALUES ('ModificarPrecio', 'Actualizar precio o descripción', 2);

INSERT INTO Acciones (Nombre_Accion, Descripcion, Id_Formulario) 
VALUES ('EliminarPlan', 'Borrar un plan del sistema', 2);


-- ---------------------------------------------
-- FORMULARIO: GESTIONAR RUTINAS (Id_Formulario = 3)
-- ---------------------------------------------
INSERT INTO Acciones (Nombre_Accion, Descripcion, Id_Formulario) 
VALUES ('ConsultarRutina', 'Ver rutina actual del cliente', 3);

INSERT INTO Acciones (Nombre_Accion, Descripcion, Id_Formulario) 
VALUES ('CrearRutina', 'Crear nueva rutina personalizada', 3);

INSERT INTO Acciones (Nombre_Accion, Descripcion, Id_Formulario) 
VALUES ('ModificarRutina', 'Editar ejercicios de la rutina', 3);


-- ---------------------------------------------
-- FORMULARIO: GESTIONAR PROGRESOS (Id_Formulario = 4)
-- ---------------------------------------------
INSERT INTO Acciones (Nombre_Accion, Descripcion, Id_Formulario) 
VALUES ('RegistrarProgreso', 'Cargar peso y repeticiones diarias', 4);

INSERT INTO Acciones (Nombre_Accion, Descripcion, Id_Formulario) 
VALUES ('ConsultarHistorial', 'Ver evolución del cliente', 4);

-- ---------------------------------------------
-- FORMULARIO: GESTIONAR USUARIOS (Id_Formulario = 5)
-- ---------------------------------------------
INSERT INTO Acciones (Nombre_Accion, Descripcion, Id_Formulario) 
VALUES ('ConsultarUsuario', 'Ver usuarios', 5)

INSERT INTO Acciones (Nombre_Accion, Descripcion, Id_Formulario) 
VALUES ('AgregarUsuario', 'Crear usuarios', 5);

INSERT INTO Acciones (Nombre_Accion, Descripcion, Id_Formulario) 
VALUES ('ModificarUsuario', 'Editar usuarios', 5);

INSERT INTO Acciones (Nombre_Accion, Descripcion, Id_Formulario) 
VALUES ('EliminarUsuario', 'Baja de usuarios', 5);

-- ---------------------------------------------
-- FORMULARIO: GESTIONAR PERMISOS (Id_Formulario = 6)
-- ---------------------------------------------
INSERT INTO Acciones (Nombre_Accion, Descripcion, Id_Formulario) 
VALUES ('GestionarRoles', 'Asignar acciones a grupos', 6);


-- 5. CARGAR GRUPOS (Roles del Negocio)
-- Rol Encargado (Activo)
INSERT INTO Grupos (Nombre_Grupo, Descripcion, Id_EstadoGrupo) 
VALUES ('Encargado', 'Administración de clientes y cobros', 1); -- Id 1

-- Rol Profesor (Activo)
INSERT INTO Grupos (Nombre_Grupo, Descripcion, Id_EstadoGrupo) 
VALUES ('Profesor', 'Gestión de piso y rutinas', 1); -- Id 2

-- Rol Admin (Activo)
INSERT INTO Grupos (Nombre_Grupo, Descripcion, Id_EstadoGrupo) 
VALUES ('Administrador', 'Gestión de aplicación', 1); -- Id 3


-- 6. CARGAR USUARIOS (Login)
-- Usuario Encargado
INSERT INTO Usuarios (Nombre_Usuario, Clave_Usuario, Nombre, Apellido, Mail, Id_EstadoUsuario)
VALUES ('encargado', '1234', 'Carlos', 'Gomez', 'carlos@sag.com', 1);

-- Usuario Profesor
INSERT INTO Usuarios (Nombre_Usuario, Clave_Usuario, Nombre, Apellido, Mail, Id_EstadoUsuario)
VALUES ('profe', '1234', 'Ignacio', 'Roldan', 'nacho@sag.com', 1);

INSERT INTO Usuarios (Nombre_Usuario, Clave_Usuario, Nombre, Apellido, Mail, Id_EstadoUsuario)
VALUES ('admin', 'admin', 'Cosme', 'Fulanito', 'cosme@sag.com', 1);




-- =============================================
-- 7. VINCULACIÓN FINAL (ASIGNACIONES)
-- =============================================

-- A. ASIGNAR USUARIOS A GRUPOS (Llenar Usuarios_Grupos)
-- -----------------------------------------------------

-- 1. Asignar al usuario 'encargado' el rol 'Encargado'
INSERT INTO Usuarios_Grupos (Id_Usuario, Id_Grupo)
SELECT 
    (SELECT Id_Usuario FROM Usuarios WHERE Nombre_Usuario = 'encargado'),
    (SELECT Id_Grupo FROM Grupos WHERE Nombre_Grupo = 'Encargado');

-- 2. Asignar al usuario 'profe' el rol 'Profesor'
INSERT INTO Usuarios_Grupos (Id_Usuario, Id_Grupo)
SELECT 
    (SELECT Id_Usuario FROM Usuarios WHERE Nombre_Usuario = 'profe'),
    (SELECT Id_Grupo FROM Grupos WHERE Nombre_Grupo = 'Profesor');

-- 3. Asignar al usuario 'admin' el rol 'Administrador'
INSERT INTO Usuarios_Grupos (Id_Usuario, Id_Grupo)
SELECT 
    (SELECT Id_Usuario FROM Usuarios WHERE Nombre_Usuario = 'admin'),
    (SELECT Id_Grupo FROM Grupos WHERE Nombre_Grupo = 'Administrador');


-- B. ASIGNAR PERMISOS A LOS GRUPOS (Llenar Grupos_Acciones)
-- -----------------------------------------------------

-- === GRUPO ENCARGADO ===
-- Le damos permiso a TODAS las acciones de los formularios 'FormGestionarClientes' y 'FormGestionarPlanes'
INSERT INTO Grupos_Acciones (Id_Grupo, Id_Accion)
SELECT 
    (SELECT Id_Grupo FROM Grupos WHERE Nombre_Grupo = 'Encargado'),
    A.Id_Accion
FROM Acciones A
JOIN Formularios F ON A.Id_Formulario = F.Id_Formulario
WHERE F.Nombre_Formulario IN ('FormGestionarClientes', 'FormGestionarPlanes');


-- === GRUPO PROFESOR ===
-- Le damos permiso a TODAS las acciones de 'FormGestionarRutinas' y 'FormRegistrarProgreso'
INSERT INTO Grupos_Acciones (Id_Grupo, Id_Accion)
SELECT 
    (SELECT Id_Grupo FROM Grupos WHERE Nombre_Grupo = 'Profesor'),
    A.Id_Accion
FROM Acciones A
JOIN Formularios F ON A.Id_Formulario = F.Id_Formulario
WHERE F.Nombre_Formulario IN ('FormGestionarRutinas', 'FormRegistrarProgreso');


-- === GRUPO ADMINISTRADOR ===
-- Le damos permiso a TODAS las acciones de Seguridad
INSERT INTO Grupos_Acciones (Id_Grupo, Id_Accion)
SELECT 
    (SELECT Id_Grupo FROM Grupos WHERE Nombre_Grupo = 'Administrador'),
    A.Id_Accion
FROM Acciones A
JOIN Formularios F ON A.Id_Formulario = F.Id_Formulario
WHERE F.Nombre_Formulario IN ('FormGestionarUsuarios', 'FormGestionarPermisos');



SELECT 
    U.Nombre_Usuario AS [Usuario],
    G.Nombre_Grupo AS [Rol Asignado],
    F.Nombre_Formulario AS [Pantalla],
    A.Nombre_Accion AS [Permiso / Botón],
    A.Descripcion
FROM Usuarios U
JOIN Usuarios_Grupos UG ON U.Id_Usuario = UG.Id_Usuario
JOIN Grupos G ON UG.Id_Grupo = G.Id_Grupo
JOIN Grupos_Acciones GA ON G.Id_Grupo = GA.Id_Grupo
JOIN Acciones A ON GA.Id_Accion = A.Id_Accion
JOIN Formularios F ON A.Id_Formulario = F.Id_Formulario
WHERE U.Nombre_Usuario = 'profe' -- <--- Cambia esto por 'admin' o 'encargado' para probar los otros
ORDER BY F.Nombre_Formulario;