using E_Learning.Data;
using E_Learning.Interfaces;
using E_Learning.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Learning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IRepository _ElearRepository;

        public AccountController(IRepository ElearRepository)
        {
            _ElearRepository = ElearRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_ElearRepository.GetAllAccount());
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
                var Account = _ElearRepository.GetByIdAccount(id);
                if (Account != null)
                {
                    return Ok(Account);
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
        public IActionResult CreateNew(Account model)
        {
            try
            {                
                return Ok(_ElearRepository.CreateNewAccount(model));
            }
            catch
            {
                return BadRequest();
            }    
        }

        [HttpPut("{id}")]
        public IActionResult UpdateById(int id, Accountmodel account)
        {
            if (id != account.Idaccount)
            {
                return BadRequest();
            }
            try
            {
                _ElearRepository.UpdateByIdAccount(account);
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
                    _ElearRepository.DeleteByIdAccount(id);
                    return Ok();
                }
                catch
                {
                    return BadRequest();
                }

            }
        } 
    } 


