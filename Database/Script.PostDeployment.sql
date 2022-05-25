/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
-------------------------------------------------------------------------------------- 
*/
 --ok 
--INSERT INTO [dbo].[Ingredient_Categories] ([IC_ID],[IC_name])
--VALUES (1,N'Կաթնամթերք'),
--       (2,N'Բանջարեղեն ու կանաչեղեն'),
--       (3,N'Մրգեղեն'),
--       (4,N'Հացահատկեղեն և խմորային մասսա, պաստա'),
--       (5,N'Ընկուզեղեն'),
--       (6,N'Համեմունքներ'),
--       (7,N'Մսեղեն և ձկնեղեն'),
--       (8,N'Ծովամթերք'),
--       (9,N'Յուղեր'),
--       (10,N'Լոխումներ'),
--       (11,N'Դեսերտային քաղցրություններ'),
--       (12,N'Քաղցրեղեն'),
--       (13,N'Հեղուկներ'),
--       (14,N'Ալկոհոլ'),
--       (15,N'Սոուսներ և մածուկներ')
-- --ok
-- go

--INSERT INTO [dbo].[Ingredients] ([I_name],[I_categID])
--VALUES (N'կաթ',1),
--       (N'աղ',6),
--       (N'պղպեղ սև',6),
--       (N'կարագ',1),
--       (N'մշկընկույզ (мускатный орех)',5),
--       (N'ալյուր',4),
--       (N'կանաչի խառը',2),
--       (N'լոլիկի մածուկ',15),
--       (N'միս տավարի(աղացած)',7),
--       (N'ձիթայուղ',9),
--       (N'պանիր պարմեզան',1),
--       (N'լազանյայի շերտեր',4),
--       (N'սոխ',2),
--       (N'լոլիկ',2),
--       (N'մեխակ',6),
--       (N'պանիր',1),
--       (N'գինի կարմիր',14),
--       (N'գազար',2),
--       (N'սխտոր',2),
--       (N'ռեհան չորացած',6)

--       go 
--INSERT INTO [dbo].[User_account]([U_FullName],[U_email],[U_password])
--VALUES (N'Սանասար Բաղդասարյան','adermansam@gmail.com','melonlord1248')  --added beshamel


--Set IDENTITY_INSERT [Recipes] on

--INSERT INTO [dbo].[Recipes]([R_ID],[R_name],[R_description],[R_preptime_In_minutes],[R_cooktime_In_minutes],[R_difficulty],[R_userID]	)
--VALUES (110,N'Սոուս Բեշամել' , N'Ֆրանսիական 4 "մայր" սոուսներից մեկն է՝ ըստ Օգյուստ Էսկոֆյեի դասակարգման:
--       Բեշամելի հիմքի վրա են պատրաստվում մի շարք սթեյքի սոուսներ, լազանյայի որոշ տեսակներ և այլ շատ համեղ ուտեստներ:',
--       10,20,1, Scope_Identity() )
       
--Set IDENTITY_INSERT [Recipes] off
--GO

--INSERT INTO [dbo].[Recipe_Ingredients]([RI_RecipeID],[RI_IngredientID],[RI_measurement_amount],[RI_measurement_type])
--SELECT  110, Ing.I_ID,50,N'գր'
--FROM Ingredients Ing where Ing.I_name=N'կարագ'

--INSERT INTO [dbo].[Recipe_Ingredients]([RI_RecipeID],[RI_IngredientID],[RI_measurement_amount],[RI_measurement_type])
--SELECT 110, Ing.I_ID,50,N'գր'
--FROM Ingredients Ing where Ing.I_name=N'ալյուր'

--INSERT INTO [dbo].[Recipe_Ingredients]([RI_RecipeID],[RI_IngredientID],[RI_measurement_amount],[RI_measurement_type])
--SELECT 110, Ing.I_ID,1.75,N'բաժակ'
--FROM Ingredients Ing where Ing.I_name=N'կաթ'

--INSERT INTO [dbo].[Recipe_Ingredients]([RI_RecipeID],[RI_IngredientID],[RI_measurement_amount],[RI_measurement_type])
--SELECT 110, Ing.I_ID,1,N'թ/գդ'
--FROM Ingredients Ing where Ing.I_name=N'աղ'

--INSERT INTO [dbo].[Recipe_Ingredients]([RI_RecipeID],[RI_IngredientID],[RI_measurement_amount],[RI_measurement_type])
--SELECT 110, Ing.I_ID,1,N'պտղունց'
--FROM Ingredients Ing where Ing.I_name=N'պղպեղ սև'


--INSERT INTO [dbo].[Steps]([S_recipe_ID],[S_number],[S_description])
--VALUES(110, 1 , N'Եռացնում ենք կաթը: Եթե ցանկանում ենք ստանալ ավելի խիտ սոուս, ապա օգտագործում ենք 1,5 բաժակ կաթ,իսկ ավելի նոսր սոուսի համար՝  2,5 բաժակ կաթ:Առանձին կաթսայի մեջ հալեցնում ենք կարագը թույլ կրակի վրա:' ),
--      (110, 2 , N'Ավելացնում ենք ալյուրը, աղը, սև պղպեղն ու արագ խառնում ստացված զանգվածը, որպեսզի գնդիկներ չառաջանան:Ի դեպ, յուղի և ալյուրի այսպիսի զանգվածը ֆրանսերեն կոչվում է "ռու" (roux):' ) ,
--      (110, 3 , N'Երբ զանգվածի գույնը մի փոքր մգանա, ավելացնում ենք 2 գդալ եռման կաթ՝ անընդհատ խառնելով սոուսը ձեռքի հարիչով:' ),
--      (110, 4, N'Չդադարելով խառնելը՝ քիչ-քիչ ավելացնում ենք կաթի մնացած մասը:' ),
--      (110, 5, N'Մշտապես խառնելով սոուսը՝ հասցնում ենք այն եռման աստիճանի,ապա թույլ կրակի վրա պահում ևս 2 րոպե մինչև խտանալը:Հանում ենք սոուսը կրակի վրայից: THE END' )

--         Go 

--go
--INSERT INTO [dbo].[User_account]([U_FullName],[U_email],[U_password])
--VALUES (N'Սիփանե Ալեքսանյան','chungachanga@gmail.com','idontknowthepassword') --added lasagne

--Set IDENTITY_INSERT [Recipes] on

--INSERT INTO [dbo].[Recipes]([R_ID],[R_name],[R_preptime_In_minutes],[R_cooktime_In_minutes],[R_difficulty],[R_userID]	)
--VALUES(111,N'Լազանյա դասական',20,30,3, Scope_Identity())

--Set IDENTITY_INSERT [Recipes] off
--go

--INSERT INTO [dbo].[Steps]([S_recipe_ID],[S_number],[S_description],[S_subrecipe_ID])
--VALUES(111, 1 , N'Պատրաստում ենք բոլոնյեզ սոուսը։ Ձիթայուղը թավայի մեջ տաքացնում ենք, 
--                             ավելացնում ենք կտրատած սոխը, տապակում ենք մինչև թափանցիկ դառնա։
--                             Ավելացնում ենք խճողակը, խառնում ենք. եթե խճողակը արդեն գույնը փոխել է,
--                             ավելացնում ենք համեմունքները, լոլիկի մածուկն ու լոլիկները և 5-10 րոպե եփում ենք։
--                             Այնուհետև մի քիչ ջուր ենք ավելացնում և ևս 5-10 րոպե եփում ենք։
--                             Սոուսը պետք է ջրիկ լինի, որպեսզի ներծծվի լազանյայի շերտերի մեջ։',NULL ),
--      (111, 3 , N'Սկսում ենք լազանյան դասավորել։ Ուղղանկյունաձև ձևամանի մեջ մի քիչ բեշամել սոուս ենք լցնում,
--                             վրան լազանյայի չոր շերտերն ենք դնում, վրան ենք լցնում բոլոնյեզ սոուսը,
--                             քերած պանիրը և կրկին բեշամել սոուսը։ Այս գործընթացը 3-4 անգամ կրկնում ենք։
--                             Վերևամասում առատորեն բեշամել սոուս ենք լցնում և քերած պանիր ցանում։',NULL ),
--      (111, 4, N'Լազանյան թխում ենք մոտ 30 րոպե` մինչև 180 աստիճան տաքացրած ջեռոցի մեջ։
--                            Պատրաստի լազանյան 15-20 րոպե սառեցնում ենք, այնուհետև կտրում ենք և մատուցում։',NULL )
    
--INSERT INTO [dbo].[Steps]([S_recipe_ID],[S_number],[S_description],[S_subrecipe_ID])
--Select  111, 2 , N'Պատրաստում ենք բեշամել սոուսը։ Կաթը տաքացնում ենք։
--                             Հաստ պատերով կաթսայի մեջ կարագը հալեցնում ենք, 
--                             ավելացնում ենք ալյուրը և անընդհատ խառնելով եփում ենք`
--                             մինչև միասեռ զանգված ստանանք։ Ավելացնում ենք կաթի կեսը,
--                             լավ խառնում ենք, ավելացնում ենք համեմունքները և եփում ենք մինչև թանձրանա։
--                             Ավելացնում ենք մնացած կաթը, կրկին խառնում ենք մինչև համասեռ դառնա։' ,R.R_ID
--FROM Recipes R
--where R.R_name=N'Սոուս Բեշամել'

--go
-- recipe_ingredients T_T

--INSERT INTO [dbo].[Recipe_Ingredients]([RI_RecipeID],[RI_IngredientID],[RI_measurement_amount],[RI_measurement_type])
--SELECT 111, Ing.I_ID,1,N'տուփ'
--FROM Ingredients Ing where Ing.I_name=N'լազանյայի շերտեր'

--INSERT INTO [dbo].[Recipe_Ingredients]([RI_RecipeID],[RI_IngredientID],[RI_measurement_amount],[RI_measurement_type])
--SELECT 111, Ing.I_ID,500,N'գր'
--FROM Ingredients Ing where Ing.I_name=N'պանիր'

--INSERT INTO [dbo].[Recipe_Ingredients]([RI_RecipeID],[RI_IngredientID],[RI_measurement_amount],[RI_measurement_type])
--SELECT 111, Ing.I_ID,800,N'գր'
--FROM Ingredients Ing where Ing.I_name=N'միս տավարի(աղացած)'

--INSERT INTO [dbo].[Recipe_Ingredients]([RI_RecipeID],[RI_IngredientID],[RI_measurement_amount],[RI_measurement_type])
--SELECT 111, Ing.I_ID,1,N'գլուխ'
--FROM Ingredients Ing where Ing.I_name=N'սոխ'

--INSERT INTO [dbo].[Recipe_Ingredients]([RI_RecipeID],[RI_IngredientID],[RI_measurement_amount],[RI_measurement_type])
--SELECT 111, Ing.I_ID,1,N'ճ/գդ'
--FROM Ingredients Ing where Ing.I_name=N'ձիթայուղ'

--INSERT INTO [dbo].[Recipe_Ingredients]([RI_RecipeID],[RI_IngredientID],[RI_measurement_amount],[RI_measurement_type])
--SELECT 111, Ing.I_ID,1,N'ճ/գդ'
--FROM Ingredients Ing where Ing.I_name=N'լոլիկի մածուկ'

--INSERT INTO [dbo].[Recipe_Ingredients]([RI_RecipeID],[RI_IngredientID],[RI_measurement_amount],[RI_measurement_type])
--SELECT 111, Ing.I_ID,2,N'հատ'
--FROM Ingredients Ing where Ing.I_name=N'լոլիկ'

--INSERT INTO [dbo].[Recipe_Ingredients]([RI_RecipeID],[RI_IngredientID],[RI_measurement_amount],[RI_measurement_type])
--SELECT 111, Ing.I_ID,NULL,N'պտղունց'
--FROM Ingredients Ing where Ing.I_name=N'մեխակ'

--INSERT INTO [dbo].[Recipe_Ingredients]([RI_RecipeID],[RI_IngredientID],[RI_measurement_amount],[RI_measurement_type])
--SELECT 111, Ing.I_ID,NULL,N'հատ'
--FROM Ingredients Ing where Ing.I_name=N'մշկընկույզ (мускатный орех)'

--INSERT INTO [dbo].[Recipe_Ingredients]([RI_RecipeID],[RI_IngredientID],[RI_measurement_amount],[RI_measurement_type])
--SELECT 111, Ing.I_ID,NULL,N'պտղունց'
--FROM Ingredients Ing where Ing.I_name=N'պղպեղ սև'

--INSERT INTO [dbo].[Recipe_Ingredients]([RI_RecipeID],[RI_IngredientID],[RI_measurement_amount],[RI_measurement_type])
--SELECT 111, Ing.I_ID,NULL,N'պտղունց'
--FROM Ingredients Ing where Ing.I_name=N'աղ'

--INSERT INTO [dbo].[Recipe_Ingredients]([RI_RecipeID],[RI_IngredientID],[RI_measurement_amount],[RI_measurement_type])
--SELECT 111, Ing.I_ID,4,N'ճ/գդ'
--FROM Ingredients Ing where Ing.I_name=N'ալյուր'

--INSERT INTO [dbo].[Recipe_Ingredients]([RI_RecipeID],[RI_IngredientID],[RI_measurement_amount],[RI_measurement_type])
--SELECT 111, Ing.I_ID,8,N'բաժակ'
--FROM Ingredients Ing where Ing.I_name=N'կաթ'

--INSERT INTO [dbo].[Recipe_Ingredients]([RI_RecipeID],[RI_IngredientID],[RI_measurement_amount],[RI_measurement_type])
--SELECT 111, Ing.I_ID,100,N'գ'
--FROM Ingredients Ing where Ing.I_name=N'կարագ'




-- ////////////////////////////////////////// testing for search

--INSERT INTO [dbo].[User_account]([U_FullName],[U_email],[U_password])
--VALUES (N'Սաթենիկ Գևորգյան','sanasarsar@gmail.com','gomentsukki')  --added beshamel


--Set IDENTITY_INSERT [Recipes] on

--INSERT INTO [dbo].[Recipes]([R_ID],[R_name],[R_description],[R_preptime_In_minutes],[R_cooktime_In_minutes],[R_difficulty],[R_userID]	)
--VALUES (112,N'Բեշամել' , N'Ֆրանսիական սոուս',
--       10,20,1, Scope_Identity() )
       
--Set IDENTITY_INSERT [Recipes] off
--GO

--INSERT INTO [dbo].[Recipe_Ingredients]([RI_RecipeID],[RI_IngredientID],[RI_measurement_amount],[RI_measurement_type])
--SELECT  112, Ing.I_ID,50,N'գր'
--FROM Ingredients Ing where Ing.I_name=N'կարագ'

--INSERT INTO [dbo].[Recipe_Ingredients]([RI_RecipeID],[RI_IngredientID],[RI_measurement_amount],[RI_measurement_type])
--SELECT 112, Ing.I_ID,50,N'գր'
--FROM Ingredients Ing where Ing.I_name=N'ալյուր'

--INSERT INTO [dbo].[Recipe_Ingredients]([RI_RecipeID],[RI_IngredientID],[RI_measurement_amount],[RI_measurement_type])
--SELECT 112, Ing.I_ID,1.75,N'բաժակ'
--FROM Ingredients Ing where Ing.I_name=N'կաթ'

--INSERT INTO [dbo].[Recipe_Ingredients]([RI_RecipeID],[RI_IngredientID],[RI_measurement_amount],[RI_measurement_type])
--SELECT 112, Ing.I_ID,1,N'թ/գդ'
--FROM Ingredients Ing where Ing.I_name=N'աղ'



--INSERT INTO [dbo].[Steps]([S_recipe_ID],[S_number],[S_description])
--VALUES(112, 1 , N'Եռացնում ենք կաթը: Եթե ցանկանում ենք ստանալ ավելի խիտ սոուս, ապա օգտագործում ենք 1,5 բաժակ կաթ,իսկ ավելի նոսր սոուսի համար՝  2,5 բաժակ կաթ:Առանձին կաթսայի մեջ հալեցնում ենք կարագը թույլ կրակի վրա:' ),
--      (112, 2 , N'Ավելացնում ենք ալյուրը, աղը, սև պղպեղն ու արագ խառնում ստացված զանգվածը, որպեսզի գնդիկներ չառաջանան:Ի դեպ, յուղի և ալյուրի այսպիսի զանգվածը ֆրանսերեն կոչվում է "ռու" (roux):' ) ,
--      (112, 3 , N'Երբ զանգվածի գույնը մի փոքր մգանա, ավելացնում ենք 2 գդալ եռման կաթ՝ անընդհատ խառնելով սոուսը ձեռքի հարիչով:' ),
--      (112, 4, N'Չդադարելով խառնելը՝ քիչ-քիչ ավելացնում ենք կաթի մնացած մասը:' ),
--      (112, 5, N'Մշտապես խառնելով սոուսը՝ հասցնում ենք այն եռման աստիճանի,ապա թույլ կրակի վրա պահում ևս 2 րոպե մինչև խտանալը:Հանում ենք սոուսը կրակի վրայից: THE END' )

--         Go       

--INSERT INTO [dbo].[Ingredients] ([I_name],[I_categID])
--VALUES (N'շոկոլադ',12),
--       (N'բրինձ',4)
      