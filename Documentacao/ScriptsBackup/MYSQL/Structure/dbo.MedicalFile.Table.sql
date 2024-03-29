USE `SmartDigitalPsicoDB`;
 
/* SQLINES DEMO *** le [dbo].[MedicalFile]    Script Date: 25/04/2023 23:22:15 ******/
/* SET ANSI_NULLS ON */
 
/* SET QUOTED_IDENTIFIER ON */
 
-- SQLINES LICENSE FOR EVALUATION USE ONLY
CREATE TABLE `MedicalFile`(
	`Id` bigint AUTO_INCREMENT NOT NULL,
	`Enable` Tinyint NULL,
	`MedicalId` bigint NOT NULL,
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
 CONSTRAINT `PK_MedicalFile` PRIMARY KEY 
(
	`Id` ASC
) 
);
ALTER TABLE `MedicalFile` ADD  CONSTRAINT `FK_MedicalFile_Medicals_MedicalId` FOREIGN KEY(`MedicalId`)
REFERENCES `Medicals` (`Id`)
ON DELETE CASCADE;
 
ALTER TABLE `MedicalFile` CHECK CONSTRAINT `FK_MedicalFile_Medicals_MedicalId`;
 
ALTER TABLE `MedicalFile` ADD  CONSTRAINT `FK_MedicalFile_Users_CreatedUserId` FOREIGN KEY(`CreatedUserId`)
REFERENCES `Users` (`Id`);
 
ALTER TABLE `MedicalFile` CHECK CONSTRAINT `FK_MedicalFile_Users_CreatedUserId`;
 
ALTER TABLE `MedicalFile` ADD  CONSTRAINT `FK_MedicalFile_Users_ModifyUserId` FOREIGN KEY(`ModifyUserId`)
REFERENCES `Users` (`Id`);
 
ALTER TABLE `MedicalFile` CHECK CONSTRAINT `FK_MedicalFile_Users_ModifyUserId`;
 
