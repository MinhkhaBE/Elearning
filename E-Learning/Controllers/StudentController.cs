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
    public class StudentController : ControllerBase
    {
        private readonly IRepository _ElearRepository;

        public StudentController(IRepository ElearRepository)
        {
            _ElearRepository = ElearRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_ElearRepository.GetAllStudent());
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
                var Student = _ElearRepository.GetByIdStudent(id);
                if (Student != null)
                {
                    return Ok(Student);
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
        public IActionResult CreateNew(Student model)
        {
            try
            {
                return Ok(_ElearRepository.CreateNewStudent(model));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateById(int id, Studentmodel student)
        {
            if (id != student.Idstudent)
            {
                return BadRequest();
            }
            try
            {
                _ElearRepository.UpdateByIdStudent(student);
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
                _ElearRepository.DeleteByIdStudent(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
