using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
    public class Recipes
    {
		public int RecipeID { get; set; }
		public string RecipeName { get; set; } 
		public string RecipeDescription { get; set; }
		public int RecipePrepTime { get; set; }
		public int RecipeCookTime { get; set; }
		public int RecipeDificulty { get; set; }
		public int RecipeUserID { get; set; }
		public string RecipeImage_Url { get; set; }
		public DateTime RecipeCDate { get; set; }


		public List<Steps> RecipeSteps { get; set; }  
		// I dont know what to do with these 
		public List<IngredientsOfRecipe> RecipeIngredients { get; set; }  //  :(

        public Recipes()
        {

        }
		public Recipes(int ID)
        {
			this.RecipeID = ID;
        }
        
    }
}
