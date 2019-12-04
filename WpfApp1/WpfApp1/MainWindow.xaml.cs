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
using MahApps.Metro.Controls;
using WpfApp1.Services;
using System.ComponentModel;
using WpfApp1.Models;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    /// 
    /// 
    //THIS CLASS USES TO HIDE SOME COLUMN IN THE LISTVIEW FOR EXAMPLE ID  /////////////////////////////////////////////
    public class GridViewColumnVisibilityManager
    {
        static Dictionary<GridViewColumn, double> originalColumnWidths = new Dictionary<GridViewColumn, double>();

        public static bool GetIsVisible(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsVisibleProperty);
        }

        public static void SetIsVisible(DependencyObject obj, bool value)
        {
            obj.SetValue(IsVisibleProperty, value);
        }

        public static readonly DependencyProperty IsVisibleProperty =
            DependencyProperty.RegisterAttached("IsVisible", typeof(bool), typeof(GridViewColumnVisibilityManager), new UIPropertyMetadata(true, OnIsVisibleChanged));

        private static void OnIsVisibleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            GridViewColumn gc = d as GridViewColumn;
            if (gc == null)
                return;

            if (GetIsVisible(gc) == false)
            {
                originalColumnWidths[gc] = gc.Width;
                gc.Width = 0;
            }
            else
            {
                if (gc.Width == 0)
                    gc.Width = originalColumnWidths[gc];
            }
        }
    }
    ////////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class MainWindow : MetroWindow
    {
     
        private UserService userService = new UserService();
        private NoteService noteService = new NoteService();
        private List<Note> currentNotes = new List<Note>();        
        public MainWindow()
        {       
            InitializeComponent();
        }
    

        void DataWindow_Closing(object sender, CancelEventArgs e)
        {
            //если не вызывать этот метод, при нажатии Х в списке процессов отстается слепок приложения
            System.Windows.Application.Current.Shutdown();
        }
        void App_Activated(object sender, EventArgs e)
        {
            // Application activated
            if(App.id != null && App.username!=null && App.userToken != null)
            {
                this.NewNoteBox.IsEnabled = true;
                this.AllNotesItemButton.IsEnabled = true;
                this.SharedNotesButton.IsEnabled = true;
                this.TrashButton.IsEnabled = true;
                this.NewNoteMenuItem.IsEnabled = true;
                this.SignInLable.Content = App.username + ", " + "Sign out";
                this.NewNoteMenuItem.IsEnabled = true;
            }
            if(NotesList.SelectedIndex == -1)
            {
                NoteBox.IsEnabled = false;
            }
        }


        private void Exit(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void NewNode(object sender, RoutedEventArgs e)
        {
            //AuthorizationWindow authWindow = new AuthorizationWindow();
            //authWindow.Show();
            NoteBox.Text = "";
            HeaderBox.Text = "";
            if (App.username != null && App.userToken != null)
            {
                CreateNoteWindow createNoteWindow = new CreateNoteWindow();
                createNoteWindow.Show();
            }
            else
            {
                AuthorizationWindow loginWindow = new AuthorizationWindow();
                loginWindow.Show();
            }
                       

        }



        private void AllNotes(object sender, RoutedEventArgs e)
        {
            NoteBox.Text = "";
            HeaderBox.Text = "";
            NotesList.Items.Clear();
            currentNotes.Clear();
            if (App.username != null && App.userToken != null)
            {
                var Notes = noteService.GetNotesByUserId(App.id);
                currentNotes = Notes;
                foreach (Note note in Notes)
                {    
                    if(note.TrashedDate == Convert.ToDateTime("0001 - 01 - 01 00:00:00")) this.NotesList.Items.Add(note);
                }
                
                NotesListLabel.Content = "My Notes";
            }
            else
            {
                AuthorizationWindow authorizationWindow = new AuthorizationWindow();
                authorizationWindow.Show();
            }
        }

        
        private void SignInOutMenuItem(object sender, RoutedEventArgs e)
        {
            if (App.username != null && App.userToken != null)
            {
                SignOut();
            }
            else
            {
                AuthorizationWindow loginWindow = new AuthorizationWindow();
                loginWindow.Show();
            }
        }
        private void SignOut()
        {
            App.id = null;
            App.username = null;
            App.userToken = null;
            this.SignOutMenuItem.Header = "Sign In";
            this.NewNoteBox.IsEnabled = false;
            this.AllNotesItemButton.IsEnabled = false;
            this.SharedNotesButton.IsEnabled = false;
            this.TrashButton.IsEnabled = false;
            this.NewNoteMenuItem.IsEnabled = false;
            SignInLable.Content = "Sign in";            
            NotesList.Items.Clear();
            HeaderBox.Text = "";
            NoteBox.Text = "";
            HeaderBox.IsEnabled = false;
            NoteBox.IsEnabled = false;
            SaveChangesButton.IsEnabled = false;
            
        }

        private void NotesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (NotesList.SelectedIndex != -1)
            {
                NoteBox.IsEnabled = true;
                RemindTimePicker.IsEnabled = true;
            }
            var element = NotesList.SelectedIndex;
        }
        private void MoveToTrash(object sender, RoutedEventArgs e)
        {
            if (NotesList.SelectedIndex == -1) return;            
            Note note = (Note)NotesList.SelectedItem;
            note.TrashedDate = DateTime.Now;
            string updateResult = noteService.Update(note);
            System.Windows.MessageBox.Show(updateResult);
            this.AllNotes(null, null);
        }
        private void Share(object sender, RoutedEventArgs e)
        {
            if (NotesList.SelectedIndex == -1) return;
            Note note = (Note)NotesList.SelectedItem;
            App.shareNoteId = note.Id.ToString();
            ShareWindow shareWindow = new ShareWindow();
            shareWindow.Show();

        }

        private void NoteBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SaveChangesButton.IsEnabled = true;            
        }

        private void SaveChangesButton_Click(object sender, RoutedEventArgs e)
        {
            if (NotesList.SelectedIndex == -1) return;
            Note note = (Note)NotesList.SelectedItem;
            if(RemindTimePicker.SelectedDate != null) note.RemindTime = RemindTimePicker.SelectedDate.Value;
            note.Header = HeaderBox.Text;
            note.Body = NoteBox.Text;
            string updateResult = noteService.Update(note);
            System.Windows.MessageBox.Show(updateResult);
            this.AllNotes(null,null);
        }



        private void TrashButton_Click(object sender, RoutedEventArgs e)
        {
            NoteBox.Text = "";
            HeaderBox.Text = "";
            NotesListLabel.Content = "Trash";
            NotesList.Items.Clear();
            currentNotes.Clear();
            if (App.username != null && App.userToken != null)
            {
                var Notes = noteService.GetNotesByUserId(App.id);
                currentNotes = Notes;
                foreach (Note note in Notes)
                {
                    if (note.TrashedDate != Convert.ToDateTime("0001 - 01 - 01 00:00:00")) this.NotesList.Items.Add(note);
                }
                
                NotesListLabel.Content = "Trash";
            }
            else
            {
                AuthorizationWindow authorizationWindow = new AuthorizationWindow();
                authorizationWindow.Show();
            }
        }

        private void SharedNotesButton_Click(object sender, RoutedEventArgs e)
        {
            NoteBox.Text = "";
            HeaderBox.Text = "";
            NotesList.Items.Clear();
            currentNotes.Clear();
            
            NotesListLabel.Content = "Shared with me";
            noteService.GetNoteSharedWithMe(App.id);
            var Notes = noteService.GetNoteSharedWithMe(App.id);
            currentNotes = Notes;
            if(Notes != null)
            {
                foreach (Note note in Notes)
                {
                    this.NotesList.Items.Add(note);
                }
            }

        }
        private void ExportToPdf(object sender, RoutedEventArgs e)
        {
            if (NotesList.SelectedIndex != -1)
            {
                PdfService pdfService = new PdfService();
                Note note = (Note) NotesList.SelectedItem;                
                pdfService.ExportToPDF(note.Header, note.Body);
            }
        }
        private void NoteListView_Click(object sender, RoutedEventArgs e)
        {
            if (App.id != null)
            {
                RemindTimePicker.SelectedDate = null;
                Note note = (Note)NotesList.SelectedItem;
                if(note != null)
                {
                    HeaderBox.Text = note.Header;
                    NoteBox.Text = note.Body;
                    DateTime date = DateTime.ParseExact("0001-01-01 00:00:00", "yyyy-MM-dd HH:mm:ss",
                                               System.Globalization.CultureInfo.InvariantCulture);
                    if (note.RemindTime != date) RemindTimePicker.SelectedDate = note.RemindTime;
                    HeaderBox.IsEnabled = true;
                    NoteBox.IsEnabled = true;
                    RemindTimePicker.IsEnabled = true;
                }

            }
        }

    }
}
