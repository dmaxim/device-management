
GO
USE MASTER
GO

CREATE LOGIN DeviceManagerApp WITH PASSWORD = '$(appPassword)';

GO

CREATE USER DeviceManagerApp FOR LOGIN DeviceManagerApp WITH DEFAULT_SCHEMA = [dbo]

GO

USE DeviceManager
GO

CREATE USER DeviceManagerApp FOR LOGIN DeviceManagerApp WITH DEFAULT_SCHEMA = [dbo]

GO

CREATE ROLE DeviceManagerRole AUTHORIZATION [dbo]

GO


GRANT 
	DELETE, 
	EXECUTE, 
	INSERT, 
	SELECT, 
	UPDATE
ON SCHEMA :: dbo
	TO DeviceManagerRole
GO


EXEC sp_addrolemember 'DeviceManagerRole', 'DeviceManagerApp';

GO

