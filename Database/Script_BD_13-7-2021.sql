USE [master]
GO
/****** Object:  Database [INTERNET_BANKIN_ULACIT_DW]    Script Date: 13/7/2021 10:04:51 ******/
CREATE DATABASE [INTERNET_BANKIN_ULACIT_DW]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'INTERNET_BANKIN_ULACIT_DW', FILENAME = N'D:\Informatica\Bases_de_Datos\SQL Server\Instancia\MSSQL15.MSSQLSERVER\MSSQL\DATA\INTERNET_BANKIN_ULACIT_DW.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'INTERNET_BANKIN_ULACIT_DW_log', FILENAME = N'D:\Informatica\Bases_de_Datos\SQL Server\Instancia\MSSQL15.MSSQLSERVER\MSSQL\DATA\INTERNET_BANKIN_ULACIT_DW_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [INTERNET_BANKIN_ULACIT_DW] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [INTERNET_BANKIN_ULACIT_DW].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [INTERNET_BANKIN_ULACIT_DW] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [INTERNET_BANKIN_ULACIT_DW] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [INTERNET_BANKIN_ULACIT_DW] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [INTERNET_BANKIN_ULACIT_DW] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [INTERNET_BANKIN_ULACIT_DW] SET ARITHABORT OFF 
GO
ALTER DATABASE [INTERNET_BANKIN_ULACIT_DW] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [INTERNET_BANKIN_ULACIT_DW] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [INTERNET_BANKIN_ULACIT_DW] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [INTERNET_BANKIN_ULACIT_DW] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [INTERNET_BANKIN_ULACIT_DW] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [INTERNET_BANKIN_ULACIT_DW] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [INTERNET_BANKIN_ULACIT_DW] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [INTERNET_BANKIN_ULACIT_DW] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [INTERNET_BANKIN_ULACIT_DW] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [INTERNET_BANKIN_ULACIT_DW] SET  ENABLE_BROKER 
GO
ALTER DATABASE [INTERNET_BANKIN_ULACIT_DW] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [INTERNET_BANKIN_ULACIT_DW] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [INTERNET_BANKIN_ULACIT_DW] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [INTERNET_BANKIN_ULACIT_DW] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [INTERNET_BANKIN_ULACIT_DW] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [INTERNET_BANKIN_ULACIT_DW] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [INTERNET_BANKIN_ULACIT_DW] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [INTERNET_BANKIN_ULACIT_DW] SET RECOVERY FULL 
GO
ALTER DATABASE [INTERNET_BANKIN_ULACIT_DW] SET  MULTI_USER 
GO
ALTER DATABASE [INTERNET_BANKIN_ULACIT_DW] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [INTERNET_BANKIN_ULACIT_DW] SET DB_CHAINING OFF 
GO
ALTER DATABASE [INTERNET_BANKIN_ULACIT_DW] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [INTERNET_BANKIN_ULACIT_DW] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [INTERNET_BANKIN_ULACIT_DW] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [INTERNET_BANKIN_ULACIT_DW] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'INTERNET_BANKIN_ULACIT_DW', N'ON'
GO
ALTER DATABASE [INTERNET_BANKIN_ULACIT_DW] SET QUERY_STORE = OFF
GO
USE [INTERNET_BANKIN_ULACIT_DW]
GO
/****** Object:  Table [dbo].[Cuenta_Credito]    Script Date: 13/7/2021 10:04:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cuenta_Credito](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[CodigoUsuario] [int] NOT NULL,
	[CodigoMoneda] [int] NOT NULL,
	[CodigoSucursal] [int] NOT NULL,
	[CodigoTarjeta] [int] NOT NULL,
	[Descripción] [varchar](50) NOT NULL,
	[IBAN] [varchar](22) NOT NULL,
	[Saldo] [numeric](18, 2) NOT NULL,
	[FechaPago] [datetime] NOT NULL,
	[PagoMinimo] [numeric](18, 2) NOT NULL,
	[PagoContado] [numeric](18, 2) NOT NULL,
	[Estado] [char](1) NOT NULL,
 CONSTRAINT [PK_Cuenta_Credito] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cuenta_Debito]    Script Date: 13/7/2021 10:04:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cuenta_Debito](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[CodigoUsuario] [int] NOT NULL,
	[CodigoMoneda] [int] NOT NULL,
	[CodigoSucursal] [int] NOT NULL,
	[CodigoTarjeta] [int] NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
	[IBAN] [varchar](22) NOT NULL,
	[Saldo] [numeric](18, 2) NOT NULL,
	[Estado] [char](1) NULL,
 CONSTRAINT [PK_Cuenta] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Emisor]    Script Date: 13/7/2021 10:04:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Emisor](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
	[Prefijo] [varchar](10) NOT NULL,
	[NumeroDigitos] [int] NOT NULL,
 CONSTRAINT [PK_Emisor] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Error]    Script Date: 13/7/2021 10:04:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Error](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[CodigoUsuario] [int] NOT NULL,
	[FechaHora] [datetime] NOT NULL,
	[Fuente] [varchar](50) NOT NULL,
	[Numero] [varchar](50) NOT NULL,
	[Descripcion] [varchar](1000) NOT NULL,
	[Accion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Error] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estadistica]    Script Date: 13/7/2021 10:04:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estadistica](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[CodigoUsuario] [int] NOT NULL,
	[FechaHora] [datetime] NOT NULL,
	[Navegador] [varchar](50) NOT NULL,
	[PlataformaDispositivo] [varchar](50) NOT NULL,
	[FabricanteDispositivo] [varchar](50) NOT NULL,
	[Vista] [varchar](50) NOT NULL,
	[Accion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Estadistica] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fiador]    Script Date: 13/7/2021 10:04:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fiador](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[CodigoPrestamo] [int] NOT NULL,
	[Cedula] [varchar](50) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellidos] [varchar](50) NOT NULL,
	[Ocupacion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Fiador] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Inversion]    Script Date: 13/7/2021 10:04:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inversion](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[CodigoUsuario] [int] NOT NULL,
	[CodigoMoneda] [int] NOT NULL,
	[Monto] [numeric](18, 2) NOT NULL,
	[Interes] [int] NOT NULL,
	[Liquidez] [numeric](18, 2) NOT NULL,
 CONSTRAINT [PK_Inversion] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Marchamo]    Script Date: 13/7/2021 10:04:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marchamo](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[CodigoUsuario] [int] NOT NULL,
	[Placa] [varchar](10) NOT NULL,
	[Monto] [numeric](18, 2) NOT NULL,
	[FechaLimite] [datetime] NOT NULL,
	[Estado] [varchar](10) NOT NULL,
 CONSTRAINT [PK_Marchamo] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Moneda]    Script Date: 13/7/2021 10:04:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Moneda](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](20) NOT NULL,
	[Estado] [char](1) NOT NULL,
 CONSTRAINT [PK_Moneda] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pago]    Script Date: 13/7/2021 10:04:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pago](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[CodigoServicio] [int] NOT NULL,
	[CodigoTarjeta] [int] NOT NULL,
	[Fechahora] [datetime] NOT NULL,
	[Monto] [numeric](18, 2) NOT NULL,
 CONSTRAINT [PK_Pago] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Prestamo]    Script Date: 13/7/2021 10:04:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Prestamo](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[CodigoUsuario] [int] NOT NULL,
	[CodigoMoneda] [int] NOT NULL,
	[Monto] [numeric](18, 2) NOT NULL,
	[SaldoPendiente] [numeric](18, 2) NOT NULL,
	[TasaInteres] [int] NOT NULL,
	[FechaEmision] [datetime] NOT NULL,
	[FechaVencimiento] [datetime] NOT NULL,
	[Estado] [char](1) NOT NULL,
 CONSTRAINT [PK_Prestamo] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Promocion]    Script Date: 13/7/2021 10:04:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Promocion](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[CodigoEmisor] [int] NOT NULL,
	[Empresa] [varchar](50) NOT NULL,
	[FechaInicio] [datetime] NOT NULL,
	[FechaFinalizacion] [datetime] NOT NULL,
	[Descuento] [int] NOT NULL,
 CONSTRAINT [PK_Promocion] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Propiedad]    Script Date: 13/7/2021 10:04:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Propiedad](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[CodigoUsuario] [int] NOT NULL,
	[Ubicacion] [varchar](100) NOT NULL,
	[Dimension] [varchar](50) NOT NULL,
	[Descripcion] [varchar](100) NOT NULL,
	[Estado] [varchar](10) NOT NULL,
	[PrecioFiscal] [numeric](18, 2) NOT NULL,
 CONSTRAINT [PK_Propiedad] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Servicio]    Script Date: 13/7/2021 10:04:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Servicio](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](20) NOT NULL,
	[Estado] [char](1) NOT NULL,
 CONSTRAINT [PK_Servicio] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sesion]    Script Date: 13/7/2021 10:04:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sesion](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[CodigoUsuario] [int] NOT NULL,
	[FechaInicio] [datetime] NOT NULL,
	[FechaExpiracion] [datetime] NOT NULL,
	[Estado] [char](1) NOT NULL,
 CONSTRAINT [PK_Sesion] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sucursal]    Script Date: 13/7/2021 10:04:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sucursal](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Ubicacion] [varchar](100) NOT NULL,
	[Correo] [varchar](50) NOT NULL,
	[Telefono] [int] NOT NULL,
 CONSTRAINT [PK_Sucursal] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tarjeta]    Script Date: 13/7/2021 10:04:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tarjeta](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[CodigoEmisor] [int] NOT NULL,
	[Numero] [varchar](50) NOT NULL,
	[FechaEmision] [datetime] NOT NULL,
	[FechaVencimiento] [datetime] NOT NULL,
	[Estado] [char](1) NOT NULL,
 CONSTRAINT [PK_Tarjeta] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transferencia]    Script Date: 13/7/2021 10:04:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transferencia](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[CuentaOrigen] [int] NULL,
	[CuentaDestino] [int] NULL,
	[FechaHora] [datetime] NULL,
	[Descripcion] [varchar](50) NULL,
	[Monto] [numeric](18, 2) NULL,
	[Estado] [char](1) NULL,
 CONSTRAINT [PK_Transferencia] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 13/7/2021 10:04:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[Identificacion] [varchar](20) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Username] [varchar](50) NOT NULL,
	[Password] [varchar](100) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[FechaNacimiento] [datetime] NOT NULL,
	[Estado] [char](1) NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Cuenta_Credito]  WITH CHECK ADD  CONSTRAINT [FK_Cuenta_Credito_Moneda] FOREIGN KEY([CodigoMoneda])
REFERENCES [dbo].[Moneda] ([Codigo])
GO
ALTER TABLE [dbo].[Cuenta_Credito] CHECK CONSTRAINT [FK_Cuenta_Credito_Moneda]
GO
ALTER TABLE [dbo].[Cuenta_Credito]  WITH CHECK ADD  CONSTRAINT [FK_Cuenta_Credito_Sucursal] FOREIGN KEY([CodigoSucursal])
REFERENCES [dbo].[Sucursal] ([Codigo])
GO
ALTER TABLE [dbo].[Cuenta_Credito] CHECK CONSTRAINT [FK_Cuenta_Credito_Sucursal]
GO
ALTER TABLE [dbo].[Cuenta_Credito]  WITH CHECK ADD  CONSTRAINT [FK_Cuenta_Credito_Tarjeta] FOREIGN KEY([CodigoTarjeta])
REFERENCES [dbo].[Tarjeta] ([Codigo])
GO
ALTER TABLE [dbo].[Cuenta_Credito] CHECK CONSTRAINT [FK_Cuenta_Credito_Tarjeta]
GO
ALTER TABLE [dbo].[Cuenta_Credito]  WITH CHECK ADD  CONSTRAINT [FK_Cuenta_Credito_Usuario] FOREIGN KEY([CodigoUsuario])
REFERENCES [dbo].[Usuario] ([Codigo])
GO
ALTER TABLE [dbo].[Cuenta_Credito] CHECK CONSTRAINT [FK_Cuenta_Credito_Usuario]
GO
ALTER TABLE [dbo].[Cuenta_Debito]  WITH CHECK ADD  CONSTRAINT [FK_Cuenta_Debito_Moneda] FOREIGN KEY([CodigoMoneda])
REFERENCES [dbo].[Moneda] ([Codigo])
GO
ALTER TABLE [dbo].[Cuenta_Debito] CHECK CONSTRAINT [FK_Cuenta_Debito_Moneda]
GO
ALTER TABLE [dbo].[Cuenta_Debito]  WITH CHECK ADD  CONSTRAINT [FK_Cuenta_Debito_Sucursal] FOREIGN KEY([CodigoSucursal])
REFERENCES [dbo].[Sucursal] ([Codigo])
GO
ALTER TABLE [dbo].[Cuenta_Debito] CHECK CONSTRAINT [FK_Cuenta_Debito_Sucursal]
GO
ALTER TABLE [dbo].[Cuenta_Debito]  WITH CHECK ADD  CONSTRAINT [FK_Cuenta_Debito_Tarjeta] FOREIGN KEY([CodigoTarjeta])
REFERENCES [dbo].[Tarjeta] ([Codigo])
GO
ALTER TABLE [dbo].[Cuenta_Debito] CHECK CONSTRAINT [FK_Cuenta_Debito_Tarjeta]
GO
ALTER TABLE [dbo].[Cuenta_Debito]  WITH CHECK ADD  CONSTRAINT [FK_Cuenta_Debito_Usuario] FOREIGN KEY([CodigoUsuario])
REFERENCES [dbo].[Usuario] ([Codigo])
GO
ALTER TABLE [dbo].[Cuenta_Debito] CHECK CONSTRAINT [FK_Cuenta_Debito_Usuario]
GO
ALTER TABLE [dbo].[Fiador]  WITH CHECK ADD  CONSTRAINT [FK_Fiador_Prestamo] FOREIGN KEY([CodigoPrestamo])
REFERENCES [dbo].[Prestamo] ([Codigo])
GO
ALTER TABLE [dbo].[Fiador] CHECK CONSTRAINT [FK_Fiador_Prestamo]
GO
ALTER TABLE [dbo].[Inversion]  WITH CHECK ADD  CONSTRAINT [FK_Inversion_Usuario] FOREIGN KEY([CodigoUsuario])
REFERENCES [dbo].[Usuario] ([Codigo])
GO
ALTER TABLE [dbo].[Inversion] CHECK CONSTRAINT [FK_Inversion_Usuario]
GO
ALTER TABLE [dbo].[Marchamo]  WITH CHECK ADD  CONSTRAINT [FK_Marchamo_Usuario] FOREIGN KEY([CodigoUsuario])
REFERENCES [dbo].[Usuario] ([Codigo])
GO
ALTER TABLE [dbo].[Marchamo] CHECK CONSTRAINT [FK_Marchamo_Usuario]
GO
ALTER TABLE [dbo].[Pago]  WITH CHECK ADD  CONSTRAINT [FK_Pago_Servicio] FOREIGN KEY([CodigoServicio])
REFERENCES [dbo].[Servicio] ([Codigo])
GO
ALTER TABLE [dbo].[Pago] CHECK CONSTRAINT [FK_Pago_Servicio]
GO
ALTER TABLE [dbo].[Pago]  WITH CHECK ADD  CONSTRAINT [FK_Pago_Tarjeta] FOREIGN KEY([CodigoTarjeta])
REFERENCES [dbo].[Tarjeta] ([Codigo])
GO
ALTER TABLE [dbo].[Pago] CHECK CONSTRAINT [FK_Pago_Tarjeta]
GO
ALTER TABLE [dbo].[Prestamo]  WITH CHECK ADD  CONSTRAINT [FK_Prestamo_Moneda] FOREIGN KEY([CodigoMoneda])
REFERENCES [dbo].[Moneda] ([Codigo])
GO
ALTER TABLE [dbo].[Prestamo] CHECK CONSTRAINT [FK_Prestamo_Moneda]
GO
ALTER TABLE [dbo].[Prestamo]  WITH CHECK ADD  CONSTRAINT [FK_Prestamo_Usuario] FOREIGN KEY([CodigoUsuario])
REFERENCES [dbo].[Usuario] ([Codigo])
GO
ALTER TABLE [dbo].[Prestamo] CHECK CONSTRAINT [FK_Prestamo_Usuario]
GO
ALTER TABLE [dbo].[Promocion]  WITH CHECK ADD  CONSTRAINT [FK_Promocion_Emisor] FOREIGN KEY([CodigoEmisor])
REFERENCES [dbo].[Emisor] ([Codigo])
GO
ALTER TABLE [dbo].[Promocion] CHECK CONSTRAINT [FK_Promocion_Emisor]
GO
ALTER TABLE [dbo].[Propiedad]  WITH CHECK ADD  CONSTRAINT [FK_Propiedad_Usuario] FOREIGN KEY([CodigoUsuario])
REFERENCES [dbo].[Usuario] ([Codigo])
GO
ALTER TABLE [dbo].[Propiedad] CHECK CONSTRAINT [FK_Propiedad_Usuario]
GO
ALTER TABLE [dbo].[Tarjeta]  WITH CHECK ADD  CONSTRAINT [FK_Tarjeta_Emisor] FOREIGN KEY([CodigoEmisor])
REFERENCES [dbo].[Emisor] ([Codigo])
GO
ALTER TABLE [dbo].[Tarjeta] CHECK CONSTRAINT [FK_Tarjeta_Emisor]
GO
USE [master]
GO
ALTER DATABASE [INTERNET_BANKIN_ULACIT_DW] SET  READ_WRITE 
GO
