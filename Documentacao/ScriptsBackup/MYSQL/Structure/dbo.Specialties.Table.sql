USE `SmartDigitalPsicoDB`;
 
/* SQLINES DEMO *** le [dbo].[Specialties]    Script Date: 25/04/2023 23:22:15 ******/
/* SET ANSI_NULLS ON */
 
/* SET QUOTED_IDENTIFIER ON */
 
-- SQLINES LICENSE FOR EVALUATION USE ONLY
CREATE TABLE `Specialties`(
	`Id` bigint AUTO_INCREMENT NOT NULL,
	`Enable` Tinyint NULL,
	`Description` varchar(255) NOT NULL,
	`Language` varchar(10) NOT NULL,
	`CreatedDate` Datetime(6) NOT NULL,
	`ModifyDate` Datetime(6) NOT NULL,
	`LastAccessDate` Datetime(6) NOT NULL,
 CONSTRAINT `PK_Specialties` PRIMARY KEY 
(
	`Id` ASC
) 
);
/* Moved to CREATE TABLE
ALTER TABLE `Specialties` ADD  DEFAULT (CONVERT([bit] */,(1))) FOR `Enable`
GO
