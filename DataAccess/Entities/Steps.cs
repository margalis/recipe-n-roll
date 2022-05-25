using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
    public class Steps
    {
        public int SRecipeID { get; set; }
        public int StepNumber { get; set; }
        public string StepDescription { get; set; }
        public  int? StepsSubRecipesID { get; set; } // sa anmshak a derevs chgitem nullable
     
    }
}
