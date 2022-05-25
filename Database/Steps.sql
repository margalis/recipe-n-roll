CREATE TABLE [dbo].[Steps]
(
	[S_recipe_ID]		INT				NOT NULL,
	[S_number]			INT				NOT NULL,
	[S_description]		nvarchar(4000)	NOT NULL,
	[S_subrecipe_ID]	INT 			NULL 
	CONSTRAINT pk_Steps PRIMARY KEY(S_recipe_ID,S_number),
	CONSTRAINT fk_Steps_RecipeID FOREIGN KEY(S_recipe_ID) REFERENCES [Recipes](R_ID)
	ON DELETE CASCADE 
	ON UPDATE CASCADE ,
	CONSTRAINT fk_Steps_SubRecID FOREIGN KEY(S_subrecipe_ID) REFERENCES [Recipes](R_ID)
	ON DELETE NO ACTION
	ON UPDATE NO ACTION,
	CONSTRAINT ch_StepsNum CHECK(S_number>0 and S_number <=105),


)
