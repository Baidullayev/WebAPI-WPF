using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp1.Models
{
    class SharedNote
    {
        public int Id { get; set; }
        public string SenderId { get; set; }
        public string RecipientId { get; set; }
        public DateTime SendingTime { get; set; }
        public int NoteId { get; set; }
    }
}
