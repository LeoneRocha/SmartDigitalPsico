USE [SmartDigitalPsicoDB]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 25/04/2023 23:22:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Enable] [bit] NULL,
	[Name] [varchar](255) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Login] [varchar](25) NOT NULL,
	[MedicalId] [bigint] NULL,
	[PasswordHash] [varbinary](max) NOT NULL,
	[PasswordSalt] [varbinary](max) NOT NULL,
	[Role] [varchar](50) NOT NULL,
	[Admin] [bit] NOT NULL,
	[Language] [varchar](10) NULL,
	[TimeZone] [varchar](255) NULL,
	[Refresh_token] [nvarchar](max) NULL,
	[Refresh_token_expiry_time] [datetime2](7) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[ModifyDate] [datetime2](7) NOT NULL,
	[LastAccessDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (CONVERT([bit],(1))) FOR [Enable]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT ('Admin') FOR [Role]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Medicals_MedicalId] FOREIGN KEY([MedicalId])
REFERENCES [dbo].[Medicals] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Medicals_MedicalId]
GO
