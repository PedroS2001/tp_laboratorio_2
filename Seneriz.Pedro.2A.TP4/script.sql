USE [master]
GO
/****** Object:  Database [tp4Productos]    Script Date: 22/11/2020 23:46:15 ******/
CREATE DATABASE [tp4Productos]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'pt4Productos', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\pt4Productos.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'pt4Productos_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\pt4Productos_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [tp4Productos] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [tp4Productos].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [tp4Productos] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [tp4Productos] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [tp4Productos] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [tp4Productos] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [tp4Productos] SET ARITHABORT OFF 
GO
ALTER DATABASE [tp4Productos] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [tp4Productos] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [tp4Productos] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [tp4Productos] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [tp4Productos] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [tp4Productos] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [tp4Productos] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [tp4Productos] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [tp4Productos] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [tp4Productos] SET  DISABLE_BROKER 
GO
ALTER DATABASE [tp4Productos] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [tp4Productos] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [tp4Productos] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [tp4Productos] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [tp4Productos] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [tp4Productos] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [tp4Productos] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [tp4Productos] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [tp4Productos] SET  MULTI_USER 
GO
ALTER DATABASE [tp4Productos] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [tp4Productos] SET DB_CHAINING OFF 
GO
ALTER DATABASE [tp4Productos] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [tp4Productos] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [tp4Productos] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [tp4Productos] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [tp4Productos] SET QUERY_STORE = OFF
GO
USE [tp4Productos]
GO
/****** Object:  Table [dbo].[productos]    Script Date: 22/11/2020 23:46:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[productos](
	[codigo] [int] IDENTITY(1,1) NOT NULL,
	[precio] [float] NOT NULL,
	[anio] [int] NOT NULL,
	[tipo] [varchar](50) NULL,
	[almohadones] [int] NULL,
	[cajones] [int] NULL,
	[puertas] [int] NULL,
	[patas] [int] NULL,
	[capacidad] [int] NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[productos] ON 

INSERT [dbo].[productos] ([codigo], [precio], [anio], [tipo], [almohadones], [cajones], [puertas], [patas], [capacidad]) VALUES (1022, 25000, 2004, N'Mesa', NULL, NULL, NULL, 4, 6)
INSERT [dbo].[productos] ([codigo], [precio], [anio], [tipo], [almohadones], [cajones], [puertas], [patas], [capacidad]) VALUES (1002, 20000, 1990, N'Armario', NULL, 0, 3, NULL, NULL)
INSERT [dbo].[productos] ([codigo], [precio], [anio], [tipo], [almohadones], [cajones], [puertas], [patas], [capacidad]) VALUES (1003, 17500, 2000, N'Mesa', NULL, NULL, NULL, 4, 8)
INSERT [dbo].[productos] ([codigo], [precio], [anio], [tipo], [almohadones], [cajones], [puertas], [patas], [capacidad]) VALUES (1019, 16300, 2005, N'Sillon', 3, NULL, NULL, NULL, NULL)
INSERT [dbo].[productos] ([codigo], [precio], [anio], [tipo], [almohadones], [cajones], [puertas], [patas], [capacidad]) VALUES (1020, 9500, 1950, N'Armario', NULL, 0, 2, NULL, NULL)
INSERT [dbo].[productos] ([codigo], [precio], [anio], [tipo], [almohadones], [cajones], [puertas], [patas], [capacidad]) VALUES (1014, 50000, 2000, N'Armario', NULL, 6, 6, NULL, NULL)
INSERT [dbo].[productos] ([codigo], [precio], [anio], [tipo], [almohadones], [cajones], [puertas], [patas], [capacidad]) VALUES (1017, 15000, 1980, N'Armario', NULL, 2, 4, NULL, NULL)
INSERT [dbo].[productos] ([codigo], [precio], [anio], [tipo], [almohadones], [cajones], [puertas], [patas], [capacidad]) VALUES (1018, 55000, 1850, N'Mesa', NULL, NULL, NULL, 6, 8)
INSERT [dbo].[productos] ([codigo], [precio], [anio], [tipo], [almohadones], [cajones], [puertas], [patas], [capacidad]) VALUES (1021, 9000, 1985, N'Mesa', NULL, NULL, NULL, 1, 2)
SET IDENTITY_INSERT [dbo].[productos] OFF
GO
USE [master]
GO
ALTER DATABASE [tp4Productos] SET  READ_WRITE 
GO
