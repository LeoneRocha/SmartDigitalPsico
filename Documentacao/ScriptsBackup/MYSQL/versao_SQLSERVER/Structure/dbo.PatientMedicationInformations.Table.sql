USE [SmartDigitalPsicoDB]
GO
/****** Object:  Table [dbo].[PatientMedicationInformations]    Script Date: 25/04/2023 23:22:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PatientMedicationInformations](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Enable] [bit] NULL,
	[PatientId] [bigint] NOT NULL,
	[CreatedUserId] [bigint] NULL,
	[ModifyUserId] [bigint] NULL,
	[Description] [varchar](255) NOT NULL,
	[StartDate] [datetime2](7) NOT NULL,
	[EndDate] [datetime2](7) NULL,
	[Dosage] [varchar](255) NULL,
	[Posology] [varchar](255) NULL,
	[MainDrug] [varchar](255) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[ModifyDate] [datetime2](7) NOT NULL,
	[LastAccessDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_PatientMedicationInformations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[PatientMedicationInformations] ADD  DEFAULT (CONVERT([bit],(1))) FOR [Enable]
GO
ALTER TABLE [dbo].[PatientMedicationInformations]  WITH CHECK ADD  CONSTRAINT [FK_PatientMedicationInformations_Patients_PatientId] FOREIGN KEY([PatientId])
REFERENCES [dbo].[Patients] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PatientMedicationInformations] CHECK CONSTRAINT [FK_PatientMedicationInformations_Patients_PatientId]
GO
ALTER TABLE [dbo].[PatientMedicationInformations]  WITH CHECK ADD  CONSTRAINT [FK_PatientMedicationInformations_Users_CreatedUserId] FOREIGN KEY([CreatedUserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[PatientMedicationInformations] CHECK CONSTRAINT [FK_PatientMedicationInformations_Users_CreatedUserId]
GO
ALTER TABLE [dbo].[PatientMedicationInformations]  WITH CHECK ADD  CONSTRAINT [FK_PatientMedicationInformations_Users_ModifyUserId] FOREIGN KEY([ModifyUserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[PatientMedicationInformations] CHECK CONSTRAINT [FK_PatientMedicationInformations_Users_ModifyUserId]
GO
