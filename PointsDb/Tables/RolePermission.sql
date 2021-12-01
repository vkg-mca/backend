CREATE TABLE [dbo].[RolePermission]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [RoleId] INT NOT NULL REFERENCES [Role]([Id]),
    [PermissionId] INT NOT NULL REFERENCES [permission]([Id])
)
