CREATE TABLE [dbo].[Recipe_Ingredients]
(
	[RI_RecipeID]				INT				NOT NULL, 
	[RI_IngredientID]			INT				NOT NULL,
	[RI_measurement_amount]		smallmoney		NULL,
	[RI_measurement_type]		nvarchar(10)	NOT NULL

	CONSTRAINT fk_Recipes_RIID FOREIGN KEY(RI_RecipeID) REFERENCES [Recipes](R_ID)
	ON DELETE CASCADE 
	ON UPDATE CASCADE ,
	CONSTRAINT fk_Ingredients_RIID FOREIGN KEY(RI_IngredientID) REFERENCES [Ingredients](I_ID)
	ON DELETE CASCADE 
	ON UPDATE CASCADE ,
	CONSTRAINT un_RI PRIMARY KEY(RI_RecipeID,RI_IngredientID)
)
