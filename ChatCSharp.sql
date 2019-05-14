create database ChatCSharp
go 

use ChatCSharp
go
--************************************************************************************
--TABLE: Account
--************************************************************************************
create table Account
(
	userName nvarchar(100) primary key,
	passWord nvarchar(1000) not null ,
	userstatus int not null default 0 --(0: offline, 1: online)
)

CREATE PROC USP_GetAccountByUserName
@UserName nvarchar(100)
AS
BEGIN
	SELECT * FROM dbo.Account WHERE userName = @UserName
END
GO

CREATE PROC USP_IsInvalidAccount
@UserName nvarchar(100), @pass NVARCHAR(1000)
AS
BEGIN
	SELECT * FROM dbo.Account WHERE userName = @UserName AND passWord = @pass
END
GO

CREATE PROC USP_GetAllUserName
AS
BEGIN
	SELECT userName FROM dbo.Account 
END
GO

CREATE PROC USP_AddAccount
@name NVARCHAR(100), @pass NVARCHAR(1000)
AS 
BEGIN
	INSERT INTO dbo.Account( userName, passWord) VALUES  ( @name, @pass)
END
GO

--************************************************************************************
--DEMO: Account
--************************************************************************************

EXEC dbo.USP_AddAccount @name = N'trung' ,@pass = N'abc123'
EXEC dbo.USP_IsInvalidAccountbool @UserName = N'trung' ,@pass = N'abc123'
EXEC dbo.USP_GetAccountByUserName @UserName = N'trung'
exec USP_GetAllUserName

create table MessageOffline
(
	userName nvarchar(100) not null ,
	message nvarchar(1000) not null ,
	senderr nvarchar(100) not null
)

CREATE PROC USP_AddMessage
@name NVARCHAR(100), @message NVARCHAR(1000), @sender NVARCHAR(100)
AS 
BEGIN
	INSERT INTO dbo.MessageOffline( userName, message, senderr) VALUES  ( @name, @message, @sender)
END
GO

CREATE PROC USP_GetMessage
@name NVARCHAR(100)
AS 
BEGIN
	SELECT * FROM dbo.MessageOffline 
END
GO

CREATE PROC USP_DeleteMessage
@name NVARCHAR(100)
AS 
BEGIN
	DELETE FROM MessageOffline WHERE @name = userName
END
GO

exec USP_AddMessage @name = 'trung',@message = '1223456789', @sender = 'Server'
go
exec USP_GetMessage @name = 'thuy'
exec USP_GetMessage @name = 'trung'
exec USP_DeleteMessage @name = 'trung'
delete MessageOffline
drop proc USP_GetMessage