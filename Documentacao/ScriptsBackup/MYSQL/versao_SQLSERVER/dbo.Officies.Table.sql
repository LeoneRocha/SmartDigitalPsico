USE [SmartDigitalPsicoDB]
GO
SET IDENTITY_INSERT [dbo].[Officies] ON 

INSERT [dbo].[Officies] ([Id], [Enable], [Description], [Language], [CreatedDate], [ModifyDate], [LastAccessDate]) VALUES (1, 1, N'Psicólogo', N'pt-BR', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Officies] ([Id], [Enable], [Description], [Language], [CreatedDate], [ModifyDate], [LastAccessDate]) VALUES (2, 1, N'Psicóloga', N'pt-BR', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Officies] ([Id], [Enable], [Description], [Language], [CreatedDate], [ModifyDate], [LastAccessDate]) VALUES (3, 1, N'Clínico', N'pt-BR', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Officies] OFF
GO
