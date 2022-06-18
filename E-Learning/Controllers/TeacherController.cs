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
    public class TeacherController : ControllerBase
    {
        private readonly MyDbContext _context;

        public TeacherController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var dsTeacher = _context.Teachers.ToList();
            return Ok(dsTeacher);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var Teacher = _context.Teachers.SingleOrDefault(tea => tea.Idteacher == id);
            if (Teacher != null)
            {
                return Ok(Teacher);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost]
        public IActionResult CreateNew(Teachermodel model)
        {
            try
            {
                var Teacher = new Teacher
                {
                    Nameteacher = model.Nameteacher,
                    Gmail = model.Phone,
                    Phone = model.Phone,
                    Gender = model.Gender,
                    Birth = model.Birth,
                    Idaccount = model.Idaccount
                };

                _context.Add(Teacher);
                _context.SaveChanges();
                return Ok(Teacher);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateById(int id, Teachermodel model)
        {
            var Teacher = _context.Teachers.SingleOrDefault(tea => tea.Idteacher == id);
            if (Teacher != null)
            {
                Teacher.Nameteacher = model.Nameteacher;
                Teacher.Gmail = model.Phone;
                Teacher.Phone = model.Phone;
                Teacher.Gender = model.Gender;
                Teacher.Birth = model.Birth;
                Teacher.Idaccount = model.Idaccount;
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
                var Teacher = _context.Teachers.SingleOrDefault(tea => tea.Idteacher == id);
                if (Teacher != null)
                {
                    _context.Remove(Teacher);
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
