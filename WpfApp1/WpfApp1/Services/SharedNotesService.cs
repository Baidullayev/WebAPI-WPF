using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using WpfApp1.Models;

namespace WpfApp1.Services
{
    class SharedNotesService
    {
        HttpService httpService = new HttpService();
        public string Create(SharedNote sharedNote)
        {
            string url = "http://localhost:4702/api/SharedNotes/create";
            object jsonObject = JsonConvert.SerializeObject(new
            {
                NoteId = sharedNote.NoteId,
                SenderId = sharedNote.SenderId,
                RecipientId = sharedNote.RecipientId,                
                SendingTime = sharedNote.SendingTime
            });

            string httpResponce = httpService.HttpWebRequest(jsonObject, url);
            return httpResponce;
           
        }
    }
}
