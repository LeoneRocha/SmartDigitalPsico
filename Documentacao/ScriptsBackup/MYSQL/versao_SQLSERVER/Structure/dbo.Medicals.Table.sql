USE [SmartDigitalPsicoDB]
GO
/****** Object:  Table [dbo].[Medicals]    Script Date: 25/04/2023 23:22:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Medicals](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Enable] [bit] NULL,
	[Name] [varchar](255) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[OfficeId] [bigint] NOT NULL,
	[UserId] [bigint] NULL,
	[CreatedUserId] [bigint] NULL,
	[ModifyUserId] [bigint] NULL,
	[Accreditation] [varchar](20) NOT NULL,
	[TypeAccreditation] [int] NOT NULL,
	[SecurityKey] [varchar](255) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[ModifyDate] [datetime2](7) NOT NULL,
	[LastAccessDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Medicals] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Medicals] ADD  DEFAULT (CONVERT([bit],(1))) FOR [Enable]
GO
ALTER TABLE [dbo].[Medicals]  WITH CHECK ADD  CONSTRAINT [FK_Medicals_Officies_OfficeId] FOREIGN KEY([OfficeId])
REFERENCES [dbo].[Officies] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Medicals] CHECK CONSTRAINT [FK_Medicals_Officies_OfficeId]
GO
ALTER TABLE [dbo].[Medicals]  WITH CHECK ADD  CONSTRAINT [FK_Medicals_Users_CreatedUserId] FOREIGN KEY([CreatedUserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Medicals] CHECK CONSTRAINT [FK_Medicals_Users_CreatedUserId]
GO
ALTER TABLE [dbo].[Medicals]  WITH CHECK ADD  CONSTRAINT [FK_Medicals_Users_ModifyUserId] FOREIGN KEY([ModifyUserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Medicals] CHECK CONSTRAINT [FK_Medicals_Users_ModifyUserId]
GO
ALTER TABLE [dbo].[Medicals]  WITH CHECK ADD  CONSTRAINT [FK_Medicals_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Medicals] CHECK CONSTRAINT [FK_Medicals_Users_UserId]
GO
