CREATE PROCEDURE [dbo].[usp_UserLogin]
	@UserEmail	  varchar(200),
	@UserPassword varchar(100)
AS
	SELECT U_ID
	FROM User_account
	where U_email=@UserEmail and U_password= @UserPassword

GO
