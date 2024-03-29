USE `SmartDigitalPsicoDB`;
 
/* SQLINES DEMO *** le [dbo].[PatientHospitalizationInformations]    Script Date: 25/04/2023 23:22:15 ******/
/* SET ANSI_NULLS ON */
 
/* SET QUOTED_IDENTIFIER ON */
 
-- SQLINES LICENSE FOR EVALUATION USE ONLY
CREATE TABLE `PatientHospitalizationInformations`(
	`Id` bigint AUTO_INCREMENT NOT NULL,
	`Enable` Tinyint NULL,
	`PatientId` bigint NOT NULL,
	`CreatedUserId` bigint NULL,
	`ModifyUserId` bigint NULL,
	`Description` varchar(255) NOT NULL,
	`StartDate` Datetime(6) NOT NULL,
	`EndDate` Datetime(6) NULL,
	`CID` varchar(20) NOT NULL,
	`Observation` varchar(2000) NOT NULL,
	`CreatedDate` Datetime(6) NOT NULL,
	`ModifyDate` Datetime(6) NOT NULL,
	`LastAccessDate` Datetime(6) NOT NULL,
 CONSTRAINT `PK_PatientHospitalizationInformations` PRIMARY KEY 
(
	`Id` ASC
) 
);
/* Moved to CREATE TABLE
ALTER TABLE `PatientHospitalizationInformations` ADD  DEFAULT (CONVERT([bit] */,(1))) FOR `Enable`
GO
ALTER TABLE `PatientHospitalizationInformations` ADD  CONSTRAINT `FK_PatientHospitalizationInformations_Patients_PatientId` FOREIGN KEY(`PatientId`)
REFERENCES `Patients` (`Id`)
ON DELETE CASCADE;
 
ALTER TABLE `PatientHospitalizationInformations` CHECK CONSTRAINT `FK_PatientHospitalizationInformations_Patients_PatientId`;
 
ALTER TABLE `PatientHospitalizationInformations` ADD  CONSTRAINT `FK_PatientHospitalizationInformations_Users_CreatedUserId` FOREIGN KEY(`CreatedUserId`)
REFERENCES `Users` (`Id`);
 
ALTER TABLE `PatientHospitalizationInformations` CHECK CONSTRAINT `FK_PatientHospitalizationInformations_Users_CreatedUserId`;
 
ALTER TABLE `PatientHospitalizationInformations` ADD  CONSTRAINT `FK_PatientHospitalizationInformations_Users_ModifyUserId` FOREIGN KEY(`ModifyUserId`)
REFERENCES `Users` (`Id`);
 
ALTER TABLE `PatientHospitalizationInformations` CHECK CONSTRAINT `FK_PatientHospitalizationInformations_Users_ModifyUserId`;
 
