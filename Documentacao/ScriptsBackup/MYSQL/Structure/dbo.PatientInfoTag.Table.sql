USE `SmartDigitalPsicoDB`;
 
/* SQLINES DEMO *** le [dbo].[PatientInfoTag]    Script Date: 25/04/2023 23:22:15 ******/
/* SET ANSI_NULLS ON */
 
/* SET QUOTED_IDENTIFIER ON */
 
-- SQLINES LICENSE FOR EVALUATION USE ONLY
CREATE TABLE `PatientInfoTag`(
	`Id` bigint AUTO_INCREMENT NOT NULL,
	`InfoTagId` bigint NOT NULL,
	`PatientId` bigint NOT NULL,
 CONSTRAINT `PK_PatientInfoTag` PRIMARY KEY 
(
	`PatientId` ASC,
	`InfoTagId` ASC
) 
);
ALTER TABLE `PatientInfoTag` ADD  CONSTRAINT `FK_PatientInfoTag_InfoTag_InfoTagId` FOREIGN KEY(`InfoTagId`)
REFERENCES `InfoTag` (`Id`);
 
ALTER TABLE `PatientInfoTag` CHECK CONSTRAINT `FK_PatientInfoTag_InfoTag_InfoTagId`;
 
ALTER TABLE `PatientInfoTag` ADD  CONSTRAINT `FK_PatientInfoTag_Patients_PatientId` FOREIGN KEY(`PatientId`)
REFERENCES `Patients` (`Id`);
 
ALTER TABLE `PatientInfoTag` CHECK CONSTRAINT `FK_PatientInfoTag_Patients_PatientId`;
 
/* REVISAR */