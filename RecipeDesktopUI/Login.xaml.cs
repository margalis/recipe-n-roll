using DataAccess;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }
      
        private void Login_Button_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxEmail.Text.Length == 0)
            {
                errormessage.Text = "մուտքագրեք ձեր էլեկտրոնային հասցեն";
                textBoxEmail.Focus();
            }
            else if (!Regex.IsMatch(textBoxEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                errormessage.Text = "վը մուտքագրեք մարդավարի";
                textBoxEmail.Select(0, textBoxEmail.Text.Length);
                textBoxEmail.Focus();
            }
            else
            {
                User_Account ua = new User_Account();
  
                object sc;  // object a qanzi  null i het em uzum  hamematel :) 
                UserRepository up = new UserRepository();
                sc= up.LoginInformation(textBoxEmail.Text, passwordBox.Password);
                if (sc == null)
                {
                    errormessage.Text = "օյ, մուտքագրեք գոյություն ունեցող էլ.հասցե և գաղտնաբառ.";
                    textBoxEmail.Focus();
                    passwordBox.Focus();
                }
                else
                {
                    ua.UserID = (int)sc;
                    ua.UserEmail = textBoxEmail.Text;   // 
                    ua.UserPassword = passwordBox.Password;  // es erkusy vapshe petq a initialize anel?
                    UserAccountWindow uaw = new UserAccountWindow(ua.UserID);
                    uaw.Show();
                    this.Close();
                }
            }
        }
        private void buttonRegister_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow rw = new RegisterWindow();
            rw.Show();
            Close();
        }
    }
}
