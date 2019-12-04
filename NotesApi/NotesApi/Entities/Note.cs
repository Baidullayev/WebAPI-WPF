using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NotesApi.Entities
{
    public class Note
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName ="nvarchar(100)")]
        public string Header { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Body { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        public DateTime RemindTime { get; set; }
        
        public DateTime TrashedDate { get; set; }
    }
}
