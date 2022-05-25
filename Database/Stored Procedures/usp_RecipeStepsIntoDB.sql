CREATE PROCEDURE [dbo].[usp_RecipeStepsIntoDB]
	@Stepps StepsList READONLY
AS
	
	INSERT INTO [dbo].[Steps]([S_recipe_ID],[S_number],[S_description],[S_subrecipe_ID])
	SELECT  SRecipeID, SRecipeNumber, SDescription, SSubRecipeID
	FROM @Stepps

GO


Create Type StepsList as Table(
    SRecipeID       INT	,
	SRecipeNumber	INT	,
	SDescription	nvarchar(4000),
	SSubRecipeID	INT 
)
        /* 
INSERT INTO [dbo].[Steps]([S_recipe_ID],[S_number],[S_description])
VALUES(100, 1 , N'Եռացնում ենք կաթը: Եթե ցանկանում ենք ստանալ ավելի խիտ սոուս, ապա օգտագործում ենք 1,5 բաժակ կաթ,
    իսկ ավելի նոսր սոուսի համար՝  2,5 բաժակ կաթ:
    Առանձին կաթսայի մեջ հալեցնում ենք կարագը թույլ կրակի վրա:' ),
(100, 2 , N'Ավելացնում ենք ալյուրը, աղը, սև պղպեղն ու արագ խառնում ստացված զանգվածը, որպեսզի գնդիկներ չառաջանան:
     Ի դեպ, յուղի և ալյուրի այսպիսի զանգվածը ֆրանսերեն կոչվում է "ռու" (roux):' ) ,
(100, 3 , N'Երբ զանգվածի գույնը մի փոքր մգանա,
   ավելացնում ենք 2 գդալ եռման կաթ՝ անընդհատ խառնելով սոուսը ձեռքի հարիչով:' ),
(100, 4, N'Չդադարելով խառնելը՝ քիչ-քիչ ավելացնում ենք կաթի մնացած մասը:' ),
(100, 5, N'Մշտապես խառնելով սոուսը՝ հասցնում ենք այն եռման աստիճանի, 
   ապա թույլ կրակի վրա պահում ևս 2 րոպե մինչև խտանալը:
   Հանում ենք սոուսը կրակի վրայից: THE END' )

Go       
          */