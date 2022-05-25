CREATE PROCEDURE [dbo].[usp_GetIngredients]
AS

select I.*, IC.IC_name, IC.IC_icon
from Ingredients I
join Ingredient_Categories IC on I.I_categID= IC.IC_ID

GO
