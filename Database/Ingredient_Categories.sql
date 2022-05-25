CREATE TABLE [dbo].[Ingredient_Categories]
(	
	[IC_ID]		INT				NOT NULL,
	[IC_name]	nvarchar(50)	NOT NULL,
	[IC_icon]	nvarchar(2100)	NULL  
	CONSTRAINT pk_IC PRIMARY KEY(IC_ID)
)
