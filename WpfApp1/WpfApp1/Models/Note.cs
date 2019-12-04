using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp1.Models
{
    class Note
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime RemindTime { get; set; }
        public DateTime TrashedDate { get; set; }
    }
}
