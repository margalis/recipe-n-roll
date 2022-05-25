using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Entities;

namespace DataAccess
{
    public interface IRecipesAndIngrRepository
    {
        public Recipes GetRecipeInfo(int ID);
        public IEnumerable<Ingredients> GetIngredients();

        public List<RecipeIDName> GetRecipeNamesSimilarTo(string recipeName);

        public List<RecipeIDName> GetRecipeNamesnIDviaIngredients(List<String> ingredientNames);
    }

}
