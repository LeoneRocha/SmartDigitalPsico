USE `SmartDigitalPsicoDB`;
 
/* SQLINES DEMO *** le [dbo].[InfoTag]    Script Date: 25/04/2023 23:22:15 ******/
/* SET ANSI_NULLS ON */
 
/* SET QUOTED_IDENTIFIER ON */
 
-- SQLINES LICENSE FOR EVALUATION USE ONLY
CREATE TABLE `InfoTag`(
	`Id` bigint AUTO_INCREMENT NOT NULL,
	`Enable` Tinyint NULL,
	`MedicalId` bigint NOT NULL,
	`CreatedUserId` bigint NULL,
	`ModifyUserId` bigint NULL,
	`CreatedDate` Datetime(6) NOT NULL,
	`ModifyDate` Datetime(6) NOT NULL,
	`LastAccessDate` Datetime(6) NOT NULL,
 CONSTRAINT `PK_InfoTag` PRIMARY KEY 
(
	`Id` ASC
) 
);
ALTER TABLE `InfoTag` ADD  CONSTRAINT `FK_InfoTag_Medicals_MedicalId` FOREIGN KEY(`MedicalId`)
REFERENCES `Medicals` (`Id`)
ON DELETE CASCADE;
 
ALTER TABLE `InfoTag` CHECK CONSTRAINT `FK_InfoTag_Medicals_MedicalId`;
 
ALTER TABLE `InfoTag` ADD  CONSTRAINT `FK_InfoTag_Users_CreatedUserId` FOREIGN KEY(`CreatedUserId`)
REFERENCES `Users` (`Id`);
 
ALTER TABLE `InfoTag` CHECK CONSTRAINT `FK_InfoTag_Users_CreatedUserId`;
 
ALTER TABLE `InfoTag` ADD  CONSTRAINT `FK_InfoTag_Users_ModifyUserId` FOREIGN KEY(`ModifyUserId`)
REFERENCES `Users` (`Id`);
 
ALTER TABLE `InfoTag` CHECK CONSTRAINT `FK_InfoTag_Users_ModifyUserId`;
 
