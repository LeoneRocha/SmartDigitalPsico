USE [SmartDigitalPsicoDB]
GO
/****** Object:  Table [dbo].[Patients]    Script Date: 25/04/2023 23:22:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patients](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Enable] [bit] NULL,
	[Name] [varchar](255) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[MedicalId] [bigint] NOT NULL,
	[CreatedUserId] [bigint] NULL,
	[ModifyUserId] [bigint] NULL,
	[GenderId] [bigint] NOT NULL,
	[DateOfBirth] [datetime2](7) NOT NULL,
	[Profession] [varchar](255) NULL,
	[Cpf] [varchar](15) NULL,
	[Rg] [varchar](15) NOT NULL,
	[Education] [varchar](255) NULL,
	[MaritalStatus] [int] NOT NULL,
	[PhoneNumber] [varchar](20) NULL,
	[AddressStreet] [varchar](255) NULL,
	[AddressNeighborhood] [varchar](255) NULL,
	[AddressCity] [varchar](255) NULL,
	[AddressState] [varchar](255) NULL,
	[AddressCep] [varchar](20) NULL,
	[EmergencyContactName] [varchar](255) NULL,
	[EmergencyContactPhoneNumber] [varchar](20) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[ModifyDate] [datetime2](7) NOT NULL,
	[LastAccessDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Patients] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Patients] ADD  DEFAULT (CONVERT([bit],(1))) FOR [Enable]
GO
ALTER TABLE [dbo].[Patients]  WITH CHECK ADD  CONSTRAINT [FK_Patients_Genders_GenderId] FOREIGN KEY([GenderId])
REFERENCES [dbo].[Genders] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Patients] CHECK CONSTRAINT [FK_Patients_Genders_GenderId]
GO
ALTER TABLE [dbo].[Patients]  WITH CHECK ADD  CONSTRAINT [FK_Patients_Medicals_MedicalId] FOREIGN KEY([MedicalId])
REFERENCES [dbo].[Medicals] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Patients] CHECK CONSTRAINT [FK_Patients_Medicals_MedicalId]
GO
ALTER TABLE [dbo].[Patients]  WITH CHECK ADD  CONSTRAINT [FK_Patients_Users_CreatedUserId] FOREIGN KEY([CreatedUserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Patients] CHECK CONSTRAINT [FK_Patients_Users_CreatedUserId]
GO
ALTER TABLE [dbo].[Patients]  WITH CHECK ADD  CONSTRAINT [FK_Patients_Users_ModifyUserId] FOREIGN KEY([ModifyUserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Patients] CHECK CONSTRAINT [FK_Patients_Users_ModifyUserId]
GO
