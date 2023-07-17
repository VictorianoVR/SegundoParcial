USE [Agenda]
GO
/****** Object:  Table [dbo].[Agenda]    Script Date: 16/7/2023 8:31:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Agenda](
	[Nombre] [nvarchar](50) NULL,
	[Apellido] [nvarchar](50) NULL,
	[Celular] [nvarchar](13) NOT NULL,
	[Direccion] [nvarchar](50) NULL,
	[FechaNacimiento] [datetime] NULL
) ON [PRIMARY]
GO
INSERT [dbo].[Agenda] ([Nombre], [Apellido], [Celular], [Direccion], [FechaNacimiento]) VALUES (N'vd', N'vd', N'd', N'dv', CAST(N'2023-07-16T00:00:00.000' AS DateTime))
INSERT [dbo].[Agenda] ([Nombre], [Apellido], [Celular], [Direccion], [FechaNacimiento]) VALUES (N'', N'', N'', N'', CAST(N'2023-07-16T00:00:00.000' AS DateTime))
INSERT [dbo].[Agenda] ([Nombre], [Apellido], [Celular], [Direccion], [FechaNacimiento]) VALUES (N'1', N'2', N'123', N'123465', CAST(N'2023-07-16T00:00:00.000' AS DateTime))
GO
