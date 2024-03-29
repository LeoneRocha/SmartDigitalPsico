  
CREATE TABLE smartdigitalpsicodb.`PatientNotificationMessage`(
	`Id` bigint AUTO_INCREMENT NOT NULL,
	`Enable` Tinyint NULL,
	`PatientId` bigint NOT NULL,
	`CreatedUserId` bigint NULL,
	`ModifyUserId` bigint NULL,
	`MessagePatient` varchar(2000) NOT NULL,
	`IsReaded` Tinyint NOT NULL,
	`ReadingDate` Datetime(6) NULL,
	`Notified` Tinyint NOT NULL,
	`NotifiedDate` Datetime(6) NULL,
	`CreatedDate` Datetime(6) NOT NULL,
	`ModifyDate` Datetime(6) NOT NULL,
	`LastAccessDate` Datetime(6) NOT NULL,
 CONSTRAINT `PK_PatientNotificationMessage` PRIMARY KEY 
(
	`Id` ASC
) 
);
 
ALTER TABLE smartdigitalpsicodb.`PatientNotificationMessage` ADD  CONSTRAINT `FK_PatientNotificationMessage_Patients_PatientId` FOREIGN KEY(`PatientId`)
REFERENCES `Patients` (`Id`)
ON DELETE CASCADE;
  
ALTER TABLE smartdigitalpsicodb.`PatientNotificationMessage` ADD  CONSTRAINT `FK_PatientNotificationMessage_Users_CreatedUserId` FOREIGN KEY(`CreatedUserId`)
REFERENCES `Users` (`Id`);
 
 
ALTER TABLE smartdigitalpsicodb.`PatientNotificationMessage` ADD  CONSTRAINT `FK_PatientNotificationMessage_Users_ModifyUserId` FOREIGN KEY(`ModifyUserId`)
REFERENCES `Users` (`Id`);
 
