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
	foto_frente_DNI VARCHAR (255),
	foto_dorso_DNI VARCHAR (255),
	id_estado INT NOT NULL,
	FOREIGN KEY (id_estado) REFERENCES Estados (id_estado)
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


INSERT INTO Tipos_Cuentas
VALUES ('Pesos Argentinos'),
		('Dolares')