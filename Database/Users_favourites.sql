CREATE TABLE [dbo].[Users_favourites]
(
	[UF_Users_ID]		INT			NOT NULL ,
	[UF_Recipes_ID]	    INT			NOT NULL ,
	[UF_Add_date]		datetime2	NOT NULL CONSTRAINT df_UFDate default SysDateTime(), 
	CONSTRAINT fk_Usfav_UsID FOREIGN KEY(UF_Users_ID) REFERENCES [User_account](U_ID),
	CONSTRAINT fk_Usfav_RecID FOREIGN KEY(UF_Recipes_ID) REFERENCES [Recipes](R_ID)
	ON DELETE CASCADE 
	ON UPDATE CASCADE ,
	CONSTRAINT pk_Usfav PRIMARY KEY(UF_Users_ID,UF_Recipes_ID) 
)
