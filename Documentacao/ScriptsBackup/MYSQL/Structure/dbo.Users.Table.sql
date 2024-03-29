USE `SmartDigitalPsicoDB`;
 
/* SQLINES DEMO *** le [dbo].[Users]    Script Date: 25/04/2023 23:22:15 ******/
/* SET ANSI_NULLS ON */
 
/* SET QUOTED_IDENTIFIER ON */
 
-- SQLINES LICENSE FOR EVALUATION USE ONLY
CREATE TABLE `Users`(
	`Id` bigint AUTO_INCREMENT NOT NULL,
	`Enable` Tinyint NULL,
	`Name` varchar(255) NOT NULL,
	`Email` varchar(100) NOT NULL,
	`Login` varchar(25) NOT NULL,
	`MedicalId` bigint NULL,
	`PasswordHash` Longblob NOT NULL,
	`PasswordSalt` Longblob NOT NULL,
	`Role` varchar(50) NOT NULL DEFAULT 'Admin',
	`Admin` Tinyint NOT NULL,
	`Language` varchar(10) NULL,
	`TimeZone` varchar(255) NULL,
	`Refresh_token` Longtext NULL,
	`Refresh_token_expiry_time` Datetime(6) NULL,
	`CreatedDate` Datetime(6) NOT NULL,
	`ModifyDate` Datetime(6) NOT NULL,
	`LastAccessDate` Datetime(6) NOT NULL,
 CONSTRAINT `PK_Users` PRIMARY KEY 
(
	`Id` ASC
) 
);
/* Moved to CREATE TABLE
ALTER TABLE `Users` ADD  DEFAULT (CONVERT([bit] */,(1))) FOR `Enable`
GO
/* Moved to CREATE TABLE
ALTER TABLE `Users` ADD  DEFAULT ('Admin') FOR `Role`
GO */
ALTER TABLE `Users` ADD  CONSTRAINT `FK_Users_Medicals_MedicalId` FOREIGN KEY(`MedicalId`)
REFERENCES `Medicals` (`Id`)
ON DELETE CASCADE;
 
ALTER TABLE `Users` CHECK CONSTRAINT `FK_Users_Medicals_MedicalId`;
 
