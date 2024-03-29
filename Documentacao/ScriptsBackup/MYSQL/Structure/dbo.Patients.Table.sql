USE `SmartDigitalPsicoDB`;
 
/* SQLINES DEMO *** le [dbo].[Patients]    Script Date: 25/04/2023 23:22:15 ******/
/* SET ANSI_NULLS ON */
 
/* SET QUOTED_IDENTIFIER ON */
 
-- SQLINES LICENSE FOR EVALUATION USE ONLY
CREATE TABLE `Patients`(
	`Id` bigint AUTO_INCREMENT NOT NULL,
	`Enable` Tinyint NULL,
	`Name` varchar(255) NOT NULL,
	`Email` varchar(100) NOT NULL,
	`MedicalId` bigint NOT NULL,
	`CreatedUserId` bigint NULL,
	`ModifyUserId` bigint NULL,
	`GenderId` bigint NOT NULL,
	`DateOfBirth` Datetime(6) NOT NULL,
	`Profession` varchar(255) NULL,
	`Cpf` varchar(15) NULL,
	`Rg` varchar(15) NOT NULL,
	`Education` varchar(255) NULL,
	`MaritalStatus` int NOT NULL,
	`PhoneNumber` varchar(20) NULL,
	`AddressStreet` varchar(255) NULL,
	`AddressNeighborhood` varchar(255) NULL,
	`AddressCity` varchar(255) NULL,
	`AddressState` varchar(255) NULL,
	`AddressCep` varchar(20) NULL,
	`EmergencyContactName` varchar(255) NULL,
	`EmergencyContactPhoneNumber` varchar(20) NULL,
	`CreatedDate` Datetime(6) NOT NULL,
	`ModifyDate` Datetime(6) NOT NULL,
	`LastAccessDate` Datetime(6) NOT NULL,
 CONSTRAINT `PK_Patients` PRIMARY KEY 
(
	`Id` ASC
) 
);
/* Moved to CREATE TABLE
ALTER TABLE `Patients` ADD  DEFAULT (CONVERT([bit] */,(1))) FOR `Enable`
GO
ALTER TABLE `Patients` ADD  CONSTRAINT `FK_Patients_Genders_GenderId` FOREIGN KEY(`GenderId`)
REFERENCES `Genders` (`Id`)
ON DELETE CASCADE;
 
ALTER TABLE `Patients` CHECK CONSTRAINT `FK_Patients_Genders_GenderId`;
 
ALTER TABLE `Patients` ADD  CONSTRAINT `FK_Patients_Medicals_MedicalId` FOREIGN KEY(`MedicalId`)
REFERENCES `Medicals` (`Id`)
ON DELETE CASCADE;
 
ALTER TABLE `Patients` CHECK CONSTRAINT `FK_Patients_Medicals_MedicalId`;
 
ALTER TABLE `Patients` ADD  CONSTRAINT `FK_Patients_Users_CreatedUserId` FOREIGN KEY(`CreatedUserId`)
REFERENCES `Users` (`Id`);
 
ALTER TABLE `Patients` CHECK CONSTRAINT `FK_Patients_Users_CreatedUserId`;
 
ALTER TABLE `Patients` ADD  CONSTRAINT `FK_Patients_Users_ModifyUserId` FOREIGN KEY(`ModifyUserId`)
REFERENCES `Users` (`Id`);
 
ALTER TABLE `Patients` CHECK CONSTRAINT `FK_Patients_Users_ModifyUserId`;
 
