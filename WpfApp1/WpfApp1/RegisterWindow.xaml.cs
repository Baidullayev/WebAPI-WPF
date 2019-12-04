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
    /// Логика взаимодействия для RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void SignIn(object sender, RoutedEventArgs e)
        {
            AuthorizationWindow loginWindow = new AuthorizationWindow();
            loginWindow.Show();
            this.Close();
        }


        private void Register(object sender, RoutedEventArgs e)
        {
            //string username = this.UsernameBox.Text;
            UserService userService = new UserService();
            if (this.UsernameBox.Text != "" && FirstnameBox.Text != "" && LastnameBox.Text != "" && PasswordBox.Password != "" && ConfirmPasswordBox.Password != "")
            {
                if (this.PasswordBox.Password == this.ConfirmPasswordBox.Password)
                {
                    string result = userService.Create(this.UsernameBox.Text, this.FirstnameBox.Text, this.LastnameBox.Text, this.PasswordBox.Password);
                    if (result.ToLower() == "success")
                    {
                        userService.Authenticate(this.UsernameBox.Text, this.PasswordBox.Password);
                        this.Close();
                    }
                    this.FeedbackLabel.Content = result;
                }
                else this.FeedbackLabel.Content = "Password and confirm password does not match";
            }else this.FeedbackLabel.Content = "Please, fill in form fields";


        }
    }
}
