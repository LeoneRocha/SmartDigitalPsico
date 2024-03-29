USE `SmartDigitalPsicoDB`;
 
/* SQLINES DEMO *** le [dbo].[ApplicationLanguage]    Script Date: 25/04/2023 23:22:15 ******/
/* SET ANSI_NULLS ON */
 
/* SET QUOTED_IDENTIFIER ON */
 
-- SQLINES LICENSE FOR EVALUATION USE ONLY
CREATE TABLE `ApplicationLanguage`(
	`Id` bigint AUTO_INCREMENT NOT NULL,
	`Enable` Tinyint NULL,
	`Language` varchar(10) NOT NULL,
	`Description` varchar(255) NOT NULL,
	`LanguageKey` varchar(255) NOT NULL,
	`ResourceKey` varchar(255) NOT NULL DEFAULT 'ApplicationLanguage',
	`LanguageValue` varchar(1000) NOT NULL,
	`CreatedDate` Datetime(6) NOT NULL,
	`ModifyDate` Datetime(6) NOT NULL,
	`LastAccessDate` Datetime(6) NOT NULL,
 CONSTRAINT `PK_ApplicationLanguage` PRIMARY KEY 
(
	`Id` ASC
) 
);
/* Moved to CREATE TABLE
ALTER TABLE `ApplicationLanguage` ADD  DEFAULT ('ApplicationLanguage') FOR `ResourceKey`
GO */
