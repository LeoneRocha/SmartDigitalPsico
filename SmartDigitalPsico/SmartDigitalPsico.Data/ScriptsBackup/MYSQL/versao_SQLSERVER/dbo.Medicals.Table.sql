USE [SmartDigitalPsicoDB]
GO
SET IDENTITY_INSERT [dbo].[Medicals] ON 

INSERT [dbo].[Medicals] ([Id], [Enable], [Name], [Email], [OfficeId], [UserId], [CreatedUserId], [ModifyUserId], [Accreditation], [TypeAccreditation], [SecurityKey], [CreatedDate], [ModifyDate], [LastAccessDate]) VALUES (1, 1, N'Medical MOCK ', N'medical@sistemas.com', 3, NULL, 1, NULL, N'123456', 0, NULL, CAST(N'2023-04-25T11:54:00.6015612' AS DateTime2), CAST(N'2023-04-25T11:54:00.6015615' AS DateTime2), CAST(N'2023-04-25T11:54:00.6015614' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Medicals] OFF
GO
