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

CREATE PROC USP_IsInvalidAccountbool
@UserName nvarchar(100), @pass NVARCHAR(1000)
AS
BEGIN
	SELECT 1 FROM dbo.Account WHERE userName = @UserName AND passWord = @pass
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

--************************************************************************************
--TABLE: User
--************************************************************************************

create table CurrentUser
(
	userName nvarchar(100) primary key,
	userstatus int not null default 0 --(0: offline, 1: online)
)
GO

CREATE PROC USP_UpdateCurrentUser
@name NVARCHAR(100)
AS 
BEGIN
	INSERT INTO dbo.CurrentUser( userName) VALUES  ( @name)
END
GO

CREATE PROC USP_DeleteCurrentUser
AS 
BEGIN
	DELETE FROM CurrentUser
END
GO

CREATE PROC USP_GetCurrentUser
AS 
BEGIN
	SELECT * FROM dbo.CurrentUser 
END
GO

exec USP_UpdateCurrentUser @name = 'trung'
go
exec USP_GetCurrentUser 
go
exec USP_DeleteCurrentUser
go