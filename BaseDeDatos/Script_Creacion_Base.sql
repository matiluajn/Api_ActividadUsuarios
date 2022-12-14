CREATE DATABASE [UsuarioActividad]
PRINT 'CREATE DATABASE [UsuarioActividad]'
GO
USE UsuarioActividad
GO
/****** Object:  Table [dbo].[actividades]    Script Date: 01/12/2022 9:41:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[actividades](
	[Id_actividad] [int] IDENTITY(1,1) NOT NULL,
	[Create_date] [datetime] NOT NULL,
	[Id_usuario] [int] NOT NULL,
	[Actividad] [varchar](150) NOT NULL,
 CONSTRAINT [PK_actividades] PRIMARY KEY CLUSTERED 
(
	[Id_actividad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
PRINT 'CREATE tabla [[actividades]]'
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[usuarios]    Script Date: 01/12/2022 9:41:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[usuarios](
	[Id_usuario] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](150) NOT NULL,
	[Apellido] [varchar](150) NOT NULL,
	[Correo_Electronico] [varchar](150) NOT NULL,
	[Fecha_Nacimiento] [datetime] NOT NULL,
	[Telefono] [varchar](150) NULL,
	[Pais_Residencia] [varchar](150) NOT NULL,
	[info] [bit] NULL,
 CONSTRAINT [PK_usuarios] PRIMARY KEY CLUSTERED 
(
	[Id_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

PRINT 'CREATE tabla [[[usuarios]]]'
GO
SET ANSI_PADDING OFF
GO
