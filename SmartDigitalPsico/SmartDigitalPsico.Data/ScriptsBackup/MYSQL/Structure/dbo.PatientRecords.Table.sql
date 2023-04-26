USE `SmartDigitalPsicoDB`;
 
/* SQLINES DEMO *** le [dbo].[PatientRecords]    Script Date: 25/04/2023 23:22:15 ******/
/* SET ANSI_NULLS ON */
 
/* SET QUOTED_IDENTIFIER ON */
 
-- SQLINES LICENSE FOR EVALUATION USE ONLY
CREATE TABLE `PatientRecords`(
	`Id` bigint AUTO_INCREMENT NOT NULL,
	`Enable` Tinyint NULL,
	`PatientId` bigint NOT NULL,
	`CreatedUserId` bigint NULL,
	`ModifyUserId` bigint NULL,
	`Description` varchar(255) NOT NULL,
	`Annotation` Longtext NOT NULL,
	`AnnotationDate` Datetime(6) NOT NULL,
	`CreatedDate` Datetime(6) NOT NULL,
	`ModifyDate` Datetime(6) NOT NULL,
	`LastAccessDate` Datetime(6) NOT NULL,
 CONSTRAINT `PK_PatientRecords` PRIMARY KEY 
(
	`Id` ASC
) 
);
/* Moved to CREATE TABLE
ALTER TABLE `PatientRecords` ADD  DEFAULT (CONVERT([bit] */,(1))) FOR `Enable`
GO
ALTER TABLE `PatientRecords` ADD  CONSTRAINT `FK_PatientRecords_Patients_PatientId` FOREIGN KEY(`PatientId`)
REFERENCES `Patients` (`Id`)
ON DELETE CASCADE;
 
ALTER TABLE `PatientRecords` CHECK CONSTRAINT `FK_PatientRecords_Patients_PatientId`;
 
ALTER TABLE `PatientRecords` ADD  CONSTRAINT `FK_PatientRecords_Users_CreatedUserId` FOREIGN KEY(`CreatedUserId`)
REFERENCES `Users` (`Id`);
 
ALTER TABLE `PatientRecords` CHECK CONSTRAINT `FK_PatientRecords_Users_CreatedUserId`;
 
ALTER TABLE `PatientRecords` ADD  CONSTRAINT `FK_PatientRecords_Users_ModifyUserId` FOREIGN KEY(`ModifyUserId`)
REFERENCES `Users` (`Id`);
 
ALTER TABLE `PatientRecords` CHECK CONSTRAINT `FK_PatientRecords_Users_ModifyUserId`;
 
