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
    public class AdminController : ControllerBase
    {
        private readonly IRepository _ElearRepository;

        public AdminController(IRepository ElearRepository)
        {
            _ElearRepository = ElearRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_ElearRepository.GetAllAdmin());
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
                var Admin = _ElearRepository.GetByIdAdmin(id);
                if (Admin != null)
                {
                    return Ok(Admin);
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
        public IActionResult CreateNew(Admin model)
        {
            try
            {
                return Ok(_ElearRepository.CreateNewAdmin(model));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateById(int id, Adminmodel admin)
        {
            if (id != admin.Idadmin)
            {
                return BadRequest();
            }
            try
            {
                _ElearRepository.UpdateByIdAdmin(admin);
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
                _ElearRepository.DeleteByIdAdmin(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }

}
