/*CREATE PROCEDURE [dbo].[usp_GetUserInfo]
	@UserID int ,
	@UserFullName nvarchar(100) out ,
	@UserEmail varchar(200) out ,
	@UserPassword varchar(200) out ,
	@UImage nvarchar(2100) out ,
	@URegDate int out 
	
AS
	SELECT @UserFullName=U_FullName, @UserEmail=U_email,
	@UserPassword= U_password,@UImage= U_image_url, @URegDate=U_reg_date
	FROM User_account
	WHERE  U_ID= @UserID
	/* 
	[U_FullName]	nvarchar(100)   NOT NULL,
	[U_email]		varchar(200)	NOT NULL,
	[U_password]	varchar(100)	NOT NULL,
	[U_image_url]	nvarchar(2100)	NULL ,
	[U_reg_date]	
	*/
GO

*/

CREATE PROCEDURE [dbo].[usp_GetUserInfo]
	@UserID int 
AS

Select *
from User_account 
where U_ID=@UserID

GO