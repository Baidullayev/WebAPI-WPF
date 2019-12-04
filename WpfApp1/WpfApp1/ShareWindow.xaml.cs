using Newtonsoft.Json;
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
using WpfApp1.Models;
using WpfApp1.Services;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для ShareWindow.xaml
    /// </summary>
    public partial class ShareWindow : Window
    {
        List<User> users;
        public ShareWindow()
        {

            InitializeComponent();
        }
        void App_Activated(object sender, EventArgs e)
        {
            if(HeaderBlock.Text == "")
            {
                NoteService noteService = new NoteService();
                Note noteToShare = noteService.GetNoteById(App.shareNoteId);
                HeaderBlock.Text = noteToShare.Header;
            }
            

                UserService userService = new UserService();
                users = userService.GetAllUsers();
                foreach (User user in users)
                {
                    if(user.Username != App.username) UsernameBox.Items.Add(user.Username);
                }
            

            
        }
        

        private void ToShare(object sender, RoutedEventArgs e)
        {
            
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameBox.SelectedItem.ToString();
            string recipientId = null;
            foreach (User user in users)
            {
                if (user.Username == username)
                {
                    recipientId = user.Id;
                }
            }

            if (recipientId != null)
            {

                SharedNote shareNote = new SharedNote();
                shareNote.NoteId = Convert.ToInt32(App.shareNoteId);
                shareNote.SenderId = App.id;
                shareNote.RecipientId = recipientId;
                shareNote.SendingTime = DateTime.Now;

                SharedNotesService shareNoteService = new SharedNotesService();
                System.Windows.MessageBox.Show(shareNoteService.Create(shareNote));
            }
        }
    }

}
