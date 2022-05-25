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
    /// Interaction logic for UsersCreatedRecipes.xaml
    /// </summary>
    public partial class UsersCreatedRecipes : Window
    {
        public UsersCreatedRecipes(User_Account ua)
        {
            InitializeComponent();
            this.DataContext = ua;
            //Functions      
            //  berum a list of Users Created Recipes 
            //  Recipenery clickable en  bacvum a amen recipe i hamar ira edgy 
            //  recipeneri  koghqic kan  Button ner (Change, petq a bacvi ChangeRecipe  window u pokhven tvyalnery),ay es chgitem vonc em anelu
            // mek el delete recipe klini , vor usery jnji ira steghtsats recipey, cascade ov pti vor jnjven sagh, ete chisht em arel

             /*
            using (SqlConnection conn = ConnectionManager.CreateConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "[dbo].[usp_CreatedRecipes]";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UserID", System.Data.SqlDbType.Int).Value = ua.UserID;
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        if (r.HasRows)
                        {
                            int ordRID = r.GetOrdinal("R_ID");
                            int ordRName = r.GetOrdinal("R_Name");
                            while (r.Read())  // mi togh a bayc de
                            {
                                RecipefromUserview rfuw = new RecipefromUserview();
                                rfuw.RecipeId = r.GetInt32(ordRID);
                                rfuw.RecipeName = r.GetString(ordRName);
                                ua.UserCreatedRecipeList.Add(rfuw);
                            }
                        }
                    }
                }

                conn.Close();     
            }  */
        }
    }
}
