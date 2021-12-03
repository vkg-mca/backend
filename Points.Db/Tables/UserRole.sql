﻿CREATE TABLE [dbo].[UserRole]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [UserId] INT NOT NULL REFERENCES [User]([Id]),
    [RoleId] INT NOT NULL REFERENCES [Role]([Id]),
)
