using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DataAccess
{
    public class RecipesAndIngrRepository : IRecipesAndIngrRepository
    {
        //Recipe page 
        public void GetRecipeInfo(Recipes recipe)
        {
            using (SqlConnection conn = ConnectionManager.CreateConnection())
            {
                conn.Open();
                // arandzin function a sa 
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "[dbo].[usp_GetRecipeInfo]";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RecipeID", System.Data.SqlDbType.Int).Value = recipe.RecipeID;
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        if (r.HasRows)
                        {
                            int ordRN = r.GetOrdinal("R_name");
                            int ordDsc = r.GetOrdinal("R_description");
                            int ordPrT = r.GetOrdinal("R_preptime_In_minutes");
                            int ordCkT = r.GetOrdinal("R_cooktime_In_minutes");
                            int ordDfclty = r.GetOrdinal("R_difficulty");
                            int ordUID = r.GetOrdinal("R_userID");
                            int ordImg = r.GetOrdinal("R_image_url");
                            int ordDT = r.GetOrdinal("R_date");
                            while (r.Read())  // mi togh a bayc de
                            {

                                recipe.RecipeName = r.GetString(ordRN);
                                recipe.RecipeDescription = r.IsDBNull(ordDsc) ? string.Empty : r.GetString(ordDsc);
                                recipe.RecipePrepTime = r.IsDBNull(ordPrT) ? 0 : r.GetInt32(ordPrT);
                                recipe.RecipeCookTime = r.IsDBNull(ordCkT) ? 0 : r.GetInt32(ordCkT);
                                recipe.RecipeDificulty = r.IsDBNull(ordDfclty) ? 0 : r.GetByte(ordDfclty);
                                recipe.RecipeUserID = r.IsDBNull(ordUID) ? 0 : r.GetInt32(ordUID);
                                recipe.RecipeImage_Url = r.IsDBNull(ordImg) ? string.Empty : r.GetString(ordImg);
                                recipe.RecipeCDate = r.IsDBNull(ordDT) ? DateTime.MinValue : r.GetDateTime(ordDT);

                            }
                        }
                    }
                }
              
            } 
            //Steps
            List<Steps> stepsList = new List<Steps>(); 
            //esi mi connectionov  aveli chisht a che erevi ? 

            using (SqlConnection conn = ConnectionManager.CreateConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "[dbo].[usp_GetRecipeSteps]";  // mi hat generacnel es 
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    int currentRID = recipe.RecipeID;
                    cmd.Parameters.Add("@RecipeID", System.Data.SqlDbType.Int).Value = currentRID;
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        if (r.HasRows)
                        {
                            int ordSNumber = r.GetOrdinal("S_number");
                            int ordSDesc = r.GetOrdinal("S_description");
                            int ordsbRID = r.GetOrdinal("S_subrecipe_ID"); // nullable

                            while (r.Read())  // mi togh a bayc de
                            {
                                var step = new Steps
                                {
                                    SRecipeID = currentRID,
                                    StepNumber = r.GetInt32(ordSNumber),
                                    StepDescription = r.GetString(ordSDesc),
                                    StepsSubRecipesID = r.IsDBNull(ordsbRID) ? 0 : r.GetInt32(ordsbRID)
                                };
                                stepsList.Add(step);

                            }
                        }
                    }
                }
             recipe.RecipeSteps = stepsList;
            }
            
            List<IngredientsOfRecipe> RI = new List<IngredientsOfRecipe>();
            using (SqlConnection conn = ConnectionManager.CreateConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "[dbo].[usp_GetRecipeIngredients]";  // mi hat generacnel es 
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    int currentRID = recipe.RecipeID;
                    cmd.Parameters.Add("@RecipeID", System.Data.SqlDbType.Int).Value = currentRID;
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        if (r.HasRows)
                        { // RI_IngredientID, Ingredients.I_name ,RI_measurement_amount, RI_measurement_type
                            int ordIngID = r.GetOrdinal("RI_IngredientID");
                            int ordIngName = r.GetOrdinal("I_name");
                            int ordMsAm = r.GetOrdinal("RI_measurement_amount");
                            int ordMsType = r.GetOrdinal("RI_measurement_type");

                            while (r.Read())
                            {
                                var recipeIngredient = new IngredientsOfRecipe
                                {
                                    RecipeIngredientName = r.GetString(ordIngName),
                                    IngrID = r.GetInt32(ordIngID),
                                    MeasurementType = r.GetString(ordMsType),
                                    MeasurementAmount = r.IsDBNull(ordMsAm) ? 0 : r.GetDecimal(ordMsAm)
                                };
                                RI.Add(recipeIngredient);
                            }
                        }
                    }

                }
                recipe.RecipeIngredients = RI;
            }
        }
 
        // Search and Stuff 
        public IEnumerable<Ingredients> GetIngredients()
        {     
            List<Ingredients> ingredientslist = new List<Ingredients>();

            using (SqlConnection conn = ConnectionManager.CreateConnection())
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "[dbo].[usp_GetIngredients]";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        if (r.HasRows)
                        {
                            int ordIID = r.GetOrdinal("I_ID");
                            int ordIName = r.GetOrdinal("I_name");
                            int ordICategoryName = r.GetOrdinal("IC_name");
                            int ordICategoryIcon = r.GetOrdinal("IC_icon"); 
                            while (r.Read())  
                            {
                                var ingredientsList = new Ingredients
                                {
                                    //  public int IngredientID { get; set; }
                                    // public string IngredientName { get; set; }
                                    // public int IngredientCategory { get; set; }

                                    IngredientID = r.GetInt32(ordIID),
                                    IngredientName = r.GetString(ordIName),
                                    IngredientCategory= r.GetString(ordICategoryName)
                                    //maybe id veradardznely aveli tuyn liner
                                };
                                ingredientslist.Add(ingredientsList);
                                //listviewin tal en inch menq enq uzum 
                            }
                        }

                    }

                }
            }
            return ingredientslist;
        }

        public void GetRecipeNamesSimilarTo(List<RecipeIDName> recipelist, string recipeName)
        {
          
            using (SqlConnection conn = ConnectionManager.CreateConnection())
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "[dbo].[usp_TestSearch]";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RecipeName", System.Data.SqlDbType.NVarChar).Value = recipeName;
                    // searchy  hly mtatsel 
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        
                        if (r.HasRows)
                        {
                           
                            int ordRID = r.GetOrdinal("R_ID");
                            int ordRName = r.GetOrdinal("R_name");

                            while (r.Read())  // mi togh a bayc de
                            {
                                var recipenamepair = new RecipeIDName
                                {
                                    RecipeId = r.GetInt32(ordRID),
                                    RecipeName = r.GetString(ordRName),

                                };
                                recipelist.Add(recipenamepair);

                                //listviewin tal en inch menq enq uzum 
                            }
                        }
                        else
                        {
                           
                        }

                    }

                }
            }
        }

        public void GetRecipeNamesnIDviaIngredients(List<String> ingredientNames, List<RecipeIDName> recipelist)
        {
            using (SqlConnection conn = ConnectionManager.CreateConnection())
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "[dbo].[usp_IngredientsTestSearch]";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.Add("@IngredientNames", System.Data.SqlDbType.Structured).Value = ingredientNames.ListToDataTable(); // ConnectionManager.ListToDataTable<String>(ingredientNames); // chgitem ed functiony inchu togheci connection managerum :)
                                                                                                                                                                 //  searchy  hly mtatsel 
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        if (r.HasRows)
                        {
                            int ordRID = r.GetOrdinal("R_ID");
                            int ordRName = r.GetOrdinal("R_name");

                            while (r.Read())  // mi togh a bayc de
                            {
                                var recipenamepair = new RecipeIDName
                                {
                                    RecipeId = r.GetInt32(ordRID),
                                    RecipeName = r.GetString(ordRName),

                                };
                                recipelist.Add(recipenamepair);
                                //   listviewin tal en inch menq enq uzum 
                            }
                        }
                        else { }

                    }
                }
            }
        }

        //Creating Recipe, Input functions
        //TRANSACTION SCOPE i pahy :/
        public void CreateRecipePart1Recipe(Recipes r)
        {  // karogha ban petq lini veradarznel
            using (SqlConnection conn = ConnectionManager.CreateConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "[dbo].[usp_NewRecReg]";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RecipeName", System.Data.SqlDbType.NVarChar).Value = r.RecipeName;
                    cmd.Parameters.Add("@RecipeDescription", System.Data.SqlDbType.NVarChar).Value = r.RecipeDescription;
                    cmd.Parameters.Add("@RecipePrepTime", System.Data.SqlDbType.Int).Value = r.RecipePrepTime;
                    cmd.Parameters.Add("@RecipeCookTime", System.Data.SqlDbType.Int).Value = r.RecipeCookTime;
                    cmd.Parameters.Add("@RecipeDifficulty", System.Data.SqlDbType.TinyInt).Value = r.RecipeDificulty;
                    cmd.Parameters.Add("@RecipeUserID", System.Data.SqlDbType.Int).Value = r.RecipeUserID;
                    //cmd.Parameters.Add("@RecipeID", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add("@RecipeID", System.Data.SqlDbType.Int);
                    cmd.Parameters["@RecipeID"].Direction = System.Data.ParameterDirection.Output;
                    cmd.ExecuteNonQuery();

                    //int recipeid;
                    r.RecipeID = Convert.ToInt32(cmd.Parameters["@RecipeID"].Value);
                   // r.RecipeID = recipeid;

                }
            }
        }
        // senc arandzin en qanzi yski post deploymenti jamanak hkaraci miangamic edqan infon qcem baza :( 
        public void CreateRecipePart2Steps(List<Steps> addedsteps)
        {
            DataTable dt = new DataTable();
            // dt = ConnectionManager.ListToDataTable<Steps>(addedsteps);
            dt = addedsteps.ListToDataTable();
            using (SqlConnection conn = ConnectionManager.CreateConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "[dbo].[usp_RecipeStepsIntoDB]";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Stepps", System.Data.SqlDbType.Structured).Value = dt; 
                    cmd.ExecuteNonQuery();
                }

            }

        }
        public void CreateRecipePart3Ingredients(List<Recipe_Ingredients> addedingredients)
        {
            DataTable dt = new DataTable();
            //dt = ConnectionManager.ListToDataTable<Recipe_Ingredients>(addedingredients);
            dt = addedingredients.ListToDataTable();
            using (SqlConnection conn = ConnectionManager.CreateConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "[dbo].[usp_RecipeIngredientsIntoDB]";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.Add("@IngredientInfo", System.Data.SqlDbType.Structured).Value = dt;
                    cmd.ExecuteNonQuery();
                }

            }

        }
       
        
        //FOR API LAYER ,CAUSE DESKTOPI HAMAR BARDAK EN INCHQAN HASKACA :)
        public IEnumerable<Recipes> GetUsersRecipes()
        {
            List<Recipes> allRecipes = new List<Recipes>();


            return allRecipes;
        }
        
      
        public Recipes GetRecipeInfo(int ID)
        {
            Recipes recipe = new Recipes(ID);
        
            using (SqlConnection conn = ConnectionManager.CreateConnection())
            {
                conn.Open();
                // arandzin function a sa 
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "[dbo].[usp_GetRecipeInfo]";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RecipeID", System.Data.SqlDbType.Int).Value = recipe.RecipeID;
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        if (r.HasRows)
                        {
                            int ordRN = r.GetOrdinal("R_name");
                            int ordDsc = r.GetOrdinal("R_description");
                            int ordPrT = r.GetOrdinal("R_preptime_In_minutes");
                            int ordCkT = r.GetOrdinal("R_cooktime_In_minutes");
                            int ordDfclty = r.GetOrdinal("R_difficulty");
                            int ordUID = r.GetOrdinal("R_userID");
                            int ordImg = r.GetOrdinal("R_image_url");
                            int ordDT = r.GetOrdinal("R_date");
                            while (r.Read())  
                            {

                                recipe.RecipeName = r.GetString(ordRN);
                                recipe.RecipeDescription = r.IsDBNull(ordDsc) ? string.Empty : r.GetString(ordDsc);
                                recipe.RecipePrepTime = r.IsDBNull(ordPrT) ? 0 : r.GetInt32(ordPrT);
                                recipe.RecipeCookTime = r.IsDBNull(ordCkT) ? 0 : r.GetInt32(ordCkT);
                                recipe.RecipeDificulty = r.IsDBNull(ordDfclty) ? 0 : r.GetByte(ordDfclty);
                                recipe.RecipeUserID = r.IsDBNull(ordUID) ? 0 : r.GetInt32(ordUID);
                                recipe.RecipeImage_Url = r.IsDBNull(ordImg) ? string.Empty : r.GetString(ordImg);
                                recipe.RecipeCDate = r.IsDBNull(ordDT) ? DateTime.MinValue : r.GetDateTime(ordDT);

                            }
                        }
                    }
                }

            }
            //Steps
            List<Steps> stepsList = new List<Steps>();
            //esi mi connectionov  aveli chisht a che erevi ? 

            using (SqlConnection conn = ConnectionManager.CreateConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "[dbo].[usp_GetRecipeSteps]";  // mi hat generacnel es 
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@RecipeID", System.Data.SqlDbType.Int).Value = recipe.RecipeID;
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        if (r.HasRows)
                        {
                            int ordSNumber = r.GetOrdinal("S_number");
                            int ordSDesc = r.GetOrdinal("S_description");
                            int ordsbRID = r.GetOrdinal("S_subrecipe_ID"); // nullable

                            while (r.Read())  // mi togh a bayc de
                            {
                                var step = new Steps
                                {
                                    SRecipeID = recipe.RecipeID,
                                    StepNumber = r.GetInt32(ordSNumber),
                                    StepDescription = r.GetString(ordSDesc),
                                    StepsSubRecipesID = r.IsDBNull(ordsbRID) ? 0 : r.GetInt32(ordsbRID)
                                };
                                stepsList.Add(step);

                            }
                        }
                    }
                }
                recipe.RecipeSteps = stepsList;
            }

            List<IngredientsOfRecipe> RI = new List<IngredientsOfRecipe>();
            using (SqlConnection conn = ConnectionManager.CreateConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "[dbo].[usp_GetRecipeIngredients]";  // mi hat generacnel es 
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@RecipeID", System.Data.SqlDbType.Int).Value = recipe.RecipeID;
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        if (r.HasRows)
                        { // RI_IngredientID, Ingredients.I_name ,RI_measurement_amount, RI_measurement_type
                            int ordIngID = r.GetOrdinal("RI_IngredientID");
                            int ordIngName = r.GetOrdinal("I_name");
                            int ordMsAm = r.GetOrdinal("RI_measurement_amount");
                            int ordMsType = r.GetOrdinal("RI_measurement_type");

                            while (r.Read())
                            {
                                var recipeIngredient = new IngredientsOfRecipe
                                {
                                    RecipeIngredientName = r.GetString(ordIngName),
                                    IngrID = r.GetInt32(ordIngID),
                                    MeasurementType = r.GetString(ordMsType),
                                    MeasurementAmount = r.IsDBNull(ordMsAm) ? 0 : r.GetDecimal(ordMsAm)
                                };
                                RI.Add(recipeIngredient);
                            }
                        }
                    }

                }
                recipe.RecipeIngredients = RI;
            }

            return recipe;
        }
        public List<RecipeIDName>  GetRecipeNamesSimilarTo(string recipeName)
        {
            List<RecipeIDName> recipelist = new List<RecipeIDName>();
            using (SqlConnection conn = ConnectionManager.CreateConnection())
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "[dbo].[usp_TestSearch]";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RecipeName", System.Data.SqlDbType.NVarChar).Value = recipeName;
                    // searchy  hly mtatsel 
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {

                        if (r.HasRows)
                        {

                            int ordRID = r.GetOrdinal("R_ID");
                            int ordRName = r.GetOrdinal("R_name");

                            while (r.Read())  // mi togh a bayc de
                            {
                                var recipenamepair = new RecipeIDName
                                {
                                    RecipeId = r.GetInt32(ordRID),
                                    RecipeName = r.GetString(ordRName),

                                };
                                recipelist.Add(recipenamepair);

                                //listviewin tal en inch menq enq uzum 
                            }
                        }
                        else
                        {

                        }

                    }

                }
                return recipelist;
            } 
        }

        public List<RecipeIDName> GetRecipeNamesnIDviaIngredients(List<String> ingredientNames)
        {
            List<RecipeIDName> recipelist = new List<RecipeIDName>();
            using (SqlConnection conn = ConnectionManager.CreateConnection())
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "[dbo].[usp_IngredientsTestSearch]";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.Add("@IngredientNames", System.Data.SqlDbType.Structured).Value = ingredientNames.ListToDataTable(); // ConnectionManager.ListToDataTable<String>(ingredientNames); // chgitem ed functiony inchu togheci connection managerum :)
                                                                                                                                        //  searchy  hly mtatsel 
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        if (r.HasRows)
                        {
                            int ordRID = r.GetOrdinal("R_ID");
                            int ordRName = r.GetOrdinal("R_name");

                            while (r.Read())  // mi togh a bayc de
                            {
                                var recipenamepair = new RecipeIDName
                                {
                                    RecipeId = r.GetInt32(ordRID),
                                    RecipeName = r.GetString(ordRName),

                                };
                                recipelist.Add(recipenamepair);
                                //   listviewin tal en inch menq enq uzum 
                            }
                        }
                        else { }

                    }
                }
            } return recipelist;
        }
    }
}