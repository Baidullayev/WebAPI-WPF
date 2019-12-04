using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NotesApi.Entities
{
    public class SharedNotes
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int NoteId {get;set;}
        [Required]
        public int SenderId { get; set; }
        [Required]
        public int RecipientId { get; set; }
        [Required]
        public DateTime SendingTime { get; set; }
        
    }
}
