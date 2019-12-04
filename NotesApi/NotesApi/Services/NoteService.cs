using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotesApi.Data;
using NotesApi.Entities;

namespace NotesApi.Services
{
    public interface INoteService
    {
        string Create (Note newNote);
        string Update(Note note);
        string Delete(int id);
        IEnumerable<Note> GetByUserId(int userId);
        Note GetById(int noteId);
        IEnumerable<Note> GetAll();
    }
    public class NoteService : INoteService
    {
        ApplicationDBContext context = new ApplicationDBContext();
        public string Create(Note newNote)
        {
            using (ApplicationDBContext context = new ApplicationDBContext())
            {
                try
                {
                    context.NoteList.Add(newNote);
                    context.SaveChanges();
                    return "Success";
                }catch(Exception ex)
                {
                    return ex.Message;
                }
            }
        }

        public string Update(Note note)
        {
            try
            {
                var updatingItem = context.NoteList.Where(item => item.Id == note.Id).FirstOrDefault();
                updatingItem.Header = note.Header;
                updatingItem.Body = note.Body;
                updatingItem.RemindTime = note.RemindTime;
                updatingItem.TrashedDate = note.TrashedDate;
                context.SaveChanges();
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public string Delete(int id)
        {
            try
            {
                var itemToRemove = context.NoteList.Where(item => item.Id == id).FirstOrDefault();
                context.NoteList.Remove(itemToRemove);
                context.SaveChanges();
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public IEnumerable<Note> GetByUserId(int userId)
        {
            try
            {
                IEnumerable<Note> noteListOfUser = context.NoteList.Where(item => item.UserId == userId).ToList();
                return noteListOfUser;
            }catch
            {                
                return null;
            }
        }
        public Note GetById(int noteId)
        {
            try
            {
                Note note = context.NoteList.Where(item => item.Id == noteId).FirstOrDefault();
                return note;
            }
            catch
            {
                return null;
            }
        }
        public IEnumerable<Note> GetAll()
        {
            try
            {
                IEnumerable<Note> noteListOfUser = context.NoteList.ToList();
                return noteListOfUser;
            }
            catch
            {
                return null;
            }
        }

    }
}
