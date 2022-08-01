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
    public class TestController : ControllerBase
    {
        private readonly IRepository _ElearRepository;

        public TestController(IRepository ElearRepository)
        {
            _ElearRepository = ElearRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_ElearRepository.GetAllTest());
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
                var Test = _ElearRepository.GetByIdTest(id);
                if (Test != null)
                {
                    return Ok(Test);
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
        public IActionResult CreateNew(Test model)
        {
            try
            {
                return Ok(_ElearRepository.CreateNewTest(model));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateById(int id, Testmodel test)
        {
            if (id != test.Idtest)
            {
                return BadRequest();
            }
            try
            {
                _ElearRepository.UpdateByIdTest(test);
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
                _ElearRepository.DeleteByIdTest(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
