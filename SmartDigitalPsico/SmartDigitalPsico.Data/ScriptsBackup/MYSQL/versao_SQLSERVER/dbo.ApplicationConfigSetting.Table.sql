USE [SmartDigitalPsicoDB]
GO
SET IDENTITY_INSERT [dbo].[ApplicationConfigSetting] ON 

INSERT [dbo].[ApplicationConfigSetting] ([Id], [Enable], [Description], [Language], [EndPointUrl_StorageFiles], [EndPointUrl_Cache], [TypeLocationSaveFiles], [TypeLocationCache], [TypeLocationQueeMessaging], [CreatedDate], [ModifyDate], [LastAccessDate]) VALUES (1, 1, N'Default', N'pt-BR', N'', N'', 0, 1, 0, CAST(N'2023-04-25T11:54:00.5994079' AS DateTime2), CAST(N'2023-04-25T11:54:00.5994088' AS DateTime2), CAST(N'2023-04-25T11:54:00.5994088' AS DateTime2))
SET IDENTITY_INSERT [dbo].[ApplicationConfigSetting] OFF
GO
