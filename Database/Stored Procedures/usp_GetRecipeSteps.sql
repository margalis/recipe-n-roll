CREATE PROCEDURE [dbo].[usp_GetRecipeSteps]
	@RecipeId int 
AS
	select s.*
	from Steps s 
	join Recipes r 
	on s.S_recipe_ID = r.R_ID
	where r.R_ID= @RecipeId

GO
