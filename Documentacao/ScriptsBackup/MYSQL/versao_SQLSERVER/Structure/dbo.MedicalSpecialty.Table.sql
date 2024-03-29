USE [SmartDigitalPsicoDB]
GO
/****** Object:  Table [dbo].[MedicalSpecialty]    Script Date: 25/04/2023 23:22:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MedicalSpecialty](
	[MedicalsId] [bigint] NOT NULL,
	[SpecialtiesId] [bigint] NOT NULL,
 CONSTRAINT [PK_MedicalSpecialty] PRIMARY KEY CLUSTERED 
(
	[MedicalsId] ASC,
	[SpecialtiesId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[MedicalSpecialty]  WITH CHECK ADD  CONSTRAINT [FK_MedicalSpecialty_Medicals_MedicalsId] FOREIGN KEY([MedicalsId])
REFERENCES [dbo].[Medicals] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MedicalSpecialty] CHECK CONSTRAINT [FK_MedicalSpecialty_Medicals_MedicalsId]
GO
ALTER TABLE [dbo].[MedicalSpecialty]  WITH CHECK ADD  CONSTRAINT [FK_MedicalSpecialty_Specialties_SpecialtiesId] FOREIGN KEY([SpecialtiesId])
REFERENCES [dbo].[Specialties] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MedicalSpecialty] CHECK CONSTRAINT [FK_MedicalSpecialty_Specialties_SpecialtiesId]
GO
