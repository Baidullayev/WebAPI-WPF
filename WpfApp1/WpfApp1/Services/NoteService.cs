using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WpfApp1.Models;

namespace WpfApp1.Services
{

    class NoteService
    {
        HttpService httpService = new HttpService();
        public string createUrl = "http://localhost:4702/api/notes/create";
        public string getAll = "http://localhost:4702/api/notes/getall";
        public string updateUrl = "http://localhost:4702/api/notes/update";
        public string getNotesByUserIdUrl = "http://localhost:4702/api/notes/getbyuserid";
        public string getSharedWithMeUrl = "http://localhost:4702/api/notes/gesharedwithme";
        public string getById = "http://localhost:4702/api/notes/getbyid";

        public string Create(Note note)
        {
            object jsonObject = JsonConvert.SerializeObject(new
            {
                Header = note.Header,
                Body = note.Body,
                UserId = App.id,
                RemindTime = note.RemindTime
                

            });
            return httpService.HttpWebRequest(jsonObject, createUrl);
        }
        public List<Note> GetNotesByUserId(string userId)
        {
            object jsonObject = JsonConvert.SerializeObject(new
            {
                userId = userId
            });
            var response = httpService.HttpWebRequest(jsonObject, getNotesByUserIdUrl);
            List<Note> NoteList = JsonConvert.DeserializeObject<List<Note>>(response);
            return NoteList;
        }
        public List<Note> GetNoteSharedWithMe(string userId)
        {
            object jsonObject = JsonConvert.SerializeObject(new
            {
                userId = userId
            });
            var response = httpService.HttpWebRequest(jsonObject, getSharedWithMeUrl);
            List<Note> NoteList = JsonConvert.DeserializeObject<List<Note>>(response);
            return NoteList;
        }
        public Note GetNoteById(string noteId)
        {
            object jsonObject = JsonConvert.SerializeObject(new
            {
                Id = noteId
            });
            var response = httpService.HttpWebRequest(jsonObject, getById);
            Note note= JsonConvert.DeserializeObject<Note>(response);
            return note;

        }
        public List<Note> GetNotes()
        {

                var response = httpService.HttpWebRequest(null,getAll);
                List<Note> NoteList = JsonConvert.DeserializeObject<List<Note>>(response);
                return NoteList;
               
        }
        public string Update(Note note)
        {
            object jsonObject = JsonConvert.SerializeObject(note);
            return httpService.HttpWebRequest(jsonObject, updateUrl);
        }
    }
}
