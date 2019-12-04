using NotesApi.Data;
using NotesApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesApi.Services
{
    public interface ISharedNotesService
    {
        SharedNotes GetById(int noteId);
        string Create(SharedNotes newNote);
        string Delete(int id);
        IEnumerable<SharedNotes> GetBySenderId(int userId);
        IEnumerable<SharedNotes> GetByRecipientId(int userId);        
        IEnumerable<SharedNotes> GetAll();
    }
    public class SharedNotesService :ISharedNotesService
    {
        ApplicationDBContext context = new ApplicationDBContext();
        public SharedNotes GetById(int noteId)
        {
            try
            {
                SharedNotes  sharedNotesList = context.SharedNotesList.Where(item => item.Id == noteId).FirstOrDefault();
                return sharedNotesList;
            }
            catch
            {
                return null;
            }
        }

        public string Create (SharedNotes newSharedNote)
        {
            try
            {
                context.SharedNotesList.Add(newSharedNote);
                context.SaveChanges();
                return "Success";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

        public string Delete(int id)
        {
            try
            {
                var itemToRemove = context.SharedNotesList.Where(item => item.Id == id).FirstOrDefault();
                context.SharedNotesList.Remove(itemToRemove);
                context.SaveChanges();
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public IEnumerable<SharedNotes> GetBySenderId(int userId)
        {
            try
            {
                IEnumerable<SharedNotes> sharedNotesList = context.SharedNotesList.Where(item => item.SenderId == userId).ToList();
                return sharedNotesList;
            }
            catch
            {
                return null;
            }
        }
        public IEnumerable<SharedNotes> GetByRecipientId(int userId)
        {
            try
            {
                IEnumerable<SharedNotes> sharedNotesList = context.SharedNotesList.Where(item => item.RecipientId == userId).ToList();
                return sharedNotesList;
            }
            catch
            {
                return null;
            }
        }
        public IEnumerable<SharedNotes> GetAll()
        {
            try
            {
                IEnumerable<SharedNotes> allSharedNotesInDb = context.SharedNotesList.ToList();
                return allSharedNotesInDb;
            }
            catch
            {
                return null;
            }
        }

    }
}
