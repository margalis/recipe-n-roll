using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APILayer.Models
{
    public class RecipesDTO
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


		public List<StepsDTO> RecipeSteps { get; set; }
		// I dont know what to do with these 
		public List<IngredientsOfRecipeDTO> RecipeIngredients { get; set; }  //  :(

		public RecipesDTO()
		{

		}
		public RecipesDTO(int ID)
		{
			this.RecipeID = ID;
		}

	}
}
