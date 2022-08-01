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
    public class ClassdetailController : ControllerBase
    {
        private readonly IRepository _ElearRepository;

        public ClassdetailController(IRepository ElearRepository)
        {
            _ElearRepository = ElearRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_ElearRepository.GetAllClassdetail());
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
                var Classdetail = _ElearRepository.GetByIdClassdetail(id);
                if (Classdetail != null)
                {
                    return Ok(Classdetail);
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
        public IActionResult CreateNew(Classdetail model)
        {
            try
            {
                return Ok(_ElearRepository.CreateNewClassdetail(model));
            }
            catch
            {
                return BadRequest();
            }

        }

        [HttpPut("{id}")]
        public IActionResult UpdateById(int id, Classdetailmodel classdetail)
        {
            if (id != classdetail.Idclassdetail)
            {
                return BadRequest();
            }
            try
            {
                _ElearRepository.UpdateByIdClassdetail(classdetail);
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
                _ElearRepository.DeleteByIdClassdetail(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
