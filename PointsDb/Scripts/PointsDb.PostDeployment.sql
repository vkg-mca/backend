/*
 Pre-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be executed before the build script.	
 Use SQLCMD syntax to include a file in the pre-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the pre-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
--TRUNCATE TABLE Permission;
--TRUNCATE TABLE AccessControl;

INSERT INTO [dbo].[Role] VALUES 
('GUEST','Guest'),
('USER','User'),
('MANAGER','Manager'),
('ADMIN','Administrator')

INSERT INTO [dbo].[Permission] VALUES 
('NONE','No Permission'),
('CREATE','Create'),
('READ','Read'),
('UPDATE','Update'),
('DELETE','Delete'),
('ALL','All')

INSERT INTO [dbo].[RolePermission] VALUES 
(1,1),
(2,2),
(2,3),
(3,2),
(3,3),
(3,4),
(4,6)

INSERT INTO [dbo].[User] VALUES 
('VKG','Vinod'),
('KJC','Jit'),
('AKR','Ajay'),
('AP','Ashwani'),
('SV','Srini')

INSERT INTO [dbo].[UserRole] VALUES 
(1,1),
(2,2),
(3,3),
(4,4)