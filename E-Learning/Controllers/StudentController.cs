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
    public class StudentController : ControllerBase
    {
        private readonly MyDbContext _context;

        public StudentController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var dsStudent = _context.Students.ToList();
            return Ok(dsStudent);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var Student = _context.Students.SingleOrDefault(st => st.Idstudent == id);
            if (Student != null)
            {
                return Ok(Student);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost]
        public IActionResult CreateNew(Studentmodel model)
        {
            try
            {
                var Student = new Student
                {
                    Namestudent = model.Namestudent,
                    Gmail = model.Gmail,
                    Phone = model.Phone,
                    Gender = model.Gender,
                    Birth =model.Birth,
                    Idaccount = model.Idaccount
                    
                };

                _context.Add(Student);
                _context.SaveChanges();
                return Ok(Student);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateById(int id, Studentmodel model)
        {
            var Student = _context.Students.SingleOrDefault(st => st.Idstudent == id);
            if (Student != null)
            {
                Student.Namestudent = model.Namestudent;
                Student.Gmail = model.Gmail;
                Student.Phone = model.Phone;
                Student.Gender = model.Gender;
                Student.Birth = model.Birth;
                Student.Idaccount = model.Idaccount;
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
                var Student = _context.Students.SingleOrDefault(st => st.Idstudent == id);
                if (Student != null)
                {
                    _context.Remove(Student);
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
