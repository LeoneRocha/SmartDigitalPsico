USE [SmartDigitalPsicoDB]
GO
SET IDENTITY_INSERT [dbo].[ApplicationLanguage] ON 

INSERT [dbo].[ApplicationLanguage] ([Id], [Enable], [Language], [Description], [LanguageKey], [ResourceKey], [LanguageValue], [CreatedDate], [ModifyDate], [LastAccessDate]) VALUES (1, 1, N'pt-BR', N'Default', N'Default_ptbr', N'ApplicationLanguage', N'Padrão', CAST(N'2023-04-10T19:30:11.5035141' AS DateTime2), CAST(N'2023-04-10T19:30:11.5035144' AS DateTime2), CAST(N'2023-04-10T19:30:11.5035145' AS DateTime2))
INSERT [dbo].[ApplicationLanguage] ([Id], [Enable], [Language], [Description], [LanguageKey], [ResourceKey], [LanguageValue], [CreatedDate], [ModifyDate], [LastAccessDate]) VALUES (2, 1, N'pt-BR', N'Registro encontrado', N'RegisterIsFound', N'SharedResource', N'Registro encontrado', CAST(N'2023-04-08T15:16:18.6786383' AS DateTime2), CAST(N'2023-04-08T15:16:18.5142594' AS DateTime2), CAST(N'2023-04-08T15:16:18.5142594' AS DateTime2))
INSERT [dbo].[ApplicationLanguage] ([Id], [Enable], [Language], [Description], [LanguageKey], [ResourceKey], [LanguageValue], [CreatedDate], [ModifyDate], [LastAccessDate]) VALUES (3, 1, N'pt-BR', N'Registro não encontrado', N'RegisterIsNotFound', N'SharedResource', N'Registro não encontrado', CAST(N'2023-04-08T15:18:35.9657058' AS DateTime2), CAST(N'2023-04-08T15:18:35.9626649' AS DateTime2), CAST(N'2023-04-08T15:18:35.9626649' AS DateTime2))
INSERT [dbo].[ApplicationLanguage] ([Id], [Enable], [Language], [Description], [LanguageKey], [ResourceKey], [LanguageValue], [CreatedDate], [ModifyDate], [LastAccessDate]) VALUES (4, 1, N'pt-BR', N'Registro existe', N'RegisterExist', N'SharedResource', N'Registro existe', CAST(N'2023-04-10T14:05:12.3388809' AS DateTime2), CAST(N'2023-04-10T14:05:12.1257625' AS DateTime2), CAST(N'2023-04-10T14:05:12.1257627' AS DateTime2))
INSERT [dbo].[ApplicationLanguage] ([Id], [Enable], [Language], [Description], [LanguageKey], [ResourceKey], [LanguageValue], [CreatedDate], [ModifyDate], [LastAccessDate]) VALUES (5, 1, N'pt-BR', N'Registro deletado', N'RegisterDeleted', N'SharedResource', N'Registro deletado', CAST(N'2023-04-10T14:09:17.6063523' AS DateTime2), CAST(N'2023-04-10T14:09:17.1808767' AS DateTime2), CAST(N'2023-04-10T14:09:17.1808768' AS DateTime2))
INSERT [dbo].[ApplicationLanguage] ([Id], [Enable], [Language], [Description], [LanguageKey], [ResourceKey], [LanguageValue], [CreatedDate], [ModifyDate], [LastAccessDate]) VALUES (6, 1, N'pt-BR', N'Registro atualizado', N'RegisterUpdated', N'SharedResource', N'Registro atualizado', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2023-04-10T14:44:12.1805140' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[ApplicationLanguage] ([Id], [Enable], [Language], [Description], [LanguageKey], [ResourceKey], [LanguageValue], [CreatedDate], [ModifyDate], [LastAccessDate]) VALUES (7, 1, N'pt-BR', N'Registro localizado', N'RegisterFind', N'SharedResource', N'Registro localizado', CAST(N'2023-04-10T14:13:59.0046614' AS DateTime2), CAST(N'2023-04-10T14:13:58.9986090' AS DateTime2), CAST(N'2023-04-10T14:13:58.9986091' AS DateTime2))
INSERT [dbo].[ApplicationLanguage] ([Id], [Enable], [Language], [Description], [LanguageKey], [ResourceKey], [LanguageValue], [CreatedDate], [ModifyDate], [LastAccessDate]) VALUES (8, 1, N'pt-BR', N'Registros contabilizados', N'RegisterCounted', N'SharedResource', N'Registros contabilizados', CAST(N'2023-04-10T14:14:29.2734086' AS DateTime2), CAST(N'2023-04-10T14:14:29.2678837' AS DateTime2), CAST(N'2023-04-10T14:14:29.2678839' AS DateTime2))
INSERT [dbo].[ApplicationLanguage] ([Id], [Enable], [Language], [Description], [LanguageKey], [ResourceKey], [LanguageValue], [CreatedDate], [ModifyDate], [LastAccessDate]) VALUES (9, 1, N'pt-BR', N'Registro criado', N'RegisterCreated', N'SharedResource', N'Registro criado', CAST(N'2023-04-10T14:15:08.8217824' AS DateTime2), CAST(N'2023-04-10T14:15:08.8163687' AS DateTime2), CAST(N'2023-04-10T14:15:08.8163688' AS DateTime2))
INSERT [dbo].[ApplicationLanguage] ([Id], [Enable], [Language], [Description], [LanguageKey], [ResourceKey], [LanguageValue], [CreatedDate], [ModifyDate], [LastAccessDate]) VALUES (10, 1, N'pt-BR', N'A descrição não pode ser vazia', N'ErrorValidator_Description_Null', N'SharedResource', N'A descrição não pode ser vazia', CAST(N'2023-04-10T15:01:32.4730957' AS DateTime2), CAST(N'2023-04-10T15:01:31.5524646' AS DateTime2), CAST(N'2023-04-10T15:01:31.5524647' AS DateTime2))
INSERT [dbo].[ApplicationLanguage] ([Id], [Enable], [Language], [Description], [LanguageKey], [ResourceKey], [LanguageValue], [CreatedDate], [ModifyDate], [LastAccessDate]) VALUES (11, 1, N'pt-BR', N'O idoma não pode ser vazio', N'ErrorValidator_Language_Null', N'SharedResource', N'O idoma não pode ser vazio', CAST(N'2023-04-10T15:03:08.1550414' AS DateTime2), CAST(N'2023-04-10T15:03:08.0536155' AS DateTime2), CAST(N'2023-04-10T15:03:08.0536156' AS DateTime2))
INSERT [dbo].[ApplicationLanguage] ([Id], [Enable], [Language], [Description], [LanguageKey], [ResourceKey], [LanguageValue], [CreatedDate], [ModifyDate], [LastAccessDate]) VALUES (12, 1, N'pt-BR', N'O idoma não pode ultrapassar {MaxLength}', N'ErrorValidator_Language_MaximumLength', N'SharedResource', N'O idoma não pode ultrapassar {MaxLength}', CAST(N'2023-04-10T15:04:16.4288166' AS DateTime2), CAST(N'2023-04-10T15:04:16.3257504' AS DateTime2), CAST(N'2023-04-10T15:04:16.3257506' AS DateTime2))
INSERT [dbo].[ApplicationLanguage] ([Id], [Enable], [Language], [Description], [LanguageKey], [ResourceKey], [LanguageValue], [CreatedDate], [ModifyDate], [LastAccessDate]) VALUES (13, 1, N'pt-BR', N'Válido', N'LangValid', N'SharedResource', N'Válido', CAST(N'2023-04-10T15:23:06.0916443' AS DateTime2), CAST(N'2023-04-10T15:23:05.9099210' AS DateTime2), CAST(N'2023-04-10T15:23:05.9099210' AS DateTime2))
INSERT [dbo].[ApplicationLanguage] ([Id], [Enable], [Language], [Description], [LanguageKey], [ResourceKey], [LanguageValue], [CreatedDate], [ModifyDate], [LastAccessDate]) VALUES (14, 1, N'pt-BR', N'Ocorreram erros!', N'LangErrors', N'SharedResource', N'Ocorreram erros!', CAST(N'2023-04-10T15:23:32.2423527' AS DateTime2), CAST(N'2023-04-10T15:23:32.2327651' AS DateTime2), CAST(N'2023-04-10T15:23:32.2327652' AS DateTime2))
INSERT [dbo].[ApplicationLanguage] ([Id], [Enable], [Language], [Description], [LanguageKey], [ResourceKey], [LanguageValue], [CreatedDate], [ModifyDate], [LastAccessDate]) VALUES (15, 1, N'pt-BR', N'O medico deve ser informado.', N'ErrorValidator_MedicalId_Null', N'SharedResource', N'O medico deve ser informado.', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2023-04-10T20:02:04.9489994' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[ApplicationLanguage] ([Id], [Enable], [Language], [Description], [LanguageKey], [ResourceKey], [LanguageValue], [CreatedDate], [ModifyDate], [LastAccessDate]) VALUES (16, 1, N'pt-BR', N'O medico informado não existe.', N'ErrorValidator_MedicalId_NotFound', N'SharedResource', N'O medico informado não existe.', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2023-04-10T20:02:24.1359699' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[ApplicationLanguage] ([Id], [Enable], [Language], [Description], [LanguageKey], [ResourceKey], [LanguageValue], [CreatedDate], [ModifyDate], [LastAccessDate]) VALUES (17, 1, N'pt-BR', N'O medico infomado deve ser o mesmo logado. Medicos', N'ErrorValidator_Medical_Changed', N'SharedResource', N'O medico infomado deve ser o mesmo logado. Medicos nao podem criar arquivos de outro medico.', CAST(N'2023-04-10T18:50:11.3087797' AS DateTime2), CAST(N'2023-04-10T18:50:11.2892858' AS DateTime2), CAST(N'2023-04-10T18:50:11.2892859' AS DateTime2))
INSERT [dbo].[ApplicationLanguage] ([Id], [Enable], [Language], [Description], [LanguageKey], [ResourceKey], [LanguageValue], [CreatedDate], [ModifyDate], [LastAccessDate]) VALUES (18, 1, N'pt-BR', N'O nome não pode ser vazio', N'ErrorValidator_Name_Null', N'SharedResource', N'O nome não pode ser vazio', CAST(N'2023-04-10T19:45:23.4766964' AS DateTime2), CAST(N'2023-04-10T19:45:23.4694609' AS DateTime2), CAST(N'2023-04-10T19:45:23.4694610' AS DateTime2))
INSERT [dbo].[ApplicationLanguage] ([Id], [Enable], [Language], [Description], [LanguageKey], [ResourceKey], [LanguageValue], [CreatedDate], [ModifyDate], [LastAccessDate]) VALUES (19, 1, N'pt-BR', N'O Login não pode ser vazio.', N'ErrorValidator_Login_Null', N'SharedResource', N'O Login não pode ser vazio.', CAST(N'2023-04-10T19:46:02.9574039' AS DateTime2), CAST(N'2023-04-10T19:46:02.9518176' AS DateTime2), CAST(N'2023-04-10T19:46:02.9518178' AS DateTime2))
INSERT [dbo].[ApplicationLanguage] ([Id], [Enable], [Language], [Description], [LanguageKey], [ResourceKey], [LanguageValue], [CreatedDate], [ModifyDate], [LastAccessDate]) VALUES (20, 1, N'pt-BR', N'Login deve ser unico.', N'ErrorValidator_Login_Unique', N'SharedResource', N'Login deve ser unico.', CAST(N'2023-04-10T19:47:32.7853664' AS DateTime2), CAST(N'2023-04-10T19:47:32.7794816' AS DateTime2), CAST(N'2023-04-10T19:47:32.7794817' AS DateTime2))
INSERT [dbo].[ApplicationLanguage] ([Id], [Enable], [Language], [Description], [LanguageKey], [ResourceKey], [LanguageValue], [CreatedDate], [ModifyDate], [LastAccessDate]) VALUES (21, 1, N'pt-BR', N'O Email não pode ser vazio', N'ErrorValidator_Email_Null', N'SharedResource', N'O Email não pode ser vazio', CAST(N'2023-04-10T19:48:03.6561980' AS DateTime2), CAST(N'2023-04-10T19:48:03.6503405' AS DateTime2), CAST(N'2023-04-10T19:48:03.6503406' AS DateTime2))
INSERT [dbo].[ApplicationLanguage] ([Id], [Enable], [Language], [Description], [LanguageKey], [ResourceKey], [LanguageValue], [CreatedDate], [ModifyDate], [LastAccessDate]) VALUES (22, 1, N'pt-BR', N'O Email é invalido.', N'ErrorValidator_Email_Invalid', N'SharedResource', N'O Email é invalido.', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2023-04-10T19:48:46.7159280' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[ApplicationLanguage] ([Id], [Enable], [Language], [Description], [LanguageKey], [ResourceKey], [LanguageValue], [CreatedDate], [ModifyDate], [LastAccessDate]) VALUES (23, 1, N'pt-BR', N'O Email deve ser unico.', N'ErrorValidator_Email_Unique', N'SharedResource', N'O Email deve ser unico.', CAST(N'2023-04-10T19:49:49.9080886' AS DateTime2), CAST(N'2023-04-10T19:49:49.9022291' AS DateTime2), CAST(N'2023-04-10T19:49:49.9022293' AS DateTime2))
INSERT [dbo].[ApplicationLanguage] ([Id], [Enable], [Language], [Description], [LanguageKey], [ResourceKey], [LanguageValue], [CreatedDate], [ModifyDate], [LastAccessDate]) VALUES (24, 1, N'pt-BR', N'O Credenciamento não pode ser vazio.', N'ErrorValidator_Accreditation_Null', N'SharedResource', N'O Credenciamento não pode ser vazio.', CAST(N'2023-04-10T19:56:03.6336035' AS DateTime2), CAST(N'2023-04-10T19:56:03.5781467' AS DateTime2), CAST(N'2023-04-10T19:56:03.5781468' AS DateTime2))
INSERT [dbo].[ApplicationLanguage] ([Id], [Enable], [Language], [Description], [LanguageKey], [ResourceKey], [LanguageValue], [CreatedDate], [ModifyDate], [LastAccessDate]) VALUES (25, 1, N'pt-BR', N'O Credenciamento deve ser unico.', N'ErrorValidator_Accreditation_Unique', N'SharedResource', N'O Credenciamento deve ser unico.', CAST(N'2023-04-10T19:57:01.1920431' AS DateTime2), CAST(N'2023-04-10T19:57:01.1849125' AS DateTime2), CAST(N'2023-04-10T19:57:01.1849126' AS DateTime2))
INSERT [dbo].[ApplicationLanguage] ([Id], [Enable], [Language], [Description], [LanguageKey], [ResourceKey], [LanguageValue], [CreatedDate], [ModifyDate], [LastAccessDate]) VALUES (26, 1, N'pt-BR', N'O medico infomado deve ser o mesmo logado. Medicos', N'ErrorValidator_MedicalCreated_Invalid', N'SharedResource', N'O medico infomado deve ser o mesmo logado. Medicos nao podem criar arquivos de outro medico.', CAST(N'2023-04-10T20:03:32.8269570' AS DateTime2), CAST(N'2023-04-10T20:03:32.8205879' AS DateTime2), CAST(N'2023-04-10T20:03:32.8205881' AS DateTime2))
INSERT [dbo].[ApplicationLanguage] ([Id], [Enable], [Language], [Description], [LanguageKey], [ResourceKey], [LanguageValue], [CreatedDate], [ModifyDate], [LastAccessDate]) VALUES (27, 1, N'pt-BR', N'O medico infomado deve ser o mesmo logado. Medicos', N'ErrorValidator_MedicalModify_Invalid', N'SharedResource', N'O medico infomado deve ser o mesmo logado. Medicos nao podem modificar arquivos de outro medico.', CAST(N'2023-04-10T20:04:05.7287407' AS DateTime2), CAST(N'2023-04-10T20:04:05.7212572' AS DateTime2), CAST(N'2023-04-10T20:04:05.7212574' AS DateTime2))
INSERT [dbo].[ApplicationLanguage] ([Id], [Enable], [Language], [Description], [LanguageKey], [ResourceKey], [LanguageValue], [CreatedDate], [ModifyDate], [LastAccessDate]) VALUES (28, 1, N'pt-BR', N'O Paciente deve ser informado.', N'ErrorValidator_Patient_Null', N'SharedResource', N'O Paciente deve ser informado.', CAST(N'2023-04-10T20:05:12.1562556' AS DateTime2), CAST(N'2023-04-10T20:05:12.1473831' AS DateTime2), CAST(N'2023-04-10T20:05:12.1473833' AS DateTime2))
INSERT [dbo].[ApplicationLanguage] ([Id], [Enable], [Language], [Description], [LanguageKey], [ResourceKey], [LanguageValue], [CreatedDate], [ModifyDate], [LastAccessDate]) VALUES (29, 1, N'pt-BR', N'O Paciente informado não existe.', N'ErrorValidator_Patient_NotFound', N'SharedResource', N'O Paciente informado não existe.', CAST(N'2023-04-10T20:05:56.7853775' AS DateTime2), CAST(N'2023-04-10T20:05:56.7789265' AS DateTime2), CAST(N'2023-04-10T20:05:56.7789266' AS DateTime2))
INSERT [dbo].[ApplicationLanguage] ([Id], [Enable], [Language], [Description], [LanguageKey], [ResourceKey], [LanguageValue], [CreatedDate], [ModifyDate], [LastAccessDate]) VALUES (30, 1, N'pt-BR', N'O Paciente não pode ser alterado.', N'ErrorValidator_Patient_Changed', N'SharedResource', N'O Paciente não pode ser alterado.', CAST(N'2023-04-10T20:06:27.7129302' AS DateTime2), CAST(N'2023-04-10T20:06:27.7084043' AS DateTime2), CAST(N'2023-04-10T20:06:27.7084045' AS DateTime2))
INSERT [dbo].[ApplicationLanguage] ([Id], [Enable], [Language], [Description], [LanguageKey], [ResourceKey], [LanguageValue], [CreatedDate], [ModifyDate], [LastAccessDate]) VALUES (31, 1, N'pt-BR', N'Informações do paciente não podem ser adicionadas ', N'ErrorValidator_Patient_Medical_Created', N'SharedResource', N'Informações do paciente não podem ser adicionadas por outro medico e/ou usuario.', CAST(N'2023-04-10T20:06:54.7036241' AS DateTime2), CAST(N'2023-04-10T20:06:54.6965949' AS DateTime2), CAST(N'2023-04-10T20:06:54.6965951' AS DateTime2))
INSERT [dbo].[ApplicationLanguage] ([Id], [Enable], [Language], [Description], [LanguageKey], [ResourceKey], [LanguageValue], [CreatedDate], [ModifyDate], [LastAccessDate]) VALUES (32, 1, N'pt-BR', N'Informações do paciente não podem ser modificadas ', N'ErrorValidator_Patient_Medical_Modify', N'SharedResource', N'Informações do paciente não podem ser modificadas por outro medico e/ou usuario.', CAST(N'2023-04-10T20:07:19.1459597' AS DateTime2), CAST(N'2023-04-10T20:07:19.1409878' AS DateTime2), CAST(N'2023-04-10T20:07:19.1409880' AS DateTime2))
INSERT [dbo].[ApplicationLanguage] ([Id], [Enable], [Language], [Description], [LanguageKey], [ResourceKey], [LanguageValue], [CreatedDate], [ModifyDate], [LastAccessDate]) VALUES (33, 1, N'pt-BR', N'O Usuário que está criando deve ser informado.', N'ErrorValidator_CreatedUser_Null', N'SharedResource', N'O Usuário que está criando deve ser informado.', CAST(N'2023-04-10T20:08:10.7752037' AS DateTime2), CAST(N'2023-04-10T20:08:10.7702910' AS DateTime2), CAST(N'2023-04-10T20:08:10.7702912' AS DateTime2))
INSERT [dbo].[ApplicationLanguage] ([Id], [Enable], [Language], [Description], [LanguageKey], [ResourceKey], [LanguageValue], [CreatedDate], [ModifyDate], [LastAccessDate]) VALUES (34, 1, N'pt-BR', N'A anotação não pode ser vazia.', N'ErrorValidator_Annotation_Null', N'SharedResource', N'A anotação não pode ser vazia.', CAST(N'2023-04-10T20:13:44.6992105' AS DateTime2), CAST(N'2023-04-10T20:13:44.6924342' AS DateTime2), CAST(N'2023-04-10T20:13:44.6924344' AS DateTime2))
INSERT [dbo].[ApplicationLanguage] ([Id], [Enable], [Language], [Description], [LanguageKey], [ResourceKey], [LanguageValue], [CreatedDate], [ModifyDate], [LastAccessDate]) VALUES (35, 1, N'pt-BR', N'A data da anotação não pode ser vazia.', N'ErrorValidator_AnnotationDate_Null', N'SharedResource', N'A data da anotação não pode ser vazia.', CAST(N'2023-04-10T20:14:13.5623338' AS DateTime2), CAST(N'2023-04-10T20:14:13.5562345' AS DateTime2), CAST(N'2023-04-10T20:14:13.5562346' AS DateTime2))
INSERT [dbo].[ApplicationLanguage] ([Id], [Enable], [Language], [Description], [LanguageKey], [ResourceKey], [LanguageValue], [CreatedDate], [ModifyDate], [LastAccessDate]) VALUES (36, 1, N'pt-BR', N'Data de nascimento invalido', N'ErrorValidator_DateOfBirth_Invalid', N'SharedResource', N'Data de nascimento invalido', CAST(N'2023-04-10T20:16:16.8702670' AS DateTime2), CAST(N'2023-04-10T20:16:16.8648931' AS DateTime2), CAST(N'2023-04-10T20:16:16.8648933' AS DateTime2))
INSERT [dbo].[ApplicationLanguage] ([Id], [Enable], [Language], [Description], [LanguageKey], [ResourceKey], [LanguageValue], [CreatedDate], [ModifyDate], [LastAccessDate]) VALUES (37, 1, N'pt-BR', N'O Rg não pode ser vazio.', N'ErrorValidator_RG_Null', N'SharedResource', N'O Rg não pode ser vazio.', CAST(N'2023-04-10T20:16:52.1240039' AS DateTime2), CAST(N'2023-04-10T20:16:52.1183786' AS DateTime2), CAST(N'2023-04-10T20:16:52.1183788' AS DateTime2))
INSERT [dbo].[ApplicationLanguage] ([Id], [Enable], [Language], [Description], [LanguageKey], [ResourceKey], [LanguageValue], [CreatedDate], [ModifyDate], [LastAccessDate]) VALUES (38, 1, N'pt-BR', N'O CPF não pode ser vazio.', N'ErrorValidator_CPF_Null', N'SharedResource', N'O CPF não pode ser vazio.', CAST(N'2023-04-10T20:17:21.9842569' AS DateTime2), CAST(N'2023-04-10T20:17:21.9793706' AS DateTime2), CAST(N'2023-04-10T20:17:21.9793708' AS DateTime2))
SET IDENTITY_INSERT [dbo].[ApplicationLanguage] OFF
GO
