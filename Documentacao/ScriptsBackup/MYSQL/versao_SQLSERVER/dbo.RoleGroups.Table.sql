USE [SmartDigitalPsicoDB]
GO
SET IDENTITY_INSERT [dbo].[RoleGroups] ON 

INSERT [dbo].[RoleGroups] ([Id], [Enable], [Description], [Language], [RolePolicyClaimCode], [CreatedDate], [ModifyDate], [LastAccessDate]) VALUES (1, 1, N'Administrador', N'pt-BR', N'Admin', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[RoleGroups] ([Id], [Enable], [Description], [Language], [RolePolicyClaimCode], [CreatedDate], [ModifyDate], [LastAccessDate]) VALUES (2, 1, N'Medico', N'pt-BR', N'Medical', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[RoleGroups] ([Id], [Enable], [Description], [Language], [RolePolicyClaimCode], [CreatedDate], [ModifyDate], [LastAccessDate]) VALUES (3, 1, N'Recepcionista', N'pt-BR', N'Staff', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[RoleGroups] ([Id], [Enable], [Description], [Language], [RolePolicyClaimCode], [CreatedDate], [ModifyDate], [LastAccessDate]) VALUES (4, 1, N'Paciente', N'pt-BR', N'Patient', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[RoleGroups] ([Id], [Enable], [Description], [Language], [RolePolicyClaimCode], [CreatedDate], [ModifyDate], [LastAccessDate]) VALUES (5, 1, N'Leitura', N'pt-BR', N'Read', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[RoleGroups] ([Id], [Enable], [Description], [Language], [RolePolicyClaimCode], [CreatedDate], [ModifyDate], [LastAccessDate]) VALUES (6, 1, N'Escrita', N'pt-BR', N'Write', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[RoleGroups] OFF
GO
