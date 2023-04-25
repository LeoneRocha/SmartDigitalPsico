USE [SmartDigitalPsicoDB]
GO
SET IDENTITY_INSERT [dbo].[Genders] ON 

INSERT [dbo].[Genders] ([Id], [Enable], [Description], [Language], [CreatedDate], [ModifyDate], [LastAccessDate]) VALUES (1, 1, N'Masculino', N'pt-BR', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Genders] ([Id], [Enable], [Description], [Language], [CreatedDate], [ModifyDate], [LastAccessDate]) VALUES (2, 1, N'Feminino', N'pt-BR', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Genders] OFF
GO
