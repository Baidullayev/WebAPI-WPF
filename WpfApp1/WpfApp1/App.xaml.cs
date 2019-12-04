using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfApp1.Models;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    /// 
    
    public partial class App : Application
    {
        
        public static string username;
        public static string id;
        public static string userToken;

        //параметр для передачи shareWindow
        public static string shareNoteId;
    }
}
