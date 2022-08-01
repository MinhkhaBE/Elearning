using E_Learning.Data;
using E_Learning.Interfaces;
using E_Learning.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Learning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly IRepository _ElearRepository;

        public SubjectController(IRepository ElearRepository)
        {
            _ElearRepository = ElearRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_ElearRepository.GetAllSubject());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var Subject = _ElearRepository.GetByIdSubject(id);
                if (Subject != null)
                {
                    return Ok(Subject);
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult CreateNew(Subject model)
        {
            try
            {
                return Ok(_ElearRepository.CreateNewSubject(model));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateById(int id, Subjectmodel subject)
        {
            if (id != subject.Idsubject)
            {
                return BadRequest();
            }
            try
            {
                _ElearRepository.UpdateByIdSubject(subject);
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }


        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            try
            {
                _ElearRepository.DeleteByIdSubject(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
