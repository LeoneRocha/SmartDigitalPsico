CREATE TABLE smartdigitalpsicodb.`PatientMedicationInformations`(
	`Id` bigint AUTO_INCREMENT NOT NULL,
	`Enable` Tinyint Unsigned NULL,
	`PatientId` bigint NOT NULL,
	`CreatedUserId` bigint NULL,
	`ModifyUserId` bigint NULL,
	`Description` varchar(255) NOT NULL,
	`StartDate` Datetime(6) NOT NULL,
	`EndDate` Datetime(6) NULL,
	`Dosage` varchar(255) NULL,
	`Posology` varchar(255) NULL,
	`MainDrug` varchar(255) NULL,
	`CreatedDate` Datetime(6) NOT NULL,
	`ModifyDate` Datetime(6) NOT NULL,
	`LastAccessDate` Datetime(6) NOT NULL,
 CONSTRAINT `PK_PatientMedicationInformations` PRIMARY KEY 
(
	`Id` ASC
) 
);
 
ALTER TABLE smartdigitalpsicodb.`PatientMedicationInformations` ADD  CONSTRAINT `FK_PatientMedicationInformations_Patients_PatientId` FOREIGN KEY(`PatientId`)
REFERENCES `Patients` (`Id`)
ON DELETE CASCADE;
 
ALTER TABLE smartdigitalpsicodb.`PatientMedicationInformations` ADD  CONSTRAINT `FK_PatientMedicationInformations_Users_CreatedUserId` FOREIGN KEY(`CreatedUserId`)
REFERENCES `Users` (`Id`);
 
ALTER TABLE smartdigitalpsicodb.`PatientMedicationInformations` ADD  CONSTRAINT `FK_PatientMedicationInformations_Users_ModifyUserId` FOREIGN KEY(`ModifyUserId`)
REFERENCES `Users` (`Id`);
  