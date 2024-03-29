USE `SmartDigitalPsicoDB`;
 
/* SQLINES DEMO *** le [dbo].[Officies]    Script Date: 25/04/2023 23:22:15 ******/
/* SET ANSI_NULLS ON */
 
/* SET QUOTED_IDENTIFIER ON */
 
-- SQLINES LICENSE FOR EVALUATION USE ONLY
CREATE TABLE `Officies`(
	`Id` bigint AUTO_INCREMENT NOT NULL,
	`Enable` Tinyint NULL,
	`Description` varchar(255) NOT NULL,
	`Language` varchar(10) NOT NULL,
	`CreatedDate` Datetime(6) NOT NULL,
	`ModifyDate` Datetime(6) NOT NULL,
	`LastAccessDate` Datetime(6) NOT NULL,
 CONSTRAINT `PK_Officies` PRIMARY KEY 
(
	`Id` ASC
) 
);
/* Moved to CREATE TABLE
ALTER TABLE `Officies` ADD  DEFAULT (CONVERT([bit] */,(1))) FOR `Enable`
GO
