
/****** Object:  StoredProcedure [dbo].[crear_ciudad]    Script Date: 20/10/2021 21:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[crear_ciudad] (@nombre varchar(70), @provincia INT) AS
BEGIN
INSERT INTO Ciudades(nombre_ciudad, id_provincia) VALUES (@nombre, @provincia)
END

GO
/****** Object:  StoredProcedure [dbo].[crear_cuenta]    Script Date: 20/10/2021 21:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[crear_cuenta] (@id_usuario INT, @cvu varchar(255)) AS
BEGIN
INSERT INTO Cuentas(id_usuario, id_tipo_cuenta, monto, id_estado, cvu)
VALUES (@id_usuario, 1, 0.00, 1, @cvu)
END


GO
/****** Object:  StoredProcedure [dbo].[crear_movimiento]    Script Date: 20/10/2021 21:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[crear_movimiento] (@monto decimal (9,2), @cvuorigen varchar(50), @cvuDestino varchar(50), @tipoMovimiento nvarchar(10)) AS
BEGIN
INSERT INTO [dbo].[Movimientos]
           ([fecha_hora]
           ,[monto]
           ,[is_ingreso]
           ,[id_estado]
           ,[cvuOrigen]
           ,[cvuDestino]
           ,[tipomovimiento])
VALUES (getutcdate(), @monto, 1, 1, @cvuorigen, @cvuDestino, @tipoMovimiento)
END


GO
/****** Object:  StoredProcedure [dbo].[crear_pais]    Script Date: 20/10/2021 21:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[crear_pais] (@nombre varchar(70)) AS
BEGIN
INSERT INTO Paises (nombre_pais) VALUES (@nombre)
END

GO
/****** Object:  StoredProcedure [dbo].[crear_provincia]    Script Date: 20/10/2021 21:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[crear_provincia] (@nombre varchar(70), @pais INT) AS
BEGIN
INSERT INTO Provincias(nombre_provincia, id_pais) VALUES (@nombre, @pais)
END
GO
/****** Object:  StoredProcedure [dbo].[crear_tipo_cuenta]    Script Date: 20/10/2021 21:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[crear_tipo_cuenta] (@tipo varchar(70)) AS
BEGIN
INSERT INTO Tipos_Cuentas(tipo) VALUES (@tipo)
END

GO
/****** Object:  StoredProcedure [dbo].[crear_usuario]    Script Date: 20/10/2021 21:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[crear_usuario] (@username varchar(255), @nombre varchar(255), @apellido varchar(255), @email varchar(255), @contraseña varchar(255), @telefono varchar(255), @fecha_nacimiento datetime) AS
BEGIN
INSERT INTO Usuarios(username, nombre, apellido, email, contraseña, telefono, id_ciudad, foto_frente_DNI, foto_dorso_DNI, id_estado, fecha_nacimiento)
VALUES (@username, @nombre, @apellido, @email, @contraseña, @telefono, 1, '2222222', '222222', 4, @fecha_nacimiento)
SELECT CAST(scope_identity() AS INT)
END

GO
/****** Object:  StoredProcedure [dbo].[eliminar_usuario]    Script Date: 20/10/2021 21:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[eliminar_usuario] (@id_usuario INT) AS
BEGIN
DELETE FROM Usuarios WHERE id_usuario = @id_usuario
END

GO
/****** Object:  StoredProcedure [dbo].[ingresar_dinero]    Script Date: 20/10/2021 21:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[ingresar_dinero] (@cvu varchar(50), @monto decimal) AS
BEGIN
INSERT INTO Movimientos(fecha_hora, monto, id_estado, cvuOrigen, cvuDestino, tipomovimiento)
					VALUES (getutcdate(), @monto, 6, @cvu, @cvu, 'INGRESO');
					SELECT CAST(scope_identity() AS INT)
UPDATE Cuentas
SET monto = monto+@monto
WHERE cvu = @cvu;
END


GO
/****** Object:  StoredProcedure [dbo].[listar_ultimos_movimientos]    Script Date: 20/10/2021 21:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




create PROCEDURE [dbo].[listar_ultimos_movimientos] (@cvu varchar(50)) AS
BEGIN
SELECT * FROM Movimientos WHERE cvuOrigen = @cvu or cvuDestino = @cvu
END




GO
/****** Object:  StoredProcedure [dbo].[LoguearUsuario]    Script Date: 20/10/2021 21:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LoguearUsuario](@email varchar(255), @password varchar(255)) AS
BEGIN
SELECT COUNT(*) FROM [PIL2021_fbravo].[dbo].[Usuarios] 
WHERE email = @email and contraseña = @password 
END

GO
/****** Object:  StoredProcedure [dbo].[obtener_cuenta]    Script Date: 20/10/2021 21:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[obtener_cuenta] (@id_user INT) AS
BEGIN
SELECT * FROM Cuentas WHERE id_usuario = @id_user
END


GO
/****** Object:  StoredProcedure [dbo].[obtener_cuenta_cvu]    Script Date: 20/10/2021 21:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[obtener_cuenta_cvu] (@id_user varchar(50)) AS
BEGIN
SELECT * FROM Cuentas WHERE cvu = @id_user
END



GO
/****** Object:  StoredProcedure [dbo].[obtener_cvu]    Script Date: 20/10/2021 21:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[obtener_cvu] (@id int) AS
BEGIN
SELECT cvu FROM Cuentas WHERE id_usuario = @id
END



GO
/****** Object:  StoredProcedure [dbo].[obtener_usuario]    Script Date: 20/10/2021 21:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[obtener_usuario] (@email VARCHAR(255)) AS
BEGIN
SELECT id_usuario FROM Usuarios WHERE email = @email
END


GO
/****** Object:  StoredProcedure [dbo].[obtenerid]    Script Date: 20/10/2021 21:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[obtenerid] (@email varchar(255), @password varchar(255))
AS   
    SET NOCOUNT ON;  
    SELECT id_usuario,[username]
      ,[nombre]
      ,[apellido]
      ,[email]
      ,[contraseña]
      ,[telefono]
      ,[fecha_nacimiento]  
    FROM Usuarios
    WHERE email = @email AND contraseña = @password;  
RETURN  

GO
/****** Object:  StoredProcedure [dbo].[obteniendo_usuarios]    Script Date: 20/10/2021 21:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[obteniendo_usuarios] AS
BEGIN
SELECT  [id_usuario]
      ,[username]
      ,[nombre]
      ,[apellido]
      ,[email]
      ,[contraseña]
      ,[telefono]
      ,[id_ciudad]
      ,[foto_frente_DNI]
      ,[foto_dorso_DNI]
      ,[id_estado]
      ,[fecha_nacimiento]
  FROM [PIL2021_fbravo].[dbo].[Usuarios] 
END

GO
/****** Object:  StoredProcedure [dbo].[paises_bib]    Script Date: 20/10/2021 21:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[paises_bib]
AS 
SELECT PAI_ID, PAI_Nombre from BIB_PAIS PAI;

GO
/****** Object:  StoredProcedure [dbo].[retirar_dinero]    Script Date: 20/10/2021 21:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[retirar_dinero] (@cvu varchar(50), @monto decimal) AS
BEGIN
IF ((SELECT monto FROM Cuentas WHERE cvu = @cvu)-@monto) >= 0 BEGIN
       INSERT INTO Movimientos(fecha_hora, monto, id_estado, cvuOrigen, cvuDestino, tipomovimiento)
					VALUES (getutcdate(), @monto, 6, @cvu, @cvu, 'RETIRO');
					SELECT CAST(scope_identity() AS INT)
					UPDATE Cuentas
					SET monto = monto-@monto
					WHERE cvu = @cvu;
			END
IF ((SELECT monto FROM Cuentas WHERE cvu = @cvu)-@monto) < 0 BEGIN
     INSERT INTO Movimientos(fecha_hora, monto, id_estado, cvuOrigen, cvuDestino, tipomovimiento)
	 VALUES (getutcdate(), @monto, 14, @cvu, @cvu, 'SALDO INSUFICIENTE');
	 SELECT 'NO TIENE SALDO SUFUCIENTE'
	 END
END




GO
/****** Object:  StoredProcedure [dbo].[transferir_dinero]    Script Date: 20/10/2021 21:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[transferir_dinero] (@cvu_origen varchar(50), @cvu_destino varchar(50), @monto decimal) AS
BEGIN
     IF ((SELECT monto FROM Cuentas WHERE cvu = @cvu_origen)-@monto) >= 0 BEGIN
        INSERT INTO Movimientos(fecha_hora, monto, id_estado, cvuOrigen, cvuDestino, tipomovimiento)
		VALUES (getutcdate(), @monto, 1, @cvu_origen, @cvu_destino, 'TRANSFERENCIA');
		UPDATE Cuentas
		SET monto = monto-@monto
		WHERE cvu = @cvu_origen;
		UPDATE Cuentas
		SET monto = monto+@monto
					WHERE cvu = @cvu_destino;
					SELECT CAST(scope_identity() AS INT)
					END
	  IF((SELECT monto FROM Cuentas WHERE cvu = @cvu_origen)-@monto) < 0 BEGIN
		INSERT INTO Movimientos(fecha_hora, monto, id_estado, cvuOrigen, cvuDestino, tipomovimiento)
	 VALUES (getutcdate(), @monto, 14, @cvu_origen, @cvu_destino, 'SALDO INSUFICIENTE');
	 SELECT 'NO TIENE SALDO SUFUCIENTE'
		END
END

GO
/****** Object:  Table [dbo].[Ciudades]    Script Date: 20/10/2021 21:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ciudades](
	[id_ciudad] [int] IDENTITY(1,1) NOT NULL,
	[nombre_ciudad] [varchar](255) NULL,
	[id_provincia] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_ciudad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Cuentas]    Script Date: 20/10/2021 21:52:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cuentas](
	[id_cuenta] [int] IDENTITY(1,1) NOT NULL,
	[id_usuario] [int] NOT NULL,
	[id_tipo_cuenta] [int] NOT NULL,
	[monto] [decimal](9, 2) NULL,
	[id_estado] [int] NOT NULL,
	[cvu] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_cuenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Estados]    Script Date: 20/10/2021 21:52:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Estados](
	[id_estado] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](255) NULL,
	[Tabla] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_estado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Movimientos]    Script Date: 20/10/2021 21:52:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Movimientos](
	[id_movimiento] [int] IDENTITY(1,1) NOT NULL,
	[fecha_hora] [datetime] NULL,
	[monto] [decimal](9, 2) NULL,
	[is_ingreso] [bit] NULL,
	[id_estado] [int] NOT NULL,
	[cvuOrigen] [varchar](50) NOT NULL,
	[cvuDestino] [varchar](50) NOT NULL,
	[tipomovimiento] [nvarchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_movimiento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Paises]    Script Date: 20/10/2021 21:52:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Paises](
	[id_pais] [int] IDENTITY(1,1) NOT NULL,
	[nombre_pais] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_pais] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Provincias]    Script Date: 20/10/2021 21:52:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Provincias](
	[id_provincia] [int] IDENTITY(1,1) NOT NULL,
	[nombre_provincia] [varchar](255) NULL,
	[id_pais] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_provincia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tipos_Cuentas]    Script Date: 20/10/2021 21:52:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tipos_Cuentas](
	[id_tipo_cuenta] [int] IDENTITY(1,1) NOT NULL,
	[tipo] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_tipo_cuenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 20/10/2021 21:52:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuarios](
	[id_usuario] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](255) NULL,
	[nombre] [varchar](255) NULL,
	[apellido] [varchar](255) NULL,
	[email] [varchar](255) NULL,
	[contraseña] [varchar](255) NULL,
	[telefono] [varchar](255) NULL,
	[id_ciudad] [int] NOT NULL,
	[foto_frente_DNI] [varchar](255) NULL,
	[foto_dorso_DNI] [varchar](255) NULL,
	[id_estado] [int] NOT NULL,
	[fecha_nacimiento] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Ciudades]  WITH CHECK ADD FOREIGN KEY([id_provincia])
REFERENCES [dbo].[Provincias] ([id_provincia])
GO
ALTER TABLE [dbo].[Cuentas]  WITH CHECK ADD FOREIGN KEY([id_estado])
REFERENCES [dbo].[Estados] ([id_estado])
GO
ALTER TABLE [dbo].[Cuentas]  WITH CHECK ADD FOREIGN KEY([id_tipo_cuenta])
REFERENCES [dbo].[Tipos_Cuentas] ([id_tipo_cuenta])
GO
ALTER TABLE [dbo].[Cuentas]  WITH CHECK ADD FOREIGN KEY([id_usuario])
REFERENCES [dbo].[Usuarios] ([id_usuario])
GO
ALTER TABLE [dbo].[Provincias]  WITH CHECK ADD FOREIGN KEY([id_pais])
REFERENCES [dbo].[Paises] ([id_pais])
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD FOREIGN KEY([id_ciudad])
REFERENCES [dbo].[Ciudades] ([id_ciudad])
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD FOREIGN KEY([id_estado])
REFERENCES [dbo].[Estados] ([id_estado])
GO
