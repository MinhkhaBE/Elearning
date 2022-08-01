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
    public class TeacherController : ControllerBase
    {
        private readonly IRepository _ElearRepository;

        public TeacherController(IRepository ElearRepository)
        {
            _ElearRepository = ElearRepository;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_ElearRepository.GetAllTeacher());
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
                var Teacher = _ElearRepository.GetByIdTeacher(id);
                if (Teacher != null)
                {
                    return Ok(Teacher);
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
        public IActionResult CreateNew(Teacher model)
        {
            try
            {
                return Ok(_ElearRepository.CreateNewTeacher(model));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateById(int id, Teachermodel teacher)
        {
            if (id != teacher.Idteacher)
            {
                return BadRequest();
            }
            try
            {
                _ElearRepository.UpdateByIdTeacher(teacher);
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
                _ElearRepository.DeleteByIdTeacher(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }

        }
    }
}
