USE [master]
GO
/****** Object:  Database [SistemaTicket]    Script Date: 02/24/2022 17:18:45 ******/
CREATE DATABASE [SistemaTicket] ON  PRIMARY 
( NAME = N'SistemaTicket', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.JULIAN\MSSQL\DATA\SistemaTicket.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'SistemaTicket_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.JULIAN\MSSQL\DATA\SistemaTicket_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [SistemaTicket] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SistemaTicket].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SistemaTicket] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [SistemaTicket] SET ANSI_NULLS OFF
GO
ALTER DATABASE [SistemaTicket] SET ANSI_PADDING OFF
GO
ALTER DATABASE [SistemaTicket] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [SistemaTicket] SET ARITHABORT OFF
GO
ALTER DATABASE [SistemaTicket] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [SistemaTicket] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [SistemaTicket] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [SistemaTicket] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [SistemaTicket] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [SistemaTicket] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [SistemaTicket] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [SistemaTicket] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [SistemaTicket] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [SistemaTicket] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [SistemaTicket] SET  DISABLE_BROKER
GO
ALTER DATABASE [SistemaTicket] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [SistemaTicket] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [SistemaTicket] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [SistemaTicket] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [SistemaTicket] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [SistemaTicket] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [SistemaTicket] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [SistemaTicket] SET  READ_WRITE
GO
ALTER DATABASE [SistemaTicket] SET RECOVERY FULL
GO
ALTER DATABASE [SistemaTicket] SET  MULTI_USER
GO
ALTER DATABASE [SistemaTicket] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [SistemaTicket] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'SistemaTicket', N'ON'
GO
USE [SistemaTicket]
GO
/****** Object:  Table [dbo].[tbPersona]    Script Date: 02/24/2022 17:18:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbPersona](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cedula] [nvarchar](50) NULL,
	[nombres] [nvarchar](50) NULL,
	[apellidos] [nvarchar](50) NULL,
	[user_ingreso] [int] NULL,
	[user_modificacion] [int] NULL,
 CONSTRAINT [PK_tbPersona] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_tbPersona] ON [dbo].[tbPersona] 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tbPersona] ON
INSERT [dbo].[tbPersona] ([id], [cedula], [nombres], [apellidos], [user_ingreso], [user_modificacion]) VALUES (1, N'0931047021', N'Carlos Enrique', N'Victor', 1, 1)
INSERT [dbo].[tbPersona] ([id], [cedula], [nombres], [apellidos], [user_ingreso], [user_modificacion]) VALUES (2, N'0930066691', N'Carlos', N'Ramirez', NULL, NULL)
SET IDENTITY_INSERT [dbo].[tbPersona] OFF
/****** Object:  Table [dbo].[tbEstadoTicket]    Script Date: 02/24/2022 17:18:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbEstadoTicket](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbEstadoTicket] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tbEstadoTicket] ON
INSERT [dbo].[tbEstadoTicket] ([id], [descripcion]) VALUES (1, N'ACTIVO')
INSERT [dbo].[tbEstadoTicket] ([id], [descripcion]) VALUES (2, N'PENDIENTE')
INSERT [dbo].[tbEstadoTicket] ([id], [descripcion]) VALUES (3, N'TERMINADO')
SET IDENTITY_INSERT [dbo].[tbEstadoTicket] OFF
/****** Object:  Table [dbo].[tbusuario]    Script Date: 02/24/2022 17:18:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbusuario](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](50) NULL,
	[apellidos] [nvarchar](50) NULL,
	[perfil] [nchar](10) NULL,
	[usuario] [nvarchar](50) NULL,
	[password] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbusuario] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tbusuario] ON
INSERT [dbo].[tbusuario] ([id], [nombre], [apellidos], [perfil], [usuario], [password]) VALUES (1, N'Carlos', N'Ramirez v', N'1         ', N'crami', N'123')
INSERT [dbo].[tbusuario] ([id], [nombre], [apellidos], [perfil], [usuario], [password]) VALUES (2, N'Carlos Enrique', N'Victor', NULL, N'cr2021', N'julian1989')
SET IDENTITY_INSERT [dbo].[tbusuario] OFF
/****** Object:  Table [dbo].[tbTicketHistorial]    Script Date: 02/24/2022 17:18:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbTicketHistorial](
	[id] [int] NOT NULL,
	[id_usuario] [int] NULL,
	[id_ticket] [int] NOT NULL,
	[comentario] [text] NULL,
 CONSTRAINT [PK_tbTicketHistorial] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbTicket]    Script Date: 02/24/2022 17:18:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbTicket](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_persona] [int] NOT NULL,
	[id_estado_ticket] [int] NOT NULL,
	[fecha] [smalldatetime] NOT NULL,
	[asunto] [text] NULL,
	[descripcion] [text] NULL,
	[user_ingreso] [int] NULL,
	[user_modificacion] [int] NULL,
 CONSTRAINT [PK_tbTicket] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_tbTicket] ON [dbo].[tbTicket] 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tbTicket] ON
INSERT [dbo].[tbTicket] ([id], [id_persona], [id_estado_ticket], [fecha], [asunto], [descripcion], [user_ingreso], [user_modificacion]) VALUES (4, 2, 1, CAST(0xAE4603A4 AS SmallDateTime), N'ewrwr', N'werwer', 1, 1)
SET IDENTITY_INSERT [dbo].[tbTicket] OFF
/****** Object:  Default [DF_tbTicket_fecha]    Script Date: 02/24/2022 17:18:46 ******/
ALTER TABLE [dbo].[tbTicket] ADD  CONSTRAINT [DF_tbTicket_fecha]  DEFAULT (getdate()) FOR [fecha]
GO
/****** Object:  ForeignKey [FK_tbTicket_tbEstadoTicket]    Script Date: 02/24/2022 17:18:46 ******/
ALTER TABLE [dbo].[tbTicket]  WITH CHECK ADD  CONSTRAINT [FK_tbTicket_tbEstadoTicket] FOREIGN KEY([id_estado_ticket])
REFERENCES [dbo].[tbEstadoTicket] ([id])
GO
ALTER TABLE [dbo].[tbTicket] CHECK CONSTRAINT [FK_tbTicket_tbEstadoTicket]
GO
/****** Object:  ForeignKey [FK_tbTicket_tbPersona]    Script Date: 02/24/2022 17:18:46 ******/
ALTER TABLE [dbo].[tbTicket]  WITH CHECK ADD  CONSTRAINT [FK_tbTicket_tbPersona] FOREIGN KEY([id_persona])
REFERENCES [dbo].[tbPersona] ([id])
GO
ALTER TABLE [dbo].[tbTicket] CHECK CONSTRAINT [FK_tbTicket_tbPersona]
GO
/****** Object:  ForeignKey [FK_tbTicket_tbusuario]    Script Date: 02/24/2022 17:18:46 ******/
ALTER TABLE [dbo].[tbTicket]  WITH CHECK ADD  CONSTRAINT [FK_tbTicket_tbusuario] FOREIGN KEY([user_ingreso])
REFERENCES [dbo].[tbusuario] ([id])
GO
ALTER TABLE [dbo].[tbTicket] CHECK CONSTRAINT [FK_tbTicket_tbusuario]
GO
