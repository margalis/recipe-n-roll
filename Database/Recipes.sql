CREATE TABLE [dbo].[Recipes]
(
	[R_ID]			INT					NOT NULL	 IDENTITY(100,1) ,
	[R_name]		nvarchar(20)		NOT NULL ,	
	[R_description] nvarchar(600)		NULL     ,
	[R_preptime_In_minutes]	INT			NULL	 ,
	[R_cooktime_In_minutes]	INT			NULL	 ,
	[R_difficulty]	tinyint				NULL 	 ,
	[R_userID]		INT					NULL     ,
	[R_image_url]	nvarchar(2100)		NULL	 , 
	[R_date]		datetime2			NULL CONSTRAINT df_R default SysDateTime()
	CONSTRAINT pk_Recipes PRIMARY KEY(R_ID),
	CONSTRAINT fk_Recipes_UserID FOREIGN KEY(R_userID) REFERENCES [User_account](U_ID)
	ON DELETE CASCADE --sarqel cascade luchshe, no action er 
	ON UPDATE CASCADE ,
	
)
