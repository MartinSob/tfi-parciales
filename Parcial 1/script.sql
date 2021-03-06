USE [master]
GO
/****** Object:  Database [Parcial]    Script Date: 2021-09-20 21:35:08 ******/
CREATE DATABASE [Parcial]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Parcial', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Parcial.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Parcial_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Parcial_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Parcial] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Parcial].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Parcial] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Parcial] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Parcial] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Parcial] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Parcial] SET ARITHABORT OFF 
GO
ALTER DATABASE [Parcial] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Parcial] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Parcial] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Parcial] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Parcial] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Parcial] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Parcial] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Parcial] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Parcial] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Parcial] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Parcial] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Parcial] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Parcial] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Parcial] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Parcial] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Parcial] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Parcial] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Parcial] SET RECOVERY FULL 
GO
ALTER DATABASE [Parcial] SET  MULTI_USER 
GO
ALTER DATABASE [Parcial] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Parcial] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Parcial] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Parcial] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Parcial] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Parcial] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Parcial', N'ON'
GO
ALTER DATABASE [Parcial] SET QUERY_STORE = OFF
GO
USE [Parcial]
GO
/****** Object:  Table [dbo].[cliente]    Script Date: 2021-09-20 21:35:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cliente](
	[idCliente] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
	[dni] [varchar](50) NULL,
	[comunicador_id] [int] NULL,
	[borrado] [bit] NULL,
 CONSTRAINT [PK_cliente] PRIMARY KEY CLUSTERED 
(
	[idCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[comunicador]    Script Date: 2021-09-20 21:35:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[comunicador](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[numero] [varchar](50) NULL,
	[tipo] [varchar](50) NULL,
	[borrado] [bit] NULL,
 CONSTRAINT [PK_comunicador] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[llamada]    Script Date: 2021-09-20 21:35:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[llamada](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[origen_id] [int] NULL,
	[destino_id] [int] NULL,
	[duracion] [int] NULL,
	[fecha] [datetime] NULL,
	[nacional] [bit] NULL,
	[costo] [decimal](18, 2) NULL,
 CONSTRAINT [PK_llamada] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[cliente] ADD  CONSTRAINT [DF_cliente_borrado]  DEFAULT ((0)) FOR [borrado]
GO
ALTER TABLE [dbo].[comunicador] ADD  CONSTRAINT [DF_comunicador_borrado]  DEFAULT ((0)) FOR [borrado]
GO
/****** Object:  StoredProcedure [dbo].[ActualizarCliente]    Script Date: 2021-09-20 21:35:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ActualizarCliente] @id int, @nombre varchar(50), @dni varchar(50)
AS
UPDATE cliente SET nombre = @nombre, dni = @dni WHERE idCliente = @id
GO
/****** Object:  StoredProcedure [dbo].[ActualizarComunicador]    Script Date: 2021-09-20 21:35:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ActualizarComunicador] @id int, @numero varchar(50), @tipo  varchar(50)
AS
UPDATE comunicador SET numero = @numero, tipo = @tipo WHERE id = @id
GO
/****** Object:  StoredProcedure [dbo].[BorrarCliente]    Script Date: 2021-09-20 21:35:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BorrarCliente] @id int
AS
UPDATE cliente SET borrado = 1 WHERE idCliente = @id
GO
/****** Object:  StoredProcedure [dbo].[BorrarComunicador]    Script Date: 2021-09-20 21:35:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BorrarComunicador] @id int
AS
UPDATE comunicador SET borrado = 1 WHERE id = @id
GO
/****** Object:  StoredProcedure [dbo].[CrearCliente]    Script Date: 2021-09-20 21:35:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CrearCliente] @nombre varchar(50), @dni varchar(50), @comunicador int
AS
INSERT INTO cliente (nombre, dni, comunicador_id) VALUES (@nombre, @dni, @comunicador)
GO
/****** Object:  StoredProcedure [dbo].[CrearComunicador]    Script Date: 2021-09-20 21:35:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CrearComunicador] @numero varchar(50), @tipo varchar(50)
AS
INSERT INTO comunicador (numero, tipo) VALUES (@numero, @tipo)
GO
/****** Object:  StoredProcedure [dbo].[CrearLlamada]    Script Date: 2021-09-20 21:35:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CrearLlamada] @origen int, @destino int, @duracion float, @fecha datetime, @nacional bit, @costo decimal(18,2)
AS
INSERT INTO llamada (origen_id, destino_id, duracion, fecha, nacional, costo) VALUES (@origen, @destino, @duracion, @fecha, @nacional, @costo)
GO
/****** Object:  StoredProcedure [dbo].[ListarClientes]    Script Date: 2021-09-20 21:35:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ListarClientes]
AS
SELECT * FROM cliente 
JOIN comunicador ON comunicador.id = cliente.comunicador_id 
WHERE cliente.borrado = 0
GO
/****** Object:  StoredProcedure [dbo].[ListarComunicadores]    Script Date: 2021-09-20 21:35:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ListarComunicadores]
AS
SELECT * FROM comunicador WHERE borrado = 0
GO
/****** Object:  StoredProcedure [dbo].[ListarLlamadas]    Script Date: 2021-09-20 21:35:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ListarLlamadas]
AS
SELECT * FROM llamada
GO
/****** Object:  StoredProcedure [dbo].[ListarTodosClientes]    Script Date: 2021-09-20 21:35:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ListarTodosClientes]
AS
SELECT * FROM cliente 
JOIN comunicador ON comunicador.id = cliente.comunicador_id
GO
/****** Object:  StoredProcedure [dbo].[ListarTodosComunicadores]    Script Date: 2021-09-20 21:35:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ListarTodosComunicadores]
AS
SELECT * FROM comunicador
GO
/****** Object:  StoredProcedure [dbo].[ObtenerUltimoCliente]    Script Date: 2021-09-20 21:35:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ObtenerUltimoCliente]
AS
SELECT TOP 1 idCliente FROM cliente ORDER BY idCliente DESC
GO
/****** Object:  StoredProcedure [dbo].[ObtenerUltimoComunicador]    Script Date: 2021-09-20 21:35:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ObtenerUltimoComunicador]
AS
SELECT TOP 1 id FROM comunicador ORDER BY id DESC
GO
USE [master]
GO
ALTER DATABASE [Parcial] SET  READ_WRITE 
GO
