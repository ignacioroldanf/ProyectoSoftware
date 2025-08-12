create database Diploma
use Diploma

CREATE TABLE Clientes (
    Id_Cliente INT PRIMARY KEY IDENTITY,
    DNI_Cliente INT NOT NULL,
    Nombre_Cliente VARCHAR(100),
    Apellido_Cliente VARCHAR(100),
	Mail_Cliente VARCHAR(30),
    Fecha_Alta DATE,
);

CREATE TABLE EstadoSuscripcion (
    Id_EstadoSuscripcion INT PRIMARY KEY IDENTITY,
    Descripcion VARCHAR(50)
);


CREATE TABLE Ejercicios (
    Id_Ejercicio INT PRIMARY KEY IDENTITY,
    Nombre_Ejercicio VARCHAR(100),
    Descrip_Ejercicio NVARCHAR(150)
);

CREATE TABLE Rutinas (
    Id_Rutina INT PRIMARY KEY IDENTITY,
    Fecha_Asignacion DATE,
	Cant_Dias INT,
    Id_Cliente INT,
    FOREIGN KEY (Id_Cliente) REFERENCES Clientes(Id_Cliente)
);


CREATE TABLE DiasRutina (
    Id_DiaRutina INT PRIMARY KEY IDENTITY,
    Id_Rutina INT,
	NumeroDia INT,
    FOREIGN KEY (Id_Rutina) REFERENCES Rutinas(Id_Rutina)
);

CREATE TABLE EjerciciosAsignado (
    Id_EjercicioAsignado INT PRIMARY KEY IDENTITY,
    Series INT,
    Repeticiones INT,
    Peso FLOAT,
    Orden INT,
    Id_Ejercicio INT,
    Id_DiaRutina INT,
    FOREIGN KEY (Id_Ejercicio) REFERENCES Ejercicios(Id_Ejercicio),
    FOREIGN KEY (Id_DiaRutina) REFERENCES DiasRutina(Id_DiaRutina)
);

CREATE TABLE Planes (
    Id_Plan INT PRIMARY KEY IDENTITY,
    Nombre_Plan VARCHAR(100),
    DuracionMeses INT NOT NULL,
    Soporte BIT,
    PrecioMensual DECIMAL(10,2),
    Descrip_Plan nvarchar(150)
);


CREATE TABLE Suscripciones (
    Id_Suscripcion INT PRIMARY KEY IDENTITY,
    Id_Cliente INT,
    Id_Plan INT,
	Id_EstadoSuscripcion INT,
    Inicio DATE,
    Fin DATE,
    FOREIGN KEY (Id_Cliente) REFERENCES Clientes(Id_Cliente),
    FOREIGN KEY (Id_Plan) REFERENCES Planes(Id_Plan),
	FOREIGN KEY (Id_EstadoSuscripcion) REFERENCES EstadoSuscripcion(Id_EstadoSuscripcion)
);

CREATE TABLE Progresos (
    Id_Progreso INT PRIMARY KEY IDENTITY,
    Id_Cliente INT,
	Id_EjercicioAsignado INT,
    Fecha DATE,
    Series_Hechas INT,
    Repes_Hechas INT,
    Peso_Usado DECIMAL(10,2),
    Observaciones NVARCHAR(150),
    FOREIGN KEY (Id_Cliente) REFERENCES Clientes(Id_Cliente),
	FOREIGN KEY (Id_EjercicioAsignado) REFERENCES EjerciciosAsignado(Id_EjercicioAsignado)
);
