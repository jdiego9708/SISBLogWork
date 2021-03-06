USE [master]
GO
/****** Object:  Database [SISBlogWork]    Script Date: 14/02/2019 4:34:48 p. m. ******/
CREATE DATABASE [SISBlogWork]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SISBlogWork', FILENAME = N'C:\Users\Diego\SISBlogWork.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SISBlogWork_log', FILENAME = N'C:\Users\Diego\SISBlogWork_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [SISBlogWork] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SISBlogWork].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SISBlogWork] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SISBlogWork] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SISBlogWork] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SISBlogWork] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SISBlogWork] SET ARITHABORT OFF 
GO
ALTER DATABASE [SISBlogWork] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SISBlogWork] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SISBlogWork] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SISBlogWork] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SISBlogWork] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SISBlogWork] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SISBlogWork] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SISBlogWork] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SISBlogWork] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SISBlogWork] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SISBlogWork] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SISBlogWork] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SISBlogWork] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SISBlogWork] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SISBlogWork] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SISBlogWork] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SISBlogWork] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SISBlogWork] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SISBlogWork] SET  MULTI_USER 
GO
ALTER DATABASE [SISBlogWork] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SISBlogWork] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SISBlogWork] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SISBlogWork] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SISBlogWork] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SISBlogWork] SET QUERY_STORE = OFF
GO
USE [SISBlogWork]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [SISBlogWork]
GO
/****** Object:  Table [dbo].[Detalle_entrada]    Script Date: 14/02/2019 4:34:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detalle_entrada](
	[Id_entrada] [int] NOT NULL,
	[Etiqueta] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Entradas]    Script Date: 14/02/2019 4:34:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Entradas](
	[Id_entrada] [int] IDENTITY(3030,2) NOT NULL,
	[Id_persona] [int] NOT NULL,
	[Fecha_publicacion] [date] NOT NULL,
	[Hora_publicacion] [time](2) NOT NULL,
	[Titulo_entrada] [varchar](100) NOT NULL,
	[Descripcion_entrada] [varchar](max) NULL,
 CONSTRAINT [PK_Entradas] PRIMARY KEY CLUSTERED 
(
	[Id_entrada] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Personas]    Script Date: 14/02/2019 4:34:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personas](
	[Id_persona] [int] IDENTITY(2020,2) NOT NULL,
	[Fecha_ingreso] [date] NOT NULL,
	[Nombre_persona] [varchar](500) NOT NULL,
	[Tipo_persona] [varchar](50) NOT NULL,
	[Correo_electronico] [varchar](250) NULL,
 CONSTRAINT [PK_Personas] PRIMARY KEY CLUSTERED 
(
	[Id_persona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Personas] ON 

INSERT [dbo].[Personas] ([Id_persona], [Fecha_ingreso], [Nombre_persona], [Tipo_persona], [Correo_electronico]) VALUES (2022, CAST(N'2019-02-14' AS Date), N'Pablo Andrés Erazo', N'ADMINISTRADOR', N'jdiego9708@gmail.com')
SET IDENTITY_INSERT [dbo].[Personas] OFF
/****** Object:  StoredProcedure [dbo].[sp_Buscar_entradas]    Script Date: 14/02/2019 4:34:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[sp_Buscar_entradas]
@Tipo_busqueda varchar(50),
@Texto_busqueda varchar(50)
AS
BEGIN TRY
BEGIN

IF @Tipo_busqueda = 'COMPLETO'
BEGIN
SELECT Id_entrada, Entradas.Id_persona, Personas.Nombre_persona, Personas.Correo_electronico,
Fecha_publicacion, Hora_publicacion, Titulo_entrada, Descripcion_entrada
FROM Entradas INNER JOIN Personas ON Entradas.Id_persona = Personas.Id_persona
END

END
COMMIT
RETURN 1
END TRY
BEGIN CATCH
IF @@TRANCOUNT > 0
DECLARE @Mensaje_error NVARCHAR(4000) = ERROR_MESSAGE();
DECLARE @Mensaje_severidad INT = ERROR_SEVERITY();
DECLARE @Estado_error INT = ERROR_STATE();
DECLARE @Numero_error INT = ERROR_NUMBER();
DECLARE @Error_procedure varchar(500) = ERROR_PROCEDURE();
DECLARE @Error_line INT = Error_line();
RAISERROR (@Mensaje_error,
           @Mensaje_severidad,
           @Estado_error,
		   @Numero_error,
		   @Error_procedure,
		   @Error_line
           ); 
ROLLBACK
RETURN -1
END CATCH
GO
/****** Object:  StoredProcedure [dbo].[sp_Buscar_persona]    Script Date: 14/02/2019 4:34:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[sp_Buscar_persona]
@Tipo_busqueda varchar(50),
@Texto_busqueda varchar(50)
AS
BEGIN TRY
BEGIN

IF @Tipo_busqueda = 'COMPLETO'
BEGIN
SELECT * FROM Personas
END
ELSE IF @Tipo_busqueda = 'NOMBRE'
BEGIN
SELECT * FROM Personas
WHERE Nombre_persona like '%' + @Texto_busqueda + '%'
END
ELSE IF @Tipo_busqueda = 'CORREO'
BEGIN
SELECT * FROM Personas
WHERE Correo_electronico like @Texto_busqueda + '%'
END

END
COMMIT
RETURN 1
END TRY
BEGIN CATCH
IF @@TRANCOUNT > 0
DECLARE @Mensaje_error NVARCHAR(4000) = ERROR_MESSAGE();
DECLARE @Mensaje_severidad INT = ERROR_SEVERITY();
DECLARE @Estado_error INT = ERROR_STATE();
DECLARE @Numero_error INT = ERROR_NUMBER();
DECLARE @Error_procedure varchar(500) = ERROR_PROCEDURE();
DECLARE @Error_line INT = Error_line();
RAISERROR (@Mensaje_error,
           @Mensaje_severidad,
           @Estado_error,
		   @Numero_error,
		   @Error_procedure,
		   @Error_line
           ); 
ROLLBACK
RETURN -1
END CATCH
GO
/****** Object:  StoredProcedure [dbo].[sp_Editar_entrada]    Script Date: 14/02/2019 4:34:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[sp_Editar_entrada]
@Id_entrada int,
@Id_persona int,
@Titulo_entrada varchar(100),
@Descripcion_entrada varchar(MAX)
AS
BEGIN TRY
BEGIN TRANSACTION Editar_entrada
BEGIN

UPDATE Entradas
SET
Titulo_entrada = @Titulo_entrada,
Descripcion_entrada = @Descripcion_entrada
WHERE Id_entrada = @Id_entrada

END
COMMIT
RETURN 1
END TRY
BEGIN CATCH
IF @@TRANCOUNT > 0
DECLARE @Mensaje_error NVARCHAR(4000) = ERROR_MESSAGE();
DECLARE @Mensaje_severidad INT = ERROR_SEVERITY();
DECLARE @Estado_error INT = ERROR_STATE();
DECLARE @Numero_error INT = ERROR_NUMBER();
DECLARE @Error_procedure varchar(500) = ERROR_PROCEDURE();
DECLARE @Error_line INT = Error_line();
RAISERROR (@Mensaje_error,
           @Mensaje_severidad,
           @Estado_error,
		   @Numero_error,
		   @Error_procedure,
		   @Error_line
           ); 
ROLLBACK
RETURN -1
END CATCH
GO
/****** Object:  StoredProcedure [dbo].[sp_Editar_persona]    Script Date: 14/02/2019 4:34:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[sp_Editar_persona]
@Id_persona int,
@Nombre_persona varchar(500),
@Tipo_persona varchar(50),
@Correo_electronico varchar(250)
AS
BEGIN TRY
BEGIN TRANSACTION EditarPersona
BEGIN

UPDATE Personas
SET
Nombre_persona = @Nombre_persona,
Tipo_persona = @Tipo_persona,
Correo_electronico = @Correo_electronico
WHERE Id_persona = @Id_persona

END
COMMIT
RETURN 1
END TRY
BEGIN CATCH
IF @@TRANCOUNT > 0
DECLARE @Mensaje_error NVARCHAR(4000) = ERROR_MESSAGE();
DECLARE @Mensaje_severidad INT = ERROR_SEVERITY();
DECLARE @Estado_error INT = ERROR_STATE();
DECLARE @Numero_error INT = ERROR_NUMBER();
DECLARE @Error_procedure varchar(500) = ERROR_PROCEDURE();
DECLARE @Error_line INT = Error_line();
RAISERROR (@Mensaje_error,
           @Mensaje_severidad,
           @Estado_error,
		   @Numero_error,
		   @Error_procedure,
		   @Error_line
           ); 
ROLLBACK
RETURN -1
END CATCH
GO
/****** Object:  StoredProcedure [dbo].[sp_Insertar_entrada]    Script Date: 14/02/2019 4:34:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_Insertar_entrada]
@Id_entrada int output,
@Id_persona int,
@Titulo_entrada varchar(100),
@Descripcion_entrada varchar(MAX)
AS
BEGIN TRY
BEGIN TRANSACTION Insertar_entrada
BEGIN

INSERT INTO Entradas
VALUES (@Id_persona, CONVERT(date, GETDATE()), CONVERT(time(2), GETDATE()),
@Titulo_entrada, @Descripcion_entrada)
SET @Id_entrada = SCOPE_IDENTITY()

END
COMMIT
RETURN 1
END TRY
BEGIN CATCH
IF @@TRANCOUNT > 0
DECLARE @Mensaje_error NVARCHAR(4000) = ERROR_MESSAGE();
DECLARE @Mensaje_severidad INT = ERROR_SEVERITY();
DECLARE @Estado_error INT = ERROR_STATE();
DECLARE @Numero_error INT = ERROR_NUMBER();
DECLARE @Error_procedure varchar(500) = ERROR_PROCEDURE();
DECLARE @Error_line INT = Error_line();
RAISERROR (@Mensaje_error,
           @Mensaje_severidad,
           @Estado_error,
		   @Numero_error,
		   @Error_procedure,
		   @Error_line
           ); 
ROLLBACK
RETURN -1
END CATCH
GO
/****** Object:  StoredProcedure [dbo].[sp_Insertar_persona]    Script Date: 14/02/2019 4:34:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_Insertar_persona]
@Id_persona int output,
@Nombre_persona varchar(500),
@Tipo_persona varchar(50),
@Correo_electronico varchar(250)
AS
BEGIN TRY
BEGIN TRANSACTION InsertarPersona
BEGIN

INSERT INTO Personas
VALUES (CONVERT(date, GETDATE()), @Nombre_persona, @Tipo_persona, @Correo_electronico)
SET @Id_persona = SCOPE_IDENTITY()

END
COMMIT
RETURN 1
END TRY
BEGIN CATCH
IF @@TRANCOUNT > 0
DECLARE @Mensaje_error NVARCHAR(4000) = ERROR_MESSAGE();
DECLARE @Mensaje_severidad INT = ERROR_SEVERITY();
DECLARE @Estado_error INT = ERROR_STATE();
DECLARE @Numero_error INT = ERROR_NUMBER();
DECLARE @Error_procedure varchar(500) = ERROR_PROCEDURE();
DECLARE @Error_line INT = Error_line();
RAISERROR (@Mensaje_error,
           @Mensaje_severidad,
           @Estado_error,
		   @Numero_error,
		   @Error_procedure,
		   @Error_line
           ); 
ROLLBACK
RETURN -1
END CATCH
GO
USE [master]
GO
ALTER DATABASE [SISBlogWork] SET  READ_WRITE 
GO
