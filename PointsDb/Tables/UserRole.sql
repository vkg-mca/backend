CREATE TABLE [dbo].[UserRole]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [userId] INT NOT NULL,
    [RoleId] INT NOT NULL
)
