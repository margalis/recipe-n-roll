using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APILayer.Models
{
    public class IngredientsOfRecipeDTO
    {
        public int IngrID { get; set; }
        public string RecipeIngredientName { get; set; }
        public string MeasurementType { get; set; }
        public Decimal MeasurementAmount { get; set; }
    }
}
