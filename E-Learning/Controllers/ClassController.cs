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
    public class ClassController : ControllerBase
    {
        private readonly IRepository _ElearRepository;

        public ClassController(IRepository ElearRepository)
        {
            _ElearRepository = ElearRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_ElearRepository.GetAllClass());
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
                var Class = _ElearRepository.GetByIdClass(id);
                if (Class != null)
                {
                    return Ok(Class);
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
        public IActionResult CreateNew(Class model)
        {
            try
            {
                return Ok(_ElearRepository.CreateNewClass(model));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateById(int id, Classmodel classs)
        {
            if (id != classs.Idclass)
            {
                return BadRequest();
            }
            try
            {
                _ElearRepository.UpdateByIdClass(classs);
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
                _ElearRepository.DeleteByIdClass(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }

        }
    }
}
