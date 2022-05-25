using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APILayer.Models
{
    public class IngredientCategoriesDTO
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public int CategoryIcon { get; set; }

        public List<IngredientsDTO> CategoryIngredients { get; set; }
    }
}
