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
    /// Логика взаимодействия для CreateNoteWindow.xaml
    /// </summary>
    public partial class CreateNoteWindow : Window
    {
        Note note = new Note();
        public CreateNoteWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

       
        private void SaveAndClose(object sender, RoutedEventArgs e)
        {
            if(Checker())
            {           
                
                note.Header = Header.Text;
                note.CreatedDate = DateTime.Now;
                note.Body = Body.Text;
                note.UserId = Int32.Parse(App.id);
               
                if (RemindTimePicker.SelectedDate.HasValue)
                {
                    note.RemindTime = RemindTimePicker.SelectedDate.Value;
                }
                NoteService noteService = new NoteService();
                string result = noteService.Create(note);
                if (result.ToLower() == "success") this.Close();
                else System.Windows.MessageBox.Show(result);
            }
        }
        private bool Checker()
        {
            if(Header.Text!="")
            {
                return true;
            }
            return false;
        }
        private void ExportToPdf(object sender, RoutedEventArgs e)
        {
            if (Header.Text != null)
            {
                PdfService pdfService = new PdfService();
                pdfService.ExportToPDF(Header.Text, Body.Text);
            }
        }
    }
}
