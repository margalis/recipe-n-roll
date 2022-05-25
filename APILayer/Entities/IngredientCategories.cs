using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
    class IngredientCategories
    {
        // es pahery durs ekav tsragric , vorovhetev chem hascnum , sa search y barelavelu hamar a irakanm :(
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public int CategoryIcon { get; set; }
        
        public List<Ingredients> CategoryIngredients { get; set;  }
    }
}
