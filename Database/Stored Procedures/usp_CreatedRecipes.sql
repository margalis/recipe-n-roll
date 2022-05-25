CREATE PROCEDURE [dbo].[usp_CreatedRecipes]
	@UserID int
AS
	SELECT R_ID, R_name
	FROM Recipes 
	where R_userID = @UserID

GO
