CREATE PROCEDURE [dbo].[usp_RecipeIngredientsIntoDB]
	@IngredientInfo RecipeIngredients READONLY
AS
	
	INSERT INTO [dbo].[Recipe_Ingredients]([RI_RecipeID],[RI_IngredientID],[RI_measurement_amount],[RI_measurement_type])
	SELECT  RecipeID, IngrID , MeasurementAmount, MeasurementType
	FROM @IngredientInfo

GO


Create Type RecipeIngredients as Table(
    IngrID             INT	,
	RecipeID           INT	,
	MeasurementType	   nvarchar(4000),
	MeasurementAmount  smallmoney
)


/* 
public int IngrID { get; set; }
        public int RecipeID { get; set; } 
        public string MeasurementType { get; set; }
        public Decimal MeasurementAmount { get; set; }

*/

 /*
            INSERT INTO [dbo].[Recipe_Ingredients]([RI_RecipeID],[RI_IngredientID],[RI_measurement_amount],[RI_measurement_type])
            SELECT  100, Ing.I_ID,50,N'գր'
            FROM Ingredients Ing where Ing.I_name=N'կարագ'

            INSERT INTO [dbo].[Recipe_Ingredients]([RI_RecipeID],[RI_IngredientID],[RI_measurement_amount],[RI_measurement_type])
            SELECT 100, Ing.I_ID,50,N'գր'
            FROM Ingredients Ing where Ing.I_name=N'ալյուր'

            INSERT INTO [dbo].[Recipe_Ingredients]([RI_RecipeID],[RI_IngredientID],[RI_measurement_amount],[RI_measurement_type])
            SELECT 100, Ing.I_ID,1.75,N'բաժակ'
            FROM Ingredients Ing where Ing.I_name=N'կաթ'

            INSERT INTO [dbo].[Recipe_Ingredients]([RI_RecipeID],[RI_IngredientID],[RI_measurement_amount],[RI_measurement_type])
            SELECT 100, Ing.I_ID,1,N'թ/գդ'
            FROM Ingredients Ing where Ing.I_name=N'աղ'

            INSERT INTO [dbo].[Recipe_Ingredients]([RI_RecipeID],[RI_IngredientID],[RI_measurement_amount],[RI_measurement_type])
            SELECT 100, Ing.I_ID,1,N'պտղունց'
            FROM Ingredients Ing where Ing.I_name=N'պղպեղ սև'

            Set IDENTITY_INSERT [Recipes] off   
            }
            */           