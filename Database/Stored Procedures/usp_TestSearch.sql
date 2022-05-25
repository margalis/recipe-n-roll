CREATE PROCEDURE [dbo].[usp_TestSearch]
 @RecipeName nvarchar(20)
 AS 

 select *
 from Recipes
 where R_name like  CONCAT('%', @RecipeName ,'%')
 
 GO
