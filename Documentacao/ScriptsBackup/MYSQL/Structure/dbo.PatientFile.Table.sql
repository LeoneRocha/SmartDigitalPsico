USE `SmartDigitalPsicoDB`;
 
/* SQLINES DEMO *** le [dbo].[PatientFile]    Script Date: 25/04/2023 23:22:15 ******/
/* SET ANSI_NULLS ON */
 
/* SET QUOTED_IDENTIFIER ON */
 
-- SQLINES LICENSE FOR EVALUATION USE ONLY
CREATE TABLE `PatientFile`(
	`Id` bigint AUTO_INCREMENT NOT NULL,
	`Enable` Tinyint NULL,
	`PatientId` bigint NOT NULL,
	`CreatedUserId` bigint NULL,
	`ModifyUserId` bigint NULL,
	`CreatedDate` Datetime(6) NOT NULL,
	`ModifyDate` Datetime(6) NOT NULL,
	`LastAccessDate` Datetime(6) NOT NULL,
	`Description` varchar(255) NULL,
	`FilePath` varchar(2083) NULL,
	`FileData` Longblob NULL,
	`FileExtension` varchar(3) NULL,
	`FileContentType` varchar(100) NULL,
	`FileSizeKB` bigint NOT NULL,
	`TypeLocationSaveFile` int NOT NULL,
 CONSTRAINT `PK_PatientFile` PRIMARY KEY 
(
	`Id` ASC
) 
);
ALTER TABLE `PatientFile` ADD  CONSTRAINT `FK_PatientFile_Patients_PatientId` FOREIGN KEY(`PatientId`)
REFERENCES `Patients` (`Id`)
ON DELETE CASCADE;
 
ALTER TABLE `PatientFile` CHECK CONSTRAINT `FK_PatientFile_Patients_PatientId`;
 
ALTER TABLE `PatientFile` ADD  CONSTRAINT `FK_PatientFile_Users_CreatedUserId` FOREIGN KEY(`CreatedUserId`)
REFERENCES `Users` (`Id`);
 
ALTER TABLE `PatientFile` CHECK CONSTRAINT `FK_PatientFile_Users_CreatedUserId`;
 
ALTER TABLE `PatientFile` ADD  CONSTRAINT `FK_PatientFile_Users_ModifyUserId` FOREIGN KEY(`ModifyUserId`)
REFERENCES `Users` (`Id`);
 
ALTER TABLE `PatientFile` CHECK CONSTRAINT `FK_PatientFile_Users_ModifyUserId`;
 
