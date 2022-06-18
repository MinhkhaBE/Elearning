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
    public class ClassController : ControllerBase
    {
        private readonly MyDbContext _context;

        public ClassController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var dsClass = _context.Classes.ToList();
            return Ok(dsClass);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var Class = _context.Classes.SingleOrDefault(cl => cl.Idclass == id);
            if (Class != null)
            {
                return Ok(Class);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost]
        public IActionResult CreateNew(Classmodel model)
        {
            try
            {
                var Class = new Class
                {
                    Nameclass = model.Nameclass,
                    Topic = model.Topic,
                    Semester = model.Semester,
                    Status = model.Status,
                    Idsubject = model.Idsubject
                };
                _context.Add(Class);
                _context.SaveChanges();
                return Ok(Class);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateById(int id, Classmodel model)
        {
            var Class = _context.Classes.SingleOrDefault(cl => cl.Idclass == id);
            if (Class != null)
            {
                Class.Nameclass = model.Nameclass;
                Class.Topic = model.Topic;
                Class.Semester = model.Semester;
                Class.Status = model.Status;
                Class.Idsubject = model.Idsubject;
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
                var Class = _context.Classes.SingleOrDefault(cl => cl.Idclass == id);
                if (Class != null)
                {
                    _context.Remove(Class);
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
