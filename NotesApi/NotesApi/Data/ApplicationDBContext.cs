using Microsoft.EntityFrameworkCore;
using NotesApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesApi.Data
{
    public class ApplicationDBContext :DbContext
    {
        public DbSet<User> UserList { get; set; }
        public DbSet<Note> NoteList { get; set; }
        public DbSet<SharedNotes> SharedNotesList { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite("Filename=./Notes.db");
    }
}
