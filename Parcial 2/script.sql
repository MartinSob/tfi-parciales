USE [master]
GO
/****** Object:  Database [Parcial2]    Script Date: 2021-11-15 20:23:08 ******/
CREATE DATABASE [Parcial2]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Parcial2', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Parcial2.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Parcial2_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Parcial2_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Parcial2] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Parcial2].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Parcial2] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Parcial2] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Parcial2] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Parcial2] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Parcial2] SET ARITHABORT OFF 
GO
ALTER DATABASE [Parcial2] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Parcial2] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Parcial2] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Parcial2] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Parcial2] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Parcial2] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Parcial2] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Parcial2] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Parcial2] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Parcial2] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Parcial2] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Parcial2] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Parcial2] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Parcial2] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Parcial2] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Parcial2] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Parcial2] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Parcial2] SET RECOVERY FULL 
GO
ALTER DATABASE [Parcial2] SET  MULTI_USER 
GO
ALTER DATABASE [Parcial2] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Parcial2] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Parcial2] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Parcial2] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Parcial2] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Parcial2] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Parcial2', N'ON'
GO
ALTER DATABASE [Parcial2] SET QUERY_STORE = OFF
GO
USE [Parcial2]
GO
/****** Object:  Table [dbo].[concepto]    Script Date: 2021-11-15 20:23:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[concepto](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NULL,
	[cantidad] [decimal](18, 2) NULL,
	[tipo] [varchar](50) NULL,
	[borrado] [bit] NULL,
 CONSTRAINT [PK_concepto] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[empleado]    Script Date: 2021-11-15 20:23:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[empleado](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
	[apellido] [varchar](50) NULL,
	[dni] [varchar](50) NULL,
	[legajo] [varchar](50) NULL,
	[fecNac] [date] NULL,
	[sueldo] [decimal](18, 2) NULL,
 CONSTRAINT [PK_empleado] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[recibo]    Script Date: 2021-11-15 20:23:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[recibo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[empleado_id] [int] NULL,
	[periodo] [date] NULL,
	[total] [decimal](18, 2) NULL,
 CONSTRAINT [PK_recibo] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[recibo_concepto]    Script Date: 2021-11-15 20:23:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[recibo_concepto](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[recibo_id] [int] NULL,
	[concepto_id] [int] NULL,
	[valorUnitario] [decimal](18, 2) NULL,
	[total] [decimal](18, 2) NULL,
 CONSTRAINT [PK_recibo_concepto] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[concepto] ON 

INSERT [dbo].[concepto] ([id], [descripcion], [cantidad], [tipo], [borrado]) VALUES (1, N'R - Sueldo basico', CAST(100.00 AS Decimal(18, 2)), N'Remunerativo', 0)
INSERT [dbo].[concepto] ([id], [descripcion], [cantidad], [tipo], [borrado]) VALUES (2, N'R - Puntualidad', CAST(10.00 AS Decimal(18, 2)), N'Remunerativo', 0)
INSERT [dbo].[concepto] ([id], [descripcion], [cantidad], [tipo], [borrado]) VALUES (3, N'D - Jubilacion', CAST(10.00 AS Decimal(18, 2)), N'Descuento', 0)
INSERT [dbo].[concepto] ([id], [descripcion], [cantidad], [tipo], [borrado]) VALUES (4, N'D - Ganancias', CAST(80.00 AS Decimal(18, 2)), N'Descuento', 0)
SET IDENTITY_INSERT [dbo].[concepto] OFF
GO
SET IDENTITY_INSERT [dbo].[empleado] ON 

INSERT [dbo].[empleado] ([id], [nombre], [apellido], [dni], [legajo], [fecNac], [sueldo]) VALUES (1, N'Leandro', N'Emp', N'12345678', N'112233', CAST(N'1995-01-02' AS Date), CAST(10000.00 AS Decimal(18, 2)))
INSERT [dbo].[empleado] ([id], [nombre], [apellido], [dni], [legajo], [fecNac], [sueldo]) VALUES (2, N'Lionel', N'Scaloni', N'23456789', N'223344', CAST(N'1978-05-16' AS Date), CAST(20000.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[empleado] OFF
GO
SET IDENTITY_INSERT [dbo].[recibo] ON 

INSERT [dbo].[recibo] ([id], [empleado_id], [periodo], [total]) VALUES (1, 1, CAST(N'2020-11-15' AS Date), CAST(9000.00 AS Decimal(18, 2)))
INSERT [dbo].[recibo] ([id], [empleado_id], [periodo], [total]) VALUES (2, 2, CAST(N'2021-10-15' AS Date), CAST(4400.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[recibo] OFF
GO
SET IDENTITY_INSERT [dbo].[recibo_concepto] ON 

INSERT [dbo].[recibo_concepto] ([id], [recibo_id], [concepto_id], [valorUnitario], [total]) VALUES (1, 1, 1, CAST(10000.00 AS Decimal(18, 2)), CAST(10000.00 AS Decimal(18, 2)))
INSERT [dbo].[recibo_concepto] ([id], [recibo_id], [concepto_id], [valorUnitario], [total]) VALUES (2, 1, 3, CAST(10000.00 AS Decimal(18, 2)), CAST(1000.00 AS Decimal(18, 2)))
INSERT [dbo].[recibo_concepto] ([id], [recibo_id], [concepto_id], [valorUnitario], [total]) VALUES (3, 2, 1, CAST(20000.00 AS Decimal(18, 2)), CAST(20000.00 AS Decimal(18, 2)))
INSERT [dbo].[recibo_concepto] ([id], [recibo_id], [concepto_id], [valorUnitario], [total]) VALUES (4, 2, 2, CAST(20000.00 AS Decimal(18, 2)), CAST(2000.00 AS Decimal(18, 2)))
INSERT [dbo].[recibo_concepto] ([id], [recibo_id], [concepto_id], [valorUnitario], [total]) VALUES (5, 2, 4, CAST(22000.00 AS Decimal(18, 2)), CAST(17600.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[recibo_concepto] OFF
GO
ALTER TABLE [dbo].[concepto] ADD  CONSTRAINT [DF_concepto_borrado]  DEFAULT ((0)) FOR [borrado]
GO
/****** Object:  StoredProcedure [dbo].[ActualizarConcepto]    Script Date: 2021-11-15 20:23:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ActualizarConcepto] @id int, @descripcion varchar(50), @cantidad decimal(18,2), @tipo varchar(50)
AS
UPDATE concepto SET descripcion=@descripcion, cantidad=@cantidad, tipo=@tipo WHERE id = @id
GO
/****** Object:  StoredProcedure [dbo].[BorrarConcepto]    Script Date: 2021-11-15 20:23:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BorrarConcepto] @id int
AS
UPDATE concepto SET borrado=1 WHERE id = @id
GO
/****** Object:  StoredProcedure [dbo].[CrearConcepto]    Script Date: 2021-11-15 20:23:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CrearConcepto] @descripcion varchar(50), @cantidad decimal(18,2), @tipo varchar(50)
AS
INSERT INTO concepto(descripcion, cantidad, tipo) VALUES (@descripcion, @cantidad, @tipo)
GO
/****** Object:  StoredProcedure [dbo].[CrearEmpleado]    Script Date: 2021-11-15 20:23:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CrearEmpleado] @nombre varchar(50), @apellido varchar(50), @dni varchar(50), @legajo varchar(50), @fecNac date, @sueldo decimal(18,2)
AS
INSERT INTO empleado(nombre, apellido, dni, legajo, fecNac, sueldo) VALUES (@nombre, @apellido, @dni, @legajo, @fecNac, @sueldo)
GO
/****** Object:  StoredProcedure [dbo].[CrearRecibo]    Script Date: 2021-11-15 20:23:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CrearRecibo] @empleado_id int, @periodo date, @total decimal(18,2)
AS
INSERT INTO recibo(empleado_id, periodo, total) VALUES (@empleado_id, @periodo, @total)
GO
/****** Object:  StoredProcedure [dbo].[CrearReciboConcepto]    Script Date: 2021-11-15 20:23:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CrearReciboConcepto] @recibo_id int, @concepto_id int, @valorUnitario decimal(18,2), @total decimal(18,2)
AS
INSERT INTO recibo_concepto(recibo_id, concepto_id, valorUnitario, total) VALUES (@recibo_id, @concepto_id, @valorUnitario, @total)
GO
/****** Object:  StoredProcedure [dbo].[ListarConceptos]    Script Date: 2021-11-15 20:23:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ListarConceptos]
AS
SELECT * FROM concepto WHERE borrado = 0
GO
/****** Object:  StoredProcedure [dbo].[ListarEmpleados]    Script Date: 2021-11-15 20:23:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ListarEmpleados]
AS
SELECT * FROM empleado
GO
/****** Object:  StoredProcedure [dbo].[ListarReciboConcepto]    Script Date: 2021-11-15 20:23:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ListarReciboConcepto] @recibo_id int
AS
SELECT * from recibo_concepto rc
JOIN concepto c
	ON c.id = rc.concepto_id
WHERE rc.recibo_id = @recibo_id
GO
/****** Object:  StoredProcedure [dbo].[ListarRecibos]    Script Date: 2021-11-15 20:23:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ListarRecibos]
AS
SELECT * FROM recibo
GO
/****** Object:  StoredProcedure [dbo].[ObtenerUltimoRecibo]    Script Date: 2021-11-15 20:23:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ObtenerUltimoRecibo]
AS
SELECT TOP 1 id FROM recibo ORDER BY id DESC
GO
USE [master]
GO
ALTER DATABASE [Parcial2] SET  READ_WRITE 
GO
