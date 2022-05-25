using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APILayer.Models
{
    public class StepsDTO
    { 
        public int SRecipeID { get; set; }
        public int StepNumber { get; set; }
        public string StepDescription { get; set; }
        public int? StepsSubRecipesID { get; set; }
    }
}
