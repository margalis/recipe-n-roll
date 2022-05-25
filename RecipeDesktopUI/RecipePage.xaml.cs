using DataAccess;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RecipeDesktopUI
{
    /// <summary>
    /// Interaction logic for RecipePage.xaml
    /// </summary>
    public partial class RecipePage : Window
    {
        Recipes recipe = new Recipes();
        private RecipesAndIngrRepository rireop = new RecipesAndIngrRepository();
        public RecipePage(int id)  //  Recipe Id  ov 
        {
            InitializeComponent();
            recipe.RecipeID = id;
            this.DataContext = recipe;
            
            rireop.GetRecipeInfo(recipe);
            StepsList.ItemsSource = recipe.RecipeSteps;
            IngredientsMMList.ItemsSource = recipe.RecipeIngredients;
          
            // some listview  for ingredients 
            //RecipeIngredients.DataContext = rireop.GetIngredientsofRecipe(recipe);
            //RecipeIngredients.ItemSource = rireop.GetIngredientsofRecipe(recipe);
            #region  commentsandstuff 
            /*     
             using (SqlConnection conn = ConnectionManager.CreateConnection())
             {
                 conn.Open();
                 // arandzin function a sa 
                 using (SqlCommand cmd = new SqlCommand())
                 {
                     cmd.Connection = conn;
                     cmd.CommandText = "[dbo].[usp_GetRecipeInfo]";
                     cmd.CommandType = System.Data.CommandType.StoredProcedure;

                     cmd.Parameters.Add("@RecipeID", System.Data.SqlDbType.Int).Value = id;
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
                 }   }  */
            //sa el arandzin function

            /*
            List<Steps> stepsList = new List<Steps>(); // sa kareli a miangamic tvyal recipe i mej list sarqel
                                                           // u iran tal new List<Steps> ,zut es C# ic kakhum em
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
                StepsList.DataContext = stepsList;
                StepsList.ItemsSource = stepsList;
                conn.Close();
                  */
            /*
            using (SqlConnection conn = ConnectionManager.CreateConnection())
            {
                conn.Open();
                List<Recipe_Ingredients> RI = new List<Recipe_Ingredients>();
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

                            while (r.Read())  // mi togh a bayc de
                            {
                                var recipeIngredient = new Recipe_Ingredients
                                {
                                    RecipeIngredientName = r.GetString(ordIngName),
                                    IngrID = r.GetInt32(ordIngID),
                                    MeasurementType = r.GetString(ordMsType),
                                    MeasurementAmount = r.IsDBNull(ordMsAm) ? 0 : r.GetInt32(ordMsAm)
                                };
                                RI.Add(recipeIngredient);
                                //sarqel listview ev tal datacontexty :D 
                            }
                        }
                    }

                }
            }  */
            #endregion
        }
        private void AddToFavourites_Click(object sender, RoutedEventArgs e)
        {
            //doin some work up here 
            MessageBox.Show($"you succesfully added this recipe to your Favourites list");


        }
    }
}
