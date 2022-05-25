using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using DataAccess;
using System.Data.SqlClient;
using DataAccess.Entities;

namespace RecipeDesktopUI
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        // UserAccount viewModel = new UserAccount();
        User_Account ua = new User_Account();
        public RegisterWindow()
        {
            InitializeComponent();
            
          //  this.DataContext = viewModel;
        }

        private void RW_RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            if (userRegname.Text.Length==0)  // stringIsNullOrWhiteSpace-ov ckaroghaca :/
            {
                errormessage.Text = "մուտքագրեք ձեր անունը";
                userRegname.Focus();
            }
            else if (userRegemail.Text.Length == 0)
            {
                errormessage.Text = "մուտքագրեք ձեր էլեկտրոնային հասցեն";
                userRegemail.Focus();
            }
            else if (!Regex.IsMatch(userRegemail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            { // es gtel em,hpart em hatnagortsutyambs :DDD
                errormessage.Text = "Մուտքագրեք մարդավարի մեյլ վը";
                userRegemail.Select(0, userRegemail.Text.Length);
                userRegemail.Focus();
            }
            //stugum a if password nery havasar en te voch 
            //ete ayo   apa 
            else if (userRegpassword.Password.Length == 0)
            {
                errormessage.Text = "մուտքագրեք գաղտնաբառ.";
                userRegpassword.Focus();
            }
            else if (userRegpasswordconfirm.Password.Length == 0)
            {
                errormessage.Text = "մուտքագրեք գաղտնաբառը 2րդ անգամ";
                userRegpasswordconfirm.Focus();
            }
            else if (userRegpassword.Password != userRegpasswordconfirm.Password)
            {
                errormessage.Text = "ուղղեք գաղտնաբառը";
                userRegpasswordconfirm.Focus();
            }
            else
            {
                errormessage.Text = "";
               
                ua.UserFullName = userRegname.Text;
                ua.UserEmail = userRegemail.Text;
                ua.UserPassword = userRegpassword.Password;  // ??

                UserRepository.RegisteringProccess(ua);
                errormessage.Text = "Դուք հաջողությամբ գրանցվեցիք,կարող եք մուտք գործել";  
                Login l = new Login();
                l.Show();

            }
        }
        private void RW_CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
    


