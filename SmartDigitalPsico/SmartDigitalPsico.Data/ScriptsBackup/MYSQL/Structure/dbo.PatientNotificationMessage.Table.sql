USE `SmartDigitalPsicoDB`;
 
/* SQLINES DEMO *** le [dbo].[PatientNotificationMessage]    Script Date: 25/04/2023 23:22:15 ******/
/* SET ANSI_NULLS ON */
 
/* SET QUOTED_IDENTIFIER ON */
 
-- SQLINES LICENSE FOR EVALUATION USE ONLY
CREATE TABLE `PatientNotificationMessage`(
	`Id` bigint AUTO_INCREMENT NOT NULL,
	`Enable` Tinyint NULL,
	`PatientId` bigint NOT NULL,
	`CreatedUserId` bigint NULL,
	`ModifyUserId` bigint NULL,
	`MessagePatient` varchar(2000) NOT NULL,
	`IsReaded` Tinyint NOT NULL,
	`ReadingDate` Datetime(6) NULL,
	`Notified` Tinyint NOT NULL,
	`NotifiedDate` Datetime(6) NULL,
	`CreatedDate` Datetime(6) NOT NULL,
	`ModifyDate` Datetime(6) NOT NULL,
	`LastAccessDate` Datetime(6) NOT NULL,
 CONSTRAINT `PK_PatientNotificationMessage` PRIMARY KEY 
(
	`Id` ASC
) 
);
/* Moved to CREATE TABLE
ALTER TABLE `PatientNotificationMessage` ADD  DEFAULT (CONVERT([bit] */,(1))) FOR `Enable`
GO
ALTER TABLE `PatientNotificationMessage` ADD  CONSTRAINT `FK_PatientNotificationMessage_Patients_PatientId` FOREIGN KEY(`PatientId`)
REFERENCES `Patients` (`Id`)
ON DELETE CASCADE;
 
ALTER TABLE `PatientNotificationMessage` CHECK CONSTRAINT `FK_PatientNotificationMessage_Patients_PatientId`;
 
ALTER TABLE `PatientNotificationMessage` ADD  CONSTRAINT `FK_PatientNotificationMessage_Users_CreatedUserId` FOREIGN KEY(`CreatedUserId`)
REFERENCES `Users` (`Id`);
 
ALTER TABLE `PatientNotificationMessage` CHECK CONSTRAINT `FK_PatientNotificationMessage_Users_CreatedUserId`;
 
ALTER TABLE `PatientNotificationMessage` ADD  CONSTRAINT `FK_PatientNotificationMessage_Users_ModifyUserId` FOREIGN KEY(`ModifyUserId`)
REFERENCES `Users` (`Id`);
 
ALTER TABLE `PatientNotificationMessage` CHECK CONSTRAINT `FK_PatientNotificationMessage_Users_ModifyUserId`;
 
