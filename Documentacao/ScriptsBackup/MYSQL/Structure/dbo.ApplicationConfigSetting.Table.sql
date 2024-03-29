USE `SmartDigitalPsicoDB`;
 
/* SQLINES DEMO *** le [dbo].[ApplicationConfigSetting]    Script Date: 25/04/2023 23:22:15 ******/
/* SET ANSI_NULLS ON */
 
/* SET QUOTED_IDENTIFIER ON */
 
-- SQLINES LICENSE FOR EVALUATION USE ONLY
CREATE TABLE `ApplicationConfigSetting`(
	`Id` bigint AUTO_INCREMENT NOT NULL,
	`Enable` Tinyint NULL,
	`Description` varchar(255) NOT NULL,
	`Language` varchar(10) NOT NULL,
	`EndPointUrl_StorageFiles` varchar(255) NOT NULL,
	`EndPointUrl_Cache` varchar(255) NOT NULL,
	`TypeLocationSaveFiles` int NOT NULL,
	`TypeLocationCache` int NOT NULL,
	`TypeLocationQueeMessaging` int NOT NULL,
	`CreatedDate` Datetime(6) NOT NULL,
	`ModifyDate` Datetime(6) NOT NULL,
	`LastAccessDate` Datetime(6) NOT NULL,
 CONSTRAINT `PK_ApplicationConfigSetting` PRIMARY KEY 
(
	`Id` ASC
) 
);
