CREATE TABLE [dbo].[Ingredients]
(
	[I_ID]			 INT			NOT NULL  IDENTITY (2000,1), 
	[I_name]		 nvarchar(50)	NOT NULL,
	[I_categID]		 INT			NOT NULL

	CONSTRAINT pk_Ingredients  PRIMARY KEY(I_ID),
	CONSTRAINT fk_Ingr_CategID FOREIGN KEY(I_categID) REFERENCES [Ingredient_Categories](IC_ID)
	ON DELETE NO ACTION
	ON UPDATE CASCADE ,
	CONSTRAINT un_Ingredients UNIQUE(I_name)

	--indexner arje grel ?
	--idea hetoyi hamar , ingredientneri description el lini ,bayc et heto ,qanzi 
	--kardaci vor lasagniayi hamar  bahar a petq u es chgitei ed vorn a :DDD
)
