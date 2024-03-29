USE `SmartDigitalPsicoDB`;
 
/* SQLINES DEMO *** le [dbo].[MedicalSpecialty]    Script Date: 25/04/2023 23:22:15 ******/
/* SET ANSI_NULLS ON */
 
/* SET QUOTED_IDENTIFIER ON */
 
-- SQLINES LICENSE FOR EVALUATION USE ONLY
CREATE TABLE `MedicalSpecialty`(
	`MedicalsId` bigint NOT NULL,
	`SpecialtiesId` bigint NOT NULL,
 CONSTRAINT `PK_MedicalSpecialty` PRIMARY KEY 
(
	`MedicalsId` ASC,
	`SpecialtiesId` ASC
) 
);
ALTER TABLE `MedicalSpecialty` ADD  CONSTRAINT `FK_MedicalSpecialty_Medicals_MedicalsId` FOREIGN KEY(`MedicalsId`)
REFERENCES `Medicals` (`Id`)
ON DELETE CASCADE;
 
ALTER TABLE `MedicalSpecialty` CHECK CONSTRAINT `FK_MedicalSpecialty_Medicals_MedicalsId`;
 
ALTER TABLE `MedicalSpecialty` ADD  CONSTRAINT `FK_MedicalSpecialty_Specialties_SpecialtiesId` FOREIGN KEY(`SpecialtiesId`)
REFERENCES `Specialties` (`Id`)
ON DELETE CASCADE;
 
ALTER TABLE `MedicalSpecialty` CHECK CONSTRAINT `FK_MedicalSpecialty_Specialties_SpecialtiesId`;
 
