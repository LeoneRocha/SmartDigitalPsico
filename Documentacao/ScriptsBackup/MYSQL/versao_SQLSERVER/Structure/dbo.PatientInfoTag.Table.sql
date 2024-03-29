USE [SmartDigitalPsicoDB]
GO
/****** Object:  Table [dbo].[PatientInfoTag]    Script Date: 25/04/2023 23:22:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PatientInfoTag](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[InfoTagId] [bigint] NOT NULL,
	[PatientId] [bigint] NOT NULL,
 CONSTRAINT [PK_PatientInfoTag] PRIMARY KEY CLUSTERED 
(
	[PatientId] ASC,
	[InfoTagId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[PatientInfoTag]  WITH CHECK ADD  CONSTRAINT [FK_PatientInfoTag_InfoTag_InfoTagId] FOREIGN KEY([InfoTagId])
REFERENCES [dbo].[InfoTag] ([Id])
GO
ALTER TABLE [dbo].[PatientInfoTag] CHECK CONSTRAINT [FK_PatientInfoTag_InfoTag_InfoTagId]
GO
ALTER TABLE [dbo].[PatientInfoTag]  WITH CHECK ADD  CONSTRAINT [FK_PatientInfoTag_Patients_PatientId] FOREIGN KEY([PatientId])
REFERENCES [dbo].[Patients] ([Id])
GO
ALTER TABLE [dbo].[PatientInfoTag] CHECK CONSTRAINT [FK_PatientInfoTag_Patients_PatientId]
GO
