create database ChatCSharp
go 

use ChatCSharp
go
--************************************************************************************
--TABLE: User
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
--DEMO: User
--************************************************************************************

EXEC dbo.USP_AddAccount @name = N'trung' ,@pass = N'abc123'
EXEC dbo.USP_IsInvalidAccountbool @UserName = N'trung' ,@pass = N'abc123'
EXEC dbo.USP_GetAccountByUserName @UserName = N'trung' 

