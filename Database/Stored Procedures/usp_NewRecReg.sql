CREATE PROCEDURE [dbo].[usp_NewRecReg]
	@RecipeName  nvarchar(20),
	@RecipeDescription nvarchar(600),
	@RecipePrepTime int ,
	@RecipeCookTime int ,
	@RecipeDifficulty tinyint, 
	@RecipeUserID int ,
	@RecipeID int out
AS

INSERT INTO [dbo].[Recipes]([R_name],[R_description],[R_preptime_In_minutes],[R_cooktime_In_minutes],[R_difficulty],[R_userID])
VALUES(@RecipeName,@RecipeDescription,@RecipePrepTime,@RecipeCookTime,@RecipeDifficulty,@RecipeUserID)
-- hly vor without images 

SET @RecipeID= SCOPE_IDENTITY()

GO
