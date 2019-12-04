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
    public class SharedNotesController : ControllerBase
    {
        private ISharedNotesService _sharedNote;

        public SharedNotesController(ISharedNotesService sharedNoteService)
        {
            _sharedNote = sharedNoteService;
        }

        [AllowAnonymous]
        [HttpPost("getbyid")]
        public IActionResult GetById([FromBody]JsonObject param)
        {
            var result = _sharedNote.GetById(Convert.ToInt32(param["sharedNoteId"].ToString()));
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost("create")]
        public IActionResult Create([FromBody]SharedNotes sharedNote)
        {
            var result = _sharedNote.Create(sharedNote);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost("delete")]
        public IActionResult Delete([FromBody]JsonObject param)
        {
            var result = _sharedNote.Delete(Convert.ToInt32(param["sharedNoteId"].ToString()));
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost("getbysenderid")]
        public IActionResult GetBySenderId([FromBody]JsonObject param)
        {
            var result = _sharedNote.GetBySenderId(Convert.ToInt32(param["userId"].ToString()));
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost("getbyrecipientid")]
        public IActionResult GetByRecipientId([FromBody]JsonObject param)
        {
            var result = _sharedNote.GetByRecipientId(Convert.ToInt32(param["userId"].ToString()));
            return Ok(result);
        }

        //[Authorize(Roles = "Admin")]
        [AllowAnonymous]
        [HttpPost("getall")]
        public IActionResult GetAll()
        {
            var result = _sharedNote.GetAll();
            return Ok(result);
        }
    }
}