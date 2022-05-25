using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
    public  class IngredientsOfRecipe
    {
      
        public int IngrID { get; set;  }
        public string RecipeIngredientName { get; set; } 
        public string MeasurementType { get; set; }
        public Decimal MeasurementAmount { get; set; }
    }
}
