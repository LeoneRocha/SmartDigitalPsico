USE `SmartDigitalPsicoDB`;
 
/* SQLINES DEMO *** le [dbo].[Medicals]    Script Date: 25/04/2023 23:22:15 ******/
/* SET ANSI_NULLS ON */
 
/* SET QUOTED_IDENTIFIER ON */
 
-- SQLINES LICENSE FOR EVALUATION USE ONLY
CREATE TABLE `Medicals`(
	`Id` bigint AUTO_INCREMENT NOT NULL,
	`Enable` Tinyint NULL,
	`Name` varchar(255) NOT NULL,
	`Email` varchar(100) NOT NULL,
	`OfficeId` bigint NOT NULL,
	`UserId` bigint NULL,
	`CreatedUserId` bigint NULL,
	`ModifyUserId` bigint NULL,
	`Accreditation` varchar(20) NOT NULL,
	`TypeAccreditation` int NOT NULL,
	`SecurityKey` varchar(255) NULL,
	`CreatedDate` Datetime(6) NOT NULL,
	`ModifyDate` Datetime(6) NOT NULL,
	`LastAccessDate` Datetime(6) NOT NULL,
 CONSTRAINT `PK_Medicals` PRIMARY KEY 
(
	`Id` ASC
) 
);
/* Moved to CREATE TABLE
ALTER TABLE `Medicals` ADD  DEFAULT (CONVERT([bit] */,(1))) FOR `Enable`
GO
ALTER TABLE `Medicals` ADD  CONSTRAINT `FK_Medicals_Officies_OfficeId` FOREIGN KEY(`OfficeId`)
REFERENCES `Officies` (`Id`)
ON DELETE CASCADE;
 
ALTER TABLE `Medicals` CHECK CONSTRAINT `FK_Medicals_Officies_OfficeId`;
 
ALTER TABLE `Medicals` ADD  CONSTRAINT `FK_Medicals_Users_CreatedUserId` FOREIGN KEY(`CreatedUserId`)
REFERENCES `Users` (`Id`);
 
ALTER TABLE `Medicals` CHECK CONSTRAINT `FK_Medicals_Users_CreatedUserId`;
 
ALTER TABLE `Medicals` ADD  CONSTRAINT `FK_Medicals_Users_ModifyUserId` FOREIGN KEY(`ModifyUserId`)
REFERENCES `Users` (`Id`);
 
ALTER TABLE `Medicals` CHECK CONSTRAINT `FK_Medicals_Users_ModifyUserId`;
 
ALTER TABLE `Medicals` ADD  CONSTRAINT `FK_Medicals_Users_UserId` FOREIGN KEY(`UserId`)
REFERENCES `Users` (`Id`);
 
ALTER TABLE `Medicals` CHECK CONSTRAINT `FK_Medicals_Users_UserId`;
 
