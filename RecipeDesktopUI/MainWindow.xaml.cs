using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RecipeDesktopUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
          //  RecipePage rp = new RecipePage(110);
           // rp.Show();
        }

        private void MW_RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            // MessageBox.Show($"Random Stuff");
            RegisterWindow rw = new RegisterWindow();
            rw.Show();
           
        }

        private void MW_Login_Click(object sender, RoutedEventArgs e)
        {
            Login lg = new Login();
            lg.Show();
            this.Close();
        }

        private void Recipe_Sample_Click(object sender, RoutedEventArgs e)
        {
            //zut sampley nayelu hamar er, sa ankap a 
            RecipePage rp = new RecipePage(110);
            rp.Show();
        }

        private void MW_SWR_Click(object sender, RoutedEventArgs e)
        {
            //es el a sample search i  hamar
            SearchWindow sw = new SearchWindow();
            sw.Show();
        }
    }
}
