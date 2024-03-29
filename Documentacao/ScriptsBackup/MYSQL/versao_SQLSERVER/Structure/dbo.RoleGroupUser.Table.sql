USE [SmartDigitalPsicoDB]
GO
/****** Object:  Table [dbo].[RoleGroupUser]    Script Date: 25/04/2023 23:22:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleGroupUser](
	[RoleGroupsId] [bigint] NOT NULL,
	[UsersId] [bigint] NOT NULL,
 CONSTRAINT [PK_RoleGroupUser] PRIMARY KEY CLUSTERED 
(
	[RoleGroupsId] ASC,
	[UsersId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[RoleGroupUser]  WITH CHECK ADD  CONSTRAINT [FK_RoleGroupUser_RoleGroups_RoleGroupsId] FOREIGN KEY([RoleGroupsId])
REFERENCES [dbo].[RoleGroups] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RoleGroupUser] CHECK CONSTRAINT [FK_RoleGroupUser_RoleGroups_RoleGroupsId]
GO
ALTER TABLE [dbo].[RoleGroupUser]  WITH CHECK ADD  CONSTRAINT [FK_RoleGroupUser_Users_UsersId] FOREIGN KEY([UsersId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RoleGroupUser] CHECK CONSTRAINT [FK_RoleGroupUser_Users_UsersId]
GO
