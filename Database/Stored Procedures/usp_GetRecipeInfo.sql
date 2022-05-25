CREATE PROCEDURE [dbo].[usp_GetRecipeInfo]
	@RecipeID int 
AS

	SELECT *
	from Recipes 
	where R_ID= @RecipeID

GO
