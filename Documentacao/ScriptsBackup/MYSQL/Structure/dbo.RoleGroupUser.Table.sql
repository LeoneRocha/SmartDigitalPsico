USE `SmartDigitalPsicoDB`;
 
/* SQLINES DEMO *** le [dbo].[RoleGroupUser]    Script Date: 25/04/2023 23:22:15 ******/
/* SET ANSI_NULLS ON */
 
/* SET QUOTED_IDENTIFIER ON */
 
-- SQLINES LICENSE FOR EVALUATION USE ONLY
CREATE TABLE `RoleGroupUser`(
	`RoleGroupsId` bigint NOT NULL,
	`UsersId` bigint NOT NULL,
 CONSTRAINT `PK_RoleGroupUser` PRIMARY KEY 
(
	`RoleGroupsId` ASC,
	`UsersId` ASC
) 
);
ALTER TABLE `RoleGroupUser` ADD  CONSTRAINT `FK_RoleGroupUser_RoleGroups_RoleGroupsId` FOREIGN KEY(`RoleGroupsId`)
REFERENCES `RoleGroups` (`Id`)
ON DELETE CASCADE;
 
ALTER TABLE `RoleGroupUser` CHECK CONSTRAINT `FK_RoleGroupUser_RoleGroups_RoleGroupsId`;
 
ALTER TABLE `RoleGroupUser` ADD  CONSTRAINT `FK_RoleGroupUser_Users_UsersId` FOREIGN KEY(`UsersId`)
REFERENCES `Users` (`Id`)
ON DELETE CASCADE;
 
ALTER TABLE `RoleGroupUser` CHECK CONSTRAINT `FK_RoleGroupUser_Users_UsersId`;
 
