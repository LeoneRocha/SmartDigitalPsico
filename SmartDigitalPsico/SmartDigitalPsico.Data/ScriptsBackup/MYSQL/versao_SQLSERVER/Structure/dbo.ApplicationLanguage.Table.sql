USE [SmartDigitalPsicoDB]
GO
/****** Object:  Table [dbo].[ApplicationLanguage]    Script Date: 25/04/2023 23:22:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApplicationLanguage](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Enable] [bit] NULL,
	[Language] [varchar](10) NOT NULL,
	[Description] [varchar](255) NOT NULL,
	[LanguageKey] [varchar](255) NOT NULL,
	[ResourceKey] [varchar](255) NOT NULL,
	[LanguageValue] [varchar](1000) NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[ModifyDate] [datetime2](7) NOT NULL,
	[LastAccessDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_ApplicationLanguage] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ApplicationLanguage] ADD  DEFAULT ('ApplicationLanguage') FOR [ResourceKey]
GO
