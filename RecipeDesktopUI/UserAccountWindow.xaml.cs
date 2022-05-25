
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
    /// Interaction logic for UserAccountWindow.xaml
    /// </summary>
    public partial class UserAccountWindow : Window
    {
        User_Account ua = new User_Account();
        public UserAccountWindow()
        {
            InitializeComponent();
            
        }
        public UserAccountWindow(int UID)
        {  
            //overload constructor logic 
            InitializeComponent();
            ua.UserID = UID;
            this.DataContext = ua;
            UserRepository.GetUserInfoFromDB(ua);
        }

        private void Create_New_Recipe_Click(object sender, RoutedEventArgs e)
        {
            // ua i ID n pahelov 
            CreateRecipe cr = new CreateRecipe(ua.UserID);
            cr.Show();
        }

        private void UA_Search_Click(object sender, RoutedEventArgs e)
        {
            SearchWindow sw = new SearchWindow();
            sw.Show(); 
        }

        private void UA_LogOut_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are You Sure",
                 "LogOut", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                MainWindow mw = new MainWindow();
                mw.Show();
                this.Close();

                // stugi vor useri bacats mnacats edgern el pakven 
            }
            else { }
        }
        // verji puli tzvz baner en
        private void Change_FullName_Click(object sender, RoutedEventArgs e)
        {
            //TODO 
        }

        private void Change_Password_Click(object sender, RoutedEventArgs e)
        {
            //TODO
        }

        private void Change_Photo_Click(object sender, RoutedEventArgs e)
        {
            //TODO
        }

        private void Created_Recipes_Click(object sender, RoutedEventArgs e)
        {
            //ua Id ov 
           UsersCreatedRecipes ucr = new UsersCreatedRecipes(ua);
           ucr.Show();
        }

        private void User_Favourites_Click(object sender, RoutedEventArgs e)
        {
           // UsersFavourites uf = new UsersFavourites(ua.UserID);
            //uf.Show();
        }
    }
}
