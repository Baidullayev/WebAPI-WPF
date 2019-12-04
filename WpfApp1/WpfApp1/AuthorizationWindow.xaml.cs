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
using WpfApp1.Services;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
        }



        private void SignIn(object sender, RoutedEventArgs e)
        {
            UserService userService = new UserService();
            string result = userService.Authenticate(this.UsernameBox.Text, PasswordBox.Password);
            if (result == "success") this.Close();
            else
            {
                this.FeedbackLabel.Content = result;
                System.Windows.MessageBox.Show(result);
                
            }

        }



        private void Register(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Show();
            this.Close();
        }
    }
}
