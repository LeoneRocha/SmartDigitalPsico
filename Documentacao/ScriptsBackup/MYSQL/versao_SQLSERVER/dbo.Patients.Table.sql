USE [SmartDigitalPsicoDB]
GO
SET IDENTITY_INSERT [dbo].[Patients] ON 

INSERT [dbo].[Patients] ([Id], [Enable], [Name], [Email], [MedicalId], [CreatedUserId], [ModifyUserId], [GenderId], [DateOfBirth], [Profession], [Cpf], [Rg], [Education], [MaritalStatus], [PhoneNumber], [AddressStreet], [AddressNeighborhood], [AddressCity], [AddressState], [AddressCep], [EmergencyContactName], [EmergencyContactPhoneNumber], [CreatedDate], [ModifyDate], [LastAccessDate]) VALUES (1, 1, N'Tiago Thales Mendes', N'tiago.thales.mendes@andrade.com', 1, 1, NULL, 1, CAST(N'1960-03-11T00:00:00.0000000' AS DateTime2), N'Professor', N'947.846.605-42', N'13.809.283-7', N'Superior', 0, N'(73) 2877-3408', N'Avenida Presidente Médici 264', N'Centro', N'Aurelino Leal', N'Bahia', N'45675-970', N'Milena Isabelly Vanessa', N'(73) 98540-4268', CAST(N'2023-04-25T11:54:00.6035464' AS DateTime2), CAST(N'2023-04-25T11:54:00.6035466' AS DateTime2), CAST(N'2023-04-25T11:54:00.6035466' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Patients] OFF
GO
