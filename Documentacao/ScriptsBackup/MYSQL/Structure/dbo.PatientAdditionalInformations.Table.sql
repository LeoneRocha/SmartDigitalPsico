USE `SmartDigitalPsicoDB`;
 
/* SQLINES DEMO *** le [dbo].[PatientAdditionalInformations]    Script Date: 25/04/2023 23:22:15 ******/
/* SET ANSI_NULLS ON */
 
/* SET QUOTED_IDENTIFIER ON */
 
-- SQLINES LICENSE FOR EVALUATION USE ONLY
CREATE TABLE `PatientAdditionalInformations`(
	`Id` bigint AUTO_INCREMENT NOT NULL,
	`Enable` Tinyint NULL,
	`PatientId` bigint NOT NULL,
	`CreatedUserId` bigint NULL,
	`ModifyUserId` bigint NULL,
	`FollowUp_Psychiatric` varchar(2000) NULL,
	`FollowUp_Neurological` varchar(2000) NULL,
	`CreatedDate` Datetime(6) NOT NULL,
	`ModifyDate` Datetime(6) NOT NULL,
	`LastAccessDate` Datetime(6) NOT NULL,
 CONSTRAINT `PK_PatientAdditionalInformations` PRIMARY KEY 
(
	`Id` ASC
) 
);
/* Moved to CREATE TABLE
ALTER TABLE `PatientAdditionalInformations` ADD  DEFAULT (CONVERT([bit] */,(1))) FOR `Enable`
GO
ALTER TABLE `PatientAdditionalInformations` ADD  CONSTRAINT `FK_PatientAdditionalInformations_Patients_PatientId` FOREIGN KEY(`PatientId`)
REFERENCES `Patients` (`Id`)
ON DELETE CASCADE;
 
ALTER TABLE `PatientAdditionalInformations` CHECK CONSTRAINT `FK_PatientAdditionalInformations_Patients_PatientId`;
 
ALTER TABLE `PatientAdditionalInformations` ADD  CONSTRAINT `FK_PatientAdditionalInformations_Users_CreatedUserId` FOREIGN KEY(`CreatedUserId`)
REFERENCES `Users` (`Id`);
 
ALTER TABLE `PatientAdditionalInformations` CHECK CONSTRAINT `FK_PatientAdditionalInformations_Users_CreatedUserId`;
 
ALTER TABLE `PatientAdditionalInformations` ADD  CONSTRAINT `FK_PatientAdditionalInformations_Users_ModifyUserId` FOREIGN KEY(`ModifyUserId`)
REFERENCES `Users` (`Id`);
 
ALTER TABLE `PatientAdditionalInformations` CHECK CONSTRAINT `FK_PatientAdditionalInformations_Users_ModifyUserId`;
 
