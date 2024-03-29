USE [SmartDigitalPsicoDB]
GO
/****** Object:  Table [dbo].[PatientAdditionalInformations]    Script Date: 25/04/2023 23:22:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PatientAdditionalInformations](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Enable] [bit] NULL,
	[PatientId] [bigint] NOT NULL,
	[CreatedUserId] [bigint] NULL,
	[ModifyUserId] [bigint] NULL,
	[FollowUp_Psychiatric] [varchar](2000) NULL,
	[FollowUp_Neurological] [varchar](2000) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[ModifyDate] [datetime2](7) NOT NULL,
	[LastAccessDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_PatientAdditionalInformations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[PatientAdditionalInformations] ADD  DEFAULT (CONVERT([bit],(1))) FOR [Enable]
GO
ALTER TABLE [dbo].[PatientAdditionalInformations]  WITH CHECK ADD  CONSTRAINT [FK_PatientAdditionalInformations_Patients_PatientId] FOREIGN KEY([PatientId])
REFERENCES [dbo].[Patients] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PatientAdditionalInformations] CHECK CONSTRAINT [FK_PatientAdditionalInformations_Patients_PatientId]
GO
ALTER TABLE [dbo].[PatientAdditionalInformations]  WITH CHECK ADD  CONSTRAINT [FK_PatientAdditionalInformations_Users_CreatedUserId] FOREIGN KEY([CreatedUserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[PatientAdditionalInformations] CHECK CONSTRAINT [FK_PatientAdditionalInformations_Users_CreatedUserId]
GO
ALTER TABLE [dbo].[PatientAdditionalInformations]  WITH CHECK ADD  CONSTRAINT [FK_PatientAdditionalInformations_Users_ModifyUserId] FOREIGN KEY([ModifyUserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[PatientAdditionalInformations] CHECK CONSTRAINT [FK_PatientAdditionalInformations_Users_ModifyUserId]
GO
