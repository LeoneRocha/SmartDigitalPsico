USE [SmartDigitalPsicoDB]
GO
/****** Object:  Table [dbo].[MedicalFile]    Script Date: 25/04/2023 23:22:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MedicalFile](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Enable] [bit] NULL,
	[MedicalId] [bigint] NOT NULL,
	[CreatedUserId] [bigint] NULL,
	[ModifyUserId] [bigint] NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[ModifyDate] [datetime2](7) NOT NULL,
	[LastAccessDate] [datetime2](7) NOT NULL,
	[Description] [varchar](255) NULL,
	[FilePath] [varchar](2083) NULL,
	[FileData] [varbinary](max) NULL,
	[FileExtension] [varchar](3) NULL,
	[FileContentType] [varchar](100) NULL,
	[FileSizeKB] [bigint] NOT NULL,
	[TypeLocationSaveFile] [int] NOT NULL,
 CONSTRAINT [PK_MedicalFile] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[MedicalFile]  WITH CHECK ADD  CONSTRAINT [FK_MedicalFile_Medicals_MedicalId] FOREIGN KEY([MedicalId])
REFERENCES [dbo].[Medicals] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MedicalFile] CHECK CONSTRAINT [FK_MedicalFile_Medicals_MedicalId]
GO
ALTER TABLE [dbo].[MedicalFile]  WITH CHECK ADD  CONSTRAINT [FK_MedicalFile_Users_CreatedUserId] FOREIGN KEY([CreatedUserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[MedicalFile] CHECK CONSTRAINT [FK_MedicalFile_Users_CreatedUserId]
GO
ALTER TABLE [dbo].[MedicalFile]  WITH CHECK ADD  CONSTRAINT [FK_MedicalFile_Users_ModifyUserId] FOREIGN KEY([ModifyUserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[MedicalFile] CHECK CONSTRAINT [FK_MedicalFile_Users_ModifyUserId]
GO
