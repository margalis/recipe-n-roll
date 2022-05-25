using DataAccess;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace RecipeDesktopUI
{
    /// <summary>
    /// Interaction logic for CreateRecipe.xaml
    /// </summary>
    public partial class CreateRecipe : Window
    {
        Recipes r = new Recipes();
        private RecipesAndIngrRepository rp = new RecipesAndIngrRepository();
 
        public CreateRecipe(int id)  // useri ID n a 
        {
            InitializeComponent();
            
            //  this.DataContext = r;
            r.RecipeUserID = id;

          
           List<Ingredients> ingredients = (List<Ingredients>)rp.GetIngredients();
           IngredientsList.ItemsSource = ingredients;
          //inchvor instructioner bacvi estegh ,TODO
            // if(r.RecipeUserID !=0)
            //{
            //    MessageBox.Show("Welcome " +
            //        "Instructions` ");
            //    MessageBox.Show("Input Data in here ");
            //    RecipeDescr.Focus();
            //    MessageBox.Show("After that ` Input Steps in here and make sure to click վերջնական after");
            //    StepsVisual.Focus();
            //    MessageBox.Show("After that ` Input Ingredients in here ");
            //    IngredientsVisual.Focus();
            //}
        }
      
        private void SubmitButton1_Click(object sender, RoutedEventArgs e)
        {
            int a = 0, b = 0;
            if (RecRegname.Text.Length == 0 || RecDescr.Text.Length == 0)
            {
                MessageBox.Show("մուտքագրեք բաղադրատոմսի անունը ,նախընտրելի է նկարագրությունն էլ ։)");
                RecRegname.Focus();
                RecDescr.Focus();
            }
            else if(!(Int32.TryParse(PrepTime.Text, out  a)))
            {
                MessageBox.Show("մուտքագրեք թիվ");
                PrepTime.Focus();
                PrepTime.Select(0, PrepTime.Text.Length);
            }
            else if(Int32.TryParse(CookTime.Text, out b))
            {
                MessageBox.Show("մուտքագրեք թիվ");
                CookTime.Focus();
                CookTime.Select(0, CookTime.Text.Length);

            }
            else {
                r.RecipeName = RecRegname.Text;
                r.RecipeDescription = RecDescr.Text;
                r.RecipeDificulty = Difficulty.SelectedIndex + 1;
                r.RecipePrepTime = a;
                r.RecipeCookTime = b;
                    //image n el ,bayc dzev chem imanum 
                rp.CreateRecipePart1Recipe(r);          
                MessageBox.Show("անցնենք քայլերին ՞։)"); 
            }
           

        }
        private void AddStepButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(AddStepText.Text))
            {
                return;
            }
            StepsVisual.Items.Add(AddStepText.Text);
            AddStepText.Clear();
            AddStepText.Focus();
        }

        private void StepRemove_Click(object sender, RoutedEventArgs e)
        {
            if (StepsVisual.Items.Count > 0)
            {
                //exception a trnum erb aranc select anelu remove a arvum 
                if (StepsVisual.SelectedIndex != -1)
                {
                    StepsVisual.Items.RemoveAt(StepsVisual.SelectedIndex);
                }
            }
        }
        private void SubmitButton2_Click(object sender, RoutedEventArgs e)
        {

            if (MessageBox.Show(" ներմուծե՞լ եք անվան/նկարագրության/... դաշտերը՞,վստահ ե՞ք,որ ձեր ներմուծված քայլերը վերջնական են",
                 "Հաստատել", MessageBoxButton.YesNo) == MessageBoxResult.Yes) {
                List<Steps> addedsteps = new List<Steps>();
                if (r.RecipeID != 0)
                {
                    for (int i = 0; i < StepsVisual.Items.Count; ++i)
                    {

                        addedsteps.Add(new Steps()
                        {
                            SRecipeID = r.RecipeID,
                            StepNumber = i + 1,
                            StepDescription = StepsVisual.Items[i].ToString(),// chgitem kashkhati te che :_:
                            StepsSubRecipesID = null // hly vor senc togh mutqery  lini,

                        }); ;

                    }
                    rp.CreateRecipePart2Steps(addedsteps);
                    #region recipeSteps  
                    /*  DataTable dt = new DataTable();
                      dt = ConnectionManager.ListToDataTable<Steps>(addedsteps);
                      using (SqlConnection conn = ConnectionManager.CreateConnection())
                      {
                          conn.Open();
                          using (SqlCommand cmd = new SqlCommand())
                          {
                              cmd.Connection = conn;
                              cmd.CommandText = "[dbo].[usp_RecipeStepsIntoDB]";
                              cmd.CommandType = System.Data.CommandType.StoredProcedure;

                              cmd.Parameters.Add("@Stepps", System.Data.SqlDbType.Structured).Value = dt;
                              // pti stugvi anpayman 
                              cmd.ExecuteNonQuery();
                          }

                      }  */
                    #endregion
                    MessageBox.Show("անցնենք բաղադրամասերին ։) ");
                }
                else
                {
                    MessageBox.Show("recept is not created normally ");
                    RecipeDescr.Focus();
                    Difficulty.Focus();
                }
        
            }  
            else {
                
                MessageBox.Show("մմմ... ավելացրեք խնդրում եմ");
                RecipeDescr.Focus();
                Difficulty.Focus();
            }
        }
        private void AddCurrentIngredient_Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(MessAmount.Text) || string.IsNullOrEmpty(MessType.Text) || IngredientsList.SelectedIndex == -1)
            {   // MessAmount     // MessType  // IngredientsList 
                // amount y kara voroshvats chlini irakanum ,bayc lav togh null cheghni
                return;
            }

            Ingredients currentIngr = new Ingredients();
            currentIngr = (Ingredients)IngredientsList.SelectedItem;
            
            Recipe_Ingredients ri = new Recipe_Ingredients();
            ri.IngrID = currentIngr.IngredientID;
            ri.RecipeID = r.RecipeID;
            ri.MeasurementType = MessType.Text.ToString();
            ri.MeasurementAmount = System.Convert.ToDecimal(MessAmount.Text);
            // event grel, vor menak tvayin arjeq lini sa 
            
            IngredientsVisual.Items.Add(ri); 
        
            MessAmount.Clear();
            MessAmount.Focus();

            MessType.Clear();
            MessType.Focus();
        }
        private void removeIngredient_Click(object sender, RoutedEventArgs e)
        {
            if (IngredientsVisual.Items.Count > 0)
            {
                //exception a trnum erb aranc select anelu remove a arvum 
                if (IngredientsVisual.SelectedIndex != -1)
                {
                    IngredientsVisual.Items.RemoveAt(IngredientsVisual.SelectedIndex);
                }
            }

        }
        private void addIngredientButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show(" ներմուծե՞լ եք անվան/նկարագրության/... դաշտերը՞,վստահ ե՞ք,որ ձեր ներմուծված բաղադրամասերի նկարագրությունները վերջնական են",
                "Հաստատել", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                if (r.RecipeID != 0)
                {
                    List<Recipe_Ingredients> addedingredients = new List<Recipe_Ingredients>();
                    for (int i = 0; i < IngredientsVisual.Items.Count; ++i)
                    {
                        addedingredients.Add((Recipe_Ingredients)IngredientsVisual.Items[i]);
                        //esi karogh a senc ok chashkhati bayc
                    }

                    rp.CreateRecipePart3Ingredients(addedingredients);

                    MessageBox.Show("բաղադրամասը կառուցվեց, կարող եք սեղմել {Դիտել} կոճակի վրա և նայել ։)" +
                        "քայլերի կամ ինգրեդիենտների փոփոխություններ անելու համար հլը բան չեմ մտածել");
                }
                else { MessageBox.Show("ռեցեպտը չկա ");
                    RecipeDescr.Focus();
                    Difficulty.Focus();
                    StepsVisual.Focus();
                }
            }
            else {
                MessageBox.Show("ավելացրեք խնդրում եմ ։)");
                RecipeDescr.Focus();
                Difficulty.Focus();
                StepsVisual.Focus();
             
                 }
        }
        private void OpenRecipePage_Button_Click(object sender, RoutedEventArgs e)
        {
            RecipePage rp = new RecipePage(r.RecipeID);
            rp.Show();
            this.Close();
        }

        private void MessAmount_KeyDown(object sender, KeyEventArgs e)
        {
            //if(!char.IsDigit(Convert.ToChar(e.Key.ToString())) && !char.IsControl(Convert.ToChar(e.Key.ToString())) && !e.Key.Equals('.'))
            //{
            //    e.Handled = true;
            //}

            //if(e.Key!=Key.NumPad0 || 
            //    e.Key !=Key.NumPad1 ||
            //    e.Key !=Key.NumPad2 ||
            //    e.Key != Key.NumPad3 || e.Key != Key.NumPad4 || e.Key != Key.NumPad5 || e.Key != Key.NumPad6 || e.Key != Key.NumPad7 ||
            //    e.Key != Key.NumPad8 || e.Key != Key.NumPad9 || e.Key != Key.Decimal ||  e.Key != Key.NumPad0 ||( e.Key.ToString() != ("."))){
            //    e.Handled = false;
            //}
            //else { e.Handled = true; }
        }

        private void TEST_click(object sender, RoutedEventArgs e)
        {
            // es vor sagh irar het lini,  mtatsum em hly
        //    bool recipeChecker = false;

        //    r.RecipeName = RecRegname.Text;
        //    r.RecipeDescription = RecDescr.Text;
        //    r.RecipeDificulty = Difficulty.SelectedIndex + 1;
                              
        //    if (Int32.TryParse(PrepTime.Text, out int a)){
        //        r.RecipePrepTime = a;
        //    }
        //    else
        //    {
        //        MessageBox.Show("մոտւքագրեք թիվ");
        //        PrepTime.Focus();
        //    }
        //    if(Int32.TryParse(CookTime.Text, out int b)){
        //        r.RecipeCookTime = b;
        //    }
        //    else
        //    {
        //        MessageBox.Show("մոտւքագրեք թիվ");
        //        CookTime.Focus();
        //    }
            
        //    //image n el ,bayc dzev chem imanum 

        //    rp.CreateRecipePart1Recipe(r);
        //    recipeChecker = true; 
        //    //steps 

        //    List<Steps> addedsteps = new List<Steps>();
        //    for (int i = 0; i < StepsVisual.Items.Count; ++i)
        //    {

        //        addedsteps.Add(new Steps()
        //        {
        //            SRecipeID = r.RecipeID,
        //            StepNumber = i + 1,
        //            StepDescription = StepsVisual.Items[i].ToString(),// chgitem kashkhati te che :_:
        //            StepsSubRecipesID = null // hly vor senc togh mutqery  lini,

        //        }); ;

        //    }
        //    rp.CreateRecipePart2Steps(addedsteps);


        //    //Ingredients

        //    List<Recipe_Ingredients> addedingredients = new List<Recipe_Ingredients>();
        //    for (int i = 0; i < IngredientsVisual.Items.Count; ++i)
        //    {
        //        addedingredients.Add((Recipe_Ingredients)IngredientsVisual.Items[i]);
        //        //esi karogh a senc ok chashkhati bayc
        //    }

        //    rp.CreateRecipePart3Ingredients(addedingredients);
        //
        }
    }
}
