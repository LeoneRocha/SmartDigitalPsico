USE `SmartDigitalPsicoDB`;
 
/* SET IDENTITY_INSERT [dbo].[Patients] ON */ 

-- SQLINES LICENSE FOR EVALUATION USE ONLY
INSERT smartdigitalpsicodb.`Patients` (`Id`, `Enable`, `Name`, `Email`, `MedicalId`, `CreatedUserId`, `ModifyUserId`, `GenderId`, `DateOfBirth`, `Profession`, `Cpf`, `Rg`, `Education`, `MaritalStatus`, `PhoneNumber`, `AddressStreet`, `AddressNeighborhood`, `AddressCity`, `AddressState`, `AddressCep`, `EmergencyContactName`, `EmergencyContactPhoneNumber`, `CreatedDate`, `ModifyDate`, `LastAccessDate`) VALUES (1, 1, 'Tiago Thales Mendes', 'tiago.thales.mendes@andrade.com', 1, 1, NULL, 1, CAST('1960-03-11T00:00:00.0000000' AS DATETIME(6)), 'Professor', '947.846.605-42', '13.809.283-7', 'Superior', 0, '(73) 2877-3408', 'Avenida Presidente Médici 264', 'Centro', 'Aurelino Leal', 'Bahia', '45675-970', 'Milena Isabelly Vanessa', '(73) 98540-4268', CAST('2023-04-25T11:54:00.6035464' AS DATETIME(6)), CAST('2023-04-25T11:54:00.6035466' AS DATETIME(6)), CAST('2023-04-25T11:54:00.6035466' AS DATETIME(6)));
/* SET IDENTITY_INSERT [dbo].[Patients] OFF */
 
