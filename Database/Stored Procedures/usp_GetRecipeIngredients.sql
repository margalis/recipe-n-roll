CREATE PROCEDURE [dbo].[usp_GetRecipeIngredients]
	@RecipeID int
AS
	select RI_IngredientID, Ingredients.I_name ,RI_measurement_amount, RI_measurement_type
	from Recipe_Ingredients
	left join Ingredients on Ingredients.I_ID= Recipe_Ingredients.RI_IngredientID
where RI_RecipeID= @RecipeID

GO