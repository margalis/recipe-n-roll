CREATE PROCEDURE [dbo].[usp_NewUserReg]
	@UserFullName nvarchar(100) ,
	@UserEmail	  varchar(200),
	@UserPassword	varchar(100)
AS
	INSERT INTO [dbo].[User_account]([U_FullName],[U_email],[U_password])
	OUTPUT inserted.U_ID
	VALUES (@UserFullName, @UserEmail, @UserPassword)
go

