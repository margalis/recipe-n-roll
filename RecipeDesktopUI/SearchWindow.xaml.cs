using DataAccess;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for SearchWindow.xaml
    /// </summary>
    /// 

    public partial class SearchWindow : Window
    {
        // List<DataAccess.Entities.RecipefromUserview> recipeList = new List<DataAccess.Entities.RecipefromUserview>();
        private RecipesAndIngrRepository rrrepo = new RecipesAndIngrRepository();
        public SearchWindow()
        {
            InitializeComponent();
            List<Ingredients> ingredientslist = new List<Ingredients>();

            ingredientslist = (List<Ingredients>)rrrepo.GetIngredients();
            //IngSearchBox.DataContext = ingredientslist;
            // IngSearchBox.ItemsSource = ingredientslist; // maybe a better way ? 
            foreach (Ingredients i in ingredientslist)
            {
                IngSearchBox.Items.Add(i.IngredientName);
            }

        }
        private void NameSearchButton_Click(object sender, RoutedEventArgs e)
        {
            string recipeName = NameSearchBox.Text;

            List<DataAccess.Entities.RecipeIDName> recipeList = new List<DataAccess.Entities.RecipeIDName>();

            rrrepo.GetRecipeNamesSimilarTo(recipeList , recipeName);
            if (recipeList.Count <=0)
            {
                MessageBox.Show("նՇՎԱԾ ԱՆՈՒՆՈՎ ԲԱՂԱԴՐԱՏՈՄՍ ԳՈՅՈՒԹՅՈՒՆ ՉՈՒՆԻ");

            }
            RecipeLists.DataContext = recipeList;
            RecipeLists.ItemsSource = recipeList;

            
        }
        private void IngSearchButton_Click(object sender, RoutedEventArgs e)
        {
            List<String> ingredientNames = new List<String> ();
            foreach (var listboxitem in IngSearchBox.SelectedItems)
            {
                ingredientNames.Add(listboxitem.ToString());
            }
           
            List<RecipeIDName> recipeList = new List<RecipeIDName>();
           
            rrrepo.GetRecipeNamesnIDviaIngredients(ingredientNames, recipeList);
            // GetRecipeNamesnIDviaIngredients
            if (recipeList.Count <= 0)
            {
                MessageBox.Show("նՇՎԱԾ ԲԱՂԱԴՐԱՄԱՍԵՐՈՎ ԲԱՂԱԴՐԱՏՈՄՍ ԳՈՅՈՒԹՅՈՒՆ ՉՈՒՆԻ Բազայում ։Դ");

            }
            RecipeLists.DataContext = recipeList;
            RecipeLists.ItemsSource = recipeList;

        }
        private void RecipeOpener_Click(object sender, RoutedEventArgs e)
        {
            RecipeIDName rp = new RecipeIDName();
            rp = (RecipeIDName)RecipeLists.SelectedItem;
            RecipePage recipe = new RecipePage(rp.RecipeId);
            recipe.Show();
        }
    }
}
