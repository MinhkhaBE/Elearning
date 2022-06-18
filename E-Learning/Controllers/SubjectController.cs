using E_Learning.Data;
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
        private readonly MyDbContext _context;

        public SubjectController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var dsSubject = _context.Subjects.ToList();
            return Ok(dsSubject);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var Subject = _context.Subjects.SingleOrDefault(su => su.Idsubject == id);
            if (Subject != null)
            {
                return Ok(Subject);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost]
        public IActionResult CreateNew(Subjectmodel model)
        {
            try
            {
                var Subject = new Subject
                {
                    Namesubject = model.Namesubject                    
                };

                _context.Add(Subject);
                _context.SaveChanges();
                return Ok(Subject);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateById(int id, Subjectmodel model)
        {
            var Subject = _context.Subjects.SingleOrDefault(su => su.Idsubject == id);
            if (Subject != null)
            {
                Subject.Namesubject = model.Namesubject;

                _context.SaveChanges();
                return NoContent();
            }
            else
            {
                return NotFound();
            }

        }


        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            try
            {
                var Subject = _context.Subjects.SingleOrDefault(su => su.Idsubject == id);
                if (Subject != null)
                {
                    _context.Remove(Subject);
                    _context.SaveChanges();
                    return Ok();

                }
                return NotFound();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
