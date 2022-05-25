CREATE PROCEDURE [dbo].[usp_IngredientsTestSearch]
	@IngredientNames IngrNames READONLY

AS
	select R_ID,R_name
	from Recipes
	join (
	select RI_RecipeID
	from Recipe_Ingredients
	join (select I_ID 
	from Ingredients
	CROSS APPLY (SELECT * FROM @IngredientNames)AS C
	WHERE Ingredients.I_name=C.IngName) as A
	on Recipe_Ingredients.RI_IngredientID= A.I_ID
	group by RI_RecipeID
	) as B
	on Recipes.R_ID=B.RI_RecipeID

GO

Create Type IngrNames as Table(
    IngName  nvarchar(50)
)
GO
/* 

select R_ID,R_Name
from Recipes
join (
select RI_RecipeID
from Recipe_Ingredients
join (select I_ID 
from IngredientNames
join Ingredients on Ing_name=Ingredients.I_name) as A
on Recipe_Ingredients.RI_IngredientID= A.I_ID
group by RI_RecipeID
) as B
on Recipes.R_ID=B.RI_RecipeID

*/