USE [SmartDigitalPsicoDB]
GO
/****** Object:  Table [dbo].[ApplicationConfigSetting]    Script Date: 25/04/2023 23:22:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApplicationConfigSetting](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Enable] [bit] NULL,
	[Description] [varchar](255) NOT NULL,
	[Language] [varchar](10) NOT NULL,
	[EndPointUrl_StorageFiles] [varchar](255) NOT NULL,
	[EndPointUrl_Cache] [varchar](255) NOT NULL,
	[TypeLocationSaveFiles] [int] NOT NULL,
	[TypeLocationCache] [int] NOT NULL,
	[TypeLocationQueeMessaging] [int] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[ModifyDate] [datetime2](7) NOT NULL,
	[LastAccessDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_ApplicationConfigSetting] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
