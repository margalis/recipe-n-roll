using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
    public class Recipe_Ingredients
    {
        //CreateRecipe i u Searchi jamanak a ogtagortsvum 
        public int IngrID { get; set; }
        public int RecipeID { get; set; } 
        public string MeasurementType { get; set; }
        public Decimal MeasurementAmount { get; set; }
    }
}
