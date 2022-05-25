CREATE TABLE [dbo].[User_account]
(
	[U_ID]			INT				NOT NULL  IDENTITY(1000,1),
	[U_FullName]	nvarchar(100)   NOT NULL,
	[U_email]		varchar(200)	NOT NULL,
	[U_password]	varchar(100)	NOT NULL,
	[U_image_url]	nvarchar(2100)	NULL ,
	[U_reg_date]	datetime2		NOT NULL  CONSTRAINT df_UserDt default SysDateTime(),  
	--[U_is active]   char(1)		NOT NULL,  -- 
	--[U_email notf]  char(1)		NOT NULL   -- 

	CONSTRAINT pk_User PRIMARY KEY(U_ID),
	CONSTRAINT un_User UNIQUE(U_email, U_password )
)
