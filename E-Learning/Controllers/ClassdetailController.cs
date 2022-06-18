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
    public class ClassdetailController : ControllerBase
    {
        private readonly MyDbContext _context;

        public ClassdetailController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var dsClassdetail = _context.Classdetails.ToList();
            return Ok(dsClassdetail);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var Classdetail = _context.Classdetails.SingleOrDefault(cld => cld.Idclassdetail == id);
            if (Classdetail != null)
            {
                return Ok(Classdetail);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost]
        public IActionResult CreateNew(Classdetailmodel model)
        {
            try
            {
                var Classdetail = new Classdetail
                {
                   Passwordclass = model.Passwordclass,
                   Teacher = model.Teacher,
                   Lesson = model.Lesson,
                   Studytime = model.Studytime,
                   Schedule = model.Schedule,
                   description = model.description,
                   Idclass = model.Idclass

                };

                _context.Add(Classdetail);
                _context.SaveChanges();
                return Ok(Classdetail);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateById(int id, Classdetailmodel model)
        {
            var Classdetail = _context.Classdetails.SingleOrDefault(cld => cld.Idclassdetail == id);
            if (Classdetail != null)
            {
                Classdetail.Passwordclass = model.Passwordclass;
                Classdetail.Teacher = model.Teacher;
                Classdetail.Lesson = model.Lesson;
                Classdetail.Studytime = model.Studytime;
                Classdetail.Schedule = model.Schedule;
                Classdetail.description = model.description;
                Classdetail.Idclass = model.Idclass;
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
                var Classdetail = _context.Classdetails.SingleOrDefault(cld => cld.Idclassdetail == id);
                if (Classdetail != null)
                {
                    _context.Remove(Classdetail);
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
