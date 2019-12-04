using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotesApi.Entities;
using NotesApi.Services;
using RestSharp;

namespace NotesApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        INoteService _noteService;

        public NotesController(INoteService noteService)
        {
            _noteService = noteService;
        }
        [AllowAnonymous]
        [HttpPost("create")]
        public IActionResult Create([FromBody]Note note)
        {
            note.CreatedDate = DateTime.Now;
            var result =_noteService.Create(note);
            return Ok(result);
        }
        [AllowAnonymous]
        [HttpPost("update")]
        public IActionResult Update([FromBody]Note note)
        {
            var result = _noteService.Update(note);
            return Ok(result);
        }
        
        [HttpPost("delete")]        
        public IActionResult Delete([FromBody]JsonObject param)
        {
            var result = _noteService.Delete(Convert.ToInt32(param["id"].ToString()));
            return Ok(result);
        }
        
        [HttpPost("getbyuserid")]
        public IActionResult GetByUserId([FromBody]JsonObject param)
        {
            var result = _noteService.GetByUserId(Convert.ToInt32(param["userId"].ToString()));
            return Ok(result);
        }

       
        [HttpPost("getbyid")]
        public IActionResult GetById([FromBody]JsonObject param)
        {
            var result = _noteService.GetById(Convert.ToInt32(param["Id"].ToString()));
            return Ok(result);
        }


        [HttpPost("gesharedwithme")]
        public IActionResult GetSharedWithMe([FromBody]JsonObject param)
        {
            SharedNotesService sharedNotesService = new SharedNotesService();
            var sharedNotes = sharedNotesService.GetByRecipientId(Convert.ToInt32(param[0].ToString()));
            if(sharedNotes != null)
            {
                //IEnumerable<SharedNotes> sharedNotesList = sharedNotesService.GetByRecipientId((Convert.ToInt32(param)));
                List<Note> mySharedNotes = new List<Note>();
                foreach (SharedNotes item in sharedNotes)
                {
                    mySharedNotes.Add(_noteService.GetById(item.NoteId));
                }
                return Ok(mySharedNotes);
            }
            return null;

        }

        [HttpPost("getall")]
        public IActionResult GetAll()
        {
            var result = _noteService.GetAll();
            return Ok(result);
        }

    }
}