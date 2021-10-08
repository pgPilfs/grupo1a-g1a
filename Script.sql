
--CREACION TABLAS

CREATE TABLE  Tipos_Cuentas (
	id_tipo_cuenta INT PRIMARY KEY IDENTITY (1, 1),
	tipo VARCHAR (255)
);

CREATE TABLE  Estados (
	id_estado INT PRIMARY KEY IDENTITY (1, 1),
	descripcion VARCHAR (255),
	Tabla VARCHAR (255)
);

CREATE TABLE  Usuarios (
	id_usuario INT PRIMARY KEY IDENTITY (1, 1),
	username VARCHAR (255),
	nombre VARCHAR (255),
	apellido VARCHAR (255),
	email VARCHAR (255),
	contraseña VARCHAR (255),
	telefono VARCHAR (255),
	id_ciudad INT NOT NULL,
	foto_frente_DNI VARCHAR (255),
	foto_dorso_DNI VARCHAR (255),
	id_estado INT NOT NULL,
	FOREIGN KEY (id_estado) REFERENCES Estados (id_estado),
	FOREIGN KEY (id_ciudad) REFERENCES Ciudades (id_ciudad)
);

CREATE TABLE  Cuentas (
	id_cuenta INT PRIMARY KEY IDENTITY (1, 1),
	id_usuario INT NOT NULL,
	id_tipo_cuenta INT NOT NULL,
	monto MONEY,
	nro_cuenta VARCHAR (255),
	id_estado INT NOT NULL,
	FOREIGN KEY (id_usuario) REFERENCES Usuarios (id_usuario),
	FOREIGN KEY (id_tipo_cuenta) REFERENCES Tipos_Cuentas (id_tipo_cuenta),
	FOREIGN KEY (id_estado) REFERENCES Estados (id_estado)
);

CREATE TABLE  Movimientos (
	id_movimiento INT PRIMARY KEY IDENTITY (1, 1),
	id_cuenta_principal INT NOT NULL,
	id_cuenta_recibe INT NOT NULL,
	fecha_hora TIMESTAMP,
	monto MONEY,
	is_ingreso BIT,
	id_estado INT NOT NULL,
	FOREIGN KEY (id_cuenta_principal) REFERENCES Cuentas (id_cuenta),
	FOREIGN KEY (id_cuenta_recibe) REFERENCES Cuentas (id_cuenta),
	FOREIGN KEY (id_estado) REFERENCES Estados (id_estado)
);

CREATE TABLE Paises (
	id_pais INT PRIMARY KEY IDENTITY (1, 1),
	nombre_pais varchar (255)

);

CREATE TABLE Provincias (
	id_provincia INT PRIMARY KEY IDENTITY (1, 1),
	nombre_provincia varchar (255),
	id_pais INT NOT NULL,
	FOREIGN KEY (id_pais) REFERENCES Paises (id_pais)

);

CREATE TABLE Ciudades (
	id_ciudad INT PRIMARY KEY IDENTITY (1, 1),
	nombre_ciudad varchar (255),
	id_provincia INT NOT NULL,
	FOREIGN KEY (id_provincia) REFERENCES Provincias (id_provincia)

);



-- PRIMEROS INSERT

INSERT INTO Paises (nombre_pais)
VALUES ('Argentina'),
		('Brasil');

INSERT INTO Provincias
VALUES ('Córdoba', 1),
		('Buenos Aires', 1);

INSERT INTO Ciudades
VALUES ('Capital', 1),
		('Mendiolaza', 1);

INSERT INTO Tipos_Cuentas
VALUES ('Pesos Argentinos'),
		('Dolares');

INSERT INTO Estados
VALUES ('Activa', 'Cuentas'),
		('Inactiva', 'Cuentas'),
		('Congelada', 'Cuentas'),
		('Activo', 'Usuarios'),
		('Inactivo', 'Usuarios'),
		('En proceso', 'Movimientos'),
		('Completado', 'Movimientos'),
		('Cancelado', 'Movimientos'),
		('Denegado', 'Movimientos');



-- PROCEDIMIENTOS ALMACENADOS Y SUS EJECUTORES

Go
CREATE PROCEDURE crear_pais (@nombre varchar(70)) AS
BEGIN
INSERT INTO Paises (nombre_pais) VALUES (@nombre)
END
Go

EXEC crear_pais 'Uruguay';


Go
CREATE PROCEDURE crear_provincia (@nombre varchar(70), @pais INT) AS
BEGIN
INSERT INTO Provincias(nombre_provincia, id_pais) VALUES (@nombre, @pais)
END
Go

EXEC crear_provincia 'Chubut', 1;


Go
CREATE PROCEDURE crear_ciudad (@nombre varchar(70), @provincia INT) AS
BEGIN
INSERT INTO Ciudades(nombre_ciudad, id_provincia) VALUES (@nombre, @provincia)
END
Go

EXEC crear_ciudad 'Comodoro Rivadavia', 3


Go
CREATE PROCEDURE crear_tipo_cuenta (@tipo varchar(70)) AS
BEGIN
INSERT INTO Tipos_Cuentas(tipo) VALUES (@tipo)
END
Go

EXEC crear_tipo_cuenta 'Yenes';


Go
CREATE PROCEDURE crear_usuario (@username varchar(255), @nombre varchar(255), @apellido varchar(255), @email varchar(255), @contraseña varchar(255), @telefono varchar(255), @ciudad INT, @foto_f_DNI varchar(255), @foto_d_DNI varchar(255)) AS
BEGIN
INSERT INTO Usuarios(username, nombre, apellido, email, contraseña, telefono, id_ciudad, foto_frente_DNI, foto_dorso_DNI, id_estado)
VALUES (@username, @nombre, @apellido, @email, @contraseña, @telefono, @ciudad, @foto_f_DNI, @foto_d_DNI, 4)
END
Go

EXEC crear_usuario 'usuario1', 'usuario', '1', 'usuario1@qsy.com', 'contraseñau1', '99999999', 1, 'foto_f_u', 'foto_d_u';


Go
CREATE PROCEDURE crear_cuenta (@id_usuario INT, @id_tipo INT, @monto money, @nro_cuenta varchar(255)) AS
BEGIN
INSERT INTO Cuentas(id_usuario, id_tipo_cuenta, monto, nro_cuenta, id_estado)
VALUES (@id_usuario, @id_tipo, @monto, @nro_cuenta, 1)
END
Go

EXEC crear_cuenta 1, 1, 250000, '1111111111111';


Go
CREATE PROCEDURE crear_movimiento (@id_c_principal INT, @id_c_recibe INT, @monto money) AS
BEGIN
INSERT INTO Movimientos(id_cuenta_principal, id_cuenta_recibe, monto, is_ingreso, id_estado)
VALUES (@id_c_principal, @id_c_recibe, @monto, 1, 6)
END
Go

EXEC crear_movimiento 1, 1, 250000;


















--TIPOS MOVIMIENTOS
--1: Ingreso dinero
--2: Egreso dinero
--3: Transferencia


--el ingreso de dinero en la cuenta
Go
CREATE PROCEDURE ingresar_dinero (@id_c_principal INT, @monto money) AS
BEGIN
INSERT INTO Movimientos(id_cuenta_principal, id_cuenta_recibe, monto, id_estado, tipomovimiento)
VALUES (@id_c_principal, @id_c_principal, @monto, 6, 1);
UPDATE Cuentas
SET monto = monto+@monto
WHERE id_cuenta = @id_c_principal;
END
Go
EXEC ingresar_dinero 1, 250000, 1;

--retiro de dinero
Go
CREATE PROCEDURE retirar_dinero (@id_c_principal INT, @monto money) AS
BEGIN
SELECT CASE WHEN monto-@monto >= 0 THEN
					(INSERT INTO Movimientos(id_cuenta_principal, id_cuenta_recibe, monto, id_estado, tipomovimiento)
					VALUES (@id_c_principal, @id_c_principal, @monto, 6, 2);
					UPDATE Cuentas
					SET monto = monto-@monto
					WHERE id_cuenta = @id_c_principal;)
			WHEN monto-@monto < 0 THEN
					(INSERT INTO Movimientos(id_cuenta_principal, id_cuenta_recibe, monto, id_estado, tipomovimiento)
					VALUES (@id_c_principal, @id_c_principal, @monto, 9, 2);)
			END Retiro
FROM Cuentas
END
Go
EXEC retirar_dinero 1, 250000, 2;

--transferencias
Go
CREATE PROCEDURE transferir_dinero (@id_c_principal INT, @id_c_recibe INT, @monto money) AS
BEGIN
SELECT CASE WHEN monto-@monto >= 0 THEN
					(INSERT INTO Movimientos(id_cuenta_principal, id_cuenta_recibe, monto, id_estado, tipomovimiento)
					VALUES (@id_c_principal, @id_c_recibe, @monto, 6, 3);
					UPDATE Cuentas
					SET monto = monto-@monto
					WHERE id_cuenta = @id_c_principal;
					UPDATE Cuentas
					SET monto = monto+@monto
					WHERE id_cuenta = @id_c_recibe;)
			WHEN monto-@monto < 0 THEN
					(INSERT INTO Movimientos(id_cuenta_principal, id_cuenta_recibe, monto, id_estado, tipomovimiento)
					VALUES (@id_c_principal, @id_c_recibe, @monto, 9, 3);)
			END Retiro
FROM Cuentas
WHERE id_cuenta = @id_c_principal
END
Go
EXEC transferir_dinero 1, 2, 250000;


--filtrado de ciudad por provincia

SELECT * FROM Paises

SELECT * FROM Provincias WHERE id_pais = @id_pais

SELECT * FROM Ciudades WHERE id_provincia = @id_provincia


